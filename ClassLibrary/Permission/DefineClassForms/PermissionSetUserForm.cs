using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Globals;

namespace ClassLibrary
{
    public partial class JPermissionSetUserForm : JBaseForm
    {
        private int _UserPostCode;
        private int _UserCode;
        private int _ObjectCode = 0;
        public JPermissionSetUserForm(int pUserCode)
        {
            _UserCode = pUserCode;
            InitializeComponent();

            JPermissionsDefineClass Per = new JPermissionsDefineClass();
            Per.GetData();
            DefineClassListBox.Items.AddRange(Per.Items);

            JUser User = new JUser(pUserCode);
            lbUserName.Text = User.username;

            Employment.JEOrganizationChart chart = new Employment.JEOrganizationChart();
            comboBoxPost.DisplayMember = "Job";
            comboBoxPost.ValueMember = "Code";
            comboBoxPost.DataSource = chart.GetUserPostsByUser_code(pUserCode);
        }

        public void SetUsers(int pCode)
        {
            _UserCode = pCode;
        }

        private void DefineClasslistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DecissionlistBox.Items.Clear();
                ObjectlistBox.Items.Clear();
                _ObjectCode = 0;
                JPermissionDefineClass PerDefine = (JPermissionDefineClass)DefineClassListBox.SelectedItem;
                if (PerDefine != null)
                {
                    if (PerDefine.SQL.Length < 1)
                    {
                        GetDecision();
                    }
                    else
                    {
                        IDictionary<string, object> Objs = PerDefine.GetObjectList();
                        foreach (KeyValuePair<string, object> Obj in Objs)
                        {
                            ObjectlistBox.Items.Add(Obj);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Except.AddException(ex);
            }
        }

        private void ObjectlistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ObjectlistBox.SelectedItems.Count == 1)
            {
                if (ObjectlistBox.SelectedItem != null)
                {
                    _ObjectCode = Int32.Parse(((KeyValuePair<string, object>)ObjectlistBox.SelectedItem).Key);
                    GetDecision();
                }
            }
        }

        private void GetDecision()
        {
            if (DefineClassListBox.SelectedItems.Count > 0)
            {
                DecissionlistBox.Items.Clear();
                DataTable DT = JPermissionDecisions.GetDataTable(((JPermissionDefineClass)DefineClassListBox.SelectedItem).Code);
                if (DT.Rows.Count > 0)
                {
                    foreach (DataRow DR in DT.Rows)
                    {
                        JPermissionDecision PD = new JPermissionDecision();
                        JTable.SetToClassProperty(PD, DR);
                        int index = DecissionlistBox.Items.Add(PD);
                    }
                }
            }
        }

        private void Insertbutton_Click(object sender, EventArgs e)
        {
            if (DefineClassListBox.SelectedIndex >= 0 && DecissionlistBox.SelectedIndex >= 0)
            {
                JPermissionDefineClass PDC = (JPermissionDefineClass)DefineClassListBox.SelectedItem;
                foreach (object Item in DecissionlistBox.SelectedItems)
                {
                    JPermissionDecision PD = (JPermissionDecision)Item;

                    KeyValuePair<string, object>[] Objs;
                    if (ObjectlistBox.SelectedItems.Count > 0)
                    {
                        Objs = new KeyValuePair<string, object>[ObjectlistBox.SelectedItems.Count];
                    }
                    else
                    {
                        Objs = new KeyValuePair<string, object>[1] { new KeyValuePair<string, object>("", 0) };
                    }
                    if (ObjectlistBox.Enabled)
                    {
                        int _count = 0;
                        foreach (object sItem in ObjectlistBox.SelectedItems)
                        {
                            {
                                Objs[_count++] = (KeyValuePair<string, object>)sItem;
                            }
                        }
                    }
                    JPermissionUser PU = new JPermissionUser();
                    PU.User_Post_Code = _UserPostCode;
                    foreach (KeyValuePair<string, object> Obj in Objs)
                    {
                        if (Obj.Key != "")
                            PU.ObjectCode = Int32.Parse(Obj.Key);
                        PU.DecisionCode = PD.Code;
                        PU.HasPermission = true;
                        if (PU.Check())
                        {
                            int Code = PU.Insert();
                            if (Code > 0)
                            {
                                PermissionUserlistBox.Items.Add(PU);
                            }
                        }
                    }
                }
            }
        }

        private void Deletebutton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < PermissionUserlistBox.SelectedItems.Count; i++)
            {
                JPermissionUser PU = (JPermissionUser)PermissionUserlistBox.SelectedItems[i];
                if (PU != null)
                {
                    if (PU.delete())
                    {
                        PermissionUserlistBox.Items.Remove(PU);
                        i--;
                    }
                }
            }
        }

        private void Okbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DecissionlistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ObjectlistBox.SelectedItem != null)
            {
                _ObjectCode = Int32.Parse(((KeyValuePair<string, object>)ObjectlistBox.SelectedItem).Key);
            }
        }

        private void comboBoxPost_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPost.SelectedItem != null)
            {
                _UserPostCode = Convert.ToInt32(((DataRowView)(comboBoxPost.SelectedItem))["Code"]);
                JPermissionsUser PerUser = new JPermissionsUser(_UserPostCode);
                PerUser.GetData();
                PermissionUserlistBox.Items.AddRange(PerUser.Items);
            }
        }

        private void checkBoxNone_CheckedChanged(object sender, EventArgs e)
        {
            ObjectlistBox.ClearSelected();
            if (checkBoxNone.Checked)
            {
                _ObjectCode = 0;
                GetDecision();
                ObjectlistBox.Enabled = false;
            }
            else
            {
                ObjectlistBox.Enabled = true;
            }

        }

        private void checkBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int Count = 0; Count < ObjectlistBox.Items.Count; Count++)
            {
                ObjectlistBox.SetSelected(Count, checkBoxAll.Checked);
            }

        }

        private void JPermissionSetUserForm_Load(object sender, EventArgs e)
        {
            //  ---------------------- Set ComboBox Group --------------------------
            cmbGroup.DisplayMember = "FarsiName";
            cmbGroup.ValueMember = "value";
            
            cmbGroup.DataSource = ClassLibrary.Domains.JApplication.JApplicationType.GetData();
            cmbGroup.SelectedValue = ClassLibrary.Domains.JApplication.JApplicationType.Automation;
        }

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            DefineClassListBox.Items.Clear();
            JPermissionsDefineClass Per = new JPermissionsDefineClass();
            Per.GetData(Convert.ToInt32(cmbGroup.SelectedValue), 0);
            DefineClassListBox.Items.AddRange(Per.Items);
        }

        private void txtFindObj_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < ObjectlistBox.Items.Count; i++)
            {
                if (ObjectlistBox.Items[i].ToString().IndexOf(txtFindObj.Text) > 0)
                    ObjectlistBox.SetSelected(i, true);
                else
                    ObjectlistBox.SetSelected(i, false);
            }
        }
    }
}
