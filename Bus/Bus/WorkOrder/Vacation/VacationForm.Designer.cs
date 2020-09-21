namespace BusManagment.WorkOrder
{
    partial class JVacationForm
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grp = new System.Windows.Forms.GroupBox();
            this.cmbVationType = new ClassLibrary.JComboBox(this.components);
            this.personDriver = new ClassLibrary.JUCPerson();
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.txtToTime = new ClassLibrary.TimeEdit(this.components);
            this.txtToDate = new ClassLibrary.DateEdit(this.components);
            this.txtFromTime = new ClassLibrary.TimeEdit(this.components);
            this.txtFromDate = new ClassLibrary.DateEdit(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.grp.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 313);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(614, 38);
            this.panel1.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(520, 4);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(87, 28);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(3, 6);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 28);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grp
            // 
            this.grp.Controls.Add(this.cmbVationType);
            this.grp.Controls.Add(this.personDriver);
            this.grp.Controls.Add(this.txtDesc);
            this.grp.Controls.Add(this.txtToTime);
            this.grp.Controls.Add(this.txtToDate);
            this.grp.Controls.Add(this.txtFromTime);
            this.grp.Controls.Add(this.txtFromDate);
            this.grp.Controls.Add(this.label8);
            this.grp.Controls.Add(this.label9);
            this.grp.Controls.Add(this.label6);
            this.grp.Controls.Add(this.label5);
            this.grp.Controls.Add(this.label2);
            this.grp.Controls.Add(this.label1);
            this.grp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grp.Location = new System.Drawing.Point(0, 0);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(614, 313);
            this.grp.TabIndex = 0;
            this.grp.TabStop = false;
            // 
            // cmbVationType
            // 
            this.cmbVationType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbVationType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbVationType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbVationType.BaseCode = 0;
            this.cmbVationType.ChangeColorIfNotEmpty = true;
            this.cmbVationType.ChangeColorOnEnter = true;
            this.cmbVationType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbVationType.FormattingEnabled = true;
            this.cmbVationType.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbVationType.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbVationType.Location = new System.Drawing.Point(291, 209);
            this.cmbVationType.Name = "cmbVationType";
            this.cmbVationType.NotEmpty = false;
            this.cmbVationType.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbVationType.SelectOnEnter = true;
            this.cmbVationType.Size = new System.Drawing.Size(224, 24);
            this.cmbVationType.TabIndex = 1;
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
            //this.personDriver.ShowPersonImage = true;
            this.personDriver.Size = new System.Drawing.Size(608, 181);
            this.personDriver.TabIndex = 0;
            this.personDriver.TafsiliCode = false;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.ChangeColorIfNotEmpty = false;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(6, 233);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(239, 65);
            this.txtDesc.TabIndex = 6;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtToTime
            // 
            this.txtToTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToTime.ChangeColorIfNotEmpty = true;
            this.txtToTime.ChangeColorOnEnter = true;
            this.txtToTime.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtToTime.InBackColor = System.Drawing.SystemColors.Info;
            this.txtToTime.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtToTime.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtToTime.Location = new System.Drawing.Point(291, 273);
            this.txtToTime.Mask = "00:00";
            this.txtToTime.Name = "txtToTime";
            this.txtToTime.NotEmpty = false;
            this.txtToTime.NotEmptyColor = System.Drawing.Color.Red;
            this.txtToTime.Size = new System.Drawing.Size(58, 27);
            this.txtToTime.TabIndex = 5;
            this.txtToTime.ValidatingType = typeof(System.DateTime);
            // 
            // txtToDate
            // 
            this.txtToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToDate.ChangeColorIfNotEmpty = true;
            this.txtToDate.ChangeColorOnEnter = true;
            this.txtToDate.Date = new System.DateTime(((long)(0)));
            this.txtToDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtToDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtToDate.InsertInDatesTable = true;
            this.txtToDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtToDate.Location = new System.Drawing.Point(415, 275);
            this.txtToDate.Mask = "0000/00/00";
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.NotEmpty = false;
            this.txtToDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtToDate.Size = new System.Drawing.Size(100, 23);
            this.txtToDate.TabIndex = 4;
            // 
            // txtFromTime
            // 
            this.txtFromTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFromTime.ChangeColorIfNotEmpty = true;
            this.txtFromTime.ChangeColorOnEnter = true;
            this.txtFromTime.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtFromTime.InBackColor = System.Drawing.SystemColors.Info;
            this.txtFromTime.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFromTime.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtFromTime.Location = new System.Drawing.Point(291, 239);
            this.txtFromTime.Mask = "00:00";
            this.txtFromTime.Name = "txtFromTime";
            this.txtFromTime.NotEmpty = false;
            this.txtFromTime.NotEmptyColor = System.Drawing.Color.Red;
            this.txtFromTime.Size = new System.Drawing.Size(58, 27);
            this.txtFromTime.TabIndex = 3;
            this.txtFromTime.ValidatingType = typeof(System.DateTime);
            // 
            // txtFromDate
            // 
            this.txtFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFromDate.ChangeColorIfNotEmpty = true;
            this.txtFromDate.ChangeColorOnEnter = true;
            this.txtFromDate.Date = new System.DateTime(((long)(0)));
            this.txtFromDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtFromDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFromDate.InsertInDatesTable = true;
            this.txtFromDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtFromDate.Location = new System.Drawing.Point(415, 241);
            this.txtFromDate.Mask = "0000/00/00";
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.NotEmpty = false;
            this.txtFromDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtFromDate.Size = new System.Drawing.Size(100, 23);
            this.txtFromDate.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(355, 275);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 16);
            this.label8.TabIndex = 8;
            this.label8.Text = "ساعت:";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(525, 275);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 16);
            this.label9.TabIndex = 7;
            this.label9.Text = "تا تاریخ:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(355, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "ساعت:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(525, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "از تاریخ:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "توضیحات:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(525, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "نوع مرخصی:";
            // 
            // JVacationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 351);
            this.Controls.Add(this.grp);
            this.Controls.Add(this.panel1);
            this.Name = "JVacationForm";
            this.Text = "مرخصی";
            this.panel1.ResumeLayout(false);
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grp;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.TextEdit txtDesc;
        private ClassLibrary.TimeEdit txtToTime;
        private ClassLibrary.DateEdit txtToDate;
        private ClassLibrary.TimeEdit txtFromTime;
        private ClassLibrary.DateEdit txtFromDate;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClose;
        private ClassLibrary.JUCPerson personDriver;
        private ClassLibrary.JComboBox cmbVationType;

    }
}