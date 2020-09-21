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
    public partial class JDefineFormData : JBaseForm
    {
        public int FormCode;
        public string FormName;
        public string Query;
        public bool isMultiple;
        public string Action;

        public JDefineFormData(int formCode, string formName, string query, string pAction)
        {
            InitializeComponent();
            txtQuery.Words.Add("@ObjectCode");
            txtFormName.Text = formName;
            txtQuery.Text = query;
            textBox1.Text = pAction;
            Action = pAction;
            FormCode = formCode;
            if (formCode > 0)
            {
                cbxMultiple.Enabled = false;
                cbxMultiple.Checked = (new JForms(formCode)).isMultiple;
            }
        }

        private void DefineFormData_Load(object sender, EventArgs e)
        {
            DataTable dt = Employment.JEOrganizationChart.GetUserPosts();
            foreach (DataRow dr in dt.Rows)
            {
                JKeyValue jKeyValue = new JKeyValue();
                jKeyValue.Key = dr[1].ToString();
                jKeyValue.Value = Convert.ToInt32(dr[0]);
                clbPosts.Items.Add(jKeyValue);
            }
            if (FormCode > 0)
            {
                dt = (new JFormUserPostCode()).GetData(FormCode);
                foreach (DataRow cDataRow in dt.Rows)
                {
                    for (int i = 0; i < clbPosts.Items.Count; i++)
                    {
                        if (Convert.ToInt32((clbPosts.Items[i] as JKeyValue).Value) == Convert.ToInt32(cDataRow[0]))
                        {
                            clbPosts.SetItemCheckState(i, CheckState.Checked);
                            break;
                        }
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtQuery.Text != "")
            {
                if (txtQuery.Text.IndexOf("@ObjectCode") < 0)
                {
                    JMessages.Error("پارامتر @ObjectCode در کوئری استفاده نشده است.", "@ObjectCode");
                    return;
                }
            }
            isMultiple = cbxMultiple.Checked;
            FormName = txtFormName.Text;
            Query = txtQuery.Text;
            Action = textBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
