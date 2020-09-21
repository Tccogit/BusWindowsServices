namespace ClassLibrary.SMS
{
    partial class SMSSentList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMSSentList));
            ClassLibrary.JPopupMenu jPopupMenu2 = new ClassLibrary.JPopupMenu();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbSMS = new ClassLibrary.JComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgrSentList = new ClassLibrary.JDataGrid();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrSentList)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbSMS
            // 
            this.cmbSMS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbSMS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSMS.BaseCode = 0;
            this.cmbSMS.ChangeColorIfNotEmpty = true;
            this.cmbSMS.ChangeColorOnEnter = true;
            this.cmbSMS.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbSMS.FormattingEnabled = true;
            this.cmbSMS.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbSMS.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbSMS.Location = new System.Drawing.Point(0, 20);
            this.cmbSMS.Name = "cmbSMS";
            this.cmbSMS.NotEmpty = false;
            this.cmbSMS.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbSMS.SelectOnEnter = true;
            this.cmbSMS.Size = new System.Drawing.Size(669, 24);
            this.cmbSMS.TabIndex = 0;
            this.cmbSMS.SelectedIndexChanged += new System.EventHandler(this.cmbSMS_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(669, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "لیست اس ام اس های قبلی شما:";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(669, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "لیست گیرندگان اس ام اس:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 369);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel2.Size = new System.Drawing.Size(669, 58);
            this.panel2.TabIndex = 47;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.SystemColors.Control;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(520, 11);
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
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dgrSentList
            // 
            this.dgrSentList.ActionMenu = jPopupMenu2;
            this.dgrSentList.AllowUserToAddRows = false;
            this.dgrSentList.AllowUserToDeleteRows = false;
            this.dgrSentList.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dgrSentList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgrSentList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgrSentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrSentList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrSentList.EnableContexMenu = true;
            this.dgrSentList.KeyName = null;
            this.dgrSentList.Location = new System.Drawing.Point(0, 65);
            this.dgrSentList.Name = "dgrSentList";
            this.dgrSentList.ReadHeadersFromDB = false;
            this.dgrSentList.ReadOnly = true;
            this.dgrSentList.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.dgrSentList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrSentList.ShowRowNumber = true;
            this.dgrSentList.Size = new System.Drawing.Size(669, 362);
            this.dgrSentList.TabIndex = 46;
            this.dgrSentList.TableName = null;
            // 
            // SMSSentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 427);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgrSentList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbSMS);
            this.Controls.Add(this.label1);
            this.Name = "SMSSentList";
            this.Text = "SMSSentList";
            this.Load += new System.EventHandler(this.SMSSentList_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrSentList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private JComboBox cmbSMS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnExit;
        private JDataGrid dgrSentList;
    }
}