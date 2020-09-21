using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary
{
    public partial class JJanusGrid : UserControl
    {
        #region Peroperties
        /// <summary>
        /// جدول داده ی گرید
        /// </summary>
        public DataTable DataSource;
        /// <summary>
        /// ستون هایی که باید دیده نشوند
        /// </summary>
        string[] hidColumns;
        private JDataBase _Database;
        private string _pSet;
        private Janus.Windows.GridEX.FilterMode _FilterMode;
        private Janus.Windows.GridEX.FilterRowButtonStyle _FilterRowButtonStyle;
        public DataRowView[] SelectedRows = new DataRowView[0];
        public DataRowView SelectedRow;
        /// <summary>
        /// امکان انتخاب چند تایی سطرهای گرید
        /// </summary>
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
                if (_MultiSelect)
                    gridEX1.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelectionSameTable;
                else
                    gridEX1.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;

            }
        }
        #endregion Peroperties
        #region Constructor
        public JJanusGrid()
        {
            InitializeComponent();
        }
        #endregion Constructor

        #region Myfunctions
        public void bind(JDataBase pDatabase, string pSet, Janus.Windows.GridEX.FilterMode pFilterMode, Janus.Windows.GridEX.FilterRowButtonStyle pFilterRowButtonStyle)
        {
            _FilterMode = pFilterMode;
            _FilterRowButtonStyle = pFilterRowButtonStyle;
            _pSet = pSet;
            _Database = pDatabase;
            DataSource = pDatabase.Query_DataTable();
            gridEX1.DataSource = DataSource;
            gridEX1.FilterMode = _FilterMode;
            gridEX1.FilterRowButtonStyle = _FilterRowButtonStyle;
            gridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            gridEX1.UpdateOnLeave = false; 
            gridEX1.RetrieveStructure();
            gridEX1.SettingsKey = _pSet;
            gridEX1.LoadComponentSettings();

            DataSource = (DataTable)gridEX1.DataSource;
            SetColumnsHeaderCaption();
        }

        public void bind(DataTable pDataTable, string pSet, Janus.Windows.GridEX.FilterMode pFilterMode, Janus.Windows.GridEX.FilterRowButtonStyle pFilterRowButtonStyle)
        {
            try
            {
                _FilterMode = pFilterMode;
                _FilterRowButtonStyle = pFilterRowButtonStyle;
                _pSet = pSet;
                //_Database = pDatabase;
                DataSource = pDataTable;
                gridEX1.DataSource = pDataTable;
                gridEX1.FilterMode = _FilterMode;
                if (_MultiSelect)
                    gridEX1.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelectionSameTable;
                else
                    gridEX1.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;

                gridEX1.FilterRowButtonStyle = _FilterRowButtonStyle;
                gridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
                gridEX1.UpdateOnLeave = false;
                try
                {
                    gridEX1.RetrieveStructure();
                }
                catch { }
                gridEX1.SettingsKey = _pSet;                
                 try
                 { gridEX1.LoadComponentSettings(); 
                 }
                 catch { }
                DataSource = (DataTable)gridEX1.DataSource;
                SetColumnsHeaderCaption();

            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Refresh()
        {
            if (_MultiSelect)
                gridEX1.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelectionSameTable;
            else
                gridEX1.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            gridEX1.DataSource = DataSource;
            gridEX1.FilterMode = _FilterMode;
            gridEX1.FilterRowButtonStyle = _FilterRowButtonStyle;
            gridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            gridEX1.UpdateOnLeave = false;
            gridEX1.RetrieveStructure();
            gridEX1.SettingsKey = _pSet;
            gridEX1.LoadComponentSettings();
        }
        public void RemoveSelectedRows()
        {
            try
            {
                for (int i = 0; i < gridEX1.SelectedItems.Count; i++)
                {
                    for (int j = 0; j < DataSource.Rows.Count; j++)
                    {
                        if (DataSource.Rows[j]["code"].ToString() == ((DataRowView)((gridEX1.SelectedItems[i].GetRow().DataRow)))["code"].ToString())
                        {
                            DataSource.Rows.Remove(DataSource.Rows[j]);
                            break;
                        }
                    }
                    //gridEX1.SelectedItems.Remove(gridEX1.SelectedItems[i]);
                }
                DataSource = (DataTable)gridEX1.DataSource;
                gridEX1.Refresh();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        /// <summary>
        /// مخفی کردن ستون ها
        /// </summary>
        /// <param name="pColumns">نام ستون ها</param>
        public void HidColumns(string[] pColumns)
        {
            Array.Resize(ref hidColumns, pColumns.Length);
            hidColumns = pColumns;
            for (int i = 0; i < pColumns.Length; i++)
            {
                for (int j = 0; j < gridEX1.CurrentTable.Columns.Count; j++)
                {
                    if (gridEX1.CurrentTable.Columns[j].DataMember.ToLower() == pColumns[i].ToLower())
                    {
                        gridEX1.CurrentTable.Columns[j].Visible = false;
                        break;
                    }
                }

            }
        }
        /// <summary>
        /// ترجمه عنوان ستون ها
        /// </summary>
        private void SetColumnsHeaderCaption()
        {
            try
            {
                for (int j = 0; j < gridEX1.CurrentTable.Columns.Count; j++)
                {
                    gridEX1.CurrentTable.Columns[j].Caption = JLanguages._Text(gridEX1.CurrentTable.Columns[j].Key);
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
        #endregion Myfunctions

        public static class JSettingKeys
        {
            public static string Organizations = "Organizations";
            public static string Refer = "Refer";
            public static string CentralRefer = "CentralRefer";
            public static string Central = "Central";
            public static string Copy = "Copy";
            public static string Dictionary = "Dictionary";
            public static string FinanceSharesReport = "FinanceSharesReport";
            public static string LetterAttachments = "LetterAttachments";
            public static string PersonSheet = "PersonSheet";
            public static string PaymentHistory = "PaymentHistory";
            public static string Minute = "Minute";
            public static string RelatedLetter = "RelatedLetter";
            public static string ExternalRefer = "ExternalRefer";
        }




        #region Events

        private void gridEX1_RowDoubleClick_1(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            try
            {
                if (GridRowDoubleClick == null) return;
                SelectedRow = (DataRowView)e.Row.DataRow;                
                GridRowDoubleClick.BeginInvoke(sender, e, null, null);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        /// <summary>
        /// رویداد دوبار کلیک موس بر روی یک سطر
        /// </summary>
        public event EventHandler GridRowDoubleClick;
        ///// <summary>
        ///// رویداد تغییر سطرهای انتخابی
        ///// </summary>
        public event EventHandler SelectionChanged;
        private void gridEX1_SelectionChanged(object sender, EventArgs e)
        {
            if (_MultiSelect)
                gridEX1.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelectionSameTable;
            else
                gridEX1.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;

            if (SelectionChanged == null) return;

            Array.Resize(ref SelectedRows, gridEX1.SelectedItems.Count);
            for (int i = 0; i < gridEX1.SelectedItems.Count; i++)
            {
                SelectedRows[i] = ((DataRowView)gridEX1.SelectedItems[i].GetRow().DataRow);
            }
            if (gridEX1.SelectedItems.Count == 1)
            {
                SelectedRow = ((DataRowView)gridEX1.SelectedItems[0].GetRow().DataRow);
            }
            SelectionChanged.BeginInvoke(sender, e, null, null);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            gridEX1.FilterMode = _FilterMode;
            gridEX1.FilterRowButtonStyle = _FilterRowButtonStyle;
            gridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            gridEX1.UpdateOnLeave = false;
            gridEX1.DataSource = DataSource;
            gridEX1.RetrieveStructure();
            if (hidColumns != null)
                for (int i = 0; i < hidColumns.Length; i++)
                {
                    for (int j = 0; j < gridEX1.CurrentTable.Columns.Count; j++)
                    {
                        if (gridEX1.CurrentTable.Columns[j].DataMember.ToLower() == hidColumns[i].ToLower())
                        {
                            gridEX1.CurrentTable.Columns[j].Visible = false;
                            break;
                        }
                    }

                }
            SetColumnsHeaderCaption();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            gridEX1.SaveComponentSettings();
        }

        private void btnAdvanceSearch_Click(object sender, EventArgs e)
        {
            gridEX1.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            gridEX1.RetrieveStructure();
        }

        private void JJanusGrid_Enter(object sender, EventArgs e)
        {
            gridEX1.Focus();
        }
        #endregion Events








    }

    
}
