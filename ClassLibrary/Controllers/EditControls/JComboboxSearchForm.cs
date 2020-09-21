using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;

namespace ClassLibrary.Controllers.EditControls
{
    public partial class JComboboxSearchForm : JBaseForm
    {
        JComboBox _jComboBox;
        JUIComboBox _jUIComboBox;
        DataTable _DataTable;
        BindingSource _BindingSource = new BindingSource();
        string _DisplayMember, _ValueMember;
        public JComboboxSearchForm(JComboBox jComboBox)
        {
            InitializeComponent();
            _jComboBox = jComboBox;
            _jUIComboBox = null;
            _DisplayMember = jComboBox.DisplayMember;
            _ValueMember = jComboBox.ValueMember;
        }
        public JComboboxSearchForm(JUIComboBox jUIComboBox)
        {
            InitializeComponent();
            _jUIComboBox = jUIComboBox;
            _jComboBox = null;
            _DisplayMember = jUIComboBox.DisplayMember;
            _ValueMember = jUIComboBox.ValueMember;
        }

        private void JComboboxSearchForm_Load(object sender, EventArgs e)
        {
            if (_jComboBox != null)
                _BindingSource.DataSource = _jComboBox.DataSource;
            else
                _BindingSource.DataSource = _jUIComboBox.DataSource;

            dgrList.DataSource = _BindingSource.DataSource as DataTable;
            
            for (int i = 0; i < dgrList.Columns.Count; i++)
            {
                dgrList.Columns[i].Visible = false;
            }
            dgrList.Columns[_DisplayMember].Width = Width - 100;
            dgrList.Columns[_DisplayMember].Visible = true;
            txtSearch.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _BindingSource.Filter = "";
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dgrList.SelectedRow == null) return;
            object value = dgrList.SelectedRow[_ValueMember];
            _BindingSource.Filter = "";
            if (_jComboBox != null)
                _jComboBox.SelectedValue = value;
            else
                _jUIComboBox.SelectedValue = value;

            this.Close();
        }

        private void dgrList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnOK_Click(null, null);
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dgrList.Focus();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _BindingSource.Filter = string.Format("{0} LIKE '%{1}%'", _DisplayMember, txtSearch.Text.Replace("'", "''").Replace("%", " "));
        }

        private void dgrList_DoubleClick(object sender, EventArgs e)
        {
            btnOK_Click(null, null);
        }

        private void dgrList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOK_Click(null, null);
        }

    }
}
