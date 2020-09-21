namespace BusManagment.Reports
{
    partial class DailyPerformanceRportOnBusForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DailyPerformanceRportOnBusForm));
            this.grdReport = new ClassLibrary.JJanusGrid();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbZone = new ClassLibrary.JComboBox(this.components);
            this.cmbDriverBus = new ClassLibrary.JComboBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.cmbOwnerBus = new ClassLibrary.JComboBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDateOut = new ClassLibrary.DateEdit(this.components);
            this.txtDateIn = new ClassLibrary.DateEdit(this.components);
            this.txtLineNo = new System.Windows.Forms.TextBox();
            this.txtBusNo = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkListGroup = new System.Windows.Forms.CheckedListBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageSize = new System.Drawing.Size(24, 24);
            // 
            // grdReport
            // 
            this.grdReport.ActionClassName = "";
            this.grdReport.ActionMenu = null;
            this.grdReport.DataSource = null;
            this.grdReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdReport.Edited = false;
            this.grdReport.Location = new System.Drawing.Point(0, 194);
            this.grdReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdReport.MultiSelect = true;
            this.grdReport.Name = "grdReport";
            this.grdReport.ShowNavigator = true;
            this.grdReport.ShowToolbar = true;
            this.grdReport.Size = new System.Drawing.Size(596, 247);
            this.grdReport.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.ItemSize = new System.Drawing.Size(110, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(596, 153);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(588, 124);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "فیلتر";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cmbZone);
            this.panel1.Controls.Add(this.cmbDriverBus);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cmbOwnerBus);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtDateOut);
            this.panel1.Controls.Add(this.txtDateIn);
            this.panel1.Controls.Add(this.txtLineNo);
            this.panel1.Controls.Add(this.txtBusNo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 118);
            this.panel1.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(153, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "منطقه:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(259, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "شماره خط:";
            // 
            // cmbZone
            // 
            this.cmbZone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbZone.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbZone.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbZone.BaseCode = 0;
            this.cmbZone.ChangeColorIfNotEmpty = true;
            this.cmbZone.ChangeColorOnEnter = true;
            this.cmbZone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbZone.FormattingEnabled = true;
            this.cmbZone.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbZone.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbZone.Location = new System.Drawing.Point(117, 78);
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.NotEmpty = false;
            this.cmbZone.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbZone.SelectOnEnter = true;
            this.cmbZone.Size = new System.Drawing.Size(104, 24);
            this.cmbZone.TabIndex = 7;
            // 
            // cmbDriverBus
            // 
            this.cmbDriverBus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDriverBus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbDriverBus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDriverBus.BaseCode = 0;
            this.cmbDriverBus.ChangeColorIfNotEmpty = true;
            this.cmbDriverBus.ChangeColorOnEnter = true;
            this.cmbDriverBus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDriverBus.FormattingEnabled = true;
            this.cmbDriverBus.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbDriverBus.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbDriverBus.Location = new System.Drawing.Point(333, 78);
            this.cmbDriverBus.Name = "cmbDriverBus";
            this.cmbDriverBus.NotEmpty = false;
            this.cmbDriverBus.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbDriverBus.SelectOnEnter = true;
            this.cmbDriverBus.Size = new System.Drawing.Size(241, 24);
            this.cmbDriverBus.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(493, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "راننده اتوبوس:";
            // 
            // cmbOwnerBus
            // 
            this.cmbOwnerBus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbOwnerBus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbOwnerBus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbOwnerBus.BaseCode = 0;
            this.cmbOwnerBus.ChangeColorIfNotEmpty = true;
            this.cmbOwnerBus.ChangeColorOnEnter = true;
            this.cmbOwnerBus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbOwnerBus.FormattingEnabled = true;
            this.cmbOwnerBus.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbOwnerBus.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbOwnerBus.Location = new System.Drawing.Point(37, 29);
            this.cmbOwnerBus.Name = "cmbOwnerBus";
            this.cmbOwnerBus.NotEmpty = false;
            this.cmbOwnerBus.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbOwnerBus.SelectOnEnter = true;
            this.cmbOwnerBus.Size = new System.Drawing.Size(219, 24);
            this.cmbOwnerBus.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(175, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "مالک اتوبوس:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(314, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "تا تاریخ:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(417, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "از تاریخ:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(485, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "شماره اتوبوس:";
            // 
            // txtDateOut
            // 
            this.txtDateOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDateOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDateOut.ChangeColorIfNotEmpty = true;
            this.txtDateOut.ChangeColorOnEnter = true;
            this.txtDateOut.Date = new System.DateTime(((long)(0)));
            this.txtDateOut.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDateOut.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDateOut.InsertInDatesTable = true;
            this.txtDateOut.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDateOut.Location = new System.Drawing.Point(262, 29);
            this.txtDateOut.Mask = "0000/00/00";
            this.txtDateOut.Name = "txtDateOut";
            this.txtDateOut.NotEmpty = false;
            this.txtDateOut.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDateOut.Size = new System.Drawing.Size(100, 23);
            this.txtDateOut.TabIndex = 3;
            // 
            // txtDateIn
            // 
            this.txtDateIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDateIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDateIn.ChangeColorIfNotEmpty = true;
            this.txtDateIn.ChangeColorOnEnter = true;
            this.txtDateIn.Date = new System.DateTime(((long)(0)));
            this.txtDateIn.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDateIn.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDateIn.InsertInDatesTable = true;
            this.txtDateIn.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDateIn.Location = new System.Drawing.Point(368, 29);
            this.txtDateIn.Mask = "0000/00/00";
            this.txtDateIn.Name = "txtDateIn";
            this.txtDateIn.NotEmpty = false;
            this.txtDateIn.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDateIn.Size = new System.Drawing.Size(100, 23);
            this.txtDateIn.TabIndex = 2;
            // 
            // txtLineNo
            // 
            this.txtLineNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLineNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLineNo.Location = new System.Drawing.Point(227, 78);
            this.txtLineNo.Name = "txtLineNo";
            this.txtLineNo.Size = new System.Drawing.Size(100, 23);
            this.txtLineNo.TabIndex = 1;
            // 
            // txtBusNo
            // 
            this.txtBusNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBusNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBusNo.Location = new System.Drawing.Point(474, 29);
            this.txtBusNo.Name = "txtBusNo";
            this.txtBusNo.Size = new System.Drawing.Size(100, 23);
            this.txtBusNo.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chkListGroup);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(588, 115);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "گروه بندی";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chkListGroup
            // 
            this.chkListGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chkListGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkListGroup.FormattingEnabled = true;
            this.chkListGroup.IntegralHeight = false;
            this.chkListGroup.Items.AddRange(new object[] {
            "مبلغ",
            "راننده",
            "منطقه",
            "مالک",
            "اتوبوس",
            "خط"});
            this.chkListGroup.Location = new System.Drawing.Point(3, 3);
            this.chkListGroup.Name = "chkListGroup";
            this.chkListGroup.Size = new System.Drawing.Size(582, 109);
            this.chkListGroup.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(424, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(165, 30);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "گزارش";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 153);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(596, 41);
            this.panel2.TabIndex = 9;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "report_s24.png");
            // 
            // DailyPerformanceRportOnBusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 441);
            this.Controls.Add(this.grdReport);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tabControl1);
            this.Name = "DailyPerformanceRportOnBusForm";
            this.Text = "گزارش کارکرد اتوبوس";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ClassLibrary.JJanusGrid grdReport;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private ClassLibrary.JComboBox cmbZone;
        private ClassLibrary.JComboBox cmbDriverBus;
        private System.Windows.Forms.Label label5;
        private ClassLibrary.JComboBox cmbOwnerBus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.DateEdit txtDateOut;
        private ClassLibrary.DateEdit txtDateIn;
        private System.Windows.Forms.TextBox txtLineNo;
        private System.Windows.Forms.TextBox txtBusNo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckedListBox chkListGroup;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ImageList imageList1;

    }
}