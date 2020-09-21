namespace BusManagment.Documents
{
    partial class JAUTDocumentReportForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbOwners = new ClassLibrary.JComboBox(this.components);
            this.cmbBuses = new ClassLibrary.JComboBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grdReport = new ClassLibrary.JJanusGrid();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbBes = new System.Windows.Forms.Label();
            this.lbBed = new System.Windows.Forms.Label();
            this.lbRemain = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.cmbOwners);
            this.groupBox1.Controls.Add(this.cmbBuses);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(718, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSearch.Location = new System.Drawing.Point(261, 32);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 26);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "نمایش";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbOwners
            // 
            this.cmbOwners.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbOwners.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbOwners.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbOwners.BaseCode = 0;
            this.cmbOwners.ChangeColorIfNotEmpty = true;
            this.cmbOwners.ChangeColorOnEnter = true;
            this.cmbOwners.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbOwners.FormattingEnabled = true;
            this.cmbOwners.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbOwners.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbOwners.Location = new System.Drawing.Point(342, 34);
            this.cmbOwners.Name = "cmbOwners";
            this.cmbOwners.NotEmpty = false;
            this.cmbOwners.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbOwners.SelectOnEnter = true;
            this.cmbOwners.Size = new System.Drawing.Size(166, 24);
            this.cmbOwners.TabIndex = 3;
            // 
            // cmbBuses
            // 
            this.cmbBuses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBuses.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbBuses.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBuses.BaseCode = 0;
            this.cmbBuses.ChangeColorIfNotEmpty = true;
            this.cmbBuses.ChangeColorOnEnter = true;
            this.cmbBuses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBuses.FormattingEnabled = true;
            this.cmbBuses.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbBuses.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbBuses.Location = new System.Drawing.Point(537, 32);
            this.cmbBuses.Name = "cmbBuses";
            this.cmbBuses.NotEmpty = false;
            this.cmbBuses.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbBuses.SelectOnEnter = true;
            this.cmbBuses.Size = new System.Drawing.Size(166, 24);
            this.cmbBuses.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(450, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "نام مالک:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(614, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "شماره اتوبوس:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbRemain);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lbBes);
            this.panel1.Controls.Add(this.lbBed);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 429);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(718, 66);
            this.panel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(12, 31);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 32);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "خروج";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grdReport);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(718, 365);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // grdReport
            // 
            this.grdReport.ActionClassName = "";
            this.grdReport.ActionMenu = null;
            this.grdReport.DataSource = null;
            this.grdReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdReport.Edited = false;
            this.grdReport.Location = new System.Drawing.Point(3, 19);
            this.grdReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdReport.MultiSelect = true;
            this.grdReport.Name = "grdReport";
            this.grdReport.ShowNavigator = true;
            this.grdReport.ShowToolbar = true;
            this.grdReport.Size = new System.Drawing.Size(712, 343);
            this.grdReport.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(615, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "مجموع بدهکار:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(605, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "مجموع بستانکار:";
            // 
            // lbBes
            // 
            this.lbBes.Location = new System.Drawing.Point(406, 9);
            this.lbBes.Name = "lbBes";
            this.lbBes.Size = new System.Drawing.Size(178, 16);
            this.lbBes.TabIndex = 4;
            this.lbBes.Text = "0";
            // 
            // lbBed
            // 
            this.lbBed.Location = new System.Drawing.Point(406, 39);
            this.lbBed.Name = "lbBed";
            this.lbBed.Size = new System.Drawing.Size(177, 16);
            this.lbBed.TabIndex = 3;
            this.lbBed.Text = "0";
            // 
            // lbRemain
            // 
            this.lbRemain.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbRemain.Location = new System.Drawing.Point(172, 39);
            this.lbRemain.Name = "lbRemain";
            this.lbRemain.Size = new System.Drawing.Size(177, 16);
            this.lbRemain.TabIndex = 6;
            this.lbRemain.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.Location = new System.Drawing.Point(355, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 16);
            this.label8.TabIndex = 5;
            this.label8.Text = "مانده:";
            // 
            // JAUTDocumentReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 495);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JAUTDocumentReportForm";
            this.Text = "گزارش اسناد و پرداختی ها";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnClose;
        private ClassLibrary.JJanusGrid grdReport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.JComboBox cmbOwners;
        private ClassLibrary.JComboBox cmbBuses;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lbRemain;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbBes;
        private System.Windows.Forms.Label lbBed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}