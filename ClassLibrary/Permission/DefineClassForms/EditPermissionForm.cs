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
    public partial class JPermissionEditForm : Globals.JBaseForm
    {
        private JPermissionDefineClass _DefineClass;
        private KeyValuePair<string, object> _Object;

        public JPermissionEditForm(JPermissionDefineClass pDefineClass, int pUserPostCode)
        {
            InitializeComponent();
            _DefineClass = pDefineClass;
            _FillCheckBox();
        }

        public JPermissionEditForm(JPermissionDefineClass pDefineClass, KeyValuePair<string, object> pObject, int pUserPostCode)
        {
            InitializeComponent();
            _Object = pObject;
            _DefineClass = pDefineClass;
            _FillCheckBoxForObject();
        }


        private void _FillCheckBox()
        {
            treeView1.Nodes.Clear();
            JPermissionDecisions decisions = new JPermissionDecisions();
            decisions.GetData(_DefineClass.Code);
            foreach (JPermissionDecision decision in decisions.Items)
            {
                TreeNode decisionNode = new TreeNode(decision.Name);
                decisionNode.Tag = decision;
                decisionNode.Checked = true;
                /// افزودن هر کدام از تصمیمات به نود کلاس
                treeView1.Nodes.Add(decisionNode);
            }
        }

        private void _FillCheckBoxForObject()
        {
            treeView1.Nodes.Clear();
            JPermissionDecisions decisions = new JPermissionDecisions();
            decisions.GetData(_DefineClass.Code);
            foreach (JPermissionDecision decision in decisions.Items)
            {
                TreeNode decisionNode = new TreeNode(decision.Name);
                decisionNode.Tag = decision;
                decisionNode.Checked = true;
                /// افزودن هر کدام از تصمیمات به نود کلاس
                treeView1.Nodes.Add(decisionNode);
            }
        }
    }
}
