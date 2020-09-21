namespace ClassLibrary.Controllers.Editor
{
    partial class JEditorWord
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.winWordControl1 = new OfficeWord.WinWordControl();
            this.SuspendLayout();
            // 
            // winWordControl1
            // 
            this.winWordControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.winWordControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.winWordControl1.FileCode = 0;
            this.winWordControl1.Location = new System.Drawing.Point(0, 0);
            this.winWordControl1.Name = "winWordControl1";
            this.winWordControl1.ReadOnly = false;
            this.winWordControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.winWordControl1.Size = new System.Drawing.Size(150, 150);
            this.winWordControl1.TabIndex = 0;
            // 
            // JEditorWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.winWordControl1);
            this.Name = "JEditorWord";
            this.ResumeLayout(false);

        }

        #endregion

        private OfficeWord.WinWordControl winWordControl1;
    }
}
