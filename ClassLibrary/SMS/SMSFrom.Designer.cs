namespace ClassLibrary
{
    partial class JSMSFrom
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
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbGroup = new ClassLibrary.JComboBox(this.components);
            this.txtRecipient = new ClassLibrary.TextEdit(this.components);
            this.rbSendPerson = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rbGroupSend = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbSMSDevice = new ClassLibrary.JComboBox(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.lblCountSMS = new System.Windows.Forms.Label();
            this.lblLenCh = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvEmployee = new ClassLibrary.JJanusGrid();
            this.btnDel = new System.Windows.Forms.Button();
            this.GroupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.btnDel);
            this.GroupBox2.Controls.Add(this.label3);
            this.GroupBox2.Controls.Add(this.cmbGroup);
            this.GroupBox2.Controls.Add(this.txtRecipient);
            this.GroupBox2.Controls.Add(this.rbSendPerson);
            this.GroupBox2.Controls.Add(this.label1);
            this.GroupBox2.Controls.Add(this.rbGroupSend);
            this.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupBox2.Location = new System.Drawing.Point(0, 0);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(678, 91);
            this.GroupBox2.TabIndex = 4;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "ارسال SMS";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(424, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 64;
            this.label3.Text = "گروه ها :";
            // 
            // cmbGroup
            // 
            this.cmbGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGroup.BaseCode = 0;
            this.cmbGroup.ChangeColorIfNotEmpty = true;
            this.cmbGroup.ChangeColorOnEnter = true;
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbGroup.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbGroup.Location = new System.Drawing.Point(167, 55);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.NotEmpty = false;
            this.cmbGroup.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbGroup.SelectOnEnter = true;
            this.cmbGroup.Size = new System.Drawing.Size(251, 24);
            this.cmbGroup.TabIndex = 65;
            this.cmbGroup.SelectedIndexChanged += new System.EventHandler(this.cmbGroup_SelectedIndexChanged);
            // 
            // txtRecipient
            // 
            this.txtRecipient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRecipient.ChangeColorIfNotEmpty = false;
            this.txtRecipient.ChangeColorOnEnter = true;
            this.txtRecipient.Enabled = false;
            this.txtRecipient.InBackColor = System.Drawing.SystemColors.Info;
            this.txtRecipient.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRecipient.Location = new System.Drawing.Point(167, 24);
            this.txtRecipient.Name = "txtRecipient";
            this.txtRecipient.Negative = true;
            this.txtRecipient.NotEmpty = false;
            this.txtRecipient.NotEmptyColor = System.Drawing.Color.Red;
            this.txtRecipient.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRecipient.SelectOnEnter = true;
            this.txtRecipient.Size = new System.Drawing.Size(251, 23);
            this.txtRecipient.TabIndex = 63;
            this.txtRecipient.TextMode = ClassLibrary.TextModes.Text;
            // 
            // rbSendPerson
            // 
            this.rbSendPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbSendPerson.AutoSize = true;
            this.rbSendPerson.Location = new System.Drawing.Point(541, 26);
            this.rbSendPerson.Name = "rbSendPerson";
            this.rbSendPerson.Size = new System.Drawing.Size(115, 20);
            this.rbSendPerson.TabIndex = 61;
            this.rbSendPerson.Text = "ارسال به شخص";
            this.rbSendPerson.UseVisualStyleBackColor = true;
            this.rbSendPerson.CheckedChanged += new System.EventHandler(this.rbSendPerson_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(424, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 62;
            this.label1.Text = "شماره موبایل :";
            // 
            // rbGroupSend
            // 
            this.rbGroupSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbGroupSend.AutoSize = true;
            this.rbGroupSend.Checked = true;
            this.rbGroupSend.Location = new System.Drawing.Point(555, 55);
            this.rbGroupSend.Name = "rbGroupSend";
            this.rbGroupSend.Size = new System.Drawing.Size(101, 20);
            this.rbGroupSend.TabIndex = 59;
            this.rbGroupSend.TabStop = true;
            this.rbGroupSend.Text = "ارسال گروهی";
            this.rbGroupSend.UseVisualStyleBackColor = true;
            this.rbGroupSend.CheckedChanged += new System.EventHandler(this.rbGroupSend_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(633, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "متن :";
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Location = new System.Drawing.Point(12, 16);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(615, 76);
            this.txtMessage.TabIndex = 4;
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(271, 134);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(349, 24);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "S&end";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.cmbSMSDevice);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.lblCountSMS);
            this.groupBox3.Controls.Add(this.lblLenCh);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btnSend);
            this.groupBox3.Controls.Add(this.txtMessage);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 334);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(678, 164);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(528, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 16);
            this.label6.TabIndex = 67;
            this.label6.Text = "ارسال با چه وسیله :";
            // 
            // cmbSMSDevice
            // 
            this.cmbSMSDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSMSDevice.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbSMSDevice.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSMSDevice.BaseCode = 0;
            this.cmbSMSDevice.ChangeColorIfNotEmpty = true;
            this.cmbSMSDevice.ChangeColorOnEnter = true;
            this.cmbSMSDevice.FormattingEnabled = true;
            this.cmbSMSDevice.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbSMSDevice.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbSMSDevice.Location = new System.Drawing.Point(271, 98);
            this.cmbSMSDevice.Name = "cmbSMSDevice";
            this.cmbSMSDevice.NotEmpty = false;
            this.cmbSMSDevice.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbSMSDevice.SelectOnEnter = true;
            this.cmbSMSDevice.Size = new System.Drawing.Size(251, 24);
            this.cmbSMSDevice.TabIndex = 68;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 66;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblCountSMS
            // 
            this.lblCountSMS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCountSMS.AutoSize = true;
            this.lblCountSMS.BackColor = System.Drawing.Color.Transparent;
            this.lblCountSMS.ForeColor = System.Drawing.Color.DarkRed;
            this.lblCountSMS.Location = new System.Drawing.Point(91, 127);
            this.lblCountSMS.Name = "lblCountSMS";
            this.lblCountSMS.Size = new System.Drawing.Size(15, 16);
            this.lblCountSMS.TabIndex = 13;
            this.lblCountSMS.Text = "0";
            // 
            // lblLenCh
            // 
            this.lblLenCh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLenCh.AutoSize = true;
            this.lblLenCh.BackColor = System.Drawing.Color.Transparent;
            this.lblLenCh.ForeColor = System.Drawing.Color.DarkRed;
            this.lblLenCh.Location = new System.Drawing.Point(91, 104);
            this.lblLenCh.Name = "lblLenCh";
            this.lblLenCh.Size = new System.Drawing.Size(15, 16);
            this.lblLenCh.TabIndex = 12;
            this.lblLenCh.Text = "0";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(167, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "تعداد SMS :";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(166, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "تعداد کارکتر:";
            // 
            // dgvEmployee
            // 
            this.dgvEmployee.ActionClassName = "";
            this.dgvEmployee.ActionMenu = null;
            this.dgvEmployee.DataSource = null;
            this.dgvEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmployee.Edited = false;
            this.dgvEmployee.Location = new System.Drawing.Point(0, 91);
            this.dgvEmployee.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dgvEmployee.MultiSelect = true;
            this.dgvEmployee.Name = "dgvEmployee";
            this.dgvEmployee.ShowNavigator = true;
            this.dgvEmployee.ShowToolbar = true;
            this.dgvEmployee.Size = new System.Drawing.Size(678, 243);
            this.dgvEmployee.TabIndex = 67;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(12, 20);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 25);
            this.btnDel.TabIndex = 68;
            this.btnDel.Text = "حذف";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // JSMSFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 498);
            this.Controls.Add(this.dgvEmployee);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.GroupBox2);
            this.Name = "JSMSFrom";
            this.Text = "SMSFrom";
            this.Load += new System.EventHandler(this.JSMSFrom_Load);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.TextBox txtMessage;
        internal System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCountSMS;
        private System.Windows.Forms.Label lblLenCh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private JComboBox cmbGroup;
        private TextEdit txtRecipient;
        private System.Windows.Forms.RadioButton rbSendPerson;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbGroupSend;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private JComboBox cmbSMSDevice;
        private JJanusGrid dgvEmployee;
        private System.Windows.Forms.Button btnDel;
    }
}