namespace ClassLibrary
{
    partial class TimeEdit
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
            this.SuspendLayout();
            // 
            // TimeEdit
            // 
            this.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Location = new System.Drawing.Point(409, 92);
            this.Mask = "00:00";
            this.Name = "txtStartTime";
            this.Size = new System.Drawing.Size(58, 24);
            this.TabIndex = 2;
            this.Text = "  :";
            this.ValidatingType = typeof(System.DateTime);
            this.Enter += new System.EventHandler(this.TimeEdit_Enter);
            this.Leave += new System.EventHandler(this.TimeEdit_Leave);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
