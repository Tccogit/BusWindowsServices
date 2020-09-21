namespace ClassLibrary.Controllers.Editor
{
    partial class JEditorDataTable
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
            this.jEditor1 = new ClassLibrary.JEditor();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbFields = new ClassLibrary.JComboBox(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // jEditor1
            // 
            this.jEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jEditor1.Location = new System.Drawing.Point(0, 36);
            this.jEditor1.Name = "jEditor1";
            this.jEditor1.Size = new System.Drawing.Size(646, 479);
            this.jEditor1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.cmbFields);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(646, 36);
            this.panel1.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(265, 7);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbFields
            // 
            this.cmbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFields.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbFields.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFields.BaseCode = 0;
            this.cmbFields.ChangeColorIfNotEmpty = true;
            this.cmbFields.ChangeColorOnEnter = true;
            this.cmbFields.FormattingEnabled = true;
            this.cmbFields.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbFields.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbFields.Location = new System.Drawing.Point(346, 9);
            this.cmbFields.Name = "cmbFields";
            this.cmbFields.NotEmpty = false;
            this.cmbFields.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbFields.SelectOnEnter = true;
            this.cmbFields.Size = new System.Drawing.Size(297, 21);
            this.cmbFields.TabIndex = 0;
            // 
            // JEditorDataTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.jEditor1);
            this.Controls.Add(this.panel1);
            this.Name = "JEditorDataTable";
            this.Size = new System.Drawing.Size(646, 515);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ClassLibrary.JEditor jEditor1;
        private System.Windows.Forms.Panel panel1;
        private JComboBox cmbFields;
        private System.Windows.Forms.Button btnAdd;
    }
}
