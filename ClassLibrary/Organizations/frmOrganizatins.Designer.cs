namespace ClassLibrary
{
    partial class JfrmOrganizatins
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JfrmOrganizatins));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAction = new System.Windows.Forms.Button();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnReturnSelected = new System.Windows.Forms.Button();
            this.btnSelOrganization = new System.Windows.Forms.Button();
            this.nedtAccessCode = new ClassLibrary.NumEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDescription = new ClassLibrary.TextEdit(this.components);
            this.txtOrganizationName = new ClassLibrary.TextEdit(this.components);
            this.txtAddress = new ClassLibrary.TextEdit(this.components);
            this.txtPhoneNumber = new ClassLibrary.TextEdit(this.components);
            this.txtManagingDirector = new ClassLibrary.TextEdit(this.components);
            this.cdbOrganizations = new ClassLibrary.JCodingBox();
            this.uc_Grd_Organizations = new ClassLibrary.UC_Grid();
            this.pnlActions.SuspendLayout();
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
            this.label1.Location = new System.Drawing.Point(672, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Organization Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(677, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Managing Director:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(306, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Phone Number:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(344, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Address:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(718, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Description:";
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(27, 118);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(75, 23);
            this.btnAction.TabIndex = 9;
            this.btnAction.Text = "Register";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // pnlActions
            // 
            this.pnlActions.Controls.Add(this.btnReturnSelected);
            this.pnlActions.Controls.Add(this.btnSelOrganization);
            this.pnlActions.Controls.Add(this.nedtAccessCode);
            this.pnlActions.Controls.Add(this.label8);
            this.pnlActions.Controls.Add(this.label7);
            this.pnlActions.Controls.Add(this.txtDescription);
            this.pnlActions.Controls.Add(this.btnAction);
            this.pnlActions.Controls.Add(this.txtOrganizationName);
            this.pnlActions.Controls.Add(this.label6);
            this.pnlActions.Controls.Add(this.txtAddress);
            this.pnlActions.Controls.Add(this.txtPhoneNumber);
            this.pnlActions.Controls.Add(this.label4);
            this.pnlActions.Controls.Add(this.label3);
            this.pnlActions.Controls.Add(this.txtManagingDirector);
            this.pnlActions.Controls.Add(this.label2);
            this.pnlActions.Controls.Add(this.label1);
            this.pnlActions.Controls.Add(this.cdbOrganizations);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlActions.Location = new System.Drawing.Point(0, 0);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(802, 164);
            this.pnlActions.TabIndex = 1;
            // 
            // btnReturnSelected
            // 
            this.btnReturnSelected.Image = ((System.Drawing.Image)(resources.GetObject("btnReturnSelected.Image")));
            this.btnReturnSelected.Location = new System.Drawing.Point(766, 135);
            this.btnReturnSelected.Margin = new System.Windows.Forms.Padding(0);
            this.btnReturnSelected.Name = "btnReturnSelected";
            this.btnReturnSelected.Size = new System.Drawing.Size(25, 20);
            this.btnReturnSelected.TabIndex = 3;
            this.btnReturnSelected.UseVisualStyleBackColor = true;
            this.btnReturnSelected.Click += new System.EventHandler(this.btnReturnSelected_Click);
            // 
            // btnSelOrganization
            // 
            this.btnSelOrganization.Location = new System.Drawing.Point(27, 65);
            this.btnSelOrganization.Name = "btnSelOrganization";
            this.btnSelOrganization.Size = new System.Drawing.Size(28, 23);
            this.btnSelOrganization.TabIndex = 7;
            this.btnSelOrganization.TabStop = false;
            this.btnSelOrganization.Text = "...";
            this.btnSelOrganization.UseVisualStyleBackColor = true;
            this.btnSelOrganization.Click += new System.EventHandler(this.btnSelOrganization_Click);
            // 
            // nedtAccessCode
            // 
            this.nedtAccessCode.ChangeColorIfNotEmpty = true;
            this.nedtAccessCode.ChangeColorOnEnter = true;
            this.nedtAccessCode.InBackColor = System.Drawing.SystemColors.Info;
            this.nedtAccessCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.nedtAccessCode.Location = new System.Drawing.Point(409, 65);
            this.nedtAccessCode.Name = "nedtAccessCode";
            this.nedtAccessCode.Negative = true;
            this.nedtAccessCode.NotEmpty = false;
            this.nedtAccessCode.NotEmptyColor = System.Drawing.Color.Red;
            this.nedtAccessCode.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.nedtAccessCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nedtAccessCode.SelectOnEnter = true;
            this.nedtAccessCode.Size = new System.Drawing.Size(257, 23);
            this.nedtAccessCode.TabIndex = 8;
            this.nedtAccessCode.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(709, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 16);
            this.label8.TabIndex = 20;
            this.label8.Text = "Access Code:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(320, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = "Parent Code:";
            // 
            // txtDescription
            // 
            this.txtDescription.ChangeColorIfNotEmpty = true;
            this.txtDescription.ChangeColorOnEnter = true;
            this.txtDescription.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDescription.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDescription.Location = new System.Drawing.Point(108, 96);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Negative = true;
            this.txtDescription.NotEmpty = false;
            this.txtDescription.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDescription.SelectOnEnter = true;
            this.txtDescription.Size = new System.Drawing.Size(558, 45);
            this.txtDescription.TabIndex = 21;
            this.txtDescription.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtOrganizationName
            // 
            this.txtOrganizationName.ChangeColorIfNotEmpty = true;
            this.txtOrganizationName.ChangeColorOnEnter = true;
            this.txtOrganizationName.InBackColor = System.Drawing.SystemColors.Info;
            this.txtOrganizationName.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOrganizationName.Location = new System.Drawing.Point(409, 3);
            this.txtOrganizationName.Name = "txtOrganizationName";
            this.txtOrganizationName.Negative = true;
            this.txtOrganizationName.NotEmpty = false;
            this.txtOrganizationName.NotEmptyColor = System.Drawing.Color.Red;
            this.txtOrganizationName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtOrganizationName.SelectOnEnter = true;
            this.txtOrganizationName.Size = new System.Drawing.Size(257, 23);
            this.txtOrganizationName.TabIndex = 22;
            this.txtOrganizationName.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtAddress
            // 
            this.txtAddress.ChangeColorIfNotEmpty = true;
            this.txtAddress.ChangeColorOnEnter = true;
            this.txtAddress.InBackColor = System.Drawing.SystemColors.Info;
            this.txtAddress.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAddress.Location = new System.Drawing.Point(27, 34);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Negative = true;
            this.txtAddress.NotEmpty = false;
            this.txtAddress.NotEmptyColor = System.Drawing.Color.Red;
            this.txtAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAddress.SelectOnEnter = true;
            this.txtAddress.Size = new System.Drawing.Size(259, 23);
            this.txtAddress.TabIndex = 23;
            this.txtAddress.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.ChangeColorIfNotEmpty = true;
            this.txtPhoneNumber.ChangeColorOnEnter = true;
            this.txtPhoneNumber.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPhoneNumber.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPhoneNumber.Location = new System.Drawing.Point(27, 3);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Negative = true;
            this.txtPhoneNumber.NotEmpty = false;
            this.txtPhoneNumber.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPhoneNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPhoneNumber.SelectOnEnter = true;
            this.txtPhoneNumber.Size = new System.Drawing.Size(259, 23);
            this.txtPhoneNumber.TabIndex = 24;
            this.txtPhoneNumber.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtManagingDirector
            // 
            this.txtManagingDirector.ChangeColorIfNotEmpty = true;
            this.txtManagingDirector.ChangeColorOnEnter = true;
            this.txtManagingDirector.InBackColor = System.Drawing.SystemColors.Info;
            this.txtManagingDirector.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtManagingDirector.Location = new System.Drawing.Point(409, 34);
            this.txtManagingDirector.Name = "txtManagingDirector";
            this.txtManagingDirector.Negative = true;
            this.txtManagingDirector.NotEmpty = false;
            this.txtManagingDirector.NotEmptyColor = System.Drawing.Color.Red;
            this.txtManagingDirector.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtManagingDirector.SelectOnEnter = true;
            this.txtManagingDirector.Size = new System.Drawing.Size(257, 23);
            this.txtManagingDirector.TabIndex = 25;
            this.txtManagingDirector.TextMode = ClassLibrary.TextModes.Text;
            // 
            // cdbOrganizations
            // 
            this.cdbOrganizations.dataTable = null;
            this.cdbOrganizations.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cdbOrganizations.Location = new System.Drawing.Point(52, 62);
            this.cdbOrganizations.Name = "cdbOrganizations";
            this.cdbOrganizations.SelectedIndex = -1;
            this.cdbOrganizations.SelectedValue = null;
            this.cdbOrganizations.Size = new System.Drawing.Size(238, 39);
            this.cdbOrganizations.TabIndex = 21;
            // 
            // uc_Grd_Organizations
            // 
            this.uc_Grd_Organizations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_Grd_Organizations.Location = new System.Drawing.Point(0, 164);
            this.uc_Grd_Organizations.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uc_Grd_Organizations.MultiSelect = false;
            this.uc_Grd_Organizations.Name = "uc_Grd_Organizations";
            this.uc_Grd_Organizations.Size = new System.Drawing.Size(802, 345);
            this.uc_Grd_Organizations.TabIndex = 2;
            this.uc_Grd_Organizations.SelectionChanged += new System.EventHandler(this.uc_Grd_Organizations_SelectionChanged);
            this.uc_Grd_Organizations.GridRowDoubleClick += new System.EventHandler(this.uc_Grd_Organizations_GridRowDoubleClick);
            // 
            // JfrmOrganizatins
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 509);
            this.Controls.Add(this.uc_Grd_Organizations);
            this.Controls.Add(this.pnlActions);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JfrmOrganizatins";
            this.RightToLeftLayout = false;
            this.Text = "frmOrganizatins";
            this.Load += new System.EventHandler(this.JfrmOrganizatins_Load);
            this.pnlActions.ResumeLayout(false);
            this.pnlActions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.TextEdit txtManagingDirector;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ClassLibrary.TextEdit txtPhoneNumber;
        private ClassLibrary.TextEdit txtAddress;
        private System.Windows.Forms.Label label6;
        private ClassLibrary.TextEdit txtOrganizationName;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.Panel pnlActions;
        private ClassLibrary.UC_Grid uc_Grd_Organizations;
        private ClassLibrary.TextEdit txtDescription;
        private ClassLibrary.NumEdit nedtAccessCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSelOrganization;
        private JCodingBox cdbOrganizations;
        private System.Windows.Forms.Button btnReturnSelected;

    }
}