namespace ClassLibrary
{
    partial class JHamkaranForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.jdgvInfo = new ClassLibrary.JJanusGrid();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.jdgvTafsili = new ClassLibrary.JJanusGrid();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuConfirm = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 631);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(894, 18);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.jdgvInfo);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(703, 631);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "اطلاعات افراد";
            // 
            // jdgvInfo
            // 
            this.jdgvInfo.ActionMenu = null;
            this.jdgvInfo.DataSource = null;
            this.jdgvInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jdgvInfo.Edited = false;
            this.jdgvInfo.Location = new System.Drawing.Point(3, 19);
            this.jdgvInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jdgvInfo.MultiSelect = true;
            this.jdgvInfo.Name = "jdgvInfo";
            this.jdgvInfo.ShowNavigator = true;
            this.jdgvInfo.ShowToolbar = true;
            this.jdgvInfo.Size = new System.Drawing.Size(697, 609);
            this.jdgvInfo.TabIndex = 0;
            this.jdgvInfo.OnRowDBClick += new ClassLibrary.JJanusGrid.RowDBClick(this.jdgvInfo_OnRowDBClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.jdgvTafsili);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(703, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(455, 631);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "کد تفصیلی افراد";
            // 
            // jdgvTafsili
            // 
            this.jdgvTafsili.ActionMenu = null;
            this.jdgvTafsili.ContextMenuStrip = this.contextMenuStrip1;
            this.jdgvTafsili.DataSource = null;
            this.jdgvTafsili.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jdgvTafsili.Edited = false;
            this.jdgvTafsili.Location = new System.Drawing.Point(3, 19);
            this.jdgvTafsili.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jdgvTafsili.MultiSelect = true;
            this.jdgvTafsili.Name = "jdgvTafsili";
            this.jdgvTafsili.ShowNavigator = true;
            this.jdgvTafsili.ShowToolbar = true;
            this.jdgvTafsili.Size = new System.Drawing.Size(449, 609);
            this.jdgvTafsili.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuConfirm});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(96, 26);
            // 
            // MenuConfirm
            // 
            this.MenuConfirm.Name = "MenuConfirm";
            this.MenuConfirm.Size = new System.Drawing.Size(95, 22);
            this.MenuConfirm.Text = "تایید";
            this.MenuConfirm.Click += new System.EventHandler(this.MenuConfirm_Click);
            // 
            // JHamkaranForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 649);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "JHamkaranForm";
            this.Text = "";
            this.Load += new System.EventHandler(this.JHamkaranForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private JJanusGrid jdgvInfo;
        private System.Windows.Forms.GroupBox groupBox3;
        private JJanusGrid jdgvTafsili;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuConfirm;
    }
}