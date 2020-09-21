namespace BusManagment.Driver
{
    partial class DriverLogSearch
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtEventDate = new ClassLibrary.DateEdit(this.components);
            this.btnSearchEventDate = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.jJanusGridResault = new ClassLibrary.JJanusGrid();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtEventDate);
            this.panel1.Controls.Add(this.btnSearchEventDate);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(696, 48);
            this.panel1.TabIndex = 3;
            // 
            // txtEventDate
            // 
            this.txtEventDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEventDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEventDate.ChangeColorIfNotEmpty = true;
            this.txtEventDate.ChangeColorOnEnter = true;
            this.txtEventDate.Date = new System.DateTime(((long)(0)));
            this.txtEventDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtEventDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEventDate.InsertInDatesTable = true;
            this.txtEventDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtEventDate.Location = new System.Drawing.Point(437, 13);
            this.txtEventDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEventDate.Mask = "0000/00/00";
            this.txtEventDate.Name = "txtEventDate";
            this.txtEventDate.NotEmpty = false;
            this.txtEventDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtEventDate.Size = new System.Drawing.Size(143, 23);
            this.txtEventDate.TabIndex = 367;
            // 
            // btnSearchEventDate
            // 
            this.btnSearchEventDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchEventDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchEventDate.Location = new System.Drawing.Point(326, 13);
            this.btnSearchEventDate.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSearchEventDate.Name = "btnSearchEventDate";
            this.btnSearchEventDate.Size = new System.Drawing.Size(105, 23);
            this.btnSearchEventDate.TabIndex = 366;
            this.btnSearchEventDate.Text = "Search";
            this.btnSearchEventDate.UseVisualStyleBackColor = true;
            this.btnSearchEventDate.Click += new System.EventHandler(this.btnSearchName_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(600, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 16);
            this.label6.TabIndex = 360;
            this.label6.Text = "Event Date";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnOk);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 461);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(696, 41);
            this.panel2.TabIndex = 369;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(12, 5);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 32);
            this.btnClose.TabIndex = 371;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(574, 5);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(110, 32);
            this.btnOk.TabIndex = 370;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // jJanusGridResault
            // 
            this.jJanusGridResault.ActionClassName = "";
            this.jJanusGridResault.ActionMenu = null;
            this.jJanusGridResault.DataSource = null;
            this.jJanusGridResault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jJanusGridResault.Edited = false;
            this.jJanusGridResault.Location = new System.Drawing.Point(0, 48);
            this.jJanusGridResault.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.jJanusGridResault.MultiSelect = true;
            this.jJanusGridResault.Name = "jJanusGridResault";
            this.jJanusGridResault.ShowNavigator = true;
            this.jJanusGridResault.ShowToolbar = true;
            this.jJanusGridResault.Size = new System.Drawing.Size(696, 413);
            this.jJanusGridResault.TabIndex = 370;
            // 
            // DriverLogSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 502);
            this.Controls.Add(this.jJanusGridResault);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DriverLogSearch";
            this.Text = "DriverLogSearch";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearchEventDate;
        private System.Windows.Forms.Label label6;
        private ClassLibrary.DateEdit txtEventDate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOk;
        private ClassLibrary.JJanusGrid jJanusGridResault;
    }
}