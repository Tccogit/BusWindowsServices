namespace ClassLibrary
{
    partial class JGroupPermissionForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdPermissions = new ClassLibrary.JJanusGrid();
            this.grdObjects = new ClassLibrary.JJanusGrid();
            this.grdUsers = new ClassLibrary.JJanusGrid();
            this.checkBoxNone = new System.Windows.Forms.CheckBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblStatus = new ClassLibrary.Controllers.JAutoTypeLabel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdPermissions);
            this.groupBox1.Controls.Add(this.grdObjects);
            this.groupBox1.Controls.Add(this.grdUsers);
            this.groupBox1.Location = new System.Drawing.Point(0, 36);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(1006, 402);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // grdPermissions
            // 
            this.grdPermissions.ActionMenu = null;
            this.grdPermissions.DataSource = null;
            this.grdPermissions.Edited = false;
            this.grdPermissions.Location = new System.Drawing.Point(12, 15);
            this.grdPermissions.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grdPermissions.MultiSelect = true;
            this.grdPermissions.Name = "grdPermissions";
            this.grdPermissions.ShowNavigator = false;
            this.grdPermissions.ShowToolbar = false;
            this.grdPermissions.Size = new System.Drawing.Size(320, 378);
            this.grdPermissions.TabIndex = 1;
            // 
            // grdObjects
            // 
            this.grdObjects.ActionMenu = null;
            this.grdObjects.DataSource = null;
            this.grdObjects.Edited = false;
            this.grdObjects.Location = new System.Drawing.Point(350, 15);
            this.grdObjects.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.grdObjects.MultiSelect = true;
            this.grdObjects.Name = "grdObjects";
            this.grdObjects.ShowNavigator = false;
            this.grdObjects.ShowToolbar = false;
            this.grdObjects.Size = new System.Drawing.Size(320, 376);
            this.grdObjects.TabIndex = 11;
            // 
            // grdUsers
            // 
            this.grdUsers.ActionMenu = null;
            this.grdUsers.DataSource = null;
            this.grdUsers.Edited = false;
            this.grdUsers.Location = new System.Drawing.Point(676, 15);
            this.grdUsers.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.grdUsers.MultiSelect = false;
            this.grdUsers.Name = "grdUsers";
            this.grdUsers.ShowNavigator = false;
            this.grdUsers.ShowToolbar = false;
            this.grdUsers.Size = new System.Drawing.Size(320, 376);
            this.grdUsers.TabIndex = 6;
            // 
            // checkBoxNone
            // 
            this.checkBoxNone.AutoSize = true;
            this.checkBoxNone.Location = new System.Drawing.Point(496, 19);
            this.checkBoxNone.Name = "checkBoxNone";
            this.checkBoxNone.Size = new System.Drawing.Size(108, 20);
            this.checkBoxNone.TabIndex = 7;
            this.checkBoxNone.Text = "checkBoxNone";
            this.checkBoxNone.UseVisualStyleBackColor = true;
            this.checkBoxNone.CheckedChanged += new System.EventHandler(this.checkBoxNone_CheckedChanged);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(350, 9);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(140, 39);
            this.btnInsert.TabIndex = 6;
            this.btnInsert.Text = "درج";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(12, 9);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(140, 38);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = "حذف";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.checkBoxNone);
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.btnInsert);
            this.panel1.Location = new System.Drawing.Point(0, 447);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel1.Size = new System.Drawing.Size(1006, 58);
            this.panel1.TabIndex = 46;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(857, 8);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(140, 40);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "خروج";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblStatus.Location = new System.Drawing.Point(0, 0);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(1006, 34);
            this.lblStatus.TabIndex = 47;
            this.lblStatus.TextList = null;
            this.lblStatus.TimerInterval = 25;
            this.lblStatus.WaitTick = 100;
            // 
            // JGroupPermissionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 505);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JGroupPermissionForm";
            this.Text = "مجوزدهی ";
            this.Load += new System.EventHandler(this.JGroupPermissionForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDel;
        private ClassLibrary.JJanusGrid grdUsers;
        private ClassLibrary.JJanusGrid grdPermissions;
        private JJanusGrid grdObjects;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.CheckBox checkBoxNone;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOk;
        private ClassLibrary.Controllers.JAutoTypeLabel lblStatus;
    }
}