using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary.Controllers.Grid
{
    public partial class LinesCountForm : ClassLibrary.JBaseForm
    {
        public LinesCountForm()
        {
            InitializeComponent();
        }
        public int ReturnValue;
        private void btnOK_Click(object sender, EventArgs e)
        {
            ReturnValue = textEdit1.IntValue;
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }
    }
}
