namespace ClassLibrary
{
    partial class FormFormule
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
            this.CMSFormuleManager = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TxtFormule = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.BTNInsert = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.chNumeric = new System.Windows.Forms.CheckBox();
            this.cbxAllUsers = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtBoxFName = new System.Windows.Forms.TextBox();
            this.LBFields = new System.Windows.Forms.ListBox();
            this.LBFormuleList = new System.Windows.Forms.ListBox();
            this.CMSFormuleManager.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CMSFormuleManager
            // 
            this.CMSFormuleManager.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.CMSFormuleManager.Name = "CMSFormuleManager";
            this.CMSFormuleManager.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(589, 490);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.TxtFormule);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.chNumeric);
            this.tabPage1.Controls.Add(this.cbxAllUsers);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.TxtBoxFName);
            this.tabPage1.Controls.Add(this.LBFields);
            this.tabPage1.Controls.Add(this.LBFormuleList);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(581, 464);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Formula";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // TxtFormule
            // 
            this.TxtFormule.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFormule.Location = new System.Drawing.Point(186, 209);
            this.TxtFormule.Name = "TxtFormule";
            this.TxtFormule.Size = new System.Drawing.Size(386, 160);
            this.TxtFormule.TabIndex = 45;
            this.TxtFormule.Text = "";
            this.TxtFormule.TextChanged += new System.EventHandler(this.TxtFormule_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.BTNInsert);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Location = new System.Drawing.Point(0, 406);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel1.Size = new System.Drawing.Size(581, 58);
            this.panel1.TabIndex = 44;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 40);
            this.button2.TabIndex = 11;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // BTNInsert
            // 
            this.BTNInsert.Location = new System.Drawing.Point(436, 11);
            this.BTNInsert.Name = "BTNInsert";
            this.BTNInsert.Size = new System.Drawing.Size(139, 38);
            this.BTNInsert.TabIndex = 16;
            this.BTNInsert.Text = "OK";
            this.BTNInsert.UseVisualStyleBackColor = true;
            this.BTNInsert.Click += new System.EventHandler(this.BTNInsert_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(291, 11);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(139, 38);
            this.btnNew.TabIndex = 10;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.button1_Click);
            // 
            // chNumeric
            // 
            this.chNumeric.AutoSize = true;
            this.chNumeric.Location = new System.Drawing.Point(347, 375);
            this.chNumeric.Name = "chNumeric";
            this.chNumeric.Size = new System.Drawing.Size(65, 17);
            this.chNumeric.TabIndex = 17;
            this.chNumeric.Text = "Numeric";
            this.chNumeric.UseVisualStyleBackColor = true;
            // 
            // cbxAllUsers
            // 
            this.cbxAllUsers.AutoSize = true;
            this.cbxAllUsers.Location = new System.Drawing.Point(186, 375);
            this.cbxAllUsers.Name = "cbxAllUsers";
            this.cbxAllUsers.Size = new System.Drawing.Size(106, 17);
            this.cbxAllUsers.TabIndex = 17;
            this.cbxAllUsers.Text = "Show to all users";
            this.cbxAllUsers.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Fields:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(534, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(525, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Formule:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(494, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Formule Name:";
            // 
            // TxtBoxFName
            // 
            this.TxtBoxFName.Location = new System.Drawing.Point(186, 159);
            this.TxtBoxFName.Name = "TxtBoxFName";
            this.TxtBoxFName.Size = new System.Drawing.Size(386, 20);
            this.TxtBoxFName.TabIndex = 9;
            // 
            // LBFields
            // 
            this.LBFields.FormattingEnabled = true;
            this.LBFields.Location = new System.Drawing.Point(8, 157);
            this.LBFields.Name = "LBFields";
            this.LBFields.Size = new System.Drawing.Size(172, 212);
            this.LBFields.TabIndex = 6;
            this.LBFields.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LBFields_MouseDoubleClick);
            // 
            // LBFormuleList
            // 
            this.LBFormuleList.ContextMenuStrip = this.CMSFormuleManager;
            this.LBFormuleList.FormattingEnabled = true;
            this.LBFormuleList.Location = new System.Drawing.Point(8, 27);
            this.LBFormuleList.Name = "LBFormuleList";
            this.LBFormuleList.Size = new System.Drawing.Size(564, 95);
            this.LBFormuleList.TabIndex = 7;
            this.LBFormuleList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LBFormuleList_MouseDoubleClick);
            // 
            // FormFormule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 490);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFormule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormFormule";
            this.Load += new System.EventHandler(this.FormFormule_Load);
            this.CMSFormuleManager.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip CMSFormuleManager;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button BTNInsert;
        private System.Windows.Forms.CheckBox cbxAllUsers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox TxtBoxFName;
        private System.Windows.Forms.ListBox LBFields;
        private System.Windows.Forms.ListBox LBFormuleList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox TxtFormule;
		private System.Windows.Forms.CheckBox chNumeric;

    }
}