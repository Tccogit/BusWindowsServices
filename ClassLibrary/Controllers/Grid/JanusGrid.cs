using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using Microsoft.Win32;

namespace ClassLibrary
{

    public partial class JJanusGrid : UserControl
    {
        #region Peroperties
        /// <summary>
        /// جدول داده ی گرید
        /// </summary>
        private DataTable _DataSource;

		public GridEX gridEX1
		{
			get
			{
				return _gridEX1;
			}
			set
			{
				_gridEX1 = value;
				bind(value);
			}
		}
        public DataTable DataSource
        {
            set
            {
                _DataSource = value;
                if (_DataSource != null)
                    _DataSource.RowChanged += _DataSource_RowChanged;
                bind((DataTable)value);
                DataGridView p = new DataGridView();
            }
            get
            {
                return _DataSource;
            }
        }

        void _DataSource_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            bind(sender as DataTable);
        }

        private bool ClassNameSet = false;
        private string _ClassName = "";
        public string ActionClassName
        {
            get
            {
                return _ClassName;
            }
            set
            {
				try
				{
					_ClassName = value;
					ClassNameSet = true;
					LoadCustomize();
				}
				catch
				{
				}

            }
        }

        /// <summary>
        /// اکشنها
        /// </summary>
        private List<JAction> Actions { get; set; }
        public JPopupMenu ActionMenu { get; set; }

        public int RowCount
        {
            get
            {
                try
                {
                    return (_DataSource as DataTable).Rows.Count;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public GridEXColumnCollection Columns
        {
            get
            {
                return _gridEX1.CurrentTable.Columns;
            }
        }
        public string Text
        {
            get
            {
                return groupBox1.Text;
            }
            set
            {
                groupBox1.Text = value;
            }
        }

        /// <summary>
        /// ستون هایی که باید دیده نشوند
        /// </summary>
        string[] hidColumns;
        public bool hasRealClassName = true;
        private JDataBase _Database;
        private Janus.Windows.GridEX.FilterMode _FilterMode;
        private Janus.Windows.GridEX.FilterRowButtonStyle _FilterRowButtonStyle;
        public DataRowView[] SelectedRows = new DataRowView[0];
        public DataTable SelectedDataTable
        {
            get
            {
                DataTable _Selected = new DataTable();
                Janus.Windows.GridEX.GridEXSelectedItemCollection Grows = _gridEX1.SelectedItems;
                _Selected = ((DataTable)_gridEX1.DataSource).Clone();
                foreach (Janus.Windows.GridEX.GridEXSelectedItem _grow in Grows)
                {
                    System.Data.DataRow _DR = _Selected.NewRow();
                    JTable.CopyRow(((System.Data.DataRowView)(_gridEX1.GetRow(_grow.Position)).DataRow).Row, _DR);
                    _Selected.Rows.Add(_DR);
                }
                return _Selected;
            }
        }
        public DataRowView SelectedRow
        {
            get
            {
                if (_gridEX1.CurrentRow != null)
                    return (_gridEX1.CurrentRow.DataRow as DataRowView);
                else
                    return null;
            }
        }
        public delegate void RowSelectionClick(object Sender, EventArgs e);
        public event RowSelectionClick OnRowSelectionClick;

        public delegate void RowDBClick(object Sender, RowActionEventArgs e);
        public event RowDBClick OnRowDBClick;
        /// <summary>
        /// امکان انتخاب چند تایی سطرهای گرید
        /// </summary>
        private bool _MultiSelect = true;
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
                    _gridEX1.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelectionSameTable;
                else
                    _gridEX1.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;

            }
        }

        private bool _Edited = false;
        public bool Edited
        {
            get
            {
                return _Edited;
            }
            set
            {
                _Edited = value;
                if (_Edited)
                    _gridEX1.AllowEdit = InheritableBoolean.True;
                else
                    _gridEX1.AllowEdit = InheritableBoolean.False;
            }
        }
        private bool _ShowToolbar = true;
        public bool ShowToolbar
        {
            get
            {
                //return panel1.Visible;
                return _ShowToolbar;
            }
            set
            {
                //panel1.Visible = value;
                _ShowToolbar = value;
                if (_ShowToolbar)
                    panel1.Visible = true;
                else
                    panel1.Visible = false;
            }
        }
        public bool ShowNavigator
        {
            get
            {
                return _gridEX1.RecordNavigator;
            }
            set
            {
                _gridEX1.RecordNavigator = value;
            }
        }

        #endregion Peroperties

        #region RowColor
        public JRowStyles RowColor;
        #endregion RowColor

        #region Constructor

        public JJanusGrid()
        {
            InitializeComponent();

			
            // فقط مدیر امکان ایجاد فرم جدید دارد
            if (JMainFrame.CurrentPostCode != 1)
                btnProperties.Visible = false;

        }
        #endregion Constructor

        #region Myfunctions

		private void bind(GridEX pGridEX)
		{
			try
			{
				_DataSource = (DataTable)pGridEX.DataSource;
			}
			catch
			{
			}
		}
        public void bind(JDataBase pDatabase, string pClassName, Janus.Windows.GridEX.FilterMode pFilterMode, Janus.Windows.GridEX.FilterRowButtonStyle pFilterRowButtonStyle)
        {
            _FilterMode = Janus.Windows.GridEX.FilterMode.Automatic; //pFilterMode;
            _FilterRowButtonStyle = pFilterRowButtonStyle;
            _Database = pDatabase;
            _DataSource = pDatabase.Query_DataTable();

            if (pClassName == "")
            {
                _ClassName = JDataBase.GetStringFiledsName(DefaultView);
                hasRealClassName = false;
            }
            else
            {
                _ClassName = pClassName;
                ClassNameSet = true;
            }
            _gridEX1.DataSource = _DataSource;
            _gridEX1.FilterMode = _FilterMode;
            _gridEX1.FilterRowButtonStyle = FilterRowButtonStyle.ConditionOperatorDropDown; //_FilterRowButtonStyle;
            _gridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            _gridEX1.UpdateOnLeave = false;

            _gridEX1.RecordNavigator = true;
            _gridEX1.BuiltInTexts[GridEXBuiltInText.RecordNavigator] = "شماره سطر:";

            _DataSource = (DataTable)_gridEX1.DataSource;
            LoadCustomize();
        }

        public void bind(DataTable pDataTable)
        {
            bind(pDataTable, _ClassName, FilterMode.Automatic, FilterRowButtonStyle.ConditionOperatorDropDown);
        }

        public void bind(DataTable pDataTable, string pClassName)
        {
            bind(pDataTable, _ClassName, FilterMode.Automatic, FilterRowButtonStyle.ConditionOperatorDropDown);
        }

        public void bind(DataTable pDataTable, string pClassName, Janus.Windows.GridEX.FilterMode pFilterMode, Janus.Windows.GridEX.FilterRowButtonStyle pFilterRowButtonStyle)
        {
            try
            {
                if (pClassName == "")
                {
                    _ClassName = JDataBase.GetStringFiledsName(DefaultView);
                    hasRealClassName = false;
                }
                else
                {
                    _ClassName = pClassName;
                    ClassNameSet = true;
                }
                _FilterMode = _FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;  //pFilterMode;
                _FilterRowButtonStyle = FilterRowButtonStyle.ConditionOperatorDropDown;// pFilterRowButtonStyle;
                _DataSource = pDataTable;
                _gridEX1.DataSource = pDataTable;
                _gridEX1.FilterMode = _FilterMode;
                if (_MultiSelect)
                    _gridEX1.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelectionSameTable;
                else
                    _gridEX1.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;

                _gridEX1.FilterRowButtonStyle = _FilterRowButtonStyle;
                _gridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
                _gridEX1.UpdateOnLeave = false;
                _gridEX1.RecordNavigator = true;
                _gridEX1.RecordNavigatorText = "شماره سطر:";
                _DataSource = (DataTable)_gridEX1.DataSource;
                LoadCustomize();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        public void AddAction(JAction pAction)
        {
            if (ActionMenu == null)
                ActionMenu = new JPopupMenu();
            ActionMenu.Insert(pAction);
            this.ContextMenuStrip = ActionMenu.GetPopup(JSystem.Nodes);
            this.ContextMenuStrip.ItemClicked += ContextMenuStrip_ItemClicked;
        }

        private void ContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Refresh();
        }

        public void ClearActions()
        {
            if (ActionMenu != null)
                ActionMenu.ClearItems();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Refresh()
        {
            if (_ClassName == "")
            {
                _ClassName = JDataBase.GetStringFiledsName(DefaultView);
                hasRealClassName = false;
            }

            if (_MultiSelect)
                _gridEX1.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelectionSameTable;
            else
                _gridEX1.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            _gridEX1.DataSource = _DataSource;
            _gridEX1.FilterMode = _FilterMode;
            _gridEX1.FilterRowButtonStyle = _FilterRowButtonStyle;
            _gridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            _gridEX1.UpdateOnLeave = false;
            LoadCustomize();
        }
        public void RemoveSelectedRows()
        {
            try
            {
                for (int i = 0; i < _gridEX1.SelectedItems.Count; i++)
                {
                    for (int j = 0; j < _DataSource.Rows.Count; j++)
                    {
                        if (_DataSource.Rows[j]["code"].ToString() == ((DataRowView)((_gridEX1.SelectedItems[i].GetRow().DataRow)))["code"].ToString())
                        {
                            _DataSource.Rows.Remove(_DataSource.Rows[j]);
                            break;
                        }
                    }
                }
                _DataSource = (DataTable)_gridEX1.DataSource;
                _gridEX1.Refresh();
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
            try
            {
                if (_gridEX1.CurrentTable == null) return;
                for (int i = 0; i < _gridEX1.CurrentTable.Columns.Count; i++)
                {
                    _gridEX1.CurrentTable.Columns[i].Visible = true;
                }
                if (pColumns == null || pColumns.Length == 0) return;
                Array.Resize(ref hidColumns, pColumns.Length);
                hidColumns = pColumns;
                for (int i = 0; i < pColumns.Length; i++)
                {
                    string[] D = pColumns[i].Split(new string[] { ":" }, StringSplitOptions.None);

                    string item = D.Length >= 1 ? D[0] : "";
                    bool hidden = D.Length >= 2 ? D[1] == "hidden" : false;
                    int size = D.Length >= 3 && int.TryParse(D[2], out size) ? int.Parse(D[2]) : -1;
                    int ordered = D.Length >= 4 ? int.Parse(D[3]) : -1;

                    for (int j = 0; j < _gridEX1.CurrentTable.Columns.Count; j++)
                    {
                        if (_gridEX1.CurrentTable.Columns[j].DataMember.ToLower() == item.ToLower())
                        {
                            if (hidden)
                                _gridEX1.CurrentTable.Columns[j].Visible = false;
                            if (size >= 0)
                                _gridEX1.CurrentTable.Columns[j].Width = size;
                            if (ordered >= 0)
                                _gridEX1.CurrentTable.Columns[j].Position = ordered;


                            break;
                        }
                    }
                }
            }
            catch { }
            finally { }
        }
        /// <summary>
        /// ترجمه عنوان ستون ها
        /// </summary>
        public void SetColumnsHeaderCaption()
        {
            try
            {
                for (int j = 0; j < _gridEX1.CurrentTable.Columns.Count; j++)
                {
                    _gridEX1.CurrentTable.Columns[j].Caption = JLanguages._Text(_gridEX1.CurrentTable.Columns[j].Key);
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

        private void _gridEX1_RowDoubleClick_1(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            //try
            //{
            //    if (GridRowDoubleClick == null) return;
            //    SelectedRow = (DataRowView)e.Row.DataRow;                
            //    GridRowDoubleClick.BeginInvoke(sender, e, null, null);
            //}
            //catch (Exception ex)
            //{
            //    JSystem.Except.AddException(ex);
            //}
        }

        /// <summary>
        /// رویداد دوبار کلیک موس بر روی یک سطر
        /// </summary>
        public event EventHandler GridRowDoubleClick;
        ///// <summary>
        ///// رویداد تغییر سطرهای انتخابی
        ///// </summary>
        public event EventHandler SelectionChanged;
        private void _gridEX1_SelectionChanged(object sender, EventArgs e)
        {
            //if (_MultiSelect)
            //    _gridEX1.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelectionSameTable;
            //else
            //    _gridEX1.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;

            //if (SelectionChanged == null) return;

            //Array.Resize(ref SelectedRows, _gridEX1.SelectedItems.Count);
            //for (int i = 0; i < _gridEX1.SelectedItems.Count; i++)
            //{
            //    SelectedRows[i] = ((DataRowView)_gridEX1.SelectedItems[i].GetRow().DataRow);
            //}
            //if (_gridEX1.SelectedItems.Count == 1)
            //{
            //    SelectedRow = ((DataRowView)_gridEX1.SelectedItems[0].GetRow().DataRow);
            //}
            //SelectionChanged.BeginInvoke(sender, e, null, null);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _gridEX1.FilterMode = _FilterMode;
            _gridEX1.FilterRowButtonStyle = _FilterRowButtonStyle;
            _gridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            _gridEX1.UpdateOnLeave = false;
            _gridEX1.DataSource = _DataSource;
            if (hidColumns != null)
                for (int i = 0; i < hidColumns.Length; i++)
                {
                    for (int j = 0; j < _gridEX1.CurrentTable.Columns.Count; j++)
                    {
                        if (_gridEX1.CurrentTable.Columns[j].DataMember.ToLower() == hidColumns[i].ToLower())
                        {
                            _gridEX1.CurrentTable.Columns[j].Visible = false;
                            break;
                        }
                    }

                }
            if (_ClassName == "")
            {
                _ClassName = JDataBase.GetStringFiledsName(DefaultView);
                hasRealClassName = false;
            }
            LoadCustomize();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _gridEX1.SaveSettings = true;
            try
            {
                _gridEX1.SaveComponentSettings();
            }
            catch { }
            finally { }
        }

        private void btnAdvanceSearch_Click(object sender, EventArgs e)
        {
            JDataTable DT = (_gridEX1.DataSource as JDataTable);
            if (DT != null && DT.Paging != null && DT.Paging.Condition.Length > 0)
            {
                return;
            }
            LoadCustomize(true);
        }

        private void JJanusGrid_Enter(object sender, EventArgs e)
        {
            _gridEX1.Focus();
        }
        #endregion Events

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (_ClassName == "")
            {
                _ClassName = JDataBase.GetStringFiledsName(DefaultView);
                hasRealClassName = false;
            }

            int OldKey = JGeneral.StrintToNumber(JDataBase.GetStringFiledsName(DefaultView));
            Int64 NewKey = JGeneral.GetInt64HashCode(ActionClassName);
            ClassLibrary.JDynamicReportForm DRF = new JDynamicReportForm(OldKey, NewKey);
            DRF.Add(DefaultView);
            DRF.ShowDialog();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
			System.Windows.Forms.SaveFileDialog saveDialog = new System.Windows.Forms.SaveFileDialog();
            saveDialog.Filter = "Microsoft Excel | *.xls";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileStream st = new System.IO.FileStream(saveDialog.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None);
                gridEXExporter1.Export(st);
                st.Close();
            }
        }

        private void _gridEX1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void _gridEX1_RowDoubleClick(object sender, RowActionEventArgs e)
        {
            if (OnRowDBClick != null)
                OnRowDBClick(sender, e);
        }

        private void _gridEX1_DragDrop(object sender, DragEventArgs e)
        {
        }

        private void _gridEX1_DragLeave(object sender, EventArgs e)
        {

        }

        public void SaveSettings(string pKey)
        {
            try
            {
                //_gridEX1.SaveComponentSettings();
            }
            catch { }
            finally { }
        }

        private void _gridEX1_SelectionChanged_1(object sender, EventArgs e)
        {
            if (OnRowSelectionClick != null)
                OnRowSelectionClick(sender, e);
        }


        private System.Data.DataTable _DefaultView;
        public System.Data.DataTable DefaultView
        {
            get
            {
                if (_gridEX1.DataSource != null)
                {
                    Janus.Windows.GridEX.GridEXRow[] Grows = _gridEX1.GetDataRows();

                    if (_DefaultView != null)
                        _DefaultView.Clear();
                    _DefaultView = (_gridEX1.DataSource as DataTable).Clone();
                    foreach (Janus.Windows.GridEX.GridEXRow _grow in Grows)
                    {
                        try
                        {
                            System.Data.DataRow _DR = _DefaultView.NewRow();
                            JTable.CopyRow(((System.Data.DataRowView)_grow.DataRow).Row, _DR);
                            _DefaultView.Rows.Add(_DR);
                        }
                        catch
                        {
                        }
                        finally
                        {
                        }
                    }

                    return _DefaultView;
                }
                return null;
            }
        }


        private System.Data.DataTable _Selected;
        public System.Data.DataTable Selected
        {
            get
            {
                try
                {
                    Janus.Windows.GridEX.GridEXSelectedItemCollection Grows = _gridEX1.SelectedItems;

                    if (_Selected != null)
                        _Selected.Clear();
                    _Selected = (_gridEX1.DataSource as DataTable).Clone();
                    foreach (Janus.Windows.GridEX.GridEXSelectedItem _grow in Grows)
                    {
                        try
                        {
                            System.Data.DataRow _DR = _Selected.NewRow();
                            JTable.CopyRow(((System.Data.DataRowView)(_gridEX1.GetRow(_grow.Position)).DataRow).Row, _DR);
                            _Selected.Rows.Add(_DR);
                        }
                        catch(Exception ex)
                        {
                            JSystem.Except.AddException(ex);
                        }
                    }
                    return _Selected;
                }
                catch
                {
                    return null;
                }
            }
        }

        private void btnDPrint_Click(object sender, EventArgs e)
        {
        }

        private void btnSelectPrint_Click(object sender, EventArgs e)
        {
            if (_ClassName == "")
            {
                _ClassName = JDataBase.GetStringFiledsName(DefaultView);
                hasRealClassName = false;
            }

            Int64 OldKey = JGeneral.StrintToNumber(JDataBase.GetStringFiledsName(DefaultView));
            Int64 NewKey = JGeneral.GetInt64HashCode(ActionClassName);

            ClassLibrary.JDynamicReports Rep = new JDynamicReports(OldKey, NewKey);
            Rep.Add(Selected);

            Rep.PrintDefault();
        }

        private void btnWordDesign_Click(object sender, EventArgs e)
        {
        }

        private void btnWordPrint_Click(object sender, EventArgs e)
        {
        }

        private void btnWordSelectPrint_Click(object sender, EventArgs e)
        {
        }

        private void _gridEX1_ColumnHeaderClick(object sender, ColumnActionEventArgs e)
        {
            if (e.Column.Key == "row_number")
                return;

            JDataTable DT = (_gridEX1.DataSource as JDataTable);
            if (DT!=null && DT.Paging != null)
            {
                DT.Paging.Start = 1;
                DT.Paging.Ordered = e.Column.Key;
                this._gridEX1.DataSource = DT.Paging.RefreshPage();
                DT.Clear();
                DT.Reset();
                DT = null;
            }

            try
            {
                UpdateElapsedTime(e.Column);
            }
            catch
            {
            }

        }

        private void UpdateElapsedTime(GridEXColumn pColumn)
        {

            pColumn.AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum;
            lbComment.Text = "مجموع = "+_gridEX1.GetTotal(pColumn, Janus.Windows.GridEX.AggregateFunction.Sum).ToString();
        }
        
        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            JDataTable DT = (_gridEX1.DataSource as JDataTable);
            if (DT == null) return;
            if (DT.Paging == null) return;
            if (DT.Paging.Start == 1) return;
            DT.Paging.PreviousPage();
            this._gridEX1.DataSource = DT.Paging.RefreshPage();
            DT.Clear();
            DT.Reset();
            DT = null;
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            JDataTable DT = (_gridEX1.DataSource as JDataTable);
            if (DT == null) return;
            if (DT == null || DT.Paging == null) return;
            DT.Paging.NextPage();
            this._gridEX1.DataSource = DT.Paging.RefreshPage();
            DT.Clear();
            DT.Reset();
            DT = null;
        }

        private void _gridEX1_FilterApplied(object sender, EventArgs e)
        {
            try
            {
                if (_gridEX1.GetRows().Count() > 300)
                {
                    cmbCount.Visible = true;
                    BtnNext.Visible = true;
                    BtnPrevious.Visible = true;
                }
            }
            catch
            {
            }
            finally
            {
            }
            try
            {
                string _SQL = "";
                string[] CondiationSQL;
                int count = 0;

                IFilterCondition Condition = _gridEX1.FilterRow.Table.FilterCondition;
                if (Condition != null && Condition.FilterCondition != null)
                {
                    CondiationSQL = new String[Condition.FilterCondition.Conditions.Count];
                    foreach (GridEXFilterCondition FC in Condition.FilterCondition.Conditions)
                    {
                        switch (FC.ConditionOperator)
                        {
                            case ConditionOperator.Contains:
                                CondiationSQL[count++] += "[" + FC.Column.Key + "] LIKE N'%" + FC.Value1 + "%' ";
                                break;
                            case ConditionOperator.BeginsWith:
                                CondiationSQL[count++] += "[" + FC.Column.Key + "] LIKE N'%" + FC.Value1 + "' ";
                                break;
                            case ConditionOperator.EndsWith:
                                CondiationSQL[count++] += "[" + FC.Column.Key + "] LIKE N'" + FC.Value1 + "%' ";
                                break;
                            case ConditionOperator.NotEqual:
                                CondiationSQL[count++] += "[" + FC.Column.Key + "] <> N'" + FC.Value1 + "' ";
                                break;
                            case ConditionOperator.Equal:
                                CondiationSQL[count++] += "[" + FC.Column.Key + "] = N'" + FC.Value1 + "' ";
                                break;
                            case ConditionOperator.NotIsNull:
                                CondiationSQL[count++] += "[" + FC.Column.Key + "] is not null ";
                                break;
                            case ConditionOperator.IsNull:
                                CondiationSQL[count++] += "[" + FC.Column.Key + "] is null";
                                break;
                            case ConditionOperator.IsEmpty:
                                CondiationSQL[count++] += "([" + FC.Column.Key + "] is null  OR " + "[" + FC.Column.Key + "] = '') ";
                                break;
                            case ConditionOperator.NotIsEmpty:
                                CondiationSQL[count++] += "([" + FC.Column.Key + "] is not null  OR " + "[" + FC.Column.Key + "] <> '') ";
                                break;
                            case ConditionOperator.Between:
                                CondiationSQL[count++] += "[" + FC.Column.Key + "] Between N'" + FC.Value1 + "' AND '" + FC.Value2 + "N' ";
                                break;
                            case ConditionOperator.GreaterThan:
                                CondiationSQL[count++] += "[" + FC.Column.Key + "] > N'" + FC.Value1 + "' ";
                                break;
                            case ConditionOperator.GreaterThanOrEqualTo:
                                CondiationSQL[count++] += "[" + FC.Column.Key + "] >= N'" + FC.Value1 + "' ";
                                break;
                            case ConditionOperator.LessThan:
                                CondiationSQL[count++] += "[" + FC.Column.Key + "] < N'" + FC.Value1 + "' ";
                                break;
                            case ConditionOperator.LessThanOrEqualTo:
                                CondiationSQL[count++] += "[" + FC.Column.Key + "] <= N'" + FC.Value1 + "' ";
                                break;
                            case ConditionOperator.NotBetween:
                                CondiationSQL[count++] += "[" + FC.Column.Key + "] NOT Between N'" + FC.Value1 + "' AND N'" + FC.Value2 + "' ";
                                break;
                            case ConditionOperator.NotContains:
                                CondiationSQL[count++] += "[" + FC.Column.Key + "] NOT LIKE N'%" + FC.Value1 + "%' ";
                                break;
                            case ConditionOperator.In:
                                CondiationSQL[count++] += "[" + FC.Column.Key + "] in (" + FC.Value1 + ") ";
                                break;
                            case ConditionOperator.NotIn:
                                CondiationSQL[count++] += "[" + FC.Column.Key + "] not in (" + FC.Value1 + ") ";
                                break;
                        }
                    }

                    _SQL = String.Join(" AND ", CondiationSQL);
                }

                if ((_gridEX1.DataSource as JDataTable).Rows.Count > 0)
                {
                    this._gridEX1.SelectedItems.Clear();
                    this._gridEX1.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                    this._gridEX1.SelectedItems.Add(0);
                    this._gridEX1.Focus();

                }

                JDataTable DT = (_gridEX1.DataSource as JDataTable);
                if (DT == null || DT.Paging == null)
                {
                    //if (JSystem.Nodes != null)
                        //JSystem.Nodes.refreshGrid();
                    return;
                }
                DT.Paging.Start = 1;
                DT.Paging.Condition = _SQL;
                this._gridEX1.DataSource = DT.Paging.RefreshPage();
                DT.Clear();
                DT.Reset();
                DT = null;
            }
            catch
            {
            }

        }

		public void RefreshPaging()
		{
			cmbCount.SelectedItem = ReadValueRegister();
		}
		private void SetValueRegister(string pPageNumber)
		{
			RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);
			if (key == null)
				key = Registry.CurrentUser.CreateSubKey("Software");

			key.CreateSubKey("ERPTarahan");
			key = key.OpenSubKey("ERPTarahan", true);

			key.CreateSubKey("Version2015");
			key = key.OpenSubKey("Version2015", true);

			key.SetValue("Paging_" + _ClassName, pPageNumber);

		}

		private string ReadValueRegister()
		{
			RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);
			if (key == null)
				key = Registry.CurrentUser.CreateSubKey("Software");

			key = key.OpenSubKey("ERPTarahan");
			if (key == null)
			{
				return "...";
			}

			key = key.OpenSubKey("Version2015", true);
			if (key == null)
			{
				return "...";
			}

			return (string)key.GetValue("Paging_" + _ClassName, "...");

		}

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
			try
			{
				long Count = 0;
				try
				{
					Count = int.Parse(cmbCount.SelectedItem.ToString());
				}
				catch
				{
					Count = 9000000000000000000;
				}

				JDataTable DT = (_gridEX1.DataSource as JDataTable);
				if (DT.Paging == null)
				{
					DT.Paging = new JPage();
					DT.Paging.BaseSQL = DT.BaseSQL;
					DT.Paging.Condition = "";
				}
				DT.Paging.Start = 1;
				DT.Paging.Count = Count;
				this.DataSource = DT.Paging.RefreshPage();
				JSystem.Nodes.DataTable = this.DataSource;
				SetValueRegister(Count.ToString());
				DT.Clear();
				DT.Reset();
				DT = null;
			}
			catch
			{
			}

        }

        private void btnFormule_Click(object sender, EventArgs e)
        {
            if (_ClassName == "")
            {
                _ClassName = JDataBase.GetStringFiledsName(DefaultView);
                hasRealClassName = false;
            }

            if (_gridEX1.DataSource == null) return;
            FormFormule FF = new FormFormule((_gridEX1.DataSource as DataTable), _ClassName);
            FF.ShowDialog();
        }

        private void btnColumns_Click(object sender, EventArgs e)
        {
            if (_ClassName == "")
            {
                _ClassName = JDataBase.GetStringFiledsName(DefaultView);
                hasRealClassName = false;
            }

            if (_gridEX1.DataSource == null) return;
            ColumnsPropertiesForm CPF = new ColumnsPropertiesForm((_gridEX1.DataSource as DataTable), _ClassName);
            CPF.ShowDialog();
            HidColumns((new JHiddenColumns()).GetColumns(JMainFrame.CurrentUserCode, _ClassName));
        }

        private void btnProperties_Click(object sender, EventArgs e)
        {
            if (hasRealClassName == false) return;
            (new ClassLibrary.JDefineForm(_ClassName)).ShowDialog();
        }

        private void btnNewForm_Click(object sender, EventArgs e)
        {
            if (hasRealClassName == false) return;
            if (_gridEX1.CurrentRow == null) return;
            (new ClassLibrary.JFormObjectsForm(_ClassName, Convert.ToInt32(_gridEX1.CurrentRow.Cells["Code"].Value))).ShowDialog();
            if (JSystem.Nodes != null)
                JSystem.Nodes.refreshGrid();
        }

        public void LoadCustomize()
        {
            LoadCustomize(false);
        }

        public void LoadCustomize(bool Reset)
        {
            if (_ClassName == "")
            {
                _ClassName = JDataBase.GetStringFiledsName(DefaultView);
                hasRealClassName = false;
            }
            DataTable dt = _gridEX1.DataSource as DataTable;
            if (dt != null)
            {
            }
            else
            {
                return;
            }
            if ((_ClassName == null || _ClassName == "") && !ClassNameSet)
            {
                btnFormule.Visible = false;
                btnColumns.Visible = false;
                btnNewForm.Visible = false;
                btnProperties.Visible = false;
            }
            else
            {
                btnFormule.Visible = true;
                btnColumns.Visible = true;
                btnNewForm.Visible = true;
                //btnProperties.Visible = true; این گزینه فقط برای مدیر فعال می شود 

                try
                {
                    JFormuleManagers FMS = new JFormuleManagers(_ClassName);
                    FMS.SetDataTableFormule(dt);
                }
                catch
                {
                }
            }

            if (hasRealClassName == false)
            {
                btnProperties.Visible = false;
                btnNewForm.Visible = false;
            }

            _gridEX1.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            _gridEX1.RetrieveStructure();

            JHiddenColumns jHiddenColumns = new JHiddenColumns();
            HidColumns(jHiddenColumns.GetColumns(JMainFrame.CurrentUserCode, _ClassName));

            try
            {
                JFormuleManagers FMS = new JFormuleManagers(_ClassName);
                FMS.SetDataTableFormule(dt);
            }
            catch
            {
            }



            _gridEX1.SettingsKey = _ClassName;
            if (!Reset)
                try
                {
                    _gridEX1.LoadComponentSettings();
                }
                catch { }
                finally { }

            SetColumnsHeaderCaption();

            _gridEX1.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            _gridEX1.FilterMode = FilterMode.Manual;
            try
            {
                //_gridEX1.SaveComponentSettings();
            }
            catch { }
            finally { }
            _gridEX1.FilterMode = FilterMode.Automatic;
        }

        private void _gridEX1_LayoutLoad(object sender, EventArgs e)
        {

        }

        private void btnSendSMS_Click(object sender, EventArgs e)
        {

            ClassLibrary.SMS.SMSForm p = new ClassLibrary.SMS.SMSForm();
            p.ShowDialog();
        }

		private void _gridEX1_LoadingRow(object sender, RowLoadEventArgs e)
		{
		}


    }
}
