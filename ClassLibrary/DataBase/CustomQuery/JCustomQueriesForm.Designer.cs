namespace ClassLibrary.DataBase.CustomQuery
{
    partial class JCustomQueriesForm
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
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.cbPost = new System.Windows.Forms.ComboBox();
            this.tbNew = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tbList = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbSearch
            // 
            this.tbSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbSearch.Location = new System.Drawing.Point(0, 0);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(615, 23);
            this.tbSearch.TabIndex = 0;
            this.tbSearch.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // cbPost
            // 
            this.cbPost.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbPost.FormattingEnabled = true;
            this.cbPost.Location = new System.Drawing.Point(0, 235);
            this.cbPost.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbPost.Name = "cbPost";
            this.cbPost.Size = new System.Drawing.Size(615, 24);
            this.cbPost.TabIndex = 2;
            this.cbPost.SelectedIndexChanged += new System.EventHandler(this.cbPost_SelectedIndexChanged);
            // 
            // tbNew
            // 
            this.tbNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNew.Location = new System.Drawing.Point(0, 259);
            this.tbNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbNew.Multiline = true;
            this.tbNew.Name = "tbNew";
            this.tbNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbNew.Size = new System.Drawing.Size(615, 156);
            this.tbNew.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 415);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(615, 53);
            this.panel1.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(108, 10);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 28);
            this.button2.TabIndex = 0;
            this.button2.Text = "Apply";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 10);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tbList
            // 
            this.tbList.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbList.ItemHeight = 16;
            this.tbList.Location = new System.Drawing.Point(0, 23);
            this.tbList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbList.Name = "tbList";
            this.tbList.Size = new System.Drawing.Size(615, 212);
            this.tbList.TabIndex = 1;
            this.tbList.SelectedIndexChanged += new System.EventHandler(this.tbList_SelectedIndexChanged);
            this.tbList.DoubleClick += new System.EventHandler(this.tbList_DoubleClick);
            // 
            // JCustomQueriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 468);
            this.Controls.Add(this.tbNew);
            this.Controls.Add(this.cbPost);
            this.Controls.Add(this.tbList);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JCustomQueriesForm";
            this.Text = "JCustomQueriesForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.ComboBox cbPost;
        private System.Windows.Forms.TextBox tbNew;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox tbList;
    }
}