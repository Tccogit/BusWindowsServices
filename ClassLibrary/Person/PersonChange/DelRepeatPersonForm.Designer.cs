namespace ClassLibrary
{
    partial class DelRepeatPersonForm
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.grdAllPerson = new ClassLibrary.JJanusGrid();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnEdit = new System.Windows.Forms.Button();
			this.chShMelli = new System.Windows.Forms.CheckBox();
			this.chShSh = new System.Windows.Forms.CheckBox();
			this.chFatherName = new System.Windows.Forms.CheckBox();
			this.chName = new System.Windows.Forms.CheckBox();
			this.grdRepeatPerson = new ClassLibrary.JDataGrid();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnDel = new System.Windows.Forms.Button();
			this.btnView = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.LBPersonFields = new ClassLibrary.JJanusGrid();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnRemove = new System.Windows.Forms.Button();
			this.btnSet = new System.Windows.Forms.Button();
			this.LBAllFields = new ClassLibrary.JJanusGrid();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.LBShowData = new ClassLibrary.JJanusGrid();
			this.button2 = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdRepeatPerson)).BeginInit();
			this.panel2.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.RightToLeftLayout = true;
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(935, 506);
			this.tabControl1.TabIndex = 4;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.grdAllPerson);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Controls.Add(this.grdRepeatPerson);
			this.tabPage1.Controls.Add(this.panel2);
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(927, 477);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "حذف افراد تکراری";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// grdAllPerson
			// 
			this.grdAllPerson.ActionClassName = "";
			this.grdAllPerson.ActionMenu = null;
			this.grdAllPerson.DataSource = null;
			this.grdAllPerson.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdAllPerson.Edited = false;
			this.grdAllPerson.Location = new System.Drawing.Point(3, 55);
			this.grdAllPerson.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.grdAllPerson.MultiSelect = true;
			this.grdAllPerson.Name = "grdAllPerson";
			this.grdAllPerson.ShowNavigator = true;
			this.grdAllPerson.ShowToolbar = true;
			this.grdAllPerson.Size = new System.Drawing.Size(921, 224);
			this.grdAllPerson.TabIndex = 10;
			this.grdAllPerson.OnRowSelectionClick += new ClassLibrary.JJanusGrid.RowSelectionClick(this.grdAllPerson_OnRowSelectionClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnEdit);
			this.groupBox1.Controls.Add(this.chShMelli);
			this.groupBox1.Controls.Add(this.chShSh);
			this.groupBox1.Controls.Add(this.chFatherName);
			this.groupBox1.Controls.Add(this.chName);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(921, 52);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "فیلتر بر اساس:";
			// 
			// btnEdit
			// 
			this.btnEdit.Location = new System.Drawing.Point(23, 18);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(108, 28);
			this.btnEdit.TabIndex = 1;
			this.btnEdit.Text = "ویرایش";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// chShMelli
			// 
			this.chShMelli.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chShMelli.AutoSize = true;
			this.chShMelli.Location = new System.Drawing.Point(351, 27);
			this.chShMelli.Name = "chShMelli";
			this.chShMelli.Size = new System.Drawing.Size(69, 20);
			this.chShMelli.TabIndex = 3;
			this.chShMelli.Text = "کد ملی";
			this.chShMelli.UseVisualStyleBackColor = true;
			this.chShMelli.CheckedChanged += new System.EventHandler(this.chName_CheckedChanged);
			// 
			// chShSh
			// 
			this.chShSh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chShSh.AutoSize = true;
			this.chShSh.Location = new System.Drawing.Point(488, 27);
			this.chShSh.Name = "chShSh";
			this.chShSh.Size = new System.Drawing.Size(125, 20);
			this.chShSh.TabIndex = 2;
			this.chShSh.Text = "شماره شناسنامه";
			this.chShSh.UseVisualStyleBackColor = true;
			this.chShSh.CheckedChanged += new System.EventHandler(this.chName_CheckedChanged);
			// 
			// chFatherName
			// 
			this.chFatherName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chFatherName.AutoSize = true;
			this.chFatherName.Location = new System.Drawing.Point(676, 27);
			this.chFatherName.Name = "chFatherName";
			this.chFatherName.Size = new System.Drawing.Size(63, 20);
			this.chFatherName.TabIndex = 1;
			this.chFatherName.Text = "نام پدر";
			this.chFatherName.UseVisualStyleBackColor = true;
			this.chFatherName.CheckedChanged += new System.EventHandler(this.chName_CheckedChanged);
			// 
			// chName
			// 
			this.chName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chName.AutoSize = true;
			this.chName.Checked = true;
			this.chName.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chName.Location = new System.Drawing.Point(785, 27);
			this.chName.Name = "chName";
			this.chName.Size = new System.Drawing.Size(127, 20);
			this.chName.TabIndex = 0;
			this.chName.Text = "نام و نام خانوادگی";
			this.chName.UseVisualStyleBackColor = true;
			this.chName.CheckedChanged += new System.EventHandler(this.chName_CheckedChanged);
			// 
			// grdRepeatPerson
			// 
			this.grdRepeatPerson.ActionMenu = jPopupMenu1;
			this.grdRepeatPerson.AllowUserToAddRows = false;
			this.grdRepeatPerson.AllowUserToDeleteRows = false;
			this.grdRepeatPerson.AllowUserToOrderColumns = true;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
			this.grdRepeatPerson.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.grdRepeatPerson.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.grdRepeatPerson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdRepeatPerson.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.grdRepeatPerson.EnableContexMenu = true;
			this.grdRepeatPerson.KeyName = null;
			this.grdRepeatPerson.Location = new System.Drawing.Point(3, 279);
			this.grdRepeatPerson.Name = "grdRepeatPerson";
			this.grdRepeatPerson.ReadHeadersFromDB = false;
			this.grdRepeatPerson.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
			this.grdRepeatPerson.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grdRepeatPerson.ShowRowNumber = true;
			this.grdRepeatPerson.Size = new System.Drawing.Size(921, 150);
			this.grdRepeatPerson.TabIndex = 5;
			this.grdRepeatPerson.TableName = null;
			this.grdRepeatPerson.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdRepeatPerson_CellDoubleClick);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.button2);
			this.panel2.Controls.Add(this.btnDel);
			this.panel2.Controls.Add(this.btnView);
			this.panel2.Controls.Add(this.button1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(3, 429);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(921, 45);
			this.panel2.TabIndex = 4;
			// 
			// btnDel
			// 
			this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDel.Location = new System.Drawing.Point(227, 8);
			this.btnDel.Name = "btnDel";
			this.btnDel.Size = new System.Drawing.Size(137, 32);
			this.btnDel.TabIndex = 2;
			this.btnDel.Text = "Delete";
			this.btnDel.UseVisualStyleBackColor = true;
			this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
			// 
			// btnView
			// 
			this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnView.Location = new System.Drawing.Point(370, 8);
			this.btnView.Name = "btnView";
			this.btnView.Size = new System.Drawing.Size(137, 32);
			this.btnView.TabIndex = 1;
			this.btnView.Text = "مشاهده";
			this.btnView.UseVisualStyleBackColor = true;
			this.btnView.Click += new System.EventHandler(this.btnView_Click);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(717, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(195, 32);
			this.button1.TabIndex = 0;
			this.button1.Text = "حذف بقیه بجز انتخاب شده";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.LBPersonFields);
			this.tabPage2.Controls.Add(this.panel1);
			this.tabPage2.Controls.Add(this.LBAllFields);
			this.tabPage2.Controls.Add(this.splitter2);
			this.tabPage2.Controls.Add(this.LBShowData);
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(927, 477);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "جدول ارتباطات";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// LBPersonFields
			// 
			this.LBPersonFields.ActionClassName = "";
			this.LBPersonFields.ActionMenu = null;
			this.LBPersonFields.DataSource = null;
			this.LBPersonFields.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LBPersonFields.Edited = false;
			this.LBPersonFields.Location = new System.Drawing.Point(3, 3);
			this.LBPersonFields.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.LBPersonFields.MultiSelect = true;
			this.LBPersonFields.Name = "LBPersonFields";
			this.LBPersonFields.ShowNavigator = true;
			this.LBPersonFields.ShowToolbar = true;
			this.LBPersonFields.Size = new System.Drawing.Size(416, 215);
			this.LBPersonFields.TabIndex = 5;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnRemove);
			this.panel1.Controls.Add(this.btnSet);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel1.Location = new System.Drawing.Point(419, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(94, 215);
			this.panel1.TabIndex = 6;
			// 
			// btnRemove
			// 
			this.btnRemove.Location = new System.Drawing.Point(13, 51);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(75, 23);
			this.btnRemove.TabIndex = 3;
			this.btnRemove.Text = "<";
			this.btnRemove.UseVisualStyleBackColor = true;
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// btnSet
			// 
			this.btnSet.Location = new System.Drawing.Point(13, 22);
			this.btnSet.Name = "btnSet";
			this.btnSet.Size = new System.Drawing.Size(75, 23);
			this.btnSet.TabIndex = 3;
			this.btnSet.Text = ">";
			this.btnSet.UseVisualStyleBackColor = true;
			this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
			// 
			// LBAllFields
			// 
			this.LBAllFields.ActionClassName = "";
			this.LBAllFields.ActionMenu = null;
			this.LBAllFields.DataSource = null;
			this.LBAllFields.Dock = System.Windows.Forms.DockStyle.Right;
			this.LBAllFields.Edited = false;
			this.LBAllFields.Location = new System.Drawing.Point(513, 3);
			this.LBAllFields.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.LBAllFields.MultiSelect = true;
			this.LBAllFields.Name = "LBAllFields";
			this.LBAllFields.ShowNavigator = true;
			this.LBAllFields.ShowToolbar = true;
			this.LBAllFields.Size = new System.Drawing.Size(411, 215);
			this.LBAllFields.TabIndex = 5;
			// 
			// splitter2
			// 
			this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter2.Location = new System.Drawing.Point(3, 218);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(921, 8);
			this.splitter2.TabIndex = 9;
			this.splitter2.TabStop = false;
			// 
			// LBShowData
			// 
			this.LBShowData.ActionClassName = "";
			this.LBShowData.ActionMenu = null;
			this.LBShowData.DataSource = null;
			this.LBShowData.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.LBShowData.Edited = false;
			this.LBShowData.Location = new System.Drawing.Point(3, 226);
			this.LBShowData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.LBShowData.MultiSelect = true;
			this.LBShowData.Name = "LBShowData";
			this.LBShowData.ShowNavigator = true;
			this.LBShowData.ShowToolbar = true;
			this.LBShowData.Size = new System.Drawing.Size(921, 248);
			this.LBShowData.TabIndex = 7;
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(513, 8);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(195, 32);
			this.button2.TabIndex = 3;
			this.button2.Text = "حدف اتوماتیک همه تکراری ها";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// DelRepeatPersonForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(935, 506);
			this.Controls.Add(this.tabControl1);
			this.Name = "DelRepeatPersonForm";
			this.Text = "حذف اشخاص تکراری";
			this.Shown += new System.EventHandler(this.DelRepeatPersonForm_Shown);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdRepeatPerson)).EndInit();
			this.panel2.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private JDataGrid grdRepeatPerson;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chShMelli;
        private System.Windows.Forms.CheckBox chShSh;
        private System.Windows.Forms.CheckBox chFatherName;
        private System.Windows.Forms.CheckBox chName;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnEdit;
        private JJanusGrid grdAllPerson;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Button btnRemove;
        private JJanusGrid LBPersonFields;
        private JJanusGrid LBAllFields;
        private System.Windows.Forms.Panel panel1;
        private JJanusGrid LBShowData;
        private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Button button2;

    }
}