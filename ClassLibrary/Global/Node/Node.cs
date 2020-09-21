using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Security.Principal;
using System.DirectoryServices;
using System.Data;

namespace ClassLibrary
{
    public class JNode : JSystemNode
    {
        public int Code;
        public string ClassName;
        //private string _Name = "";
        public string Name;
        //{
        //    get
        //    {
        //        return _Name;
        //    }
        //    set
        //    {
        //        //if (_Name != value)
        //        try
        //        {
        //            _Name = value;
        //            //if (Nodes != null && Nodes.ListViewInt != null
        //            //    && Nodes.ListViewInt.SelectedItems.Count == 1
        //            //    && Nodes.ListViewInt.SelectedItems[0].Tag is JNode
        //            //    && ((JNode)Nodes.ListViewInt.SelectedItems[0].Tag).ClassName == ClassName
        //            //    && ((JNode)Nodes.ListViewInt.SelectedItems[0].Tag).Code == Code)
        //            //    Nodes.ListViewInt.SelectedItems[0].Text = _Name;
        //        }
        //        catch(Exception ex)
        //        {
        //            Except.AddException(ex);
        //        }
        //    }
        //}
        public JListViewsNodes Nodes;
        public Object[] Columns = new object[0];
        public JSearch Search;
        public JAction MouseClickAction;
        public JAction MouseDBClickAction;
        public JAction DeleteClickAction;
        public JAction EnterClickAction;
        public JAction GetPanel;
        public System.Data.DataRow Row;
        private JAction _ChildsAction;
        private bool ChangeCildAction;

        public JAction ChildsAction
        {
            get
            {
                return _ChildsAction;
            }
            set
            {
                ChangeCildAction = true;
                _ChildsAction = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        //public int Icone = (int)JImageIndex.Default;
        private int _Icone;
        public int Icone
        {
            get
            {
                return _Icone;
            }
            set
            {
                _Icone = value;//(int)JImageIndex.Default;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Hint;
        /// <summary>
        /// 
        /// </summary>
        private JPopupMenu _Popup;

        public JPopupMenu Popup
        {
            get
            {
                return _Popup;
            }
            set
            {
                _Popup = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private bool _Visible = true;
        /// <summary>
        /// 
        /// </summary>
        public static string PrivateHalfKey = "rms.Appl" + "ication.E" + "xit";
        public bool Visible
        {
            get
            {
                return _Visible;
            }
            set
            {
                _Visible = value;
            }
        }
        public JNode[] _Childs;
        public JNode[] Childs
        {
            get
            {
                try
                {
                    if (ChangeCildAction)
                    {
                        ChangeCildAction = false;
                        if (_Childs != null)
                        {
                            Array.Clear(_Childs, 0, _Childs.Length);
                            Array.Resize(ref _Childs, 0);
                        }
                        else
                            _Childs = new JNode[0];
                        if (_ChildsAction != null)
                            _Childs = (JNode[])_ChildsAction.run();
                    }
                    return _Childs;
                }
                catch
                {
                    return null;
                }
            }
            set
            {
                _Childs = value;
            }
        }

        public JNode(int pCode, string pClassName)
        {
            Code = pCode;
            ClassName = pClassName;
            if (Popup == null)
                Popup = new JPopupMenu(pClassName, pCode);
            else
            {
                Popup.BaseAction(pClassName, pCode);
            }
            Hint = pClassName + "=" + pCode.ToString();
            //JSystem.AddObject(this);
        }

        public JNode(int pCode, object pObject)
        {
            Code = pCode;
            ClassName = this.GetType().FullName;
            if (Popup == null)
                Popup = new JPopupMenu(ClassName, pCode);
            else
            {
                Popup.BaseAction(ClassName, pCode);
            }
            Hint = ClassName + "=" + pCode.ToString();
            //JSystem.AddObject(this);
        }

        public void AddChilds(JNode pChild)
        {
            Array.Resize(ref _Childs, _Childs.Length + 1);
            Childs[_Childs.Length - 1] = pChild;
        }

        public override void Dispose()
        {
            foreach (object Column in Columns)
            {
                if (Column != null)
                    GC.SuppressFinalize(Column);
            }
            if (Childs != null)
                for (int i = 0; i < Childs.Length; i++)
                {
                    if (Childs[i] != null)
                        Childs[i].Dispose();
                }
            base.Dispose();
        }

        public void RefreshToolbar(ToolStrip Tool)
        {

            //    if (Tool != null && ToolbarsItem.Length > 0)
            //    {
            //        foreach (JToolbarNode T in ToolbarsItem)
            //        {
            //            EventHandler e = new EventHandler(run);

            //            ToolStripItem TST = Tool.Items.Add(JLanguages._Text(T.Name), null, e);
            //            TST.Tag = T.Click;
            //            TST.ToolTipText = T.Hint;
            //        }
            //    }
        }

        private void run(object sender, EventArgs e)
        {
            JAction t = (JAction)((System.Windows.Forms.ToolStripItem)sender).Tag;
            object s = t.run(Nodes);
        }

        public void AddToolbar(JToolbarNode pToolbar)
        {
            //Array.Resize(ref ToolbarsItem, ToolbarsItem.Length + 1);
            //ToolbarsItem[ToolbarsItem.Length - 1] = pToolbar;
        }

    }

    public enum JToolbarNodeType
    {
        Button,

    }

    public class JToolbarNode : JSystemNode
    {
        public string Name;
        public JAction Click;
        public JImageIndex Icon;
        public string Hint;
        public bool Enabled = true;
        public JToolbarNodeType ItemType = JToolbarNodeType.Button;
        public object[] Valus;

        public ToolStripItem GetItem(EventHandler e)
        {
            if (ItemType == JToolbarNodeType.Button)
            {
                ToolStripButton obj = new ToolStripButton(JLanguages._Text(Name), null, e);
                obj.Tag = Click;
                obj.ToolTipText = Hint;
                obj.Enabled = Enabled;
                obj.Image = JImageIcon.getImage(Icon);
                return obj;
            }
            return null;
        }

        public override void Dispose()
        {
            //Click.Dispose();
            //base.Dispose();
        }
    }


    public class JListViewsNodes : JSystemNode
    {
        #region StatusStrip
        private StatusStrip _StatusStripMain;
        public StatusStrip StatusStripMain
        {
            get
            {
                return _StatusStripMain;
            }
            set
            {
                _StatusStripMain = value;
                if (_StatusStripMain != null)
                {
                    _StatusStripMain.Items.Add(".");
                    _StatusStripMain.Items.Add(".");
                    _StatusStripMain.Items.Add(".");
                }
            }
        }
        #endregion

        #region ObjectBase
        public JAction ObjectBase;
        public string ObjectManualField;
        #endregion

        public string Name;

        public Panel SubPanel;

        public TreeNode TreeNodeSelectedTreeView;
        #region GRID
        private string _hidColumns;
        public string hidColumns
        {
            get
            {
                if (_hidColumns == null)
                    return "";
                return _hidColumns;
            }
            set
            {
                _hidColumns = value;
                HidJanusGridColumns();
            }
        }


        private Janus.Windows.GridEX.GridEX _JanusGrid;
        //public Janus.Windows.GridEX.GridEX JanusGrid
        //{
        //    get
        //    {
        //        return _JanusGrid;
        //    }
        //    set
        //    {
        //        _JanusGrid = value;
        //        if(value != null)
        //        {
        //            _JanusGrid.MouseClick += new MouseEventHandler(_JanusGrid_MouseClick);
        //            _JanusGrid.MouseDoubleClick += new MouseEventHandler(_JanusGrid_MouseDoubleClick);
        //            _JanusGrid.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(Grid_FormattingRow);
        //            _JanusGrid.RowDrag += new Janus.Windows.GridEX.RowDragEventHandler(Grid_RowDrag);
        //            _JanusGrid.DragLeave += new EventHandler(Grid_DragLeave);
        //        }
        //    }
        //}

        private JRowStyles _RowStyles;
        public JRowStyles RowStyles
        {
            get
            {
                return _RowStyles;
            }
            set
            {
                _RowStyles = value;
            }
        }



        public System.Data.DataRow DragRow;
        private void Grid_RowDrag(object sender, Janus.Windows.GridEX.RowDragEventArgs e)
        {
            if (_JanusGrid.CurrentRow.DataRow != null)
                DragRow = ((System.Data.DataRowView)_JanusGrid.CurrentRow.DataRow).Row;
        }

        private void Grid_DragLeave(object sender, EventArgs e)
        {
            JMessages.Confirm("", "");
        }

        private void Grid_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                if (_RowStyles == null || _RowStyles.Rows == null || _RowStyles.Rows.Length == 0 || e.Row.DataRow == null)
                {
                    return;
                }
DataTable tblCopy = new DataTable();
                int rowIndex = Convert.ToInt32(e.Row.RowIndex);
                foreach (JRowStyle Row in _RowStyles.Rows)
                {                    
                    

                    tblCopy = ((System.Data.DataRowView)e.Row.DataRow).DataView.Table.Clone();
                    tblCopy.ImportRow(((System.Data.DataRowView)e.Row.DataRow).DataView.Table.Rows[rowIndex]);

                    if (tblCopy.Select(Row.Expression).Length > 0)
                    ///System.Data.DataTable dt = ((System.Data.DataRowView)e.Row.DataRow).DataView.ToTable();
                    //if (((System.Data.DataRowView)e.Row.DataRow).DataView.Table.Select(Row.Expression).Length > 0 )
                    {
                        e.Row.RowStyle = Row.JanusRowStyle;
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// ترجمه عنوان ستون ها
        /// </summary>
        private void SetColumnsHeaderCaption()
        {
            if (_JanusGrid == null || _JanusGrid.CurrentTable == null) return;
            try
            {
                for (int j = 0; j < _JanusGrid.CurrentTable.Columns.Count; j++)
                {
                    _JanusGrid.CurrentTable.Columns[j].Caption = JLanguages._Text(_JanusGrid.CurrentTable.Columns[j].Key);
                }
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
        public void HidJanusGridColumns()
        {
            if (_JanusGrid == null || _JanusGrid.CurrentTable == null || _hidColumns == null) return;

            string[] pColumns = hidColumns.Split(',');
            for (int i = 0; i < pColumns.Length; i++)
            {
                for (int j = 0; j < _JanusGrid.CurrentTable.Columns.Count; j++)
                {
                    if (_JanusGrid.CurrentTable.Columns[j].DataMember.ToLower() == pColumns[i].ToLower())
                    {
                        _JanusGrid.CurrentTable.Columns[j].Visible = false;
                        break;
                    }
                }

            }
        }

        public void WordWrapColumn(string colName, int MaxLinse)
        {
            if (_JanusGrid.Tables.Count > 0)
            {
                _JanusGrid.CurrentTable.Columns[colName].WordWrap = true;
                _JanusGrid.CurrentTable.Columns[colName].MaxLines = MaxLinse;
            }
        }

        private void _JanusGrid_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right && _JanusGrid.SelectedItems.Count > 0)
                {
                    Janus.Windows.GridEX.GridEXSelectedItem janusRow = _JanusGrid.SelectedItems[0];
                    System.Data.DataRow Row = ((System.Data.DataRowView)janusRow.GetRow().DataRow).Row;

                    object ret;
                    if (ObjectManualField == null)
                    {
                        ObjectBase.Arg = new object[] { Row };
                        ret = ObjectBase.run();
                    }
                    else
                    {
                        string _ActionString = (string)Row[ObjectManualField];
                        JAction Action = new JAction("RUN", _ActionString, new object[] { Row }, null);
                        ret = Action.run();
                    }

                    if (ret is JNode)
                    {
                        JNode _Node = (JNode)ret;
                        _Node.Row = Row;
                        _Node.Popup.GetPopup(_Node.Nodes).Show(Cursor.Position);

                        Array.Resize(ref CurrentNodes, 1);
                        Array.Resize(ref CurrentRows, 1);
                        CurrentNodes[0] = _Node;
                        CurrentRows[0] = Row;
                        if (CurrentNodes.Length >= 1)
                        {
                            CurrentNode = CurrentNodes[0];
                        }

                        if (CurrentNodes.Length == 1 && CurrentNode != null)
                            CurrentNode.RefreshToolbar(ToolStripNode);
                    }
                    else
                    {
                        CurrentNodes = null;
                    }
                }
            }
            catch
            {
            }
        }


        private void _JanusGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left && _JanusGrid.SelectedItems.Count > 0)
                {
                    Janus.Windows.GridEX.GridEXSelectedItem janusRow = _JanusGrid.SelectedItems[0];
                    if (janusRow.GetRow().DataRow != null)
                    {
                        System.Data.DataRow Row = ((System.Data.DataRowView)janusRow.GetRow().DataRow).Row;

                        object ret;
                        if (ObjectManualField == null)
                        {
                            ObjectBase.Arg = new object[] { Row };
                            ret = ObjectBase.run();
                        }
                        else
                        {
                            string _ActionString = (string)Row[ObjectManualField];
                            JAction Action = new JAction("RUN", _ActionString, new object[] { Row }, null);
                            ret = Action.run();
                        }

                        if (ret is JNode)
                        {
                            JNode _Node = (JNode)ret;
                            _Node.Row = Row;

                            Array.Resize(ref CurrentNodes, 1);
                            Array.Resize(ref CurrentRows, 1);
                            CurrentNodes[0] = _Node;
                            CurrentRows[0] = Row;
                            if (CurrentNodes.Length >= 1)
                            {
                                CurrentNode = CurrentNodes[0];
                            }
                            if (CurrentNodes.Length == 1 && CurrentNode != null)
                                CurrentNode.RefreshToolbar(ToolStripNode);
                            if (_Node.MouseDBClickAction != null)
                                _Node.MouseDBClickAction.run();

                        }
                        else
                        {
                            CurrentNodes = null;
                        }

                    }
                }
            }
            catch
            {
            }
        }

        #endregion

        #region SQL And DataTable And DataView
        private System.Data.DataView _DataView;
        private System.Data.DataTable _DefaultView;
        public System.Data.DataTable DefaultView
        {
            get
            {
                Janus.Windows.GridEX.GridEXRow[] Grows = _JanusGrid.GetDataRows();

                if (_DefaultView != null)
                    _DefaultView.Clear();
                _DefaultView = ((System.Data.DataRowView)Grows[0].DataRow).Row.Table.Clone();
                foreach (Janus.Windows.GridEX.GridEXRow _grow in Grows)
                {
                    System.Data.DataRow _DR = _DefaultView.NewRow();
                    JTable.CopyRow(((System.Data.DataRowView)_grow.DataRow).Row, _DR);
                    _DefaultView.Rows.Add(_DR);
                }
                return _DefaultView;
            }
        }

        public System.Data.DataTable _Selected;
        public System.Data.DataTable Selected
        {
            get
            {
                Janus.Windows.GridEX.GridEXSelectedItemCollection Grows = _JanusGrid.SelectedItems;

                if (_Selected != null)
                    _Selected.Clear();
                _Selected = _DataTable.Clone();
                foreach (Janus.Windows.GridEX.GridEXSelectedItem _grow in Grows)
                {
                    try
                    {
                        System.Data.DataRow _DR = _Selected.NewRow();
                        JTable.CopyRow(((System.Data.DataRowView)(_JanusGrid.GetRow(_grow.Position)).DataRow).Row, _DR);
                        _Selected.Rows.Add(_DR);
                    }
                    catch(Exception ex)
                    {
                        Except.AddException(ex);
                    }

                }
                return _Selected;
            }
        }

        private string _SQL;
        public string SQL
        {
            get
            {
                return _SQL;
            }
            set
            {
                _SQL = value;
                clear();
                RefreshDataTable();
            }
        }
        private System.Data.DataTable _DataTable;
        public System.Data.DataTable DataTable
        {
            get
            {
                return _DataTable;
            }
            set
            {
                try
                {
                    _DataTable = value;
                    _DataView = _DataTable.DefaultView;
                    if (_DataTable != null)
                    {
                        _DataTable.TableCleared += new System.Data.DataTableClearEventHandler(TableClearedEvent);
                        _DataTable.TableClearing += new System.Data.DataTableClearEventHandler(TableClearingEvent);
                        _DataTable.TableNewRow += new System.Data.DataTableNewRowEventHandler(NewRowEvent);
                        _DataTable.RowDeleting += new System.Data.DataRowChangeEventHandler(DeletingRowEvent);
                        _DataTable.RowDeleted += new System.Data.DataRowChangeEventHandler(DeletedRowEvent);
                        _DataTable.RowChanging += new System.Data.DataRowChangeEventHandler(ChangingRowEvent);
                        _DataTable.RowChanged += new System.Data.DataRowChangeEventHandler(ChangedRowEvent);
                        //_DataTable.RowChanged += new System.Data.DataRowChangeEventHandler(ChangedRowEvent);
                        _DataTable.ColumnChanged += new System.Data.DataColumnChangeEventHandler(ColumnChangedEvent);
                        _DataTable.ColumnChanging += new System.Data.DataColumnChangeEventHandler(ColumnChangingEvent);
                        _DataTable.Disposed += new EventHandler(DisposedEvent);
                        _DataTable.Initialized += new EventHandler(InitializedEvent);

                        _DataView.ListChanged += new System.ComponentModel.ListChangedEventHandler(DataViewListChangedEvent);
                        _DataView.Initialized += new EventHandler(InitializedEvent);


                    }
                    _SQL = null;
                    RefreshDataTable();
                }
                catch (Exception ex)
                {
                    Except.AddException(ex);
                }
            }
        }

        private System.Data.DataTable[] _DataTables;
        public System.Data.DataTable[] DataTables
        {
            get
            {
                return _DataTables;
            }
        }

        public int AddDataTable(System.Data.DataTable pDataTable)
        {
            if (_DataTables == null)
                _DataTables = new System.Data.DataTable[0];
            Array.Resize(ref _DataTables, _DataTables.Length + 1);
            _DataTables[_DataTables.Length - 1] = pDataTable;
            return _DataTables.Length - 1;
        }

        #endregion

        private bool _AutoChange = true;
        public JShortCuts ShortCuts;

        #region DataTableEvents
        private void DisposedEvent(object o, EventArgs e)
        {
        }
        private void InitializedEvent(object o, EventArgs e)
        {
        }
        private void ColumnChangingEvent(object o, System.Data.DataColumnChangeEventArgs e)
        {
        }
        private void ColumnChangedEvent(object o, System.Data.DataColumnChangeEventArgs e)
        {
        }
        private void ChangedRowEvent(object o, System.Data.DataRowChangeEventArgs e)
        {
        }
        private void ChangingRowEvent(object o, System.Data.DataRowChangeEventArgs e)
        {
            try
            {
                if (_AutoChange && e.Action != System.Data.DataRowAction.Nothing)
                {
                    ObjectBase.Arg = new object[] { e.Row };
                    object ret = ObjectBase.run();
                    if (ret is JNode)
                    {
                        if (e.Action == System.Data.DataRowAction.Add)
                        {
                            ((JNode)ret).Row = e.Row;
                            Insert((JNode)ret);
                        }
                        else
                            if (e.Action == System.Data.DataRowAction.Delete)
                            {
                                Delete(((JNode)ret));
                            }
                            else
                                if (e.Action == System.Data.DataRowAction.Change)
                                {
                                    ((JNode)ret).Row = e.Row;
                                    Refresh(((JNode)ret));
                                }
                    }
                }
                _AutoChange = true;
            }
            catch
            {
            }
        }
        private void DeletedRowEvent(object o, System.Data.DataRowChangeEventArgs e)
        {
        }
        private void DeletingRowEvent(object o, System.Data.DataRowChangeEventArgs e)
        {
        }
        private void TableClearedEvent(object o, System.Data.DataTableClearEventArgs e)
        {
        }
        private void TableClearingEvent(object o, System.Data.DataTableClearEventArgs e)
        {
        }
        private void NewRowEvent(object o, System.Data.DataTableNewRowEventArgs e)
        {
        }
        private void DataViewListChangedEvent(object o, System.ComponentModel.ListChangedEventArgs e)
        {
            try
            {
                //e.ListChangedType = System.ComponentModel.ListChangedType.
                if (DataTable != null)
                    if (e.ListChangedType == System.ComponentModel.ListChangedType.Reset && DataTable.Rows.Count > 0)
                    {
                        ListViewClear(true);
                        RefreshDataViewListView(1);
                    }

            }
            catch
            {
            }
        }
        #endregion

        #region Page

        private int _PageStart;
        private int _PageEnd;
        private bool _PageShowAll;
        private int _PageNumber;
        private PageControl _PageControl;

        private static JConfig _Config;

        public int PageStart
        {
            get
            {
                return _PageStart;
            }
            set
            {
                _PageStart = value;
                RefreshDataViewListView(1);
            }
        }
        public int PageEnd
        {
            get
            {
                return _PageEnd;
            }
            set
            {
                _PageEnd = value;
                RefreshDataViewListView(1);
            }
        }

        public int PageCount
        {
            get
            {
                return _Config.MaxLenghList;
            }
        }

        public bool PageShowAll
        {
            get
            {
                return _PageShowAll;
            }
            set
            {
                if (_PageShowAll != value)
                {
                    _PageShowAll = value;
                    if (_PageShowAll)
                        RefreshDataViewListView(1);
                }
            }
        }

        public int PageNumber
        {
            get
            {
                return _PageNumber;
            }
            set
            {
                if (_PageNumber != value)
                {
                    _PageNumber = value;
                    _PageStart = PageCount * _PageNumber;
                    _PageEnd = _PageStart + PageCount - 1;
                    RefreshDataViewListView(1);
                }
            }
        }

        public void SetPage(System.Data.DataView pDV)
        {
            if (pDV == null) return;
            _PageControl.Refresh();
            _PageEnd = _PageStart + PageCount;
            if (_PageStart < 0)
                _PageStart = 0;
            if (PageShowAll)
            {
                _PageStart = 0;
                _PageEnd = pDV.Count;
                StatusStripMain.Items[1].Text = pDV.Count.ToString();
                return;
            }
            if (_PageStart > pDV.Count)
            {
                _PageStart = pDV.Count;
            }

            if (_PageEnd == 0 || _PageEnd > pDV.Count)
            {
                _PageEnd = pDV.Count;
            }
            StatusStripMain.Items[1].Text = (_PageEnd - _PageStart).ToString();
            _PageNumber = (_PageStart / PageCount);

            if (_PageControl != null)
            {
                _PageControl.PageCount = _PageNumber;
            }
        }

        public void LastPage()
        {
            _PageStart = _DataView.Count - (_DataView.Count % PageCount);
            _PageEnd = _DataView.Count - 1;
            RefreshDataViewListView(1);
        }
        public void FirstPage()
        {
            _PageStart = 0;
            _PageEnd = PageCount - 1;
            RefreshDataViewListView(1);
        }
        public void NextPage()
        {
            if (_PageEnd < _DataView.Count)
            {
                _PageStart += PageCount;
                _PageEnd = _PageStart + PageCount - 1;
                RefreshDataViewListView(1);
            }
        }
        public void BackPage()
        {
            if (_PageStart > 0)
            {
                _PageStart -= PageCount;
                _PageEnd = _PageStart + PageCount - 1;
                RefreshDataViewListView(1);
            }
        }
        #endregion

        public JNode[] Items = new JNode[0];

        public JNode CurrentNode;
        public JNode[] CurrentNodes = new JNode[0];
        public System.Data.DataRow[] CurrentRows = new System.Data.DataRow[0];

        public string[] Columns = new string[0];
        public JToolbarNode[] ToolbarsItem = new JToolbarNode[0];
        private JPopupMenu _GlobalMenuActions;
        public JPopupMenu GlobalMenuActions
        {
            get
            {
                if (_GlobalMenuActions == null)
                    _GlobalMenuActions = new JPopupMenu("", 0);
                return _GlobalMenuActions;
            }
            set
            {
                if (_GlobalMenuActions != null)
                    _GlobalMenuActions.Dispose();
                _GlobalMenuActions = value;
            }
        }

        public JPopupMenu MultiSelectActions;
        private ListView _ListViewInt = null;
        public ListView ListViewInt
        {
            get
            {
                return _ListViewInt;
            }
            set
            {
                if (value != null)
                {
                    _ListViewInt = value;
                    _ListViewInt.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(ItemSelectionChanged);
                    _ListViewInt.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(MouseDoubleClick);
                    _ListViewInt.KeyDown += new System.Windows.Forms.KeyEventHandler(EnterClick);
                    _ListViewInt.MouseUp += new System.Windows.Forms.MouseEventHandler(MouseUp);

                    _PageControl.Parent = _ListViewInt.Parent;
                    _PageControl.Dock = DockStyle.Bottom;
                }
                TreeNodes = new JTreeViewsNodes(this);
            }
        }
        public ToolStrip ToolStripInt;
        public ToolStrip ToolStripNode;

        private JAction _CurrentAction;
        public JAction CurrentAction
        {
            get
            {
                return _CurrentAction;
            }
            set
            {
                _CurrentAction = value;
                clear();
                if (_GlobalMenuActions != null)
                    _GlobalMenuActions.Dispose();
                GlobalMenuActions = null;
                if (_CurrentAction != null)
                {
                    _CurrentAction.run(this, false);
                }
            }
        }

        private int _Last = 0;
        public JTreeViewsNodes TreeNodes;

        private TabPage _TabPageBase;
        public TabPage TabPageBase
        {
            get
            {
                return _TabPageBase;
            }
            set
            {
                _TabPageBase = value;
            }
        }
        private JJanusGrid pJanusGrid;

        public JListViewsNodes(TabPage pTabPage, JAction pAction)
        {
            _PageControl = new PageControl();
            _RowStyles = new JRowStyles();
            if (_Config == null)
                _Config = new JConfig();
            if (pTabPage != null)
            {
                TabPageBase = pTabPage;
                pJanusGrid = new JJanusGrid();

                TabPageBase.Controls.Add(pJanusGrid);
                pJanusGrid.Dock = DockStyle.Fill;
                _JanusGrid = pJanusGrid.gridEX1;
                _JanusGrid.MouseClick += new MouseEventHandler(_JanusGrid_MouseClick);
                _JanusGrid.MouseDoubleClick += new MouseEventHandler(_JanusGrid_MouseDoubleClick);
                _JanusGrid.KeyUp += new KeyEventHandler(_JanusGrid_KeyUp);
                _JanusGrid.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(Grid_FormattingRow);
                _JanusGrid.RowDrag += new Janus.Windows.GridEX.RowDragEventHandler(Grid_RowDrag);
                _JanusGrid.DragLeave += new EventHandler(Grid_DragLeave);
                _JanusGrid.ColumnHeaderClick += new Janus.Windows.GridEX.ColumnActionEventHandler(_JanusGrid_ColumnHeaderClick);
                _JanusGrid.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.None;
                _JanusGrid.Click += new EventHandler(_JanusGrid_SelectionChanged);

                if (pAction != null && pAction.ActionCommand.Length > 0)
                {
                    pJanusGrid.ActionClassName = pAction.ActionCommand;
                }


                Splitter Split = new Splitter();
                TabPageBase.Controls.Add(Split);
                Split.Dock = DockStyle.Bottom;

                SubPanel = new Panel();
                TabPageBase.Controls.Add(SubPanel);
                SubPanel.Dock = DockStyle.Bottom;
                SubPanel.Height = 0;

            }
        }

        void _JanusGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (_JanusGrid.SelectedItems.Count == 1)
            {
                Janus.Windows.GridEX.GridEXSelectedItem janusRow = _JanusGrid.SelectedItems[0];
                if (janusRow.GetRow().DataRow == null)
                    return;
                System.Data.DataRow Row = ((System.Data.DataRowView)janusRow.GetRow().DataRow).Row;

                object ret;
                if (ObjectManualField == null)
                {
                    ObjectBase.Arg = new object[] { Row };
                    ret = ObjectBase.run();
                }
                else
                {
                    string _ActionString = (string)Row[ObjectManualField];
                    JAction Action = new JAction("RUN", _ActionString, new object[] { Row }, null);
                    ret = Action.run();
                }

                if (ret is JNode)
                {
                    JNode _Node = (JNode)ret;
                    _Node.Row = Row;
                    //_Node.Popup.GetPopup(_Node.Nodes).Show(Cursor.Position);

                    Array.Resize(ref CurrentNodes, 1);
                    Array.Resize(ref CurrentRows, 1);
                    CurrentNodes[0] = _Node;
                    CurrentRows[0] = Row;
                    if (CurrentNodes.Length >= 1)
                    {
                        CurrentNode = CurrentNodes[0];
                    }

                    if (CurrentNodes.Length == 1 && CurrentNode != null && CurrentNode.GetPanel != null)
                    {
                        CloseSubPanel();
                        if (SubPanel != null)
                        {
                            object RetObj = CurrentNode.GetPanel.run();
                            if (RetObj is Panel)
                            {
                                Panel P = (RetObj as Panel);
                                ShowSubPanel(P);
                            }
                        }
                    }
                    else
                    {
                        CloseSubPanel();
                    }

                }
                else
                {
                    CurrentNodes = null;
                }
            }
        }

        void ShowSubPanel(Panel P)
        {
            if (SubPanel != null)
            {
                SubPanel.Controls.Add(P);
                SubPanel.Height = P.Height;
                P.Dock = DockStyle.Fill;
            }
        }

        void CloseSubPanel()
        {
            if (SubPanel != null)
            {
                SubPanel.Controls.Clear();
                SubPanel.Height = 0;
            }
        }

        void _JanusGrid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MouseEventArgs MEA = new MouseEventArgs(MouseButtons.Left, 2, 0, 0, 0);
                _JanusGrid_MouseDoubleClick(sender, MEA);
            }
        }

        void _JanusGrid_ColumnHeaderClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                _JanusGrid.SaveComponentSettings();
            }
            catch { }
            finally { }
        }

        public void SetDirectComponent(ListView pListView, ToolStrip pToolStripInt, ToolStrip pToolStripNode,
            JTreeViewsNodes pTreeNodes, StatusStrip pStatusStripMain, JShortCuts pShortCuts)
        {
            _ListViewInt = pListView;
            ToolStripInt = pToolStripInt;
            ToolStripNode = pToolStripNode;
            TreeNodes = pTreeNodes;
            _StatusStripMain = pStatusStripMain;
            ShortCuts = pShortCuts;
        }

        public void AddListView(ListView LV)
        {
            ListViewInt = LV;
        }

        public void AddTreeView(TreeView TV)
        {
            TreeNodes.AddTreeView(TV);
        }

        public void AddBottunBar(Janus.Windows.ButtonBar.ButtonBar Bar)
        {
            TreeNodes.AddExplorerBar(Bar);
        }

        public void Insert(JNode Node)
        {
            try
            {
                InsertNodeInListView(Node);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        public void InsertInTreeView(JNode Node)
        {
            try
            {
                TreeNodes.InsertNodeInTreeView(TreeNodes.CurrentTreeView, TreeNodes.CurrentTreeView.SelectedNode, Node, true);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        public void DeleteFromTreeView(JNode Node)
        {
            try
            {
                TreeNodes.DeleteNodeInTreeView(TreeNodes.CurrentTreeView, TreeNodes.CurrentTreeView.SelectedNode, Node, true);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        public void Delete()
        {
            Delete(CurrentNode);
        }

        public void Delete(JNode pNode)
        {
            _JanusGrid.CurrentRow.Delete();
            if (pNode != null)
                DeleteNodeInListView(pNode.ClassName, pNode.Code);
        }

        public void Delete(string pClassName, int pCode)
        {
            DeleteNodeInListView(pClassName, pCode);
        }

        public void Refreshdata(JNode Node, System.Data.DataRow pDR)
        {

            if (Node == null)
            {
                Node = new JNode(0, "");
                Node.Row = (_JanusGrid.CurrentRow.DataRow as System.Data.DataRowView).Row;
            }
            if (Node.Row == null)
                return;
            Node.Row.BeginEdit();
            foreach (System.Data.DataColumn DC in Node.Row.Table.Columns)
            {
                try
                {
                    Node.Row[DC.Caption] = pDR[DC.Caption];
                }
                catch
                {
                }
            }
            Node.Row.EndEdit();
        }

        public void Refresh(JNode Node)
        {
            RefreshNodeInListView(Node);
        }

        public void RefreshDataTable()
        {
            if (_SQL != null)
            {
                JDataBase DB = new JDataBase();
                try
                {
                    DB.setQuery(_SQL);
                    DataTable = DB.Query_DataTable();
                }
                finally
                {
                    DB.Dispose();
                }
            }
            if (_JanusGrid != null)
            {
                try
                {
                    _JanusGrid.SaveComponentSettings();
                }
                catch (Exception ex)
                {
                    Except.AddException(ex);
                }
                _JanusGrid.DataSource = DataTable;
                _JanusGrid.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
                pJanusGrid.LoadCustomize();
                HidJanusGridColumns();
            }
            RefreshDataViewListView();
        }



        private void RefreshDataViewListView()
        {
            RefreshDataViewListView(0);
        }

        private void ListViewClear(bool pRenew)
        {
            if (_ListViewInt != null)
                _ListViewInt.Clear();
            if (pRenew)
            {
                _PageStart = 0;
                _PageEnd = PageCount;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="State">
        /// 0 = reset and new
        /// 1 = refresh or sort
        /// </param>
        private void RefreshDataViewListView(int pState)
        {
            if (_ListViewInt == null)
                return;
            if (StatusStripMain != null)
            {
                StatusStripMain.Items[0].Text = _DataView.Count.ToString();
                StatusStripMain.Items[2].Text = JDataBase.OpenDatabase.ToString();
            }

            if (pState == 0)
            {
                _SetColumnDataTable();
            }


            if (pState == 1)
            {
                ListViewClear(false);
            }

            ListViewRefreshColumn();
            int count = 0;

            SetPage(_DataView);
            int ListLength = _PageEnd - _PageStart;

            Array.Resize(ref Items, ListLength);
            ListViewItem[] LVIs = new ListViewItem[ListLength];

            for (int i = PageStart; i < _PageEnd; i++)
            {
                System.Data.DataRow Row = _DataView[i].Row;
                object ret;
                if (ObjectManualField == null)
                {
                    ObjectBase.Arg = new object[] { Row };
                    ret = ObjectBase.run(true);
                }
                else
                {
                    string _ActionString = (string)Row[ObjectManualField];
                    JAction Action = new JAction("RUN", _ActionString, new object[] { Row }, null, true);
                    ret = Action.run();
                }

                if (ret is JNode)
                {
                    ((JNode)ret).Row = Row;
                    Items[count] = (JNode)ret;
                    LVIs[count] = CreateItem((JNode)ret, null);
                    count++;
                }
            }
            _ListViewInt.Items.AddRange(LVIs);

            //JDataBase.dbsOpen.Clear();
        }

        public void RefreshNode()
        {
            try
            {
                ListViewItem pItem = JSystem.Nodes.ListViewInt.SelectedItems[0];
                System.Data.DataRow Row = ((JNode)pItem.Tag).Row;
                object ret;

                if (ObjectManualField == null)
                {
                    ObjectBase.Arg = new object[] { Row };
                    ret = ObjectBase.run();
                }
                else
                {
                    string _ActionString = (string)Row[ObjectManualField];
                    JAction Action = new JAction("RUN", _ActionString, new object[] { Row }, null);
                    ret = Action.run();
                }

                if (ret is JNode)
                {
                    ((JNode)ret).Row = Row;
                    CreateItem((JNode)ret, pItem);
                }
            }
            catch
            {
            }
        }

        private void InsertNodeInItem(JNode Node)
        {
            Node.Nodes = this;
            bool FindNull = false;
            for (int i = 0; i < _Last; i++)
            {
                if (Items[i] == null && !FindNull)
                {
                    Items[i] = Node;
                    FindNull = true;
                    break;
                }
            }
            if (!FindNull)
            {
                Array.Resize(ref Items, _Last + 1);
                Items[_Last] = Node;
                _Last++;
            }

        }

        #region Columns
        private void _SetColumnDataTable()
        {
            if (_DataTable != null)
            {
                foreach (System.Data.DataColumn Column in _DataTable.Columns)
                {
                    int Len;
                    if (Column.DataType.FullName == "System.String")
                        Len = Column.MaxLength;
                    else
                        Len = 100;
                    AddColumn(Column.Caption + ":" + Len.ToString()); ;
                }
            }
        }

        private void _CreateColumnNodeRow(JNode pNode)
        {
            Array.Resize(ref pNode.Columns, _DataTable.Columns.Count);
            int i = 0;
            foreach (System.Data.DataColumn Column in _DataTable.Columns)
            {
                pNode.Columns[i] = pNode.Row[i];
                i++;
            }
        }

        private void ListViewRefreshColumn()
        {
            if (ListViewInt == null)
                return;
            string[] _Columns = hidColumns.Split(',');
            ListViewInt.Columns.Clear();
            _ListViewInt.Columns.Add("");
            foreach (string C in Columns)
            {
                if (Array.IndexOf(_Columns, C) < 0)
                {
                    // string strCulomnWith = "100";
                    int PlaceSep = -1;
                    PlaceSep = C.IndexOf(":");
                    if (PlaceSep > 0)
                    {
                        try
                        {
                            string[] TempStr = C.Split(':');
                            _ListViewInt.Columns.Add(TempStr[0], int.Parse(TempStr[1]));
                        }
                        catch
                        {
                            _ListViewInt.Columns.Add(C.Substring(0, PlaceSep));
                        }
                    }
                    else
                    {
                        _ListViewInt.Columns.Add(C, JLanguages._Text(C));
                    }
                }
            }

        }

        public void AddColumn(string pName)
        {
            Array.Resize(ref Columns, Columns.Length + 1);
            Columns[Columns.Length - 1] = pName;
        }

        #endregion

        private ListViewItem CreateItem(JNode Node, ListViewItem pVI)
        {
            try
            {
                if (Node.Row != null)
                    _CreateColumnNodeRow(Node);
                ListViewItem VI;
                if (pVI == null)
                    VI = new ListViewItem();
                else
                    VI = pVI;
                VI.Text = JLanguages._Text(Node.Name);
                VI.ImageIndex = (int)Node.Icone;
                foreach (object col in Node.Columns)
                    if (col != null)
                    {
                        object VarTemp;
                        if (col is DateTime)
                            VarTemp = JDateTime.FarsiDate((DateTime)col);
                        else
                            VarTemp = col;
                        VI.SubItems.Add(VarTemp.ToString());
                    }
                VI.ImageIndex = (int)Node.Icone;
                VI.Tag = Node;
                VI.ToolTipText = Node.Hint;

                return VI;
                return null;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
        }

        private void InsertNodeInListView(JNode Node)
        {
            try
            {
                if (Node != null && Node.Visible && ListViewInt != null)
                {
                    ListViewItem VI = CreateItem(Node, null);
                    ListViewInt.Items.Add(VI);
                    InsertNodeInItem(Node);
                    CurrentNode = Node;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void DeleteNodeInListView(string pClassName, int pCOde)
        {
            if (ListViewInt != null)
            {
                foreach (ListViewItem LVI in ListViewInt.Items)
                {
                    if (LVI.Tag is JNode)
                    {
                        JNode NItem = (JNode)LVI.Tag;
                        if (NItem.ClassName == pClassName && NItem.Code == pCOde)
                        {
                            LVI.Remove();
                            if (NItem.Row != null)
                            {
                                _AutoChange = false;
                                NItem.Row.Delete();
                                NItem.Row = null;
                                _AutoChange = true;
                            }
                            NItem.Dispose();
                            NItem = null;
                        }
                    }
                }
            }
        }

        public JNode getNode(string pClassName, int pCOde)
        {
            try
            {
                foreach (JNode Node in Items)
                {
                    if (Node != null && Node.ClassName == pClassName && Node.Code == pCOde)
                    {
                        return Node;
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }


        private void RefreshNodeInListView(JNode Node)
        {
            if (ListViewInt != null)
            {
                foreach (ListViewItem VI in ListViewInt.Items)
                {
                    if (VI.Tag is JNode)
                    {
                        JNode NItem = (JNode)VI.Tag;
                        if (NItem.ClassName == Node.ClassName && NItem.Code == Node.Code)
                        {
                            CreateItem(Node, VI);
                            break;
                        }
                    }
                }
            }
        }

        public ToolStripItem RefreshDataTableButton()
        {
            JToolbarNode T = new JToolbarNode();
            T.Icon = JImageIndex.report;
            T.Name = "Refresh";
            T.ItemType = JToolbarNodeType.Button;
            T.Valus = null;
            EventHandler e = new EventHandler(RefreshDataTableButtonEvent);
            return T.GetItem(e);
        }

        private void RefreshDataTableButtonEvent(object sender, EventArgs e)
        {
            try
            {
                if (_JanusGrid.DataSource is JDataTable && (_JanusGrid.DataSource as JDataTable).Paging != null)
                {
                    JDataTable _DT = (_JanusGrid.DataSource as JDataTable);
                    _JanusGrid.DataSource = _DT.Paging.RefreshPage();
                    _DT.Clear();
                    _DT.Reset();
                    _DT = null;
                }
                else
                {
                    JSystem.Nodes.CurrentAction = JSystem.Nodes.CurrentAction;
                }
                RefreshToolbar();
                JSystem.Nodes.TreeNodes.RefreshAddressBar(JSystem.Nodes.TreeNodeSelectedTreeView);
            }
            catch
            {
            }
        }


        public void RefreshToolbar()
        {
            if (ToolStripInt != null)
            {
                ToolStripInt.Items.Clear();
                foreach (JToolbarNode T in ToolbarsItem)
                {
                    if (ToolStripInt != null)
                    {
                        EventHandler e = new EventHandler(run);
                        ToolStripInt.Items.Add(T.GetItem(e));
                    }
                }
                ToolStripInt.Items.Add(RefreshDataTableButton());
            }
        }

        public void AddToolbar(JToolbarNode pToolbar)
        {
            Array.Resize(ref ToolbarsItem, ToolbarsItem.Length + 1);
            ToolbarsItem[ToolbarsItem.Length - 1] = pToolbar;
            if (ToolStripInt != null)
            {
                EventHandler e = new EventHandler(run);
                ToolStripInt.Items.Add(pToolbar.GetItem(e));
            }
            setShortCutKey(pToolbar);
            ToolStripInt.Items.Add(RefreshDataTableButton());
        }

        private void setShortCutKey(JToolbarNode pToolbar)
        {
            JShortCut SC = new JShortCut();
            SC.Action = pToolbar.Click;
            SC.Object = this;
            SC.Control = true;

            if (pToolbar.Icon == JImageIndex.Add)
            {
                SC.Key = Keys.I;
            }

            if (ShortCuts != null)
                ShortCuts.Add(SC);

        }

        private void run(object sender, EventArgs e)
        {
            try
            {
                JAction t = (JAction)((System.Windows.Forms.ToolStripItem)sender).Tag;
                object s = t.run(this);
            }
            catch
            {
            }
        }

        public void clear()
        {
            Name = "";
            _RowStyles.Clear();
            _Last = 0;
            DisposeNodes();
            if (TreeNodes != null)
                TreeNodes.RefreshAddressBar(null);
            Array.Resize(ref Items, 0);
            Array.Resize(ref Columns, 0);
            Array.Resize(ref ToolbarsItem, 0);
            if (ListViewInt != null)
                ListViewClear(true);
            if (_JanusGrid != null && _JanusGrid.DataSource != null)
            {
                _JanusGrid.DataSource = null;
            }
            if (ToolStripInt != null)
                ToolStripInt.Items.Clear();
            if (_DataTable != null)
            {
                _DataTable.Clear();
                _DataTable.Dispose();
            }
            if (_DataView != null)
            {
                _DataView.Table.Clear();
                _DataView.Dispose();
            }
            ObjectManualField = null;
            if (ObjectBase != null)
            {
                ObjectBase.Dispose();
                ObjectBase = null;
            }
            hidColumns = "";
            if (ShortCuts != null)
                ShortCuts.Clear();

            if (_DataTables != null && _DataTables.Length > 0)
            {
                foreach (System.Data.DataTable _mdt in _DataTables)
                {
                    if (_mdt != null)
                    {
                        _mdt.Clear();
                        _mdt.Dispose();
                    }
                }
                Array.Resize(ref _DataTables, 0);

            }

            try
            {
            }
            catch
            {
            }
        }

        public void DisposeNodes()
        {
            foreach (JNode node in Items)
                if (node != null)
                {
                    node.Dispose();
                }
        }

        public void DisposeToolBars()
        {
            foreach (JToolbarNode node in ToolbarsItem)
            {
                node.Dispose();
            }
        }

        public override void Dispose()
        {
            DisposeNodes();
            DisposeToolBars();
            clear();
            if (JListView.PerTabPage != null && JListView.PerTabPage.Parent != null)
            {
                (JListView.PerTabPage.Parent as TabControl).SelectTab(JListView.PerTabPage);
                JListView.PerTabPage = null;
            }
            if (TabPageBase != null)
                TabPageBase.Dispose();
            JSystem.FreeNodes(this);
            GC.SuppressFinalize(this);

        }


        private void ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {

            string Name = WindowsIdentity.GetCurrent().Name;

            if (e.IsSelected)
            {
                if (e.Item.Tag is JNode)
                {
                    int i = 0;
                    Array.Resize(ref CurrentNodes, e.Item.ListView.SelectedItems.Count);
                    Array.Resize(ref CurrentRows, e.Item.ListView.SelectedItems.Count);
                    foreach (ListViewItem item in e.Item.ListView.SelectedItems)
                    {
                        if (item.Tag is JNode)
                        {
                            CurrentNodes[i] = (JNode)item.Tag;
                            CurrentRows[i] = ((JNode)item.Tag).Row;
                            i++;
                        }
                    }
                    if (CurrentNodes.Length >= 1)
                    {
                        CurrentNode = CurrentNodes[0];
                    }

                    if (CurrentNodes.Length == 1)
                        CurrentNode.RefreshToolbar(ToolStripNode);
                }
            }
            else
            {
                CurrentNodes = null;
            }
        }

        private void MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _ListViewInt != null && _ListViewInt.SelectedItems != null)
            {
                DBClick();
            }
        }


        private void EnterClick(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && _ListViewInt != null && _ListViewInt.SelectedItems != null)
            {
                DBClick();
            }
            else
                if (e.KeyCode == Keys.F && e.Control)
                {
                    Globals.DynamicSearchForm ds = new Globals.DynamicSearchForm(DataTable);
                    ds.ShowDialog();
                    ds.Dispose();
                }
                else
                    if (e.KeyCode == Keys.P && e.Control)
                    {
                    }
                    else
                        if (e.KeyCode == Keys.S && e.Control)
                        {
                            Globals.JDQuickSearch ds = new Globals.JDQuickSearch(DataTable);
                            ds.ShowDialog();
                            ds.Dispose();
                        }
        }


        public void DBClick()
        {
            if (_ListViewInt != null && _ListViewInt.SelectedItems != null
                && _ListViewInt.SelectedItems.Count > 0)
            {
                ListViewItem VI = _ListViewInt.SelectedItems[0];
                if (VI.Tag != null)
                {
                    JNode node = (JNode)VI.Tag;
                    if (node.MouseDBClickAction == null) return;
                    if (node.MouseDBClickAction != null && node.MouseDBClickAction.CleareList)
                    {
                        CurrentAction = node.MouseDBClickAction;
                        TreeNodes.SelectNode(node);
                    }
                    else
                        node.MouseDBClickAction.run(this);
                }
            }

        }

        public void RightClick()
        {
            if (_ListViewInt != null && _ListViewInt.SelectedItems != null
                && _ListViewInt.SelectedItems.Count == 1)
            {
                ListViewItem VI = _ListViewInt.SelectedItems[0];
                {
                    if (VI.Tag != null)
                    {
                        JNode node = (JNode)VI.Tag;
                        node.Popup.GetPopup(node.Nodes).Show(Cursor.Position);
                    }
                }
            }
            else
                if (_ListViewInt != null && _ListViewInt.SelectedItems.Count == 0 && GlobalMenuActions != null)
                {
                    GlobalMenuActions.GetPopup(this).Show(Cursor.Position);
                }
        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && _ListViewInt.SelectedItems != null)
            {
                RightClick();
            }
        }
    }

    public class JTreeViewsNodes : JSystemNode
    {
        private bool DisableSelect = false;
        public JNode[] Items = new JNode[0];
        public JNode RootNode;
        public TreeNode RootTree;
        public JNode CurrentNode = null;
        public JPopupMenu GlobalActions;
        public JListViewsNodes ListViewNodes;
        private TreeView _TreeViewInt = null;

        public static TabControl TabControler;

        private TreeNode CurrentTreeNode;
        public TreeView CurrentTreeView;

        public TreeView TreeViewInt
        {
            get
            {
                return _TreeViewInt;
            }
            set
            {
                if (value != null)
                {
                    _TreeViewInt = value;
                    _TreeViewInt.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(AfterSelect);
                    _TreeViewInt.MouseUp += new System.Windows.Forms.MouseEventHandler(MouseUp);
                    _TreeViewInt.MouseDoubleClick += new MouseEventHandler(_TreeViewInt_MouseDoubleClick);
                    //RootTree = _TreeViewInt.Nodes.Add("Console Root");
                    //CurrentTreeNode = RootTree;

                    JApplicationsManager AP = new JApplicationsManager();

                    JNode lRoot = new JNode(0, "ERP");
                    lRoot.Name = "Application";
                    lRoot.MouseClickAction = new JAction("Application", "ClassLibrary.JTreeViewsNodes.ApplicationListView", null, new object[] { ListViewNodes }, true);
                    CurrentNode = lRoot;
                    //                    RootTree.Tag = lRoot;
                    foreach (JNode N in AP.GetNods())
                    {
                        lRoot.AddChilds(N);
                    }

                    ApplicationListView();
                    Insert(lRoot);


                    //foreach(JNode N in AP.GetNods())
                    //{
                    //    //lRoot.AddChilds(N);
                    //    //Insert(N);
                    //    ListViewNodes.Insert(N);
                    //}
                }
            }
        }

        void _TreeViewInt_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeViewEventArgs TEA = new TreeViewEventArgs((sender as TreeView).SelectedNode);
            AfterSelect(sender, TEA);
            //throw new NotImplementedException();
        }

        private Janus.Windows.ButtonBar.ButtonBar _ButtonBar;
        public Janus.Windows.ButtonBar.ButtonBar ButtonBar
        {
            get
            {
                return _ButtonBar;
            }
            set
            {
                if (value != null)
                {
                    _ButtonBar = value;
                    _ButtonBar.GroupClick += new Janus.Windows.ButtonBar.GroupEventHandler(buttonBar_GroupClick);
                    ButtonBarRefresh();
                }
            }
        }

        public void ButtonBarRefresh()
        {
            JApplicationsManager AP = new JApplicationsManager();
            Array.Resize(ref JApplicationsManager.ANodes, 0);
            JApplicationsManager.ANodes = null;
            JNode[] ANodes = AP.GetNods();

            foreach (Janus.Windows.ButtonBar.ButtonBarGroup BB in _ButtonBar.Groups)
            {
                BB.Tag = null;
            }

            foreach (JNode N in ANodes)
            {
                TreeView jj = new TreeView();
                jj.RightToLeftLayout = true;
                jj.HideSelection = false;
                jj.BackColor = System.Drawing.Color.LemonChiffon;
                jj.ImageList = JImageIcon.GetImageList(new System.Drawing.Size(32, 32));
                jj.Dock = DockStyle.Fill;
                jj.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(AfterSelect);
                jj.MouseUp += new System.Windows.Forms.MouseEventHandler(MouseUp);
                jj.MouseDoubleClick += new MouseEventHandler(jj_MouseDoubleClick);
                jj.DragDrop += new DragEventHandler(Grid_DragLeave);

                Janus.Windows.ButtonBar.ButtonBarGroup group;
                group = null;
                foreach (Janus.Windows.ButtonBar.ButtonBarGroup BB in _ButtonBar.Groups)
                {
                    if (BB.Text == JLanguages._Text(N.Name))
                    {
                        group = BB;
                        break;
                    }
                }

                if (group == null)
                {
                    group = new Janus.Windows.ButtonBar.ButtonBarGroup();
                    _ButtonBar.Groups.Add(group);
                }
                else
                {
                }

                group.Text = JLanguages._Text(N.Name);
                group.Tag = N;
                group.Container = true;
                group.ContainerControl.Controls.Add(jj);
                InsertNodeInTreeView(jj, null, N, false);

            }

            foreach (Janus.Windows.ButtonBar.ButtonBarGroup BB in _ButtonBar.Groups)
            {
                BB.Visible = !(BB.Tag == null);
            }

            ApplicationListView();

            if (CurrentAction != null)
                CurrentAction.run(ListViewNodes, false);
        }

        void jj_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeViewEventArgs TEA = new TreeViewEventArgs((sender as TreeView).SelectedNode);
            AfterSelect(sender, TEA);
            //throw new NotImplementedException();
        }

        public ToolStrip ToolStripInt;
        public ToolStrip ToolStripNode;

        private JAction _CurrentAction;
        public JAction CurrentAction
        {
            get
            {
                return _CurrentAction;
            }
            set
            {
                _CurrentAction = value;
                if (ListViewNodes != null)
                {
                    //ListViewNodes.CurrentAction = _CurrentAction;
                }
            }
        }

        private int _Last = 0;
        private Panel _AddressBar;
        public Panel AddressPanel
        {
            get
            {
                return _AddressBar;
            }
            set
            {
                _AddressBar = value;
            }
        }

        private string _AddressBarText;
        public string AddressBarText
        {
            get
            {
                return _AddressBarText;
            }
            set
            {
                _AddressBarText = value;
            }
        }

        public JTreeViewsNodes(JListViewsNodes Nodes)
            : this(Nodes, null)
        {
        }

        public JTreeViewsNodes(JListViewsNodes Nodes, Panel pAddressbar)
        {
            RootNode = new JNode(0, "ClassLibrary.JSystem.ListView");
            ListViewNodes = Nodes;
            _AddressBar = pAddressbar;

        }

        public void AddTreeView(TreeView TV)
        {
            TreeViewInt = TV;
        }

        public void AddExplorerBar(Janus.Windows.ButtonBar.ButtonBar EX)
        {
            ButtonBar = EX;
        }

        private void Grid_DragLeave(object sender, EventArgs e)
        {
            JMessages.Confirm("", "");
        }


        public void Insert(JNode Node)
        {
            Array.Resize(ref Items, _Last + 1);
            Items[_Last] = Node;
            _Last++;

            //            RootTree = _TreeViewInt.Nodes.Add("Console Root");
            //            RootTree.Tag = Node;
            //            CurrentTreeNode = RootTree;

            InsertNodeInTreeView(_TreeViewInt, RootTree, Node, false);
        }

        public void Delete(JNode Node)
        {
            DeleteNodeInTreeView(_TreeViewInt, RootTree, Node, false);
        }

        public void Refresh(JNode Node)
        {
            RefreshNodeInTreeView(Node);
        }

        public void InsertNodeInTreeView(TreeView pTreeView, TreeNode Root, JNode Node, bool pNotIsRoot)
        {
            if (Node != null && Node.Visible)
            {
                if (pTreeView != null && Node != null)
                {
                    TreeNode VI = null;
                    if (pNotIsRoot)
                    {
                        if (Root == null)
                        {
                            RootTree = pTreeView.Nodes.Add(JLanguages._Text(Node.Name));
                            RootTree.Tag = Node;
                            CurrentTreeNode = RootTree;
                            VI = RootTree;
                            //Hasanzadeh
                            VI.ImageIndex = (int)Node.Icone;
                        }
                        else
                        {
                            VI = Root.Nodes.Add(JLanguages._Text(Node.Name));
                            VI.ImageIndex = (int)Node.Icone;
                            VI.Tag = Node;
                            VI.ToolTipText = Node.Hint;
                        }
                    }
                    if (Node.Childs != null)
                        foreach (JNode N in Node.Childs)
                        {
                            InsertNodeInTreeView(pTreeView, VI, N, true);
                        }
                    if (Root == null)
                    {
                        //RootTree.Expand();
                    }
                }
            }
        }

        public void DeleteNodeInTreeView(TreeView pTreeView, TreeNode Root, JNode Node, bool pNotIsRoot)
        {
            if (pTreeView != null)
            {
                foreach (TreeNode LVI in pTreeView.Nodes)
                {
                    if (LVI.Tag is JNode)
                    {
                        JNode NItem = (JNode)LVI.Tag;
                        if (NItem.ClassName == Node.ClassName && NItem.Code == Node.Code)
                        {
                            LVI.Remove();
                        }
                    }
                }
            }
        }

        public void RefreshNodeInTreeView(JNode Node)
        {
            if (TreeViewInt != null)
            {
                foreach (TreeNode VI in TreeViewInt.Nodes)
                {
                    if (VI.Tag is JNode)
                    {
                        JNode NItem = (JNode)VI.Tag;
                        if (NItem.ClassName == Node.ClassName && NItem.
                            Code == Node.Code)
                        {
                            VI.Text = JLanguages._Text(Node.Name);
                            VI.ImageIndex = (int)Node.Icone;
                            VI.Tag = Node;
                            VI.ToolTipText = Node.Hint;
                        }
                    }
                }
            }
        }

        public void ApplicationListView()
        {
            JApplicationsManager AP = new JApplicationsManager();
            foreach (JNode N in AP.GetNods())
            {
                ListViewNodes.Insert(N);
            }
        }
        public JNode[] ApplicationTreeView()
        {
            JApplicationsManager AP = new JApplicationsManager();
            return AP.GetNods();
        }

        private void run(object sender, EventArgs e)
        {
            JAction t = (JAction)((System.Windows.Forms.ToolStripItem)sender).Tag;
            object s = t.run(ListViewNodes);
        }

        public void clear()
        {
            JFreeClass.Check();
            _Last = 0;
            DisposeNodes();
            Array.Resize(ref Items, 0);
            if (TreeViewInt != null)
                TreeViewInt.Nodes.Clear();
            if (ToolStripInt != null)
                ToolStripInt.Items.Clear();
        }

        public void DisposeNodes()
        {
            foreach (JNode node in Items)
            {
                node.Dispose();
            }
        }

        public override void Dispose()
        {
            DisposeNodes();
            GC.SuppressFinalize(this);
        }


        public void SelectNode(JNode Node)
        {
            if (CurrentNode != null && CurrentNode.Childs != null && CurrentNode.Childs.Length > 0)
            {
                foreach (JNode JN in CurrentNode.Childs)
                {
                    if (CurrentTreeNode != null && JN != null && JN.ClassName == Node.ClassName && JN.Code == Node.Code)
                        foreach (TreeNode TN in CurrentTreeNode.Nodes)
                        {
                            if (TN.Tag.Equals(JN))
                            {
                                DisableSelect = true;
                                TN.TreeView.SelectedNode = TN;
                                DisableSelect = false;
                                CurrentNode = JN;
                                CurrentTreeNode = TN;
                                return;
                            }
                        }
                }
            }
        }

        private void AddressBarBottonClick(object sender, EventArgs e)
        {

            ((TreeNode)((Button)sender).Tag).TreeView.SelectedNode = (TreeNode)((Button)sender).Tag;
        }

        private void CreateAddressBar(TreeNode pNode)
        {
            CreateAddressBar(pNode, true);
        }

        private void CreateAddressBar(TreeNode pNode, bool pFirst)
        {
            try
            {
                if (pNode.Parent != null)
                    CreateAddressBar(pNode.Parent, false);
                Button B = new Button();
                B.Parent = _AddressBar;
                B.Text = JLanguages._Text(((JNode)pNode.Tag).Name);
                B.Dock = DockStyle.Right;
                B.BackColor = System.Drawing.Color.LightGreen;
                if (!pFirst)
                {
                    B.Text += "->";
                    B.Click += new EventHandler(AddressBarBottonClick);
                    B.BackColor = System.Drawing.Color.Linen;
                }
                B.Tag = pNode;
                B.AutoSize = true;

                _AddressBar.Controls.Add(B);
                B.BringToFront();
                _AddressBarText += B.Text;
            }
            catch
            {
            }
        }

        private void CreateCloseNodeButtonBar()
        {
            try
            {
                Button CloseNodeButton = new Button();
                CloseNodeButton.Parent = _AddressBar;
                CloseNodeButton.Text = JLanguages._Text("Close");
                CloseNodeButton.Dock = DockStyle.Right;
                CloseNodeButton.BackColor = System.Drawing.Color.LightGreen;
                CloseNodeButton.Click += new EventHandler(CloseNodeButton_Click);
                CloseNodeButton.AutoSize = true;
                _AddressBar.Controls.Add(CloseNodeButton);
                CloseNodeButton.BringToFront();
            }
            catch
            {
            }
        }

        public void RefreshAddressBar(TreeNode pNode)
        {
            _AddressBarText = "";
            _AddressBar.Controls.Clear();
            if (pNode != null)
            {
                CreateAddressBar(pNode);
                CreateCloseNodeButtonBar();
            }
        }

        void CloseNodeButton_Click(object sender, EventArgs e)
        {
            ListViewNodes.Dispose();
        }



        private void AfterSelect(object sender, TreeViewEventArgs e)
        {
            CurrentTreeView = (TreeView)sender;
            //------Hasanzadeh
            if (!DisableSelect && e.Node != null && e.Node.Tag != null)
            {

                JListView.PerTabPage = ListViewNodes.TabPageBase;
                CurrentNode = (JNode)e.Node.Tag;
                if (CurrentNode.MouseClickAction == null)
                    return;

                JListViewsNodes _N = JSystem.findNodes(CurrentNode.MouseClickAction);

                if (_N != null && _N.CurrentAction == null)
                {
                    ListViewNodes = _N;
                    ListViewNodes.CurrentAction = CurrentNode.MouseClickAction;
                    //ListViewNodes.TabPageBase.Text = JLanguages._Text(_N.CurrentAction.Name);
                    if (ListViewNodes.TabPageBase != null)
                        ListViewNodes.TabPageBase.Tag = _N;
                }
                else
                    if (_N != null && _N.TabPageBase != null)
                    {
                        if (_N.TabPageBase.Parent != null)
                            (_N.TabPageBase.Parent as TabControl).SelectTab(_N.TabPageBase);
                        //if (_N.CurrentAction != null)
                        //_N.TabPageBase.Text = JLanguages._Text(_N.Name);
                        ListViewNodes = _N;
                    }
                    else
                    {

                        TabPage TT = new TabPage("");
                        TT.Hide();
                        if (CurrentNode.MouseClickAction != null)
                            TT.Text = JLanguages._Text(CurrentNode.Name);
                        TabControler.TabPages.Add(TT);
                        (TT.Parent as TabControl).SelectTab(TT);
                        JListViewsNodes _Nodes = new JListViewsNodes(TT, CurrentNode.MouseClickAction);

                        _Nodes.SetDirectComponent(ListViewNodes.ListViewInt, ListViewNodes.ToolStripInt
                            , ListViewNodes.ToolStripNode, ListViewNodes.TreeNodes, ListViewNodes.StatusStripMain, ListViewNodes.ShortCuts);


                        JSystem.Nodes = _Nodes;
                        ListViewNodes = _Nodes;
                        TT.Tag = _Nodes;
                        ListViewNodes.CurrentAction = CurrentNode.MouseClickAction;
                        if (ListViewNodes.DataTable == null)
                        {
                            if (TabControler.SelectedTab != null)
                            {
                                ListViewNodes.Dispose();
                                if (TabControler.SelectedTab != null)
                                    ListViewNodes = (TabControler.SelectedTab.Tag as JListViewsNodes);
                            }
                        }
                        else
                        {
                            TT.Show();
                        }

                        if (_AddressBar != null)
                        {
                            RefreshAddressBar(e.Node);
                        }
                    }

                JSystem.Nodes = ListViewNodes;
                ListViewNodes.TreeNodeSelectedTreeView = e.Node;
                ListViewNodes.RefreshToolbar();
                CurrentAction = CurrentNode.MouseClickAction;
                CurrentTreeNode = e.Node;
            }
        }

        public void buttonBar_GroupClick(object sender, Janus.Windows.ButtonBar.GroupEventArgs e)
        {
            if (e.Group.Tag != null && e.Group.ContainerControl.Controls.Count > 0)
            {
                ((TreeView)e.Group.ContainerControl.Controls[0]).SelectedNode = null;

                //CurrentNode = (JNode)e.Group.Tag;
                //ListViewNodes.CurrentAction = CurrentNode.MouseClickAction;
                //CurrentTreeNode = null;
            }
        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ((TreeView)sender).SelectedNode != null)
            {
                RightClick((TreeView)sender);
            }
        }

        public void RightClick(TreeView pTreeView)
        {
            if (pTreeView != null && pTreeView.SelectedNode != null)
            {

                TreeNode TN = pTreeView.SelectedNode;
                {
                    if (TN.Tag != null)
                    {
                        JNode node = (JNode)TN.Tag;
                        node.Popup.GetPopup(node.Nodes).Show(Cursor.Position);
                    }
                }
            }
        }
    }
}
