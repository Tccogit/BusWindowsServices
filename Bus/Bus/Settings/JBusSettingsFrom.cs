using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BusManagment.Settings
{
    public partial class JBusSettingsFrom : ClassLibrary.JBaseForm
    {
        public JBusSettingsFrom()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            JBusSettings.Set("BusPercent", txtBusPercent.Text);

            this.Close();
        }

        private void JBusSettingsFrom_Load(object sender, EventArgs e)
        {
            txtBusPercent.Text = JBusSettings.Get("BusPercent").ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
