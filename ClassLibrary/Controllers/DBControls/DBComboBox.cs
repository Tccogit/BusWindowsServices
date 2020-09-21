using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassLibrary.Controllers.DBControls
{
    public partial class DBComboBox : JComboBox
    {

        private void InitializeDefault()
        {
            if (DataSource != null && ValueMember!="" && DisplayMember!="")
            {
                DataTable table = (DataTable)DataSource;
                DataRow dr;
                dr = table.NewRow();
                dr[ValueMember] = "-1";
                dr[DisplayMember] = "-----------";
                table.Rows.InsertAt(dr, 0);
                SelectedValue = dr[ValueMember];
            }
        }
        public DBComboBox()
        {
            InitializeComponent();
        }

        public DBComboBox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        private void DBComboBox_ValueMemberChanged(object sender, EventArgs e)
        {
            InitializeDefault();
        }
    }
}
