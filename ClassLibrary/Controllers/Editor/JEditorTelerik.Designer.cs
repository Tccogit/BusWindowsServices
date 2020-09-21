namespace ClassLibrary.Controllers.Editor
{
    partial class JEditorTelerik
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
            this.radRichTextEditor1 = new Telerik.WinControls.UI.RadRichTextEditor();
            this.richTextEditorRibbonBar2 = new Telerik.WinControls.UI.RichTextEditorRibbonBar();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnWord = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.radRichTextEditor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.richTextEditorRibbonBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radRichTextEditor1
            // 
            this.radRichTextEditor1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            this.radRichTextEditor1.CaretWidth = float.NaN;
            this.radRichTextEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radRichTextEditor1.Location = new System.Drawing.Point(0, 210);
            this.radRichTextEditor1.Name = "radRichTextEditor1";
            this.radRichTextEditor1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radRichTextEditor1.SelectionFill = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(78)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.radRichTextEditor1.Size = new System.Drawing.Size(612, 194);
            this.radRichTextEditor1.TabIndex = 1;
            // 
            // richTextEditorRibbonBar2
            // 
            this.richTextEditorRibbonBar2.ApplicationMenuStyle = Telerik.WinControls.UI.ApplicationMenuStyle.BackstageView;
            this.richTextEditorRibbonBar2.AssociatedRichTextEditor = this.radRichTextEditor1;
            this.richTextEditorRibbonBar2.BuiltInStylesVersion = Telerik.WinForms.Documents.Model.Styles.BuiltInStylesVersion.Office2013;
            this.richTextEditorRibbonBar2.Location = new System.Drawing.Point(0, 36);
            this.richTextEditorRibbonBar2.Name = "richTextEditorRibbonBar2";
            this.richTextEditorRibbonBar2.Size = new System.Drawing.Size(612, 174);
            this.richTextEditorRibbonBar2.TabIndex = 2;
            this.richTextEditorRibbonBar2.TabStop = false;
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.btnWord);
            this.radPanel1.Controls.Add(this.btnPrint);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(612, 36);
            this.radPanel1.TabIndex = 0;
            this.radPanel1.Visible = false;
            this.radPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.radPanel1_Paint);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(3, 7);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "چاپ";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnWord
            // 
            this.btnWord.Location = new System.Drawing.Point(84, 7);
            this.btnWord.Name = "btnWord";
            this.btnWord.Size = new System.Drawing.Size(100, 23);
            this.btnWord.TabIndex = 1;
            this.btnWord.Text = "مایکروسافت ورد";
            this.btnWord.UseVisualStyleBackColor = true;
            this.btnWord.Click += new System.EventHandler(this.btnWord_Click);
            // 
            // JEditorTelerik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radRichTextEditor1);
            this.Controls.Add(this.richTextEditorRibbonBar2);
            this.Controls.Add(this.radPanel1);
            this.Name = "JEditorTelerik";
            this.Size = new System.Drawing.Size(612, 404);
            ((System.ComponentModel.ISupportInitialize)(this.radRichTextEditor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.richTextEditorRibbonBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadRichTextEditor radRichTextEditor1;
        private Telerik.WinControls.UI.RichTextEditorRibbonBar richTextEditorRibbonBar2;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnWord;

    }
}
