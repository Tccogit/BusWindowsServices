namespace BusManagment.Driver
{
    partial class DriverLogForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtEventDate = new ClassLibrary.DateEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.JcmbLogType = new ClassLibrary.JComboBox(this.components);
            this.btnOk = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "EventDate";
            // 
            // txtEventDate
            // 
            this.txtEventDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEventDate.ChangeColorIfNotEmpty = true;
            this.txtEventDate.ChangeColorOnEnter = true;
            this.txtEventDate.Date = new System.DateTime(((long)(0)));
            this.txtEventDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtEventDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEventDate.InsertInDatesTable = true;
            this.txtEventDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtEventDate.Location = new System.Drawing.Point(93, 13);
            this.txtEventDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEventDate.Mask = "0000/00/00";
            this.txtEventDate.Name = "txtEventDate";
            this.txtEventDate.NotEmpty = false;
            this.txtEventDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtEventDate.Size = new System.Drawing.Size(101, 23);
            this.txtEventDate.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "logType";
            // 
            // JcmbLogType
            // 
            this.JcmbLogType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.JcmbLogType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.JcmbLogType.BaseCode = 0;
            this.JcmbLogType.ChangeColorIfNotEmpty = true;
            this.JcmbLogType.ChangeColorOnEnter = true;
            this.JcmbLogType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.JcmbLogType.FormattingEnabled = true;
            this.JcmbLogType.InBackColor = System.Drawing.SystemColors.Info;
            this.JcmbLogType.InForeColor = System.Drawing.SystemColors.WindowText;
            this.JcmbLogType.Location = new System.Drawing.Point(93, 44);
            this.JcmbLogType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.JcmbLogType.Name = "JcmbLogType";
            this.JcmbLogType.NotEmpty = false;
            this.JcmbLogType.NotEmptyColor = System.Drawing.Color.Red;
            this.JcmbLogType.SelectOnEnter = true;
            this.JcmbLogType.Size = new System.Drawing.Size(223, 24);
            this.JcmbLogType.TabIndex = 3;
            // 
            // btnOk
            // 
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(338, 4);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(110, 32);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnApply
            // 
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Location = new System.Drawing.Point(454, 4);
            this.btnApply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(110, 32);
            this.btnApply.TabIndex = 5;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(3, 4);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 32);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 86);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(567, 40);
            this.panel1.TabIndex = 7;
            // 
            // DriverLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 126);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.JcmbLogType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEventDate);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DriverLogForm";
            this.Text = "DriverLogForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ClassLibrary.DateEdit txtEventDate;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.JComboBox JcmbLogType;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
    }
}