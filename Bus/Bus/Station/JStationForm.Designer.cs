
namespace BusManagment.Station
{
    partial class JStationForm
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
            this.lblName = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.jComZone = new ClassLibrary.JComboBox(this.components);
            this.lblZone = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.jPropertyValue = new Globals.Property.JPropertyValueUserControl();
            this.button1 = new System.Windows.Forms.Button();
            this.cboStationType = new ClassLibrary.JComboBox(this.components);
            this.lblStationType = new System.Windows.Forms.Label();
            this.txtName = new ClassLibrary.TextEdit(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnZoomin = new System.Windows.Forms.Button();
            this.btnZoomout = new System.Windows.Forms.Button();
            this.btnShowOnMap = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLng = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLat = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(602, 24);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(46, 16);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(558, 4);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(110, 32);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Location = new System.Drawing.Point(442, 4);
            this.btnApply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(110, 32);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Visible = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(12, 4);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 32);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // jComZone
            // 
            this.jComZone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.jComZone.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.jComZone.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.jComZone.BackColor = System.Drawing.SystemColors.Info;
            this.jComZone.BaseCode = 0;
            this.jComZone.ChangeColorIfNotEmpty = true;
            this.jComZone.ChangeColorOnEnter = true;
            this.jComZone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.jComZone.ForeColor = System.Drawing.SystemColors.WindowText;
            this.jComZone.FormattingEnabled = true;
            this.jComZone.InBackColor = System.Drawing.SystemColors.Info;
            this.jComZone.InForeColor = System.Drawing.SystemColors.WindowText;
            this.jComZone.Location = new System.Drawing.Point(277, 51);
            this.jComZone.Name = "jComZone";
            this.jComZone.NotEmpty = false;
            this.jComZone.NotEmptyColor = System.Drawing.Color.Red;
            this.jComZone.SelectOnEnter = true;
            this.jComZone.Size = new System.Drawing.Size(283, 24);
            this.jComZone.TabIndex = 1;
            // 
            // lblZone
            // 
            this.lblZone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblZone.AutoSize = true;
            this.lblZone.Location = new System.Drawing.Point(607, 55);
            this.lblZone.Name = "lblZone";
            this.lblZone.Size = new System.Drawing.Size(41, 16);
            this.lblZone.TabIndex = 0;
            this.lblZone.Text = "Zone:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(110, 32);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(680, 296);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.jPropertyValue);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.cboStationType);
            this.tabPage1.Controls.Add(this.lblStationType);
            this.tabPage1.Controls.Add(this.txtName);
            this.tabPage1.Controls.Add(this.jComZone);
            this.tabPage1.Controls.Add(this.lblName);
            this.tabPage1.Controls.Add(this.lblZone);
            this.tabPage1.Location = new System.Drawing.Point(4, 36);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(672, 256);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Station";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // jPropertyValue
            // 
            this.jPropertyValue.AutoScroll = true;
            this.jPropertyValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jPropertyValue.ClassName = null;
            this.jPropertyValue.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.jPropertyValue.Location = new System.Drawing.Point(3, 133);
            this.jPropertyValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.jPropertyValue.Name = "jPropertyValue";
            this.jPropertyValue.ObjectCode = -1;
            this.jPropertyValue.Size = new System.Drawing.Size(666, 120);
            this.jPropertyValue.TabIndex = 17;
            this.jPropertyValue.ValueObjectCode = 0;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(8, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "DefineProperty";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cboStationType
            // 
            this.cboStationType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboStationType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboStationType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboStationType.BaseCode = 0;
            this.cboStationType.ChangeColorIfNotEmpty = true;
            this.cboStationType.ChangeColorOnEnter = true;
            this.cboStationType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboStationType.FormattingEnabled = true;
            this.cboStationType.InBackColor = System.Drawing.SystemColors.Info;
            this.cboStationType.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cboStationType.Location = new System.Drawing.Point(438, 86);
            this.cboStationType.Name = "cboStationType";
            this.cboStationType.NotEmpty = false;
            this.cboStationType.NotEmptyColor = System.Drawing.Color.Red;
            this.cboStationType.SelectOnEnter = true;
            this.cboStationType.Size = new System.Drawing.Size(121, 24);
            this.cboStationType.TabIndex = 2;
            // 
            // lblStationType
            // 
            this.lblStationType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStationType.AutoSize = true;
            this.lblStationType.Location = new System.Drawing.Point(567, 86);
            this.lblStationType.Name = "lblStationType";
            this.lblStationType.Size = new System.Drawing.Size(81, 16);
            this.lblStationType.TabIndex = 14;
            this.lblStationType.Text = "TypeStation:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.ChangeColorIfNotEmpty = false;
            this.txtName.ChangeColorOnEnter = true;
            this.txtName.InBackColor = System.Drawing.SystemColors.Info;
            this.txtName.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtName.Location = new System.Drawing.Point(384, 21);
            this.txtName.Name = "txtName";
            this.txtName.Negative = true;
            this.txtName.NotEmpty = false;
            this.txtName.NotEmptyColor = System.Drawing.Color.Red;
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtName.SelectOnEnter = true;
            this.txtName.Size = new System.Drawing.Size(176, 23);
            this.txtName.TabIndex = 0;
            this.txtName.TextMode = ClassLibrary.TextModes.Text;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gMapControl1);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 36);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(672, 256);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Map";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemmory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(3, 3);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(488, 250);
            this.gMapControl1.TabIndex = 4;
            this.gMapControl1.Zoom = 0D;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnZoomin);
            this.panel2.Controls.Add(this.btnZoomout);
            this.panel2.Controls.Add(this.btnShowOnMap);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtLng);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtLat);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(491, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(178, 250);
            this.panel2.TabIndex = 3;
            // 
            // btnZoomin
            // 
            this.btnZoomin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomin.Location = new System.Drawing.Point(56, 166);
            this.btnZoomin.Name = "btnZoomin";
            this.btnZoomin.Size = new System.Drawing.Size(44, 28);
            this.btnZoomin.TabIndex = 6;
            this.btnZoomin.Text = "+";
            this.btnZoomin.UseVisualStyleBackColor = true;
            this.btnZoomin.Click += new System.EventHandler(this.btnZoomin_Click);
            // 
            // btnZoomout
            // 
            this.btnZoomout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomout.Location = new System.Drawing.Point(6, 166);
            this.btnZoomout.Name = "btnZoomout";
            this.btnZoomout.Size = new System.Drawing.Size(44, 28);
            this.btnZoomout.TabIndex = 5;
            this.btnZoomout.Text = "-";
            this.btnZoomout.UseVisualStyleBackColor = true;
            this.btnZoomout.Click += new System.EventHandler(this.btnZoomout_Click);
            // 
            // btnShowOnMap
            // 
            this.btnShowOnMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowOnMap.Location = new System.Drawing.Point(6, 106);
            this.btnShowOnMap.Name = "btnShowOnMap";
            this.btnShowOnMap.Size = new System.Drawing.Size(81, 28);
            this.btnShowOnMap.TabIndex = 4;
            this.btnShowOnMap.Text = "Show";
            this.btnShowOnMap.UseVisualStyleBackColor = true;
            this.btnShowOnMap.Click += new System.EventHandler(this.btnShowOnMap_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lng:";
            // 
            // txtLng
            // 
            this.txtLng.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLng.Location = new System.Drawing.Point(6, 77);
            this.txtLng.Name = "txtLng";
            this.txtLng.Size = new System.Drawing.Size(167, 23);
            this.txtLng.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lat:";
            // 
            // txtLat
            // 
            this.txtLat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLat.Location = new System.Drawing.Point(6, 32);
            this.txtLat.Name = "txtLat";
            this.txtLat.Size = new System.Drawing.Size(167, 23);
            this.txtLat.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 296);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(680, 40);
            this.panel1.TabIndex = 1;
            // 
            // JStationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 336);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JStationForm";
            this.Text = "JStationForm";
            this.Load += new System.EventHandler(this.JStationForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnClose;
        private ClassLibrary.JComboBox jComZone;
        private System.Windows.Forms.Label lblZone;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private ClassLibrary.TextEdit txtName;
        private ClassLibrary.JComboBox cboStationType;
        private System.Windows.Forms.Label lblStationType;
        private System.Windows.Forms.Button button1;
        private Globals.Property.JPropertyValueUserControl jPropertyValue;
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLng;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLat;
        private System.Windows.Forms.Button btnShowOnMap;
        private System.Windows.Forms.Button btnZoomin;
        private System.Windows.Forms.Button btnZoomout;
    }
}