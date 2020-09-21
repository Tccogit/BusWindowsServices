namespace ClassLibrary
{
    partial class jChangePersonCodeForm
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
            this.OldjucPerson = new ClassLibrary.JUCPerson();
            this.NewjucPerson = new ClassLibrary.JUCPerson();
            this.textEdit1 = new ClassLibrary.TextEdit(this.components);
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.checkBoxRev = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // OldjucPerson
            // 
            this.OldjucPerson.FilterPerson = null;
            this.OldjucPerson.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.OldjucPerson.LableGroup = "شخصی که باید حذف شود";
            this.OldjucPerson.Location = new System.Drawing.Point(12, 12);
            this.OldjucPerson.Name = "OldjucPerson";
            this.OldjucPerson.PersonType = ClassLibrary.JPersonTypes.RealPerson;
            this.OldjucPerson.ReadOnly = false;
            this.OldjucPerson.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.OldjucPerson.SelectedCode = 0;
            this.OldjucPerson.Size = new System.Drawing.Size(418, 182);
            this.OldjucPerson.TabIndex = 0;
            // 
            // NewjucPerson
            // 
            this.NewjucPerson.FilterPerson = null;
            this.NewjucPerson.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.NewjucPerson.LableGroup = "شخصی که باید جایگزین شود";
            this.NewjucPerson.Location = new System.Drawing.Point(12, 200);
            this.NewjucPerson.Name = "NewjucPerson";
            this.NewjucPerson.PersonType = ClassLibrary.JPersonTypes.RealPerson;
            this.NewjucPerson.ReadOnly = false;
            this.NewjucPerson.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.NewjucPerson.SelectedCode = 0;
            this.NewjucPerson.Size = new System.Drawing.Size(418, 182);
            this.NewjucPerson.TabIndex = 0;
            // 
            // textEdit1
            // 
            this.textEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textEdit1.ChangeColorIfNotEmpty = false;
            this.textEdit1.ChangeColorOnEnter = true;
            this.textEdit1.InBackColor = System.Drawing.SystemColors.Info;
            this.textEdit1.InForeColor = System.Drawing.SystemColors.WindowText;
            this.textEdit1.Location = new System.Drawing.Point(193, 6);
            this.textEdit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Negative = true;
            this.textEdit1.NotEmpty = false;
            this.textEdit1.NotEmptyColor = System.Drawing.Color.Red;
            this.textEdit1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textEdit1.SelectOnEnter = true;
            this.textEdit1.Size = new System.Drawing.Size(126, 20);
            this.textEdit1.TabIndex = 37;
            this.textEdit1.Tag = "=";
            this.textEdit1.Text = "0";
            this.textEdit1.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 435);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(354, 435);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // checkBoxRev
            // 
            this.checkBoxRev.AutoSize = true;
            this.checkBoxRev.Location = new System.Drawing.Point(3, 388);
            this.checkBoxRev.Name = "checkBoxRev";
            this.checkBoxRev.Size = new System.Drawing.Size(427, 20);
            this.checkBoxRev.TabIndex = 3;
            this.checkBoxRev.Text = "پس از پایان انتقال کد شخص حدف شده به کد شخص جایگزین منتقل گردد";
            this.checkBoxRev.UseVisualStyleBackColor = true;
            // 
            // jChangePersonCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 465);
            this.Controls.Add(this.checkBoxRev);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.NewjucPerson);
            this.Controls.Add(this.OldjucPerson);
            this.Name = "jChangePersonCodeForm";
            this.Text = "ChangePersonCodeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private JUCPerson OldjucPerson;
        private JUCPerson NewjucPerson;
        private TextEdit textEdit1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox checkBoxRev;
    }
}