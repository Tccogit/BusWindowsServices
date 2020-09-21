namespace ClassLibrary.SMS
{
    partial class SMSGroupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMSGroupForm));
            ClassLibrary.JPopupMenu jPopupMenu2 = new ClassLibrary.JPopupMenu();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbGroups = new ClassLibrary.JComboBox(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgrGroupDetails = new ClassLibrary.JDataGrid();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRefreshMobile = new System.Windows.Forms.Button();
            this.btnAddNonPerson = new System.Windows.Forms.Button();
            this.btnDeleteFromGroup = new System.Windows.Forms.Button();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.jQueryEditor1 = new ClassLibrary.Controllers.EditControls.JQueryEditor();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrGroupDetails)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageSize = new System.Drawing.Size(48, 48);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 427);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel1.Size = new System.Drawing.Size(861, 58);
            this.panel1.TabIndex = 44;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(712, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 40);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "ثبت تغییرات";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel2.Controls.Add(this.cmbGroups);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnEdit);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel2.Size = new System.Drawing.Size(861, 58);
            this.panel2.TabIndex = 45;
            // 
            // cmbGroups
            // 
            this.cmbGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGroups.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbGroups.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGroups.BaseCode = 0;
            this.cmbGroups.ChangeColorIfNotEmpty = true;
            this.cmbGroups.ChangeColorOnEnter = true;
            this.cmbGroups.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbGroups.FormattingEnabled = true;
            this.cmbGroups.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbGroups.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbGroups.Location = new System.Drawing.Point(148, 10);
            this.cmbGroups.Name = "cmbGroups";
            this.cmbGroups.NotEmpty = false;
            this.cmbGroups.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbGroups.SelectOnEnter = true;
            this.cmbGroups.Size = new System.Drawing.Size(467, 31);
            this.cmbGroups.TabIndex = 6;
            this.cmbGroups.SelectedIndexChanged += new System.EventHandler(this.cmbGroups_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(803, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 46);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(25, 13);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(29, 27);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(60, 13);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(29, 27);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(95, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(29, 27);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(621, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "گروه های SMS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "add_s48.png");
            this.imageList1.Images.SetKeyName(1, "delete_s48.png");
            this.imageList1.Images.SetKeyName(2, "edit_s48.png");
            this.imageList1.Images.SetKeyName(3, "Refresh_s48.png");
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(100, 35);
            this.tabControl1.Location = new System.Drawing.Point(0, 58);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(861, 369);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 46;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgrGroupDetails);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 39);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(853, 326);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "انتخابی";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgrGroupDetails
            // 
            this.dgrGroupDetails.ActionMenu = jPopupMenu2;
            this.dgrGroupDetails.AllowUserToAddRows = false;
            this.dgrGroupDetails.AllowUserToDeleteRows = false;
            this.dgrGroupDetails.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dgrGroupDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgrGroupDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgrGroupDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrGroupDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrGroupDetails.EnableContexMenu = true;
            this.dgrGroupDetails.KeyName = null;
            this.dgrGroupDetails.Location = new System.Drawing.Point(3, 48);
            this.dgrGroupDetails.Name = "dgrGroupDetails";
            this.dgrGroupDetails.ReadHeadersFromDB = false;
            this.dgrGroupDetails.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.dgrGroupDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrGroupDetails.ShowRowNumber = true;
            this.dgrGroupDetails.Size = new System.Drawing.Size(847, 275);
            this.dgrGroupDetails.TabIndex = 48;
            this.dgrGroupDetails.TableName = null;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.btnRefreshMobile);
            this.panel3.Controls.Add(this.btnAddNonPerson);
            this.panel3.Controls.Add(this.btnDeleteFromGroup);
            this.panel3.Controls.Add(this.btnAddPerson);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Enabled = false;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel3.Size = new System.Drawing.Size(847, 45);
            this.panel3.TabIndex = 49;
            // 
            // btnRefreshMobile
            // 
            this.btnRefreshMobile.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRefreshMobile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshMobile.Font = new System.Drawing.Font("Tahoma", 9.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnRefreshMobile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefreshMobile.ImageKey = "Refresh_s48.png";
            this.btnRefreshMobile.ImageList = this.imageList1;
            this.btnRefreshMobile.Location = new System.Drawing.Point(5, 3);
            this.btnRefreshMobile.Name = "btnRefreshMobile";
            this.btnRefreshMobile.Size = new System.Drawing.Size(181, 40);
            this.btnRefreshMobile.TabIndex = 4;
            this.btnRefreshMobile.Text = "به روز رسانی شماره ها";
            this.btnRefreshMobile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefreshMobile.UseVisualStyleBackColor = false;
            this.btnRefreshMobile.Click += new System.EventHandler(this.btnRefreshMobile_Click);
            // 
            // btnAddNonPerson
            // 
            this.btnAddNonPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNonPerson.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAddNonPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNonPerson.Font = new System.Drawing.Font("Tahoma", 9.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAddNonPerson.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNonPerson.ImageKey = "add_s48.png";
            this.btnAddNonPerson.ImageList = this.imageList1;
            this.btnAddNonPerson.Location = new System.Drawing.Point(648, 3);
            this.btnAddNonPerson.Name = "btnAddNonPerson";
            this.btnAddNonPerson.Size = new System.Drawing.Size(92, 40);
            this.btnAddNonPerson.TabIndex = 3;
            this.btnAddNonPerson.Text = "ناشناس";
            this.btnAddNonPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNonPerson.UseVisualStyleBackColor = false;
            this.btnAddNonPerson.Click += new System.EventHandler(this.btnAddNonPerson_Click);
            // 
            // btnDeleteFromGroup
            // 
            this.btnDeleteFromGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteFromGroup.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDeleteFromGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteFromGroup.ImageKey = "delete_s48.png";
            this.btnDeleteFromGroup.ImageList = this.imageList1;
            this.btnDeleteFromGroup.Location = new System.Drawing.Point(594, 3);
            this.btnDeleteFromGroup.Name = "btnDeleteFromGroup";
            this.btnDeleteFromGroup.Size = new System.Drawing.Size(48, 40);
            this.btnDeleteFromGroup.TabIndex = 2;
            this.btnDeleteFromGroup.UseVisualStyleBackColor = false;
            this.btnDeleteFromGroup.Click += new System.EventHandler(this.btnDeleteFromGroup_Click);
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddPerson.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAddPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPerson.Font = new System.Drawing.Font("Tahoma", 9.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAddPerson.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddPerson.ImageKey = "add_s48.png";
            this.btnAddPerson.ImageList = this.imageList1;
            this.btnAddPerson.Location = new System.Drawing.Point(746, 3);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(92, 40);
            this.btnAddPerson.TabIndex = 0;
            this.btnAddPerson.Text = "شخص";
            this.btnAddPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddPerson.UseVisualStyleBackColor = false;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.jQueryEditor1);
            this.tabPage2.Location = new System.Drawing.Point(4, 39);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(853, 326);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Query";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // jQueryEditor1
            // 
            this.jQueryEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jQueryEditor1.isSQL = true;
            this.jQueryEditor1.Location = new System.Drawing.Point(3, 3);
            this.jQueryEditor1.Name = "jQueryEditor1";
            this.jQueryEditor1.ReadOnly = true;
            this.jQueryEditor1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.jQueryEditor1.Size = new System.Drawing.Size(847, 320);
            this.jQueryEditor1.TabIndex = 0;
            this.jQueryEditor1.Text = "";
            // 
            // SMSGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 485);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "SMSGroupForm";
            this.Text = "SMSGroupForm";
            this.Load += new System.EventHandler(this.SMSGroupForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrGroupDetails)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.PictureBox pictureBox1;
        private JComboBox cmbGroups;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private JDataGrid dgrGroupDetails;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRefreshMobile;
        private System.Windows.Forms.Button btnAddNonPerson;
        private System.Windows.Forms.Button btnDeleteFromGroup;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.TabPage tabPage2;
        private ClassLibrary.Controllers.EditControls.JQueryEditor jQueryEditor1;
    }
}