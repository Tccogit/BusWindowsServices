namespace ClassLibrary
{
    partial class JEditorBase
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelSelectEditor = new System.Windows.Forms.Panel();
            this.rbWordEditor = new System.Windows.Forms.RadioButton();
            this.rdBaseEditor = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbTelerik = new System.Windows.Forms.RadioButton();
            this.panelSelectEditor.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSelectEditor
            // 
            this.panelSelectEditor.Controls.Add(this.rbTelerik);
            this.panelSelectEditor.Controls.Add(this.rbWordEditor);
            this.panelSelectEditor.Controls.Add(this.rdBaseEditor);
            this.panelSelectEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSelectEditor.Location = new System.Drawing.Point(0, 0);
            this.panelSelectEditor.Name = "panelSelectEditor";
            this.panelSelectEditor.Size = new System.Drawing.Size(406, 29);
            this.panelSelectEditor.TabIndex = 0;
            // 
            // rbWordEditor
            // 
            this.rbWordEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbWordEditor.AutoSize = true;
            this.rbWordEditor.Location = new System.Drawing.Point(197, 3);
            this.rbWordEditor.Name = "rbWordEditor";
            this.rbWordEditor.Size = new System.Drawing.Size(79, 17);
            this.rbWordEditor.TabIndex = 1;
            this.rbWordEditor.TabStop = true;
            this.rbWordEditor.Text = "OfficeWord";
            this.rbWordEditor.UseVisualStyleBackColor = true;
            this.rbWordEditor.CheckedChanged += new System.EventHandler(this.rdBaseEditor_CheckedChanged);
            this.rbWordEditor.EnabledChanged += new System.EventHandler(this.rbWordEditor_EnabledChanged);
            // 
            // rdBaseEditor
            // 
            this.rdBaseEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdBaseEditor.AutoSize = true;
            this.rdBaseEditor.Checked = true;
            this.rdBaseEditor.Location = new System.Drawing.Point(318, 3);
            this.rdBaseEditor.Name = "rdBaseEditor";
            this.rdBaseEditor.Size = new System.Drawing.Size(76, 17);
            this.rdBaseEditor.TabIndex = 0;
            this.rdBaseEditor.TabStop = true;
            this.rdBaseEditor.Text = "BaseEditor";
            this.rdBaseEditor.UseVisualStyleBackColor = true;
            this.rdBaseEditor.CheckedChanged += new System.EventHandler(this.rdBaseEditor_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(406, 280);
            this.panel1.TabIndex = 1;
            this.panel1.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.JEditorBase_ControlRemoved);
            // 
            // rbTelerik
            // 
            this.rbTelerik.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbTelerik.AutoSize = true;
            this.rbTelerik.Location = new System.Drawing.Point(98, 3);
            this.rbTelerik.Name = "rbTelerik";
            this.rbTelerik.Size = new System.Drawing.Size(57, 17);
            this.rbTelerik.TabIndex = 2;
            this.rbTelerik.TabStop = true;
            this.rbTelerik.Text = "Telerik";
            this.rbTelerik.UseVisualStyleBackColor = true;
            this.rbTelerik.CheckedChanged += new System.EventHandler(this.rdBaseEditor_CheckedChanged);
            this.rbTelerik.Click += new System.EventHandler(this.rbTelerik_Click);
            // 
            // JEditorBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelSelectEditor);
            this.Name = "JEditorBase";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(406, 309);
            this.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.JEditorBase_ControlRemoved);
            this.panelSelectEditor.ResumeLayout(false);
            this.panelSelectEditor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSelectEditor;
        private System.Windows.Forms.RadioButton rbWordEditor;
        private System.Windows.Forms.RadioButton rdBaseEditor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbTelerik;
    }
}
