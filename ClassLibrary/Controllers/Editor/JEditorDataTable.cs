using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary.Controllers.Editor
{
    public partial class JEditorDataTable : UserControl
    {

        public JEditorDataTable()
        {
            InitializeComponent();
        }

        public void AddTable(DataTable pDt)
        {
            if (pDt == null) return;
            for (int i = 0; i < pDt.Columns.Count; i++)
            {
                {
                    cmbFields.Items.Add(JLanguages._Text(pDt.Columns[i].ColumnName));
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            jEditor1.InsertText('<' + cmbFields.Text + '>');
        }

        public string GetRTF()
        {
            return jEditor1.Text;
        }

        public string SetRTF(string pRTF)
        {
            return jEditor1.Text = pRTF;
        }

        public void Replace(DataTable pDt)
        {
            foreach (DataColumn DC in pDt.Columns)
            {
                jEditor1.Replace("<" + ClassLibrary.JLanguages._Text(DC.ColumnName) + ">", pDt.Rows[0][DC.ColumnName].ToString());
            }
        }


    }
}
