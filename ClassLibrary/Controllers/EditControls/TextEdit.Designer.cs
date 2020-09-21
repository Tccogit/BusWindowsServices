namespace ClassLibrary
{
    partial class TextEdit
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
            // TextEdit
            // 
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TextChanged += new System.EventHandler(this.TextEdit_TextChanged);
            this.Leave += new System.EventHandler(this.textBox1_Leave);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextEdit_KeyPress);
            this.Enter += new System.EventHandler(this.textBox1_Enter);
            this.ResumeLayout(false);

        }

        #endregion

    }
}
