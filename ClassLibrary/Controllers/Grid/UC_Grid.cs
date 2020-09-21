using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary
{
    public partial class UC_Grid : UserControl
    {
        private string _pSet;
        public DataGridViewSelectedRowCollection SelectedRows;
        public DataGridViewRow SelectedRow;
        public DataTable DataSource;

        private bool _MultiSelect = false;
        public bool MultiSelect
        {
            get
            {
                return _MultiSelect;
            }
            set
            {
                _MultiSelect = value;
                jasGrid.MultiSelect = _MultiSelect;
            }
        }

        public UC_Grid()
        {
            if (DesignMode) return;
            InitializeComponent();
        }

        private void UC_Grid_Load(object sender, EventArgs e)
        {
            
        }
        public void Bind(JDataBase  pDatabase, string pSet)
        {
            if (DesignMode) return;
            _pSet = pSet;
            jasGrid.bind(pDatabase);
            DataSource = (DataTable)jasGrid.DataSource;

        }
        public void Bind(DataTable pDatabase, string pSet)
        {
            if (DesignMode) return;
            _pSet = pSet;
            jasGrid.DataSource = pDatabase;
            DataSource = pDatabase;

        }
        public void bind(JDataBase pDataBase, string pSet)
        {
            if (DesignMode) return;
            _pSet = pSet;
            jasGrid.bind(pDataBase);
            DataSource = pDataBase.datatable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void janusGrid1_GridRowDoubleClick(object sender, System.EventArgs e)
        {
            if (DesignMode) return;
            if (GridRowDoubleClick == null) return;
            if (jasGrid.SelectedRows.Count > 0)
                SelectedRow = jasGrid.SelectedRows[0];
            GridRowDoubleClick.BeginInvoke(sender, e, null, null);            
        }
        /// <summary>
        /// رویداد دوبار کلیک موس بر روی یک سطر
        /// </summary>
        public event System.EventHandler GridRowDoubleClick;
        ///// <summary>
        ///// رویداد تغییر سطر انتخابی
        ///// </summary>
        public event System.EventHandler SelectionChanged;
        /// <summary>
        /// 
        /// </summary>
        public void Refresh()
        {
            if (DesignMode) return;
            jasGrid.Refresh();
        }

        private void jasGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (DesignMode) return;
            SelectedRows = jasGrid.SelectedRows;
            if (jasGrid.SelectedRows.Count > 0)
                SelectedRow = jasGrid.SelectedRows[0];
            if (SelectionChanged == null) return;

            SelectionChanged.BeginInvoke(sender, e, null, null);
        }

        /// <summary>
        /// حذف سطر های انتخاب شده - فقط نمایشی
        /// </summary>
        public void RemoveSelectedRows()
        {
            if (DesignMode) return;
            if (jasGrid.CurrentRow != null)
                jasGrid.Rows.Remove(jasGrid.CurrentRow);
            //jasGrid.ClearSelection();
        }
        
        /// <summary>
        /// مخفی کردن ستون ها
        /// </summary>
        /// <param name="pColumns">نام ستون ها با جدا کننده سمی کالن</param>
        public void HidColumns(string pColumns)
        {
            if (DesignMode) return;
            string[] strColumns;
            strColumns =  pColumns.Split(';');
            foreach (string S in strColumns)
                jasGrid.Columns[S].Visible = false;
        }

        private void jasGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void jasGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void jasGrid_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
