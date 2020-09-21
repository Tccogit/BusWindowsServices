namespace BusManagment.Driver
{
    partial class DriverForm
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupCertificate = new System.Windows.Forms.GroupBox();
            this.cmbCertType = new ClassLibrary.JComboBox(this.components);
            this.txtCertExpDate = new ClassLibrary.DateEdit(this.components);
            this.txtCertDate = new ClassLibrary.DateEdit(this.components);
            this.txtCertNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelectPerson = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.jJanusGridOwner = new ClassLibrary.JJanusGrid();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSearchOwner = new System.Windows.Forms.Button();
            this.txtOwner = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnDeActiveOw = new System.Windows.Forms.Button();
            this.btnActiveOw = new System.Windows.Forms.Button();
            this.OwEndDate = new ClassLibrary.DateEdit(this.components);
            this.OwStartDate = new ClassLibrary.DateEdit(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.jJanusGrid1 = new ClassLibrary.JJanusGrid();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupCertificate.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(638, 4);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(110, 32);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnApply
            // 
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Location = new System.Drawing.Point(522, 4);
            this.btnApply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(110, 32);
            this.btnApply.TabIndex = 8;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(7, 4);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 32);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(755, 420);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupCertificate);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(747, 391);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Base";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // groupCertificate
            // 
            this.groupCertificate.Controls.Add(this.cmbCertType);
            this.groupCertificate.Controls.Add(this.txtCertExpDate);
            this.groupCertificate.Controls.Add(this.txtCertDate);
            this.groupCertificate.Controls.Add(this.txtCertNumber);
            this.groupCertificate.Controls.Add(this.label6);
            this.groupCertificate.Controls.Add(this.label5);
            this.groupCertificate.Controls.Add(this.label4);
            this.groupCertificate.Controls.Add(this.label2);
            this.groupCertificate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupCertificate.Location = new System.Drawing.Point(3, 64);
            this.groupCertificate.Name = "groupCertificate";
            this.groupCertificate.Size = new System.Drawing.Size(741, 324);
            this.groupCertificate.TabIndex = 14;
            this.groupCertificate.TabStop = false;
            this.groupCertificate.Text = "CERTIFICATE ";
            this.groupCertificate.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cmbCertType
            // 
            this.cmbCertType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCertType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbCertType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCertType.BaseCode = 0;
            this.cmbCertType.ChangeColorIfNotEmpty = true;
            this.cmbCertType.ChangeColorOnEnter = true;
            this.cmbCertType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCertType.FormattingEnabled = true;
            this.cmbCertType.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbCertType.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbCertType.Location = new System.Drawing.Point(413, 125);
            this.cmbCertType.Name = "cmbCertType";
            this.cmbCertType.NotEmpty = false;
            this.cmbCertType.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbCertType.SelectOnEnter = true;
            this.cmbCertType.Size = new System.Drawing.Size(129, 24);
            this.cmbCertType.TabIndex = 3;
            // 
            // txtCertExpDate
            // 
            this.txtCertExpDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCertExpDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCertExpDate.ChangeColorIfNotEmpty = true;
            this.txtCertExpDate.ChangeColorOnEnter = true;
            this.txtCertExpDate.Date = new System.DateTime(((long)(0)));
            this.txtCertExpDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtCertExpDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCertExpDate.InsertInDatesTable = true;
            this.txtCertExpDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtCertExpDate.Location = new System.Drawing.Point(442, 96);
            this.txtCertExpDate.Mask = "0000/00/00";
            this.txtCertExpDate.Name = "txtCertExpDate";
            this.txtCertExpDate.NotEmpty = false;
            this.txtCertExpDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtCertExpDate.Size = new System.Drawing.Size(100, 23);
            this.txtCertExpDate.TabIndex = 2;
            // 
            // txtCertDate
            // 
            this.txtCertDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCertDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCertDate.ChangeColorIfNotEmpty = true;
            this.txtCertDate.ChangeColorOnEnter = true;
            this.txtCertDate.Date = new System.DateTime(((long)(0)));
            this.txtCertDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtCertDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCertDate.InsertInDatesTable = true;
            this.txtCertDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtCertDate.Location = new System.Drawing.Point(442, 66);
            this.txtCertDate.Mask = "0000/00/00";
            this.txtCertDate.Name = "txtCertDate";
            this.txtCertDate.NotEmpty = false;
            this.txtCertDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtCertDate.Size = new System.Drawing.Size(100, 23);
            this.txtCertDate.TabIndex = 1;
            // 
            // txtCertNumber
            // 
            this.txtCertNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCertNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCertNumber.Location = new System.Drawing.Point(201, 36);
            this.txtCertNumber.Name = "txtCertNumber";
            this.txtCertNumber.Size = new System.Drawing.Size(341, 23);
            this.txtCertNumber.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(621, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Certificate Type:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(584, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Certificate Expier Date:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(623, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Certificate Date:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(604, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Certificate Number:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSelectPerson);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(741, 61);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // btnSelectPerson
            // 
            this.btnSelectPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectPerson.Location = new System.Drawing.Point(201, 25);
            this.btnSelectPerson.Name = "btnSelectPerson";
            this.btnSelectPerson.Size = new System.Drawing.Size(75, 23);
            this.btnSelectPerson.TabIndex = 16;
            this.btnSelectPerson.Text = "...";
            this.btnSelectPerson.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(282, 25);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(342, 23);
            this.txtName.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(678, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Name:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.jJanusGridOwner);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(747, 391);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Contract";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // jJanusGridOwner
            // 
            this.jJanusGridOwner.ActionClassName = "";
            this.jJanusGridOwner.ActionMenu = null;
            this.jJanusGridOwner.DataSource = null;
            this.jJanusGridOwner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jJanusGridOwner.Edited = false;
            this.jJanusGridOwner.Location = new System.Drawing.Point(3, 66);
            this.jJanusGridOwner.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.jJanusGridOwner.MultiSelect = true;
            this.jJanusGridOwner.Name = "jJanusGridOwner";
            this.jJanusGridOwner.ShowNavigator = true;
            this.jJanusGridOwner.ShowToolbar = true;
            this.jJanusGridOwner.Size = new System.Drawing.Size(741, 322);
            this.jJanusGridOwner.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSearchOwner);
            this.panel3.Controls.Add(this.txtOwner);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.btnDeActiveOw);
            this.panel3.Controls.Add(this.btnActiveOw);
            this.panel3.Controls.Add(this.OwEndDate);
            this.panel3.Controls.Add(this.OwStartDate);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(741, 63);
            this.panel3.TabIndex = 5;
            // 
            // btnSearchOwner
            // 
            this.btnSearchOwner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchOwner.Location = new System.Drawing.Point(449, 33);
            this.btnSearchOwner.Name = "btnSearchOwner";
            this.btnSearchOwner.Size = new System.Drawing.Size(42, 23);
            this.btnSearchOwner.TabIndex = 9;
            this.btnSearchOwner.Text = "...";
            this.btnSearchOwner.UseVisualStyleBackColor = true;
            this.btnSearchOwner.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtOwner
            // 
            this.txtOwner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOwner.Location = new System.Drawing.Point(497, 33);
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.ReadOnly = true;
            this.txtOwner.Size = new System.Drawing.Size(233, 23);
            this.txtOwner.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(273, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 16);
            this.label8.TabIndex = 5;
            this.label8.Text = "EndDate:";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(372, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 16);
            this.label9.TabIndex = 5;
            this.label9.Text = "StartDate:";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(682, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 16);
            this.label11.TabIndex = 5;
            this.label11.Text = "Owner:";
            // 
            // btnDeActiveOw
            // 
            this.btnDeActiveOw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeActiveOw.Location = new System.Drawing.Point(68, 33);
            this.btnDeActiveOw.Name = "btnDeActiveOw";
            this.btnDeActiveOw.Size = new System.Drawing.Size(75, 23);
            this.btnDeActiveOw.TabIndex = 4;
            this.btnDeActiveOw.Text = "DeActive";
            this.btnDeActiveOw.UseVisualStyleBackColor = true;
            this.btnDeActiveOw.Click += new System.EventHandler(this.btnDeActiveOw_Click);
            // 
            // btnActiveOw
            // 
            this.btnActiveOw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActiveOw.Location = new System.Drawing.Point(149, 33);
            this.btnActiveOw.Name = "btnActiveOw";
            this.btnActiveOw.Size = new System.Drawing.Size(75, 23);
            this.btnActiveOw.TabIndex = 3;
            this.btnActiveOw.Text = "Active";
            this.btnActiveOw.UseVisualStyleBackColor = true;
            this.btnActiveOw.Click += new System.EventHandler(this.btnActiveOw_Click);
            // 
            // OwEndDate
            // 
            this.OwEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OwEndDate.ChangeColorIfNotEmpty = true;
            this.OwEndDate.ChangeColorOnEnter = true;
            this.OwEndDate.Date = new System.DateTime(((long)(0)));
            this.OwEndDate.InBackColor = System.Drawing.SystemColors.Info;
            this.OwEndDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.OwEndDate.InsertInDatesTable = true;
            this.OwEndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.OwEndDate.Location = new System.Drawing.Point(230, 33);
            this.OwEndDate.Mask = "0000/00/00";
            this.OwEndDate.Name = "OwEndDate";
            this.OwEndDate.NotEmpty = false;
            this.OwEndDate.NotEmptyColor = System.Drawing.Color.Red;
            this.OwEndDate.Size = new System.Drawing.Size(100, 23);
            this.OwEndDate.TabIndex = 2;
            // 
            // OwStartDate
            // 
            this.OwStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OwStartDate.ChangeColorIfNotEmpty = true;
            this.OwStartDate.ChangeColorOnEnter = true;
            this.OwStartDate.Date = new System.DateTime(((long)(0)));
            this.OwStartDate.InBackColor = System.Drawing.SystemColors.Info;
            this.OwStartDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.OwStartDate.InsertInDatesTable = true;
            this.OwStartDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.OwStartDate.Location = new System.Drawing.Point(336, 33);
            this.OwStartDate.Mask = "0000/00/00";
            this.OwStartDate.Name = "OwStartDate";
            this.OwStartDate.NotEmpty = false;
            this.OwStartDate.NotEmptyColor = System.Drawing.Color.Red;
            this.OwStartDate.Size = new System.Drawing.Size(100, 23);
            this.OwStartDate.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.jJanusGrid1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(747, 391);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "HistoryLog";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // jJanusGrid1
            // 
            this.jJanusGrid1.ActionClassName = "";
            this.jJanusGrid1.ActionMenu = null;
            this.jJanusGrid1.DataSource = null;
            this.jJanusGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jJanusGrid1.Edited = false;
            this.jJanusGrid1.Location = new System.Drawing.Point(3, 3);
            this.jJanusGrid1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jJanusGrid1.MultiSelect = true;
            this.jJanusGrid1.Name = "jJanusGrid1";
            this.jJanusGrid1.ShowNavigator = true;
            this.jJanusGrid1.ShowToolbar = true;
            this.jJanusGrid1.Size = new System.Drawing.Size(741, 385);
            this.jJanusGrid1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(747, 391);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Image";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 420);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(755, 40);
            this.panel1.TabIndex = 11;
            // 
            // DriverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 460);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DriverForm";
            this.Text = "Personel";
            this.Load += new System.EventHandler(this.DriverForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupCertificate.ResumeLayout(false);
            this.groupCertificate.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private ClassLibrary.JJanusGrid jJanusGridOwner;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnDeActiveOw;
        private System.Windows.Forms.Button btnActiveOw;
        private ClassLibrary.DateEdit OwEndDate;
        private ClassLibrary.DateEdit OwStartDate;
        private System.Windows.Forms.Button btnSearchOwner;
        private System.Windows.Forms.TextBox txtOwner;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupCertificate;
        private ClassLibrary.JJanusGrid jJanusGrid1;
        private System.Windows.Forms.TabPage tabPage4;
        private ClassLibrary.JComboBox cmbCertType;
        private ClassLibrary.DateEdit txtCertExpDate;
        private ClassLibrary.DateEdit txtCertDate;
        private System.Windows.Forms.TextBox txtCertNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSelectPerson;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
    }
}