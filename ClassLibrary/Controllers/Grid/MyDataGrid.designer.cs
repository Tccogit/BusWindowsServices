namespace ClassLibrary
{
    partial class JDataGrid
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mnuDataGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemFrozen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.itemDisplayFields = new System.Windows.Forms.ToolStripMenuItem();
            this.itemExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.itemeSaveSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.itemDefaultSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.mnuDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuDataGrid
            // 
            this.mnuDataGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemFrozen,
            this.toolStripMenuItem3,
            this.itemDisplayFields,
            this.itemExportToExcel,
            this.toolStripSeparator1,
            this.itemeSaveSetting,
            this.itemDefaultSettings});
            this.mnuDataGrid.Name = "mnuDataGrid";
            this.mnuDataGrid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mnuDataGrid.Size = new System.Drawing.Size(155, 126);
            this.mnuDataGrid.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuDataGrid_ItemClicked);
            // 
            // itemFrozen
            // 
            this.itemFrozen.CheckOnClick = true;
            this.itemFrozen.Name = "itemFrozen";
            this.itemFrozen.Size = new System.Drawing.Size(154, 22);
            this.itemFrozen.Text = "ثابت کردن ستون";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(151, 6);
            // 
            // itemDisplayFields
            // 
            this.itemDisplayFields.Name = "itemDisplayFields";
            this.itemDisplayFields.Size = new System.Drawing.Size(154, 22);
            this.itemDisplayFields.Text = "نمایش ستونها...";
            // 
            // itemExportToExcel
            // 
            this.itemExportToExcel.Name = "itemExportToExcel";
            this.itemExportToExcel.Size = new System.Drawing.Size(154, 22);
            this.itemExportToExcel.Text = "ارسال به اکسل...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(151, 6);
            // 
            // itemeSaveSetting
            // 
            this.itemeSaveSetting.Name = "itemeSaveSetting";
            this.itemeSaveSetting.Size = new System.Drawing.Size(154, 22);
            this.itemeSaveSetting.Text = "ذخیره تنظیمات";
            // 
            // itemDefaultSettings
            // 
            this.itemDefaultSettings.Name = "itemDefaultSettings";
            this.itemDefaultSettings.Size = new System.Drawing.Size(154, 22);
            this.itemDefaultSettings.Text = "تنظیمات پیشفرض";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Microsoft Excel | *.xls";
            // 
            // JDataGrid
            // 
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.JDataGrid_CellMouseClick);
            this.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.MyDataGrid_ColumnHeaderMouseClick);
            this.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.MyDataGrid_RowPostPaint);
            this.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.JDataGrid_DataBindingComplete);
            this.mnuDataGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip mnuDataGrid;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem itemDisplayFields;
        private System.Windows.Forms.ToolStripMenuItem itemExportToExcel;
        private System.Windows.Forms.ToolStripMenuItem itemeSaveSetting;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem itemFrozen;
        private System.Windows.Forms.ToolStripMenuItem itemDefaultSettings;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
