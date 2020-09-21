namespace BusManagment.SellerTicket
{
    partial class SellerForm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnSearchStation = new System.Windows.Forms.Button();
            this.txtStationName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.RichTextBox();
            this.txtTel = new ClassLibrary.NumEdit();
            this.jComType = new ClassLibrary.JComboBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnEditSeller = new System.Windows.Forms.Button();
            this.btnDelSeller = new System.Windows.Forms.Button();
            this.grdSeller = new ClassLibrary.JJanusGrid();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chActiveSeller = new System.Windows.Forms.CheckBox();
            this.btnAddSeller = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtPerson = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEndDate = new ClassLibrary.DateEdit(this.components);
            this.txtStartDate = new ClassLibrary.DateEdit(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtLat = new ClassLibrary.TextEdit(this.components);
            this.txtLongs = new ClassLibrary.TextEdit(this.components);
            this.btnZoomin = new System.Windows.Forms.Button();
            this.btnZoomout = new System.Windows.Forms.Button();
            this.btnShowOnMap = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 334);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(702, 44);
            this.panel1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(14, 5);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 32);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Location = new System.Drawing.Point(464, 5);
            this.btnApply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(110, 32);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Visible = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(580, 5);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(110, 32);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(110, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(702, 334);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnSearchStation);
            this.tabPage1.Controls.Add(this.txtStationName);
            this.tabPage1.Controls.Add(this.txtAddress);
            this.tabPage1.Controls.Add(this.txtTel);
            this.tabPage1.Controls.Add(this.jComType);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(694, 296);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "KioskInfo";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnSearchStation
            // 
            this.btnSearchStation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchStation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchStation.Location = new System.Drawing.Point(335, 47);
            this.btnSearchStation.Name = "btnSearchStation";
            this.btnSearchStation.Size = new System.Drawing.Size(42, 23);
            this.btnSearchStation.TabIndex = 2;
            this.btnSearchStation.Text = "...";
            this.btnSearchStation.UseVisualStyleBackColor = true;
            this.btnSearchStation.Click += new System.EventHandler(this.btnSearchStation_Click);
            // 
            // txtStationName
            // 
            this.txtStationName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStationName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStationName.Location = new System.Drawing.Point(383, 47);
            this.txtStationName.Name = "txtStationName";
            this.txtStationName.ReadOnly = true;
            this.txtStationName.Size = new System.Drawing.Size(233, 23);
            this.txtStationName.TabIndex = 1;
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Location = new System.Drawing.Point(228, 81);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(388, 63);
            this.txtAddress.TabIndex = 3;
            this.txtAddress.Text = "";
            // 
            // txtTel
            // 
            this.txtTel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTel.ChangeColorIfNotEmpty = false;
            this.txtTel.ChangeColorOnEnter = true;
            this.txtTel.InBackColor = System.Drawing.SystemColors.Info;
            this.txtTel.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTel.Location = new System.Drawing.Point(486, 154);
            this.txtTel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTel.Name = "txtTel";
            this.txtTel.Negative = true;
            this.txtTel.NotEmpty = false;
            this.txtTel.NotEmptyColor = System.Drawing.Color.Red;
            this.txtTel.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.txtTel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTel.SelectOnEnter = true;
            this.txtTel.Size = new System.Drawing.Size(130, 23);
            this.txtTel.TabIndex = 4;
            this.txtTel.TextMode = ClassLibrary.TextModes.Text;
            // 
            // jComType
            // 
            this.jComType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.jComType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.jComType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.jComType.BackColor = System.Drawing.SystemColors.Window;
            this.jComType.BaseCode = 0;
            this.jComType.ChangeColorIfNotEmpty = true;
            this.jComType.ChangeColorOnEnter = true;
            this.jComType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.jComType.ForeColor = System.Drawing.SystemColors.WindowText;
            this.jComType.FormattingEnabled = true;
            this.jComType.InBackColor = System.Drawing.SystemColors.Info;
            this.jComType.InForeColor = System.Drawing.SystemColors.WindowText;
            this.jComType.Location = new System.Drawing.Point(486, 16);
            this.jComType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jComType.Name = "jComType";
            this.jComType.NotEmpty = false;
            this.jComType.NotEmptyColor = System.Drawing.Color.Red;
            this.jComType.SelectOnEnter = true;
            this.jComType.Size = new System.Drawing.Size(130, 24);
            this.jComType.TabIndex = 0;
            this.jComType.SelectedIndexChanged += new System.EventHandler(this.jComType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(628, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Station:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(640, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Type:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(650, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Tel:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(622, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Address:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnEditSeller);
            this.tabPage3.Controls.Add(this.btnDelSeller);
            this.tabPage3.Controls.Add(this.grdSeller);
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(694, 296);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "KioskSellers";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnEditSeller
            // 
            this.btnEditSeller.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditSeller.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditSeller.Location = new System.Drawing.Point(601, 267);
            this.btnEditSeller.Name = "btnEditSeller";
            this.btnEditSeller.Size = new System.Drawing.Size(75, 23);
            this.btnEditSeller.TabIndex = 11;
            this.btnEditSeller.Text = "Edit...";
            this.btnEditSeller.UseVisualStyleBackColor = true;
            this.btnEditSeller.Click += new System.EventHandler(this.btnEditOwner_Click);
            // 
            // btnDelSeller
            // 
            this.btnDelSeller.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelSeller.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelSeller.Location = new System.Drawing.Point(520, 267);
            this.btnDelSeller.Name = "btnDelSeller";
            this.btnDelSeller.Size = new System.Drawing.Size(75, 23);
            this.btnDelSeller.TabIndex = 10;
            this.btnDelSeller.Text = "Delete";
            this.btnDelSeller.UseVisualStyleBackColor = true;
            this.btnDelSeller.Click += new System.EventHandler(this.btnDelSeller_Click);
            // 
            // grdSeller
            // 
            this.grdSeller.ActionClassName = "";
            this.grdSeller.ActionMenu = null;
            this.grdSeller.DataSource = null;
            this.grdSeller.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSeller.Edited = false;
            this.grdSeller.Location = new System.Drawing.Point(3, 66);
            this.grdSeller.Margin = new System.Windows.Forms.Padding(3, 11, 3, 11);
            this.grdSeller.MultiSelect = true;
            this.grdSeller.Name = "grdSeller";
            this.grdSeller.ShowNavigator = true;
            this.grdSeller.ShowToolbar = true;
            this.grdSeller.Size = new System.Drawing.Size(688, 227);
            this.grdSeller.TabIndex = 9;
            this.grdSeller.OnRowDBClick += new ClassLibrary.JJanusGrid.RowDBClick(this.grdSeller_OnRowDBClick);
            this.grdSeller.GridRowDoubleClick += new System.EventHandler(this.grdSeller_GridRowDoubleClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chActiveSeller);
            this.panel3.Controls.Add(this.btnAddSeller);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.txtPerson);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.txtEndDate);
            this.panel3.Controls.Add(this.txtStartDate);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(688, 63);
            this.panel3.TabIndex = 7;
            // 
            // chActiveSeller
            // 
            this.chActiveSeller.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chActiveSeller.AutoSize = true;
            this.chActiveSeller.Checked = true;
            this.chActiveSeller.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chActiveSeller.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chActiveSeller.Location = new System.Drawing.Point(116, 33);
            this.chActiveSeller.Name = "chActiveSeller";
            this.chActiveSeller.Size = new System.Drawing.Size(47, 20);
            this.chActiveSeller.TabIndex = 6;
            this.chActiveSeller.Text = "فعال";
            this.chActiveSeller.UseVisualStyleBackColor = true;
            // 
            // btnAddSeller
            // 
            this.btnAddSeller.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSeller.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSeller.Location = new System.Drawing.Point(7, 28);
            this.btnAddSeller.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddSeller.Name = "btnAddSeller";
            this.btnAddSeller.Size = new System.Drawing.Size(87, 28);
            this.btnAddSeller.TabIndex = 4;
            this.btnAddSeller.Text = "Add";
            this.btnAddSeller.UseVisualStyleBackColor = true;
            this.btnAddSeller.Click += new System.EventHandler(this.btnAddSeller_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(388, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(42, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtPerson
            // 
            this.txtPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPerson.Location = new System.Drawing.Point(436, 33);
            this.txtPerson.Name = "txtPerson";
            this.txtPerson.ReadOnly = true;
            this.txtPerson.Size = new System.Drawing.Size(233, 23);
            this.txtPerson.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(212, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 16);
            this.label8.TabIndex = 5;
            this.label8.Text = "EndDate:";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(311, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 16);
            this.label9.TabIndex = 5;
            this.label9.Text = "StartDate:";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(621, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 16);
            this.label11.TabIndex = 5;
            this.label11.Text = "Person:";
            // 
            // txtEndDate
            // 
            this.txtEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEndDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEndDate.ChangeColorIfNotEmpty = true;
            this.txtEndDate.ChangeColorOnEnter = true;
            this.txtEndDate.Date = new System.DateTime(((long)(0)));
            this.txtEndDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtEndDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEndDate.InsertInDatesTable = true;
            this.txtEndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtEndDate.Location = new System.Drawing.Point(169, 33);
            this.txtEndDate.Mask = "0000/00/00";
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.NotEmpty = false;
            this.txtEndDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtEndDate.Size = new System.Drawing.Size(100, 23);
            this.txtEndDate.TabIndex = 3;
            // 
            // txtStartDate
            // 
            this.txtStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStartDate.ChangeColorIfNotEmpty = true;
            this.txtStartDate.ChangeColorOnEnter = true;
            this.txtStartDate.Date = new System.DateTime(((long)(0)));
            this.txtStartDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtStartDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtStartDate.InsertInDatesTable = true;
            this.txtStartDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtStartDate.Location = new System.Drawing.Point(275, 33);
            this.txtStartDate.Mask = "0000/00/00";
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.NotEmpty = false;
            this.txtStartDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtStartDate.Size = new System.Drawing.Size(100, 23);
            this.txtStartDate.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gMapControl1);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(694, 296);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Map";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemmory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(3, 3);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(510, 290);
            this.gMapControl1.TabIndex = 6;
            this.gMapControl1.Zoom = 0D;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtLat);
            this.panel2.Controls.Add(this.txtLongs);
            this.panel2.Controls.Add(this.btnZoomin);
            this.panel2.Controls.Add(this.btnZoomout);
            this.panel2.Controls.Add(this.btnShowOnMap);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(513, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(178, 290);
            this.panel2.TabIndex = 5;
            // 
            // txtLat
            // 
            this.txtLat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLat.ChangeColorIfNotEmpty = false;
            this.txtLat.ChangeColorOnEnter = true;
            this.txtLat.InBackColor = System.Drawing.SystemColors.Info;
            this.txtLat.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLat.Location = new System.Drawing.Point(6, 31);
            this.txtLat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLat.Name = "txtLat";
            this.txtLat.Negative = true;
            this.txtLat.NotEmpty = false;
            this.txtLat.NotEmptyColor = System.Drawing.Color.Red;
            this.txtLat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLat.SelectOnEnter = true;
            this.txtLat.Size = new System.Drawing.Size(164, 23);
            this.txtLat.TabIndex = 22;
            this.txtLat.TextMode = ClassLibrary.TextModes.Real;
            // 
            // txtLongs
            // 
            this.txtLongs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLongs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLongs.ChangeColorIfNotEmpty = false;
            this.txtLongs.ChangeColorOnEnter = true;
            this.txtLongs.InBackColor = System.Drawing.SystemColors.Info;
            this.txtLongs.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLongs.Location = new System.Drawing.Point(6, 76);
            this.txtLongs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLongs.Name = "txtLongs";
            this.txtLongs.Negative = true;
            this.txtLongs.NotEmpty = false;
            this.txtLongs.NotEmptyColor = System.Drawing.Color.Red;
            this.txtLongs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLongs.SelectOnEnter = true;
            this.txtLongs.Size = new System.Drawing.Size(164, 23);
            this.txtLongs.TabIndex = 21;
            this.txtLongs.TextMode = ClassLibrary.TextModes.Real;
            // 
            // btnZoomin
            // 
            this.btnZoomin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomin.Location = new System.Drawing.Point(56, 166);
            this.btnZoomin.Name = "btnZoomin";
            this.btnZoomin.Size = new System.Drawing.Size(44, 28);
            this.btnZoomin.TabIndex = 6;
            this.btnZoomin.Text = "+";
            this.btnZoomin.UseVisualStyleBackColor = true;
            // 
            // btnZoomout
            // 
            this.btnZoomout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomout.Location = new System.Drawing.Point(6, 166);
            this.btnZoomout.Name = "btnZoomout";
            this.btnZoomout.Size = new System.Drawing.Size(44, 28);
            this.btnZoomout.TabIndex = 5;
            this.btnZoomout.Text = "-";
            this.btnZoomout.UseVisualStyleBackColor = true;
            // 
            // btnShowOnMap
            // 
            this.btnShowOnMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowOnMap.Location = new System.Drawing.Point(6, 106);
            this.btnShowOnMap.Name = "btnShowOnMap";
            this.btnShowOnMap.Size = new System.Drawing.Size(81, 28);
            this.btnShowOnMap.TabIndex = 4;
            this.btnShowOnMap.Text = "Show";
            this.btnShowOnMap.UseVisualStyleBackColor = true;
            this.btnShowOnMap.Click += new System.EventHandler(this.btnShowOnMap_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(140, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Lng:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(143, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "Lat:";
            // 
            // SellerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 378);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SellerForm";
            this.Text = "SellerTicket";
            this.Load += new System.EventHandler(this.SellerForm_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox txtAddress;
        private ClassLibrary.NumEdit txtTel;
        private ClassLibrary.JComboBox jComType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtPerson;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private ClassLibrary.DateEdit txtEndDate;
        private ClassLibrary.DateEdit txtStartDate;
        private System.Windows.Forms.Button btnSearchStation;
        private System.Windows.Forms.TextBox txtStationName;
        private System.Windows.Forms.Button btnAddSeller;
        private ClassLibrary.JJanusGrid grdSeller;
        private System.Windows.Forms.Button btnDelSeller;
        private System.Windows.Forms.CheckBox chActiveSeller;
        private System.Windows.Forms.Button btnEditSeller;
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnZoomin;
        private System.Windows.Forms.Button btnZoomout;
        private System.Windows.Forms.Button btnShowOnMap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private ClassLibrary.TextEdit txtLat;
        private ClassLibrary.TextEdit txtLongs;

    }
}