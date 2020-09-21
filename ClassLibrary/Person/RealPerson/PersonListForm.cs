using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary
{
    public partial class JPersonListForm : JBaseForm
    {
        public DataRow SelectedRow;
        public JPersonListForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            grdPerson.DataSource = JPerson.SearchPerson(txtPersonCode.IntValue, txtFamily.Text);
        }

        private void grdPerson_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnOK.PerformClick();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (grdPerson.SelectedRows.Count> 0)
            {
                DataRow row = ((DataTable)grdPerson.DataSource).NewRow();
                foreach (DataGridViewColumn col in grdPerson.Columns)
                {
                    row[col.Index] = grdPerson[col.Index, grdPerson.SelectedRows[0].Index].Value;
                }
                SelectedRow = row;
                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
