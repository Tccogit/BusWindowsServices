using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime;
using ClassLibrary;

namespace ClassLibrary
{
    public partial class JPermissionLoadDLLForm : Globals.JBaseForm
    {
        public JPermissionLoadDLLForm()
        {
            InitializeComponent();
        }

        private void _FillComboBox()
        {
            //cmbAppList.SelectedValue = ClassLibrary.Domains.JApplication.JApplicationType.ClassLibrary;            
            //treeFunctions.Nodes.Add();
        }
        /// <summary>
        /// خواندن توابع از DLL
        /// </summary>
        private void _LoadFunctions()
        {
            try
            {
				lbPermission.DataSource = Permission.JPermissionDefineControls.GetData();
				lbPermission.DisplayMember = "PermissionName";
				lbPermission.ValueMember = "PermissionName";
				//DataTable dt = new DataTable();
				//dt = ClassLibrary.Domains.JApplication.JApplicationType.GetData();
				//foreach (DataRow row in dt.Rows)
				//{
				//	try
				//	{
				//		Assembly asm = Assembly.Load(row["name"].ToString());// cmbAppList.Text);
				//		Type[] types = asm.GetTypes();
				//		string[] _tmpStr;
				//		foreach (Type oType in types)
				//		{
				//			//if ((oType.BaseType.Name.ToString() == "JSystemNode"))  //(oType.BaseType.Name.ToString() == "JBaseForm") || 
				//			//{
				//			//    InitController(oType);
				//			//}
				//			//else
				//			{
				//				MethodInfo[] methods = oType.GetMethods();
				//				#region FillTree
				//				for (int j = 0; j < methods.Length; j++)
				//				{
				//					_tmpStr = methods[j].ToString().Split(' ');
				//					if (!methods[j].IsSpecialName)
				//					{
				//						string name = (methods[j]).DeclaringType.FullName + "." +
				//							methods[j].Name;
				//						string[] names = name.Split('.');
				//						string nameSpace = "";
				//						for (int i = 0; i < names.Length - 2; i++)
				//						{
				//							if (nameSpace.Length > 0)
				//								nameSpace = nameSpace + '.' + names[i];
				//							else
				//								nameSpace = names[i];
				//						}
				//						int nameSpaceIndex = treeFunctions.Nodes.IndexOfKey(nameSpace);
				//						if (nameSpaceIndex == -1)
				//						{
				//							TreeNode insertParent = treeFunctions.Nodes.Add(nameSpace, nameSpace);
				//							TreeNode insertNode = insertParent.Nodes.Add(names[names.Length - 2], names[names.Length - 2]);
				//							insertNode.Nodes.Add(names[names.Length - 1], names[names.Length - 1]);
				//						}
				//						else
				//						{
				//							int secondNodeIndex = treeFunctions.Nodes[nameSpace].Nodes.IndexOfKey(names[names.Length - 2]);
				//							if (secondNodeIndex == -1)
				//							{
				//								TreeNode insertParent = treeFunctions.Nodes[nameSpace].Nodes.Add(names[names.Length - 2], names[names.Length - 2]);
				//								insertParent.Nodes.Add(names[names.Length - 1], names[names.Length - 1]);
				//							}
				//							else
				//							{
				//								int firstNodeIndex = treeFunctions.Nodes[nameSpace].Nodes[secondNodeIndex].Nodes.IndexOfKey(names[names.Length - 1]);
				//								if (firstNodeIndex == -1)
				//								{
				//									TreeNode insertParent = treeFunctions.Nodes[nameSpace].Nodes[secondNodeIndex].Nodes.Add(names[names.Length - 1], names[names.Length - 1]);
				//								}

				//							}
				//						}

				//					}
				//				}
				//				#endregion
				//			}
				//		}
				//	}
				//	catch(Exception ex)
				//	{
				//	}
				//}
				//treeFunctions.Sort();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        /// <summary>
        /// بازیابی تصمیمات از قبل ذخیره شده
        /// </summary>
        private void _LoadSavedDecision()
        {
            listView1.Items.Clear();
            int [] decisions=JPermissionControl.GetDecisions(txtFunctionName.Text);
            foreach (int dec in decisions)
            {
                JPermissionDecision decision = new JPermissionDecision();
                decision.GetData(dec);

                foreach (TreeNode tn in treeClass.Nodes)
                {
                    if (decision.ClassName.ToString() == ((JPermissionDefineClass)tn.Tag).ClassName)
                    {
                        for (int i = 0; i < tn.Nodes.Count; i++)
                        {
                            if (decision.Name == tn.Nodes[i].Text)
                                treeClass.SelectedNode = tn.Nodes[i];    
                        }
                    }
                }

				ListViewItem item = new ListViewItem(decision.ClassName+"."+decision.Name);
                item.Tag = decision.Code;
                listView1.Items.Add(item);
            }
        }

        private void JPermissionLoadDLLForm_Load(object sender, EventArgs e)
        {
            cmbGroup.DisplayMember = "FarsiName";
            cmbGroup.ValueMember = "value";
            cmbGroup.DataSource = ClassLibrary.Domains.JApplication.JApplicationType.GetData();
            cmbGroup.SelectedValue = ClassLibrary.Domains.JApplication.JApplicationType.Automation;

            _LoadFunctions();
            _MakeDecisionTree();
        }

        private void treeFunctions_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            txtFunctionName.Text = _GetParents(e.Node);
            _LoadSavedDecision();
        }
        private string _GetParents(TreeNode pNode)
        {
            if (pNode.Parent == null)
                return pNode.Name;
            else
                return _GetParents(pNode.Parent) + "." + pNode.Name;
        }

        private void _MakeDecisionTree()
        {
            treeClass.Nodes.Clear();
            JPermissionsDefineClass classList = new JPermissionsDefineClass();
            classList.GetData(Convert.ToInt32(cmbGroup.SelectedValue), 0);
            int i = 0;
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
                JPermissionDecisions decisions = new JPermissionDecisions();
                decisions.GetData(ds.Code);
                foreach (JPermissionDecision decision in decisions.Items)
                {
                    TreeNode decisionNode = new TreeNode(decision.Name);
                    decisionNode.Tag = decision;
                    /// افزودن هر کدام از تصمیمات به نود کلاس
                    treeClass.Nodes[i].Nodes.Add(decisionNode);
                }
                i++;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (treeClass.SelectedNode == null || lbPermission.SelectedValue == null)
                return;
            if (!(treeClass.SelectedNode.Tag is JPermissionDecision))
                return;
            if (txtFunctionName.Text == "")
                return;
            JPermissionControl control = new JPermissionControl();
            control.Class_Name = txtFunctionName.Text;
            control.Class_Code = ((JPermissionDecision)treeClass.SelectedNode.Tag).PermissionDefineCode;
            control.Decision_Code = ((JPermissionDecision)treeClass.SelectedNode.Tag).Code;
            if (control.Insert() > 0)
            {
                ListViewItem item = new ListViewItem(((JPermissionDecision)treeClass.SelectedNode.Tag).Name);
                item.Tag = ((JPermissionDecision)treeClass.SelectedNode.Tag).Code;
                listView1.Items.Add(item);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            JPermissionControl control= new JPermissionControl();
            if (control.Delete(txtFunctionName.Text, (int)listView1.SelectedItems[0].Tag))
                listView1.SelectedItems[0].Remove();
        }

        private void treeClass_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
				if (treeClass.SelectedNode == null || lbPermission.SelectedValue == null)
                    return;
                if (!(treeClass.SelectedNode.Tag is JPermissionDecision))
                    return;
                JPermissionControl control = new JPermissionControl();
                control.Class_Code = ((JPermissionDecision)treeClass.SelectedNode.Tag).PermissionDefineCode;
                control.Decision_Code = ((JPermissionDecision)treeClass.SelectedNode.Tag).Code;
                foreach (DataRow dr in control.FindClassName().Rows)
                {
                    TreeView t = new TreeView();
                    string[] str = dr["Class_Name"].ToString().Split('.');
					lbPermission.SelectedItem = str;
                }
            }
            catch (Exception ex)
            {
            }
            //btnAdd.PerformClick();
        }

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGroup.SelectedValue != null)
                _MakeDecisionTree();
        }

		private void lbPermission_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtFunctionName.Text = lbPermission.SelectedValue.ToString() ;
			_LoadSavedDecision();

		}        
    }
}