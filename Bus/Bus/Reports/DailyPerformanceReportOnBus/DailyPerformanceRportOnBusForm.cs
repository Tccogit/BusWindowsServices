using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BusManagment.Reports
{
    public partial class DailyPerformanceRportOnBusForm : JBaseForm
    {
        
        public DailyPerformanceRportOnBusForm()
        {
            InitializeComponent();
            FillComboBox();
        }

        public enum EnumReportByGroup
        {
            Price = 0,
            Driver = 1,
            Zone = 2,
            Owner = 3,
            Bus = 4,
            Line = 5
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string selectSQL = "";
            string groupSQL = "";
            string whereSQL = "Where (0=0)";
            int flag = -1;


            /// ایجاد شرط where
            if (txtBusNo.Text.Count() > 0)
                whereSQL = whereSQL + " AND tbl.BUSNumber=" + txtBusNo.Text;

            if (txtDateIn.Date.Year != 1)
                whereSQL = whereSQL + " AND tbl.Date >= '" + txtDateIn.Date.ToString("yyyy/MM/dd") + "'";

            if (txtDateOut.Date.Year != 1)
                whereSQL = whereSQL + " AND tbl.Date <= '" + txtDateOut.Date.ToString("yyyy/MM/dd") + "'";

            if (Convert.ToInt32(cmbDriverBus.SelectedValue) != -1)
                whereSQL = whereSQL + " AND tbl.DriverCode=" + cmbDriverBus.SelectedValue.ToString();

            if (txtLineNo.Text.Count() > 0)
                whereSQL = whereSQL + " AND tbl.LineNumber=" + txtLineNo.Text;

            if (Convert.ToInt32(cmbOwnerBus.SelectedValue) != -1)
                whereSQL = whereSQL + " AND tbl.OwnerCode=" + cmbOwnerBus.SelectedValue.ToString();

            if (Convert.ToInt32(cmbZone.SelectedValue) != -1)
            {
                whereSQL = whereSQL + " AND tbl.ZoneCode=" + cmbZone.SelectedValue.ToString();
            }

            // MessageBox.Show("Item with title: \"" + itemChecked.ToString() +
                //  "\", is checked. Checked state is: " + chkListGroup.GetItemCheckState(chkListGroup.Items.IndexOf(itemChecked)).ToString() + "." + ":----" + chkListGroup.Items.IndexOf(itemChecked)).ToString();
          
            foreach (object itemChecked in chkListGroup.CheckedItems)
            {

                switch (Convert.ToInt32(chkListGroup.Items.IndexOf(itemChecked)))
                {
                    case (int)EnumReportByGroup.Price:
                        selectSQL = selectSQL + " tbl.Price";
                        groupSQL = groupSQL + " group by tbl.Price";
                        flag = 0;
                        break;

                    case (int)EnumReportByGroup.Bus:
                        if (flag == 0 || flag == 1 || flag == 2 || flag == 3 || flag == 4 || flag == 5)
                        {
                            selectSQL = selectSQL + ",tbl.BUSNumber";
                            groupSQL = groupSQL + " ,tbl.BUSNumber";
                            flag = 1;
                        }
                        else
                        {
                            selectSQL = selectSQL + "tbl.BUSNumber ";
                            groupSQL = groupSQL + " group by tbl.BUSNumber";
                            flag = 1;
                        }
                        break;

                    case (int)EnumReportByGroup.Driver:
                        if (flag == 0 || flag == 1 || flag == 2 || flag == 3 || flag == 4 || flag == 5)
                        {
                            selectSQL = selectSQL + ",tbl.DriverName";
                            groupSQL = groupSQL + " ,tbl.DriverName";
                            flag = 2;
                        }
                        else
                        {
                            selectSQL = selectSQL + " tbl.DriverName";
                            groupSQL = groupSQL + " group by tbl.DriverName";
                            flag = 2;
                        }
                        break;
                    case (int)EnumReportByGroup.Line:
                        if (flag == 0 || flag == 1 || flag == 2 || flag == 3 || flag == 4 || flag == 5)
                        {
                            selectSQL = selectSQL + ",tbl.LineName";
                            groupSQL = groupSQL + " ,tbl.LineName";
                            flag = 3;
                        }
                        else
                        {
                            selectSQL = selectSQL + " tbl.LineName";
                            groupSQL = groupSQL + " group by tbl.LineName";
                            flag = 3;

                        }
                        break;

                    case (int)EnumReportByGroup.Owner:
                        if (flag == 0 || flag == 1 || flag == 2 || flag == 3 || flag == 4 || flag == 5)
                        {
                            selectSQL = selectSQL + ", tbl.BusOwnerName";
                            groupSQL = groupSQL + " ,tbl.BusOwnerName";
                            flag = 4;
                        }
                        else
                        {
                            selectSQL = selectSQL + " tbl.BusOwnerName";
                            groupSQL = groupSQL + " group by tbl.BusOwnerName";
                            flag = 4;

                        }
                        break;

                    case (int)EnumReportByGroup.Zone:
                        if (flag == 0 || flag == 1 || flag == 2 || flag == 3 || flag == 4 || flag == 5)
                        {
                            selectSQL = selectSQL + ",tbl.ZoneName";
                            groupSQL = groupSQL + " ,tbl.ZoneName";
                            flag = 5;
                        }
                        else
                        {
                            selectSQL = selectSQL + "tbl.ZoneName";
                            groupSQL = groupSQL + " group by tbl.ZoneName";
                            flag = 5;
                        }
                        break;
                }
            }

            if (flag == 0 || flag == 1 || flag == 2 || flag == 3 || flag == 4 || flag==5)
            {
                selectSQL = selectSQL + ",count(*) as tedad,sum(Price) as Price";
            }


            DataTable dt = JDailyPerformanceRportOnBus.ReportDialyPerformance(selectSQL, whereSQL, groupSQL);
            grdReport.DataSource = dt;
        } // end btn search

        public void FillComboBox()
        {
            DataTable DriverBus = BusManagment.Personel.JPersonels.GetDataTable();
            DataRow dr = DriverBus.NewRow();
            dr["Name"] = "هیچکدام";
            dr["code"] = "-1";
            DriverBus.Rows.InsertAt(dr, 0);

            cmbDriverBus.DataSource = DriverBus;
            cmbDriverBus.DisplayMember = "Name";
            cmbDriverBus.ValueMember = "code";

            DataTable OwnerBus = BusManagment.Bus.JBusOwners.GetAllOwners();
            DataRow dr1 = OwnerBus.NewRow();
            dr1["Name"] = "هیچکدام";
            dr1["code"] = "-1";
            OwnerBus.Rows.InsertAt(dr1, 0);

            cmbOwnerBus.DataSource = OwnerBus;
            cmbOwnerBus.DisplayMember = "Name";
            cmbOwnerBus.ValueMember = "code";

            DataTable Zone = BusManagment.Zone.JZones.GetDataTable();
            DataRow dr2 = Zone.NewRow();
            dr2["Name"] = "هیچکدام";
            dr2["code"] = "-1";
            Zone.Rows.InsertAt(dr2, 0);

            cmbZone.DataSource = Zone;
            cmbZone.DisplayMember = "Name";
            cmbZone.ValueMember = "code";

        }

    }
}

