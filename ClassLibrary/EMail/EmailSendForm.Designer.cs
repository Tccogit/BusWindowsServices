namespace ClassLibrary.EMail
{
    partial class EmailSendForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailSendForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDeleteRecpt = new System.Windows.Forms.Button();
            this.btnAddRecptManual = new System.Windows.Forms.Button();
            this.lsbTo = new System.Windows.Forms.ListBox();
            this.btnAddRecpt = new System.Windows.Forms.Button();
            this.txtSubject = new ClassLibrary.TextEdit(this.components);
            this.cmbFrom = new ClassLibrary.JComboBox(this.components);
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.jArchiveList1 = new ArchivedDocuments.JArchiveList();
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.jRefersTextRTB1 = new Automation.Refer.JRefersTextRTB();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRefer = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.jArchiveList1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(150, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(962, 525);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 49;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(954, 487);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "اطلاعات ایمیل";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtContent);
            this.panel3.Controls.Add(this.lblStatus);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(948, 481);
            this.panel3.TabIndex = 48;
            // 
            // txtContent
            // 
            this.txtContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContent.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtContent.Location = new System.Drawing.Point(0, 161);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(948, 301);
            this.txtContent.TabIndex = 4;
            // 
            // lblStatus
            // 
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Location = new System.Drawing.Point(0, 462);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(948, 19);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "وضعیت: ";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.Controls.Add(this.btnDeleteRecpt);
            this.panel2.Controls.Add(this.btnAddRecptManual);
            this.panel2.Controls.Add(this.lsbTo);
            this.panel2.Controls.Add(this.btnAddRecpt);
            this.panel2.Controls.Add(this.txtSubject);
            this.panel2.Controls.Add(this.cmbFrom);
            this.panel2.Controls.Add(this.lblSubject);
            this.panel2.Controls.Add(this.lblTo);
            this.panel2.Controls.Add(this.lblFrom);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(948, 161);
            this.panel2.TabIndex = 1;
            // 
            // btnDeleteRecpt
            // 
            this.btnDeleteRecpt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteRecpt.BackColor = System.Drawing.SystemColors.Control;
            this.btnDeleteRecpt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteRecpt.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDeleteRecpt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDeleteRecpt.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteRecpt.Image")));
            this.btnDeleteRecpt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteRecpt.Location = new System.Drawing.Point(215, 100);
            this.btnDeleteRecpt.Name = "btnDeleteRecpt";
            this.btnDeleteRecpt.Size = new System.Drawing.Size(75, 26);
            this.btnDeleteRecpt.TabIndex = 9;
            this.btnDeleteRecpt.Text = "حذف";
            this.btnDeleteRecpt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteRecpt.UseVisualStyleBackColor = false;
            this.btnDeleteRecpt.Click += new System.EventHandler(this.btnDeleteRecpt_Click);
            // 
            // btnAddRecptManual
            // 
            this.btnAddRecptManual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRecptManual.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddRecptManual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRecptManual.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAddRecptManual.ForeColor = System.Drawing.Color.Black;
            this.btnAddRecptManual.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRecptManual.Image")));
            this.btnAddRecptManual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddRecptManual.Location = new System.Drawing.Point(215, 68);
            this.btnAddRecptManual.Name = "btnAddRecptManual";
            this.btnAddRecptManual.Size = new System.Drawing.Size(75, 26);
            this.btnAddRecptManual.TabIndex = 8;
            this.btnAddRecptManual.Text = "دستی";
            this.btnAddRecptManual.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddRecptManual.UseVisualStyleBackColor = false;
            this.btnAddRecptManual.Click += new System.EventHandler(this.btnAddRecptManual_Click);
            // 
            // lsbTo
            // 
            this.lsbTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbTo.FormattingEnabled = true;
            this.lsbTo.IntegralHeight = false;
            this.lsbTo.ItemHeight = 16;
            this.lsbTo.Location = new System.Drawing.Point(296, 34);
            this.lsbTo.MultiColumn = true;
            this.lsbTo.Name = "lsbTo";
            this.lsbTo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lsbTo.Size = new System.Drawing.Size(572, 92);
            this.lsbTo.TabIndex = 7;
            // 
            // btnAddRecpt
            // 
            this.btnAddRecpt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRecpt.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddRecpt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRecpt.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAddRecpt.ForeColor = System.Drawing.Color.Blue;
            this.btnAddRecpt.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRecpt.Image")));
            this.btnAddRecpt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddRecpt.Location = new System.Drawing.Point(215, 36);
            this.btnAddRecpt.Name = "btnAddRecpt";
            this.btnAddRecpt.Size = new System.Drawing.Size(75, 26);
            this.btnAddRecpt.TabIndex = 6;
            this.btnAddRecpt.Text = "لیست";
            this.btnAddRecpt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddRecpt.UseVisualStyleBackColor = false;
            this.btnAddRecpt.Click += new System.EventHandler(this.btnAddRecpt_Click);
            // 
            // txtSubject
            // 
            this.txtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubject.ChangeColorIfNotEmpty = false;
            this.txtSubject.ChangeColorOnEnter = true;
            this.txtSubject.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSubject.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSubject.Location = new System.Drawing.Point(296, 132);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Negative = true;
            this.txtSubject.NotEmpty = false;
            this.txtSubject.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSubject.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSubject.SelectOnEnter = true;
            this.txtSubject.Size = new System.Drawing.Size(572, 23);
            this.txtSubject.TabIndex = 5;
            this.txtSubject.TextMode = ClassLibrary.TextModes.Text;
            // 
            // cmbFrom
            // 
            this.cmbFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFrom.BaseCode = 0;
            this.cmbFrom.ChangeColorIfNotEmpty = true;
            this.cmbFrom.ChangeColorOnEnter = true;
            this.cmbFrom.FormattingEnabled = true;
            this.cmbFrom.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbFrom.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbFrom.Location = new System.Drawing.Point(296, 7);
            this.cmbFrom.Name = "cmbFrom";
            this.cmbFrom.NotEmpty = false;
            this.cmbFrom.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbFrom.SelectOnEnter = true;
            this.cmbFrom.Size = new System.Drawing.Size(572, 24);
            this.cmbFrom.TabIndex = 3;
            // 
            // lblSubject
            // 
            this.lblSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubject.Location = new System.Drawing.Point(874, 132);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(69, 21);
            this.lblSubject.TabIndex = 2;
            this.lblSubject.Text = "موضوع: ";
            // 
            // lblTo
            // 
            this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTo.Location = new System.Drawing.Point(874, 39);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(69, 21);
            this.lblTo.TabIndex = 1;
            this.lblTo.Text = "به:";
            // 
            // lblFrom
            // 
            this.lblFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFrom.Location = new System.Drawing.Point(874, 10);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(67, 21);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "از: ";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.jArchiveList1);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(954, 487);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ضمائم";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // jArchiveList1
            // 
            this.jArchiveList1.AllowUserAddFile = true;
            this.jArchiveList1.AllowUserAddFromArchive = true;
            this.jArchiveList1.AllowUserAddImage = true;
            this.jArchiveList1.AllowUserCamera = true;
            this.jArchiveList1.AllowUserDeleteFile = true;
            this.jArchiveList1.ClassName = "";
            this.jArchiveList1.ClassNames = null;
            this.jArchiveList1.Controls.Add(this.txtDesc);
            this.jArchiveList1.DataBaseClassName = "";
            this.jArchiveList1.DataBaseObjectCode = 0;
            this.jArchiveList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jArchiveList1.EnabledChange = true;
            this.jArchiveList1.ExtraObject = null;
            this.jArchiveList1.Location = new System.Drawing.Point(3, 3);
            this.jArchiveList1.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.jArchiveList1.Name = "jArchiveList1";
            this.jArchiveList1.ObjectCode = 0;
            this.jArchiveList1.ObjectCodes = null;
            this.jArchiveList1.PlaceCode = 0;
            this.jArchiveList1.Size = new System.Drawing.Size(948, 481);
            this.jArchiveList1.SubjectCode = 0;
            this.jArchiveList1.TabIndex = 4;
            // 
            // txtDesc
            // 
            this.txtDesc.BackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.ChangeColorIfNotEmpty = true;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDesc.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(0, 0);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(3, 17, 3, 17);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(948, 23);
            this.txtDesc.TabIndex = 3;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.jRefersTextRTB1);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(954, 487);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ارجاعات";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // jRefersTextRTB1
            // 
            this.jRefersTextRTB1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jRefersTextRTB1.Location = new System.Drawing.Point(3, 3);
            this.jRefersTextRTB1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jRefersTextRTB1.Name = "jRefersTextRTB1";
            this.jRefersTextRTB1.Size = new System.Drawing.Size(948, 481);
            this.jRefersTextRTB1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnRefer);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 525);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel1.Size = new System.Drawing.Size(962, 58);
            this.panel1.TabIndex = 48;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(648, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 40);
            this.btnSave.TabIndex = 17;
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
            this.btnRefer.Location = new System.Drawing.Point(794, 12);
            this.btnRefer.Name = "btnRefer";
            this.btnRefer.Size = new System.Drawing.Size(159, 39);
            this.btnRefer.TabIndex = 13;
            this.btnRefer.Text = "ارسال / ارجاع ایمیل";
            this.btnRefer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefer.UseVisualStyleBackColor = false;
            this.btnRefer.Click += new System.EventHandler(this.btnRefer_Click);
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
            // EmailSendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 583);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "EmailSendForm";
            this.Text = "EmailSendForm";
            this.Load += new System.EventHandler(this.EmailSendForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.jArchiveList1.ResumeLayout(false);
            this.jArchiveList1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private Automation.Refer.JRefersTextRTB jRefersTextRTB1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRefer;
        private System.Windows.Forms.Button btnExit;
        private TextEdit txtSubject;
        private JComboBox cmbFrom;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label lblStatus;
        private ArchivedDocuments.JArchiveList jArchiveList1;
        private TextEdit txtDesc;
        private System.Windows.Forms.Button btnAddRecpt;
        private System.Windows.Forms.ListBox lsbTo;
        private System.Windows.Forms.Button btnAddRecptManual;
        private System.Windows.Forms.Button btnDeleteRecpt;
    }
}