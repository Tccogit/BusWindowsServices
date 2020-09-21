using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Globals.Property;

namespace ClassLibrary.FormManager
{
    public partial class JFormsListForm : JBaseForm
    {
        public string _ClassName;
        public int _ObjectCode;
        public DataTable _DataTable;

        public JFormsListForm(string className, int objectCode, DataTable dataTable)
        {
            InitializeComponent();

            _ClassName = "Form." + className;
            _ObjectCode = objectCode;
            _DataTable = dataTable;

            SetForm();
            cmbForms_SelectedIndexChanged(null, null);
        }

        public void SetForm()
        {
            cmbForms.DataSource = (new ClassLibrary.FormManager.JForms()).GetDataTable(_ClassName);
            cmbForms.DisplayMember = "FormName";
            cmbForms.ValueMember = "Code";

            dgrDataTable.DataSource = _DataTable;
        }

        private void cmbForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                JProperties jProperties = new JProperties("FormManager", Convert.ToInt32(cmbForms.SelectedValue));
                dgrItems.DataSource = jProperties.GetDataTable();
            }
            catch { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            (new ClassLibrary.FormManager.JFormObjectsForm(_ObjectCode ,Convert.ToInt32(cmbForms.SelectedValue), _ClassName)).ShowDialog();
        }

        private void JFormsListForm_Load(object sender, EventArgs e)
        {

        }
    }
}
