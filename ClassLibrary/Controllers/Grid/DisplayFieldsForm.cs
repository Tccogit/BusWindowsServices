using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;

namespace ClassLibrary
{
    public partial class JDisplayFieldsForm : JBaseForm
    {
        private DataGridView _gridView;
        public JDisplayFieldsForm(DataGridView dataGrid)
        {
            InitializeComponent();
            try
            {
                _gridView = dataGrid;
                chklstFields.Items.Clear();
                for (int i = 0; i < dataGrid.ColumnCount; i++)
                {
                    chklstFields.Items.Add(dataGrid.Columns[i].HeaderText, dataGrid.Columns[i].Visible);
                }
            }
            catch
            { }
        }
        private bool IsJanus;
        private GridEX _janusGrid;
        public JDisplayFieldsForm(GridEX dataGrid)
        {
            InitializeComponent();
            IsJanus = true;
            try
            {
                _janusGrid = dataGrid;
                chklstFields.Items.Clear();
                for (int i = 0; i < dataGrid.CurrentTable.Columns.Count; i++)
                {
                    chklstFields.Items.Add(dataGrid.CurrentTable.Columns[i].Caption, dataGrid.CurrentTable.Columns[i].Visible);
                }
            }
            catch
            { }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (!IsJanus)
                foreach (DataGridViewColumn column in _gridView.Columns)
                {
                    column.Visible = chklstFields.GetItemChecked(i++);
                }
            else
                foreach (GridEXColumn column in _janusGrid.CurrentTable.Columns)
                {
                    column.Visible = chklstFields.GetItemChecked(i++);
                }
            DialogResult = DialogResult.OK;
        }
    }
}
