namespace ClassLibrary
{
    partial class PersonAmalkardForm
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
            ClassLibrary.JPopupMenu jPopupMenu2 = new ClassLibrary.JPopupMenu();
            ClassLibrary.JPopupMenu jPopupMenu3 = new ClassLibrary.JPopupMenu();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grdWar = new ClassLibrary.JDataGrid();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grdTahod = new ClassLibrary.JDataGrid();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.grdKhadmat = new ClassLibrary.JDataGrid();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdWar)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTahod)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdKhadmat)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(656, 544);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grdWar);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(648, 515);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "اخطاريه ها";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grdWar
            // 
            this.grdWar.ActionMenu = jPopupMenu1;
            this.grdWar.AllowUserToAddRows = false;
            this.grdWar.AllowUserToDeleteRows = false;
            this.grdWar.AllowUserToOrderColumns = true;
            this.grdWar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdWar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdWar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdWar.EnableContexMenu = true;
            this.grdWar.KeyName = null;
            this.grdWar.Location = new System.Drawing.Point(3, 4);
            this.grdWar.Name = "grdWar";
            this.grdWar.ReadHeadersFromDB = false;
            this.grdWar.ReadOnly = true;
            this.grdWar.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.grdWar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdWar.ShowRowNumber = true;
            this.grdWar.Size = new System.Drawing.Size(642, 507);
            this.grdWar.TabIndex = 0;
            this.grdWar.TableName = null;
            this.grdWar.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grdWar_MouseDoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grdTahod);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(648, 515);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "تعهدات كتبي";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grdTahod
            // 
            this.grdTahod.ActionMenu = jPopupMenu2;
            this.grdTahod.AllowUserToAddRows = false;
            this.grdTahod.AllowUserToDeleteRows = false;
            this.grdTahod.AllowUserToOrderColumns = true;
            this.grdTahod.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdTahod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTahod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTahod.EnableContexMenu = true;
            this.grdTahod.KeyName = null;
            this.grdTahod.Location = new System.Drawing.Point(3, 4);
            this.grdTahod.Name = "grdTahod";
            this.grdTahod.ReadHeadersFromDB = false;
            this.grdTahod.ReadOnly = true;
            this.grdTahod.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.grdTahod.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdTahod.ShowRowNumber = true;
            this.grdTahod.Size = new System.Drawing.Size(642, 507);
            this.grdTahod.TabIndex = 0;
            this.grdTahod.TableName = null;
            this.grdTahod.DoubleClick += new System.EventHandler(this.grdTahod_DoubleClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.grdKhadmat);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(648, 515);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "خدمات";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // grdKhadmat
            // 
            this.grdKhadmat.ActionMenu = jPopupMenu3;
            this.grdKhadmat.AllowUserToAddRows = false;
            this.grdKhadmat.AllowUserToDeleteRows = false;
            this.grdKhadmat.AllowUserToOrderColumns = true;
            this.grdKhadmat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdKhadmat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdKhadmat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdKhadmat.EnableContexMenu = true;
            this.grdKhadmat.KeyName = null;
            this.grdKhadmat.Location = new System.Drawing.Point(0, 0);
            this.grdKhadmat.Name = "grdKhadmat";
            this.grdKhadmat.ReadHeadersFromDB = false;
            this.grdKhadmat.ReadOnly = true;
            this.grdKhadmat.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.grdKhadmat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdKhadmat.ShowRowNumber = true;
            this.grdKhadmat.Size = new System.Drawing.Size(648, 515);
            this.grdKhadmat.TabIndex = 0;
            this.grdKhadmat.TableName = null;
            this.grdKhadmat.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grdKhadmat_MouseDoubleClick);
            // 
            // PersonAmalkardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 544);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PersonAmalkardForm";
            this.Text = "PersonAmalkardForm";
            this.Load += new System.EventHandler(this.PersonAmalkardForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdWar)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTahod)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdKhadmat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private JDataGrid grdWar;
        private System.Windows.Forms.TabPage tabPage2;
        private JDataGrid grdTahod;
        private System.Windows.Forms.TabPage tabPage3;
        private JDataGrid grdKhadmat;
    }
}