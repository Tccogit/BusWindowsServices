namespace ClassLibrary
{
    partial class AVLServiceControl
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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.chkTicket = new System.Windows.Forms.CheckBox();
			this.chkAVL = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label = new System.Windows.Forms.Label();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabelConnectn = new System.Windows.Forms.ToolStripStatusLabel();
			this.chkBusLocation = new System.Windows.Forms.CheckBox();
			this.ChkSocket = new System.Windows.Forms.CheckBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtPeriod = new System.Windows.Forms.TextBox();
			this.txtBackTime = new System.Windows.Forms.TextBox();
			this.chkDistanceMeasurement = new System.Windows.Forms.CheckBox();
			this.chkKillSleepCon = new System.Windows.Forms.CheckBox();
			this.chkOffline = new System.Windows.Forms.CheckBox();
			this.TxtPort = new System.Windows.Forms.TextBox();
			this.BspTcpServer = new ClassLibrary.BSPTCPServer();
			this.statusStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(0, 171);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(324, 219);
			this.listBox1.TabIndex = 2;
			// 
			// chkTicket
			// 
			this.chkTicket.AutoSize = true;
			this.chkTicket.Location = new System.Drawing.Point(12, 54);
			this.chkTicket.Name = "chkTicket";
			this.chkTicket.Size = new System.Drawing.Size(56, 17);
			this.chkTicket.TabIndex = 4;
			this.chkTicket.Text = "Ticket";
			this.chkTicket.UseVisualStyleBackColor = true;
			this.chkTicket.CheckedChanged += new System.EventHandler(this.chkTicket_CheckedChanged_2);
			// 
			// chkAVL
			// 
			this.chkAVL.AutoSize = true;
			this.chkAVL.Location = new System.Drawing.Point(12, 31);
			this.chkAVL.Name = "chkAVL";
			this.chkAVL.Size = new System.Drawing.Size(46, 17);
			this.chkAVL.TabIndex = 4;
			this.chkAVL.Text = "AVL";
			this.chkAVL.UseVisualStyleBackColor = true;
			this.chkAVL.CheckedChanged += new System.EventHandler(this.chkAVL_CheckedChanged);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 5;
			this.button1.Text = "Save Log";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label
			// 
			this.label.Dock = System.Windows.Forms.DockStyle.Top;
			this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label.Location = new System.Drawing.Point(0, 0);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(324, 46);
			this.label.TabIndex = 0;
			this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelConnectn});
			this.statusStrip1.Location = new System.Drawing.Point(0, 390);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(324, 22);
			this.statusStrip1.TabIndex = 6;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabelConnectn
			// 
			this.toolStripStatusLabelConnectn.Name = "toolStripStatusLabelConnectn";
			this.toolStripStatusLabelConnectn.Size = new System.Drawing.Size(118, 17);
			this.toolStripStatusLabelConnectn.Text = "toolStripStatusLabel1";
			// 
			// chkBusLocation
			// 
			this.chkBusLocation.AutoSize = true;
			this.chkBusLocation.Location = new System.Drawing.Point(12, 8);
			this.chkBusLocation.Name = "chkBusLocation";
			this.chkBusLocation.Size = new System.Drawing.Size(85, 17);
			this.chkBusLocation.TabIndex = 7;
			this.chkBusLocation.Text = "BusLocation";
			this.chkBusLocation.UseVisualStyleBackColor = true;
			this.chkBusLocation.CheckedChanged += new System.EventHandler(this.chkBusLocation_CheckedChanged);
			// 
			// ChkSocket
			// 
			this.ChkSocket.AutoSize = true;
			this.ChkSocket.Location = new System.Drawing.Point(12, 103);
			this.ChkSocket.Name = "ChkSocket";
			this.ChkSocket.Size = new System.Drawing.Size(60, 17);
			this.ChkSocket.TabIndex = 8;
			this.ChkSocket.Text = "Socket";
			this.ChkSocket.UseVisualStyleBackColor = true;
			this.ChkSocket.CheckedChanged += new System.EventHandler(this.ChkSocket_CheckedChanged);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.txtPeriod);
			this.panel1.Controls.Add(this.txtBackTime);
			this.panel1.Controls.Add(this.chkDistanceMeasurement);
			this.panel1.Controls.Add(this.chkKillSleepCon);
			this.panel1.Controls.Add(this.chkOffline);
			this.panel1.Controls.Add(this.TxtPort);
			this.panel1.Controls.Add(this.chkBusLocation);
			this.panel1.Controls.Add(this.ChkSocket);
			this.panel1.Controls.Add(this.chkTicket);
			this.panel1.Controls.Add(this.chkAVL);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 46);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(324, 125);
			this.panel1.TabIndex = 9;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(219, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(37, 13);
			this.label2.TabIndex = 15;
			this.label2.Text = "Period";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(107, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 13);
			this.label1.TabIndex = 14;
			this.label1.Text = "Back Time";
			// 
			// txtPeriod
			// 
			this.txtPeriod.Location = new System.Drawing.Point(262, 7);
			this.txtPeriod.Name = "txtPeriod";
			this.txtPeriod.Size = new System.Drawing.Size(47, 20);
			this.txtPeriod.TabIndex = 13;
			this.txtPeriod.Text = "5";
			// 
			// txtBackTime
			// 
			this.txtBackTime.Location = new System.Drawing.Point(167, 7);
			this.txtBackTime.Name = "txtBackTime";
			this.txtBackTime.Size = new System.Drawing.Size(47, 20);
			this.txtBackTime.TabIndex = 12;
			this.txtBackTime.Text = "30";
			// 
			// chkDistanceMeasurement
			// 
			this.chkDistanceMeasurement.AutoSize = true;
			this.chkDistanceMeasurement.Location = new System.Drawing.Point(131, 77);
			this.chkDistanceMeasurement.Name = "chkDistanceMeasurement";
			this.chkDistanceMeasurement.Size = new System.Drawing.Size(135, 17);
			this.chkDistanceMeasurement.TabIndex = 11;
			this.chkDistanceMeasurement.Text = "Distance Measurement";
			this.chkDistanceMeasurement.UseVisualStyleBackColor = true;
			this.chkDistanceMeasurement.CheckedChanged += new System.EventHandler(this.chkDistanceMeasurement_CheckedChanged);
			// 
			// chkKillSleepCon
			// 
			this.chkKillSleepCon.AutoSize = true;
			this.chkKillSleepCon.Location = new System.Drawing.Point(131, 54);
			this.chkKillSleepCon.Name = "chkKillSleepCon";
			this.chkKillSleepCon.Size = new System.Drawing.Size(120, 17);
			this.chkKillSleepCon.TabIndex = 10;
			this.chkKillSleepCon.Text = "KillSleepConnection";
			this.chkKillSleepCon.UseVisualStyleBackColor = true;
			this.chkKillSleepCon.CheckedChanged += new System.EventHandler(this.chkKillSleepCon_CheckedChanged);
			// 
			// chkOffline
			// 
			this.chkOffline.AutoSize = true;
			this.chkOffline.Location = new System.Drawing.Point(12, 77);
			this.chkOffline.Name = "chkOffline";
			this.chkOffline.Size = new System.Drawing.Size(98, 17);
			this.chkOffline.TabIndex = 10;
			this.chkOffline.Text = "OffLine+SQLite";
			this.chkOffline.UseVisualStyleBackColor = true;
			this.chkOffline.CheckedChanged += new System.EventHandler(this.chkOffline_CheckedChanged);
			// 
			// TxtPort
			// 
			this.TxtPort.Location = new System.Drawing.Point(78, 100);
			this.TxtPort.Name = "TxtPort";
			this.TxtPort.Size = new System.Drawing.Size(100, 20);
			this.TxtPort.TabIndex = 9;
			this.TxtPort.Text = "8572";
			// 
			// BspTcpServer
			// 
			this.BspTcpServer.IsListen = false;
			this.BspTcpServer.Port = ((ushort)(0));
			this.BspTcpServer.OnReceiveData += new ClassLibrary.BSPTCPServer.OnReceiveDataHandler(this.BspTcpServer_OnReceiveData);
			this.BspTcpServer.OnClientConnect += new ClassLibrary.BSPTCPServer.OnClientConnectHandler(this.BspTcpServer_OnClientConnect);
			this.BspTcpServer.OnClientDisconnect += new ClassLibrary.BSPTCPServer.OnClientDisconnectHandler(this.BspTcpServer_OnClientDisconnect);
			this.BspTcpServer.OnError += new ClassLibrary.BSPTCPServer.OnErrorHandler(this.BspTcpServer_OnError);
			// 
			// AVLServiceForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(324, 412);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label);
			this.Name = "AVLServiceForm";
			this.Text = "ServiceForm";
			//this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AVLServiceForm_FormClosed);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.CheckBox chkTicket;
        private System.Windows.Forms.CheckBox chkAVL;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.CheckBox chkBusLocation;
        private ClassLibrary.BSPTCPServer BspTcpServer;
        private System.Windows.Forms.CheckBox ChkSocket;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TxtPort;
        private System.Windows.Forms.CheckBox chkOffline;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelConnectn;
        private System.Windows.Forms.CheckBox chkKillSleepCon;
        private System.Windows.Forms.CheckBox chkDistanceMeasurement;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPeriod;
        private System.Windows.Forms.TextBox txtBackTime;
    }
}