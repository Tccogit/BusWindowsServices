using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using BusManagment.Bus;

namespace BusManagment.Driver
{
    public partial class DriverForm : ClassLibrary.JBaseForm
    {
        private int Code;
        public DriverForm()
        {
            InitializeComponent();
            State = ClassLibrary.JFormState.Insert;
            Set_Default();
        }

        public DriverForm(int PCode)
        {
            InitializeComponent();
            Code = PCode;
            State = ClassLibrary.JFormState.Update;
            Set_Default();
            Load1(PCode);
        }

        private void Load1(int Code)
        {
            JDriver Auto = new JDriver();
            Auto.GetData(Code);
            //txtEmploymentCode.Text = Auto.EmploymentCode.ToString();
            txtCertDate.Date = Auto.CertificateDate;
            txtCertExpDate.Date = Auto.CertificateExpirationDate;
            txtCertNumber.Text = Auto.CertificateNumber;
            cmbCertType.SelectedValue = Auto.CertificateType;
            txtName.Tag = Auto.PersonCode;
            txtName.Text = ClassLibrary.JAllPerson.GetName(Auto.PersonCode);
        }


        public void Set_Default() {
            jJanusGridOwner.DataSource = JBusOwners.GetDataTable(Code);

            (new Personel.JCertificateTypes()).SetComboBox(cmbCertType);
        }

        private void SetData(JDriver Auto)
        {
            Auto.Code = Code;
            Auto.CertificateDate = txtCertDate.Date;
            //Auto.EmploymentCode = txtEmploymentCode.Text;
            Auto.CertificateExpirationDate = txtCertExpDate.Date;
            Auto.CertificateNumber = txtCertNumber.Text;
            if (cmbCertType.SelectedValue != null)
                Auto.CertificateType = (int)cmbCertType.SelectedValue;
            Auto.PersonCode = (int)txtName.Tag;
        }

        private void SaveOwner()
        {
            DataTable DT = (DataTable)jJanusGridOwner.DataSource;
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                DataRow DR = DT.Rows[i];
                JOwnerTable OwnerTable = new JOwnerTable();
                if (DR.RowState == DataRowState.Added)
                {
                    JOwnerTable.SetToClassField(OwnerTable, DR);
                    DR["Code"] = OwnerTable.Insert();
                }
                else
                    if (DR.RowState == DataRowState.Deleted)
                    {
                        DR.RejectChanges();
                        JOwnerTable.SetToClassField(OwnerTable, DR);
                        OwnerTable.Delete();
                        DR.Delete();
                    }
                    else
                        if (DR.RowState == DataRowState.Modified)
                        {
                            JOwnerTable.SetToClassField(OwnerTable, DR);
                            OwnerTable.Update();
                        }

                DR.AcceptChanges();
            }
        }

        private int Save()
        {
            JDriver objDriver = new JDriver();
            SetData(objDriver);
            if (State == ClassLibrary.JFormState.Insert)
                Code = objDriver.Insert();
            else
                if (State == ClassLibrary.JFormState.Update)
                    objDriver.Update();
            State = JFormState.Update;
            SaveOwner();
            return Code;
        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DriverForm_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Save();
            Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSelectPerson_Click(object sender, EventArgs e)
        {
            ClassLibrary.JFindPersonForm FindP = new ClassLibrary.JFindPersonForm();
            FindP.ShowDialog();
            if (FindP.SelectedPerson == null)
            {
                JMessages.Message("شخصی پیدا نشد", "", JMessageType.Error);
            }
            else
            {
                txtName.Text = FindP.SelectedPerson.Name;
                txtName.Tag = FindP.SelectedPersonCode;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void Set_Owner()
        {
            DataTable DT = new DataTable();
            DataRow DR = DT.NewRow();
            DR["code"] = 0;
            DR["BusCode"] = Code;
            DR["PersonCode"] = txtOwner.Tag;
            DR["Name"] = txtOwner.Text;
            DR["StartDate"] = OwStartDate.Date;
            DR["EndDate"] = OwEndDate.Date;
            DR["Active"] = true;
            DT.Rows.Add(DR);
        }

       
        private void btnActiveOw_Click(object sender, EventArgs e)
        {
            if (txtOwner.Text.Length > 0)
            {
                Set_Owner();
                txtOwner.Text = "";
                txtOwner.Tag = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClassLibrary.JFindPersonForm FindP = new ClassLibrary.JFindPersonForm();
            FindP.ShowDialog();
            if (FindP.SelectedPerson != null)
            {
                JMessages.Message("شخصی پیدا نشد", "", JMessageType.Error);
            }
            else {
                txtOwner.Text = FindP.SelectedPerson.Name;
                txtOwner.Tag = FindP.SelectedPersonCode;
            }
        }

        private void btnDeActiveOw_Click(object sender, EventArgs e)
        {
            if (jJanusGridOwner.SelectedRow != null)
            {
                jJanusGridOwner.SelectedRow.Delete();
            }
        } 

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}