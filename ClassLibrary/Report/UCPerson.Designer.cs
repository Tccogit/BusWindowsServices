namespace ClassLibrary
{
    partial class JUCPerson
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtExportCode = new ClassLibrary.TextEdit(this.components);
            this.Code = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.labDeadName = new ClassLibrary.TextEdit(this.components);
            this.labDeadshsh = new ClassLibrary.TextEdit(this.components);
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labDeadshsh);
            this.groupBox3.Controls.Add(this.labDeadName);
            this.groupBox3.Controls.Add(this.txtExportCode);
            this.groupBox3.Controls.Add(this.Code);
            this.groupBox3.Controls.Add(this.btnSearch);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(299, 93);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            // 
            // txtExportCode
            // 
            this.txtExportCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExportCode.ChangeColorIfNotEmpty = false;
            this.txtExportCode.ChangeColorOnEnter = true;
            this.txtExportCode.InBackColor = System.Drawing.SystemColors.Info;
            this.txtExportCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtExportCode.Location = new System.Drawing.Point(118, 13);
            this.txtExportCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtExportCode.Name = "txtExportCode";
            this.txtExportCode.Negative = true;
            this.txtExportCode.NotEmpty = false;
            this.txtExportCode.NotEmptyColor = System.Drawing.Color.Red;
            this.txtExportCode.ReadOnly = true;
            this.txtExportCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtExportCode.SelectOnEnter = true;
            this.txtExportCode.Size = new System.Drawing.Size(126, 20);
            this.txtExportCode.TabIndex = 37;
            this.txtExportCode.Tag = "=";
            this.txtExportCode.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // Code
            // 
            this.Code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Code.AutoSize = true;
            this.Code.Location = new System.Drawing.Point(258, 18);
            this.Code.Name = "Code";
            this.Code.Size = new System.Drawing.Size(35, 13);
            this.Code.TabIndex = 27;
            this.Code.Text = "Code:";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(80, 11);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(34, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "...";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // labDeadName
            // 
            this.labDeadName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labDeadName.ChangeColorIfNotEmpty = false;
            this.labDeadName.ChangeColorOnEnter = true;
            this.labDeadName.InBackColor = System.Drawing.SystemColors.Info;
            this.labDeadName.InForeColor = System.Drawing.SystemColors.WindowText;
            this.labDeadName.Location = new System.Drawing.Point(6, 41);
            this.labDeadName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labDeadName.Name = "labDeadName";
            this.labDeadName.Negative = true;
            this.labDeadName.NotEmpty = false;
            this.labDeadName.NotEmptyColor = System.Drawing.Color.Red;
            this.labDeadName.ReadOnly = true;
            this.labDeadName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labDeadName.SelectOnEnter = true;
            this.labDeadName.Size = new System.Drawing.Size(284, 20);
            this.labDeadName.TabIndex = 38;
            this.labDeadName.Tag = "=";
            this.labDeadName.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // labDeadshsh
            // 
            this.labDeadshsh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labDeadshsh.ChangeColorIfNotEmpty = false;
            this.labDeadshsh.ChangeColorOnEnter = true;
            this.labDeadshsh.InBackColor = System.Drawing.SystemColors.Info;
            this.labDeadshsh.InForeColor = System.Drawing.SystemColors.WindowText;
            this.labDeadshsh.Location = new System.Drawing.Point(6, 64);
            this.labDeadshsh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labDeadshsh.Name = "labDeadshsh";
            this.labDeadshsh.Negative = true;
            this.labDeadshsh.NotEmpty = false;
            this.labDeadshsh.NotEmptyColor = System.Drawing.Color.Red;
            this.labDeadshsh.ReadOnly = true;
            this.labDeadshsh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labDeadshsh.SelectOnEnter = true;
            this.labDeadshsh.Size = new System.Drawing.Size(284, 20);
            this.labDeadshsh.TabIndex = 39;
            this.labDeadshsh.Tag = "=";
            this.labDeadshsh.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // JUCPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Name = "JUCPerson";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(299, 93);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private TextEdit txtExportCode;
        private System.Windows.Forms.Label Code;
        private System.Windows.Forms.Button btnSearch;
        private TextEdit labDeadshsh;
        private TextEdit labDeadName;

    }
}
