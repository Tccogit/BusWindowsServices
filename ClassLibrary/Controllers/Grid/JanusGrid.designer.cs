namespace ClassLibrary
{
    partial class JJanusGrid
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JJanusGrid));
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnSendSMS = new System.Windows.Forms.Button();
			this.btnNewForm = new System.Windows.Forms.Button();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.btnProperties = new System.Windows.Forms.Button();
			this.cmbCount = new System.Windows.Forms.ComboBox();
			this.BtnNext = new System.Windows.Forms.Button();
			this.BtnPrevious = new System.Windows.Forms.Button();
			this.btnSelectPrint = new System.Windows.Forms.Button();
			this.btnExcel = new System.Windows.Forms.Button();
			this.btnPrint = new System.Windows.Forms.Button();
			this.btnLoad = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnColumns = new System.Windows.Forms.Button();
			this.btnFormule = new System.Windows.Forms.Button();
			this.btnReset = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this._gridEX1 = new Janus.Windows.GridEX.GridEX();
			this.panelBottom = new System.Windows.Forms.Panel();
			this.lbComment = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.gridEXExporter1 = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._gridEX1)).BeginInit();
			this.panelBottom.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.panel1.Controls.Add(this.btnSendSMS);
			this.panel1.Controls.Add(this.btnNewForm);
			this.panel1.Controls.Add(this.btnProperties);
			this.panel1.Controls.Add(this.cmbCount);
			this.panel1.Controls.Add(this.BtnNext);
			this.panel1.Controls.Add(this.BtnPrevious);
			this.panel1.Controls.Add(this.btnSelectPrint);
			this.panel1.Controls.Add(this.btnExcel);
			this.panel1.Controls.Add(this.btnPrint);
			this.panel1.Controls.Add(this.btnLoad);
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.btnColumns);
			this.panel1.Controls.Add(this.btnFormule);
			this.panel1.Controls.Add(this.btnReset);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(446, 27);
			this.panel1.TabIndex = 1;
			// 
			// btnSendSMS
			// 
			this.btnSendSMS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSendSMS.BackColor = System.Drawing.SystemColors.Control;
			this.btnSendSMS.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Info;
			this.btnSendSMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSendSMS.Image = ((System.Drawing.Image)(resources.GetObject("btnSendSMS.Image")));
			this.btnSendSMS.Location = new System.Drawing.Point(159, 2);
			this.btnSendSMS.Name = "btnSendSMS";
			this.btnSendSMS.Size = new System.Drawing.Size(24, 24);
			this.btnSendSMS.TabIndex = 13;
			this.btnSendSMS.TabStop = false;
			this.toolTip1.SetToolTip(this.btnSendSMS, "ارسال SMS");
			this.btnSendSMS.UseVisualStyleBackColor = false;
			this.btnSendSMS.Visible = false;
			this.btnSendSMS.Click += new System.EventHandler(this.btnSendSMS_Click);
			// 
			// btnNewForm
			// 
			this.btnNewForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNewForm.BackColor = System.Drawing.SystemColors.Control;
			this.btnNewForm.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Info;
			this.btnNewForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnNewForm.ImageIndex = 2;
			this.btnNewForm.ImageList = this.imageList1;
			this.btnNewForm.Location = new System.Drawing.Point(211, 2);
			this.btnNewForm.Name = "btnNewForm";
			this.btnNewForm.Size = new System.Drawing.Size(24, 24);
			this.btnNewForm.TabIndex = 12;
			this.btnNewForm.TabStop = false;
			this.toolTip1.SetToolTip(this.btnNewForm, "ثبت فرم");
			this.btnNewForm.UseVisualStyleBackColor = false;
			this.btnNewForm.Click += new System.EventHandler(this.btnNewForm_Click);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "form.png");
			this.imageList1.Images.SetKeyName(1, "formula.png");
			this.imageList1.Images.SetKeyName(2, "registered_forms.gif");
			this.imageList1.Images.SetKeyName(3, "column.png");
			this.imageList1.Images.SetKeyName(4, "icon-excel.png");
			this.imageList1.Images.SetKeyName(5, "Save-Icon-16x16.gif");
			this.imageList1.Images.SetKeyName(6, "print-icon.png");
			this.imageList1.Images.SetKeyName(7, "IconRefresh.gif");
			this.imageList1.Images.SetKeyName(8, "report.png");
			// 
			// btnProperties
			// 
			this.btnProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnProperties.BackColor = System.Drawing.SystemColors.Control;
			this.btnProperties.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Info;
			this.btnProperties.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnProperties.ImageIndex = 0;
			this.btnProperties.ImageList = this.imageList1;
			this.btnProperties.Location = new System.Drawing.Point(185, 2);
			this.btnProperties.Name = "btnProperties";
			this.btnProperties.Size = new System.Drawing.Size(24, 24);
			this.btnProperties.TabIndex = 11;
			this.btnProperties.TabStop = false;
			this.toolTip1.SetToolTip(this.btnProperties, "فرم ها");
			this.btnProperties.UseVisualStyleBackColor = false;
			this.btnProperties.Click += new System.EventHandler(this.btnProperties_Click);
			// 
			// cmbCount
			// 
			this.cmbCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCount.FormattingEnabled = true;
			this.cmbCount.Items.AddRange(new object[] {
            "12",
            "25",
            "50",
            "100",
            "200",
            "....."});
			this.cmbCount.Location = new System.Drawing.Point(29, 3);
			this.cmbCount.Name = "cmbCount";
			this.cmbCount.Size = new System.Drawing.Size(66, 21);
			this.cmbCount.TabIndex = 10;
			this.cmbCount.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// BtnNext
			// 
			this.BtnNext.Location = new System.Drawing.Point(96, 1);
			this.BtnNext.Name = "BtnNext";
			this.BtnNext.Size = new System.Drawing.Size(25, 25);
			this.BtnNext.TabIndex = 9;
			this.BtnNext.Text = "<";
			this.BtnNext.UseVisualStyleBackColor = true;
			this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
			// 
			// BtnPrevious
			// 
			this.BtnPrevious.Location = new System.Drawing.Point(3, 1);
			this.BtnPrevious.Name = "BtnPrevious";
			this.BtnPrevious.Size = new System.Drawing.Size(25, 25);
			this.BtnPrevious.TabIndex = 9;
			this.BtnPrevious.Text = ">";
			this.BtnPrevious.UseVisualStyleBackColor = true;
			this.BtnPrevious.Click += new System.EventHandler(this.BtnPrevious_Click);
			// 
			// btnSelectPrint
			// 
			this.btnSelectPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSelectPrint.BackColor = System.Drawing.SystemColors.Control;
			this.btnSelectPrint.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Info;
			this.btnSelectPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSelectPrint.ImageKey = "print-icon.png";
			this.btnSelectPrint.ImageList = this.imageList1;
			this.btnSelectPrint.Location = new System.Drawing.Point(341, 2);
			this.btnSelectPrint.Name = "btnSelectPrint";
			this.btnSelectPrint.Size = new System.Drawing.Size(24, 24);
			this.btnSelectPrint.TabIndex = 8;
			this.btnSelectPrint.TabStop = false;
			this.toolTip1.SetToolTip(this.btnSelectPrint, "چاپ");
			this.btnSelectPrint.UseVisualStyleBackColor = false;
			this.btnSelectPrint.Click += new System.EventHandler(this.btnSelectPrint_Click);
			// 
			// btnExcel
			// 
			this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExcel.BackColor = System.Drawing.SystemColors.Control;
			this.btnExcel.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Info;
			this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnExcel.ImageKey = "icon-excel.png";
			this.btnExcel.ImageList = this.imageList1;
			this.btnExcel.Location = new System.Drawing.Point(315, 2);
			this.btnExcel.Name = "btnExcel";
			this.btnExcel.Size = new System.Drawing.Size(24, 24);
			this.btnExcel.TabIndex = 7;
			this.btnExcel.TabStop = false;
			this.toolTip1.SetToolTip(this.btnExcel, "خروجی در اکسل");
			this.btnExcel.UseVisualStyleBackColor = false;
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			// 
			// btnPrint
			// 
			this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPrint.BackColor = System.Drawing.SystemColors.Control;
			this.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Info;
			this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPrint.ImageKey = "report.png";
			this.btnPrint.ImageList = this.imageList1;
			this.btnPrint.Location = new System.Drawing.Point(367, 2);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(24, 24);
			this.btnPrint.TabIndex = 6;
			this.btnPrint.TabStop = false;
			this.toolTip1.SetToolTip(this.btnPrint, "چاپ");
			this.btnPrint.UseVisualStyleBackColor = false;
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// btnLoad
			// 
			this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnLoad.BackColor = System.Drawing.SystemColors.Control;
			this.btnLoad.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Info;
			this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnLoad.ImageKey = "IconRefresh.gif";
			this.btnLoad.ImageList = this.imageList1;
			this.btnLoad.Location = new System.Drawing.Point(417, 2);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(24, 24);
			this.btnLoad.TabIndex = 5;
			this.btnLoad.TabStop = false;
			this.toolTip1.SetToolTip(this.btnLoad, "بازیابی تنظیمات");
			this.btnLoad.UseVisualStyleBackColor = false;
			this.btnLoad.Click += new System.EventHandler(this.btnAdvanceSearch_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.BackColor = System.Drawing.SystemColors.Control;
			this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Info;
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSave.ImageKey = "Save-Icon-16x16.gif";
			this.btnSave.ImageList = this.imageList1;
			this.btnSave.Location = new System.Drawing.Point(392, 2);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(24, 24);
			this.btnSave.TabIndex = 4;
			this.btnSave.TabStop = false;
			this.toolTip1.SetToolTip(this.btnSave, "ذخیره تنظیمات");
			this.btnSave.UseVisualStyleBackColor = false;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnColumns
			// 
			this.btnColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnColumns.BackColor = System.Drawing.SystemColors.Control;
			this.btnColumns.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Info;
			this.btnColumns.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnColumns.ImageKey = "column.png";
			this.btnColumns.ImageList = this.imageList1;
			this.btnColumns.Location = new System.Drawing.Point(237, 2);
			this.btnColumns.Name = "btnColumns";
			this.btnColumns.Size = new System.Drawing.Size(24, 24);
			this.btnColumns.TabIndex = 3;
			this.btnColumns.TabStop = false;
			this.btnColumns.Text = "C";
			this.toolTip1.SetToolTip(this.btnColumns, "ستون ها");
			this.btnColumns.UseVisualStyleBackColor = false;
			this.btnColumns.Click += new System.EventHandler(this.btnColumns_Click);
			// 
			// btnFormule
			// 
			this.btnFormule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFormule.BackColor = System.Drawing.SystemColors.Control;
			this.btnFormule.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Info;
			this.btnFormule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnFormule.ImageIndex = 1;
			this.btnFormule.ImageList = this.imageList1;
			this.btnFormule.Location = new System.Drawing.Point(263, 2);
			this.btnFormule.Name = "btnFormule";
			this.btnFormule.Size = new System.Drawing.Size(24, 24);
			this.btnFormule.TabIndex = 3;
			this.btnFormule.TabStop = false;
			this.btnFormule.Tag = "";
			this.toolTip1.SetToolTip(this.btnFormule, "فرمول ها");
			this.btnFormule.UseVisualStyleBackColor = false;
			this.btnFormule.Click += new System.EventHandler(this.btnFormule_Click);
			// 
			// btnReset
			// 
			this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnReset.BackColor = System.Drawing.SystemColors.Control;
			this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Info;
			this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
			this.btnReset.Location = new System.Drawing.Point(289, 2);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(24, 24);
			this.btnReset.TabIndex = 3;
			this.btnReset.TabStop = false;
			this.toolTip1.SetToolTip(this.btnReset, "تنظیمات اولیه");
			this.btnReset.UseVisualStyleBackColor = false;
			this.btnReset.Visible = false;
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.groupBox1.Controls.Add(this._gridEX1);
			this.groupBox1.Controls.Add(this.panelBottom);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox1.Location = new System.Drawing.Point(0, 27);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(446, 207);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			// 
			// _gridEX1
			// 
			this._gridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
			this._gridEX1.AlternatingColors = true;
			this._gridEX1.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.LightSteelBlue;
			this._gridEX1.AlternatingRowFormatStyle.BackColorGradient = System.Drawing.Color.White;
			this._gridEX1.AlternatingRowFormatStyle.ForeColor = System.Drawing.Color.Black;
			this._gridEX1.BuiltInTextsData = resources.GetString("_gridEX1.BuiltInTextsData");
			this._gridEX1.DefaultFilterRowComparison = Janus.Windows.GridEX.FilterConditionOperator.Contains;
			this._gridEX1.Dock = System.Windows.Forms.DockStyle.Fill;
			this._gridEX1.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.None;
			this._gridEX1.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
			this._gridEX1.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
			this._gridEX1.Font = new System.Drawing.Font("Tahoma", 9.75F);
			this._gridEX1.Location = new System.Drawing.Point(3, 16);
			this._gridEX1.Name = "_gridEX1";
			this._gridEX1.RecordNavigator = true;
			this._gridEX1.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
			this._gridEX1.SelectedFormatStyle.BackColor = System.Drawing.Color.Blue;
			this._gridEX1.SelectedFormatStyle.ForeColor = System.Drawing.Color.White;
			this._gridEX1.SelectedInactiveFormatStyle.BackColor = System.Drawing.SystemColors.Highlight;
			this._gridEX1.SelectedInactiveFormatStyle.BackColorAlphaMode = Janus.Windows.GridEX.AlphaMode.Opaque;
			this._gridEX1.SelectedInactiveFormatStyle.ForeColor = System.Drawing.SystemColors.HighlightText;
			this._gridEX1.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection;
			this._gridEX1.Size = new System.Drawing.Size(440, 163);
			this._gridEX1.TabIndex = 1;
			this._gridEX1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
			this._gridEX1.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this._gridEX1_RowDoubleClick);
			this._gridEX1.LoadingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this._gridEX1_LoadingRow);
			this._gridEX1.ColumnHeaderClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this._gridEX1_ColumnHeaderClick);
			this._gridEX1.SelectionChanged += new System.EventHandler(this._gridEX1_SelectionChanged_1);
			this._gridEX1.FilterApplied += new System.EventHandler(this._gridEX1_FilterApplied);
			this._gridEX1.LayoutLoad += new System.EventHandler(this._gridEX1_LayoutLoad);
			this._gridEX1.DragDrop += new System.Windows.Forms.DragEventHandler(this._gridEX1_DragDrop);
			this._gridEX1.DragLeave += new System.EventHandler(this._gridEX1_DragLeave);
			this._gridEX1.DoubleClick += new System.EventHandler(this._gridEX1_DoubleClick);
			// 
			// panelBottom
			// 
			this.panelBottom.Controls.Add(this.lbComment);
			this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelBottom.Location = new System.Drawing.Point(3, 179);
			this.panelBottom.Name = "panelBottom";
			this.panelBottom.Size = new System.Drawing.Size(440, 25);
			this.panelBottom.TabIndex = 2;
			// 
			// lbComment
			// 
			this.lbComment.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbComment.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.lbComment.Location = new System.Drawing.Point(0, 0);
			this.lbComment.Name = "lbComment";
			this.lbComment.Size = new System.Drawing.Size(440, 25);
			this.lbComment.TabIndex = 0;
			this.lbComment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// gridEXExporter1
			// 
			this.gridEXExporter1.GridEX = this._gridEX1;
			// 
			// JJanusGrid
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel1);
			this.Name = "JJanusGrid";
			this.Size = new System.Drawing.Size(446, 234);
			this.Enter += new System.EventHandler(this.JJanusGrid_Enter);
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this._gridEX1)).EndInit();
			this.panelBottom.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.ToolTip toolTip1;
		private Janus.Windows.GridEX.GridEX _gridEX1;
        private Janus.Windows.GridEX.Export.GridEXExporter gridEXExporter1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnSelectPrint;
        private System.Windows.Forms.ComboBox cmbCount;
        private System.Windows.Forms.Button BtnNext;
        private System.Windows.Forms.Button BtnPrevious;
        private System.Windows.Forms.Button btnColumns;
        private System.Windows.Forms.Button btnFormule;
        private System.Windows.Forms.Button btnProperties;
        private System.Windows.Forms.Button btnNewForm;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lbComment;
		private System.Windows.Forms.Button btnSendSMS;
    }
}
