namespace ClassLibrary
{
    partial class JCfrmPatternFile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JCfrmPatternFile));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTitle = new ClassLibrary.TextEdit(this.components);
            this.rdoPersonal = new System.Windows.Forms.RadioButton();
            this.rdoGeneral = new System.Windows.Forms.RadioButton();
            this.odlSelectPatternFile = new System.Windows.Forms.OpenFileDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnAction = new System.Windows.Forms.Button();
            this.lblAcceptXml = new System.Windows.Forms.Label();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "title:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Select File:";
            // 
            // txtTitle
            // 
            this.txtTitle.ChangeColorIfNotEmpty = true;
            this.txtTitle.ChangeColorOnEnter = true;
            this.txtTitle.InBackColor = System.Drawing.SystemColors.Info;
            this.txtTitle.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTitle.Location = new System.Drawing.Point(114, 16);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.NotEmpty = false;
            this.txtTitle.NotEmptyColor = System.Drawing.Color.Red;
            this.txtTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTitle.SelectOnEnter = true;
            this.txtTitle.Size = new System.Drawing.Size(400, 23);
            this.txtTitle.TabIndex = 3;
            // 
            // rdoPersonal
            // 
            this.rdoPersonal.AutoSize = true;
            this.rdoPersonal.Enabled = false;
            this.rdoPersonal.Location = new System.Drawing.Point(169, 54);
            this.rdoPersonal.Name = "rdoPersonal";
            this.rdoPersonal.Size = new System.Drawing.Size(75, 20);
            this.rdoPersonal.TabIndex = 4;
            this.rdoPersonal.Text = "Personal";
            this.rdoPersonal.UseVisualStyleBackColor = true;
            // 
            // rdoGeneral
            // 
            this.rdoGeneral.AutoSize = true;
            this.rdoGeneral.Checked = true;
            this.rdoGeneral.Enabled = false;
            this.rdoGeneral.Location = new System.Drawing.Point(279, 54);
            this.rdoGeneral.Name = "rdoGeneral";
            this.rdoGeneral.Size = new System.Drawing.Size(70, 20);
            this.rdoGeneral.TabIndex = 5;
            this.rdoGeneral.TabStop = true;
            this.rdoGeneral.Text = "General";
            this.rdoGeneral.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.odlSelectPatternFile.DefaultExt = "docx";
            this.odlSelectPatternFile.FileName = "openFileDialog1";
            this.odlSelectPatternFile.Filter = "Word documents 2007 (*.docx)|*.docx";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(117, 90);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnAction
            // 
            this.btnAction.Enabled = false;
            this.btnAction.Location = new System.Drawing.Point(241, 119);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(75, 23);
            this.btnAction.TabIndex = 7;
            this.btnAction.Text = "Action";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // lblAcceptXml
            // 
            this.lblAcceptXml.AutoSize = true;
            this.lblAcceptXml.ForeColor = System.Drawing.Color.Brown;
            this.lblAcceptXml.Location = new System.Drawing.Point(212, 93);
            this.lblAcceptXml.Name = "lblAcceptXml";
            this.lblAcceptXml.Size = new System.Drawing.Size(117, 16);
            this.lblAcceptXml.TabIndex = 8;
            this.lblAcceptXml.Text = "Invalid File Content";
            // 
            // JCfrmPatternFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(574, 151);
            this.Controls.Add(this.lblAcceptXml);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.rdoGeneral);
            this.Controls.Add(this.rdoPersonal);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "JCfrmPatternFile";
            this.Load += new System.EventHandler(this.JCfrmPatternFile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ClassLibrary.TextEdit txtTitle;
        private System.Windows.Forms.RadioButton rdoPersonal;
        private System.Windows.Forms.RadioButton rdoGeneral;
        private System.Windows.Forms.OpenFileDialog odlSelectPatternFile;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.Label lblAcceptXml;
    }
}
