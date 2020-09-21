using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace ClassLibrary
{
    public partial class JTreeForm : JBaseForm
    {
        public JTree tree;
        public JTreeForm()
        {
            InitializeComponent();
        }
        public JTreeForm(JTree pTree)
        {
            InitializeComponent();
            tree = pTree;
            ArrangeTree();
        }

        public void ArrangeTree()
        {
            treeView1.Nodes.Clear();
            LoadNodes(); 
            treeView1.Refresh();
        }

        private void LoadNodes()
        {
            foreach (JTreeNode _tNode in tree.TreeNodes)
            {
                TreeNode node;
                if (_tNode.ParentCode == 0)
                {
                    node = treeView1.Nodes.Add(_tNode.ToString());
                    node.Tag = _tNode;
                    getChildren(node);
                }
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            JTreeNode newNode = new JTreeNode(tree);
            TreeNode node = new TreeNode();
            if (comboBox1.Text.Trim().Length == 0)
                return;
            newNode.Name = comboBox1.Text;
            newNode.ObjectCode = int.Parse(textBox1.Text);
            newNode.State = true;
            node.Text = newNode.ToString();

            int ParentCode = 0;
            int insertRes;
            if (treeView1.SelectedNode != null)
                ParentCode = ((JTreeNode)treeView1.SelectedNode.Tag).Code;
            insertRes = newNode.Insert(ParentCode);
            if (insertRes > 0)
            {
                treeView1.SelectedNode.Nodes.Add(node);
                treeView1.SelectedNode = node;
                newNode.Code = insertRes;
                node.Tag = newNode;
            }

            else if (insertRes == -1)
            {
                JMessages.Message("TheObjectIsAlreadyExistsInTheTree", "Error", JMessageType.Error);
            }
            treeView1.Focus();
        }


        private void getChildren(TreeNode node)
        {
            JTreeNode tNode = (JTreeNode)node.Tag;
            foreach (JTreeNode _tNode in tree.TreeNodes)
            {
                TreeNode Node;
                if (_tNode.ParentCode == tNode.Code)
                {
                    Node = node.Nodes.Add(_tNode.ToString());
                    Node.Tag = _tNode;
                    getChildren(Node);
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            JTreeNode node = (JTreeNode)treeView1.SelectedNode.Tag;
            if (node.Delete(node.Code,false)) 
                treeView1.SelectedNode.Remove();
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            treeView1.SelectedNode.BeginEdit();
        }

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label == null)
                return;
            JTreeNode node = (JTreeNode)treeView1.SelectedNode.Tag;
            node.Name = e.Label;
            node.Update();
        }
    }
}

     

 