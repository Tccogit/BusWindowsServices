namespace ClassLibrary.SMS
{
    partial class QuickSMSForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickSMSForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRefer = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.jQuickSMS1 = new ClassLibrary.Controllers.SMS.JQuickSMS();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.btnRefer);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 382);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel2.Size = new System.Drawing.Size(763, 58);
            this.panel2.TabIndex = 45;
            // 
            // btnRefer
            // 
            this.btnRefer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefer.BackColor = System.Drawing.SystemColors.Control;
            this.btnRefer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefer.Image = ((System.Drawing.Image)(resources.GetObject("btnRefer.Image")));
            this.btnRefer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefer.Location = new System.Drawing.Point(611, 12);
            this.btnRefer.Name = "btnRefer";
            this.btnRefer.Size = new System.Drawing.Size(140, 39);
            this.btnRefer.TabIndex = 13;
            this.btnRefer.Text = "ارسال SMS";
            this.btnRefer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefer.UseVisualStyleBackColor = false;
            this.btnRefer.Click += new System.EventHandler(this.btnRefer_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.Control;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(6, 11);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(140, 40);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "بازگشت";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // jQuickSMS1
            // 
            this.jQuickSMS1._Receivers = new string[] {
        "",
        "",
        ""};
            this.jQuickSMS1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jQuickSMS1.Location = new System.Drawing.Point(0, 0);
            this.jQuickSMS1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.jQuickSMS1.Name = "jQuickSMS1";
            this.jQuickSMS1.Size = new System.Drawing.Size(763, 382);
            this.jQuickSMS1.TabIndex = 46;
            // 
            // QuickSMSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 440);
            this.Controls.Add(this.jQuickSMS1);
            this.Controls.Add(this.panel2);
            this.Name = "QuickSMSForm";
            this.Text = "QuickSMSForm";
            this.Load += new System.EventHandler(this.QuickSMSForm_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRefer;
        private System.Windows.Forms.Button btnExit;
        private Controllers.SMS.JQuickSMS jQuickSMS1;
    }
}