using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Globals.Property;

namespace ClassLibrary
{
    public partial class JDefineForm : JBaseForm
    {
        public string _ClassName;
        public JDefineForm(string className)
        {
            InitializeComponent();
            _ClassName = "Form." + className;
            SetForm();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetForm()
        {
            jJanusGrid1.DataSource = (new ClassLibrary.JForms()).GetDataTable(_ClassName);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Creating New Form
            JDefineFormData jDefineFormData = new JDefineFormData(0, "", "","");
            jDefineFormData.ShowDialog();
            if (jDefineFormData.FormName == null || jDefineFormData.FormName == "") return;
            string FormName = jDefineFormData.FormName;
            string SQLQuery = jDefineFormData.Query;
            ClassLibrary.JForms jForms = new ClassLibrary.JForms();
            jForms.isMultiple = jDefineFormData.isMultiple;
            jForms.ClassName = _ClassName;
            jForms.FormName = FormName;
            jForms.SQL = SQLQuery;
            jForms.user_code = JMainFrame.CurrentUserCode;
            jForms.Action = jDefineFormData.Action;
            jForms.Date = DateTime.Now;
            int FormCode = jForms.Insert();
            if (FormCode <= 0)
            {
                JMessages.Error("ثبت فرم جدید با خطا مواجه شد.", "فرم ها");
                return;
            }
            else
            {
                // افزودن اعضای انتخاب شده به جدول FormUserPostCode
                JFormUserPostCode jFormUserPostCode = new JFormUserPostCode();
                for (int i = 0; i < jDefineFormData.clbPosts.Items.Count; i++)
                {
                    if (jDefineFormData.clbPosts.GetItemChecked(i) == true)
                    {
                        jFormUserPostCode.Insert(FormCode, Convert.ToInt32((jDefineFormData.clbPosts.Items[i] as JKeyValue).Value));
                    }
                }
            }
            // Creating Form Properties
            (new JDefinePropertyForm("ClassLibrary.FormManagers", FormCode)).ShowDialog();
            SetForm();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (jJanusGrid1.SelectedRow != null)
            {
                JForms jForms = new JForms(Convert.ToInt32(jJanusGrid1.SelectedRow.Row[0]));
                JDefineFormData jDefineFormData = new JDefineFormData(jForms.Code, jForms.FormName, jForms.SQL, jForms.Action);
                // افزودن اعضای انتخاب شده به جدول FormUserPostCode
                JFormUserPostCode jFormUserPostCode = new JFormUserPostCode();
                jDefineFormData.ShowDialog();
                if (jDefineFormData.FormName == null || jDefineFormData.FormName == "") return;
                jFormUserPostCode.DeleteByFormCode(jForms.Code);
                for (int i = 0; i < jDefineFormData.clbPosts.Items.Count; i++)
                {
                    if (jDefineFormData.clbPosts.GetItemChecked(i) == true)
                    {
                        jFormUserPostCode.Insert(jForms.Code, Convert.ToInt32((jDefineFormData.clbPosts.Items[i] as JKeyValue).Value));
                    }
                }
                jForms.FormName = jDefineFormData.FormName;
                jForms.SQL = jDefineFormData.Query;
                jForms.Action = jDefineFormData.Action;
                jForms.Update();
                (new JDefinePropertyForm("ClassLibrary.FormManagers", Convert.ToInt32(jJanusGrid1.SelectedRow.Row[0]))).ShowDialog();
                SetForm();
            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            JFormObjects jFormObjects = new JFormObjects();
            if (jFormObjects.GetDataTable(Convert.ToInt32(jJanusGrid1.SelectedRow.Row[0])).Rows.Count > 0)
            {
                JMessages.Error("از این فرم استفاده شده است. امکان حذف وجود ندارد.", "حذف");
                return;
            }
            if (JMessages.Warning("از حذف این فرم مطمئن هستید؟", "حذف") == DialogResult.OK)
            {
                ClassLibrary.JForms jForms = new ClassLibrary.JForms();
                jForms.Code = Convert.ToInt32(jJanusGrid1.SelectedRow.Row[0]);
                jForms.Delete();
                SetForm();
            }
        }

        private void jJanusGrid1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void JDefineForm_Load(object sender, EventArgs e)
        {

            jJanusGrid1.gridEX1.MouseDoubleClick += new MouseEventHandler(gridEX1_MouseDoubleClick);
        }

        void gridEX1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnEdit_Click(null, null);
        }
    }
}
