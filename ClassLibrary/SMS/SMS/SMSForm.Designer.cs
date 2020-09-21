namespace ClassLibrary.SMS
{
    partial class SMSForm
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
            ClassLibrary.JPopupMenu jPopupMenu4 = new ClassLibrary.JPopupMenu();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMSForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpInfo = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblStatusMonth = new System.Windows.Forms.Label();
            this.lblStatusDay = new System.Windows.Forms.Label();
            this.lblTotalSMSxRecievers = new System.Windows.Forms.Label();
            this.lblSpacesAfter = new System.Windows.Forms.Label();
            this.lblSpacesBefore = new System.Windows.Forms.Label();
            this.lblTotalSMS = new System.Windows.Forms.Label();
            this.lblSMSChars = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlLetterInfo = new System.Windows.Forms.Panel();
            this.dgrMobiles = new ClassLibrary.JDataGrid();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSentList = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.btnAddNonPerson = new System.Windows.Forms.Button();
            this.btnDeleteFromGroup = new System.Windows.Forms.Button();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.refersText1 = new Automation.RefersText();
            this.tbpRefer = new System.Windows.Forms.TabPage();
            this.jRefersTextRTB1 = new Automation.Refer.JRefersTextRTB();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRefer = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tbpInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.pnlLetterInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrMobiles)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tbpRefer.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbpInfo);
            this.tabControl1.Controls.Add(this.tbpRefer);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.ItemSize = new System.Drawing.Size(150, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(929, 615);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 2;
            // 
            // tbpInfo
            // 
            this.tbpInfo.BackColor = System.Drawing.Color.Transparent;
            this.tbpInfo.Controls.Add(this.panel1);
            this.tbpInfo.Controls.Add(this.splitter1);
            this.tbpInfo.Controls.Add(this.pnlLetterInfo);
            this.tbpInfo.Controls.Add(this.refersText1);
            this.tbpInfo.ImageKey = "info_s24.png";
            this.tbpInfo.Location = new System.Drawing.Point(4, 34);
            this.tbpInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbpInfo.Name = "tbpInfo";
            this.tbpInfo.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbpInfo.Size = new System.Drawing.Size(921, 577);
            this.tbpInfo.TabIndex = 0;
            this.tbpInfo.Text = "اطلاعات SMS";
            this.tbpInfo.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtContent);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(423, 415);
            this.panel1.TabIndex = 85;
            // 
            // txtContent
            // 
            this.txtContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContent.Font = new System.Drawing.Font("B Nazanin", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtContent.Location = new System.Drawing.Point(0, 0);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(423, 279);
            this.txtContent.TabIndex = 86;
            this.txtContent.TextChanged += new System.EventHandler(this.txtContent_TextChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblStatusMonth);
            this.panel5.Controls.Add(this.lblStatusDay);
            this.panel5.Controls.Add(this.lblTotalSMSxRecievers);
            this.panel5.Controls.Add(this.lblSpacesAfter);
            this.panel5.Controls.Add(this.lblSpacesBefore);
            this.panel5.Controls.Add(this.lblTotalSMS);
            this.panel5.Controls.Add(this.lblSMSChars);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 279);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(423, 136);
            this.panel5.TabIndex = 87;
            // 
            // lblStatusMonth
            // 
            this.lblStatusMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatusMonth.Location = new System.Drawing.Point(13, 114);
            this.lblStatusMonth.Name = "lblStatusMonth";
            this.lblStatusMonth.Size = new System.Drawing.Size(404, 18);
            this.lblStatusMonth.TabIndex = 6;
            this.lblStatusMonth.Text = "تعداد SMSهای ارسال شده این ماه: 0 عدد";
            this.lblStatusMonth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatusDay
            // 
            this.lblStatusDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatusDay.Location = new System.Drawing.Point(13, 96);
            this.lblStatusDay.Name = "lblStatusDay";
            this.lblStatusDay.Size = new System.Drawing.Size(404, 18);
            this.lblStatusDay.TabIndex = 5;
            this.lblStatusDay.Text = "تعداد SMS های ارسال شده امروز: 0 عدد";
            this.lblStatusDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalSMSxRecievers
            // 
            this.lblTotalSMSxRecievers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalSMSxRecievers.Location = new System.Drawing.Point(13, 41);
            this.lblTotalSMSxRecievers.Name = "lblTotalSMSxRecievers";
            this.lblTotalSMSxRecievers.Size = new System.Drawing.Size(404, 18);
            this.lblTotalSMSxRecievers.TabIndex = 4;
            this.lblTotalSMSxRecievers.Text = "تعداد SMSها در گیرندگان: 0 عدد";
            this.lblTotalSMSxRecievers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSpacesAfter
            // 
            this.lblSpacesAfter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSpacesAfter.Location = new System.Drawing.Point(14, 77);
            this.lblSpacesAfter.Name = "lblSpacesAfter";
            this.lblSpacesAfter.Size = new System.Drawing.Size(404, 18);
            this.lblSpacesAfter.TabIndex = 3;
            this.lblSpacesAfter.Text = "تعداد فاصله ها بعد از متن: 0 عدد";
            this.lblSpacesAfter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSpacesBefore
            // 
            this.lblSpacesBefore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSpacesBefore.Location = new System.Drawing.Point(14, 59);
            this.lblSpacesBefore.Name = "lblSpacesBefore";
            this.lblSpacesBefore.Size = new System.Drawing.Size(404, 18);
            this.lblSpacesBefore.TabIndex = 2;
            this.lblSpacesBefore.Text = "تعداد فاصله ها قبل از متن: 0 عدد";
            this.lblSpacesBefore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalSMS
            // 
            this.lblTotalSMS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalSMS.Location = new System.Drawing.Point(13, 23);
            this.lblTotalSMS.Name = "lblTotalSMS";
            this.lblTotalSMS.Size = new System.Drawing.Size(404, 18);
            this.lblTotalSMS.TabIndex = 1;
            this.lblTotalSMS.Text = "تعداد SMSها: 1 عدد";
            this.lblTotalSMS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSMSChars
            // 
            this.lblSMSChars.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSMSChars.Location = new System.Drawing.Point(13, 3);
            this.lblSMSChars.Name = "lblSMSChars";
            this.lblSMSChars.Size = new System.Drawing.Size(404, 18);
            this.lblSMSChars.TabIndex = 0;
            this.lblSMSChars.Text = "تعداد کاراکتر: 0 از 70";
            this.lblSMSChars.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(426, 4);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1, 415);
            this.splitter1.TabIndex = 46;
            this.splitter1.TabStop = false;
            // 
            // pnlLetterInfo
            // 
            this.pnlLetterInfo.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlLetterInfo.Controls.Add(this.dgrMobiles);
            this.pnlLetterInfo.Controls.Add(this.panel4);
            this.pnlLetterInfo.Controls.Add(this.panel3);
            this.pnlLetterInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlLetterInfo.Location = new System.Drawing.Point(427, 4);
            this.pnlLetterInfo.Name = "pnlLetterInfo";
            this.pnlLetterInfo.Size = new System.Drawing.Size(491, 415);
            this.pnlLetterInfo.TabIndex = 76;
            // 
            // dgrMobiles
            // 
            this.dgrMobiles.ActionMenu = jPopupMenu4;
            this.dgrMobiles.AllowUserToAddRows = false;
            this.dgrMobiles.AllowUserToDeleteRows = false;
            this.dgrMobiles.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dgrMobiles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgrMobiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgrMobiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrMobiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrMobiles.EnableContexMenu = true;
            this.dgrMobiles.KeyName = null;
            this.dgrMobiles.Location = new System.Drawing.Point(0, 45);
            this.dgrMobiles.Name = "dgrMobiles";
            this.dgrMobiles.ReadHeadersFromDB = false;
            this.dgrMobiles.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.dgrMobiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrMobiles.ShowRowNumber = true;
            this.dgrMobiles.Size = new System.Drawing.Size(491, 321);
            this.dgrMobiles.TabIndex = 51;
            this.dgrMobiles.TableName = null;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.lblStatus);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 366);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(491, 49);
            this.panel4.TabIndex = 52;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Location = new System.Drawing.Point(6, 3);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(479, 42);
            this.lblStatus.TabIndex = 15;
            this.lblStatus.Text = "SMS هنوز ارسال نشده است.";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.btnSentList);
            this.panel3.Controls.Add(this.btnAddGroup);
            this.panel3.Controls.Add(this.btnAddNonPerson);
            this.panel3.Controls.Add(this.btnDeleteFromGroup);
            this.panel3.Controls.Add(this.btnAddPerson);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel3.Size = new System.Drawing.Size(491, 45);
            this.panel3.TabIndex = 50;
            // 
            // btnSentList
            // 
            this.btnSentList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSentList.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSentList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSentList.Font = new System.Drawing.Font("Tahoma", 9.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSentList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSentList.ImageKey = "add_s32.png";
            this.btnSentList.ImageList = this.imageList2;
            this.btnSentList.Location = new System.Drawing.Point(63, 3);
            this.btnSentList.Name = "btnSentList";
            this.btnSentList.Size = new System.Drawing.Size(125, 40);
            this.btnSentList.TabIndex = 5;
            this.btnSentList.Tag = "افزودن با استفاده از لیست گیرندگان اس ام اس های قبلی";
            this.btnSentList.Text = "SMS گذشته";
            this.btnSentList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSentList.UseVisualStyleBackColor = false;
            this.btnSentList.Click += new System.EventHandler(this.btnSentList_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "add_s32.png");
            this.imageList2.Images.SetKeyName(1, "delete_s32.png");
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddGroup.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAddGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddGroup.Font = new System.Drawing.Font("Tahoma", 9.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAddGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddGroup.ImageKey = "add_s32.png";
            this.btnAddGroup.ImageList = this.imageList2;
            this.btnAddGroup.Location = new System.Drawing.Point(390, 3);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(92, 40);
            this.btnAddGroup.TabIndex = 4;
            this.btnAddGroup.Text = "گروه";
            this.btnAddGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddGroup.UseVisualStyleBackColor = false;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // btnAddNonPerson
            // 
            this.btnAddNonPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNonPerson.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAddNonPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNonPerson.Font = new System.Drawing.Font("Tahoma", 9.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAddNonPerson.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNonPerson.ImageKey = "add_s32.png";
            this.btnAddNonPerson.ImageList = this.imageList2;
            this.btnAddNonPerson.Location = new System.Drawing.Point(194, 3);
            this.btnAddNonPerson.Name = "btnAddNonPerson";
            this.btnAddNonPerson.Size = new System.Drawing.Size(92, 40);
            this.btnAddNonPerson.TabIndex = 3;
            this.btnAddNonPerson.Text = "ناشناس";
            this.btnAddNonPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNonPerson.UseVisualStyleBackColor = false;
            this.btnAddNonPerson.Click += new System.EventHandler(this.btnAddNonPerson_Click);
            // 
            // btnDeleteFromGroup
            // 
            this.btnDeleteFromGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteFromGroup.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDeleteFromGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteFromGroup.ImageKey = "delete_s32.png";
            this.btnDeleteFromGroup.ImageList = this.imageList2;
            this.btnDeleteFromGroup.Location = new System.Drawing.Point(9, 3);
            this.btnDeleteFromGroup.Name = "btnDeleteFromGroup";
            this.btnDeleteFromGroup.Size = new System.Drawing.Size(48, 40);
            this.btnDeleteFromGroup.TabIndex = 2;
            this.btnDeleteFromGroup.UseVisualStyleBackColor = false;
            this.btnDeleteFromGroup.Click += new System.EventHandler(this.btnDeleteFromGroup_Click);
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddPerson.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAddPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPerson.Font = new System.Drawing.Font("Tahoma", 9.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAddPerson.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddPerson.ImageKey = "add_s32.png";
            this.btnAddPerson.ImageList = this.imageList2;
            this.btnAddPerson.Location = new System.Drawing.Point(292, 3);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(92, 40);
            this.btnAddPerson.TabIndex = 0;
            this.btnAddPerson.Text = "شخص";
            this.btnAddPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddPerson.UseVisualStyleBackColor = false;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // refersText1
            // 
            this.refersText1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.refersText1.Location = new System.Drawing.Point(3, 419);
            this.refersText1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.refersText1.Name = "refersText1";
            this.refersText1.Size = new System.Drawing.Size(915, 154);
            this.refersText1.TabIndex = 84;
            // 
            // tbpRefer
            // 
            this.tbpRefer.Controls.Add(this.jRefersTextRTB1);
            this.tbpRefer.ImageKey = "icon-departments_s24.png";
            this.tbpRefer.Location = new System.Drawing.Point(4, 34);
            this.tbpRefer.Name = "tbpRefer";
            this.tbpRefer.Padding = new System.Windows.Forms.Padding(3);
            this.tbpRefer.Size = new System.Drawing.Size(921, 577);
            this.tbpRefer.TabIndex = 1;
            this.tbpRefer.Text = "ارجاعات";
            this.tbpRefer.UseVisualStyleBackColor = true;
            // 
            // jRefersTextRTB1
            // 
            this.jRefersTextRTB1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jRefersTextRTB1.Location = new System.Drawing.Point(3, 3);
            this.jRefersTextRTB1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jRefersTextRTB1.Name = "jRefersTextRTB1";
            this.jRefersTextRTB1.Size = new System.Drawing.Size(915, 571);
            this.jRefersTextRTB1.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "attachment_s24.png");
            this.imageList1.Images.SetKeyName(1, "icon-departments_s24.png");
            this.imageList1.Images.SetKeyName(2, "info_s24.png");
            this.imageList1.Images.SetKeyName(3, "icon-2_24.png");
            // 
            // txtDesc
            // 
            this.txtDesc.ChangeColorIfNotEmpty = true;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(0, 0);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(938, 20);
            this.txtDesc.TabIndex = 3;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.Control;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(6, 11);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(140, 40);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(780, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 40);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "تایید";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRefer
            // 
            this.btnRefer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefer.BackColor = System.Drawing.SystemColors.Control;
            this.btnRefer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefer.Image = ((System.Drawing.Image)(resources.GetObject("btnRefer.Image")));
            this.btnRefer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefer.Location = new System.Drawing.Point(608, 11);
            this.btnRefer.Name = "btnRefer";
            this.btnRefer.Size = new System.Drawing.Size(166, 39);
            this.btnRefer.TabIndex = 13;
            this.btnRefer.Text = "ارجاع / ارسال SMS";
            this.btnRefer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefer.UseVisualStyleBackColor = false;
            this.btnRefer.Click += new System.EventHandler(this.btnRefer_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.btnRefer);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 615);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel2.Size = new System.Drawing.Size(929, 58);
            this.panel2.TabIndex = 44;
            // 
            // SMSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 673);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Name = "SMSForm";
            this.Text = "SMSForm";
            this.Load += new System.EventHandler(this.SMSForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tbpInfo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.pnlLetterInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrMobiles)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tbpRefer.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpInfo;
        private Automation.RefersText refersText1;
        private TextEdit txtDesc;
        private System.Windows.Forms.TabPage tbpRefer;
        private Automation.Refer.JRefersTextRTB jRefersTextRTB1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnlLetterInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.Button btnAddNonPerson;
        private System.Windows.Forms.Button btnDeleteFromGroup;
        private System.Windows.Forms.Button btnAddPerson;
        private JDataGrid dgrMobiles;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblSMSChars;
        private System.Windows.Forms.Label lblTotalSMS;
        private System.Windows.Forms.Label lblSpacesAfter;
        private System.Windows.Forms.Label lblSpacesBefore;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRefer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTotalSMSxRecievers;
        private System.Windows.Forms.Label lblStatusMonth;
        private System.Windows.Forms.Label lblStatusDay;
        private System.Windows.Forms.Button btnSentList;
    }
}