namespace BusManagment.Bus
{
    partial class JBusForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dateEdit1 = new ClassLibrary.DateEdit(this.components);
            this.btnReload = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtStartDateDevise = new ClassLibrary.DateEdit(this.components);
            this.txtEndDateDevise = new ClassLibrary.DateEdit(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBusDevise = new System.Windows.Forms.TextBox();
            this.btnSearchDevice = new System.Windows.Forms.Button();
            this.btnAddDevice = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtInstaller = new System.Windows.Forms.TextBox();
            this.btnAddInstaller = new System.Windows.Forms.Button();
            this.grdDevice = new ClassLibrary.JJanusGrid();
            this.btnDeActiveDev = new System.Windows.Forms.Button();
            this.btnEditDevice = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtOwStartDate = new ClassLibrary.DateEdit(this.components);
            this.txtOwEndDate = new ClassLibrary.DateEdit(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPerson = new System.Windows.Forms.TextBox();
            this.btnSearchOwner = new System.Windows.Forms.Button();
            this.btnAddOwner = new System.Windows.Forms.Button();
            this.chActive = new System.Windows.Forms.CheckBox();
            this.grdOwners = new ClassLibrary.JJanusGrid();
            this.btnDeActiveOw = new System.Windows.Forms.Button();
            this.btnEditOwner = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedActive = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbFleet = new ClassLibrary.JComboBox(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.cmbPlak = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.jPropertyValue = new Globals.Property.JPropertyValueUserControl();
            this.btnProperties = new System.Windows.Forms.Button();
            this.txtPlak2 = new System.Windows.Forms.TextBox();
            this.txtPlak1 = new System.Windows.Forms.TextBox();
            this.txtPlak3 = new System.Windows.Forms.TextBox();
            this.txtBCode = new ClassLibrary.TextEdit(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.panel1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(578, 4);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(110, 28);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Location = new System.Drawing.Point(457, 4);
            this.btnApply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(110, 28);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Visible = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(12, 4);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 28);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 322);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(695, 36);
            this.panel1.TabIndex = 1;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.panel4);
            this.tabPage5.Location = new System.Drawing.Point(4, 34);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(687, 284);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "AVL";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnReload);
            this.panel4.Controls.Add(this.dateEdit1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(681, 34);
            this.panel4.TabIndex = 1;
            // 
            // dateEdit1
            // 
            this.dateEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateEdit1.ChangeColorIfNotEmpty = true;
            this.dateEdit1.ChangeColorOnEnter = true;
            this.dateEdit1.Date = new System.DateTime(((long)(0)));
            this.dateEdit1.InBackColor = System.Drawing.SystemColors.Info;
            this.dateEdit1.InForeColor = System.Drawing.SystemColors.WindowText;
            this.dateEdit1.InsertInDatesTable = true;
            this.dateEdit1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dateEdit1.Location = new System.Drawing.Point(576, 4);
            this.dateEdit1.Mask = "0000/00/00";
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.NotEmpty = false;
            this.dateEdit1.NotEmptyColor = System.Drawing.Color.Red;
            this.dateEdit1.Size = new System.Drawing.Size(100, 23);
            this.dateEdit1.TabIndex = 0;
            // 
            // btnReload
            // 
            this.btnReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReload.Location = new System.Drawing.Point(495, 4);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 23);
            this.btnReload.TabIndex = 1;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(687, 284);
            this.tabPage2.TabIndex = 5;
            this.tabPage2.Text = "Image";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnEditDevice);
            this.tabPage3.Controls.Add(this.btnDeActiveDev);
            this.tabPage3.Controls.Add(this.grdDevice);
            this.tabPage3.Controls.Add(this.panel2);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(687, 284);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Device";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAddInstaller);
            this.panel2.Controls.Add(this.txtInstaller);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.btnAddDevice);
            this.panel2.Controls.Add(this.btnSearchDevice);
            this.panel2.Controls.Add(this.txtBusDevise);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtEndDateDevise);
            this.panel2.Controls.Add(this.txtStartDateDevise);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(681, 76);
            this.panel2.TabIndex = 1;
            // 
            // txtStartDateDevise
            // 
            this.txtStartDateDevise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartDateDevise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStartDateDevise.ChangeColorIfNotEmpty = true;
            this.txtStartDateDevise.ChangeColorOnEnter = true;
            this.txtStartDateDevise.Date = new System.DateTime(((long)(0)));
            this.txtStartDateDevise.InBackColor = System.Drawing.SystemColors.Info;
            this.txtStartDateDevise.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtStartDateDevise.InsertInDatesTable = true;
            this.txtStartDateDevise.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtStartDateDevise.Location = new System.Drawing.Point(127, 10);
            this.txtStartDateDevise.Mask = "0000/00/00";
            this.txtStartDateDevise.Name = "txtStartDateDevise";
            this.txtStartDateDevise.NotEmpty = false;
            this.txtStartDateDevise.NotEmptyColor = System.Drawing.Color.Red;
            this.txtStartDateDevise.Size = new System.Drawing.Size(100, 23);
            this.txtStartDateDevise.TabIndex = 4;
            // 
            // txtEndDateDevise
            // 
            this.txtEndDateDevise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEndDateDevise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEndDateDevise.ChangeColorIfNotEmpty = true;
            this.txtEndDateDevise.ChangeColorOnEnter = true;
            this.txtEndDateDevise.Date = new System.DateTime(((long)(0)));
            this.txtEndDateDevise.InBackColor = System.Drawing.SystemColors.Info;
            this.txtEndDateDevise.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEndDateDevise.InsertInDatesTable = true;
            this.txtEndDateDevise.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtEndDateDevise.Location = new System.Drawing.Point(127, 40);
            this.txtEndDateDevise.Mask = "0000/00/00";
            this.txtEndDateDevise.Name = "txtEndDateDevise";
            this.txtEndDateDevise.NotEmpty = false;
            this.txtEndDateDevise.NotEmptyColor = System.Drawing.Color.Red;
            this.txtEndDateDevise.Size = new System.Drawing.Size(100, 23);
            this.txtEndDateDevise.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(621, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Device:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(233, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "StartDate:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(240, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "EndDate:";
            // 
            // txtBusDevise
            // 
            this.txtBusDevise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBusDevise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBusDevise.Location = new System.Drawing.Point(382, 9);
            this.txtBusDevise.Name = "txtBusDevise";
            this.txtBusDevise.ReadOnly = true;
            this.txtBusDevise.Size = new System.Drawing.Size(231, 23);
            this.txtBusDevise.TabIndex = 0;
            // 
            // btnSearchDevice
            // 
            this.btnSearchDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchDevice.Location = new System.Drawing.Point(334, 9);
            this.btnSearchDevice.Name = "btnSearchDevice";
            this.btnSearchDevice.Size = new System.Drawing.Size(42, 23);
            this.btnSearchDevice.TabIndex = 1;
            this.btnSearchDevice.Text = "...";
            this.btnSearchDevice.UseVisualStyleBackColor = true;
            this.btnSearchDevice.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnAddDevice
            // 
            this.btnAddDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDevice.Location = new System.Drawing.Point(19, 37);
            this.btnAddDevice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddDevice.Name = "btnAddDevice";
            this.btnAddDevice.Size = new System.Drawing.Size(87, 28);
            this.btnAddDevice.TabIndex = 10;
            this.btnAddDevice.Text = "Add";
            this.btnAddDevice.UseVisualStyleBackColor = true;
            this.btnAddDevice.Click += new System.EventHandler(this.btnAddDevice_Click);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(619, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 16);
            this.label12.TabIndex = 13;
            this.label12.Text = "Installer";
            // 
            // txtInstaller
            // 
            this.txtInstaller.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInstaller.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInstaller.Location = new System.Drawing.Point(382, 43);
            this.txtInstaller.Name = "txtInstaller";
            this.txtInstaller.ReadOnly = true;
            this.txtInstaller.Size = new System.Drawing.Size(231, 23);
            this.txtInstaller.TabIndex = 2;
            // 
            // btnAddInstaller
            // 
            this.btnAddInstaller.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddInstaller.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddInstaller.Location = new System.Drawing.Point(334, 43);
            this.btnAddInstaller.Name = "btnAddInstaller";
            this.btnAddInstaller.Size = new System.Drawing.Size(42, 23);
            this.btnAddInstaller.TabIndex = 3;
            this.btnAddInstaller.Text = "...";
            this.btnAddInstaller.UseVisualStyleBackColor = true;
            this.btnAddInstaller.Click += new System.EventHandler(this.btnAddInstaller_Click);
            // 
            // grdDevice
            // 
            this.grdDevice.ActionClassName = "";
            this.grdDevice.ActionMenu = null;
            this.grdDevice.DataSource = null;
            this.grdDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDevice.Edited = false;
            this.grdDevice.Location = new System.Drawing.Point(3, 79);
            this.grdDevice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdDevice.MultiSelect = true;
            this.grdDevice.Name = "grdDevice";
            this.grdDevice.ShowNavigator = true;
            this.grdDevice.ShowToolbar = true;
            this.grdDevice.Size = new System.Drawing.Size(681, 202);
            this.grdDevice.TabIndex = 0;
            this.grdDevice.OnRowDBClick += new ClassLibrary.JJanusGrid.RowDBClick(this.grdDevice_OnRowDBClick);
            // 
            // btnDeActiveDev
            // 
            this.btnDeActiveDev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeActiveDev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeActiveDev.Location = new System.Drawing.Point(515, 253);
            this.btnDeActiveDev.Name = "btnDeActiveDev";
            this.btnDeActiveDev.Size = new System.Drawing.Size(75, 23);
            this.btnDeActiveDev.TabIndex = 4;
            this.btnDeActiveDev.Text = "Delete";
            this.btnDeActiveDev.UseVisualStyleBackColor = true;
            this.btnDeActiveDev.Click += new System.EventHandler(this.btnDevActiveDev_Click);
            // 
            // btnEditDevice
            // 
            this.btnEditDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditDevice.Location = new System.Drawing.Point(596, 253);
            this.btnEditDevice.Name = "btnEditDevice";
            this.btnEditDevice.Size = new System.Drawing.Size(75, 23);
            this.btnEditDevice.TabIndex = 3;
            this.btnEditDevice.Text = "Edit";
            this.btnEditDevice.UseVisualStyleBackColor = true;
            this.btnEditDevice.Click += new System.EventHandler(this.btnActiveDev_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnEditOwner);
            this.tabPage4.Controls.Add(this.btnDeActiveOw);
            this.tabPage4.Controls.Add(this.grdOwners);
            this.tabPage4.Controls.Add(this.panel3);
            this.tabPage4.Location = new System.Drawing.Point(4, 34);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(687, 284);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Owner";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chActive);
            this.panel3.Controls.Add(this.btnAddOwner);
            this.panel3.Controls.Add(this.btnSearchOwner);
            this.panel3.Controls.Add(this.txtPerson);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.txtOwEndDate);
            this.panel3.Controls.Add(this.txtOwStartDate);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(681, 63);
            this.panel3.TabIndex = 0;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // txtOwStartDate
            // 
            this.txtOwStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOwStartDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOwStartDate.ChangeColorIfNotEmpty = true;
            this.txtOwStartDate.ChangeColorOnEnter = true;
            this.txtOwStartDate.Date = new System.DateTime(((long)(0)));
            this.txtOwStartDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtOwStartDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOwStartDate.InsertInDatesTable = true;
            this.txtOwStartDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtOwStartDate.Location = new System.Drawing.Point(275, 33);
            this.txtOwStartDate.Mask = "0000/00/00";
            this.txtOwStartDate.Name = "txtOwStartDate";
            this.txtOwStartDate.NotEmpty = false;
            this.txtOwStartDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtOwStartDate.Size = new System.Drawing.Size(100, 23);
            this.txtOwStartDate.TabIndex = 2;
            // 
            // txtOwEndDate
            // 
            this.txtOwEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOwEndDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOwEndDate.ChangeColorIfNotEmpty = true;
            this.txtOwEndDate.ChangeColorOnEnter = true;
            this.txtOwEndDate.Date = new System.DateTime(((long)(0)));
            this.txtOwEndDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtOwEndDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOwEndDate.InsertInDatesTable = true;
            this.txtOwEndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtOwEndDate.Location = new System.Drawing.Point(169, 33);
            this.txtOwEndDate.Mask = "0000/00/00";
            this.txtOwEndDate.Name = "txtOwEndDate";
            this.txtOwEndDate.NotEmpty = false;
            this.txtOwEndDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtOwEndDate.Size = new System.Drawing.Size(100, 23);
            this.txtOwEndDate.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(612, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 16);
            this.label11.TabIndex = 5;
            this.label11.Text = "Person:";
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
            // txtPerson
            // 
            this.txtPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPerson.Location = new System.Drawing.Point(430, 33);
            this.txtPerson.Name = "txtPerson";
            this.txtPerson.ReadOnly = true;
            this.txtPerson.Size = new System.Drawing.Size(231, 23);
            this.txtPerson.TabIndex = 0;
            // 
            // btnSearchOwner
            // 
            this.btnSearchOwner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchOwner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchOwner.Location = new System.Drawing.Point(382, 33);
            this.btnSearchOwner.Name = "btnSearchOwner";
            this.btnSearchOwner.Size = new System.Drawing.Size(42, 23);
            this.btnSearchOwner.TabIndex = 1;
            this.btnSearchOwner.Text = "...";
            this.btnSearchOwner.UseVisualStyleBackColor = true;
            this.btnSearchOwner.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAddOwner
            // 
            this.btnAddOwner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddOwner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddOwner.Location = new System.Drawing.Point(5, 28);
            this.btnAddOwner.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddOwner.Name = "btnAddOwner";
            this.btnAddOwner.Size = new System.Drawing.Size(87, 28);
            this.btnAddOwner.TabIndex = 4;
            this.btnAddOwner.Text = "Add";
            this.btnAddOwner.UseVisualStyleBackColor = true;
            this.btnAddOwner.Click += new System.EventHandler(this.btnAddOwner_Click);
            // 
            // chActive
            // 
            this.chActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chActive.AutoSize = true;
            this.chActive.Checked = true;
            this.chActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chActive.Location = new System.Drawing.Point(116, 33);
            this.chActive.Name = "chActive";
            this.chActive.Size = new System.Drawing.Size(47, 20);
            this.chActive.TabIndex = 6;
            this.chActive.Text = "فعال";
            this.chActive.UseVisualStyleBackColor = true;
            // 
            // grdOwners
            // 
            this.grdOwners.ActionClassName = "";
            this.grdOwners.ActionMenu = null;
            this.grdOwners.DataSource = null;
            this.grdOwners.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOwners.Edited = false;
            this.grdOwners.Location = new System.Drawing.Point(3, 66);
            this.grdOwners.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grdOwners.MultiSelect = true;
            this.grdOwners.Name = "grdOwners";
            this.grdOwners.ShowNavigator = true;
            this.grdOwners.ShowToolbar = true;
            this.grdOwners.Size = new System.Drawing.Size(681, 215);
            this.grdOwners.TabIndex = 2;
            this.grdOwners.OnRowDBClick += new ClassLibrary.JJanusGrid.RowDBClick(this.grdOwners_OnRowDBClick);
            this.grdOwners.Load += new System.EventHandler(this.jJanusGridOwner_Load);
            // 
            // btnDeActiveOw
            // 
            this.btnDeActiveOw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeActiveOw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeActiveOw.Location = new System.Drawing.Point(508, 256);
            this.btnDeActiveOw.Name = "btnDeActiveOw";
            this.btnDeActiveOw.Size = new System.Drawing.Size(75, 23);
            this.btnDeActiveOw.TabIndex = 2;
            this.btnDeActiveOw.Text = "Delete";
            this.btnDeActiveOw.UseVisualStyleBackColor = true;
            this.btnDeActiveOw.Click += new System.EventHandler(this.btnDeActiveOw_Click);
            // 
            // btnEditOwner
            // 
            this.btnEditOwner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditOwner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditOwner.Location = new System.Drawing.Point(589, 256);
            this.btnEditOwner.Name = "btnEditOwner";
            this.btnEditOwner.Size = new System.Drawing.Size(75, 23);
            this.btnEditOwner.TabIndex = 1;
            this.btnEditOwner.Text = "Edit";
            this.btnEditOwner.UseVisualStyleBackColor = true;
            this.btnEditOwner.Click += new System.EventHandler(this.btnActiveOw_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtBCode);
            this.tabPage1.Controls.Add(this.txtPlak3);
            this.tabPage1.Controls.Add(this.txtPlak1);
            this.tabPage1.Controls.Add(this.txtPlak2);
            this.tabPage1.Controls.Add(this.btnProperties);
            this.tabPage1.Controls.Add(this.jPropertyValue);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.cmbPlak);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.cmbFleet);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.checkedActive);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(687, 284);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Bus";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(590, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 350;
            this.label2.Text = "BusNumber:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(627, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 350;
            this.label1.Text = "Fleet:";
            // 
            // checkedActive
            // 
            this.checkedActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedActive.AutoSize = true;
            this.checkedActive.Checked = true;
            this.checkedActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkedActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkedActive.Location = new System.Drawing.Point(511, 122);
            this.checkedActive.Name = "checkedActive";
            this.checkedActive.Size = new System.Drawing.Size(58, 20);
            this.checkedActive.TabIndex = 353;
            this.checkedActive.Text = "Active";
            this.checkedActive.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(617, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 16);
            this.label6.TabIndex = 354;
            this.label6.Text = "Plaque:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(362, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbFleet
            // 
            this.cmbFleet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFleet.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbFleet.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFleet.BaseCode = 0;
            this.cmbFleet.ChangeColorIfNotEmpty = true;
            this.cmbFleet.ChangeColorOnEnter = true;
            this.cmbFleet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFleet.FormattingEnabled = true;
            this.cmbFleet.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbFleet.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbFleet.Location = new System.Drawing.Point(412, 92);
            this.cmbFleet.Name = "cmbFleet";
            this.cmbFleet.NotEmpty = false;
            this.cmbFleet.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbFleet.SelectOnEnter = true;
            this.cmbFleet.Size = new System.Drawing.Size(157, 24);
            this.cmbFleet.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(526, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 16);
            this.label10.TabIndex = 366;
            this.label10.Text = "-";
            // 
            // cmbPlak
            // 
            this.cmbPlak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPlak.DisplayMember = "21";
            this.cmbPlak.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlak.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbPlak.FormattingEnabled = true;
            this.cmbPlak.Items.AddRange(new object[] {
            "الف",
            "ب",
            "پ",
            "ت",
            "ث",
            "ج",
            "چ",
            "ح",
            "خ",
            "د",
            "ذ",
            "ر",
            "ز",
            "ژ",
            "س",
            "ش",
            "ص",
            "ض",
            "ط",
            "ظ",
            "ع",
            "غ",
            "ف",
            "ق",
            "ک",
            "گ",
            "ل",
            "م",
            "ن",
            "و",
            "ه",
            "ی"});
            this.cmbPlak.Location = new System.Drawing.Point(436, 30);
            this.cmbPlak.Name = "cmbPlak";
            this.cmbPlak.Size = new System.Drawing.Size(46, 24);
            this.cmbPlak.TabIndex = 2;
            this.cmbPlak.ValueMember = "21";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(573, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 367;
            this.label5.Text = "ایران";
            // 
            // jPropertyValue
            // 
            this.jPropertyValue.AutoScroll = true;
            this.jPropertyValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jPropertyValue.ClassName = null;
            this.jPropertyValue.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.jPropertyValue.Location = new System.Drawing.Point(3, 143);
            this.jPropertyValue.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.jPropertyValue.Name = "jPropertyValue";
            this.jPropertyValue.ObjectCode = -1;
            this.jPropertyValue.Size = new System.Drawing.Size(681, 138);
            this.jPropertyValue.TabIndex = 8;
            this.jPropertyValue.ValueObjectCode = 0;
            // 
            // btnProperties
            // 
            this.btnProperties.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProperties.Location = new System.Drawing.Point(6, 111);
            this.btnProperties.Name = "btnProperties";
            this.btnProperties.Size = new System.Drawing.Size(136, 23);
            this.btnProperties.TabIndex = 7;
            this.btnProperties.Text = "EditProperties";
            this.btnProperties.UseVisualStyleBackColor = true;
            this.btnProperties.Click += new System.EventHandler(this.btnProperties_Click);
            // 
            // txtPlak2
            // 
            this.txtPlak2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlak2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPlak2.Location = new System.Drawing.Point(486, 30);
            this.txtPlak2.MaxLength = 3;
            this.txtPlak2.Name = "txtPlak2";
            this.txtPlak2.Size = new System.Drawing.Size(36, 23);
            this.txtPlak2.TabIndex = 1;
            this.txtPlak2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPlak1
            // 
            this.txtPlak1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlak1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPlak1.Location = new System.Drawing.Point(399, 30);
            this.txtPlak1.MaxLength = 2;
            this.txtPlak1.Name = "txtPlak1";
            this.txtPlak1.Size = new System.Drawing.Size(31, 23);
            this.txtPlak1.TabIndex = 3;
            this.txtPlak1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPlak3
            // 
            this.txtPlak3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlak3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPlak3.Location = new System.Drawing.Point(540, 30);
            this.txtPlak3.MaxLength = 2;
            this.txtPlak3.Name = "txtPlak3";
            this.txtPlak3.Size = new System.Drawing.Size(29, 23);
            this.txtPlak3.TabIndex = 0;
            this.txtPlak3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBCode
            // 
            this.txtBCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBCode.ChangeColorIfNotEmpty = false;
            this.txtBCode.ChangeColorOnEnter = true;
            this.txtBCode.InBackColor = System.Drawing.SystemColors.Info;
            this.txtBCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBCode.Location = new System.Drawing.Point(412, 63);
            this.txtBCode.Name = "txtBCode";
            this.txtBCode.Negative = true;
            this.txtBCode.NotEmpty = false;
            this.txtBCode.NotEmptyColor = System.Drawing.Color.Red;
            this.txtBCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBCode.SelectOnEnter = true;
            this.txtBCode.Size = new System.Drawing.Size(157, 23);
            this.txtBCode.TabIndex = 5;
            this.txtBCode.TextMode = ClassLibrary.TextModes.Real;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(110, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(695, 322);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // JBusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 358);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.KeyPreview = false;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JBusForm";
            this.Text = "BusForm";
            this.Load += new System.EventHandler(this.BusForm_Load);
            this.panel1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnReload;
        private ClassLibrary.DateEdit dateEdit1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnEditDevice;
        private System.Windows.Forms.Button btnDeActiveDev;
        private ClassLibrary.JJanusGrid grdDevice;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAddInstaller;
        private System.Windows.Forms.TextBox txtInstaller;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnAddDevice;
        private System.Windows.Forms.Button btnSearchDevice;
        private System.Windows.Forms.TextBox txtBusDevise;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private ClassLibrary.DateEdit txtEndDateDevise;
        private ClassLibrary.DateEdit txtStartDateDevise;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnEditOwner;
        private System.Windows.Forms.Button btnDeActiveOw;
        private ClassLibrary.JJanusGrid grdOwners;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox chActive;
        private System.Windows.Forms.Button btnAddOwner;
        private System.Windows.Forms.Button btnSearchOwner;
        private System.Windows.Forms.TextBox txtPerson;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private ClassLibrary.DateEdit txtOwEndDate;
        private ClassLibrary.DateEdit txtOwStartDate;
        private System.Windows.Forms.TabPage tabPage1;
        private ClassLibrary.TextEdit txtBCode;
        private System.Windows.Forms.TextBox txtPlak3;
        private System.Windows.Forms.TextBox txtPlak1;
        private System.Windows.Forms.TextBox txtPlak2;
        private System.Windows.Forms.Button btnProperties;
        private Globals.Property.JPropertyValueUserControl jPropertyValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbPlak;
        private System.Windows.Forms.Label label10;
        private ClassLibrary.JComboBox cmbFleet;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkedActive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
    }
}