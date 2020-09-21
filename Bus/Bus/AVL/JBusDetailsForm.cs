using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BusManagment.AVL
{
    public partial class JBusDetailsForm : ClassLibrary.JBaseForm
    {
        string BusSerial = "";
        public JBusDetailsForm(string busSerial)
        {
            InitializeComponent();
            BusSerial = busSerial;
        }

        private void JBusDetailsForm_Load(object sender, EventArgs e)
        {
            lblBusSerial.Text += BusSerial;
        }
    }
}
