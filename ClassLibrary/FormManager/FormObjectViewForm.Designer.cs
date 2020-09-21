namespace ClassLibrary
{
    partial class FormObjectViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormObjectViewForm));
            ClassLibrary.JPopupMenu jPopupMenu2 = new ClassLibrary.JPopupMenu();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.jPropertyHistoryView1 = new Globals.Property.PropertyHistory.JPropertyHistoryView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.JArchive = new ArchivedDocuments.JArchiveList();
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a = new ClassLibrary.TextEdit(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.jPropertyValueUserControl1 = new Globals.Property.JPropertyValueUserControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.propertyValueGridControl1 = new Globals.Property.PropertyValueGridControl();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgrInfo = new ClassLibrary.JDataGrid();
            this.panelNoStorage = new System.Windows.Forms.Panel();
            this.buttonNoStorage = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.refersText1 = new Automation.RefersText();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnRefer = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.txtDescription = new ClassLibrary.JEditor();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.JArchive.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrInfo)).BeginInit();
            this.panelNoStorage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageSize = new System.Drawing.Size(28, 28);
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.Images.SetKeyName(0, "print_32x32.png");
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.jPropertyHistoryView1);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(880, 525);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "تاریخچه تغییرات";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // jPropertyHistoryView1
            // 
            this.jPropertyHistoryView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jPropertyHistoryView1.Location = new System.Drawing.Point(0, 0);
            this.jPropertyHistoryView1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.jPropertyHistoryView1.Name = "jPropertyHistoryView1";
            this.jPropertyHistoryView1.Size = new System.Drawing.Size(880, 525);
            this.jPropertyHistoryView1.TabIndex = 51;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.JArchive);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(880, 525);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "اسناد";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // JArchive
            // 
            this.JArchive.AllowUserAddFile = true;
            this.JArchive.AllowUserAddFromArchive = true;
            this.JArchive.AllowUserAddImage = true;
            this.JArchive.AllowUserCamera = true;
            this.JArchive.AllowUserDeleteFile = true;
            this.JArchive.ClassName = "";
            this.JArchive.ClassNames = null;
            this.JArchive.Controls.Add(this.txtDesc);
            this.JArchive.Controls.Add(this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a);
            this.JArchive.DataBaseClassName = "";
            this.JArchive.DataBaseObjectCode = 0;
            this.JArchive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JArchive.EnabledChange = true;
            this.JArchive.ExtraObject = null;
            this.JArchive.Location = new System.Drawing.Point(0, 0);
            this.JArchive.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.JArchive.Name = "JArchive";
            this.JArchive.ObjectCode = 0;
            this.JArchive.ObjectCodes = null;
            this.JArchive.PlaceCode = 0;
            this.JArchive.Size = new System.Drawing.Size(880, 525);
            this.JArchive.SubjectCode = 0;
            this.JArchive.TabIndex = 1;
            // 
            // txtDesc
            // 
            this.txtDesc.ChangeColorIfNotEmpty = true;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(0, 23);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(3, 20079, 3, 20079);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(880, 23);
            this.txtDesc.TabIndex = 3;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // object_9b85e34b_9421_4bf2_b7e5_baba81bba67a
            // 
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.ChangeColorIfNotEmpty = true;
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.ChangeColorOnEnter = true;
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.Dock = System.Windows.Forms.DockStyle.Top;
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.InBackColor = System.Drawing.SystemColors.Info;
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.InForeColor = System.Drawing.SystemColors.WindowText;
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.Location = new System.Drawing.Point(0, 0);
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.Name = "object_9b85e34b_9421_4bf2_b7e5_baba81bba67a";
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.Negative = true;
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.NotEmpty = false;
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.NotEmptyColor = System.Drawing.Color.Red;
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.SelectOnEnter = true;
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.Size = new System.Drawing.Size(880, 23);
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.TabIndex = 3;
            this.object_9b85e34b_9421_4bf2_b7e5_baba81bba67a.TextMode = ClassLibrary.TextModes.Text;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitter1);
            this.tabPage1.Controls.Add(this.tabControl2);
            this.tabPage1.Controls.Add(this.txtComment);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.splitter2);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(880, 525);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ویژگی ها";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(608, 43);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 290);
            this.splitter1.TabIndex = 46;
            this.splitter1.TabStop = false;
            // 
            // tabControl2
            // 
            this.tabControl2.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(3, 43);
            this.tabControl2.Multiline = true;
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.RightToLeftLayout = true;
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.ShowToolTips = true;
            this.tabControl2.Size = new System.Drawing.Size(608, 290);
            this.tabControl2.TabIndex = 45;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.jPropertyValueUserControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(578, 282);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "تکی";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // jPropertyValueUserControl1
            // 
            this.jPropertyValueUserControl1.AutoScroll = true;
            this.jPropertyValueUserControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jPropertyValueUserControl1.ClassName = null;
            this.jPropertyValueUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jPropertyValueUserControl1.Location = new System.Drawing.Point(3, 3);
            this.jPropertyValueUserControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jPropertyValueUserControl1.Name = "jPropertyValueUserControl1";
            this.jPropertyValueUserControl1.ObjectCode = -1;
            this.jPropertyValueUserControl1.Size = new System.Drawing.Size(572, 276);
            this.jPropertyValueUserControl1.TabIndex = 0;
            this.jPropertyValueUserControl1.ValueObjectCode = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.propertyValueGridControl1);
            this.tabPage5.Location = new System.Drawing.Point(4, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(578, 285);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "گروهی";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // propertyValueGridControl1
            // 
            this.propertyValueGridControl1.ClassName = null;
            this.propertyValueGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyValueGridControl1.Location = new System.Drawing.Point(3, 3);
            this.propertyValueGridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.propertyValueGridControl1.Name = "propertyValueGridControl1";
            this.propertyValueGridControl1.ObjectCode = 0;
            this.propertyValueGridControl1.Size = new System.Drawing.Size(572, 279);
            this.propertyValueGridControl1.TabIndex = 0;
            this.propertyValueGridControl1.ValueObjectCode = 0;
            // 
            // txtComment
            // 
            this.txtComment.BackColor = System.Drawing.SystemColors.Info;
            this.txtComment.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtComment.Location = new System.Drawing.Point(3, 20);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(608, 23);
            this.txtComment.TabIndex = 48;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(608, 16);
            this.label1.TabIndex = 49;
            this.label1.Text = "موضوع:";
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(3, 333);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(608, 8);
            this.splitter2.TabIndex = 47;
            this.splitter2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgrInfo);
            this.panel3.Controls.Add(this.panelNoStorage);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(611, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(266, 337);
            this.panel3.TabIndex = 52;
            this.panel3.Resize += new System.EventHandler(this.panel3_Resize);
            // 
            // dgrInfo
            // 
            this.dgrInfo.ActionMenu = jPopupMenu2;
            this.dgrInfo.AllowUserToAddRows = false;
            this.dgrInfo.AllowUserToDeleteRows = false;
            this.dgrInfo.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dgrInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgrInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgrInfo.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgrInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrInfo.ColumnHeadersVisible = false;
            this.dgrInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrInfo.EnableContexMenu = true;
            this.dgrInfo.KeyName = null;
            this.dgrInfo.Location = new System.Drawing.Point(0, 70);
            this.dgrInfo.MultiSelect = false;
            this.dgrInfo.Name = "dgrInfo";
            this.dgrInfo.ReadHeadersFromDB = true;
            this.dgrInfo.ReadOnly = true;
            this.dgrInfo.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.dgrInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgrInfo.ShowRowNumber = false;
            this.dgrInfo.Size = new System.Drawing.Size(266, 267);
            this.dgrInfo.TabIndex = 45;
            this.dgrInfo.TableName = null;
            // 
            // panelNoStorage
            // 
            this.panelNoStorage.Controls.Add(this.button1);
            this.panelNoStorage.Controls.Add(this.buttonNoStorage);
            this.panelNoStorage.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNoStorage.Location = new System.Drawing.Point(0, 0);
            this.panelNoStorage.Name = "panelNoStorage";
            this.panelNoStorage.Size = new System.Drawing.Size(266, 70);
            this.panelNoStorage.TabIndex = 46;
            // 
            // buttonNoStorage
            // 
            this.buttonNoStorage.Location = new System.Drawing.Point(6, 5);
            this.buttonNoStorage.Name = "buttonNoStorage";
            this.buttonNoStorage.Size = new System.Drawing.Size(254, 26);
            this.buttonNoStorage.TabIndex = 0;
            this.buttonNoStorage.Text = "شماره از اندیکاتور";
            this.buttonNoStorage.UseVisualStyleBackColor = true;
            this.buttonNoStorage.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.refersText1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 341);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(874, 122);
            this.panel2.TabIndex = 51;
            // 
            // refersText1
            // 
            this.refersText1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.refersText1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.refersText1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.refersText1.Location = new System.Drawing.Point(0, 0);
            this.refersText1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.refersText1.Name = "refersText1";
            this.refersText1.Size = new System.Drawing.Size(874, 122);
            this.refersText1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnRefer);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 463);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel1.Size = new System.Drawing.Size(874, 58);
            this.panel1.TabIndex = 43;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.SystemColors.Control;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.ImageKey = "print_32x32.png";
            this.btnPrint.ImageList = this.imageList;
            this.btnPrint.Location = new System.Drawing.Point(435, 11);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(139, 39);
            this.btnPrint.TabIndex = 14;
            this.btnPrint.Text = "چاپ";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnRefer
            // 
            this.btnRefer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefer.BackColor = System.Drawing.SystemColors.Control;
            this.btnRefer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefer.Image = ((System.Drawing.Image)(resources.GetObject("btnRefer.Image")));
            this.btnRefer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefer.Location = new System.Drawing.Point(580, 11);
            this.btnRefer.Name = "btnRefer";
            this.btnRefer.Size = new System.Drawing.Size(139, 39);
            this.btnRefer.TabIndex = 13;
            this.btnRefer.Text = "ارجاع";
            this.btnRefer.UseVisualStyleBackColor = false;
            this.btnRefer.Click += new System.EventHandler(this.btnRefer_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(725, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 40);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "تایید";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(120, 25);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(888, 558);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.txtDescription);
            this.tabPage6.Location = new System.Drawing.Point(4, 29);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(880, 525);
            this.tabPage6.TabIndex = 4;
            this.tabPage6.Text = "توضیحات";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Location = new System.Drawing.Point(3, 3);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(874, 519);
            this.txtDescription.TabIndex = 0;
            this.txtDescription.TabStop = false;
            this.txtDescription.ViewMode = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(254, 26);
            this.button1.TabIndex = 0;
            this.button1.Text = "نمایش اطلاعات";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // FormObjectViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 558);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormObjectViewForm";
            this.Text = "ثبت اطلاعات فرم";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormObjectViewForm_FormClosing);
            this.Load += new System.EventHandler(this.FormObjectViewForm_Load);
            this.tabPage4.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.JArchive.ResumeLayout(false);
            this.JArchive.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrInfo)).EndInit();
            this.panelNoStorage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage3;
        private ArchivedDocuments.JArchiveList JArchive;
        private TextEdit txtDesc;
        private TextEdit object_9b85e34b_9421_4bf2_b7e5_baba81bba67a;
		private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRefer;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private Automation.RefersText refersText1;
        private Globals.Property.JPropertyValueUserControl jPropertyValueUserControl1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage5;
        private Globals.Property.PropertyValueGridControl propertyValueGridControl1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private Globals.Property.PropertyHistory.JPropertyHistoryView jPropertyHistoryView1;
        private System.Windows.Forms.TabPage tabPage6;
        private ClassLibrary.JEditor txtDescription;
		private System.Windows.Forms.Panel panel3;
		private JDataGrid dgrInfo;
		private System.Windows.Forms.Panel panelNoStorage;
		private System.Windows.Forms.Button buttonNoStorage;
        private System.Windows.Forms.Button button1;
    }
}