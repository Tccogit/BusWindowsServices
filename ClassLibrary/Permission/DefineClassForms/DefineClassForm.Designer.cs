namespace ClassLibrary
{
    partial class JPermisionClassForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.treeClass = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemNewClass = new System.Windows.Forms.ToolStripMenuItem();
            this.editClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemNewDecision = new System.Windows.Forms.ToolStripMenuItem();
            this.editDecisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddDecision = new System.Windows.Forms.Button();
            this.btnAddClass = new System.Windows.Forms.Button();
            this.btnDelClass = new System.Windows.Forms.Button();
            this.btnDelDecision = new System.Windows.Forms.Button();
            this.cmbGroup = new ClassLibrary.JComboBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Classes:";
            // 
            // treeClass
            // 
            this.treeClass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeClass.Location = new System.Drawing.Point(12, 28);
            this.treeClass.Name = "treeClass";
            this.treeClass.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.treeClass.RightToLeftLayout = true;
            this.treeClass.Size = new System.Drawing.Size(474, 398);
            this.treeClass.TabIndex = 3;
            this.treeClass.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeClass_NodeMouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemNewClass,
            this.editClassToolStripMenuItem,
            this.itemNewDecision,
            this.editDecisionToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(147, 92);
            // 
            // itemNewClass
            // 
            this.itemNewClass.Name = "itemNewClass";
            this.itemNewClass.Size = new System.Drawing.Size(146, 22);
            this.itemNewClass.Text = "NewClass...";
            // 
            // editClassToolStripMenuItem
            // 
            this.editClassToolStripMenuItem.Name = "editClassToolStripMenuItem";
            this.editClassToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.editClassToolStripMenuItem.Text = "EditClass...";
            // 
            // itemNewDecision
            // 
            this.itemNewDecision.Name = "itemNewDecision";
            this.itemNewDecision.Size = new System.Drawing.Size(146, 22);
            this.itemNewDecision.Text = "NewDecision...";
            // 
            // editDecisionToolStripMenuItem
            // 
            this.editDecisionToolStripMenuItem.Name = "editDecisionToolStripMenuItem";
            this.editDecisionToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.editDecisionToolStripMenuItem.Text = "EditDecision...";
            // 
            // btnAddDecision
            // 
            this.btnAddDecision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddDecision.Location = new System.Drawing.Point(370, 475);
            this.btnAddDecision.Name = "btnAddDecision";
            this.btnAddDecision.Size = new System.Drawing.Size(107, 33);
            this.btnAddDecision.TabIndex = 5;
            this.btnAddDecision.Text = "NewDecision";
            this.btnAddDecision.UseVisualStyleBackColor = true;
            this.btnAddDecision.Click += new System.EventHandler(this.btnAddDecision_Click);
            // 
            // btnAddClass
            // 
            this.btnAddClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddClass.Location = new System.Drawing.Point(370, 432);
            this.btnAddClass.Name = "btnAddClass";
            this.btnAddClass.Size = new System.Drawing.Size(107, 37);
            this.btnAddClass.TabIndex = 6;
            this.btnAddClass.Text = "NewClass";
            this.btnAddClass.UseVisualStyleBackColor = true;
            this.btnAddClass.Click += new System.EventHandler(this.btnAddClass_Click);
            // 
            // btnDelClass
            // 
            this.btnDelClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelClass.Location = new System.Drawing.Point(257, 432);
            this.btnDelClass.Name = "btnDelClass";
            this.btnDelClass.Size = new System.Drawing.Size(107, 37);
            this.btnDelClass.TabIndex = 7;
            this.btnDelClass.Text = "DeleteClass";
            this.btnDelClass.UseVisualStyleBackColor = true;
            this.btnDelClass.Click += new System.EventHandler(this.btnDelClass_Click);
            // 
            // btnDelDecision
            // 
            this.btnDelDecision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelDecision.Location = new System.Drawing.Point(257, 475);
            this.btnDelDecision.Name = "btnDelDecision";
            this.btnDelDecision.Size = new System.Drawing.Size(107, 33);
            this.btnDelDecision.TabIndex = 8;
            this.btnDelDecision.Text = "DeleteDecision";
            this.btnDelDecision.UseVisualStyleBackColor = true;
            this.btnDelDecision.Click += new System.EventHandler(this.btnDelDecision_Click);
            // 
            // cmbGroup
            // 
            this.cmbGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGroup.BaseCode = 0;
            this.cmbGroup.ChangeColorIfNotEmpty = true;
            this.cmbGroup.ChangeColorOnEnter = true;
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbGroup.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbGroup.Location = new System.Drawing.Point(53, 439);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.NotEmpty = false;
            this.cmbGroup.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbGroup.SelectOnEnter = true;
            this.cmbGroup.Size = new System.Drawing.Size(178, 24);
            this.cmbGroup.TabIndex = 9;
            this.cmbGroup.SelectedIndexChanged += new System.EventHandler(this.cmbGroup_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 442);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "گروه:";
            // 
            // JPermisionClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 510);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbGroup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelDecision);
            this.Controls.Add(this.treeClass);
            this.Controls.Add(this.btnDelClass);
            this.Controls.Add(this.btnAddClass);
            this.Controls.Add(this.btnAddDecision);
            this.Name = "JPermisionClassForm";
            this.Text = "DefineClassesAndDecisions";
            this.Load += new System.EventHandler(this.JPermisionClassForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeClass;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem itemNewClass;
        private System.Windows.Forms.ToolStripMenuItem itemNewDecision;
        private System.Windows.Forms.Button btnAddDecision;
        private System.Windows.Forms.Button btnAddClass;
        private System.Windows.Forms.Button btnDelClass;
        private System.Windows.Forms.ToolStripMenuItem editClassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editDecisionToolStripMenuItem;
        private System.Windows.Forms.Button btnDelDecision;
        private JComboBox cmbGroup;
        private System.Windows.Forms.Label label2;

    }
}