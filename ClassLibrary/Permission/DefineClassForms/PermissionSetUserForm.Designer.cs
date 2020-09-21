namespace ClassLibrary
{
    partial class JPermissionSetUserForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JPermissionSetUserForm));
            this.Insertbutton = new System.Windows.Forms.Button();
            this.Deletebutton = new System.Windows.Forms.Button();
            this.Okbutton = new System.Windows.Forms.Button();
            this.ObjectlistBox = new System.Windows.Forms.ListBox();
            this.DecissionlistBox = new System.Windows.Forms.ListBox();
            this.PermissionUserlistBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.comboBoxPost = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.DefineClassListBox = new System.Windows.Forms.ListBox();
            this.cmbGroup = new ClassLibrary.JComboBox(this.components);
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.checkBoxAll = new System.Windows.Forms.CheckBox();
            this.checkBoxNone = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.txtFindObj = new ClassLibrary.TextEdit(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.Images.SetKeyName(0, "aktion.png");
            this.imageList.Images.SetKeyName(1, "alert.png");
            this.imageList.Images.SetKeyName(2, "All software is current.png");
            this.imageList.Images.SetKeyName(3, "amor.png");
            this.imageList.Images.SetKeyName(4, "antivirus.png");
            this.imageList.Images.SetKeyName(5, "applixware.png");
            this.imageList.Images.SetKeyName(6, "ark.png");
            this.imageList.Images.SetKeyName(7, "arts.png");
            // 
            // Insertbutton
            // 
            this.Insertbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Insertbutton.Location = new System.Drawing.Point(85, 20);
            this.Insertbutton.Name = "Insertbutton";
            this.Insertbutton.Size = new System.Drawing.Size(75, 23);
            this.Insertbutton.TabIndex = 2;
            this.Insertbutton.Text = "Insert";
            this.Insertbutton.UseVisualStyleBackColor = true;
            this.Insertbutton.Click += new System.EventHandler(this.Insertbutton_Click);
            // 
            // Deletebutton
            // 
            this.Deletebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Deletebutton.Location = new System.Drawing.Point(535, 20);
            this.Deletebutton.Name = "Deletebutton";
            this.Deletebutton.Size = new System.Drawing.Size(75, 23);
            this.Deletebutton.TabIndex = 2;
            this.Deletebutton.Text = "Delete";
            this.Deletebutton.UseVisualStyleBackColor = true;
            this.Deletebutton.Click += new System.EventHandler(this.Deletebutton_Click);
            // 
            // Okbutton
            // 
            this.Okbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Okbutton.Location = new System.Drawing.Point(454, 20);
            this.Okbutton.Name = "Okbutton";
            this.Okbutton.Size = new System.Drawing.Size(75, 23);
            this.Okbutton.TabIndex = 2;
            this.Okbutton.Text = "OK";
            this.Okbutton.UseVisualStyleBackColor = true;
            this.Okbutton.Click += new System.EventHandler(this.Okbutton_Click);
            // 
            // ObjectlistBox
            // 
            this.ObjectlistBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ObjectlistBox.FormattingEnabled = true;
            this.ObjectlistBox.ItemHeight = 16;
            this.ObjectlistBox.Location = new System.Drawing.Point(3, 48);
            this.ObjectlistBox.Name = "ObjectlistBox";
            this.ObjectlistBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ObjectlistBox.Size = new System.Drawing.Size(282, 276);
            this.ObjectlistBox.TabIndex = 4;
            this.ObjectlistBox.SelectedIndexChanged += new System.EventHandler(this.ObjectlistBox_SelectedIndexChanged);
            // 
            // DecissionlistBox
            // 
            this.DecissionlistBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DecissionlistBox.FormattingEnabled = true;
            this.DecissionlistBox.ItemHeight = 16;
            this.DecissionlistBox.Location = new System.Drawing.Point(3, 19);
            this.DecissionlistBox.MultiColumn = true;
            this.DecissionlistBox.Name = "DecissionlistBox";
            this.DecissionlistBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.DecissionlistBox.Size = new System.Drawing.Size(235, 340);
            this.DecissionlistBox.TabIndex = 4;
            this.DecissionlistBox.SelectedIndexChanged += new System.EventHandler(this.DecissionlistBox_SelectedIndexChanged);
            // 
            // PermissionUserlistBox
            // 
            this.PermissionUserlistBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PermissionUserlistBox.FormattingEnabled = true;
            this.PermissionUserlistBox.ItemHeight = 16;
            this.PermissionUserlistBox.Location = new System.Drawing.Point(3, 19);
            this.PermissionUserlistBox.Name = "PermissionUserlistBox";
            this.PermissionUserlistBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.PermissionUserlistBox.Size = new System.Drawing.Size(904, 132);
            this.PermissionUserlistBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(821, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "UserName:";
            // 
            // lbUserName
            // 
            this.lbUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUserName.AutoSize = true;
            this.lbUserName.Location = new System.Drawing.Point(687, 19);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(65, 16);
            this.lbUserName.TabIndex = 5;
            this.lbUserName.Text = "username";
            // 
            // comboBoxPost
            // 
            this.comboBoxPost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPost.FormattingEnabled = true;
            this.comboBoxPost.Location = new System.Drawing.Point(384, 16);
            this.comboBoxPost.Name = "comboBoxPost";
            this.comboBoxPost.Size = new System.Drawing.Size(297, 24);
            this.comboBoxPost.TabIndex = 7;
            this.comboBoxPost.SelectedIndexChanged += new System.EventHandler(this.comboBoxPost_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxPost);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbUserName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(910, 50);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Deletebutton);
            this.groupBox3.Controls.Add(this.Okbutton);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 648);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(910, 49);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.PermissionUserlistBox);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(0, 485);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(910, 163);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "User:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox7);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(910, 435);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.DefineClassListBox);
            this.groupBox7.Controls.Add(this.cmbGroup);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(532, 19);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(375, 413);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Define Class List:";
            // 
            // DefineClassListBox
            // 
            this.DefineClassListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DefineClassListBox.FormattingEnabled = true;
            this.DefineClassListBox.ItemHeight = 16;
            this.DefineClassListBox.Location = new System.Drawing.Point(3, 43);
            this.DefineClassListBox.Name = "DefineClassListBox";
            this.DefineClassListBox.Size = new System.Drawing.Size(369, 356);
            this.DefineClassListBox.TabIndex = 11;
            this.DefineClassListBox.SelectedIndexChanged += new System.EventHandler(this.DefineClasslistBox_SelectedIndexChanged);
            // 
            // cmbGroup
            // 
            this.cmbGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGroup.BaseCode = 0;
            this.cmbGroup.ChangeColorIfNotEmpty = true;
            this.cmbGroup.ChangeColorOnEnter = true;
            this.cmbGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbGroup.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbGroup.Location = new System.Drawing.Point(3, 19);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.NotEmpty = false;
            this.cmbGroup.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbGroup.SelectOnEnter = true;
            this.cmbGroup.Size = new System.Drawing.Size(369, 24);
            this.cmbGroup.TabIndex = 10;
            this.cmbGroup.SelectedIndexChanged += new System.EventHandler(this.cmbGroup_SelectedIndexChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtFindObj);
            this.groupBox6.Controls.Add(this.groupBox8);
            this.groupBox6.Controls.Add(this.ObjectlistBox);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox6.Location = new System.Drawing.Point(244, 19);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(288, 413);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Object List:";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.checkBoxAll);
            this.groupBox8.Controls.Add(this.checkBoxNone);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox8.Location = new System.Drawing.Point(3, 320);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(282, 90);
            this.groupBox8.TabIndex = 9;
            this.groupBox8.TabStop = false;
            // 
            // checkBoxAll
            // 
            this.checkBoxAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxAll.AutoSize = true;
            this.checkBoxAll.Location = new System.Drawing.Point(183, 22);
            this.checkBoxAll.Name = "checkBoxAll";
            this.checkBoxAll.Size = new System.Drawing.Size(93, 20);
            this.checkBoxAll.TabIndex = 8;
            this.checkBoxAll.Text = "checkBoxAll";
            this.checkBoxAll.UseVisualStyleBackColor = true;
            this.checkBoxAll.CheckedChanged += new System.EventHandler(this.checkBoxAll_CheckedChanged);
            // 
            // checkBoxNone
            // 
            this.checkBoxNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxNone.AutoSize = true;
            this.checkBoxNone.Location = new System.Drawing.Point(168, 61);
            this.checkBoxNone.Name = "checkBoxNone";
            this.checkBoxNone.Size = new System.Drawing.Size(108, 20);
            this.checkBoxNone.TabIndex = 7;
            this.checkBoxNone.Text = "checkBoxNone";
            this.checkBoxNone.UseVisualStyleBackColor = true;
            this.checkBoxNone.CheckedChanged += new System.EventHandler(this.checkBoxNone_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox9);
            this.groupBox5.Controls.Add(this.DecissionlistBox);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox5.Location = new System.Drawing.Point(3, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(241, 413);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "DecissionList:";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.Insertbutton);
            this.groupBox9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox9.Location = new System.Drawing.Point(3, 361);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(235, 49);
            this.groupBox9.TabIndex = 5;
            this.groupBox9.TabStop = false;
            // 
            // txtFindObj
            // 
            this.txtFindObj.ChangeColorIfNotEmpty = false;
            this.txtFindObj.ChangeColorOnEnter = true;
            this.txtFindObj.InBackColor = System.Drawing.SystemColors.Info;
            this.txtFindObj.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFindObj.Location = new System.Drawing.Point(2, 19);
            this.txtFindObj.Name = "txtFindObj";
            this.txtFindObj.Negative = true;
            this.txtFindObj.NotEmpty = false;
            this.txtFindObj.NotEmptyColor = System.Drawing.Color.Red;
            this.txtFindObj.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFindObj.SelectOnEnter = true;
            this.txtFindObj.Size = new System.Drawing.Size(282, 23);
            this.txtFindObj.TabIndex = 10;
            this.txtFindObj.TextMode = ClassLibrary.TextModes.Text;
            this.txtFindObj.TextChanged += new System.EventHandler(this.txtFindObj_TextChanged);
            // 
            // JPermissionSetUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 697);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "JPermissionSetUserForm";
            this.Text = "PermissionSetUserForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.JPermissionSetUserForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Insertbutton;
        private System.Windows.Forms.Button Deletebutton;
        private System.Windows.Forms.Button Okbutton;
        private System.Windows.Forms.ListBox ObjectlistBox;
        private System.Windows.Forms.ListBox DecissionlistBox;
        private System.Windows.Forms.ListBox PermissionUserlistBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.ComboBox comboBoxPost;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox checkBoxAll;
        private System.Windows.Forms.CheckBox checkBoxNone;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.ListBox DefineClassListBox;
        private JComboBox cmbGroup;
        private TextEdit txtFindObj;
    }
}