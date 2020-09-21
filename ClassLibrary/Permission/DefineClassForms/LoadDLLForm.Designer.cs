namespace ClassLibrary
{
    partial class JPermissionLoadDLLForm
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
			this.btnDelete = new System.Windows.Forms.Button();
			this.txtFunctionName = new System.Windows.Forms.TextBox();
			this.btnAdd = new System.Windows.Forms.Button();
			this.listView1 = new System.Windows.Forms.ListView();
			this.treeClass = new System.Windows.Forms.TreeView();
			this.cmbGroup = new ClassLibrary.JComboBox(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.lbPermission = new System.Windows.Forms.ListBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDelete.Location = new System.Drawing.Point(2, 7);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(44, 34);
			this.btnDelete.TabIndex = 7;
			this.btnDelete.Text = "-";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// txtFunctionName
			// 
			this.txtFunctionName.BackColor = System.Drawing.SystemColors.Window;
			this.txtFunctionName.Dock = System.Windows.Forms.DockStyle.Top;
			this.txtFunctionName.Location = new System.Drawing.Point(0, 44);
			this.txtFunctionName.Name = "txtFunctionName";
			this.txtFunctionName.ReadOnly = true;
			this.txtFunctionName.Size = new System.Drawing.Size(223, 23);
			this.txtFunctionName.TabIndex = 6;
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAdd.Location = new System.Drawing.Point(52, 7);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(44, 34);
			this.btnAdd.TabIndex = 5;
			this.btnAdd.Text = "+";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// listView1
			// 
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(0, 67);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(223, 98);
			this.listView1.TabIndex = 4;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.List;
			// 
			// treeClass
			// 
			this.treeClass.Dock = System.Windows.Forms.DockStyle.Top;
			this.treeClass.HideSelection = false;
			this.treeClass.Location = new System.Drawing.Point(0, 40);
			this.treeClass.Name = "treeClass";
			this.treeClass.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.treeClass.RightToLeftLayout = true;
			this.treeClass.Size = new System.Drawing.Size(223, 327);
			this.treeClass.TabIndex = 3;
			this.treeClass.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeClass_NodeMouseDoubleClick);
			// 
			// cmbGroup
			// 
			this.cmbGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.cmbGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbGroup.BaseCode = 0;
			this.cmbGroup.ChangeColorIfNotEmpty = true;
			this.cmbGroup.ChangeColorOnEnter = true;
			this.cmbGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.cmbGroup.FormattingEnabled = true;
			this.cmbGroup.InBackColor = System.Drawing.SystemColors.Info;
			this.cmbGroup.InForeColor = System.Drawing.SystemColors.WindowText;
			this.cmbGroup.Location = new System.Drawing.Point(0, 16);
			this.cmbGroup.Name = "cmbGroup";
			this.cmbGroup.NotEmpty = false;
			this.cmbGroup.NotEmptyColor = System.Drawing.Color.Red;
			this.cmbGroup.SelectOnEnter = true;
			this.cmbGroup.Size = new System.Drawing.Size(223, 24);
			this.cmbGroup.TabIndex = 10;
			this.cmbGroup.SelectedIndexChanged += new System.EventHandler(this.cmbGroup_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 16);
			this.label1.TabIndex = 11;
			this.label1.Text = "Project:";
			// 
			// lbPermission
			// 
			this.lbPermission.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbPermission.FormattingEnabled = true;
			this.lbPermission.ItemHeight = 16;
			this.lbPermission.Location = new System.Drawing.Point(223, 0);
			this.lbPermission.Name = "lbPermission";
			this.lbPermission.Size = new System.Drawing.Size(386, 532);
			this.lbPermission.TabIndex = 12;
			this.lbPermission.SelectedIndexChanged += new System.EventHandler(this.lbPermission_SelectedIndexChanged);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.treeClass);
			this.panel1.Controls.Add(this.cmbGroup);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(223, 532);
			this.panel1.TabIndex = 13;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.listView1);
			this.panel2.Controls.Add(this.txtFunctionName);
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 367);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(223, 165);
			this.panel2.TabIndex = 12;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.btnAdd);
			this.panel3.Controls.Add(this.btnDelete);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(223, 44);
			this.panel3.TabIndex = 6;
			// 
			// JPermissionLoadDLLForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(609, 532);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.lbPermission);
			this.Name = "JPermissionLoadDLLForm";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Text = "LoadDLLForm";
			this.Load += new System.EventHandler(this.JPermissionLoadDLLForm_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.TreeView treeClass;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtFunctionName;
        private System.Windows.Forms.Button btnDelete;
        private JComboBox cmbGroup;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox lbPermission;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
    }
}