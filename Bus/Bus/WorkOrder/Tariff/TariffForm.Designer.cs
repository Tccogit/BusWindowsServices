namespace BusManagment.WorkOrder
{
    partial class JTariffForm
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
            this.timeEdit1 = new ClassLibrary.TimeEdit(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStartDate = new ClassLibrary.DateEdit(this.components);
            this.txtEndDate = new ClassLibrary.DateEdit(this.components);
            this.cmbLine = new ClassLibrary.JComboBox(this.components);
            this.cmbBus = new ClassLibrary.JComboBox(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbStartTime = new System.Windows.Forms.Label();
            this.lbEndTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbShift = new ClassLibrary.JComboBox(this.components);
            this.personDriver = new ClassLibrary.JUCPerson();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(572, 11);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(87, 28);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnApply
            // 
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Location = new System.Drawing.Point(127, 12);
            this.btnApply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(87, 28);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Visible = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(3, 11);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 28);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 280);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(674, 44);
            this.panel1.TabIndex = 1;
            // 
            // timeEdit1
            // 
            this.timeEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeEdit1.ChangeColorIfNotEmpty = true;
            this.timeEdit1.ChangeColorOnEnter = true;
            this.timeEdit1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.timeEdit1.InBackColor = System.Drawing.SystemColors.Info;
            this.timeEdit1.InForeColor = System.Drawing.SystemColors.WindowText;
            this.timeEdit1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.timeEdit1.Location = new System.Drawing.Point(6, 32188);
            this.timeEdit1.Mask = "00:00";
            this.timeEdit1.Name = "timeEdit1";
            this.timeEdit1.NotEmpty = false;
            this.timeEdit1.NotEmptyColor = System.Drawing.Color.Red;
            this.timeEdit1.Size = new System.Drawing.Size(58, 27);
            this.timeEdit1.TabIndex = 2;
            this.timeEdit1.ValidatingType = typeof(System.DateTime);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(634, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "خط:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(613, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "اتوبوس:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(313, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "تاریخ شروع:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(319, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "تاریخ پایان:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtStartDate
            // 
            this.txtStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartDate.ChangeColorIfNotEmpty = true;
            this.txtStartDate.ChangeColorOnEnter = true;
            this.txtStartDate.Date = new System.DateTime(((long)(0)));
            this.txtStartDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtStartDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtStartDate.InsertInDatesTable = true;
            this.txtStartDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtStartDate.Location = new System.Drawing.Point(233, 210);
            this.txtStartDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtStartDate.Mask = "0000/00/00";
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.NotEmpty = false;
            this.txtStartDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtStartDate.Size = new System.Drawing.Size(78, 23);
            this.txtStartDate.TabIndex = 3;
            // 
            // txtEndDate
            // 
            this.txtEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEndDate.ChangeColorIfNotEmpty = true;
            this.txtEndDate.ChangeColorOnEnter = true;
            this.txtEndDate.Date = new System.DateTime(((long)(0)));
            this.txtEndDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtEndDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEndDate.InsertInDatesTable = true;
            this.txtEndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtEndDate.Location = new System.Drawing.Point(233, 241);
            this.txtEndDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEndDate.Mask = "0000/00/00";
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.NotEmpty = false;
            this.txtEndDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtEndDate.Size = new System.Drawing.Size(78, 23);
            this.txtEndDate.TabIndex = 4;
            this.txtEndDate.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.dateEnd_MaskInputRejected);
            // 
            // cmbLine
            // 
            this.cmbLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbLine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLine.BaseCode = 0;
            this.cmbLine.ChangeColorIfNotEmpty = true;
            this.cmbLine.ChangeColorOnEnter = true;
            this.cmbLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbLine.FormattingEnabled = true;
            this.cmbLine.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbLine.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbLine.Location = new System.Drawing.Point(468, 208);
            this.cmbLine.Name = "cmbLine";
            this.cmbLine.NotEmpty = false;
            this.cmbLine.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbLine.SelectOnEnter = true;
            this.cmbLine.Size = new System.Drawing.Size(121, 24);
            this.cmbLine.TabIndex = 1;
            // 
            // cmbBus
            // 
            this.cmbBus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbBus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBus.BaseCode = 0;
            this.cmbBus.ChangeColorIfNotEmpty = true;
            this.cmbBus.ChangeColorOnEnter = true;
            this.cmbBus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBus.FormattingEnabled = true;
            this.cmbBus.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbBus.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbBus.Location = new System.Drawing.Point(468, 238);
            this.cmbBus.Name = "cmbBus";
            this.cmbBus.NotEmpty = false;
            this.cmbBus.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbBus.SelectOnEnter = true;
            this.cmbBus.Size = new System.Drawing.Size(121, 24);
            this.cmbBus.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lbStartTime);
            this.groupBox1.Controls.Add(this.lbEndTime);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbShift);
            this.groupBox1.Controls.Add(this.personDriver);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbBus);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbLine);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtEndDate);
            this.groupBox1.Controls.Add(this.txtStartDate);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(674, 280);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(127, 248);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 16);
            this.label9.TabIndex = 23;
            this.label9.Text = "از:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(51, 248);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 16);
            this.label8.TabIndex = 22;
            this.label8.Text = "تا:";
            // 
            // lbStartTime
            // 
            this.lbStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbStartTime.AutoSize = true;
            this.lbStartTime.ForeColor = System.Drawing.Color.Blue;
            this.lbStartTime.Location = new System.Drawing.Point(87, 248);
            this.lbStartTime.Name = "lbStartTime";
            this.lbStartTime.Size = new System.Drawing.Size(41, 16);
            this.lbStartTime.TabIndex = 21;
            this.lbStartTime.Text = "00:00";
            // 
            // lbEndTime
            // 
            this.lbEndTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbEndTime.AutoSize = true;
            this.lbEndTime.ForeColor = System.Drawing.Color.Blue;
            this.lbEndTime.Location = new System.Drawing.Point(12, 248);
            this.lbEndTime.Name = "lbEndTime";
            this.lbEndTime.Size = new System.Drawing.Size(41, 16);
            this.lbEndTime.TabIndex = 20;
            this.lbEndTime.Text = "00:00";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(139, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "شیفت:";
            // 
            // cmbShift
            // 
            this.cmbShift.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbShift.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbShift.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbShift.BaseCode = 0;
            this.cmbShift.ChangeColorIfNotEmpty = true;
            this.cmbShift.ChangeColorOnEnter = true;
            this.cmbShift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbShift.FormattingEnabled = true;
            this.cmbShift.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbShift.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbShift.Location = new System.Drawing.Point(12, 208);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.NotEmpty = false;
            this.cmbShift.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbShift.SelectOnEnter = true;
            this.cmbShift.Size = new System.Drawing.Size(121, 24);
            this.cmbShift.TabIndex = 5;
            this.cmbShift.SelectedIndexChanged += new System.EventHandler(this.cmbShift_SelectedIndexChanged);
            // 
            // personDriver
            // 
            this.personDriver.Dock = System.Windows.Forms.DockStyle.Top;
            this.personDriver.FilterPerson = null;
            this.personDriver.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.personDriver.LableGroup = null;
            this.personDriver.Location = new System.Drawing.Point(3, 19);
            this.personDriver.Name = "personDriver";
            this.personDriver.PersonType = ClassLibrary.JPersonTypes.None;
            this.personDriver.ReadOnly = false;
            this.personDriver.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.personDriver.SearchOnCode = ClassLibrary.SearchOnCode.Code;
            this.personDriver.SelectedCode = 0;
            this.personDriver.Size = new System.Drawing.Size(668, 182);
            this.personDriver.TabIndex = 0;
            this.personDriver.TafsiliCode = false;
            // 
            // JTariffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 324);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.timeEdit1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JTariffForm";
            this.Text = "تعریف حکم کار";
            this.Shown += new System.EventHandler(this.JTariffForm_Shown);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private ClassLibrary.TimeEdit timeEdit1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private ClassLibrary.DateEdit txtStartDate;
        private ClassLibrary.DateEdit txtEndDate;
        private ClassLibrary.JComboBox cmbLine;
        private ClassLibrary.JComboBox cmbBus;
        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.JUCPerson personDriver;
        private System.Windows.Forms.Label label3;
        private ClassLibrary.JComboBox cmbShift;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbStartTime;
        private System.Windows.Forms.Label lbEndTime;
    }
}