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
    public partial class JGroupSMSFrom : JBaseForm
    {
        DataTable _EmployeeList;
        int _GroupCode;

        public JGroupSMSFrom()
        {
            InitializeComponent();
            _GroupCode = -1;
        }

        public JGroupSMSFrom(int GroupCode)
        {
            InitializeComponent();
            _GroupCode = GroupCode;
            cmbGroup.Enabled = false;
        }

        private void JGroupSMSFrom_Load(object sender, EventArgs e)
        {
            JGroupSMSs JCCs = new JGroupSMSs();
            JCCs.SetComboBox(cmbGroup, _GroupCode);
            GetPattern();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            try
            {
                _EmployeeList = null;
                _EmployeeList = (DataTable)dgvEmployee.DataSource;
                if (Convert.ToInt32(cmbGroup.SelectedValue) == -1)
                {
                    JMessages.Error("گروه را انتخاب کنید", "error");
                    return;
                }
                JFindPersonForm JFPF = new JFindPersonForm(JPersonTypes.RealPerson, JTableNamesClassLibrary.PersonTable + ".Code IN (SELECT PCode From empcontract WHERE state = 1)");
                JFPF.MultiSelect = true;
                JFPF.ShowDialog();
                if (JFPF.SelectedPersonsCode.Length != 0)
                {
                    for (int i = 0; i < JFPF.SelectedPersonsCode.Length; i++)
                    {
                        if ((((_EmployeeList.Rows.Count > 0) && (_EmployeeList.Select("PersonCode=" + JFPF.SelectedPersonsCode[i].ToString()).Length < 1)) || (_EmployeeList.Rows.Count == 0)))
                        {
                            JAllPerson Person = new JAllPerson(JFPF.SelectedPersonsCode[i]);//JFPF.SelectedPersonCode
                            DataRow Row = _EmployeeList.NewRow();
                            //Row[JEmployeeCostCenterEnum.CostCenter.ToString()]=((JSubBaseDefine) cmbCostCenter.SelectedItem).Code;
                            Row["PersonCode"] = Person.Code;
                            //Row["Name"] = Person.Name;
                            Row["PersonName"] = Person.Name;
                            _EmployeeList.Rows.Add(Row);
                            //if (dgvEmployee == null)
                            //    dgvEmployee.DataSource = ECCs.EmployeeList;
                            //else
                            dgvEmployee.Refresh();
                        }
                        else
                            JMessages.Message("Person is Repeat", "", JMessageType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);

            }
        }

        private void btnDelPerson_Click(object sender, EventArgs e)
        {
            if (dgvEmployee.CurrentRow != null)
                dgvEmployee.Rows.Remove(dgvEmployee.CurrentRow);
            else
                JMessages.Error("لطفا یک سطر را انتخاب کنید", "error");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((dgvEmployee.Rows.Count == 0) && (State == JFormState.Insert))
            {
                JMessages.Error(" لطفا فردی را انتخاب کنید ", "");
                return;
            }
            if (cmbGroup.SelectedValue == null)
            {
                JMessages.Error("", "");
                return;
            }

            JGroupSMSEmployee tmpGroupSMSEmployee = new JGroupSMSEmployee();
            tmpGroupSMSEmployee.GroupCode = (int)cmbGroup.SelectedValue;
            if (tmpGroupSMSEmployee.Save(this.State, (DataTable)dgvEmployee.DataSource))
            {
                JMessages.Message("Insert Successfuly", "", JMessageType.Information);
                //Close();
            }
            else
                JMessages.Message("Insert Not Successfuly", "", JMessageType.Error);
        }

        private void GetPattern()
        {
            if (dgvEmployee.DataSource != null)
            {
                dgvEmployee.Columns["Code"].Visible = false;
                dgvEmployee.Columns["GroupCode"].Visible = false;
            }
        }

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvEmployee.DataSource = null;
            dgvEmployee.Refresh();
            if ((cmbGroup.SelectedValue != null) && (Convert.ToInt32(((System.Data.DataRowView)(cmbGroup.SelectedItem)).Row.ItemArray[0]) != -1))                
                dgvEmployee.DataSource = JGroupSMSEmployees.ListPersonByGroup(Convert.ToInt32(cmbGroup.SelectedValue));
            GetPattern();
        }

    }
}
