namespace ClassLibrary
{
    partial class frmDataWap
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtLinkTitle = new System.Windows.Forms.TextBox();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(272, 66);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 24);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(181, 66);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(72, 24);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(12, 44);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(52, 16);
            this.Label3.TabIndex = 29;
            this.Label3.Text = "&Link title:";
            // 
            // txtLinkTitle
            // 
            this.txtLinkTitle.Location = new System.Drawing.Point(68, 40);
            this.txtLinkTitle.Name = "txtLinkTitle";
            this.txtLinkTitle.Size = new System.Drawing.Size(276, 20);
            this.txtLinkTitle.TabIndex = 1;
            this.txtLinkTitle.Text = "ActiveXperts WAP Demo";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(68, 12);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(276, 20);
            this.txtURL.TabIndex = 0;
            this.txtURL.Text = "http://www.activexperts.com";
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(12, 16);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(32, 16);
            this.Label2.TabIndex = 26;
            this.Label2.Text = "&URL:";
            // 
            // frmDataWap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 96);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtLinkTitle);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.Label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDataWap";
            this.Text = "Encode WAP Push message";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtLinkTitle;
        internal System.Windows.Forms.TextBox txtURL;
        internal System.Windows.Forms.Label Label2;
    }
}