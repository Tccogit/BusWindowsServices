namespace ClassLibrary
{
    partial class JDynamicReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JDynamicReportForm));
            this.listBoxReports = new System.Windows.Forms.ListBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnDesign = new System.Windows.Forms.Button();
            this.rBWord = new System.Windows.Forms.RadioButton();
            this.rBFastReport = new System.Windows.Forms.RadioButton();
            this.tBReportCaption = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLable = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.buttonAllReport = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.Images.SetKeyName(0, "print_16x16.png");
            this.imageList.Images.SetKeyName(1, "Preview.png");
            this.imageList.Images.SetKeyName(2, "NewDocument.png");
            this.imageList.Images.SetKeyName(3, "edit.png");
            this.imageList.Images.SetKeyName(4, "mt_delete.png");
            // 
            // listBoxReports
            // 
            this.listBoxReports.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBoxReports.FormattingEnabled = true;
            this.listBoxReports.ItemHeight = 16;
            this.listBoxReports.Location = new System.Drawing.Point(43, 30);
            this.listBoxReports.Name = "listBoxReports";
            this.listBoxReports.Size = new System.Drawing.Size(237, 260);
            this.listBoxReports.TabIndex = 0;
            this.listBoxReports.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxReports_DrawItem);
            this.listBoxReports.SelectedIndexChanged += new System.EventHandler(this.listBoxReports_SelectedIndexChanged);
            this.listBoxReports.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxReports_MouseDoubleClick);
            // 
            // btnNew
            // 
            this.btnNew.ImageKey = "NewDocument.png";
            this.btnNew.ImageList = this.imageList;
            this.btnNew.Location = new System.Drawing.Point(12, 30);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(25, 25);
            this.btnNew.TabIndex = 1;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.ImageKey = "edit.png";
            this.btnEdit.ImageList = this.imageList;
            this.btnEdit.Location = new System.Drawing.Point(12, 59);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(25, 25);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ImageKey = "mt_delete.png";
            this.btnDelete.ImageList = this.imageList;
            this.btnDelete.Location = new System.Drawing.Point(12, 88);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(25, 25);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "لیست گزارش های تهیه شده:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnDesign);
            this.groupBox1.Controls.Add(this.rBWord);
            this.groupBox1.Controls.Add(this.rBFastReport);
            this.groupBox1.Controls.Add(this.tBReportCaption);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(286, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 205);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ویرایش گزارش";
            // 
            // btnSave
            // 
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.ImageKey = "32_save.png";
            this.btnSave.ImageList = this.imageList1;
            this.btnSave.Location = new System.Drawing.Point(6, 139);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(67, 60);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "ذخیره";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "print_32x32.png");
            this.imageList1.Images.SetKeyName(1, "Preview32x32_2.png");
            this.imageList1.Images.SetKeyName(2, "design-icon.png");
            this.imageList1.Images.SetKeyName(3, "32_save.png");
            // 
            // btnDesign
            // 
            this.btnDesign.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDesign.ImageKey = "design-icon.png";
            this.btnDesign.ImageList = this.imageList1;
            this.btnDesign.Location = new System.Drawing.Point(79, 139);
            this.btnDesign.Name = "btnDesign";
            this.btnDesign.Size = new System.Drawing.Size(67, 60);
            this.btnDesign.TabIndex = 13;
            this.btnDesign.Text = "طراحی";
            this.btnDesign.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDesign.UseVisualStyleBackColor = true;
            this.btnDesign.Click += new System.EventHandler(this.btnDesign_Click);
            // 
            // rBWord
            // 
            this.rBWord.AutoSize = true;
            this.rBWord.Location = new System.Drawing.Point(182, 99);
            this.rBWord.Name = "rBWord";
            this.rBWord.Size = new System.Drawing.Size(68, 20);
            this.rBWord.TabIndex = 12;
            this.rBWord.TabStop = true;
            this.rBWord.Text = "فایل ورد";
            this.rBWord.UseVisualStyleBackColor = true;
            this.rBWord.CheckedChanged += new System.EventHandler(this.rBWord_CheckedChanged);
            // 
            // rBFastReport
            // 
            this.rBFastReport.AutoSize = true;
            this.rBFastReport.Checked = true;
            this.rBFastReport.Location = new System.Drawing.Point(59, 99);
            this.rBFastReport.Name = "rBFastReport";
            this.rBFastReport.Size = new System.Drawing.Size(87, 20);
            this.rBFastReport.TabIndex = 11;
            this.rBFastReport.TabStop = true;
            this.rBFastReport.Text = "گزارش ساز";
            this.rBFastReport.UseVisualStyleBackColor = true;
            this.rBFastReport.CheckedChanged += new System.EventHandler(this.rBFastReport_CheckedChanged);
            // 
            // tBReportCaption
            // 
            this.tBReportCaption.Location = new System.Drawing.Point(6, 57);
            this.tBReportCaption.Name = "tBReportCaption";
            this.tBReportCaption.Size = new System.Drawing.Size(244, 23);
            this.tBReportCaption.TabIndex = 9;
            this.tBReportCaption.TextChanged += new System.EventHandler(this.tBReportCaption_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "عنوان گزارش:";
            // 
            // txtLable
            // 
            this.txtLable.Location = new System.Drawing.Point(292, 49);
            this.txtLable.Name = "txtLable";
            this.txtLable.Size = new System.Drawing.Size(247, 23);
            this.txtLable.TabIndex = 8;
            this.txtLable.TextChanged += new System.EventHandler(this.txtLable_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "برچسب:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnPreview);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Location = new System.Drawing.Point(-2, 309);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel1.Size = new System.Drawing.Size(559, 58);
            this.panel1.TabIndex = 44;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.ImageKey = "print_32x32.png";
            this.btnPrint.ImageList = this.imageList1;
            this.btnPrint.Location = new System.Drawing.Point(406, 12);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(139, 39);
            this.btnPrint.TabIndex = 14;
            this.btnPrint.Text = "چاپ";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreview.ImageKey = "Preview32x32_2.png";
            this.btnPreview.ImageList = this.imageList1;
            this.btnPreview.Location = new System.Drawing.Point(261, 12);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(139, 39);
            this.btnPreview.TabIndex = 13;
            this.btnPreview.Text = "پیش نمایش";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPrview_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(6, 11);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(140, 40);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // buttonAllReport
            // 
            this.buttonAllReport.Image = global::ClassLibrary.Properties.Resources.search22;
            this.buttonAllReport.ImageKey = "mt_delete.png";
            this.buttonAllReport.Location = new System.Drawing.Point(12, 268);
            this.buttonAllReport.Name = "buttonAllReport";
            this.buttonAllReport.Size = new System.Drawing.Size(25, 25);
            this.buttonAllReport.TabIndex = 45;
            this.buttonAllReport.UseVisualStyleBackColor = true;
            this.buttonAllReport.Visible = false;
            this.buttonAllReport.Click += new System.EventHandler(this.buttonAllReport_Click);
            // 
            // JDynamicReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 367);
            this.Controls.Add(this.buttonAllReport);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtLable);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.listBoxReports);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JDynamicReportForm";
            this.Text = "انتخاب گزارش";
            this.Load += new System.EventHandler(this.JDynamicReportForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxReports;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDesign;
        private System.Windows.Forms.RadioButton rBWord;
        private System.Windows.Forms.RadioButton rBFastReport;
        private System.Windows.Forms.TextBox tBReportCaption;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtLable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button buttonAllReport;
    }
}