using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary.SMS
{
    public partial class SMSGroupSelect : ClassLibrary.JBaseForm
    {
        public int SelectedGroup;
        public SMSGroupSelect()
        {
            InitializeComponent();
        }

        private void RefreshList()
        {
            DataTable DT = JSMSGroupDefines.GetDataTable(true);
            DT.Columns.Remove("UserCode");
            dgrGroups.DataSource = DT;
            dgrGroups.Columns["SQL"].Visible = false;
        }

        private void SMSGroupSelect_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgrGroups.SelectedRows.Count > 0)
                this.DialogResult = DialogResult.OK;
        }

        private void dgrGroups_SelectionChanged(object sender, EventArgs e)
        {
            if (dgrGroups.SelectedRows.Count <= 0) return;
            SelectedGroup = Convert.ToInt32(dgrGroups.SelectedRows[0].Cells["Code"].Value);
        }

        private void dgrGroups_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnAdd_Click(null, null);
        }

        private void btnManageGroups_Click(object sender, EventArgs e)
        {
            (new SMSGroupForm()).ShowDialog();
            RefreshList();
        }
    }
}
