namespace BusManagment.Personel
{
    partial class JPersonelForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPersonelCode = new ClassLibrary.TextEdit(this.components);
            this.groupCertificate = new System.Windows.Forms.GroupBox();
            this.cmbEmpType = new ClassLibrary.JComboBox(this.components);
            this.cmbCertType = new ClassLibrary.JComboBox(this.components);
            this.cmbFleet = new ClassLibrary.JComboBox(this.components);
            this.txtCertExpDate = new ClassLibrary.DateEdit(this.components);
            this.cmbSpecific = new ClassLibrary.JComboBox(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.txtCertDate = new ClassLibrary.DateEdit(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.txtCertNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.personControl = new ClassLibrary.JUCPerson();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnEditOwner = new System.Windows.Forms.Button();
            this.btnDeActiveOw = new System.Windows.Forms.Button();
            this.grdContract = new ClassLibrary.JJanusGrid();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAddOwner = new System.Windows.Forms.Button();
            this.btnSearchOwner = new System.Windows.Forms.Button();
            this.txtPerson = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtOwEndDate = new ClassLibrary.DateEdit(this.components);
            this.txtOwStartDate = new ClassLibrary.DateEdit(this.components);
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnProperties = new System.Windows.Forms.Button();
            this.jPropertyValue = new Globals.Property.JPropertyValueUserControl();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupCertificate.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 408);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 40);
            this.panel1.TabIndex = 18;
            // 
            // btnOk
            // 
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(653, 3);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(110, 32);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(12, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 32);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(110, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(775, 408);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtPersonelCode);
            this.tabPage1.Controls.Add(this.groupCertificate);
            this.tabPage1.Controls.Add(this.personControl);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(767, 370);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "اطلاعات شخص";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "کد پرسنلی:";
            // 
            // txtPersonelCode
            // 
            this.txtPersonelCode.ChangeColorIfNotEmpty = false;
            this.txtPersonelCode.ChangeColorOnEnter = true;
            this.txtPersonelCode.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPersonelCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPersonelCode.Location = new System.Drawing.Point(39, 21);
            this.txtPersonelCode.Name = "txtPersonelCode";
            this.txtPersonelCode.Negative = true;
            this.txtPersonelCode.NotEmpty = false;
            this.txtPersonelCode.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPersonelCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPersonelCode.SelectOnEnter = true;
            this.txtPersonelCode.Size = new System.Drawing.Size(132, 23);
            this.txtPersonelCode.TabIndex = 1;
            this.txtPersonelCode.TextMode = ClassLibrary.TextModes.Text;
            // 
            // groupCertificate
            // 
            this.groupCertificate.Controls.Add(this.cmbEmpType);
            this.groupCertificate.Controls.Add(this.cmbCertType);
            this.groupCertificate.Controls.Add(this.cmbFleet);
            this.groupCertificate.Controls.Add(this.txtCertExpDate);
            this.groupCertificate.Controls.Add(this.cmbSpecific);
            this.groupCertificate.Controls.Add(this.label8);
            this.groupCertificate.Controls.Add(this.txtCertDate);
            this.groupCertificate.Controls.Add(this.label7);
            this.groupCertificate.Controls.Add(this.txtCertNumber);
            this.groupCertificate.Controls.Add(this.label3);
            this.groupCertificate.Controls.Add(this.label6);
            this.groupCertificate.Controls.Add(this.label5);
            this.groupCertificate.Controls.Add(this.label4);
            this.groupCertificate.Controls.Add(this.label2);
            this.groupCertificate.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupCertificate.Location = new System.Drawing.Point(3, 181);
            this.groupCertificate.Name = "groupCertificate";
            this.groupCertificate.Size = new System.Drawing.Size(761, 114);
            this.groupCertificate.TabIndex = 2;
            this.groupCertificate.TabStop = false;
            this.groupCertificate.Text = "اطلاعات گواهینامه";
            // 
            // cmbEmpType
            // 
            this.cmbEmpType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbEmpType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEmpType.BaseCode = 0;
            this.cmbEmpType.ChangeColorIfNotEmpty = true;
            this.cmbEmpType.ChangeColorOnEnter = true;
            this.cmbEmpType.FormattingEnabled = true;
            this.cmbEmpType.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbEmpType.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbEmpType.Location = new System.Drawing.Point(36, 81);
            this.cmbEmpType.Name = "cmbEmpType";
            this.cmbEmpType.NotEmpty = false;
            this.cmbEmpType.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbEmpType.SelectOnEnter = true;
            this.cmbEmpType.Size = new System.Drawing.Size(132, 24);
            this.cmbEmpType.TabIndex = 6;
            // 
            // cmbCertType
            // 
            this.cmbCertType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCertType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbCertType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCertType.BaseCode = 0;
            this.cmbCertType.ChangeColorIfNotEmpty = true;
            this.cmbCertType.ChangeColorOnEnter = true;
            this.cmbCertType.FormattingEnabled = true;
            this.cmbCertType.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbCertType.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbCertType.Location = new System.Drawing.Point(520, 80);
            this.cmbCertType.Name = "cmbCertType";
            this.cmbCertType.NotEmpty = false;
            this.cmbCertType.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbCertType.SelectOnEnter = true;
            this.cmbCertType.Size = new System.Drawing.Size(100, 24);
            this.cmbCertType.TabIndex = 3;
            // 
            // cmbFleet
            // 
            this.cmbFleet.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbFleet.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFleet.BaseCode = 0;
            this.cmbFleet.ChangeColorIfNotEmpty = true;
            this.cmbFleet.ChangeColorOnEnter = true;
            this.cmbFleet.FormattingEnabled = true;
            this.cmbFleet.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbFleet.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbFleet.Location = new System.Drawing.Point(36, 48);
            this.cmbFleet.Name = "cmbFleet";
            this.cmbFleet.NotEmpty = false;
            this.cmbFleet.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbFleet.SelectOnEnter = true;
            this.cmbFleet.Size = new System.Drawing.Size(132, 24);
            this.cmbFleet.TabIndex = 5;
            // 
            // txtCertExpDate
            // 
            this.txtCertExpDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCertExpDate.ChangeColorIfNotEmpty = true;
            this.txtCertExpDate.ChangeColorOnEnter = true;
            this.txtCertExpDate.Date = new System.DateTime(((long)(0)));
            this.txtCertExpDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtCertExpDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCertExpDate.InsertInDatesTable = true;
            this.txtCertExpDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtCertExpDate.Location = new System.Drawing.Point(279, 51);
            this.txtCertExpDate.Mask = "0000/00/00";
            this.txtCertExpDate.Name = "txtCertExpDate";
            this.txtCertExpDate.NotEmpty = false;
            this.txtCertExpDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtCertExpDate.Size = new System.Drawing.Size(100, 23);
            this.txtCertExpDate.TabIndex = 2;
            // 
            // cmbSpecific
            // 
            this.cmbSpecific.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbSpecific.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSpecific.BaseCode = 0;
            this.cmbSpecific.ChangeColorIfNotEmpty = true;
            this.cmbSpecific.ChangeColorOnEnter = true;
            this.cmbSpecific.FormattingEnabled = true;
            this.cmbSpecific.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbSpecific.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbSpecific.Location = new System.Drawing.Point(36, 17);
            this.cmbSpecific.Name = "cmbSpecific";
            this.cmbSpecific.NotEmpty = false;
            this.cmbSpecific.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbSpecific.SelectOnEnter = true;
            this.cmbSpecific.Size = new System.Drawing.Size(132, 24);
            this.cmbSpecific.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(174, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 16);
            this.label8.TabIndex = 21;
            this.label8.Text = "کد ناوگان:";
            // 
            // txtCertDate
            // 
            this.txtCertDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCertDate.ChangeColorIfNotEmpty = true;
            this.txtCertDate.ChangeColorOnEnter = true;
            this.txtCertDate.Date = new System.DateTime(((long)(0)));
            this.txtCertDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtCertDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCertDate.InsertInDatesTable = true;
            this.txtCertDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtCertDate.Location = new System.Drawing.Point(520, 51);
            this.txtCertDate.Mask = "0000/00/00";
            this.txtCertDate.Name = "txtCertDate";
            this.txtCertDate.NotEmpty = false;
            this.txtCertDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtCertDate.Size = new System.Drawing.Size(100, 23);
            this.txtCertDate.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(174, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 16);
            this.label7.TabIndex = 20;
            this.label7.Text = "نوع استخدام:";
            // 
            // txtCertNumber
            // 
            this.txtCertNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCertNumber.Location = new System.Drawing.Point(279, 21);
            this.txtCertNumber.Name = "txtCertNumber";
            this.txtCertNumber.Size = new System.Drawing.Size(341, 23);
            this.txtCertNumber.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "تخصص:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(643, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "نوع گواهینامه:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(374, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "تاریخ انقضاء:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(660, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "تاریخ صدور:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(625, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "شماره گواهینامه:";
            // 
            // personControl
            // 
            this.personControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.personControl.FilterPerson = null;
            this.personControl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.personControl.LableGroup = null;
            this.personControl.Location = new System.Drawing.Point(3, 3);
            this.personControl.Name = "personControl";
            this.personControl.PersonType = ClassLibrary.JPersonTypes.RealPerson;
            this.personControl.ReadOnly = false;
            this.personControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.personControl.SearchOnCode = ClassLibrary.SearchOnCode.Code;
            this.personControl.SelectedCode = 0;
            this.personControl.Size = new System.Drawing.Size(761, 178);
            this.personControl.TabIndex = 0;
            this.personControl.TafsiliCode = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnEditOwner);
            this.tabPage2.Controls.Add(this.btnDeActiveOw);
            this.tabPage2.Controls.Add(this.grdContract);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(767, 379);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Contract";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnEditOwner
            // 
            this.btnEditOwner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditOwner.Location = new System.Drawing.Point(672, 350);
            this.btnEditOwner.Name = "btnEditOwner";
            this.btnEditOwner.Size = new System.Drawing.Size(75, 23);
            this.btnEditOwner.TabIndex = 6;
            this.btnEditOwner.Text = "Edit";
            this.btnEditOwner.UseVisualStyleBackColor = true;
            this.btnEditOwner.Click += new System.EventHandler(this.btnEditOwner_Click);
            // 
            // btnDeActiveOw
            // 
            this.btnDeActiveOw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeActiveOw.Location = new System.Drawing.Point(591, 350);
            this.btnDeActiveOw.Name = "btnDeActiveOw";
            this.btnDeActiveOw.Size = new System.Drawing.Size(75, 23);
            this.btnDeActiveOw.TabIndex = 7;
            this.btnDeActiveOw.Text = "Delete";
            this.btnDeActiveOw.UseVisualStyleBackColor = true;
            this.btnDeActiveOw.Click += new System.EventHandler(this.btnDeActiveOw_Click);
            // 
            // grdContract
            // 
            this.grdContract.ActionClassName = "";
            this.grdContract.ActionMenu = null;
            this.grdContract.DataSource = null;
            this.grdContract.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdContract.Edited = false;
            this.grdContract.Location = new System.Drawing.Point(3, 66);
            this.grdContract.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.grdContract.MultiSelect = true;
            this.grdContract.Name = "grdContract";
            this.grdContract.ShowNavigator = true;
            this.grdContract.ShowToolbar = true;
            this.grdContract.Size = new System.Drawing.Size(761, 310);
            this.grdContract.TabIndex = 4;
            this.grdContract.OnRowDBClick += new ClassLibrary.JJanusGrid.RowDBClick(this.grdContract_OnRowDBClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnAddOwner);
            this.panel3.Controls.Add(this.btnSearchOwner);
            this.panel3.Controls.Add(this.txtPerson);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.txtOwEndDate);
            this.panel3.Controls.Add(this.txtOwStartDate);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(761, 63);
            this.panel3.TabIndex = 5;
            // 
            // btnAddOwner
            // 
            this.btnAddOwner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddOwner.Location = new System.Drawing.Point(157, 31);
            this.btnAddOwner.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddOwner.Name = "btnAddOwner";
            this.btnAddOwner.Size = new System.Drawing.Size(87, 28);
            this.btnAddOwner.TabIndex = 4;
            this.btnAddOwner.Text = "Add";
            this.btnAddOwner.UseVisualStyleBackColor = true;
            this.btnAddOwner.Click += new System.EventHandler(this.btnAddOwner_Click);
            // 
            // btnSearchOwner
            // 
            this.btnSearchOwner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchOwner.Location = new System.Drawing.Point(469, 33);
            this.btnSearchOwner.Name = "btnSearchOwner";
            this.btnSearchOwner.Size = new System.Drawing.Size(42, 23);
            this.btnSearchOwner.TabIndex = 1;
            this.btnSearchOwner.Text = "...";
            this.btnSearchOwner.UseVisualStyleBackColor = true;
            this.btnSearchOwner.Click += new System.EventHandler(this.btnSearchOwner_Click);
            // 
            // txtPerson
            // 
            this.txtPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPerson.Location = new System.Drawing.Point(517, 33);
            this.txtPerson.Name = "txtPerson";
            this.txtPerson.ReadOnly = true;
            this.txtPerson.Size = new System.Drawing.Size(233, 23);
            this.txtPerson.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(293, 14);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 16);
            this.label14.TabIndex = 5;
            this.label14.Text = "EndDate:";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(392, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 16);
            this.label15.TabIndex = 5;
            this.label15.Text = "StartDate:";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(702, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 16);
            this.label16.TabIndex = 5;
            this.label16.Text = "Owner:";
            // 
            // txtOwEndDate
            // 
            this.txtOwEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOwEndDate.ChangeColorIfNotEmpty = true;
            this.txtOwEndDate.ChangeColorOnEnter = true;
            this.txtOwEndDate.Date = new System.DateTime(((long)(0)));
            this.txtOwEndDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtOwEndDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOwEndDate.InsertInDatesTable = true;
            this.txtOwEndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtOwEndDate.Location = new System.Drawing.Point(250, 33);
            this.txtOwEndDate.Mask = "0000/00/00";
            this.txtOwEndDate.Name = "txtOwEndDate";
            this.txtOwEndDate.NotEmpty = false;
            this.txtOwEndDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtOwEndDate.Size = new System.Drawing.Size(100, 23);
            this.txtOwEndDate.TabIndex = 3;
            // 
            // txtOwStartDate
            // 
            this.txtOwStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOwStartDate.ChangeColorIfNotEmpty = true;
            this.txtOwStartDate.ChangeColorOnEnter = true;
            this.txtOwStartDate.Date = new System.DateTime(((long)(0)));
            this.txtOwStartDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtOwStartDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOwStartDate.InsertInDatesTable = true;
            this.txtOwStartDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtOwStartDate.Location = new System.Drawing.Point(356, 33);
            this.txtOwStartDate.Mask = "0000/00/00";
            this.txtOwStartDate.Name = "txtOwStartDate";
            this.txtOwStartDate.NotEmpty = false;
            this.txtOwStartDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtOwStartDate.Size = new System.Drawing.Size(100, 23);
            this.txtOwStartDate.TabIndex = 2;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(767, 379);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Image";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnProperties);
            this.tabPage3.Controls.Add(this.jPropertyValue);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(767, 379);
            this.tabPage3.TabIndex = 4;
            this.tabPage3.Text = "Properties";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnProperties
            // 
            this.btnProperties.Location = new System.Drawing.Point(2, 6);
            this.btnProperties.Name = "btnProperties";
            this.btnProperties.Size = new System.Drawing.Size(136, 23);
            this.btnProperties.TabIndex = 371;
            this.btnProperties.Text = "EditProperties";
            this.btnProperties.UseVisualStyleBackColor = true;
            this.btnProperties.Click += new System.EventHandler(this.btnProperties_Click);
            // 
            // jPropertyValue
            // 
            this.jPropertyValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jPropertyValue.AutoScroll = true;
            this.jPropertyValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jPropertyValue.ClassName = null;
            this.jPropertyValue.Location = new System.Drawing.Point(3, 39);
            this.jPropertyValue.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.jPropertyValue.Name = "jPropertyValue";
            this.jPropertyValue.ObjectCode = -1;
            this.jPropertyValue.Size = new System.Drawing.Size(761, 340);
            this.jPropertyValue.TabIndex = 370;
            this.jPropertyValue.ValueObjectCode = 0;
            // 
            // JPersonelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 448);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "JPersonelForm";
            this.Text = "PersonelForm";
            this.Load += new System.EventHandler(this.JPersonelForm_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupCertificate.ResumeLayout(false);
            this.groupCertificate.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.TextEdit txtPersonelCode;
        private System.Windows.Forms.GroupBox groupCertificate;
        private ClassLibrary.JComboBox cmbEmpType;
        private ClassLibrary.JComboBox cmbCertType;
        private ClassLibrary.JComboBox cmbFleet;
        private ClassLibrary.DateEdit txtCertExpDate;
        private ClassLibrary.JComboBox cmbSpecific;
        private System.Windows.Forms.Label label8;
        private ClassLibrary.DateEdit txtCertDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCertNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.JUCPerson personControl;
        private System.Windows.Forms.TabPage tabPage2;
        private ClassLibrary.JJanusGrid grdContract;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSearchOwner;
        private System.Windows.Forms.TextBox txtPerson;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private ClassLibrary.DateEdit txtOwEndDate;
        private ClassLibrary.DateEdit txtOwStartDate;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnAddOwner;
        private System.Windows.Forms.Button btnEditOwner;
        private System.Windows.Forms.Button btnDeActiveOw;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnProperties;
        private Globals.Property.JPropertyValueUserControl jPropertyValue;
    }
}