using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary.DataBase.CustomQuery
{
    public partial class JCustomQueriesForm : JBaseForm
    {
        public JCustomQueriesForm()
        {
            InitializeComponent();
            SetForm();
        }

        private DataTable QueriesList;
        private DataTable Posts;
        int SelectQueryCode;
        int SelectPostCode;
        int Code;
        private void SetForm()
        {
            JQueries Queries = new JQueries();
            QueriesList = Queries.getDatatable();

            tbList.ValueMember = "Code";
            tbList.DisplayMember = "QueryName";
            tbList.DataSource = QueriesList;

            Posts = Employment.JEOrganizationChart.GetUserPosts();
            cbPost.ValueMember = "Code";
            cbPost.DisplayMember = "Title";
            cbPost.DataSource = Posts;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            QueriesList.DefaultView.RowFilter = ("QueryText like '*" + tbSearch.Text + "*' OR QueryName like '*" + tbSearch.Text + "*'");
        }

        private void tbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectQueryCode = (int)tbList.SelectedValue;
            SetNewQuery();
        }

        private void cbPost_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectPostCode = (int)cbPost.SelectedValue;
            SetNewQuery();
        }

        private void SetNewQuery()
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("select * from queriesUser where PostCode=" + SelectPostCode + " and QueryCode=" + SelectQueryCode);
                db.Query_DataReader();
                if (db.DataReader.Read())
                {
                    tbNew.Text = db.DataReader["QueryText"].ToString();
                    Code = (int)db.DataReader["Code"];
                }
                tbNew.Text = "";
                Code = 0;
            }
            finally
            {
                db.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            JQueriesUser QU = new JQueriesUser();
            QU.PostCode = SelectPostCode;
            QU.QueryCode = SelectQueryCode;
            QU.QueryText = tbNew.Text;
            QU.Code = Code;
            if (tbNew.Text.Length == 0 && Code > 0)
                QU.Delete();
            else
                if (Code > 0)
                    QU.Update();
                else
                {
                    if (tbNew.Text.Trim().Length > 0)
                        QU.Insert();
                }
        }

        private void tbList_DoubleClick(object sender, EventArgs e)
        {
            tbNew.Text = (tbList.SelectedItem as DataRowView)["QueryText"].ToString();
        }
    }
}
