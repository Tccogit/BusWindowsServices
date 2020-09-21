namespace ClassLibrary
{
    partial class UC_Grid
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
            this.jasGrid = new ClassLibrary.JDataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.jasGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // jasGrid
            // 
            this.jasGrid.AllowUserToAddRows = false;
            this.jasGrid.AllowUserToDeleteRows = false;
            this.jasGrid.AllowUserToOrderColumns = true;
            this.jasGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jasGrid.EnableContexMenu = true;
            this.jasGrid.KeyName = null;
            this.jasGrid.Location = new System.Drawing.Point(0, 0);
            this.jasGrid.MultiSelect = true;
            this.jasGrid.Name = "jasGrid";
            this.jasGrid.ReadHeadersFromDB = false;
            this.jasGrid.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jasGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jasGrid.ShowRowNumber = true;
            this.jasGrid.Size = new System.Drawing.Size(358, 157);
            this.jasGrid.TabIndex = 0;
            this.jasGrid.TableName = null;
            this.jasGrid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.jasGrid_CellMouseClick);
            this.jasGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.jasGrid_CellDoubleClick);
            this.jasGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.jasGrid_MouseClick);
            this.jasGrid.SelectionChanged += new System.EventHandler(this.jasGrid_SelectionChanged);
            // 
            // UC_Grid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.jasGrid);
            this.Name = "UC_Grid";
            this.Size = new System.Drawing.Size(358, 157);
            this.Load += new System.EventHandler(this.UC_Grid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.jasGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public JDataGrid jasGrid;

    }
}
