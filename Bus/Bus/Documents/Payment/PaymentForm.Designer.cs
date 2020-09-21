namespace BusManagment.Documents
{
    partial class JPaymentForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbSum = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.grdReport = new ClassLibrary.JJanusGrid();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAccountNo = new ClassLibrary.TextEdit(this.components);
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIssuDate = new ClassLibrary.DateEdit(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGetFile = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPayment = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbSum);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.grdReport);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(668, 321);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "پرداختی ها";
            // 
            // lbSum
            // 
            this.lbSum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSum.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbSum.ForeColor = System.Drawing.Color.White;
            this.lbSum.Location = new System.Drawing.Point(269, 295);
            this.lbSum.Name = "lbSum";
            this.lbSum.Size = new System.Drawing.Size(233, 16);
            this.lbSum.TabIndex = 28;
            this.lbSum.Text = "0";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(508, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 27;
            this.label4.Text = "مجموع پرداختی:";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(12, 291);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 24);
            this.btnDelete.TabIndex = 26;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            this.grdReport.Size = new System.Drawing.Size(662, 299);
            this.grdReport.TabIndex = 25;
            this.grdReport.Leave += new System.EventHandler(this.grdReport_Leave);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtAccountNo);
            this.groupBox3.Controls.Add(this.txtDesc);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtIssuDate);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(668, 86);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "شماره حساب اتوبوسرانی:";
            this.label2.Visible = false;
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.ChangeColorIfNotEmpty = false;
            this.txtAccountNo.ChangeColorOnEnter = true;
            this.txtAccountNo.InBackColor = System.Drawing.SystemColors.Info;
            this.txtAccountNo.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAccountNo.Location = new System.Drawing.Point(163, 21);
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.Negative = true;
            this.txtAccountNo.NotEmpty = false;
            this.txtAccountNo.NotEmptyColor = System.Drawing.Color.Red;
            this.txtAccountNo.ReadOnly = true;
            this.txtAccountNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAccountNo.SelectOnEnter = true;
            this.txtAccountNo.Size = new System.Drawing.Size(100, 23);
            this.txtAccountNo.TabIndex = 22;
            this.txtAccountNo.Text = "1006135007 ";
            this.txtAccountNo.TextMode = ClassLibrary.TextModes.Text;
            this.txtAccountNo.Visible = false;
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
            this.txtDesc.Location = new System.Drawing.Point(163, 51);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(403, 23);
            this.txtDesc.TabIndex = 21;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(572, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "تاریخ پرداخت:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(572, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "شرح پرداخت:";
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
            this.txtIssuDate.Location = new System.Drawing.Point(466, 22);
            this.txtIssuDate.Mask = "0000/00/00";
            this.txtIssuDate.Name = "txtIssuDate";
            this.txtIssuDate.NotEmpty = false;
            this.txtIssuDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtIssuDate.ReadOnly = true;
            this.txtIssuDate.Size = new System.Drawing.Size(100, 23);
            this.txtIssuDate.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnGetFile);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnPayment);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 407);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(668, 44);
            this.panel1.TabIndex = 25;
            // 
            // btnGetFile
            // 
            this.btnGetFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetFile.Enabled = false;
            this.btnGetFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetFile.Location = new System.Drawing.Point(366, 6);
            this.btnGetFile.Name = "btnGetFile";
            this.btnGetFile.Size = new System.Drawing.Size(85, 32);
            this.btnGetFile.TabIndex = 3;
            this.btnGetFile.Text = "دریافت فایل";
            this.btnGetFile.UseVisualStyleBackColor = true;
            this.btnGetFile.Click += new System.EventHandler(this.btnGetFile_Click);
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
            // btnPayment
            // 
            this.btnPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayment.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnPayment.Location = new System.Drawing.Point(466, 6);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(188, 32);
            this.btnPayment.TabIndex = 1;
            this.btnPayment.Text = "پرداخت انجام شود";
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // JPaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 451);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel1);
            this.Name = "JPaymentForm";
            this.Text = "پرداخت";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private ClassLibrary.JJanusGrid grdReport;
        private System.Windows.Forms.GroupBox groupBox3;
        private ClassLibrary.TextEdit txtDesc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.DateEdit txtIssuDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGetFile;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.TextEdit txtAccountNo;
        private System.Windows.Forms.Label lbSum;
        private System.Windows.Forms.Label label4;

    }
}