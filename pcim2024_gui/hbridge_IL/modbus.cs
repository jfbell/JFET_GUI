using System;
using System.IO.Ports;

namespace hbridge_IL
{
  public class modbus
  {
    public SerialPort commPort = new SerialPort();
    public string status;

    public modbus()
    {
      commPort.BaudRate = 19200;
      commPort.DataBits = 8;
      commPort.Parity = Parity.Even;
      commPort.StopBits = StopBits.One;
      commPort.WriteTimeout = 1000;
      commPort.ReadTimeout = 1000;
    }

    // Write to target holding registers, starting at offset for specified count
    public bool Write(byte mbAddress, ushort offset, ushort regCount, ref ushort[] holdReg)
    {
      // Check if port is open
      if (commPort.IsOpen)
      {
        // Outgoing message length is 9 + 2 * regCount in bytes
        //   target address:  1 byte
        //   function code:   1 byte
        //   start address:   2 bytes
        //   register count:  2 bytes
        //   byte count:      1 byte
        //   register values: 2 * register count bytes
        //   CRC:             2 bytes
        byte[] MWmessage = new byte[9 + 2 * regCount];

        // Incoming response length is always 8 bytes, except when error
        // returned the length is 5
        //   target address:  1 byte
        //   function code:   1 byte
        //   start address:   2 bytes
        //   register count:  2 bytes
        //   CRC:             2 bytes
        byte[] MWresponse = new byte[8];
        byte[] MW_CRC = new byte[2];

        // Clear port buffers
        commPort.DiscardOutBuffer();
        commPort.DiscardInBuffer();

        // Stuff data into message array
        MWmessage[0] = mbAddress;
        MWmessage[1] = 16; // MODBUS write multiple registers function code is 16
        MWmessage[2] = (byte)(offset >> 8);
        MWmessage[3] = (byte)offset;
        MWmessage[4] = (byte)(regCount >> 8);
        MWmessage[5] = (byte)regCount;
        MWmessage[6] = (byte)(regCount * 2);

        for (int i = 0; i < regCount; i++)
        {
          MWmessage[7 + 2 * i] = (byte)(holdReg[offset + i] >> 8);
          MWmessage[8 + 2 * i] = (byte)(holdReg[offset + i]);
        }

        ModGetCRC(ref MWmessage, ref MW_CRC, (ushort)(9 + 2 * regCount));
        MWmessage[MWmessage.Length - 2] = MW_CRC[0];
        MWmessage[MWmessage.Length - 1] = MW_CRC[1];

        //Send Modbus message to Serial Port:
        try
        {
          commPort.Write(MWmessage, 0, MWmessage.Length);
        }
        catch (Exception err)
        {
          status = "Error in write event: " + err.Message;
          return false;
        }

        // Evaluate response. Length = 8
        if (ModGetResponse(mbAddress, 16, ref MWresponse, 8))
        {
          status = "Ready";
          return true;
        }
        else
        {
          status = "Comm error write";
          return false;
        }
      }
      else
      {
        status = "Comm port closed";
        return false;
      }
    }

    // Read input registers from target and displays them in labels
    public bool Read(byte mbAddress, byte funcCode, ushort offset, ushort regCount, ref byte[] readBuf)
    {
      // The .Net System.IO.Ports.SerialPort is buggy.
      // Apparently the serial port buffer is only 16 deep without locking up.
      // Split reads up so that incoming datastream is <= 16 bytes long.

      // Check if port is open
      if (commPort.IsOpen)
      {
        // Outgoing message length is 8 bytes
        //   target address:  1 byte
        //   function code:   1 byte
        //   start address:   2 bytes
        //   register count:  2 bytes
        //   CRC:             2 bytes
        byte[] MRmessage = new byte[8];

        // Incoming response length is 5 + 2 * regCount in bytes, except when
        // error returned the length is 5
        //   target address:    1 byte
        //   function code:    1 byte
        //   byte count:       1 byte
        //   input registers:  2 * register count bytes
        //   CRC:              2 bytes
        //byte[] MRresponse = new byte[5 + 2 * regCount];
        byte[] MR_CRC = new byte[2];

        // Clear port buffers
        commPort.DiscardOutBuffer();
        commPort.DiscardInBuffer();

        // Stuff data into message array
        MRmessage[0] = mbAddress;
        MRmessage[1] = funcCode; // 3 = read holding regs, 4 = read input regs
        MRmessage[2] = (byte)(offset >> 8);
        MRmessage[3] = (byte)(offset);
        MRmessage[4] = (byte)(regCount >> 8);
        MRmessage[5] = (byte)(regCount);

        ModGetCRC(ref MRmessage, ref MR_CRC, 8);
        MRmessage[6] = MR_CRC[0];
        MRmessage[7] = MR_CRC[1];

        //Send Modbus message to Serial Port:
        try
        {
          commPort.Write(MRmessage, 0, MRmessage.Length);
        }
        catch (Exception err)
        {
          status = "Error in write event: " + err.Message;
          return false;
        }

        // Evaluate response. Length is 5 + 2 * register count
        return (ModGetResponse(mbAddress, 4, ref readBuf, (ushort)(5 + 2 * regCount)));
      }
      else
        return false; // Comm port was closed
    }

    // Reads response from commport, checks CRC, returns true if successful
    private bool ModGetResponse(byte mbAddress, byte GRfuncCode,
                                ref byte[] GRresponse, ushort GRlength)
    {
      ushort loopEnd;
      bool responseFlag;

      // The .Net System.IO.Ports.SerialPort is buggy.  Using ReadByte() a
      // predetermined number of times is reliable (even if not ideal).
      for (int i = 0; i < 2; i++)
      {
        try
        {
          GRresponse[i] = (byte)(commPort.ReadByte());
        }
        catch (Exception err)
        {
          status = "Error in read event: " + err.Message;
          return false;
        }
      }

      if (GRresponse[1] == (GRfuncCode + 0x80))
      { // Getting an error response back from target
        loopEnd = 5; // Error response is always 5 bytes long
        responseFlag = false;
      }
      else
      {
        loopEnd = GRlength;
        responseFlag = true;
      }

      for (int i = 2; i < loopEnd; i++)
      {
        try
        {
          GRresponse[i] = (byte)(commPort.ReadByte());
        }
        catch (Exception err)
        {
          status = "Error in read event: " + err.Message;
          return false;
        }
      }

      // Check address of incoming resonse
      if (GRresponse[0] != mbAddress)
        return false;

      // Check CRC of incoming response
      byte[] GR_CRC = new byte[2];
      ModGetCRC(ref GRresponse, ref GR_CRC, loopEnd);
      if ((GR_CRC[0] == GRresponse[loopEnd - 2]) &&
          (GR_CRC[1] == GRresponse[loopEnd - 1]) &&
           responseFlag)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    // Computes CRC on a MODBUS message with results stored in CRC array
    private void ModGetCRC(ref byte[] buf, ref byte[] CRC, ushort PDUlength)
    {
      ushort CRCword = 0xFFFF;
      byte CRChigh = 0xFF, CRClow = 0xFF;
      char CRC_LSB;

      for (int i = 0; i < PDUlength - 2; i++)
      {
        CRCword = (ushort)(CRCword ^ buf[i]);

        for (int j = 0; j < 8; j++)
        {
          CRC_LSB = (char)(CRCword & 0x0001);
          CRCword = (ushort)((CRCword >> 1) & 0x7FFF);

          if (CRC_LSB == 1)
            CRCword = (ushort)(CRCword ^ 0xA001);
        }
      }
      CRC[1] = CRChigh = (byte)((CRCword >> 8) & 0xFF);
      CRC[0] = CRClow = (byte)(CRCword & 0xFF);
    }

    // Try to open the commport. Can fail if it is currently in use elsewhere.
    public bool OpenPort()
    {
      try
      {
        if (commPort.IsOpen == false)
        {
          commPort.Open();
          return true;
        }
        return false;
      }
      catch (Exception)
      {
        return false;
      }
    }

    // Close the commport
    public void ClosePort()
    {
      if (commPort.IsOpen == true)
      {
        commPort.Close();
      }
    }
  }
}
