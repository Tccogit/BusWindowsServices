namespace ClassLibrary
{
    partial class JHistoryForm
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
            this.uC_GridHistory = new ClassLibrary.UC_Grid();
            this.clBFields = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // uC_GridHistory
            // 
            this.uC_GridHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_GridHistory.Location = new System.Drawing.Point(206, 0);
            this.uC_GridHistory.MultiSelect = false;
            this.uC_GridHistory.Name = "uC_GridHistory";
            this.uC_GridHistory.Size = new System.Drawing.Size(368, 451);
            this.uC_GridHistory.TabIndex = 1;
            // 
            // clBFields
            // 
            this.clBFields.Dock = System.Windows.Forms.DockStyle.Left;
            this.clBFields.FormattingEnabled = true;
            this.clBFields.Location = new System.Drawing.Point(0, 0);
            this.clBFields.Name = "clBFields";
            this.clBFields.Size = new System.Drawing.Size(206, 436);
            this.clBFields.TabIndex = 0;
            this.clBFields.SelectedIndexChanged += new System.EventHandler(this.clBFields_SelectedIndexChanged);
            this.clBFields.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clBFields_ItemCheck);
            this.clBFields.SelectedValueChanged += new System.EventHandler(this.clBFields_SelectedValueChanged);
            // 
            // JHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 451);
            this.Controls.Add(this.uC_GridHistory);
            this.Controls.Add(this.clBFields);
            this.Name = "JHistoryForm";
            this.Text = "HistoryForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clBFields;
        private UC_Grid uC_GridHistory;
    }
}