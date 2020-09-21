namespace ClassLibrary
{
    partial class JComboBox
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
            // JComboBox
            // 
            this.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.SelectedIndexChanged += new System.EventHandler(this.JComboBox_SelectedIndexChanged);
            this.Leave += new System.EventHandler(this.JComboBox_Leave);
            this.Enter += new System.EventHandler(this.JComboBox_Enter);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.JComboBox_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.JComboBox_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
