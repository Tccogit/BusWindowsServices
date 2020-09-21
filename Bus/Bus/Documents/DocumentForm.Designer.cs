namespace BusManagment.Documents
{
    partial class JDocumentForm
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
            this.btnExportToBank = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chListDates = new System.Windows.Forms.CheckedListBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.chAllDates = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grdReport = new ClassLibrary.JJanusGrid();
            this.txtIssuDate = new ClassLibrary.DateEdit(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnExportToBank);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 410);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(708, 44);
            this.panel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(6, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 32);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "خروج";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExportToBank
            // 
            this.btnExportToBank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportToBank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportToBank.Location = new System.Drawing.Point(293, 6);
            this.btnExportToBank.Name = "btnExportToBank";
            this.btnExportToBank.Size = new System.Drawing.Size(188, 32);
            this.btnExportToBank.TabIndex = 1;
            this.btnExportToBank.Text = "بستن تراکنشهای انتخاب شده";
            this.btnExportToBank.UseVisualStyleBackColor = true;
            this.btnExportToBank.Click += new System.EventHandler(this.btnExportToBank_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtIssuDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(708, 410);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(393, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "شرح:";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesc.ChangeColorIfNotEmpty = false;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(6, 16);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(381, 23);
            this.txtDesc.TabIndex = 21;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            this.txtDesc.TextChanged += new System.EventHandler(this.txtDesc_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.chListDates);
            this.groupBox3.Controls.Add(this.btnReport);
            this.groupBox3.Controls.Add(this.chAllDates);
            this.groupBox3.Location = new System.Drawing.Point(484, 45);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(218, 359);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "تاریخ های کارکرد رسیده:";
            // 
            // chListDates
            // 
            this.chListDates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chListDates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chListDates.FormattingEnabled = true;
            this.chListDates.IntegralHeight = false;
            this.chListDates.Location = new System.Drawing.Point(3, 39);
            this.chListDates.Name = "chListDates";
            this.chListDates.Size = new System.Drawing.Size(212, 289);
            this.chListDates.TabIndex = 18;
            this.chListDates.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chListDates_ItemCheck);
            this.chListDates.SelectedValueChanged += new System.EventHandler(this.chListDates_SelectedValueChanged);
            // 
            // btnReport
            // 
            this.btnReport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Location = new System.Drawing.Point(3, 328);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(212, 28);
            this.btnReport.TabIndex = 17;
            this.btnReport.Text = "مشاهده خروجی";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // chAllDates
            // 
            this.chAllDates.AutoSize = true;
            this.chAllDates.Dock = System.Windows.Forms.DockStyle.Top;
            this.chAllDates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chAllDates.Location = new System.Drawing.Point(3, 19);
            this.chAllDates.Name = "chAllDates";
            this.chAllDates.Size = new System.Drawing.Size(212, 20);
            this.chAllDates.TabIndex = 14;
            this.chAllDates.Text = "همه تاریخ ها";
            this.chAllDates.UseVisualStyleBackColor = true;
            this.chAllDates.CheckedChanged += new System.EventHandler(this.chAllDates_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.grdReport);
            this.groupBox2.Location = new System.Drawing.Point(3, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(478, 365);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "تراکنشهای رسیده:";
            // 
            // grdReport
            // 
            this.grdReport.ActionClassName = "";
            this.grdReport.ActionMenu = null;
            this.grdReport.DataSource = null;
            this.grdReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdReport.Edited = true;
            this.grdReport.Location = new System.Drawing.Point(3, 19);
            this.grdReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdReport.MultiSelect = true;
            this.grdReport.Name = "grdReport";
            this.grdReport.ShowNavigator = true;
            this.grdReport.ShowToolbar = true;
            this.grdReport.Size = new System.Drawing.Size(472, 343);
            this.grdReport.TabIndex = 9;
            // 
            // txtIssuDate
            // 
            this.txtIssuDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIssuDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIssuDate.ChangeColorIfNotEmpty = true;
            this.txtIssuDate.ChangeColorOnEnter = true;
            this.txtIssuDate.Date = new System.DateTime(((long)(0)));
            this.txtIssuDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtIssuDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtIssuDate.InsertInDatesTable = true;
            this.txtIssuDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtIssuDate.Location = new System.Drawing.Point(484, 16);
            this.txtIssuDate.Mask = "0000/00/00";
            this.txtIssuDate.Name = "txtIssuDate";
            this.txtIssuDate.NotEmpty = false;
            this.txtIssuDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtIssuDate.ReadOnly = true;
            this.txtIssuDate.Size = new System.Drawing.Size(100, 23);
            this.txtIssuDate.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(590, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "تاریخ بستن سند:";
            // 
            // JDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 454);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JDocumentForm";
            this.Text = "بستن تراکنشها";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.DateEdit txtIssuDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private ClassLibrary.JJanusGrid grdReport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnExportToBank;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chAllDates;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.TextEdit txtDesc;
        private System.Windows.Forms.CheckedListBox chListDates;
    }
}