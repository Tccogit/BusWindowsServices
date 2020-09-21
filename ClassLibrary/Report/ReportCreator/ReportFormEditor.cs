using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary.Report.ReportCreator
{
    public partial class ReportFormEditor : JBaseForm
    {

        private JSubReport _SR;
        public ReportFormEditor(JSubReport pSR)
        {
            InitializeComponent();

            _SR = pSR;
            txtFields.Text = pSR.Fields;
            txtGroupBy.Text = pSR.GroupBy;
            txtHide.Text = pSR.Hide;
            txtTables.Text = pSR.Tables;
            txtTabName.Text = pSR.TabTitle;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _SR.Fields = txtFields.Text;
            _SR.GroupBy = txtGroupBy.Text;
            _SR.Hide = txtHide.Text;
            _SR.Tables = txtTables.Text;
            _SR.TabTitle = txtTabName.Text;

            _SR.Update();

            Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            JReport R = new JReport();
             

            txtReport.Text =  R.getSQL(txtFields.Text, txtTables.Text, txtGroupBy.Text);
        }
    }
}
