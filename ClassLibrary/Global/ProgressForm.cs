using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace ClassLibrary
{
    public partial class JProgressForm : JBaseForm
    {
        public bool Cancel;
        public JProgressForm(int pMaximum)
        {
            InitializeComponent();
            progressBar1.Maximum = pMaximum;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel = true;   
            Close();
        }

        public void PerformStep()
        {
            progressBar1.PerformStep();
        }
    }
}
