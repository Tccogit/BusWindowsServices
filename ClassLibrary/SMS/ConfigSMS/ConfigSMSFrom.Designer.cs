namespace ClassLibrary
{
    partial class JConfigSMSFrom
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
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtServerName = new ClassLibrary.TextEdit(this.components);
            this.cbxBodyType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPincode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbxDevices = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.cbxDeviceSpeed = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.label3);
            this.GroupBox1.Controls.Add(this.txtServerName);
            this.GroupBox1.Controls.Add(this.cbxBodyType);
            this.GroupBox1.Controls.Add(this.label11);
            this.GroupBox1.Controls.Add(this.txtPincode);
            this.GroupBox1.Controls.Add(this.label1);
            this.GroupBox1.Controls.Add(this.label9);
            this.GroupBox1.Controls.Add(this.cbxDevices);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.cbxDeviceSpeed);
            this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox1.Location = new System.Drawing.Point(0, 0);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(420, 272);
            this.GroupBox1.TabIndex = 4;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "GSM Modem/Phone Connection Properties";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(323, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Server Name :";
            // 
            // txtServerName
            // 
            this.txtServerName.ChangeColorIfNotEmpty = false;
            this.txtServerName.ChangeColorOnEnter = true;
            this.txtServerName.InBackColor = System.Drawing.SystemColors.Info;
            this.txtServerName.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtServerName.Location = new System.Drawing.Point(102, 32);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Negative = true;
            this.txtServerName.NotEmpty = false;
            this.txtServerName.NotEmptyColor = System.Drawing.Color.Red;
            this.txtServerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtServerName.SelectOnEnter = true;
            this.txtServerName.Size = new System.Drawing.Size(215, 23);
            this.txtServerName.TabIndex = 14;
            this.txtServerName.TextMode = ClassLibrary.TextModes.Text;
            // 
            // cbxBodyType
            // 
            this.cbxBodyType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxBodyType.FormattingEnabled = true;
            this.cbxBodyType.Items.AddRange(new object[] {
            "Text",
            "Unicode",
            "Data",
            "Data (UDH)"});
            this.cbxBodyType.Location = new System.Drawing.Point(102, 150);
            this.cbxBodyType.Name = "cbxBodyType";
            this.cbxBodyType.Size = new System.Drawing.Size(215, 24);
            this.cbxBodyType.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(321, 154);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 16);
            this.label11.TabIndex = 12;
            this.label11.Text = "Bodyformat:";
            // 
            // txtPincode
            // 
            this.txtPincode.Location = new System.Drawing.Point(102, 61);
            this.txtPincode.Name = "txtPincode";
            this.txtPincode.PasswordChar = '*';
            this.txtPincode.Size = new System.Drawing.Size(215, 23);
            this.txtPincode.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(323, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Device:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(323, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 16);
            this.label9.TabIndex = 4;
            this.label9.Text = "Pin&code:";
            // 
            // cbxDevices
            // 
            this.cbxDevices.Location = new System.Drawing.Point(102, 120);
            this.cbxDevices.Name = "cbxDevices";
            this.cbxDevices.Size = new System.Drawing.Size(215, 24);
            this.cbxDevices.TabIndex = 1;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(323, 94);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(49, 16);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "&Speed:";
            // 
            // cbxDeviceSpeed
            // 
            this.cbxDeviceSpeed.Items.AddRange(new object[] {
            "110",
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "56000",
            "57600",
            "64000",
            "115200",
            "128000",
            "230400",
            "256000",
            "460800",
            "921600"});
            this.cbxDeviceSpeed.Location = new System.Drawing.Point(102, 90);
            this.cbxDeviceSpeed.Name = "cbxDeviceSpeed";
            this.cbxDeviceSpeed.Size = new System.Drawing.Size(215, 24);
            this.cbxDeviceSpeed.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 217);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(420, 55);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(41, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(138, 29);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(220, 20);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(138, 29);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // JConfigSMSFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 272);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JConfigSMSFrom";
            this.Text = "ConfigSMS";
            this.Load += new System.EventHandler(this.JConfigSMS_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TextBox txtPincode;
        internal System.Windows.Forms.ComboBox cbxDeviceSpeed;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox cbxDevices;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbxBodyType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private TextEdit txtServerName;
    }
}