using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary.Person.OtherPerson
{
    public partial class OtherFormList : Form
    {
        public string Select;
        static DataTable DT;
        public OtherFormList()
        {
            InitializeComponent();
            listBox1.DataSource = DT;
            listBox1.ValueMember = "Code";
            listBox1.DisplayMember = "Title";
        }

        public void Load( string pTExt)
        {
            if (DT != null)
                DT.Clear();
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from ClsOtherPerson where title like N'%" + pTExt + "%' order by Title");
                DT = DB.Query_DataTable();
            }
            catch
            {

            }
            finally
            {
                DB.Dispose();
            }
            listBox1.DataSource = DT;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JOtherPersonForm OPF = new JOtherPersonForm();
            OPF.ShowDialog();
            Load(textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Load(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Select = (listBox1.SelectedItem as DataRowView)["Title"].ToString();
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Load(textBox1.Text);
        }
    }
}
