using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
namespace BusManagment.Station
{
    public partial class StationSearch :ClassLibrary.JBaseForm
    {
        public int SelectedCode = 0;
        public string ID;
        public StationSearch()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string str = txtNameStation.Text;
                DB.setQuery("SELECT * FROM AUTDrive WHERE Name LIKE '%" + str + "%'  ");
                jJanusGrid1.DataSource = DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
        }

        private void StationSearch_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            if (jJanusGrid1.gridEX1.CurrentRow != null)
            {
                SelectedCode = (int)((DataRowView)jJanusGrid1.gridEX1.CurrentRow.DataRow).Row["Code"];
            }
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
