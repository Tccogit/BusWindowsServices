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
    public partial class JLanguageForm : JBaseForm
    {
        public JLanguageForm()
        {
            InitializeComponent();
        }

        private void JLanguageForm_Load(object sender, EventArgs e)
        {
            JLanguages.Load();
            dataGridView1.DataSource = JLanguages.DT;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            JLanguages.Save();
            dataGridView1.DataSource = JLanguages.DT;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            JLanguages.Save();
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource != null)
            {
                DataTable DT = (DataTable)dataGridView1.DataSource;
                DT.DefaultView.RowFilter = string.Format("name like '*{0}*' OR text like '*{1}*'", textBox1.Text,textBox1.Text);
            }
        }
    }
}
