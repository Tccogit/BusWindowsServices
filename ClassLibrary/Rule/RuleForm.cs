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
    public partial class JRuleForm : JBaseForm
    {
        public string Limitation;
        private JRule _Rule;
        public JRuleForm()
        {
            InitializeComponent();
        }

        public void InitGrid(JRule pRule)
        {
            _Rule = pRule;
            FieldListdataGridView.ColumnCount = 2;
            FieldListdataGridView.Columns[0].Name = "FieldName";
            FieldListdataGridView.Columns[0].HeaderText = "FieldName";
            FieldListdataGridView.Columns[1].Name = "FieldCode";
            FieldListdataGridView.Columns[1].HeaderText = "FieldCode";

            int Count = 0;
            foreach (string Field in pRule.Fields)
            {
                string[] RowF = new string[] { Field, pRule.FieldsLabel[Count++] };
                FieldListdataGridView.Rows.Add(RowF);
            }

            FieldListdataGridView.ReadOnly = true;
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            var gStr = FormuletextBox.Text.ToLower();
            if (gStr.IndexOf("drop")>=0 || gStr.IndexOf("alter")>=0)
            {
                JMessages.Error("ERROR", "ERROR");
            }
            Limitation = _Rule.Decode(gStr);
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
