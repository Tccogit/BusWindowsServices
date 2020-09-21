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
    public partial class JPermissionNewClassForm : Globals.JBaseForm
    {
        public JPermissionDefineClass _DefineClass;

        public JPermissionNewClassForm(JPermissionDefineClass pDefineClass)
        {
            InitializeComponent();
            _DefineClass = pDefineClass;
            txtClassName.Text = _DefineClass.ClassName;
            txtSQL.Text = _DefineClass.SQL;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _DefineClass.ClassName = txtClassName.Text;
            _DefineClass.SQL = txtSQL.Text;
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
