using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Drawing;

namespace hbridge_IL
{
  public partial class Form1 : Form
  {
		// MODBUS instantiations
		modbus mb = new modbus();
		byte modSlvAddr = 120; // MODBUS target address
		ushort IRlength = 5;
		ushort HRlength = 8;
		ushort[] modInputReg = new ushort[5];
		ushort[] modHoldReg  = new ushort[8];
		byte[] response      = new byte[21]; // Normally 5 + 2 * max(IRlength, HRlength)
		byte IRregs = 4; // Function code 4 = read input registers
		byte HRregs = 3; // Function code 3 = read holding registers

		// The following are indexes into the modInputReg and modHoldReg arrays
		int IRtopState = 0, IRfault = 1, IRtemp = 2, IRcurrentx10 = 3, IRminutes = 4;
		int HRgui = 0, HRon = 1, HRreset = 2, HRiLimit = 3, HRstayOn = 4, HRdur = 5;
		int HRcalTval = 6, HRcalT = 7;

		// Com port
		enum portStates { init, connectedToPort };
		int portState = (int)portStates.init;
		int numPorts;

		// Flags to allow seamless updates
		bool selectionsUpdated = false;
		short timerTick = 0;

		public Form1()
		{
			InitializeComponent();

			modHoldReg[HRgui] = 0; // 0 means not synced to target
			modHoldReg[HRon] = 0;  // 0 means off
			modHoldReg[HRreset] = 0;
			modHoldReg[HRdur] = (ushort)numDurationSet.Value;

			lblToolStripStatus.Text = "Please click 'Find target'";
		}

		#region Comm Port Settings and Status
		private void btnCommPorts_Click(object sender, EventArgs e)
		{
			bool foundPort = false;

			if (portState == (int)portStates.init)
			{
				lbxCommPorts.Items.Clear();
				numPorts = 0;
				foreach (string s in SerialPort.GetPortNames())
				{
					lbxCommPorts.Items.Add(s);
					numPorts++;
				}

				lblNumPorts.Text = numPorts.ToString();
				lblPortStatus.Text = "Closed";

				if (numPorts >= 1)
				{
					// Attempt to sync to target by setting GUI flag in holding register.
					// Only a valid target will respond with the correct MODBUS address
					// and function code.
					modHoldReg[HRgui] = 1; // Set GUI flag
		      // modHoldReg[HRon] = 0; // Clear on flag
		      // modHoldReg[HRreset] = 0; // Clear reset flag
					for (int i = 0; i < numPorts; i++)
					{
						try { mb.commPort.PortName = lbxCommPorts.Items[i].ToString(); }
						catch(Exception) { continue; }

            if (mb.OpenPort())
						{
							if (mb.Write(modSlvAddr, (ushort)HRgui, 1, ref modHoldReg))
							{
								// This port responded correctly, so it is our target
								lbxCommPorts.SetSelected(i, true);
								lblPortName.Text = lbxCommPorts.SelectedItem.ToString();
								btnCommPorts.Text = "Disconnect";
								lblPortStatus.Text = "Open";
								lblToolStripStatus.Text = "Found target on selected port.";
								portState = (int)portStates.connectedToPort;
								btnUpdateSettings.Enabled = true;
								btnReset.Enabled = true;
								foundPort = true;

								// Read holding registers to display existing settings in uC
								if(mb.Read(modSlvAddr, HRregs, (ushort)HRon, (ushort)(HRlength - HRon), ref response))
								{
									modHoldReg[HRon] = (ushort)((response[3] << 8) + response[4]);
									modHoldReg[HRreset] = (ushort)((response[5] << 8) + response[6]);
									modHoldReg[HRiLimit] = (ushort)((response[7] << 8) + response[8]);
									numCurrentSet.Value = modHoldReg[HRiLimit];
									modHoldReg[HRstayOn] = (ushort)((response[9] << 8) + response[10]);
									modHoldReg[HRdur] = (ushort)((response[11] << 8) + response[12]);
									numDurationSet.Value = modHoldReg[HRdur];
									modHoldReg[HRcalTval] = (ushort)((response[13] << 8) + response[14]);
									numCalTemperature.Value = modHoldReg[HRcalTval];

									if (modHoldReg[HRstayOn] == 0)
									{
                    btnSetDuration.Enabled = true;
										numDurationSet.Enabled = true;
                    rdoStayOn.Checked = false;
										rdoTimeout.Checked = true;
									}
									else
									{
                    btnSetDuration.Enabled = false;
										numDurationSet.Enabled = false;
                    rdoStayOn.Checked = true;
										rdoTimeout.Checked = false;
									}

									// Write and read was successful, so make sure timer is started.
									timerTick = 0; // Will take at least 2 seconds before input register read
									timer1.Enabled = true;
									timer1.Start();
									break;
								}
							}
							else
							mb.ClosePort();
						}
					}
				}

				if (!foundPort)
				{
					modHoldReg[HRgui] = 0; // Failed to sync to target
					lblToolStripStatus.Text =
					"Target not found. Please check target program, connection, and power.";
				}
			}
			else if (portState == (int)portStates.connectedToPort)
			{
				timerTick = 0;
				timer1.Stop(); // Prevent further timed reads of input registers

				// Stop inverter, settings back to default values
				lblToolStripStatus.Text = "Sending data to target...";
				modHoldReg[HRgui] = 0; // Clear gui flag
				modHoldReg[HRon] = 0; // Clear on flag
				mb.Write(modSlvAddr, 0, 2, ref modHoldReg);
				modHoldReg[HRdur] = (ushort)numDurationSet.Value;
				lblToolStripStatus.Text = mb.status;

				mb.ClosePort();
				lblNumPorts.Text = "0";
				lblPortName.Text = null;
				lblPortStatus.Text = "Closed";
				btnCommPorts.Text = "Find target";
				btnUpdateSettings.Enabled = false;
				btnRun.Enabled = false;
				btnRun.Text = "Switch on";
				btnReset.Enabled = false;
				portState = (int)portStates.init;
			}
		}
		#endregion

		private void Timer1_Tick(object sender, EventArgs e)
		{
			timerTick++;
			if (timerTick >= 2) // 2 second interval
			{
				timerTick = 0;

				// Read target input registers, skipping state
				if ((mb.status == "Ready") &&
				(mb.Read(modSlvAddr, IRregs, 0, IRlength, ref response)))
				{
					modInputReg[IRtopState] = (ushort)((response[3] << 8) + response[4]);
					modInputReg[IRfault] = (ushort)((response[5] << 8) + response[6]);
					modInputReg[IRtemp] = (ushort)((response[7] << 8) + response[8]);
					modInputReg[IRcurrentx10] = (ushort)((response[9] << 8) + response[10]);
					modInputReg[IRminutes] = (ushort)((response[11] << 8) + response[12]);
					lblTemperature.Text = ((double)modInputReg[IRtemp] - 273).ToString();
					lblCurrent.Text = ((double)modInputReg[IRcurrentx10] / 10).ToString(); // Divide by ten for decimal scaling
					lblElapsedTime.Text = ((double)modInputReg[IRminutes]).ToString();

					if (modInputReg[IRtopState] == 4) // Timed out
					{
						modHoldReg[HRon] = 0; // Clear the on flag
						btnRun.Enabled = false;
						btnReset.Enabled = true;
            btnRun.Text = "Switch on";
            lblOnOff.Text = "Timed out";
						lblOnOff.BackColor = Color.IndianRed;
          }
					else if (modInputReg[IRtopState] == 5) // Circuit breaker faulted
          {
            modHoldReg[HRon] = 0; // Clear the on flag
            btnRun.Enabled = false;
						btnReset.Enabled = true;
            btnRun.Text = "Switch on";
						if ((modInputReg[IRfault] & 0x02) == 2) // Overtemperature trip
							lblOnOff.Text = "Overtemperature";
						else if ((modInputReg[IRfault] & 0x01) == 1) // Overcurrent trip
							lblOnOff.Text = "Overcurrent";
						else
							lblOnOff.Text = "Unknown fault";

            lblOnOff.BackColor = Color.Gold;
          }
          mb.status = "Ready";
				}
				else
				{
					mb.status = "Comm error read";
					//timer1.Stop(); // Prevent further timed reads of input registers
				}
			}
		}

		private void numIlim_ValueChanged(object sender, EventArgs e)
		{
			selectionsUpdated = true;
			modHoldReg[HRiLimit] = (ushort)(numCurrentSet.Value);
			if (modHoldReg[HRon] == 0)
				btnRun.Enabled = false;
		}

		private void numDuration_ValueChanged(object sender, EventArgs e)
		{
			selectionsUpdated = true;
			modHoldReg[HRdur] = (ushort)(numDurationSet.Value);
			if (modHoldReg[HRon] == 0)
				btnRun.Enabled = false;
		}

		private void btnUpdateSettings_Click(object sender, EventArgs e)
		{
			modHoldReg[HRiLimit] = (ushort)(numCurrentSet.Value);

			// Write data to target holding registers
			// First reset the timer tick to avoid a collision with the
			// timer-generated read of target input registers
			timerTick = 0; // Will take at least 2 seconds before input register read
			lblToolStripStatus.Text = "Sending data to target...";
			// Write to target holding registers containing settings
			// if (!mb.Write(modSlvAddr, 0, HRlength, ref modHoldReg))
			// timer1.Stop(); // If write fails, stop timed reads of input registers
			mb.Write(modSlvAddr, 0, HRlength, ref modHoldReg);
        lblToolStripStatus.Text = mb.status;

			selectionsUpdated = false;
			btnRun.Enabled = true;
			if (modHoldReg[HRon] == 0)
			{
				btnRun.Text = "Switch on";
				btnReset.Enabled = true;
			}
			else
				btnRun.Text = "Switch off";
		}

		private void btnRunTest_Click(object sender, EventArgs e)
		{
			if (modHoldReg[HRon] == 0)
			{
				modHoldReg[HRon] = 1; // Set the on flag
				btnRun.Text = "Switch off";
				lblOnOff.Text = "On";
				lblOnOff.BackColor = Color.MediumSeaGreen;
				btnReset.Enabled = false;
				lblTemperature.Enabled = true;
			}
			else
			{
				modHoldReg[HRon] = 0; // Clear the on flag
				btnRun.Text = "Switch on";
				lblOnOff.Text = "Off";
				lblOnOff.BackColor = Color.IndianRed;

				if (selectionsUpdated)
					btnRun.Enabled = false;
				else
					btnReset.Enabled = true;

				lblTemperature.Enabled = false;
			}

			// Send on flag to target
			// First reset the timer tick to avoid a collision with the
			// timer-generated read of target input registers
			timerTick = 0; // Will take at least 2 seconds before input register read
			lblToolStripStatus.Text = "Sending data to target...";
			// if(!mb.Write(modSlvAddr, (ushort)HRon, 1, ref modHoldReg))
			// timer1.Stop(); // If write fails, stop timed reads of input registers
			mb.Write(modSlvAddr, (ushort)HRon, 1, ref modHoldReg);
        lblToolStripStatus.Text = mb.status;
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			modHoldReg[HRreset] = 1;

			// Send reset flag to target
			// First reset the timer tick to avoid a collision with the
			// timer-generated read of target input registers
			timerTick = 0; // Will take at least 2 seconds before input register read
			lblToolStripStatus.Text = "Sending data to target...";
			mb.Write(modSlvAddr, (ushort)HRreset, 1, ref modHoldReg); // If write fails, stop timed reads of input registers
			lblToolStripStatus.Text = mb.status;
      modHoldReg[HRreset] = 0; // Clear flag to avoid repeated resets
			btnRun.Enabled = true;
      lblOnOff.Text = "Off";
      lblOnOff.BackColor = Color.IndianRed;
    }

    private void rdoStayOn_CheckedChanged(object sender, EventArgs e)
		{
      if (rdoTimeout.Checked)
      {
        modHoldReg[HRstayOn] = 0;
        btnSetDuration.Enabled = true;
        numDurationSet.Enabled = true;
      }
      else // if (rdoStayOn.Checked)
			{
				modHoldReg[HRstayOn] = 1;
				btnSetDuration.Enabled = false;
				numDurationSet.Enabled = false;
			}

			// Send on type flag to target
			// First reset the timer tick to avoid a collision with the
			// timer-generated read of target input registers
			timerTick = 0; // Will take at least 2 seconds before input register read
			lblToolStripStatus.Text = "Sending data to target...";
			mb.Write(modSlvAddr, (ushort)HRstayOn, 1, ref modHoldReg); // If write fails, stop timed reads of input registers
			lblToolStripStatus.Text = mb.status;
		}

		private void btnSetTestDuration_Click(object sender, EventArgs e)
		{
			modHoldReg[HRdur] = (ushort)numDurationSet.Value;

			// First reset the timer tick to avoid a collision with the
			// timer-generated read of target input registers
			timerTick = 0; // Will take at least 2 seconds before input register read
			lblToolStripStatus.Text = "Sending data to target...";
			mb.Write(modSlvAddr, (ushort)HRdur, 1, ref modHoldReg); // If write fails, stop timed reads of input registers
			lblToolStripStatus.Text = mb.status;
		}

		private void btnCalTemperature_Click(object sender, EventArgs e)
		{
			modHoldReg[HRcalTval] = (ushort)(numCalTemperature.Value + 273);
			modHoldReg[HRcalT] = 1; // Set temperature calibration due flag

      // First reset the timer tick to avoid a collision with the
      // timer-generated read of target input registers
      timerTick = 0; // Will take at least 2 seconds before input register read
      lblToolStripStatus.Text = "Sending data to target...";
			// if (!mb.Write(modSlvAddr, (ushort)HRcalTval, 2, ref modHoldReg))
			//  timer1.Stop(); // If write fails, stop timed reads of input registers
			mb.Write(modSlvAddr, (ushort)HRcalTval, 2, ref modHoldReg);
        lblToolStripStatus.Text = mb.status;

			modHoldReg[HRcalT] = 0; // Clear flag to avoid repeated calibrations
    }
  }
}
