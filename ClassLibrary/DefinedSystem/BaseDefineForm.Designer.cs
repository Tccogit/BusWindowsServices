namespace ClassLibrary
{
    partial class JBaseDefineForm
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
            this.DefineNamelabel = new System.Windows.Forms.Label();
            this.NametextBox = new System.Windows.Forms.TextBox();
            this.OKbutton = new System.Windows.Forms.Button();
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.ParentNameLabel = new System.Windows.Forms.Label();
            this.ParentcomboBox = new System.Windows.Forms.ComboBox();
            this.DefinegroupBox = new System.Windows.Forms.GroupBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.DefinegroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // DefineNamelabel
            // 
            this.DefineNamelabel.AutoSize = true;
            this.DefineNamelabel.Location = new System.Drawing.Point(240, 31);
            this.DefineNamelabel.Name = "DefineNamelabel";
            this.DefineNamelabel.Size = new System.Drawing.Size(20, 16);
            this.DefineNamelabel.TabIndex = 0;
            this.DefineNamelabel.Text = "   ";
            // 
            // NametextBox
            // 
            this.NametextBox.Location = new System.Drawing.Point(6, 50);
            this.NametextBox.Name = "NametextBox";
            this.NametextBox.Size = new System.Drawing.Size(317, 23);
            this.NametextBox.TabIndex = 0;
            // 
            // OKbutton
            // 
            this.OKbutton.Location = new System.Drawing.Point(12, 159);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(75, 23);
            this.OKbutton.TabIndex = 1;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.Location = new System.Drawing.Point(266, 159);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(75, 23);
            this.Cancelbutton.TabIndex = 2;
            this.Cancelbutton.Text = "Cancel";
            this.Cancelbutton.UseVisualStyleBackColor = true;
            this.Cancelbutton.Click += new System.EventHandler(this.Cancelbutton_Click);
            // 
            // ParentNameLabel
            // 
            this.ParentNameLabel.AutoSize = true;
            this.ParentNameLabel.Location = new System.Drawing.Point(236, 76);
            this.ParentNameLabel.Name = "ParentNameLabel";
            this.ParentNameLabel.Size = new System.Drawing.Size(87, 16);
            this.ParentNameLabel.TabIndex = 4;
            this.ParentNameLabel.Text = "Parent Name:";
            this.ParentNameLabel.Visible = false;
            // 
            // ParentcomboBox
            // 
            this.ParentcomboBox.FormattingEnabled = true;
            this.ParentcomboBox.Location = new System.Drawing.Point(6, 95);
            this.ParentcomboBox.Name = "ParentcomboBox";
            this.ParentcomboBox.Size = new System.Drawing.Size(317, 24);
            this.ParentcomboBox.TabIndex = 5;
            this.ParentcomboBox.Visible = false;
            // 
            // DefinegroupBox
            // 
            this.DefinegroupBox.Controls.Add(this.NametextBox);
            this.DefinegroupBox.Controls.Add(this.ParentNameLabel);
            this.DefinegroupBox.Controls.Add(this.ParentcomboBox);
            this.DefinegroupBox.Controls.Add(this.DefineNamelabel);
            this.DefinegroupBox.Location = new System.Drawing.Point(12, 12);
            this.DefinegroupBox.Name = "DefinegroupBox";
            this.DefinegroupBox.Size = new System.Drawing.Size(329, 141);
            this.DefinegroupBox.TabIndex = 0;
            this.DefinegroupBox.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // JBaseDefineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 194);
            this.Controls.Add(this.DefinegroupBox);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.Cancelbutton);
            this.Name = "JBaseDefineForm";
            this.Text = "BaseDefineForm";
            this.DefinegroupBox.ResumeLayout(false);
            this.DefinegroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label DefineNamelabel;
        private System.Windows.Forms.TextBox NametextBox;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.Button Cancelbutton;
        private System.Windows.Forms.Label ParentNameLabel;
        private System.Windows.Forms.ComboBox ParentcomboBox;
        private System.Windows.Forms.GroupBox DefinegroupBox;
        private System.Windows.Forms.ImageList imageList1;
    }
}