using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BusManagment.Documents
{
    public partial class JAUTDocumentReportForm : Globals.JBaseForm
    {
        public JAUTDocumentReportForm()
        {
            InitializeComponent();
            FillComboBox();
        }

        public void FillComboBox()
        {
            DataTable OwnerBus = BusManagment.Bus.JBusOwners.GetAllOwners();
            cmbOwners.DataSource = OwnerBus;
            cmbOwners.DisplayMember = "Name";
            cmbOwners.ValueMember = "OwnerPCode";

            DataTable  buses = BusManagment.Bus.JBuses.GetDataTable();
            cmbBuses.DataSource = buses;
            cmbBuses.DisplayMember = "BusNumber";
            cmbBuses.ValueMember = "code";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbBuses.SelectedIndex == -1 && cmbOwners.SelectedIndex == -1)
            {
                JMessages.Error("لطفا مالک یا اتوبوس را انتخاب کنبد.", "");
                return;
            }
            grdReport.DataSource = JAUTDocumentReport.GetData(Convert.ToInt32(cmbOwners.SelectedValue), Convert.ToInt32(cmbBuses.SelectedValue));
            DataTable tableSum = JAUTDocumentReport.GetSumData(Convert.ToInt32(cmbOwners.SelectedValue), Convert.ToInt32(cmbBuses.SelectedValue));
            lbBed.Text = JMoney.StringToMoney(tableSum.Rows[0]["Bed"].ToString());
            lbBes.Text = JMoney.StringToMoney(tableSum.Rows[0]["Bes"].ToString());
            lbRemain.Text = JMoney.StringToMoney((Convert.ToInt64(tableSum.Rows[0]["Bes"]) - Convert.ToInt64(tableSum.Rows[0]["Bed"])).ToString());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
