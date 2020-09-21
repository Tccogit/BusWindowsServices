using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace ClassLibrary
{
    public partial class JActionsManagerForm : JBaseForm
    {
        public JActionsManagerForm()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbTypeArgs.SelectedIndex == -1)
                return;
            lstArgs.Items.Add(cmbTypeArgs.Text + ":" + txtDefaultArgs.Text);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string Arguments="";
            foreach (object arg in lstArgs.Items)
            {
                Arguments = Arguments + arg.ToString()+"\n";
            }
            JAction.Insert(txtName.Text, txtFunctionName.Text,Arguments , "");
            FillGrid();
        }

        private void btnDelArgs_Click(object sender, EventArgs e)
        {
            if (lstArgs.Items.Count == 0 || lstArgs.SelectedIndex==-1)
                return;
            lstArgs.Items.RemoveAt(lstArgs.SelectedIndex);
            lstArgs.Focus();
        }
        private void FillGrid()
        {
            dataGridView1.DataSource = JAction.LoadData();
        }

        private void btnAddConst_Click(object sender, EventArgs e)
        {
            if (cmbConstType.SelectedIndex == -1)
                return;
            lstConstArgs.Items.Add(cmbConstType.Text + ":" + txtConstDefault.Text);
        }

        private void btnDelConst_Click(object sender, EventArgs e)
        {
            if (lstConstArgs.Items.Count == 0 || lstConstArgs.SelectedIndex == -1)
                return;
            lstConstArgs.Items.RemoveAt(lstConstArgs.SelectedIndex);
            lstConstArgs.Focus();
        }
    }
}
