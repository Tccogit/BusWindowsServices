namespace ClassLibrary
{
    partial class JSignatureMenForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JSignatureMenForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtToDate = new ClassLibrary.DateEdit(this.components);
            this.txtFromDate = new ClassLibrary.DateEdit(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPerson = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCode = new ClassLibrary.TextEdit(this.components);
            this.txtName = new ClassLibrary.TextEdit(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtShSh = new ClassLibrary.TextEdit(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtFatherName = new ClassLibrary.TextEdit(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtLastName = new ClassLibrary.TextEdit(this.components);
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.txtPost = new ClassLibrary.TextEdit(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtToDate);
            this.groupBox1.Controls.Add(this.txtFromDate);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.txtPost);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(569, 299);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtToDate
            // 
            this.txtToDate.ChangeColorIfNotEmpty = true;
            this.txtToDate.ChangeColorOnEnter = true;
            this.txtToDate.Date = new System.DateTime(((long)(0)));
            this.txtToDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtToDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtToDate.InsertInDatesTable = true;
            this.txtToDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtToDate.Location = new System.Drawing.Point(132, 242);
            this.txtToDate.Mask = "0000/00/00";
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.NotEmpty = false;
            this.txtToDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtToDate.Size = new System.Drawing.Size(100, 23);
            this.txtToDate.TabIndex = 7;
            // 
            // txtFromDate
            // 
            this.txtFromDate.ChangeColorIfNotEmpty = true;
            this.txtFromDate.ChangeColorOnEnter = true;
            this.txtFromDate.Date = new System.DateTime(((long)(0)));
            this.txtFromDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtFromDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFromDate.InsertInDatesTable = true;
            this.txtFromDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtFromDate.Location = new System.Drawing.Point(363, 242);
            this.txtFromDate.Mask = "0000/00/00";
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.NotEmpty = false;
            this.txtFromDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtFromDate.Size = new System.Drawing.Size(100, 23);
            this.txtFromDate.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPerson);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtCode);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtShSh);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtFatherName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtLastName);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(563, 139);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "مشخصات شخص";
            // 
            // btnPerson
            // 
            this.btnPerson.Location = new System.Drawing.Point(314, 31);
            this.btnPerson.Name = "btnPerson";
            this.btnPerson.Size = new System.Drawing.Size(32, 23);
            this.btnPerson.TabIndex = 1;
            this.btnPerson.TabStop = false;
            this.btnPerson.Text = "...";
            this.btnPerson.UseVisualStyleBackColor = true;
            this.btnPerson.Click += new System.EventHandler(this.btnPerson_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(477, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "کد شخص:";
            // 
            // txtCode
            // 
            this.txtCode.ChangeColorIfNotEmpty = false;
            this.txtCode.ChangeColorOnEnter = true;
            this.txtCode.InBackColor = System.Drawing.SystemColors.Info;
            this.txtCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCode.Location = new System.Drawing.Point(352, 31);
            this.txtCode.Name = "txtCode";
            this.txtCode.Negative = true;
            this.txtCode.NotEmpty = true;
            this.txtCode.NotEmptyColor = System.Drawing.Color.Red;
            this.txtCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCode.SelectOnEnter = true;
            this.txtCode.Size = new System.Drawing.Size(108, 23);
            this.txtCode.TabIndex = 1;
            this.txtCode.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // txtName
            // 
            this.txtName.ChangeColorIfNotEmpty = true;
            this.txtName.ChangeColorOnEnter = true;
            this.txtName.InBackColor = System.Drawing.SystemColors.Info;
            this.txtName.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtName.Location = new System.Drawing.Point(34, 67);
            this.txtName.Name = "txtName";
            this.txtName.Negative = true;
            this.txtName.NotEmpty = false;
            this.txtName.NotEmptyColor = System.Drawing.Color.Red;
            this.txtName.ReadOnly = true;
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtName.SelectOnEnter = true;
            this.txtName.Size = new System.Drawing.Size(135, 23);
            this.txtName.TabIndex = 3;
            this.txtName.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "نام:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(460, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "نام خانوادگی:";
            // 
            // txtShSh
            // 
            this.txtShSh.ChangeColorIfNotEmpty = true;
            this.txtShSh.ChangeColorOnEnter = true;
            this.txtShSh.InBackColor = System.Drawing.SystemColors.Info;
            this.txtShSh.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtShSh.Location = new System.Drawing.Point(34, 102);
            this.txtShSh.Name = "txtShSh";
            this.txtShSh.Negative = true;
            this.txtShSh.NotEmpty = false;
            this.txtShSh.NotEmptyColor = System.Drawing.Color.Red;
            this.txtShSh.ReadOnly = true;
            this.txtShSh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtShSh.SelectOnEnter = true;
            this.txtShSh.Size = new System.Drawing.Size(135, 23);
            this.txtShSh.TabIndex = 5;
            this.txtShSh.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(495, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "نام پدر:";
            // 
            // txtFatherName
            // 
            this.txtFatherName.ChangeColorIfNotEmpty = true;
            this.txtFatherName.ChangeColorOnEnter = true;
            this.txtFatherName.InBackColor = System.Drawing.SystemColors.Info;
            this.txtFatherName.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFatherName.Location = new System.Drawing.Point(314, 97);
            this.txtFatherName.Name = "txtFatherName";
            this.txtFatherName.Negative = true;
            this.txtFatherName.NotEmpty = false;
            this.txtFatherName.NotEmptyColor = System.Drawing.Color.Red;
            this.txtFatherName.ReadOnly = true;
            this.txtFatherName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFatherName.SelectOnEnter = true;
            this.txtFatherName.Size = new System.Drawing.Size(146, 23);
            this.txtFatherName.TabIndex = 4;
            this.txtFatherName.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(175, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "شماره شناسنامه:";
            // 
            // txtLastName
            // 
            this.txtLastName.ChangeColorIfNotEmpty = true;
            this.txtLastName.ChangeColorOnEnter = true;
            this.txtLastName.InBackColor = System.Drawing.SystemColors.Info;
            this.txtLastName.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLastName.Location = new System.Drawing.Point(314, 63);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Negative = true;
            this.txtLastName.NotEmpty = false;
            this.txtLastName.NotEmptyColor = System.Drawing.Color.Red;
            this.txtLastName.ReadOnly = true;
            this.txtLastName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLastName.SelectOnEnter = true;
            this.txtLastName.Size = new System.Drawing.Size(146, 23);
            this.txtLastName.TabIndex = 2;
            this.txtLastName.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtDesc
            // 
            this.txtDesc.ChangeColorIfNotEmpty = true;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(37, 206);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(426, 23);
            this.txtDesc.TabIndex = 3;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtPost
            // 
            this.txtPost.ChangeColorIfNotEmpty = true;
            this.txtPost.ChangeColorOnEnter = true;
            this.txtPost.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPost.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPost.Location = new System.Drawing.Point(317, 172);
            this.txtPost.Name = "txtPost";
            this.txtPost.Negative = true;
            this.txtPost.NotEmpty = false;
            this.txtPost.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPost.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPost.SelectOnEnter = true;
            this.txtPost.Size = new System.Drawing.Size(146, 23);
            this.txtPost.TabIndex = 1;
            this.txtPost.TextMode = ClassLibrary.TextModes.Text;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(122, 175);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(50, 20);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "فعال";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(238, 245);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 16);
            this.label9.TabIndex = 5;
            this.label9.Text = "تا تاریخ:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(469, 245);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 16);
            this.label8.TabIndex = 5;
            this.label8.Text = "از تاریخ:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(469, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "حدود و اختیارات:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(469, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "سمت:";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(106, 310);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 33);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(434, 305);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 33);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // JSignatureMenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 355);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Name = "JSignatureMenForm";
            this.Text = "SignatureMen";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private TextEdit txtDesc;
        private TextEdit txtPost;
        private TextEdit txtShSh;
        private TextEdit txtFatherName;
        private TextEdit txtName;
        private TextEdit txtLastName;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private TextEdit txtCode;
        private System.Windows.Forms.Button btnPerson;
        private DateEdit txtToDate;
        private DateEdit txtFromDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}