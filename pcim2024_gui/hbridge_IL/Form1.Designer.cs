namespace hbridge_IL
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.lbxCommPorts = new System.Windows.Forms.ListBox();
      this.btnCommPorts = new System.Windows.Forms.Button();
      this.txt_numPorts = new System.Windows.Forms.Label();
      this.lblNumPorts = new System.Windows.Forms.Label();
      this.txt_portName = new System.Windows.Forms.Label();
      this.lblPortName = new System.Windows.Forms.Label();
      this.txt_portStatus = new System.Windows.Forms.Label();
      this.lblPortStatus = new System.Windows.Forms.Label();
      this.gbxCommPort = new System.Windows.Forms.GroupBox();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.lblToolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
      this.gbxCommands = new System.Windows.Forms.GroupBox();
      this.label4 = new System.Windows.Forms.Label();
      this.rdoTimeout = new System.Windows.Forms.RadioButton();
      this.numCalTemperature = new System.Windows.Forms.NumericUpDown();
      this.rdoStayOn = new System.Windows.Forms.RadioButton();
      this.btnCalTemperature = new System.Windows.Forms.Button();
      this.label18 = new System.Windows.Forms.Label();
      this.btnSetDuration = new System.Windows.Forms.Button();
      this.numDurationSet = new System.Windows.Forms.NumericUpDown();
      this.label2 = new System.Windows.Forms.Label();
      this.numCurrentSet = new System.Windows.Forms.NumericUpDown();
      this.btnReset = new System.Windows.Forms.Button();
      this.btnRun = new System.Windows.Forms.Button();
      this.btnUpdateSettings = new System.Windows.Forms.Button();
      this.gbxInputRegs = new System.Windows.Forms.GroupBox();
      this.lblElapsedTime = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.lblOnOff = new System.Windows.Forms.Label();
      this.lblCurrent = new System.Windows.Forms.Label();
      this.lblTemperature = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.txtTestedHoursStatus = new System.Windows.Forms.Label();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.timer2 = new System.Windows.Forms.Timer(this.components);
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.gbxCommPort.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.gbxCommands.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numCalTemperature)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numDurationSet)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numCurrentSet)).BeginInit();
      this.gbxInputRegs.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // lbxCommPorts
      // 
      this.lbxCommPorts.FormattingEnabled = true;
      this.lbxCommPorts.ItemHeight = 16;
      this.lbxCommPorts.Location = new System.Drawing.Point(8, 19);
      this.lbxCommPorts.Margin = new System.Windows.Forms.Padding(4);
      this.lbxCommPorts.Name = "lbxCommPorts";
      this.lbxCommPorts.Size = new System.Drawing.Size(159, 116);
      this.lbxCommPorts.TabIndex = 0;
      // 
      // btnCommPorts
      // 
      this.btnCommPorts.Location = new System.Drawing.Point(9, 143);
      this.btnCommPorts.Margin = new System.Windows.Forms.Padding(4);
      this.btnCommPorts.Name = "btnCommPorts";
      this.btnCommPorts.Size = new System.Drawing.Size(160, 28);
      this.btnCommPorts.TabIndex = 1;
      this.btnCommPorts.Text = "Find target";
      this.btnCommPorts.UseVisualStyleBackColor = true;
      this.btnCommPorts.Click += new System.EventHandler(this.btnCommPorts_Click);
      // 
      // txt_numPorts
      // 
      this.txt_numPorts.AutoSize = true;
      this.txt_numPorts.Location = new System.Drawing.Point(5, 178);
      this.txt_numPorts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.txt_numPorts.Name = "txt_numPorts";
      this.txt_numPorts.Size = new System.Drawing.Size(102, 16);
      this.txt_numPorts.TabIndex = 3;
      this.txt_numPorts.Text = "Number of ports";
      // 
      // lblNumPorts
      // 
      this.lblNumPorts.AutoSize = true;
      this.lblNumPorts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblNumPorts.Location = new System.Drawing.Point(120, 178);
      this.lblNumPorts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblNumPorts.Name = "lblNumPorts";
      this.lblNumPorts.Size = new System.Drawing.Size(16, 18);
      this.lblNumPorts.TabIndex = 4;
      this.lblNumPorts.Text = "0";
      // 
      // txt_portName
      // 
      this.txt_portName.AutoSize = true;
      this.txt_portName.Location = new System.Drawing.Point(5, 198);
      this.txt_portName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.txt_portName.Name = "txt_portName";
      this.txt_portName.Size = new System.Drawing.Size(71, 16);
      this.txt_portName.TabIndex = 5;
      this.txt_portName.Text = "Port Name";
      // 
      // lblPortName
      // 
      this.lblPortName.AutoSize = true;
      this.lblPortName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblPortName.Location = new System.Drawing.Point(120, 198);
      this.lblPortName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblPortName.Name = "lblPortName";
      this.lblPortName.Size = new System.Drawing.Size(15, 18);
      this.lblPortName.TabIndex = 6;
      this.lblPortName.Text = "  ";
      // 
      // txt_portStatus
      // 
      this.txt_portStatus.AutoSize = true;
      this.txt_portStatus.Location = new System.Drawing.Point(5, 218);
      this.txt_portStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.txt_portStatus.Name = "txt_portStatus";
      this.txt_portStatus.Size = new System.Drawing.Size(71, 16);
      this.txt_portStatus.TabIndex = 7;
      this.txt_portStatus.Text = "Port Status";
      // 
      // lblPortStatus
      // 
      this.lblPortStatus.AutoSize = true;
      this.lblPortStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblPortStatus.Location = new System.Drawing.Point(120, 218);
      this.lblPortStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblPortStatus.Name = "lblPortStatus";
      this.lblPortStatus.Size = new System.Drawing.Size(52, 18);
      this.lblPortStatus.TabIndex = 8;
      this.lblPortStatus.Text = "Closed";
      // 
      // gbxCommPort
      // 
      this.gbxCommPort.BackColor = System.Drawing.Color.LightSteelBlue;
      this.gbxCommPort.Controls.Add(this.txt_numPorts);
      this.gbxCommPort.Controls.Add(this.lblNumPorts);
      this.gbxCommPort.Controls.Add(this.txt_portName);
      this.gbxCommPort.Controls.Add(this.lblPortName);
      this.gbxCommPort.Controls.Add(this.lbxCommPorts);
      this.gbxCommPort.Controls.Add(this.txt_portStatus);
      this.gbxCommPort.Controls.Add(this.btnCommPorts);
      this.gbxCommPort.Controls.Add(this.lblPortStatus);
      this.gbxCommPort.Location = new System.Drawing.Point(12, 6);
      this.gbxCommPort.Margin = new System.Windows.Forms.Padding(4);
      this.gbxCommPort.Name = "gbxCommPort";
      this.gbxCommPort.Padding = new System.Windows.Forms.Padding(4);
      this.gbxCommPort.Size = new System.Drawing.Size(187, 244);
      this.gbxCommPort.TabIndex = 9;
      this.gbxCommPort.TabStop = false;
      this.gbxCommPort.Text = "COM Port Connection";
      // 
      // statusStrip1
      // 
      this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblToolStripStatus});
      this.statusStrip1.Location = new System.Drawing.Point(0, 430);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
      this.statusStrip1.Size = new System.Drawing.Size(555, 26);
      this.statusStrip1.TabIndex = 10;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // lblToolStripStatus
      // 
      this.lblToolStripStatus.Name = "lblToolStripStatus";
      this.lblToolStripStatus.Size = new System.Drawing.Size(151, 20);
      this.lblToolStripStatus.Text = "toolStripStatusLabel1";
      // 
      // gbxCommands
      // 
      this.gbxCommands.BackColor = System.Drawing.Color.LightSteelBlue;
      this.gbxCommands.Controls.Add(this.label4);
      this.gbxCommands.Controls.Add(this.rdoTimeout);
      this.gbxCommands.Controls.Add(this.numCalTemperature);
      this.gbxCommands.Controls.Add(this.rdoStayOn);
      this.gbxCommands.Controls.Add(this.btnCalTemperature);
      this.gbxCommands.Controls.Add(this.label18);
      this.gbxCommands.Controls.Add(this.btnSetDuration);
      this.gbxCommands.Controls.Add(this.numDurationSet);
      this.gbxCommands.Controls.Add(this.label2);
      this.gbxCommands.Controls.Add(this.numCurrentSet);
      this.gbxCommands.Controls.Add(this.btnReset);
      this.gbxCommands.Controls.Add(this.btnRun);
      this.gbxCommands.Controls.Add(this.btnUpdateSettings);
      this.gbxCommands.Location = new System.Drawing.Point(207, 6);
      this.gbxCommands.Margin = new System.Windows.Forms.Padding(4);
      this.gbxCommands.Name = "gbxCommands";
      this.gbxCommands.Padding = new System.Windows.Forms.Padding(4);
      this.gbxCommands.Size = new System.Drawing.Size(338, 244);
      this.gbxCommands.TabIndex = 10;
      this.gbxCommands.TabStop = false;
      this.gbxCommands.Text = "Commands";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(272, 170);
      this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(20, 16);
      this.label4.TabIndex = 19;
      this.label4.Text = "°C";
      // 
      // rdoTimeout
      // 
      this.rdoTimeout.AutoSize = true;
      this.rdoTimeout.Location = new System.Drawing.Point(176, 96);
      this.rdoTimeout.Name = "rdoTimeout";
      this.rdoTimeout.Size = new System.Drawing.Size(143, 20);
      this.rdoTimeout.TabIndex = 28;
      this.rdoTimeout.TabStop = true;
      this.rdoTimeout.Text = "Switch off at timeout";
      this.rdoTimeout.UseVisualStyleBackColor = true;
      // 
      // numCalTemperature
      // 
      this.numCalTemperature.Location = new System.Drawing.Point(177, 168);
      this.numCalTemperature.Margin = new System.Windows.Forms.Padding(4);
      this.numCalTemperature.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
      this.numCalTemperature.Name = "numCalTemperature";
      this.numCalTemperature.Size = new System.Drawing.Size(87, 22);
      this.numCalTemperature.TabIndex = 18;
      this.numCalTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.numCalTemperature.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
      // 
      // rdoStayOn
      // 
      this.rdoStayOn.AutoSize = true;
      this.rdoStayOn.Checked = true;
      this.rdoStayOn.Location = new System.Drawing.Point(9, 96);
      this.rdoStayOn.Name = "rdoStayOn";
      this.rdoStayOn.Size = new System.Drawing.Size(123, 20);
      this.rdoStayOn.TabIndex = 27;
      this.rdoStayOn.TabStop = true;
      this.rdoStayOn.Text = "No duration limit";
      this.rdoStayOn.UseVisualStyleBackColor = true;
      this.rdoStayOn.CheckedChanged += new System.EventHandler(this.rdoStayOn_CheckedChanged);
      // 
      // btnCalTemperature
      // 
      this.btnCalTemperature.Location = new System.Drawing.Point(9, 164);
      this.btnCalTemperature.Margin = new System.Windows.Forms.Padding(4);
      this.btnCalTemperature.Name = "btnCalTemperature";
      this.btnCalTemperature.Size = new System.Drawing.Size(160, 28);
      this.btnCalTemperature.TabIndex = 16;
      this.btnCalTemperature.Text = "Calibrate temperature";
      this.btnCalTemperature.UseVisualStyleBackColor = true;
      this.btnCalTemperature.Click += new System.EventHandler(this.btnCalTemperature_Click);
      // 
      // label18
      // 
      this.label18.AutoSize = true;
      this.label18.Location = new System.Drawing.Point(271, 134);
      this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label18.Name = "label18";
      this.label18.Size = new System.Drawing.Size(53, 16);
      this.label18.TabIndex = 13;
      this.label18.Text = "Minutes";
      // 
      // btnSetDuration
      // 
      this.btnSetDuration.Enabled = false;
      this.btnSetDuration.Location = new System.Drawing.Point(8, 128);
      this.btnSetDuration.Margin = new System.Windows.Forms.Padding(4);
      this.btnSetDuration.Name = "btnSetDuration";
      this.btnSetDuration.Size = new System.Drawing.Size(160, 28);
      this.btnSetDuration.TabIndex = 26;
      this.btnSetDuration.Text = "Set on duration";
      this.btnSetDuration.UseVisualStyleBackColor = true;
      this.btnSetDuration.Click += new System.EventHandler(this.btnSetTestDuration_Click);
      // 
      // numDurationSet
      // 
      this.numDurationSet.Enabled = false;
      this.numDurationSet.Location = new System.Drawing.Point(176, 132);
      this.numDurationSet.Margin = new System.Windows.Forms.Padding(4);
      this.numDurationSet.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
      this.numDurationSet.Name = "numDurationSet";
      this.numDurationSet.Size = new System.Drawing.Size(87, 22);
      this.numDurationSet.TabIndex = 0;
      this.numDurationSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.numDurationSet.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(271, 62);
      this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(42, 16);
      this.label2.TabIndex = 15;
      this.label2.Text = "Amps";
      // 
      // numCurrentSet
      // 
      this.numCurrentSet.Location = new System.Drawing.Point(176, 60);
      this.numCurrentSet.Margin = new System.Windows.Forms.Padding(4);
      this.numCurrentSet.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
      this.numCurrentSet.Name = "numCurrentSet";
      this.numCurrentSet.Size = new System.Drawing.Size(87, 22);
      this.numCurrentSet.TabIndex = 14;
      this.numCurrentSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.numCurrentSet.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
      // 
      // btnReset
      // 
      this.btnReset.Enabled = false;
      this.btnReset.Location = new System.Drawing.Point(8, 200);
      this.btnReset.Margin = new System.Windows.Forms.Padding(4);
      this.btnReset.Name = "btnReset";
      this.btnReset.Size = new System.Drawing.Size(160, 28);
      this.btnReset.TabIndex = 2;
      this.btnReset.Text = "Reset";
      this.btnReset.UseVisualStyleBackColor = true;
      this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
      // 
      // btnRun
      // 
      this.btnRun.Enabled = false;
      this.btnRun.Location = new System.Drawing.Point(8, 20);
      this.btnRun.Margin = new System.Windows.Forms.Padding(4);
      this.btnRun.Name = "btnRun";
      this.btnRun.Size = new System.Drawing.Size(160, 28);
      this.btnRun.TabIndex = 1;
      this.btnRun.Text = "Switch on";
      this.btnRun.UseVisualStyleBackColor = true;
      this.btnRun.Click += new System.EventHandler(this.btnRunTest_Click);
      // 
      // btnUpdateSettings
      // 
      this.btnUpdateSettings.Location = new System.Drawing.Point(8, 56);
      this.btnUpdateSettings.Margin = new System.Windows.Forms.Padding(4);
      this.btnUpdateSettings.Name = "btnUpdateSettings";
      this.btnUpdateSettings.Size = new System.Drawing.Size(160, 28);
      this.btnUpdateSettings.TabIndex = 0;
      this.btnUpdateSettings.Text = "Set current limit";
      this.btnUpdateSettings.UseVisualStyleBackColor = true;
      this.btnUpdateSettings.Click += new System.EventHandler(this.btnUpdateSettings_Click);
      // 
      // gbxInputRegs
      // 
      this.gbxInputRegs.Controls.Add(this.lblElapsedTime);
      this.gbxInputRegs.Controls.Add(this.label3);
      this.gbxInputRegs.Controls.Add(this.lblOnOff);
      this.gbxInputRegs.Controls.Add(this.lblCurrent);
      this.gbxInputRegs.Controls.Add(this.lblTemperature);
      this.gbxInputRegs.Controls.Add(this.label1);
      this.gbxInputRegs.Controls.Add(this.txtTestedHoursStatus);
      this.gbxInputRegs.Location = new System.Drawing.Point(207, 258);
      this.gbxInputRegs.Margin = new System.Windows.Forms.Padding(4);
      this.gbxInputRegs.Name = "gbxInputRegs";
      this.gbxInputRegs.Padding = new System.Windows.Forms.Padding(4);
      this.gbxInputRegs.Size = new System.Drawing.Size(338, 162);
      this.gbxInputRegs.TabIndex = 14;
      this.gbxInputRegs.TabStop = false;
      this.gbxInputRegs.Text = "Status";
      // 
      // lblElapsedTime
      // 
      this.lblElapsedTime.AutoSize = true;
      this.lblElapsedTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblElapsedTime.Location = new System.Drawing.Point(176, 129);
      this.lblElapsedTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblElapsedTime.Name = "lblElapsedTime";
      this.lblElapsedTime.Size = new System.Drawing.Size(16, 18);
      this.lblElapsedTime.TabIndex = 36;
      this.lblElapsedTime.Text = "0";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(8, 129);
      this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(118, 16);
      this.label3.TabIndex = 35;
      this.label3.Text = "Elapsed time (min)";
      // 
      // lblOnOff
      // 
      this.lblOnOff.BackColor = System.Drawing.Color.IndianRed;
      this.lblOnOff.Location = new System.Drawing.Point(8, 20);
      this.lblOnOff.Name = "lblOnOff";
      this.lblOnOff.Size = new System.Drawing.Size(160, 28);
      this.lblOnOff.TabIndex = 34;
      this.lblOnOff.Text = "Off";
      this.lblOnOff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lblCurrent
      // 
      this.lblCurrent.AutoSize = true;
      this.lblCurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblCurrent.Location = new System.Drawing.Point(176, 92);
      this.lblCurrent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblCurrent.Name = "lblCurrent";
      this.lblCurrent.Size = new System.Drawing.Size(16, 18);
      this.lblCurrent.TabIndex = 33;
      this.lblCurrent.Text = "0";
      // 
      // lblTemperature
      // 
      this.lblTemperature.AutoSize = true;
      this.lblTemperature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblTemperature.Enabled = false;
      this.lblTemperature.Location = new System.Drawing.Point(176, 54);
      this.lblTemperature.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblTemperature.Name = "lblTemperature";
      this.lblTemperature.Size = new System.Drawing.Size(23, 18);
      this.lblTemperature.TabIndex = 32;
      this.lblTemperature.Text = "25";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(8, 56);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(109, 16);
      this.label1.TabIndex = 31;
      this.label1.Text = "Temperature (°C)";
      // 
      // txtTestedHoursStatus
      // 
      this.txtTestedHoursStatus.AutoSize = true;
      this.txtTestedHoursStatus.Location = new System.Drawing.Point(8, 92);
      this.txtTestedHoursStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.txtTestedHoursStatus.Name = "txtTestedHoursStatus";
      this.txtTestedHoursStatus.Size = new System.Drawing.Size(69, 16);
      this.txtTestedHoursStatus.TabIndex = 25;
      this.txtTestedHoursStatus.Text = "Current (A)";
      // 
      // timer1
      // 
      this.timer1.Interval = 1000;
      this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
      // 
      // imageList1
      // 
      this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList1.Images.SetKeyName(0, "black_bulb.png");
      this.imageList1.Images.SetKeyName(1, "black_bulb_in_circle.png");
      this.imageList1.Images.SetKeyName(2, "white_bulb_on_blue.png");
      // 
      // pictureBox1
      // 
      this.pictureBox1.Location = new System.Drawing.Point(12, 257);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(187, 163);
      this.pictureBox1.TabIndex = 29;
      this.pictureBox1.TabStop = false;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.LightSteelBlue;
      this.ClientSize = new System.Drawing.Size(555, 456);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.gbxInputRegs);
      this.Controls.Add(this.gbxCommands);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.gbxCommPort);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "Form1";
      this.Text = "Qorvo – Semiconductor Circuit Breaker Demo";
      this.gbxCommPort.ResumeLayout(false);
      this.gbxCommPort.PerformLayout();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.gbxCommands.ResumeLayout(false);
      this.gbxCommands.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numCalTemperature)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numDurationSet)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numCurrentSet)).EndInit();
      this.gbxInputRegs.ResumeLayout(false);
      this.gbxInputRegs.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ListBox lbxCommPorts;
    private System.Windows.Forms.Label txt_numPorts;
    private System.Windows.Forms.Label lblNumPorts;
    private System.Windows.Forms.Label txt_portName;
    private System.Windows.Forms.Label lblPortName;
    private System.Windows.Forms.Label txt_portStatus;
    private System.Windows.Forms.Label lblPortStatus;
    private System.Windows.Forms.Button btnCommPorts;
    private System.Windows.Forms.GroupBox gbxCommPort;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel lblToolStripStatus;
    private System.Windows.Forms.GroupBox gbxCommands;
    private System.Windows.Forms.Button btnRun;
    private System.Windows.Forms.Button btnUpdateSettings;
    private System.Windows.Forms.GroupBox gbxInputRegs;
    private System.Windows.Forms.Button btnReset;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.Timer timer2;
    private System.Windows.Forms.Label txtTestedHoursStatus;
    private System.Windows.Forms.Button btnSetDuration;
    private System.Windows.Forms.Label label18;
    private System.Windows.Forms.NumericUpDown numDurationSet;
    private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblTemperature;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numCurrentSet;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.Label lblOnOff;
        private System.Windows.Forms.RadioButton rdoTimeout;
        private System.Windows.Forms.RadioButton rdoStayOn;
    private System.Windows.Forms.Label lblElapsedTime;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.NumericUpDown numCalTemperature;
    private System.Windows.Forms.Button btnCalTemperature;
    private System.Windows.Forms.PictureBox pictureBox1;
  }
}

