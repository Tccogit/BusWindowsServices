namespace ClassLibrary
{
    partial class JUC_AttachmentManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JUC_AttachmentManager));
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Typed File", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Scan", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Other Files", System.Windows.Forms.HorizontalAlignment.Left);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cntxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPattern = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOtherFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.odlSelectPatternFile = new System.Windows.Forms.OpenFileDialog();
            this.lstvFiles = new System.Windows.Forms.ListView();
            this.pnlDisplayThumbNill = new System.Windows.Forms.Panel();
            this.picBoxThumbNill = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tssbTypedWord = new System.Windows.Forms.ToolStripSplitButton();
            this.typedFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTopPattern = new System.Windows.Forms.ToolStripMenuItem();
            this.readyFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmTopOtherFiles = new System.Windows.Forms.ToolStripSplitButton();
            this.cmsNods = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.isMainFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxMenu.SuspendLayout();
            this.pnlDisplayThumbNill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxThumbNill)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.cmsNods.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cntxMenu
            // 
            this.cntxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem3,
            this.tsmOtherFiles});
            this.cntxMenu.Name = "contextMenuStrip1";
            this.cntxMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cntxMenu.Size = new System.Drawing.Size(131, 70);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5,
            this.tsmPattern,
            this.toolStripMenuItem10});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(130, 22);
            this.toolStripMenuItem1.Text = "Typed File";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem5.Text = "New File...";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // tsmPattern
            // 
            this.tsmPattern.Name = "tsmPattern";
            this.tsmPattern.Size = new System.Drawing.Size(136, 22);
            this.tsmPattern.Text = "Pattern";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem10.Text = "Ready File...";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.toolStripMenuItem10_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(130, 22);
            this.toolStripMenuItem3.Text = "Scan...";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // tsmOtherFiles
            // 
            this.tsmOtherFiles.Name = "tsmOtherFiles";
            this.tsmOtherFiles.Size = new System.Drawing.Size(130, 22);
            this.tsmOtherFiles.Text = "Existing File";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons2.png");
            this.imageList1.Images.SetKeyName(1, "files.jpg");
            this.imageList1.Images.SetKeyName(2, "scanner.jpg");
            this.imageList1.Images.SetKeyName(3, "icons2.png");
            this.imageList1.Images.SetKeyName(4, "Copy of files.png");
            this.imageList1.Images.SetKeyName(5, "Copy of scanner.png");
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(168, 22);
            this.toolStripMenuItem6.Text = "toolStripMenuItem6";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(168, 22);
            this.toolStripMenuItem7.Text = "toolStripMenuItem7";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(168, 22);
            this.toolStripMenuItem8.Text = "toolStripMenuItem8";
            // 
            // odlSelectPatternFile
            // 
            this.odlSelectPatternFile.DefaultExt = "docx";
            this.odlSelectPatternFile.FileName = "openFileDialog1";
            this.odlSelectPatternFile.Filter = "Word documents 2007 (*.docx)|*.docx";
            // 
            // lstvFiles
            // 
            this.lstvFiles.ContextMenuStrip = this.cntxMenu;
            this.lstvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstvFiles.GridLines = true;
            listViewGroup1.Header = "Typed File";
            listViewGroup1.Name = "lvgWord";
            listViewGroup2.Header = "Scan";
            listViewGroup2.Name = "lvgImage";
            listViewGroup3.Header = "Other Files";
            listViewGroup3.Name = "lvgOtherFiles";
            this.lstvFiles.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.lstvFiles.LabelEdit = true;
            this.lstvFiles.LargeImageList = this.imageList1;
            this.lstvFiles.Location = new System.Drawing.Point(0, 25);
            this.lstvFiles.Name = "lstvFiles";
            this.lstvFiles.Size = new System.Drawing.Size(671, 335);
            this.lstvFiles.StateImageList = this.imageList1;
            this.lstvFiles.TabIndex = 5;
            this.lstvFiles.UseCompatibleStateImageBehavior = false;
            this.lstvFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstvFiles_MouseDoubleClick);
            this.lstvFiles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstvFiles_MouseClick);
            this.lstvFiles.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lstvFiles_AfterLabelEdit);
            this.lstvFiles.ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler(this.lstvFiles_ItemMouseHover);
            this.lstvFiles.SelectedIndexChanged += new System.EventHandler(this.lstvFiles_SelectedIndexChanged);
            this.lstvFiles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstvFiles_MouseDown);
            // 
            // pnlDisplayThumbNill
            // 
            this.pnlDisplayThumbNill.AutoScroll = true;
            this.pnlDisplayThumbNill.BackColor = System.Drawing.Color.White;
            this.pnlDisplayThumbNill.Controls.Add(this.picBoxThumbNill);
            this.pnlDisplayThumbNill.Location = new System.Drawing.Point(17, 42);
            this.pnlDisplayThumbNill.Name = "pnlDisplayThumbNill";
            this.pnlDisplayThumbNill.Size = new System.Drawing.Size(200, 156);
            this.pnlDisplayThumbNill.TabIndex = 7;
            // 
            // picBoxThumbNill
            // 
            this.picBoxThumbNill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picBoxThumbNill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBoxThumbNill.ErrorImage = null;
            this.picBoxThumbNill.ImageLocation = "center";
            this.picBoxThumbNill.Location = new System.Drawing.Point(0, 0);
            this.picBoxThumbNill.Name = "picBoxThumbNill";
            this.picBoxThumbNill.Padding = new System.Windows.Forms.Padding(1);
            this.picBoxThumbNill.Size = new System.Drawing.Size(200, 156);
            this.picBoxThumbNill.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxThumbNill.TabIndex = 7;
            this.picBoxThumbNill.TabStop = false;
            this.picBoxThumbNill.VisibleChanged += new System.EventHandler(this.picBoxThumbNill_VisibleChanged);
            this.picBoxThumbNill.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picBoxThumbNill_MouseClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssbTypedWord,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.tsmTopOtherFiles});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(671, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tssbTypedWord
            // 
            this.tssbTypedWord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssbTypedWord.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.typedFileToolStripMenuItem,
            this.tsmTopPattern,
            this.readyFileToolStripMenuItem});
            this.tssbTypedWord.Image = ((System.Drawing.Image)(resources.GetObject("tssbTypedWord.Image")));
            this.tssbTypedWord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbTypedWord.Name = "tssbTypedWord";
            this.tssbTypedWord.Size = new System.Drawing.Size(72, 22);
            this.tssbTypedWord.Text = "Typed File";
            // 
            // typedFileToolStripMenuItem
            // 
            this.typedFileToolStripMenuItem.Name = "typedFileToolStripMenuItem";
            this.typedFileToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.typedFileToolStripMenuItem.Text = "New...";
            this.typedFileToolStripMenuItem.Click += new System.EventHandler(this.typedFileToolStripMenuItem_Click);
            // 
            // tsmTopPattern
            // 
            this.tsmTopPattern.Name = "tsmTopPattern";
            this.tsmTopPattern.Size = new System.Drawing.Size(136, 22);
            this.tsmTopPattern.Text = "Pattern";
            // 
            // readyFileToolStripMenuItem
            // 
            this.readyFileToolStripMenuItem.Name = "readyFileToolStripMenuItem";
            this.readyFileToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.readyFileToolStripMenuItem.Text = "Ready File...";
            this.readyFileToolStripMenuItem.Click += new System.EventHandler(this.readyFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(50, 22);
            this.toolStripButton1.Text = "Scan";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsmTopOtherFiles
            // 
            this.tsmTopOtherFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsmTopOtherFiles.Image = ((System.Drawing.Image)(resources.GetObject("tsmTopOtherFiles.Image")));
            this.tsmTopOtherFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmTopOtherFiles.Name = "tsmTopOtherFiles";
            this.tsmTopOtherFiles.Size = new System.Drawing.Size(79, 22);
            this.tsmTopOtherFiles.Text = "Existing File";
            // 
            // cmsNods
            // 
            this.cmsNods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.isMainFileToolStripMenuItem});
            this.cmsNods.Name = "contextMenuStrip1";
            this.cmsNods.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmsNods.Size = new System.Drawing.Size(128, 92);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // isMainFileToolStripMenuItem
            // 
            this.isMainFileToolStripMenuItem.Name = "isMainFileToolStripMenuItem";
            this.isMainFileToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.isMainFileToolStripMenuItem.Text = "Is Main File";
            this.isMainFileToolStripMenuItem.Click += new System.EventHandler(this.isMainFileToolStripMenuItem_Click);
            // 
            // JUC_AttachmentManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.lstvFiles);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pnlDisplayThumbNill);
            this.Name = "JUC_AttachmentManager";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(671, 360);
            this.Load += new System.EventHandler(this.JUC_AttachmentManager_Load);
            this.cntxMenu.ResumeLayout(false);
            this.pnlDisplayThumbNill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxThumbNill)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.cmsNods.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ContextMenuStrip cntxMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem tsmPattern;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem tsmOtherFiles;
        private System.Windows.Forms.OpenFileDialog odlSelectPatternFile;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView lstvFiles;
        private System.Windows.Forms.Panel pnlDisplayThumbNill;
        private System.Windows.Forms.PictureBox picBoxThumbNill;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSplitButton tssbTypedWord;
        private System.Windows.Forms.ToolStripMenuItem typedFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmTopPattern;
        private System.Windows.Forms.ToolStripMenuItem readyFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSplitButton tsmTopOtherFiles;
        private System.Windows.Forms.ContextMenuStrip cmsNods;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem isMainFileToolStripMenuItem;

    }
}
