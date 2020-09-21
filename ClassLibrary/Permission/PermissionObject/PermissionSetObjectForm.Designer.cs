namespace ClassLibrary
{
    partial class JPermissionSetObjectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JPermissionSetObjectForm));
            this.UserlistBox = new System.Windows.Forms.ListBox();
            this.ActioncheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.Applybutton = new System.Windows.Forms.Button();
            this.OKbutton = new System.Windows.Forms.Button();
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.InsertUserbutton = new System.Windows.Forms.Button();
            this.DeleteUserbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
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
            // UserlistBox
            // 
            this.UserlistBox.FormattingEnabled = true;
            this.UserlistBox.ItemHeight = 16;
            this.UserlistBox.Location = new System.Drawing.Point(10, 41);
            this.UserlistBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.UserlistBox.Name = "UserlistBox";
            this.UserlistBox.Size = new System.Drawing.Size(289, 100);
            this.UserlistBox.TabIndex = 0;
            // 
            // ActioncheckedListBox
            // 
            this.ActioncheckedListBox.FormattingEnabled = true;
            this.ActioncheckedListBox.Location = new System.Drawing.Point(9, 147);
            this.ActioncheckedListBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ActioncheckedListBox.Name = "ActioncheckedListBox";
            this.ActioncheckedListBox.Size = new System.Drawing.Size(352, 202);
            this.ActioncheckedListBox.TabIndex = 1;
            // 
            // Applybutton
            // 
            this.Applybutton.Location = new System.Drawing.Point(9, 359);
            this.Applybutton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Applybutton.Name = "Applybutton";
            this.Applybutton.Size = new System.Drawing.Size(58, 29);
            this.Applybutton.TabIndex = 4;
            this.Applybutton.Text = "تایید";
            this.Applybutton.UseVisualStyleBackColor = true;
            this.Applybutton.Click += new System.EventHandler(this.Applybutton_Click);
            // 
            // OKbutton
            // 
            this.OKbutton.Location = new System.Drawing.Point(72, 359);
            this.OKbutton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(58, 29);
            this.OKbutton.TabIndex = 5;
            this.OKbutton.Text = "ذخیره";
            this.OKbutton.UseVisualStyleBackColor = true;
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.Location = new System.Drawing.Point(135, 359);
            this.Cancelbutton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(58, 29);
            this.Cancelbutton.TabIndex = 6;
            this.Cancelbutton.Text = "انصراف";
            this.Cancelbutton.UseVisualStyleBackColor = true;
            // 
            // InsertUserbutton
            // 
            this.InsertUserbutton.Location = new System.Drawing.Point(303, 10);
            this.InsertUserbutton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.InsertUserbutton.Name = "InsertUserbutton";
            this.InsertUserbutton.Size = new System.Drawing.Size(58, 30);
            this.InsertUserbutton.TabIndex = 7;
            this.InsertUserbutton.Text = "درج...";
            this.InsertUserbutton.UseVisualStyleBackColor = true;
            this.InsertUserbutton.Click += new System.EventHandler(this.InsertUserbutton_Click);
            // 
            // DeleteUserbutton
            // 
            this.DeleteUserbutton.Location = new System.Drawing.Point(303, 45);
            this.DeleteUserbutton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DeleteUserbutton.Name = "DeleteUserbutton";
            this.DeleteUserbutton.Size = new System.Drawing.Size(58, 30);
            this.DeleteUserbutton.TabIndex = 8;
            this.DeleteUserbutton.Text = "حذف";
            this.DeleteUserbutton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // JPermissionSetObjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 393);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DeleteUserbutton);
            this.Controls.Add(this.InsertUserbutton);
            this.Controls.Add(this.Cancelbutton);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.Applybutton);
            this.Controls.Add(this.ActioncheckedListBox);
            this.Controls.Add(this.UserlistBox);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "JPermissionSetObjectForm";
            this.Text = "دسترسی ها";
            this.Load += new System.EventHandler(this.JPermissionSetObjectForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox UserlistBox;
        private System.Windows.Forms.CheckedListBox ActioncheckedListBox;
        private System.Windows.Forms.Button Applybutton;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.Button Cancelbutton;
        private System.Windows.Forms.Button InsertUserbutton;
        private System.Windows.Forms.Button DeleteUserbutton;
        private System.Windows.Forms.Label label1;
    }
}