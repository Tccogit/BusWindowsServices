namespace ClassLibrary
{
    partial class JCodingBox
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
            this.components = new System.ComponentModel.Container();
            this.cmbTitles = new ClassLibrary.JComboBox(this.components);
            this.txtCode = new ClassLibrary.NumEdit();
            this.SuspendLayout();
            // 
            // cmbTitles
            // 
            this.cmbTitles.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbTitles.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTitles.BaseCode = 0;
            this.cmbTitles.ChangeColorIfNotEmpty = true;
            this.cmbTitles.ChangeColorOnEnter = true;
            this.cmbTitles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbTitles.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbTitles.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbTitles.Location = new System.Drawing.Point(87, 0);
            this.cmbTitles.Name = "cmbTitles";
            this.cmbTitles.NotEmpty = true;
            this.cmbTitles.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbTitles.SelectOnEnter = true;
            this.cmbTitles.Size = new System.Drawing.Size(233, 24);
            this.cmbTitles.TabIndex = 1;
            this.cmbTitles.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.cmbTitles_ControlAdded);
            this.cmbTitles.Resize += new System.EventHandler(this.cmbTitles_Resize);
            this.cmbTitles.SelectedIndexChanged += new System.EventHandler(this.cmbTitles_SelectedIndexChanged);
            this.cmbTitles.Leave += new System.EventHandler(this.cmbTitles_Leave);
            this.cmbTitles.Enter += new System.EventHandler(this.cmbTitles_Enter);
            this.cmbTitles.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbTitles_KeyUp);
            this.cmbTitles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbTitles_KeyDown);
            this.cmbTitles.TextUpdate += new System.EventHandler(this.cmbTitles_TextUpdate);
            this.cmbTitles.Click += new System.EventHandler(this.cmbTitles_Click);
            // 
            // txtCode
            // 
            this.txtCode.ChangeColorIfNotEmpty = true;
            this.txtCode.ChangeColorOnEnter = true;
            this.txtCode.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtCode.InBackColor = System.Drawing.SystemColors.Info;
            this.txtCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCode.Location = new System.Drawing.Point(0, 0);
            this.txtCode.Name = "txtCode";
            this.txtCode.Negative = true;
            this.txtCode.NotEmpty = false;
            this.txtCode.NotEmptyColor = System.Drawing.Color.Red;
            this.txtCode.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.txtCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCode.SelectOnEnter = true;
            this.txtCode.Size = new System.Drawing.Size(87, 23);
            this.txtCode.TabIndex = 0;
            this.txtCode.TabStop = false;
            this.txtCode.TextMode = ClassLibrary.TextModes.Text;
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            this.txtCode.Leave += new System.EventHandler(this.txtCode_Leave);
            // 
            // JCodingBox
            // 
            this.Controls.Add(this.cmbTitles);
            this.Controls.Add(this.txtCode);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "JCodingBox";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(320, 29);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public ClassLibrary.NumEdit txtCode;
        public JComboBox cmbTitles;
    }
}
