namespace ClassLibrary
{
    partial class JRuleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JRuleForm));
            this.SpellCheckbutton = new System.Windows.Forms.Button();
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.Applybutton = new System.Windows.Forms.Button();
            this.OKbutton = new System.Windows.Forms.Button();
            this.FormuletextBox = new System.Windows.Forms.TextBox();
            this.FieldListdataGridView = new System.Windows.Forms.DataGridView();
            this.Formulelabel = new System.Windows.Forms.Label();
            this.FieldListlabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FieldListdataGridView)).BeginInit();
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
            // SpellCheckbutton
            // 
            this.SpellCheckbutton.Location = new System.Drawing.Point(350, 246);
            this.SpellCheckbutton.Name = "SpellCheckbutton";
            this.SpellCheckbutton.Size = new System.Drawing.Size(29, 23);
            this.SpellCheckbutton.TabIndex = 15;
            this.SpellCheckbutton.UseVisualStyleBackColor = true;
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.Location = new System.Drawing.Point(174, 405);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(75, 23);
            this.Cancelbutton.TabIndex = 14;
            this.Cancelbutton.Text = "Cancel";
            this.Cancelbutton.UseVisualStyleBackColor = true;
            this.Cancelbutton.Click += new System.EventHandler(this.Cancelbutton_Click);
            // 
            // Applybutton
            // 
            this.Applybutton.Location = new System.Drawing.Point(93, 405);
            this.Applybutton.Name = "Applybutton";
            this.Applybutton.Size = new System.Drawing.Size(75, 23);
            this.Applybutton.TabIndex = 13;
            this.Applybutton.Text = "Apply";
            this.Applybutton.UseVisualStyleBackColor = true;
            // 
            // OKbutton
            // 
            this.OKbutton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKbutton.Location = new System.Drawing.Point(12, 405);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(75, 23);
            this.OKbutton.TabIndex = 12;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // FormuletextBox
            // 
            this.FormuletextBox.Location = new System.Drawing.Point(12, 274);
            this.FormuletextBox.Multiline = true;
            this.FormuletextBox.Name = "FormuletextBox";
            this.FormuletextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FormuletextBox.Size = new System.Drawing.Size(367, 125);
            this.FormuletextBox.TabIndex = 11;
            // 
            // FieldListdataGridView
            // 
            this.FieldListdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FieldListdataGridView.Location = new System.Drawing.Point(12, 31);
            this.FieldListdataGridView.Name = "FieldListdataGridView";
            this.FieldListdataGridView.Size = new System.Drawing.Size(367, 209);
            this.FieldListdataGridView.TabIndex = 10;
            // 
            // Formulelabel
            // 
            this.Formulelabel.AutoSize = true;
            this.Formulelabel.Location = new System.Drawing.Point(9, 255);
            this.Formulelabel.Name = "Formulelabel";
            this.Formulelabel.Size = new System.Drawing.Size(90, 16);
            this.Formulelabel.TabIndex = 8;
            this.Formulelabel.Text = "FormuleLabel:";
            // 
            // FieldListlabel
            // 
            this.FieldListlabel.AutoSize = true;
            this.FieldListlabel.Location = new System.Drawing.Point(9, 12);
            this.FieldListlabel.Name = "FieldListlabel";
            this.FieldListlabel.Size = new System.Drawing.Size(89, 16);
            this.FieldListlabel.TabIndex = 9;
            this.FieldListlabel.Text = "FieldListLabel:";
            // 
            // JRuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 441);
            this.Controls.Add(this.SpellCheckbutton);
            this.Controls.Add(this.Cancelbutton);
            this.Controls.Add(this.Applybutton);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.FormuletextBox);
            this.Controls.Add(this.FieldListdataGridView);
            this.Controls.Add(this.Formulelabel);
            this.Controls.Add(this.FieldListlabel);
            this.Name = "JRuleForm";
            this.Text = "RuleForm";
            ((System.ComponentModel.ISupportInitialize)(this.FieldListdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SpellCheckbutton;
        private System.Windows.Forms.Button Cancelbutton;
        private System.Windows.Forms.Button Applybutton;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.TextBox FormuletextBox;
        private System.Windows.Forms.DataGridView FieldListdataGridView;
        private System.Windows.Forms.Label Formulelabel;
        private System.Windows.Forms.Label FieldListlabel;
    }
}