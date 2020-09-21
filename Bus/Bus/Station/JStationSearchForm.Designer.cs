namespace BusManagment.Station
{
    partial class JStationSearchForm
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
            this.grdStation = new ClassLibrary.JJanusGrid();
            this.SuspendLayout();
            // 
            // grdStation
            // 
            this.grdStation.ActionClassName = "";
            this.grdStation.ActionMenu = null;
            this.grdStation.DataSource = null;
            this.grdStation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStation.Edited = false;
            this.grdStation.Location = new System.Drawing.Point(0, 0);
            this.grdStation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdStation.MultiSelect = true;
            this.grdStation.Name = "grdStation";
            this.grdStation.ShowNavigator = true;
            this.grdStation.ShowToolbar = true;
            this.grdStation.Size = new System.Drawing.Size(659, 331);
            this.grdStation.TabIndex = 0;
            this.grdStation.OnRowDBClick += new ClassLibrary.JJanusGrid.RowDBClick(this.grdStation_OnRowDBClick);
            // 
            // JStationSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 331);
            this.Controls.Add(this.grdStation);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JStationSearchForm";
            this.Text = "JStationSearchForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ClassLibrary.JJanusGrid grdStation;
    }
}