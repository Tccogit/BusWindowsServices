using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
namespace BusManagment.Driver
{
    public partial class DriverLogSearch :ClassLibrary.JBaseForm
    {
        public int SelectedCode;
        public DriverLogSearch()
        {
            InitializeComponent();
        }

        private void btnSearchName_Click(object sender, EventArgs e)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string str =txtEventDate.Text;

                DB.setQuery("SELECT * FROM AUTDrive WHERE Name LIKE '%" + str + "%'");
                jJanusGridResault.DataSource = DB.Query_DataTable();
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            if (jJanusGridResault.gridEX1.CurrentRow != null)
            {
                SelectedCode = (int)((DataRowView)jJanusGridResault.gridEX1.CurrentRow.DataRow).Row["Code"];
            }
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
