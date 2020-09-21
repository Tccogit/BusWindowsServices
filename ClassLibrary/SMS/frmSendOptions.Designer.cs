namespace ClassLibrary
{
    partial class frmSendOptions
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
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxMultipart = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbDeliveryReport = new System.Windows.Forms.CheckBox();
            this.rbImmediateDisplay = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.cbxMultipart);
            this.GroupBox1.Controls.Add(this.label1);
            this.GroupBox1.Controls.Add(this.rbDeliveryReport);
            this.GroupBox1.Controls.Add(this.rbImmediateDisplay);
            this.GroupBox1.Location = new System.Drawing.Point(12, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(167, 99);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "SMS Send Options";
            // 
            // cbxMultipart
            // 
            this.cbxMultipart.FormattingEnabled = true;
            this.cbxMultipart.Items.AddRange(new object[] {
            "OK",
            "Truncate",
            "Error"});
            this.cbxMultipart.Location = new System.Drawing.Point(69, 24);
            this.cbxMultipart.Name = "cbxMultipart";
            this.cbxMultipart.Size = new System.Drawing.Size(87, 21);
            this.cbxMultipart.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Multipart:";
            // 
            // rbDeliveryReport
            // 
            this.rbDeliveryReport.AutoSize = true;
            this.rbDeliveryReport.Location = new System.Drawing.Point(16, 72);
            this.rbDeliveryReport.Name = "rbDeliveryReport";
            this.rbDeliveryReport.Size = new System.Drawing.Size(135, 17);
            this.rbDeliveryReport.TabIndex = 2;
            this.rbDeliveryReport.Text = "&Request delivery report";
            // 
            // rbImmediateDisplay
            // 
            this.rbImmediateDisplay.AutoSize = true;
            this.rbImmediateDisplay.Location = new System.Drawing.Point(16, 48);
            this.rbImmediateDisplay.Name = "rbImmediateDisplay";
            this.rbImmediateDisplay.Size = new System.Drawing.Size(143, 17);
            this.rbImmediateDisplay.TabIndex = 1;
            this.rbImmediateDisplay.Text = "&Immediate display (Flash)";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(107, 117);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 24);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 117);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(72, 24);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmSendOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(193, 149);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSendOptions";
            this.Text = "Send Options";
            this.Load += new System.EventHandler(this.frmSendOptions_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.CheckBox rbDeliveryReport;
        internal System.Windows.Forms.CheckBox rbImmediateDisplay;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cbxMultipart;
        private System.Windows.Forms.Label label1;
    }
}