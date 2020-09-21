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
    public partial class JDataTreeView : UserControl
    {
        public DataTable dtTree;
        public string Code;
        public string ParentCode;
        public string Title;
        public bool CheckBox = false;
        public bool RTLLayout = true;
        public object SelectedItem;
        public ContextMenuStrip CMenu;
 
        public JDataTreeView()
        {
            InitializeComponent();
                        
        }
        public void Refresh()
        {
            TreeView.Nodes.Clear();
            TreeView.CheckBoxes = CheckBox;
            if (RTLLayout)
            {
                this.RightToLeft = RightToLeft.Yes;
                txtSearch.RightToLeft = RightToLeft.Yes;
            }
            TreeView.RightToLeftLayout = RTLLayout;
            _Tree(TreeView);
            if (TreeView.Nodes != null && TreeView.Nodes.Count > 0)
            {
                TreeView.Nodes[0].Collapse();
                TreeView.Nodes[0].Expand();
            }
            TreeView.SelectedNode = null;
            SelectedItem = null;

        }
        private void _Tree(TreeView TR)
        {
            try
            {
                TreeNode TN = new TreeNode();

                if (dtTree.Rows.Count > 0)
                {
                    //TN.Text = "ریشه";                    
                    TreeNode[] Result = _ChildNodes(0);
                    foreach (var item in Result)
                    {
                        item.ContextMenuStrip = CMenu;
                        TR.Nodes.Add(item);
                    }
                }
                else
                {
                    DataRow dr = dtTree.NewRow();
                    dr[Code] = 0;
                    dr[Title] = JLanguages._Text("Empty");
                    dtTree.Rows.InsertAt(dr, 0);
                    TN.Text = JLanguages._Text("Empty");
                    TN.Tag = dtTree.Rows[0];
                    TN.ContextMenuStrip = CMenu;
                    TR.Nodes.Insert(0, TN);
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }

        }
        private TreeNode[] _ChildNodes(object code)
        {
           
                                   
            TreeNode[] Result = new TreeNode[0];
            try
            {
            DataView dv = new DataView();
            dv = dtTree.DefaultView;
     
            if (Convert.ToInt32(code) == 0)
            {
                dv.RowFilter = ParentCode + " IS NULL ";//or " + ParentCode + "=-1";
            }
            else
            {
                dv.RowFilter = ParentCode + " = '" + code + "'";
            }

            DataTable dbTmp = new DataTable();
            dbTmp = (dv.ToTable()).Copy();
            Array.Resize(ref Result, dbTmp.Rows.Count);

            for (int i = 0; i < dbTmp.Rows.Count; i++)
            {
                Result[i] = new TreeNode();
                Result[i].Text = dbTmp.Rows[i][Title].ToString();
                Result[i].Tag = dbTmp.Rows[i];
                TreeNode[] Child = _ChildNodes(dbTmp.Rows[i][Code]);
                foreach (var item in Child)
                {
                    item.ContextMenuStrip = CMenu;                    
                    Result[i].Nodes.Add(item);
                }
            }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            return Result;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectedItem = TreeView.SelectedNode;
            if (SelectedItemChange != null)
            {
                SelectedItemChange.BeginInvoke(sender, e, null, null);
            }
        }
        /// <summary>
        /// تعریف رویداد انتخاب نود جدید
        /// </summary>
        public event TreeViewEventHandler SelectedItemChange;
        /// <summary>
        /// find and expand node
        /// </summary>
        /// <param name="pCode"></param>
        public void FindAndExpandNode(int pCode)
        {
            if (TreeView != null && TreeView.Nodes != null && TreeView.Nodes.Count > 0)
            {
                _FindAndExpandNode(TreeView.Nodes[0],pCode.ToString());
            }
        }
        /// <summary>
        /// find and expand node
        /// </summary>
        /// <param name="pNode"></param>
        /// <param name="pCode"></param>
        private bool _FindAndExpandNode(TreeNode pNode,string pCode)
        {
            if (((DataRow)pNode.Tag)[Code].ToString() == pCode)
            {
                pNode.Expand();
                TreeView.SelectedNode = pNode;
                return true;
            }

            bool find = false;
            for (int i = 0; i < pNode.Nodes.Count; i++)
            {
                if (_FindAndExpandNode(pNode.Nodes[i], pCode))
                {
                    pNode.Nodes[i].Expand();
                    find = true;
                }
            }
            if (!find)
                pNode.Collapse();
            
            return find;
        }

        private void TreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                SelectedItem = e.Node;
                TreeView.SelectedNode = e.Node;
            }
        }

        private void TreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Node.ContextMenuStrip == null)
                {
                    return;
                }
                Point p = new Point(System.Windows.Forms.Control.MousePosition.X - e.Node.ContextMenuStrip.Size.Width, System.Windows.Forms.Control.MousePosition.Y);
                e.Node.ContextMenuStrip.Show(p);
                if (SelectedNodWithMouseDoubleClick != null)
                {
                    SelectedNodWithMouseDoubleClick.BeginInvoke(sender, e, null, null);
                }
            }
            catch(Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
        /// <summary>
        /// رویداد انتخاب یه نود با دوبار کلیک
        /// </summary>
        public event TreeNodeMouseClickEventHandler SelectedNodWithMouseDoubleClick;

        private bool _FindNodes(TreeNode N,string strSearch)
        {
            if (N == null)
                return false;

            bool find = false;
            if (((System.Data.DataRow)N.Tag)[Title].ToString().Contains(strSearch))
            {
                N.Expand();
                N.BackColor = Color.Bisque;
                find = true;
            }
            else
            {
                N.BackColor = Color.White;
            }

            for (int i = 0; i < N.Nodes.Count; i++)
            {
                if (_FindNodes(N.Nodes[i], strSearch))
                {
                    N.Nodes[i].Expand();
                    find = true;
                }
                else
                {
                    _FindNodes(N.Nodes[i], strSearch);   
                }
            }
            if (!find)
                N.Collapse();
            return find;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            if (TreeView.Nodes != null && TreeView.Nodes.Count > 0)
            {
                if (_FindNodes(TreeView.Nodes[0], txtSearch.Text))
                {
                    TreeView.Nodes[0].Expand();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (TreeView.Nodes != null && TreeView.Nodes.Count > 0)
            {
                if (_FindNodes(TreeView.Nodes[0], txtSearch.Text))
                {
                    TreeView.Nodes[0].Expand();
                }
            }
        }
        /// <summary>
        /// تنظیم چک های یه قسمت از درخت
        /// </summary>
        /// <param name="N">نود ریشه</param>
        /// <param name="Checked">چک بخورد یا برداشته شود</param>
        public void CheckNodes(TreeNode N,bool Checked)
        {
            if (N == null)
                return;

            N.Checked = Checked;
            for (int i = 0; i < N.Nodes.Count; i++)
            {
                CheckNodes(N.Nodes[i],Checked);
            }
            return;
        }
        /// <summary>
        /// نود های چک خورده را بر میگرداند
        /// </summary>
        /// <param name="N">نود شروع بررسی</param>
        /// <returns>ارایه ای از سطر ها</returns>
        public DataRow[] SelectedItems(TreeNode N)
        {
            if (N == null)
                return null;
            DataRow[] Items = new DataRow[0];

            if (N.Checked == true)
            {
                Array.Resize(ref Items, Items.Length + 1);
                Items[Items.Length - 1] = (DataRow)N.Tag;
            }
            for (int i = 0; i < N.Nodes.Count; i++)
            {
                DataRow[] tmp;
                tmp = SelectedItems(N.Nodes[i]);
                if (tmp != null)
                {                    
                    for (int j = 0; j < tmp.Length; j++)
                    {
                        Array.Resize(ref Items, Items.Length + 1);
                        Items[Items.Length - 1] = tmp[j];
                    }
                }
            }
            return Items;
        }

        private void TreeView_MouseClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("");
        }
    }
}
