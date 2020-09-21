using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary.Controllers
{
    public partial class JCustomTreeView : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NameCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NameParent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NameTitle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TreeView TreeView = new TreeView();
        /// <summary>
        /// 
        /// </summary>
        private string _Pattern;
        /// <summary>
        /// 
        /// </summary>
        public string Pattern
        {
            get
            {
                return _Pattern;
            }
            set
            {
                _Pattern = value;

            }
        }
        public int DefaultCode
        {
            get;
            set;
        }
        public bool AutoIncrement
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public IDictionary<string, object> FieldsValue;
        /// <summary>
        /// 
        /// </summary>
        private JCustomTree _customTree;

        public JCustomTreeView()
        {
            InitializeComponent();
            TreeView.Parent = this;
            TreeView.Dock = DockStyle.Fill;
            TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(AfterSelect);
        }

        private void AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                JCustomTreeNode CurrentNode = (JCustomTreeNode)e.Node.Tag;
                FieldsValue.Clear();
                foreach (KeyValuePair<string, object> Param in CurrentNode.FieldsValue)
                    FieldsValue.Add(Param);
            }
        }

        public bool Delete(bool DeleteChildren)
        {
            if (JPermission.CheckPermission("ClassLibrary.Controllers.JCustomTreeView.Delete"))
            {

                if (_customTree.Delete(int.Parse(FieldsValue[NameCode].ToString()), DeleteChildren))
                {
                    TreeView.SelectedNode.Remove();
                    return true;
                }
                return false;
            }
            else
                return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TreeNode Update()
        {
            if (JPermission.CheckPermission("ClassLibrary.Controllers.JCustomTreeView.Update"))
            {
                JCustomTreeNode node = _customTree.Update(FieldsValue);
                if (node != null)
                {
                    TreeNode treeNode = new TreeNode(node.ToString());
                    treeNode.Tag = node;
                    //TreeView.SelectedNode.Name = ((JCustomTreeNode)TreeView.SelectedNode.Tag).ToString();
                    return treeNode;
                }
                return null;
            }
            else
                return null;
        }

        public TreeNode Insert()
        {
            if (JPermission.CheckPermission("ClassLibrary.Controllers.JCustomTreeView.Insert"))
            {
                _customTree.AutoIncrement = AutoIncrement;
                _customTree.DefaultCode = DefaultCode;
                JCustomTreeNode node = _customTree.Insert(FieldsValue);
                if (node != null)
                {
                    TreeNode treeNode = new TreeNode(node.ToString());
                    treeNode.Tag = node;
                    if (TreeView.SelectedNode != null)
                        TreeView.SelectedNode.Nodes.Add(treeNode);
                    else
                        TreeView.Nodes.Add(treeNode);
                    return treeNode;
                }
                else
                    return null;
            }
            else
                return null;
        }

        public void Refresh()
        {
            if (NameCode.Length > 0 && NameTitle.Length > 0 && NameParent.Length > 0 && TableName.Length > 0)
            {
                _customTree = new JCustomTree(TableName, NameCode, NameTitle, NameParent);
                _customTree.Pattern = Pattern;
                _LoadTreeView(0, null);
            }
        }

        private void _LoadTreeView(int pParentCode, TreeNode pTN)
        {
            if (pParentCode == 0)
                TreeView.Nodes.Clear();
            FieldsValue = _customTree.FieldsValue;
            JCustomTreeNode[] CTNs = _customTree.GetChilds(pParentCode);
            try
            {
                foreach (JCustomTreeNode CTN in CTNs)
                {
                    TreeNode T;
                    if (CTN.ParentCode == 0)
                    {
                        T = new TreeNode(CTN.Code.ToString());
                        T = TreeView.Nodes.Add(CTN.Code.ToString(), CTN.ToString());
                        T.Tag = CTN;
                    }
                    else
                    {
                        T = new TreeNode(CTN.ToString());
                        T.Name = CTN.Code.ToString();
                        T.Tag = CTN;
                        pTN.Nodes.Add(T);
                    }
                    _LoadTreeView(CTN.Code, T);
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                _customTree.Dispose();
            }
        }
    }
}

