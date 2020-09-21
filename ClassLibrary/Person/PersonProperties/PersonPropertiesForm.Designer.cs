namespace ClassLibrary
{
    partial class JPersonPropertiesForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.propertiesRealPerson = new Globals.Property.JDefinePropertyUserControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.propertiesLegalPerson = new Globals.Property.JDefinePropertyUserControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(732, 414);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.propertiesRealPerson);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(724, 385);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ویژگی اشخاص حقیقی";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // propertiesRealPerson
            // 
            this.propertiesRealPerson.ClassName = null;
            this.propertiesRealPerson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertiesRealPerson.Location = new System.Drawing.Point(3, 3);
            this.propertiesRealPerson.Name = "propertiesRealPerson";
            this.propertiesRealPerson.ObjectCode = 0;
            this.propertiesRealPerson.Size = new System.Drawing.Size(718, 379);
            this.propertiesRealPerson.TabIndex = 0;
            this.propertiesRealPerson.AfterPropertyDeleted += new Globals.Property.JDefinePropertyUserControl.PropertyDeleted(this.propertiesRealPerson_AfterPropertyDeleted);
            this.propertiesRealPerson.AfterPropertyAdded += new Globals.Property.JDefinePropertyUserControl.PropertyAdded(this.propertiesRealPerson_AfterPropertyAdded);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.propertiesLegalPerson);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(724, 385);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ویژگی اشخاص حقوقی";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // propertiesLegalPerson
            // 
            this.propertiesLegalPerson.ClassName = null;
            this.propertiesLegalPerson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertiesLegalPerson.Location = new System.Drawing.Point(3, 3);
            this.propertiesLegalPerson.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.propertiesLegalPerson.Name = "propertiesLegalPerson";
            this.propertiesLegalPerson.ObjectCode = 0;
            this.propertiesLegalPerson.Size = new System.Drawing.Size(718, 379);
            this.propertiesLegalPerson.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 414);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(732, 50);
            this.panel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(520, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 32);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "خروج";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(623, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 32);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "ذخیره";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // JPersonPropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 464);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "JPersonPropertiesForm";
            this.Text = "ویژگی اشخاص";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private Globals.Property.JDefinePropertyUserControl propertiesRealPerson;
        private System.Windows.Forms.TabPage tabPage2;
        private Globals.Property.JDefinePropertyUserControl propertiesLegalPerson;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}