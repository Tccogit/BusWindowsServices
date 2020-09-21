namespace ClassLibrary
{
    partial class JSettingPrintForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JSettingPrintForm));
            this.chkLandEscape = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.chklstFields = new System.Windows.Forms.CheckedListBox();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMR = new ClassLibrary.TextEdit(this.components);
            this.txtML = new ClassLibrary.TextEdit(this.components);
            this.txtMT = new ClassLibrary.TextEdit(this.components);
            this.txtMB = new ClassLibrary.TextEdit(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHeader = new ClassLibrary.TextEdit(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtFooter = new ClassLibrary.TextEdit(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.txtTitle = new ClassLibrary.TextEdit(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.listBoxSetting = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkLandEscape
            // 
            this.chkLandEscape.AutoSize = true;
            this.chkLandEscape.Location = new System.Drawing.Point(128, 111);
            this.chkLandEscape.Name = "chkLandEscape";
            this.chkLandEscape.Size = new System.Drawing.Size(87, 20);
            this.chkLandEscape.TabIndex = 12;
            this.chkLandEscape.Text = "Landscape";
            this.chkLandEscape.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(477, 266);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(30, 30);
            this.btnOk.TabIndex = 11;
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(513, 266);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 10;
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chklstFields
            // 
            this.chklstFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chklstFields.CheckOnClick = true;
            this.chklstFields.FormattingEnabled = true;
            this.chklstFields.Location = new System.Drawing.Point(421, 3);
            this.chklstFields.Name = "chklstFields";
            this.chklstFields.Size = new System.Drawing.Size(170, 256);
            this.chklstFields.TabIndex = 9;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMR);
            this.groupBox1.Controls.Add(this.txtML);
            this.groupBox1.Controls.Add(this.txtMT);
            this.groupBox1.Controls.Add(this.txtMB);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 92);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "حاشیه ها";
            // 
            // txtMR
            // 
            this.txtMR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMR.ChangeColorIfNotEmpty = false;
            this.txtMR.ChangeColorOnEnter = true;
            this.txtMR.InBackColor = System.Drawing.SystemColors.Info;
            this.txtMR.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtMR.Location = new System.Drawing.Point(9, 51);
            this.txtMR.Name = "txtMR";
            this.txtMR.Negative = true;
            this.txtMR.NotEmpty = false;
            this.txtMR.NotEmptyColor = System.Drawing.Color.Red;
            this.txtMR.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMR.SelectOnEnter = true;
            this.txtMR.Size = new System.Drawing.Size(44, 23);
            this.txtMR.TabIndex = 17;
            this.txtMR.TextMode = ClassLibrary.TextModes.Real;
            // 
            // txtML
            // 
            this.txtML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtML.ChangeColorIfNotEmpty = false;
            this.txtML.ChangeColorOnEnter = true;
            this.txtML.InBackColor = System.Drawing.SystemColors.Info;
            this.txtML.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtML.Location = new System.Drawing.Point(9, 25);
            this.txtML.Name = "txtML";
            this.txtML.Negative = true;
            this.txtML.NotEmpty = false;
            this.txtML.NotEmptyColor = System.Drawing.Color.Red;
            this.txtML.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtML.SelectOnEnter = true;
            this.txtML.Size = new System.Drawing.Size(44, 23);
            this.txtML.TabIndex = 16;
            this.txtML.TextMode = ClassLibrary.TextModes.Real;
            // 
            // txtMT
            // 
            this.txtMT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMT.ChangeColorIfNotEmpty = false;
            this.txtMT.ChangeColorOnEnter = true;
            this.txtMT.InBackColor = System.Drawing.SystemColors.Info;
            this.txtMT.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtMT.Location = new System.Drawing.Point(112, 53);
            this.txtMT.Name = "txtMT";
            this.txtMT.Negative = true;
            this.txtMT.NotEmpty = false;
            this.txtMT.NotEmptyColor = System.Drawing.Color.Red;
            this.txtMT.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMT.SelectOnEnter = true;
            this.txtMT.Size = new System.Drawing.Size(44, 23);
            this.txtMT.TabIndex = 15;
            this.txtMT.TextMode = ClassLibrary.TextModes.Real;
            // 
            // txtMB
            // 
            this.txtMB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMB.ChangeColorIfNotEmpty = false;
            this.txtMB.ChangeColorOnEnter = true;
            this.txtMB.InBackColor = System.Drawing.SystemColors.Info;
            this.txtMB.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtMB.Location = new System.Drawing.Point(112, 24);
            this.txtMB.Name = "txtMB";
            this.txtMB.Negative = true;
            this.txtMB.NotEmpty = false;
            this.txtMB.NotEmptyColor = System.Drawing.Color.Red;
            this.txtMB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMB.SelectOnEnter = true;
            this.txtMB.Size = new System.Drawing.Size(44, 23);
            this.txtMB.TabIndex = 14;
            this.txtMB.TextMode = ClassLibrary.TextModes.Real;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "راست";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "چپ";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "بالا";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "پایین";
            // 
            // txtHeader
            // 
            this.txtHeader.ChangeColorIfNotEmpty = false;
            this.txtHeader.ChangeColorOnEnter = true;
            this.txtHeader.InBackColor = System.Drawing.SystemColors.Info;
            this.txtHeader.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtHeader.Location = new System.Drawing.Point(127, 227);
            this.txtHeader.Name = "txtHeader";
            this.txtHeader.Negative = true;
            this.txtHeader.NotEmpty = false;
            this.txtHeader.NotEmptyColor = System.Drawing.Color.Red;
            this.txtHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtHeader.SelectOnEnter = true;
            this.txtHeader.Size = new System.Drawing.Size(212, 23);
            this.txtHeader.TabIndex = 17;
            this.txtHeader.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "عنوان بالای صفحه:";
            // 
            // txtFooter
            // 
            this.txtFooter.ChangeColorIfNotEmpty = false;
            this.txtFooter.ChangeColorOnEnter = true;
            this.txtFooter.InBackColor = System.Drawing.SystemColors.Info;
            this.txtFooter.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFooter.Location = new System.Drawing.Point(127, 256);
            this.txtFooter.Name = "txtFooter";
            this.txtFooter.Negative = true;
            this.txtFooter.NotEmpty = false;
            this.txtFooter.NotEmptyColor = System.Drawing.Color.Red;
            this.txtFooter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFooter.SelectOnEnter = true;
            this.txtFooter.Size = new System.Drawing.Size(212, 23);
            this.txtFooter.TabIndex = 19;
            this.txtFooter.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "عنوان پایین صفحه:";
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.ChangeColorIfNotEmpty = false;
            this.txtTitle.ChangeColorOnEnter = true;
            this.txtTitle.InBackColor = System.Drawing.SystemColors.Info;
            this.txtTitle.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTitle.Location = new System.Drawing.Point(151, 10);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Negative = true;
            this.txtTitle.NotEmpty = false;
            this.txtTitle.NotEmptyColor = System.Drawing.Color.Red;
            this.txtTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTitle.SelectOnEnter = true;
            this.txtTitle.Size = new System.Drawing.Size(166, 23);
            this.txtTitle.TabIndex = 24;
            this.txtTitle.TextMode = ClassLibrary.TextModes.Text;
            this.txtTitle.Visible = false;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 16);
            this.label7.TabIndex = 23;
            this.label7.Text = "عنوان ذخیره شده:";
            this.label7.Visible = false;
            // 
            // listBoxSetting
            // 
            this.listBoxSetting.FormattingEnabled = true;
            this.listBoxSetting.ItemHeight = 16;
            this.listBoxSetting.Location = new System.Drawing.Point(7, 39);
            this.listBoxSetting.Name = "listBoxSetting";
            this.listBoxSetting.Size = new System.Drawing.Size(154, 180);
            this.listBoxSetting.TabIndex = 25;
            this.listBoxSetting.Visible = false;
            this.listBoxSetting.SelectedIndexChanged += new System.EventHandler(this.listBoxSetting_SelectedIndexChanged);
            // 
            // JSettingPrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 299);
            this.Controls.Add(this.chkLandEscape);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBoxSetting);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtFooter);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtHeader);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.chklstFields);
            this.Name = "JSettingPrintForm";
            this.Text = "فرم تنظیم چاپ";
            this.Load += new System.EventHandler(this.JSettingPrintForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkLandEscape;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckedListBox chklstFields;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private TextEdit txtMR;
        private TextEdit txtML;
        private TextEdit txtMT;
        private TextEdit txtMB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private TextEdit txtHeader;
        private System.Windows.Forms.Label label5;
        private TextEdit txtFooter;
        private System.Windows.Forms.Label label6;
        private TextEdit txtTitle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox listBoxSetting;
    }
}