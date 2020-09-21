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
    public partial class JPermissionSetForm : Globals.JBaseForm
    {
        int _UserPostCode;
        public JPermissionSetForm(int pUserPostCode)
        {
            InitializeComponent();
            _UserPostCode = pUserPostCode;
            Employment.JEOrganizationChart chart = new Employment.JEOrganizationChart(pUserPostCode);
            ListViewItem item = new ListViewItem(chart.UserName);
            item.Tag = chart.code;
            _UserPostCode = chart.code;
            listView1.Items.Add(item);
            //chart.full_title
        }

        private void _MakeClassTree()
        {
            treeClass.Nodes.Clear();
            JPermissionsDefineClass classList = new JPermissionsDefineClass();
            classList.GetData();
            //int i = 0;
            foreach (JPermissionDefineClass ds in classList.Items)
            {
                /// افزودن کلاس به درخت
                TreeNode classNode = new TreeNode(ds.ClassName);
                classNode.Tag = ds;
                if (ds.SQL.Trim() != "")
                {
                    classNode.BackColor = Color.Yellow;
                    treeClass.ShowNodeToolTips = true;
                    classNode.ToolTipText = ds.SQL;
                }
                treeClass.Nodes.Add(classNode);
                IDictionary<string, object> Dic = ds.GetObjectList();
                if (Dic!=null)
                    foreach (KeyValuePair<string, object> item in Dic)
                    {
                        TreeNode objectNode = new TreeNode(item.Value.ToString());
                        objectNode.Tag = item;
                        classNode.Nodes.Add(objectNode);
                    }
            }
        }


        private void JPermissionSetForm_Load(object sender, EventArgs e)
        {
            _MakeClassTree();
        }

        private void treeClass_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void treeClass_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                e.Node.Checked = !e.Node.Checked;
                e.Node.Parent.Checked = false;
                return;
            }
            foreach (TreeNode node in treeClass.Nodes)
            {
                if (node == e.Node)
                    continue;
                node.Checked = false;
                if (node.Nodes.Count > 0)
                    foreach (TreeNode objNode in node.Nodes)
                    {
                        objNode.Checked = false;
                    }
            }
            e.Node.Checked = !e.Node.Checked;
            if (e.Node.Nodes.Count > 0)
            {
                foreach (TreeNode node in e.Node.Nodes)
                {
                    node.Checked = e.Node.Checked;
                }                
            }
        }

        private void btnSetPermissions_Click(object sender, EventArgs e)
        {
            TreeNode SelectedNode=new TreeNode();
            foreach (TreeNode node in treeClass.Nodes)
            {
                if (node.Checked)
                    SelectedNode = node;
            }
            if (SelectedNode == null)
            { 

            }
            else
            { }
            //if (e.Node.Tag is JPermissionDefineClass)
            //{
            //    JPermissionEditForm editForm= new JPermissionEditForm((JPermissionDefineClass)e.Node.Tag, _UserPostCode);
            //    editForm.Text = e.Node.Text;
            //    editForm.ShowDialog();
            //}
            //else if (e.Node.Tag is KeyValuePair<string, object>)
            //{
            //    JPermissionEditForm editForm = new JPermissionEditForm((JPermissionDefineClass)e.Node.Parent.Tag, (KeyValuePair<string, object>)e.Node.Tag, _UserPostCode);
            //    editForm.Text = e.Node.Text;
            //    editForm.ShowDialog();
            //}
        }
    }
}
