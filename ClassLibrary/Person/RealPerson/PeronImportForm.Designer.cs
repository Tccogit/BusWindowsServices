namespace ClassLibrary.Person.RealPerson
{
    partial class PeronImportForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbImage = new System.Windows.Forms.TextBox();
            this.tbEmza = new System.Windows.Forms.TextBox();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "آدرس شاخه فایلها :";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(137, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(325, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "...";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "انتخاب آدرس ...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "عکس شخص شامل باشد:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "امضا شامل باشد:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "توضیحات شامل باشد:";
            // 
            // tbImage
            // 
            this.tbImage.Location = new System.Drawing.Point(175, 84);
            this.tbImage.Name = "tbImage";
            this.tbImage.Size = new System.Drawing.Size(100, 23);
            this.tbImage.TabIndex = 3;
            this.tbImage.Text = "ax";
            // 
            // tbEmza
            // 
            this.tbEmza.Location = new System.Drawing.Point(175, 113);
            this.tbEmza.Name = "tbEmza";
            this.tbEmza.Size = new System.Drawing.Size(100, 23);
            this.tbEmza.TabIndex = 3;
            this.tbEmza.Text = "e";
            // 
            // tbDesc
            // 
            this.tbDesc.Location = new System.Drawing.Point(175, 146);
            this.tbDesc.Multiline = true;
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbDesc.Size = new System.Drawing.Size(287, 134);
            this.tbDesc.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(162, 328);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "شروع";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(451, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "اطلاعات پس از پردازش اتومات از روی هارد پاک می گردد. حتما کپی داشته باش!!!";
            // 
            // PeronImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 363);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tbDesc);
            this.Controls.Add(this.tbEmza);
            this.Controls.Add(this.tbImage);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PeronImportForm";
            this.Text = "PeronImportForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbImage;
        private System.Windows.Forms.TextBox tbEmza;
        private System.Windows.Forms.TextBox tbDesc;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
    }
}