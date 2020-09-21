namespace ClassLibrary
{
    partial class JPostHistoryForm
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
            this.jGPersonHostory = new ClassLibrary.JJanusGrid();
            this.jGDataTableHistory = new ClassLibrary.JJanusGrid();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // jGPersonHostory
            // 
            this.jGPersonHostory.ActionMenu = null;
            this.jGPersonHostory.DataSource = null;
            this.jGPersonHostory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jGPersonHostory.Location = new System.Drawing.Point(0, 0);
            this.jGPersonHostory.MultiSelect = false;
            this.jGPersonHostory.Name = "jGPersonHostory";
            this.jGPersonHostory.Size = new System.Drawing.Size(583, 244);
            this.jGPersonHostory.TabIndex = 0;
            // 
            // jGDataTableHistory
            // 
            this.jGDataTableHistory.ActionMenu = null;
            this.jGDataTableHistory.DataSource = null;
            this.jGDataTableHistory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.jGDataTableHistory.Location = new System.Drawing.Point(0, 280);
            this.jGDataTableHistory.MultiSelect = false;
            this.jGDataTableHistory.Name = "jGDataTableHistory";
            this.jGDataTableHistory.Size = new System.Drawing.Size(583, 171);
            this.jGDataTableHistory.TabIndex = 1;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 272);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(583, 8);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 244);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 28);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(529, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // JPostHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 451);
            this.Controls.Add(this.jGPersonHostory);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.jGDataTableHistory);
            this.Name = "JPostHistoryForm";
            this.Text = "PostHistoryForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private JJanusGrid jGPersonHostory;
        private JJanusGrid jGDataTableHistory;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}