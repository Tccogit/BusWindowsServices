namespace ClassLibrary
{
    partial class JImageDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JImageDialog));
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnBrowse = new System.Windows.Forms.ToolStripButton();
            this.btnScan = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chStretch = new System.Windows.Forms.CheckBox();
            this.tsImage = new System.Windows.Forms.ToolStrip();
            this.btnZomIn = new System.Windows.Forms.ToolStripButton();
            this.btnZoomOut = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControlImages = new System.Windows.Forms.TabControl();
            this.tbnWebCam = new System.Windows.Forms.ToolStripButton();
            this.tsMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tsImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBrowse,
            this.btnScan,
            this.tbnWebCam});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(439, 25);
            this.tsMain.TabIndex = 0;
            this.tsMain.Text = "GetWebCam...";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowse.Image")));
            this.btnBrowse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(74, 22);
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnScan
            // 
            this.btnScan.Image = ((System.Drawing.Image)(resources.GetObject("btnScan.Image")));
            this.btnScan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(61, 22);
            this.btnScan.Text = "Scan...";
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chStretch);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(439, 45);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // chStretch
            // 
            this.chStretch.AutoSize = true;
            this.chStretch.Location = new System.Drawing.Point(6, 19);
            this.chStretch.Name = "chStretch";
            this.chStretch.Size = new System.Drawing.Size(60, 17);
            this.chStretch.TabIndex = 6;
            this.chStretch.Text = "Stretch";
            this.chStretch.UseVisualStyleBackColor = true;
            this.chStretch.CheckedChanged += new System.EventHandler(this.chStretch_CheckedChanged);
            // 
            // tsImage
            // 
            this.tsImage.BackColor = System.Drawing.SystemColors.Control;
            this.tsImage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnZomIn,
            this.btnZoomOut});
            this.tsImage.Location = new System.Drawing.Point(0, 70);
            this.tsImage.Name = "tsImage";
            this.tsImage.Size = new System.Drawing.Size(439, 25);
            this.tsImage.TabIndex = 5;
            this.tsImage.Text = "toolStrip2";
            // 
            // btnZomIn
            // 
            this.btnZomIn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnZomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZomIn.Image = ((System.Drawing.Image)(resources.GetObject("btnZomIn.Image")));
            this.btnZomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZomIn.Name = "btnZomIn";
            this.btnZomIn.Size = new System.Drawing.Size(23, 22);
            this.btnZomIn.Text = "toolStripButton3";
            this.btnZomIn.Click += new System.EventHandler(this.btnZomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomOut.Image")));
            this.btnZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(23, 22);
            this.btnZoomOut.Text = "toolStripButton4";
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Image Files|*.jpg";
            this.openFileDialog1.Multiselect = true;
            // 
            // tabControlImages
            // 
            this.tabControlImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlImages.Location = new System.Drawing.Point(0, 95);
            this.tabControlImages.Name = "tabControlImages";
            this.tabControlImages.SelectedIndex = 0;
            this.tabControlImages.Size = new System.Drawing.Size(439, 246);
            this.tabControlImages.TabIndex = 9;
            this.tabControlImages.SelectedIndexChanged += new System.EventHandler(this.tabControlImages_SelectedIndexChanged);
            // 
            // tbnWebCam
            // 
            this.tbnWebCam.Image = ((System.Drawing.Image)(resources.GetObject("tbnWebCam.Image")));
            this.tbnWebCam.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbnWebCam.Name = "tbnWebCam";
            this.tbnWebCam.Size = new System.Drawing.Size(103, 22);
            this.tbnWebCam.Text = "GetWebCam...";
            this.tbnWebCam.Click += new System.EventHandler(this.tbnWebCam_Click);
            // 
            // JImageDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlImages);
            this.Controls.Add(this.tsImage);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsMain);
            this.Name = "JImageDialog";
            this.Size = new System.Drawing.Size(439, 341);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tsImage.ResumeLayout(false);
            this.tsImage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip tsImage;
        private System.Windows.Forms.ToolStripButton btnZomIn;
        private System.Windows.Forms.ToolStripButton btnZoomOut;
        private System.Windows.Forms.CheckBox chStretch;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.ToolStripButton btnScan;
        public System.Windows.Forms.ToolStripButton btnBrowse;
        private System.Windows.Forms.TabControl tabControlImages;
        private System.Windows.Forms.ToolStripButton tbnWebCam;
    }
}
