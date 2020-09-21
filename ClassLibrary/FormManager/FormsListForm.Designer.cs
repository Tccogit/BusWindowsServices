namespace ClassLibrary.FormManager
{
    partial class JFormsListForm
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
            ClassLibrary.JPopupMenu jPopupMenu5 = new ClassLibrary.JPopupMenu();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            ClassLibrary.JPopupMenu jPopupMenu6 = new ClassLibrary.JPopupMenu();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgrItems = new ClassLibrary.JDataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbForms = new ClassLibrary.JComboBox(this.components);
            this.dgrDataTable = new ClassLibrary.JDataGrid();
            this.btnPrint = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(574, 451);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.dgrItems);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cmbForms);
            this.tabPage1.Controls.Add(this.dgrDataTable);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(566, 422);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ثبت فرم";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Location = new System.Drawing.Point(0, 364);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel1.Size = new System.Drawing.Size(570, 58);
            this.panel1.TabIndex = 46;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(421, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 40);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "نمایش فرم";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(8, 8);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(140, 40);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // dgrItems
            // 
            this.dgrItems.ActionMenu = jPopupMenu5;
            this.dgrItems.AllowUserToAddRows = false;
            this.dgrItems.AllowUserToDeleteRows = false;
            this.dgrItems.AllowUserToOrderColumns = true;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dgrItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgrItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgrItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrItems.EnableContexMenu = true;
            this.dgrItems.KeyName = null;
            this.dgrItems.Location = new System.Drawing.Point(8, 129);
            this.dgrItems.MultiSelect = false;
            this.dgrItems.Name = "dgrItems";
            this.dgrItems.ReadHeadersFromDB = false;
            this.dgrItems.ReadOnly = true;
            this.dgrItems.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.dgrItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrItems.ShowRowNumber = true;
            this.dgrItems.Size = new System.Drawing.Size(547, 229);
            this.dgrItems.TabIndex = 3;
            this.dgrItems.TableName = null;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(515, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "فرم ها";
            // 
            // cmbForms
            // 
            this.cmbForms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbForms.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbForms.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbForms.BaseCode = 0;
            this.cmbForms.ChangeColorIfNotEmpty = true;
            this.cmbForms.ChangeColorOnEnter = true;
            this.cmbForms.FormattingEnabled = true;
            this.cmbForms.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbForms.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbForms.Location = new System.Drawing.Point(6, 99);
            this.cmbForms.Name = "cmbForms";
            this.cmbForms.NotEmpty = false;
            this.cmbForms.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbForms.SelectOnEnter = true;
            this.cmbForms.Size = new System.Drawing.Size(550, 24);
            this.cmbForms.TabIndex = 1;
            this.cmbForms.SelectedIndexChanged += new System.EventHandler(this.cmbForms_SelectedIndexChanged);
            // 
            // dgrDataTable
            // 
            this.dgrDataTable.ActionMenu = jPopupMenu6;
            this.dgrDataTable.AllowUserToAddRows = false;
            this.dgrDataTable.AllowUserToDeleteRows = false;
            this.dgrDataTable.AllowUserToOrderColumns = true;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dgrDataTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgrDataTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrDataTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgrDataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrDataTable.EnableContexMenu = true;
            this.dgrDataTable.KeyName = null;
            this.dgrDataTable.Location = new System.Drawing.Point(6, 6);
            this.dgrDataTable.Name = "dgrDataTable";
            this.dgrDataTable.ReadHeadersFromDB = false;
            this.dgrDataTable.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.dgrDataTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrDataTable.ShowRowNumber = true;
            this.dgrDataTable.Size = new System.Drawing.Size(554, 60);
            this.dgrDataTable.TabIndex = 0;
            this.dgrDataTable.TableName = null;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(275, 8);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(140, 40);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "چاپ";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // JFormsListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 451);
            this.Controls.Add(this.tabControl1);
            this.Name = "JFormsListForm";
            this.Text = "ثبت فرم";
            this.Load += new System.EventHandler(this.JFormsListForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDataTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private ClassLibrary.JDataGrid dgrDataTable;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.JComboBox cmbForms;
        private ClassLibrary.JDataGrid dgrItems;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPrint;

    }
}