namespace BusManagment.Line
{
    partial class FormLine
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtLineName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.JCmbZoneCode = new ClassLibrary.JComboBox(this.components);
            this.JcmbFleet = new ClassLibrary.JComboBox(this.components);
            this.checkState = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.JcmbLineType = new ClassLibrary.JComboBox(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtLineNumber = new ClassLibrary.TextEdit(this.components);
            this.checkRotate = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lstBackStations = new System.Windows.Forms.ListView();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtBackStation = new ClassLibrary.TextEdit(this.components);
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lstStations = new System.Windows.Forms.ListView();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSearchStation = new System.Windows.Forms.Button();
            this.txtStation = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnActivePath = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnEditPrice = new System.Windows.Forms.Button();
            this.btnDelPrice = new System.Windows.Forms.Button();
            this.grdPrices = new ClassLibrary.JJanusGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtPrice = new ClassLibrary.TextEdit(this.components);
            this.btnActPrice = new System.Windows.Forms.Button();
            this.txtEndTimePrice = new ClassLibrary.TimeEdit(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.txtStartTimePrice = new ClassLibrary.TimeEdit(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEndDatePrice = new ClassLibrary.DateEdit(this.components);
            this.txtStartDatePrice = new ClassLibrary.DateEdit(this.components);
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.mapLinePath = new GMap.NET.WindowsForms.GMapControl();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnInsertPoint = new System.Windows.Forms.Button();
            this.btnDeletePoint = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(677, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "LineName:";
            // 
            // txtLineName
            // 
            this.txtLineName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLineName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLineName.Location = new System.Drawing.Point(471, 26);
            this.txtLineName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLineName.Name = "txtLineName";
            this.txtLineName.Size = new System.Drawing.Size(181, 23);
            this.txtLineName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(665, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "LineNumber:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(705, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Fleet:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(682, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "LineType:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(699, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Active:";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(654, 8);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(110, 32);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Location = new System.Drawing.Point(538, 8);
            this.btnApply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(110, 32);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Visible = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(12, 8);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 32);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // JCmbZoneCode
            // 
            this.JCmbZoneCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.JCmbZoneCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.JCmbZoneCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.JCmbZoneCode.BaseCode = 0;
            this.JCmbZoneCode.ChangeColorIfNotEmpty = true;
            this.JCmbZoneCode.ChangeColorOnEnter = true;
            this.JCmbZoneCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.JCmbZoneCode.FormattingEnabled = true;
            this.JCmbZoneCode.InBackColor = System.Drawing.SystemColors.Info;
            this.JCmbZoneCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.JCmbZoneCode.Location = new System.Drawing.Point(376, 87);
            this.JCmbZoneCode.Name = "JCmbZoneCode";
            this.JCmbZoneCode.NotEmpty = false;
            this.JCmbZoneCode.NotEmptyColor = System.Drawing.Color.Red;
            this.JCmbZoneCode.SelectOnEnter = true;
            this.JCmbZoneCode.Size = new System.Drawing.Size(276, 24);
            this.JCmbZoneCode.TabIndex = 2;
            // 
            // JcmbFleet
            // 
            this.JcmbFleet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.JcmbFleet.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.JcmbFleet.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.JcmbFleet.BaseCode = 0;
            this.JcmbFleet.ChangeColorIfNotEmpty = true;
            this.JcmbFleet.ChangeColorOnEnter = true;
            this.JcmbFleet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.JcmbFleet.FormattingEnabled = true;
            this.JcmbFleet.InBackColor = System.Drawing.SystemColors.Info;
            this.JcmbFleet.InForeColor = System.Drawing.SystemColors.WindowText;
            this.JcmbFleet.Location = new System.Drawing.Point(376, 117);
            this.JcmbFleet.Name = "JcmbFleet";
            this.JcmbFleet.NotEmpty = false;
            this.JcmbFleet.NotEmptyColor = System.Drawing.Color.Red;
            this.JcmbFleet.SelectOnEnter = true;
            this.JcmbFleet.Size = new System.Drawing.Size(276, 24);
            this.JcmbFleet.TabIndex = 3;
            // 
            // checkState
            // 
            this.checkState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkState.AutoSize = true;
            this.checkState.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkState.Location = new System.Drawing.Point(640, 176);
            this.checkState.Name = "checkState";
            this.checkState.Size = new System.Drawing.Size(12, 11);
            this.checkState.TabIndex = 5;
            this.checkState.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(705, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Zone:";
            // 
            // JcmbLineType
            // 
            this.JcmbLineType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.JcmbLineType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.JcmbLineType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.JcmbLineType.BaseCode = 0;
            this.JcmbLineType.ChangeColorIfNotEmpty = true;
            this.JcmbLineType.ChangeColorOnEnter = true;
            this.JcmbLineType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.JcmbLineType.FormattingEnabled = true;
            this.JcmbLineType.InBackColor = System.Drawing.SystemColors.Info;
            this.JcmbLineType.InForeColor = System.Drawing.SystemColors.WindowText;
            this.JcmbLineType.Location = new System.Drawing.Point(376, 147);
            this.JcmbLineType.Name = "JcmbLineType";
            this.JcmbLineType.NotEmpty = false;
            this.JcmbLineType.NotEmptyColor = System.Drawing.Color.Red;
            this.JcmbLineType.SelectOnEnter = true;
            this.JcmbLineType.Size = new System.Drawing.Size(276, 24);
            this.JcmbLineType.TabIndex = 4;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage5);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.ItemSize = new System.Drawing.Size(110, 30);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.RightToLeftLayout = true;
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(771, 391);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtLineNumber);
            this.tabPage1.Controls.Add(this.txtLineName);
            this.tabPage1.Controls.Add(this.checkRotate);
            this.tabPage1.Controls.Add(this.checkState);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.JcmbLineType);
            this.tabPage1.Controls.Add(this.JcmbFleet);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.JCmbZoneCode);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(763, 353);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Line";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtLineNumber
            // 
            this.txtLineNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLineNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLineNumber.ChangeColorIfNotEmpty = false;
            this.txtLineNumber.ChangeColorOnEnter = true;
            this.txtLineNumber.InBackColor = System.Drawing.SystemColors.Info;
            this.txtLineNumber.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLineNumber.Location = new System.Drawing.Point(471, 56);
            this.txtLineNumber.Name = "txtLineNumber";
            this.txtLineNumber.Negative = true;
            this.txtLineNumber.NotEmpty = false;
            this.txtLineNumber.NotEmptyColor = System.Drawing.Color.Red;
            this.txtLineNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLineNumber.SelectOnEnter = true;
            this.txtLineNumber.Size = new System.Drawing.Size(181, 23);
            this.txtLineNumber.TabIndex = 1;
            this.txtLineNumber.TextMode = ClassLibrary.TextModes.Real;
            // 
            // checkRotate
            // 
            this.checkRotate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkRotate.AutoSize = true;
            this.checkRotate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkRotate.Location = new System.Drawing.Point(640, 202);
            this.checkRotate.Name = "checkRotate";
            this.checkRotate.Size = new System.Drawing.Size(12, 11);
            this.checkRotate.TabIndex = 6;
            this.checkRotate.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(696, 200);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 16);
            this.label8.TabIndex = 9;
            this.label8.Text = "Rotate:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(763, 354);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Path";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pictureBox6);
            this.panel4.Controls.Add(this.pictureBox5);
            this.panel4.Controls.Add(this.pictureBox4);
            this.panel4.Controls.Add(this.lstBackStations);
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.txtBackStation);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(339, 348);
            this.panel4.TabIndex = 8;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::BusManagment.Properties.Resources.Trash;
            this.pictureBox6.Location = new System.Drawing.Point(46, 79);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(16, 16);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox6.TabIndex = 8;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::BusManagment.Properties.Resources.Down;
            this.pictureBox5.Location = new System.Drawing.Point(24, 79);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(16, 16);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox5.TabIndex = 7;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::BusManagment.Properties.Resources.up;
            this.pictureBox4.Location = new System.Drawing.Point(5, 79);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(16, 16);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // lstBackStations
            // 
            this.lstBackStations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstBackStations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstBackStations.Location = new System.Drawing.Point(0, 96);
            this.lstBackStations.MultiSelect = false;
            this.lstBackStations.Name = "lstBackStations";
            this.lstBackStations.RightToLeftLayout = true;
            this.lstBackStations.Size = new System.Drawing.Size(339, 252);
            this.lstBackStations.TabIndex = 5;
            this.lstBackStations.UseCompatibleStateImageBehavior = false;
            this.lstBackStations.View = System.Windows.Forms.View.List;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(2, 50);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(54, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(59, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtBackStation
            // 
            this.txtBackStation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBackStation.ChangeColorIfNotEmpty = false;
            this.txtBackStation.ChangeColorOnEnter = true;
            this.txtBackStation.InBackColor = System.Drawing.SystemColors.Info;
            this.txtBackStation.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBackStation.Location = new System.Drawing.Point(94, 50);
            this.txtBackStation.Name = "txtBackStation";
            this.txtBackStation.Negative = true;
            this.txtBackStation.NotEmpty = false;
            this.txtBackStation.NotEmptyColor = System.Drawing.Color.Red;
            this.txtBackStation.ReadOnly = true;
            this.txtBackStation.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBackStation.SelectOnEnter = true;
            this.txtBackStation.Size = new System.Drawing.Size(238, 23);
            this.txtBackStation.TabIndex = 2;
            this.txtBackStation.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(283, 34);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 16);
            this.label16.TabIndex = 1;
            this.label16.Text = "Station:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label15.Location = new System.Drawing.Point(234, 4);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(102, 16);
            this.label15.TabIndex = 0;
            this.label15.Text = "Back on Track:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.lstStations);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.btnSearchStation);
            this.panel3.Controls.Add(this.txtStation);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.btnActivePath);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(423, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(337, 348);
            this.panel3.TabIndex = 7;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::BusManagment.Properties.Resources.Trash;
            this.pictureBox3.Location = new System.Drawing.Point(42, 79);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 16);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BusManagment.Properties.Resources.Down;
            this.pictureBox2.Location = new System.Drawing.Point(23, 79);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BusManagment.Properties.Resources.up;
            this.pictureBox1.Location = new System.Drawing.Point(4, 79);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lstStations
            // 
            this.lstStations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstStations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstStations.Location = new System.Drawing.Point(0, 96);
            this.lstStations.MultiSelect = false;
            this.lstStations.Name = "lstStations";
            this.lstStations.RightToLeftLayout = true;
            this.lstStations.Size = new System.Drawing.Size(337, 252);
            this.lstStations.TabIndex = 11;
            this.lstStations.UseCompatibleStateImageBehavior = false;
            this.lstStations.View = System.Windows.Forms.View.List;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.Location = new System.Drawing.Point(247, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Go On Track:";
            // 
            // btnSearchStation
            // 
            this.btnSearchStation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchStation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchStation.Location = new System.Drawing.Point(62, 50);
            this.btnSearchStation.Name = "btnSearchStation";
            this.btnSearchStation.Size = new System.Drawing.Size(28, 23);
            this.btnSearchStation.TabIndex = 9;
            this.btnSearchStation.Text = "...";
            this.btnSearchStation.UseVisualStyleBackColor = true;
            this.btnSearchStation.Click += new System.EventHandler(this.btnSearchStation_Click);
            // 
            // txtStation
            // 
            this.txtStation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStation.Location = new System.Drawing.Point(96, 50);
            this.txtStation.Name = "txtStation";
            this.txtStation.ReadOnly = true;
            this.txtStation.Size = new System.Drawing.Size(238, 23);
            this.txtStation.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(281, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 16);
            this.label11.TabIndex = 5;
            this.label11.Text = "Station:";
            // 
            // btnActivePath
            // 
            this.btnActivePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActivePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivePath.Location = new System.Drawing.Point(3, 50);
            this.btnActivePath.Name = "btnActivePath";
            this.btnActivePath.Size = new System.Drawing.Size(54, 23);
            this.btnActivePath.TabIndex = 3;
            this.btnActivePath.Text = "Add";
            this.btnActivePath.UseVisualStyleBackColor = true;
            this.btnActivePath.Click += new System.EventHandler(this.btnActivePath_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnEditPrice);
            this.tabPage3.Controls.Add(this.btnDelPrice);
            this.tabPage3.Controls.Add(this.grdPrices);
            this.tabPage3.Controls.Add(this.panel2);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(763, 354);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Price";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnEditPrice
            // 
            this.btnEditPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditPrice.Location = new System.Drawing.Point(651, 325);
            this.btnEditPrice.Name = "btnEditPrice";
            this.btnEditPrice.Size = new System.Drawing.Size(75, 23);
            this.btnEditPrice.TabIndex = 3;
            this.btnEditPrice.Text = "Edit";
            this.btnEditPrice.UseVisualStyleBackColor = true;
            this.btnEditPrice.Click += new System.EventHandler(this.btnEditOwner_Click);
            // 
            // btnDelPrice
            // 
            this.btnDelPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelPrice.Location = new System.Drawing.Point(570, 325);
            this.btnDelPrice.Name = "btnDelPrice";
            this.btnDelPrice.Size = new System.Drawing.Size(75, 23);
            this.btnDelPrice.TabIndex = 4;
            this.btnDelPrice.Text = "Delete";
            this.btnDelPrice.UseVisualStyleBackColor = true;
            this.btnDelPrice.Click += new System.EventHandler(this.btnDelPrice_Click);
            // 
            // grdPrices
            // 
            this.grdPrices.ActionClassName = "";
            this.grdPrices.ActionMenu = null;
            this.grdPrices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grdPrices.DataSource = null;
            this.grdPrices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPrices.Edited = false;
            this.grdPrices.Location = new System.Drawing.Point(3, 65);
            this.grdPrices.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdPrices.MultiSelect = false;
            this.grdPrices.Name = "grdPrices";
            this.grdPrices.ShowNavigator = true;
            this.grdPrices.ShowToolbar = true;
            this.grdPrices.Size = new System.Drawing.Size(757, 286);
            this.grdPrices.TabIndex = 1;
            this.grdPrices.OnRowDBClick += new ClassLibrary.JJanusGrid.RowDBClick(this.grdPrices_OnRowDBClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtPrice);
            this.panel2.Controls.Add(this.btnActPrice);
            this.panel2.Controls.Add(this.txtEndTimePrice);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.txtStartTimePrice);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtEndDatePrice);
            this.panel2.Controls.Add(this.txtStartDatePrice);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(757, 62);
            this.panel2.TabIndex = 0;
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrice.ChangeColorIfNotEmpty = false;
            this.txtPrice.ChangeColorOnEnter = true;
            this.txtPrice.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPrice.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPrice.Location = new System.Drawing.Point(612, 25);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Negative = true;
            this.txtPrice.NotEmpty = false;
            this.txtPrice.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrice.SelectOnEnter = true;
            this.txtPrice.Size = new System.Drawing.Size(131, 23);
            this.txtPrice.TabIndex = 0;
            this.txtPrice.TextMode = ClassLibrary.TextModes.Money;
            // 
            // btnActPrice
            // 
            this.btnActPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActPrice.Location = new System.Drawing.Point(162, 23);
            this.btnActPrice.Name = "btnActPrice";
            this.btnActPrice.Size = new System.Drawing.Size(75, 27);
            this.btnActPrice.TabIndex = 5;
            this.btnActPrice.Text = "Add";
            this.btnActPrice.UseVisualStyleBackColor = true;
            this.btnActPrice.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtEndTimePrice
            // 
            this.txtEndTimePrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEndTimePrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEndTimePrice.ChangeColorIfNotEmpty = true;
            this.txtEndTimePrice.ChangeColorOnEnter = true;
            this.txtEndTimePrice.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtEndTimePrice.InBackColor = System.Drawing.SystemColors.Info;
            this.txtEndTimePrice.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEndTimePrice.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtEndTimePrice.Location = new System.Drawing.Point(243, 23);
            this.txtEndTimePrice.Mask = "00:00";
            this.txtEndTimePrice.Name = "txtEndTimePrice";
            this.txtEndTimePrice.NotEmpty = false;
            this.txtEndTimePrice.NotEmptyColor = System.Drawing.Color.Red;
            this.txtEndTimePrice.Size = new System.Drawing.Size(76, 27);
            this.txtEndTimePrice.TabIndex = 4;
            this.txtEndTimePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEndTimePrice.ValidatingType = typeof(System.DateTime);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(710, 6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 16);
            this.label14.TabIndex = 14;
            this.label14.Text = "Price";
            // 
            // txtStartTimePrice
            // 
            this.txtStartTimePrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartTimePrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStartTimePrice.ChangeColorIfNotEmpty = true;
            this.txtStartTimePrice.ChangeColorOnEnter = true;
            this.txtStartTimePrice.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtStartTimePrice.InBackColor = System.Drawing.SystemColors.Info;
            this.txtStartTimePrice.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtStartTimePrice.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtStartTimePrice.Location = new System.Drawing.Point(325, 23);
            this.txtStartTimePrice.Mask = "00:00";
            this.txtStartTimePrice.Name = "txtStartTimePrice";
            this.txtStartTimePrice.NotEmpty = false;
            this.txtStartTimePrice.NotEmptyColor = System.Drawing.Color.Red;
            this.txtStartTimePrice.Size = new System.Drawing.Size(76, 27);
            this.txtStartTimePrice.TabIndex = 3;
            this.txtStartTimePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtStartTimePrice.ValidatingType = typeof(System.DateTime);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(547, 4);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 16);
            this.label13.TabIndex = 17;
            this.label13.Text = "StartDate";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(260, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 16);
            this.label9.TabIndex = 23;
            this.label9.Text = "EndTime";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(453, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 16);
            this.label12.TabIndex = 18;
            this.label12.Text = "EndDate";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(335, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 16);
            this.label10.TabIndex = 22;
            this.label10.Text = "StartTime";
            // 
            // txtEndDatePrice
            // 
            this.txtEndDatePrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEndDatePrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEndDatePrice.ChangeColorIfNotEmpty = true;
            this.txtEndDatePrice.ChangeColorOnEnter = true;
            this.txtEndDatePrice.Date = new System.DateTime(((long)(0)));
            this.txtEndDatePrice.InBackColor = System.Drawing.SystemColors.Info;
            this.txtEndDatePrice.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEndDatePrice.InsertInDatesTable = true;
            this.txtEndDatePrice.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtEndDatePrice.Location = new System.Drawing.Point(410, 25);
            this.txtEndDatePrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEndDatePrice.Mask = "0000/00/00";
            this.txtEndDatePrice.Name = "txtEndDatePrice";
            this.txtEndDatePrice.NotEmpty = false;
            this.txtEndDatePrice.NotEmptyColor = System.Drawing.Color.Red;
            this.txtEndDatePrice.Size = new System.Drawing.Size(95, 23);
            this.txtEndDatePrice.TabIndex = 2;
            // 
            // txtStartDatePrice
            // 
            this.txtStartDatePrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartDatePrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStartDatePrice.ChangeColorIfNotEmpty = true;
            this.txtStartDatePrice.ChangeColorOnEnter = true;
            this.txtStartDatePrice.Date = new System.DateTime(((long)(0)));
            this.txtStartDatePrice.InBackColor = System.Drawing.SystemColors.Info;
            this.txtStartDatePrice.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtStartDatePrice.InsertInDatesTable = true;
            this.txtStartDatePrice.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtStartDatePrice.Location = new System.Drawing.Point(511, 25);
            this.txtStartDatePrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtStartDatePrice.Mask = "0000/00/00";
            this.txtStartDatePrice.Name = "txtStartDatePrice";
            this.txtStartDatePrice.NotEmpty = false;
            this.txtStartDatePrice.NotEmptyColor = System.Drawing.Color.Red;
            this.txtStartDatePrice.Size = new System.Drawing.Size(95, 23);
            this.txtStartDatePrice.TabIndex = 1;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.mapLinePath);
            this.tabPage5.Controls.Add(this.panel5);
            this.tabPage5.Location = new System.Drawing.Point(4, 34);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(763, 354);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "LinePath";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // mapLinePath
            // 
            this.mapLinePath.Bearing = 0F;
            this.mapLinePath.CanDragMap = true;
            this.mapLinePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapLinePath.EmptyTileColor = System.Drawing.Color.Navy;
            this.mapLinePath.GrayScaleMode = false;
            this.mapLinePath.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.mapLinePath.LevelsKeepInMemmory = 5;
            this.mapLinePath.Location = new System.Drawing.Point(3, 3);
            this.mapLinePath.MarkersEnabled = true;
            this.mapLinePath.MaxZoom = 2;
            this.mapLinePath.MinZoom = 2;
            this.mapLinePath.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.mapLinePath.Name = "mapLinePath";
            this.mapLinePath.NegativeMode = false;
            this.mapLinePath.PolygonsEnabled = true;
            this.mapLinePath.RetryLoadTile = 0;
            this.mapLinePath.RoutesEnabled = true;
            this.mapLinePath.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.mapLinePath.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.mapLinePath.ShowTileGridLines = false;
            this.mapLinePath.Size = new System.Drawing.Size(658, 348);
            this.mapLinePath.TabIndex = 3;
            this.mapLinePath.Zoom = 0D;
            this.mapLinePath.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.mapLinePath_OnMarkerClick);
            this.mapLinePath.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapLinePath_MouseMove);
            this.mapLinePath.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mapLinePath_MouseUp);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnInsertPoint);
            this.panel5.Controls.Add(this.btnDeletePoint);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(661, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(99, 348);
            this.panel5.TabIndex = 2;
            // 
            // btnInsertPoint
            // 
            this.btnInsertPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsertPoint.Location = new System.Drawing.Point(6, 45);
            this.btnInsertPoint.Name = "btnInsertPoint";
            this.btnInsertPoint.Size = new System.Drawing.Size(87, 64);
            this.btnInsertPoint.TabIndex = 1;
            this.btnInsertPoint.Text = "افزودن نقطه ...";
            this.btnInsertPoint.UseVisualStyleBackColor = true;
            // 
            // btnDeletePoint
            // 
            this.btnDeletePoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletePoint.Location = new System.Drawing.Point(6, 12);
            this.btnDeletePoint.Name = "btnDeletePoint";
            this.btnDeletePoint.Size = new System.Drawing.Size(87, 27);
            this.btnDeletePoint.TabIndex = 0;
            this.btnDeletePoint.Text = "حذف نقطه";
            this.btnDeletePoint.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.gMapControl1);
            this.tabPage4.Location = new System.Drawing.Point(4, 34);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(763, 354);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Map";
            this.tabPage4.UseVisualStyleBackColor = true;
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
            this.gMapControl1.Size = new System.Drawing.Size(757, 348);
            this.gMapControl1.TabIndex = 0;
            this.gMapControl1.Zoom = 0D;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 391);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(771, 50);
            this.panel1.TabIndex = 1;
            // 
            // FormLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 441);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormLine";
            this.Text = "Line";
            this.Load += new System.EventHandler(this.FormLine_Load_1);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLineName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnClose;
        private ClassLibrary.JComboBox JCmbZoneCode;
        private ClassLibrary.JComboBox JcmbFleet;
        private System.Windows.Forms.CheckBox checkState;
        private System.Windows.Forms.Label label6;
        private ClassLibrary.JComboBox JcmbLineType;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSearchStation;
        private System.Windows.Forms.TextBox txtStation;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnActivePath;
        private System.Windows.Forms.CheckBox checkRotate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel2;
        private ClassLibrary.TimeEdit txtEndTimePrice;
        private System.Windows.Forms.Label label14;
        private ClassLibrary.TimeEdit txtStartTimePrice;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private ClassLibrary.DateEdit txtEndDatePrice;
        private ClassLibrary.DateEdit txtStartDatePrice;
        private ClassLibrary.JJanusGrid grdPrices;
        private System.Windows.Forms.Button btnActPrice;
        private System.Windows.Forms.TabPage tabPage4;
        private ClassLibrary.TextEdit txtPrice;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private ClassLibrary.TextEdit txtBackStation;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView lstStations;
        private System.Windows.Forms.ListView lstBackStations;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.TabPage tabPage5;
        private GMap.NET.WindowsForms.GMapControl mapLinePath;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnDeletePoint;
        private System.Windows.Forms.Button btnInsertPoint;
        private System.Windows.Forms.Button btnEditPrice;
        private System.Windows.Forms.Button btnDelPrice;
        private ClassLibrary.TextEdit txtLineNumber;

    }
}