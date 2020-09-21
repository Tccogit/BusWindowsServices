namespace ClassLibrary.Person.Find
{
    partial class JDetailCodeForm
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
            this.dgvDetailCodeForm = new System.Windows.Forms.DataGridView();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnsearch = new System.Windows.Forms.Button();
            this.btmClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailCodeForm)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "کد:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "عنوان:";
            // 
            // dgvDetailCodeForm
            // 
            this.dgvDetailCodeForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetailCodeForm.Location = new System.Drawing.Point(49, 96);
            this.dgvDetailCodeForm.Name = "dgvDetailCodeForm";
            this.dgvDetailCodeForm.Size = new System.Drawing.Size(367, 218);
            this.dgvDetailCodeForm.TabIndex = 3;
            this.dgvDetailCodeForm.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetailCodeForm_CellContentClick);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(77, 56);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(131, 23);
            this.txtTitle.TabIndex = 1;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(77, 12);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(131, 23);
            this.txtCode.TabIndex = 0;
            // 
            // btnsearch
            // 
            this.btnsearch.Location = new System.Drawing.Point(107, 331);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(75, 23);
            this.btnsearch.TabIndex = 2;
            this.btnsearch.Text = "جستجو";
            this.btnsearch.UseVisualStyleBackColor = true;
            // 
            // btmClose
            // 
            this.btmClose.Location = new System.Drawing.Point(278, 331);
            this.btmClose.Name = "btmClose";
            this.btmClose.Size = new System.Drawing.Size(75, 23);
            this.btmClose.TabIndex = 3;
            this.btmClose.Text = "خروج";
            this.btmClose.UseVisualStyleBackColor = true;
            // 
            // JDetailCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 369);
            this.Controls.Add(this.btmClose);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.dgvDetailCodeForm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "JDetailCodeForm";
            this.Text = "جستجوی کد تفضیلی اشخاص";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailCodeForm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDetailCodeForm;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.Button btmClose;

    }
}