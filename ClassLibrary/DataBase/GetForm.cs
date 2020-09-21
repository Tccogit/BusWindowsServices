using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary.DataBase
{
    public partial class GetLoginTypeForm : Form
    {
        public GetLoginTypeForm()
        {
            //JSystem.WebConnect = false;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GetLoginTypeForm_Load(object sender, EventArgs e)
        {

        }

        private void RBLocal_CheckedChanged(object sender, EventArgs e)
        {
            //JSystem.WebConnect = false;
        }

        private void RemLocal_CheckedChanged(object sender, EventArgs e)
        {
            //JSystem.WebConnect = true;
        }
    }
}
