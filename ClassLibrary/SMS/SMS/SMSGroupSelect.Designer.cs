namespace ClassLibrary.SMS
{
    partial class SMSGroupSelect
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
            ClassLibrary.JPopupMenu jPopupMenu1 = new ClassLibrary.JPopupMenu();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMSGroupSelect));
            this.dgrGroups = new ClassLibrary.JDataGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnManageGroups = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgrGroups)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgrGroups
            // 
            this.dgrGroups.ActionMenu = jPopupMenu1;
            this.dgrGroups.AllowUserToAddRows = false;
            this.dgrGroups.AllowUserToDeleteRows = false;
            this.dgrGroups.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dgrGroups.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrGroups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgrGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrGroups.EnableContexMenu = true;
            this.dgrGroups.KeyName = null;
            this.dgrGroups.Location = new System.Drawing.Point(0, 0);
            this.dgrGroups.Name = "dgrGroups";
            this.dgrGroups.ReadHeadersFromDB = false;
            this.dgrGroups.ReadOnly = true;
            this.dgrGroups.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.dgrGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrGroups.ShowRowNumber = true;
            this.dgrGroups.Size = new System.Drawing.Size(475, 284);
            this.dgrGroups.TabIndex = 0;
            this.dgrGroups.TableName = null;
            this.dgrGroups.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgrGroups_MouseDoubleClick);
            this.dgrGroups.SelectionChanged += new System.EventHandler(this.dgrGroups_SelectionChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.btnManageGroups);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 226);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel2.Size = new System.Drawing.Size(475, 58);
            this.panel2.TabIndex = 45;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.SystemColors.Control;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(326, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(140, 40);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "افزودن به لیست";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.Control;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(6, 11);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(140, 40);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "بازگشت";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnManageGroups
            // 
            this.btnManageGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManageGroups.BackColor = System.Drawing.SystemColors.Control;
            this.btnManageGroups.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageGroups.Image = ((System.Drawing.Image)(resources.GetObject("btnManageGroups.Image")));
            this.btnManageGroups.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageGroups.Location = new System.Drawing.Point(180, 11);
            this.btnManageGroups.Name = "btnManageGroups";
            this.btnManageGroups.Size = new System.Drawing.Size(140, 40);
            this.btnManageGroups.TabIndex = 13;
            this.btnManageGroups.Text = "مدیریت گروه ها";
            this.btnManageGroups.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnManageGroups.UseVisualStyleBackColor = false;
            this.btnManageGroups.Click += new System.EventHandler(this.btnManageGroups_Click);
            // 
            // SMSGroupSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 284);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgrGroups);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SMSGroupSelect";
            this.Text = "SMSGroupSelect";
            this.Load += new System.EventHandler(this.SMSGroupSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrGroups)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private JDataGrid dgrGroups;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnManageGroups;
    }
}