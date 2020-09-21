using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Data;

namespace ClassLibrary
{
    public partial class JConnectionForm : JBaseForm
    {
        private int _Code;
        DataTable _dtConnection;
        private string _ClassName="";

        public JConnectionForm()
        {
            InitializeComponent();
            _Code = 0;            
            _LoadFunctions();
        }

        public JConnectionForm(int pCode)
        {
            InitializeComponent();
            _Code = pCode;
            SetForm();
            cmbDataBaseType.Items.AddRange(JMainFrame.EnumToListBox(Type.GetType("ClassLibrary.JDataBaseType")));
        }      

        private void GetPattern()
        {
            _dtConnection = JConnections.GetDataTable(_Code);
            jdgvConnection.DataSource = _dtConnection;
            //RemoveColumn();
        }

        private void SetForm()
        {
            _dtConnection = JConnections.GetDataTable(_Code);
            jdgvConnection.DataSource = _dtConnection;
        }

        private void Refresh()
        {
            _dtConnection = JConnections.GetDataTable(0);
            jdgvConnection.DataSource = _dtConnection;
        }

        /// <summary>
        /// خواندن توابع از DLL
        /// </summary>
        private void _LoadFunctions()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = ClassLibrary.Domains.JApplication.JApplicationType.GetData();
                foreach (DataRow row in dt.Rows)
                {
                    Assembly asm = Assembly.Load(row["name"].ToString());// cmbAppList.Text);
                    Type[] types = asm.GetTypes();
                    string[] _tmpStr;
                    foreach (Type oType in types)
                    {
                        //if ((oType.BaseType.Name.ToString() == "JSystemNode"))  //(oType.BaseType.Name.ToString() == "JBaseForm") || 
                        //{
                        //    InitController(oType);
                        //}
                        //else
                        {
                            MethodInfo[] methods = oType.GetMethods();
                            #region FillTree
                            for (int j = 0; j < methods.Length; j++)
                            {
                                _tmpStr = methods[j].ToString().Split(' ');
                                if (!methods[j].IsSpecialName)
                                {
                                    string name = (methods[j]).DeclaringType.FullName + "." +
                                        methods[j].Name;
                                    string[] names = name.Split('.');
                                    string nameSpace = "";
                                    for (int i = 0; i < names.Length - 2; i++)
                                    {
                                        if (nameSpace.Length > 0)
                                            nameSpace = nameSpace + '.' + names[i];
                                        else
                                            nameSpace = names[i];
                                    }
                                    int nameSpaceIndex = treeFunctions.Nodes.IndexOfKey(nameSpace);
                                    if (nameSpaceIndex == -1)
                                    {
                                        TreeNode insertParent = treeFunctions.Nodes.Add(nameSpace, nameSpace);
                                        TreeNode insertNode = insertParent.Nodes.Add(names[names.Length - 2], names[names.Length - 2]);
                                        insertNode.Nodes.Add(names[names.Length - 1], names[names.Length - 1]);
                                    }
                                    else
                                    {
                                        int secondNodeIndex = treeFunctions.Nodes[nameSpace].Nodes.IndexOfKey(names[names.Length - 2]);
                                        if (secondNodeIndex == -1)
                                        {
                                            TreeNode insertParent = treeFunctions.Nodes[nameSpace].Nodes.Add(names[names.Length - 2], names[names.Length - 2]);
                                            insertParent.Nodes.Add(names[names.Length - 1], names[names.Length - 1]);
                                        }
                                        else
                                        {
                                            int firstNodeIndex = treeFunctions.Nodes[nameSpace].Nodes[secondNodeIndex].Nodes.IndexOfKey(names[names.Length - 1]);
                                            if (firstNodeIndex == -1)
                                            {
                                                TreeNode insertParent = treeFunctions.Nodes[nameSpace].Nodes[secondNodeIndex].Nodes.Add(names[names.Length - 1], names[names.Length - 1]);
                                            }

                                        }
                                    }

                                }
                            }
                            #endregion
                        }
                    }
                }
                treeFunctions.Sort();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //if (Save())
                Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                Refresh();
                //btnSave.Enabled = false;
                this.State = JFormState.Update;
            }
        }

        private bool Save()
        {
            #region CheckControl
            if (txtObjectCode.Text == "")
            {
                JMessages.Error("کد را وارد است", "error");
                return false;
            }
            if (txtPassword.Text == "")
            {
                JMessages.Error("رمز را وارد است", "error");
                return false;
            }
            if (txtServerName.Text == "")
            {
                JMessages.Error("نام سرور را وارد است", "error");
                return false;
            }
            if (txtUserName.Text == "")
            {
                JMessages.Error("نام کاربری را وارد است", "error");
                return false;
            }
            if (txtDataBase.Text == "")
            {
                JMessages.Error("نام بانک را وارد کنید", "error");
                return false;
            }
            if (_ClassName == "")
            {
                JMessages.Error("کلاس را وارد کنید", "error");
                return false;
            }
            if (cmbDataBaseType.SelectedIndex >=0 )
            {
            }
            #endregion

            JConnection tmpJConnection = new JConnection();
            tmpJConnection.Code = _Code;
            tmpJConnection.ObjectCode = Convert.ToInt32(txtObjectCode.Text);
            tmpJConnection.ServerName = txtServerName.Text;
            tmpJConnection.DataBaseName = txtDataBase.Text;
            tmpJConnection.UserName = txtUserName.Text;
            tmpJConnection.Password = txtPassword.Text;
            tmpJConnection.ClassName = _ClassName;
            //---------ویرایش------------
            if (State != JFormState.Update)
            {

                //----------Update Archive------------
                _Code = tmpJConnection.Insert();
                if (_Code > 0)
                {                   
                    JMessages.Message("Insert Successfuly ", "", JMessageType.Information);
                    return true;
                }
                else
                    JMessages.Message("Insert Not Successfuly ", "", JMessageType.Information);
            }
            else
            {
                tmpJConnection.Code = _Code;
                if (tmpJConnection.Update())
                {
                    JMessages.Message("Update Successfuly ", "", JMessageType.Information);
                    return true;
                }
                else
                    JMessages.Message(" Update Not Successfuly ", "", JMessageType.Error);
            }
            return true;
        }

        private void JConnectionForm_Load(object sender, EventArgs e)
        {
            _LoadFunctions();
            GetPattern();
        }

        private void treeFunctions_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            _ClassName = _GetParents(e.Node);
            //_ClassName = e.Node.Text;
        }

        private string _GetParents(TreeNode pNode)
        {
            if (pNode.Parent == null)
                return pNode.Name;
            else
                return _GetParents(pNode.Parent) + "." + pNode.Name;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvConnection.CurrentRow != null)
                {
                    JConnection tmpJConnection = new JConnection();
                    tmpJConnection.Code = Convert.ToInt32(jdgvConnection.CurrentRow.Cells[0].Value);
                    if (tmpJConnection.Delete())
                    {
                        Refresh();
                        JMessages.Message("Update Successfuly ", "", JMessageType.Information);
                    }
                    else
                        JMessages.Message(" Update Not Successfuly ", "", JMessageType.Error);
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
    }
}
