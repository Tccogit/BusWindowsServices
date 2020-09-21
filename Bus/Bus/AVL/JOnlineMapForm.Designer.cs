namespace BusManagment.AVL
{
    partial class JOnlineMapForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JOnlineMapForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnZoom = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnShow = new System.Windows.Forms.Button();
            this.timeB = new ClassLibrary.TimeEdit(this.components);
            this.dateB = new ClassLibrary.DateEdit(this.components);
            this.timeA = new ClassLibrary.TimeEdit(this.components);
            this.dateA = new ClassLibrary.DateEdit(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chbOnline = new System.Windows.Forms.CheckBox();
            this.chbBuses = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 400;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnZoom
            // 
            this.btnZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnZoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoom.Location = new System.Drawing.Point(136, 322);
            this.btnZoom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnZoom.Name = "btnZoom";
            this.btnZoom.Size = new System.Drawing.Size(84, 26);
            this.btnZoom.TabIndex = 1;
            this.btnZoom.Text = "Zoom";
            this.btnZoom.UseVisualStyleBackColor = true;
            this.btnZoom.Click += new System.EventHandler(this.btnZoom_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "bus_flat16.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.chbBuses);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnZoom);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(670, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(226, 525);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.btnShow);
            this.panel2.Controls.Add(this.timeB);
            this.panel2.Controls.Add(this.dateB);
            this.panel2.Controls.Add(this.timeA);
            this.panel2.Controls.Add(this.dateA);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.chbOnline);
            this.panel2.Location = new System.Drawing.Point(3, 355);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(220, 167);
            this.panel2.TabIndex = 5;
            // 
            // btnShow
            // 
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Location = new System.Drawing.Point(130, 133);
            this.btnShow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(84, 26);
            this.btnShow.TabIndex = 10;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // timeB
            // 
            this.timeB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.timeB.ChangeColorIfNotEmpty = true;
            this.timeB.ChangeColorOnEnter = true;
            this.timeB.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.timeB.InBackColor = System.Drawing.SystemColors.Info;
            this.timeB.InForeColor = System.Drawing.SystemColors.WindowText;
            this.timeB.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.timeB.Location = new System.Drawing.Point(99, 106);
            this.timeB.Mask = "00:00";
            this.timeB.Name = "timeB";
            this.timeB.NotEmpty = false;
            this.timeB.NotEmptyColor = System.Drawing.Color.Red;
            this.timeB.Size = new System.Drawing.Size(53, 20);
            this.timeB.TabIndex = 8;
            this.timeB.ValidatingType = typeof(System.DateTime);
            // 
            // dateB
            // 
            this.dateB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dateB.ChangeColorIfNotEmpty = true;
            this.dateB.ChangeColorOnEnter = true;
            this.dateB.Date = new System.DateTime(((long)(0)));
            this.dateB.InBackColor = System.Drawing.SystemColors.Info;
            this.dateB.InForeColor = System.Drawing.SystemColors.WindowText;
            this.dateB.InsertInDatesTable = true;
            this.dateB.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dateB.Location = new System.Drawing.Point(17, 109);
            this.dateB.Mask = "0000/00/00";
            this.dateB.Name = "dateB";
            this.dateB.NotEmpty = false;
            this.dateB.NotEmptyColor = System.Drawing.Color.Red;
            this.dateB.Size = new System.Drawing.Size(76, 16);
            this.dateB.TabIndex = 9;
            // 
            // timeA
            // 
            this.timeA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.timeA.ChangeColorIfNotEmpty = true;
            this.timeA.ChangeColorOnEnter = true;
            this.timeA.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.timeA.InBackColor = System.Drawing.SystemColors.Info;
            this.timeA.InForeColor = System.Drawing.SystemColors.WindowText;
            this.timeA.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.timeA.Location = new System.Drawing.Point(99, 58);
            this.timeA.Mask = "00:00";
            this.timeA.Name = "timeA";
            this.timeA.NotEmpty = false;
            this.timeA.NotEmptyColor = System.Drawing.Color.Red;
            this.timeA.Size = new System.Drawing.Size(53, 20);
            this.timeA.TabIndex = 2;
            this.timeA.ValidatingType = typeof(System.DateTime);
            // 
            // dateA
            // 
            this.dateA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dateA.ChangeColorIfNotEmpty = true;
            this.dateA.ChangeColorOnEnter = true;
            this.dateA.Date = new System.DateTime(((long)(0)));
            this.dateA.InBackColor = System.Drawing.SystemColors.Info;
            this.dateA.InForeColor = System.Drawing.SystemColors.WindowText;
            this.dateA.InsertInDatesTable = true;
            this.dateA.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dateA.Location = new System.Drawing.Point(17, 61);
            this.dateA.Mask = "0000/00/00";
            this.dateA.Name = "dateA";
            this.dateA.NotEmpty = false;
            this.dateA.NotEmptyColor = System.Drawing.Color.Red;
            this.dateA.Size = new System.Drawing.Size(76, 16);
            this.dateA.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(141, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 22);
            this.label3.TabIndex = 7;
            this.label3.Text = "تا:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(141, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "از:";
            // 
            // chbOnline
            // 
            this.chbOnline.AutoSize = true;
            this.chbOnline.Location = new System.Drawing.Point(65, 3);
            this.chbOnline.Name = "chbOnline";
            this.chbOnline.Size = new System.Drawing.Size(149, 20);
            this.chbOnline.TabIndex = 5;
            this.chbOnline.Text = "نمایش به صورت آنلاین";
            this.chbOnline.UseVisualStyleBackColor = true;
            this.chbOnline.CheckedChanged += new System.EventHandler(this.chbOnline_CheckedChanged);
            // 
            // chbBuses
            // 
            this.chbBuses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.chbBuses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chbBuses.FormattingEnabled = true;
            this.chbBuses.IntegralHeight = false;
            this.chbBuses.Location = new System.Drawing.Point(3, 34);
            this.chbBuses.Name = "chbBuses";
            this.chbBuses.Size = new System.Drawing.Size(220, 281);
            this.chbBuses.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(144, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "اتوبوس ها:";
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
            this.gMapControl1.Location = new System.Drawing.Point(0, 0);
            this.gMapControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.gMapControl1.Size = new System.Drawing.Size(670, 525);
            this.gMapControl1.TabIndex = 4;
            this.gMapControl1.Zoom = 0D;
            // 
            // JOnlineMapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 525);
            this.Controls.Add(this.gMapControl1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JOnlineMapForm";
            this.Text = "JOnlineMapForm";
            this.Load += new System.EventHandler(this.JOnlineMapForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnZoom;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chbOnline;
        private System.Windows.Forms.CheckedListBox chbBuses;
        private ClassLibrary.DateEdit dateA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnShow;
        private ClassLibrary.TimeEdit timeB;
        private ClassLibrary.DateEdit dateB;
        private ClassLibrary.TimeEdit timeA;
    }
}