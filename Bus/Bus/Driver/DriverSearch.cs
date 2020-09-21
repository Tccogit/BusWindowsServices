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
    public partial class DriverSearch :ClassLibrary.JBaseForm
    {
        public int SelectedCode = 0;
        public DriverSearch()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void btnSearchName_Click(object sender, EventArgs e)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string str = txtName.Text;
                string owner = txtOwner.Text;
                DB.setQuery("SELECT * FROM AUTDrive AD INNER JOIN clsAllPerson CL ON CL.Code=AD.Code  WHERE CL.Name LIKE '%"+str+"%' ");
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

        private void btnSearchCode_Click(object sender, EventArgs e)
        {
            JDataBase DB = new JDataBase();
            try
            {
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

        private void btnook_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            if (jJanusGridResault.gridEX1.CurrentRow != null)
            {
                SelectedCode = (int)((DataRowView)jJanusGridResault.gridEX1.CurrentRow.DataRow).Row["Code"];
            }
            Close();
        }
    }
}
