using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary
{
    public partial class JNotShowForm : JBaseForm
    {
        public JNotShowForm()
        {
            InitializeComponent();
        }

        public void SetText(string pText)
        {
            txtShow.Text = pText + txtShow.Text;
            txtShow.Text = Environment.NewLine + "------" + DateTime.Now.ToLocalTime() + "-------" + "- :)" + txtShow.Text;
            txtShow.SelectedText = "";
        }

        public void Clear()
        {
            txtShow.Clear();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void JNotShowForm_Shown(object sender, EventArgs e)
        {
            this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
        }
    }
}
