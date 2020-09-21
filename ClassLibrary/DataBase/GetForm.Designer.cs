namespace ClassLibrary.DataBase
{
    partial class GetLoginTypeForm
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
            this.RemLocal = new System.Windows.Forms.RadioButton();
            this.RBLocal = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RemLocal
            // 
            this.RemLocal.AutoSize = true;
            this.RemLocal.Location = new System.Drawing.Point(41, 53);
            this.RemLocal.Name = "RemLocal";
            this.RemLocal.Size = new System.Drawing.Size(160, 17);
            this.RemLocal.TabIndex = 15;
            this.RemLocal.Text = "ارتباط از خارج از شبکه داخلی";
            this.RemLocal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RemLocal.UseVisualStyleBackColor = true;
            this.RemLocal.CheckedChanged += new System.EventHandler(this.RemLocal_CheckedChanged);
            // 
            // RBLocal
            // 
            this.RBLocal.AutoSize = true;
            this.RBLocal.Checked = true;
            this.RBLocal.Location = new System.Drawing.Point(41, 30);
            this.RBLocal.Name = "RBLocal";
            this.RBLocal.Size = new System.Drawing.Size(122, 17);
            this.RBLocal.TabIndex = 14;
            this.RBLocal.TabStop = true;
            this.RBLocal.Text = "ارتباط از شبکه داخلی";
            this.RBLocal.UseVisualStyleBackColor = true;
            this.RBLocal.CheckedChanged += new System.EventHandler(this.RBLocal_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "تایید";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GetLoginTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 129);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.RemLocal);
            this.Controls.Add(this.RBLocal);
            this.Name = "GetLoginTypeForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "نوع ارتباط شبکه با سرور";
            this.Load += new System.EventHandler(this.GetLoginTypeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton RemLocal;
        private System.Windows.Forms.RadioButton RBLocal;
        private System.Windows.Forms.Button button1;
    }
}