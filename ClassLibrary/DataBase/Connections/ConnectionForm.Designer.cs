namespace ClassLibrary
{
    partial class JConnectionForm
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
            ClassLibrary.JPopupMenu jPopupMenu2 = new ClassLibrary.JPopupMenu();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.txtDataBase = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtObjectCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.treeFunctions = new System.Windows.Forms.TreeView();
            this.btnDel = new System.Windows.Forms.Button();
            this.jdgvConnection = new ClassLibrary.JDataGrid();
            this.cmbDataBaseType = new System.Windows.Forms.ComboBox();
            this.lbDataBaseType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvConnection)).BeginInit();
            this.SuspendLayout();
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(484, 83);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtServerName.Size = new System.Drawing.Size(156, 23);
            this.txtServerName.TabIndex = 3;
            // 
            // txtDataBase
            // 
            this.txtDataBase.Location = new System.Drawing.Point(484, 112);
            this.txtDataBase.Name = "txtDataBase";
            this.txtDataBase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDataBase.Size = new System.Drawing.Size(156, 23);
            this.txtDataBase.TabIndex = 4;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(484, 141);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUserName.Size = new System.Drawing.Size(156, 23);
            this.txtUserName.TabIndex = 5;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(484, 172);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPassword.Size = new System.Drawing.Size(156, 23);
            this.txtPassword.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(364, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "servername";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(364, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "databasename";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(364, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "username";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(364, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "password";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(484, 212);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(397, 212);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtObjectCode
            // 
            this.txtObjectCode.Location = new System.Drawing.Point(484, 24);
            this.txtObjectCode.Name = "txtObjectCode";
            this.txtObjectCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtObjectCode.Size = new System.Drawing.Size(156, 23);
            this.txtObjectCode.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(364, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "ObjectCode";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "ClassNameList";
            // 
            // treeFunctions
            // 
            this.treeFunctions.Location = new System.Drawing.Point(12, 24);
            this.treeFunctions.Name = "treeFunctions";
            this.treeFunctions.RightToLeftLayout = true;
            this.treeFunctions.Size = new System.Drawing.Size(322, 212);
            this.treeFunctions.TabIndex = 1;
            this.treeFunctions.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeFunctions_NodeMouseClick);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(565, 212);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 9;
            this.btnDel.Text = "Delete";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // jdgvConnection
            // 
            this.jdgvConnection.ActionMenu = jPopupMenu2;
            this.jdgvConnection.AllowUserToAddRows = false;
            this.jdgvConnection.AllowUserToDeleteRows = false;
            this.jdgvConnection.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.jdgvConnection.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.jdgvConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.jdgvConnection.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jdgvConnection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvConnection.EnableContexMenu = true;
            this.jdgvConnection.KeyName = null;
            this.jdgvConnection.Location = new System.Drawing.Point(12, 247);
            this.jdgvConnection.Name = "jdgvConnection";
            this.jdgvConnection.ReadHeadersFromDB = false;
            this.jdgvConnection.ReadOnly = true;
            this.jdgvConnection.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvConnection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvConnection.ShowRowNumber = true;
            this.jdgvConnection.Size = new System.Drawing.Size(628, 125);
            this.jdgvConnection.TabIndex = 11;
            this.jdgvConnection.TableName = null;
            // 
            // cmbDataBaseType
            // 
            this.cmbDataBaseType.FormattingEnabled = true;
            this.cmbDataBaseType.Location = new System.Drawing.Point(484, 53);
            this.cmbDataBaseType.Name = "cmbDataBaseType";
            this.cmbDataBaseType.Size = new System.Drawing.Size(156, 24);
            this.cmbDataBaseType.TabIndex = 14;
            // 
            // lbDataBaseType
            // 
            this.lbDataBaseType.AutoSize = true;
            this.lbDataBaseType.Location = new System.Drawing.Point(364, 56);
            this.lbDataBaseType.Name = "lbDataBaseType";
            this.lbDataBaseType.Size = new System.Drawing.Size(89, 16);
            this.lbDataBaseType.TabIndex = 2;
            this.lbDataBaseType.Text = "DataBaseType";
            // 
            // JConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 387);
            this.Controls.Add(this.cmbDataBaseType);
            this.Controls.Add(this.jdgvConnection);
            this.Controls.Add(this.treeFunctions);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbDataBaseType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtDataBase);
            this.Controls.Add(this.txtObjectCode);
            this.Controls.Add(this.txtServerName);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JConnectionForm";
            this.Text = "Connections";
            this.Load += new System.EventHandler(this.JConnectionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.jdgvConnection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.TextBox txtDataBase;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtObjectCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TreeView treeFunctions;
        private System.Windows.Forms.Button btnDel;
        private JDataGrid jdgvConnection;
        private System.Windows.Forms.ComboBox cmbDataBaseType;
        private System.Windows.Forms.Label lbDataBaseType;
    }
}