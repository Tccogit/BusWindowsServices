namespace ClassLibrary
{
    partial class JActionsManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JActionsManagerForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtFunctionName = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDelArgs = new System.Windows.Forms.Button();
            this.lstArgs = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtDefaultArgs = new System.Windows.Forms.TextBox();
            this.cmbTypeArgs = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDelConst = new System.Windows.Forms.Button();
            this.lstConstArgs = new System.Windows.Forms.ListBox();
            this.btnAddConst = new System.Windows.Forms.Button();
            this.txtConstDefault = new System.Windows.Forms.TextBox();
            this.cmbConstType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.Images.SetKeyName(0, "aktion.png");
            this.imageList.Images.SetKeyName(1, "alert.png");
            this.imageList.Images.SetKeyName(2, "All software is current.png");
            this.imageList.Images.SetKeyName(3, "amor.png");
            this.imageList.Images.SetKeyName(4, "antivirus.png");
            this.imageList.Images.SetKeyName(5, "applixware.png");
            this.imageList.Images.SetKeyName(6, "ark.png");
            this.imageList.Images.SetKeyName(7, "arts.png");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "FunctionName";
            // 
            // txtFunctionName
            // 
            this.txtFunctionName.Location = new System.Drawing.Point(104, 43);
            this.txtFunctionName.Name = "txtFunctionName";
            this.txtFunctionName.Size = new System.Drawing.Size(482, 23);
            this.txtFunctionName.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 462);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(692, 105);
            this.dataGridView1.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "ActionName";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(104, 14);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(165, 23);
            this.txtName.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFunctionName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(692, 76);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDelArgs);
            this.groupBox2.Controls.Add(this.lstArgs);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.txtDefaultArgs);
            this.groupBox2.Controls.Add(this.cmbTypeArgs);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(692, 181);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FunctionArguments";
            // 
            // btnDelArgs
            // 
            this.btnDelArgs.Location = new System.Drawing.Point(348, 146);
            this.btnDelArgs.Name = "btnDelArgs";
            this.btnDelArgs.Size = new System.Drawing.Size(34, 23);
            this.btnDelArgs.TabIndex = 22;
            this.btnDelArgs.Text = "Del";
            this.btnDelArgs.UseVisualStyleBackColor = true;
            this.btnDelArgs.Click += new System.EventHandler(this.btnDelArgs_Click);
            // 
            // lstArgs
            // 
            this.lstArgs.FormattingEnabled = true;
            this.lstArgs.ItemHeight = 16;
            this.lstArgs.Location = new System.Drawing.Point(15, 68);
            this.lstArgs.Name = "lstArgs";
            this.lstArgs.Size = new System.Drawing.Size(327, 100);
            this.lstArgs.TabIndex = 17;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(267, 40);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtDefaultArgs
            // 
            this.txtDefaultArgs.Location = new System.Drawing.Point(155, 40);
            this.txtDefaultArgs.Name = "txtDefaultArgs";
            this.txtDefaultArgs.Size = new System.Drawing.Size(100, 23);
            this.txtDefaultArgs.TabIndex = 15;
            // 
            // cmbTypeArgs
            // 
            this.cmbTypeArgs.FormattingEnabled = true;
            this.cmbTypeArgs.Items.AddRange(new object[] {
            "int",
            "string",
            "bool"});
            this.cmbTypeArgs.Location = new System.Drawing.Point(15, 38);
            this.cmbTypeArgs.Name = "cmbTypeArgs";
            this.cmbTypeArgs.Size = new System.Drawing.Size(121, 24);
            this.cmbTypeArgs.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(157, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Default Value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Type";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDelConst);
            this.groupBox3.Controls.Add(this.lstConstArgs);
            this.groupBox3.Controls.Add(this.btnAddConst);
            this.groupBox3.Controls.Add(this.txtConstDefault);
            this.groupBox3.Controls.Add(this.cmbConstType);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 257);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(692, 174);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ConstructorArguments";
            // 
            // btnDelConst
            // 
            this.btnDelConst.Location = new System.Drawing.Point(348, 145);
            this.btnDelConst.Name = "btnDelConst";
            this.btnDelConst.Size = new System.Drawing.Size(34, 23);
            this.btnDelConst.TabIndex = 25;
            this.btnDelConst.Text = "Del";
            this.btnDelConst.UseVisualStyleBackColor = true;
            this.btnDelConst.Click += new System.EventHandler(this.btnDelConst_Click);
            // 
            // lstConstArgs
            // 
            this.lstConstArgs.FormattingEnabled = true;
            this.lstConstArgs.ItemHeight = 16;
            this.lstConstArgs.Location = new System.Drawing.Point(15, 68);
            this.lstConstArgs.Name = "lstConstArgs";
            this.lstConstArgs.Size = new System.Drawing.Size(327, 100);
            this.lstConstArgs.TabIndex = 23;
            // 
            // btnAddConst
            // 
            this.btnAddConst.Location = new System.Drawing.Point(267, 39);
            this.btnAddConst.Name = "btnAddConst";
            this.btnAddConst.Size = new System.Drawing.Size(75, 23);
            this.btnAddConst.TabIndex = 16;
            this.btnAddConst.Text = "Add";
            this.btnAddConst.UseVisualStyleBackColor = true;
            this.btnAddConst.Click += new System.EventHandler(this.btnAddConst_Click);
            // 
            // txtConstDefault
            // 
            this.txtConstDefault.Location = new System.Drawing.Point(155, 39);
            this.txtConstDefault.Name = "txtConstDefault";
            this.txtConstDefault.Size = new System.Drawing.Size(100, 23);
            this.txtConstDefault.TabIndex = 15;
            // 
            // cmbConstType
            // 
            this.cmbConstType.FormattingEnabled = true;
            this.cmbConstType.Items.AddRange(new object[] {
            "int",
            "string",
            "bool"});
            this.cmbConstType.Location = new System.Drawing.Point(15, 38);
            this.cmbConstType.Name = "cmbConstType";
            this.cmbConstType.Size = new System.Drawing.Size(121, 24);
            this.cmbConstType.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(157, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Default Value";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = "Type";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(10, 437);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // JActionsManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 567);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "JActionsManagerForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RightToLeftLayout = false;
            this.Text = resources.GetString("$this.Text");
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFunctionName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstArgs;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtDefaultArgs;
        private System.Windows.Forms.ComboBox cmbTypeArgs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAddConst;
        private System.Windows.Forms.TextBox txtConstDefault;
        private System.Windows.Forms.ComboBox cmbConstType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnDelArgs;
        private System.Windows.Forms.Button btnDelConst;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListBox lstConstArgs;
    }
}