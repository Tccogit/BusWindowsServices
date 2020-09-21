using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BusManagment.Personel
{
    public partial class JPersonelForm : JBaseForm
    {
        int _PCode;
        int _Code;
        Finance.JBankAccountControl accountControl = new Finance.JBankAccountControl();
        private ArchivedDocuments.JArchiveList jArchiveList1;

        public JPersonelForm()
        {
            InitializeComponent();
            State = ClassLibrary.JFormState.Insert;
            accountControl.Location = new Point(10, 70);
            tabPage1.Controls.Add(accountControl);
            accountControl.BringToFront();

            LoadDefault();
            LoadComboBox();
            LoadProperties();
        }

        private void LoadProperties()
        {
            // Configuring PropertyControl
            jPropertyValue.ClassName = "BusManagment.JPersonel";
            jPropertyValue.ObjectCode = 1;
            jPropertyValue.ValueObjectCode = _Code;
        }

        private void LoadComboBox()
        {
            JPersonel objAutoDefine = new JPersonel(_Code);
            JSpecificationTypes types = new JSpecificationTypes();
            types.SetComboBox(cmbSpecific, objAutoDefine.Specification);
            JEmploymentTypes empTypes = new JEmploymentTypes();
            empTypes.SetComboBox(cmbEmpType, objAutoDefine.EmployeeType);
            JCertificateTypes cerTypes = new JCertificateTypes();
            cerTypes.SetComboBox(cmbCertType, objAutoDefine.CertificateType);
        }

        public JPersonelForm(int pCode)
        {
            InitializeComponent();
            State = ClassLibrary.JFormState.Update;
            accountControl.Location = new Point(10, 70);
            JPersonel objAutoDefine = new JPersonel(pCode);
            _PCode = objAutoDefine.PersonCode;
            _Code = pCode;
            tabPage1.Controls.Add(accountControl);
            accountControl.BringToFront();
            LoadDefault();
            LoadComboBox();
            LoadData();
            LoadProperties();
        }

        private void LoadDefault()
        {
            jArchiveList1 = new ArchivedDocuments.JArchiveList();
            tabPage4.Controls.Add(jArchiveList1);
            jArchiveList1.Dock = DockStyle.Fill;
            jArchiveList1.ClassName = "BusManagment.Personel.JPersonel"; 
            
            cmbFleet.DataSource = Fleet.JFleets.GetDataTable(0);
            cmbFleet.DisplayMember = "Name";
            cmbFleet.ValueMember = "Code";
        }

        private bool Validate()
        {
            if(personControl.SelectedCode == 0)
            {
                JMessages.Error("لطفا شخص را انتخاب کنید", "");
                tabControl1.SelectedIndex = 0;
                return false;
            }
            return true;
        }

        private bool Save()
        {
            bool result = false;
            if (!Validate())
                return false;
            JPersonel objAutoDefine = new JPersonel(_Code);
            objAutoDefine.PersonCode = personControl.SelectedCode;
            objAutoDefine.PersonelCode = txtPersonelCode.Text;
            objAutoDefine.CertificateDate = txtCertDate.Date;
            objAutoDefine.CertificateExpirationDate = txtCertExpDate.Date;
            objAutoDefine.CertificateNumber = txtCertNumber.Text;
            if (cmbCertType.SelectedValue != null)
                objAutoDefine.CertificateType = Convert.ToInt32(cmbCertType.SelectedValue);
            if (cmbCertType.SelectedValue != null)
                objAutoDefine.EmployeeType = Convert.ToInt32(cmbEmpType.SelectedValue);
            if (cmbFleet.SelectedValue != null)
                objAutoDefine.FleetCode = Convert.ToInt32(cmbFleet.SelectedValue);
            if (cmbSpecific.SelectedValue != null)
                objAutoDefine.Specification = Convert.ToInt32(cmbSpecific.SelectedValue);

            if (State == ClassLibrary.JFormState.Insert)
            {
                _Code = objAutoDefine.Insert();
                result = _Code > 0;
                if (result)
                {
                    accountControl.PersonCode = objAutoDefine.PersonCode;
                    accountControl.Save();
                    State = ClassLibrary.JFormState.Update;
                }
            }
            else
                if (State == ClassLibrary.JFormState.Update)
                {
                    result = objAutoDefine.Update();
                    accountControl.PersonCode = objAutoDefine.PersonCode;
                    accountControl.Save();
                }
            if (jArchiveList1.ObjectCode == 0)
            {
                jArchiveList1.ObjectCode = _Code;
            }

            jArchiveList1.ArchiveList();
            if (result)
            {
                jPropertyValue.ValueObjectCode = _Code;
                jPropertyValue.Save();
            }
            return result;
        }

        public void LoadData()
        {
            accountControl.PersonCode = _PCode;
            accountControl.LoadData();
            personControl.SelectedCode = _PCode;
            JPersonel objAutoDefine = new JPersonel(_Code);
            personControl.SelectedCode = objAutoDefine.PersonCode;
            txtPersonelCode.Text = objAutoDefine.PersonelCode.ToString();
            txtCertNumber .Text = objAutoDefine.CertificateNumber;
            txtCertExpDate.Date = objAutoDefine.CertificateExpirationDate;
            txtCertDate.Date = objAutoDefine.CertificateDate;
            cmbFleet.SelectedValue = objAutoDefine.FleetCode;
            jArchiveList1.ObjectCode = _Code;

            personControl.Enabled = false;
            LoadContracts();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Save())
                Close();
        }

        private void JPersonelForm_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void LoadContracts()
        {
            grdContract.DataSource = JPersonelContracts.GetDataTable(_Code);
        }
        int _contractCode = 0;
        /// <summary>
        /// ذخیره مالک
        /// </summary>
        /// <returns></returns>
        private bool SaveContract()
        {
            bool result = false;
            if (txtPerson.Tag == null || (int)txtPerson.Tag == 0)
            {
                JMessages.Error("لطفا مالک را انتخاب کنید", "خطا");
                return false;
            }
            if (txtOwStartDate.Date == DateTime.MinValue)
            {
                JMessages.Error("لطفا تاریخ شروع را وارد کنید", "خطا");
                return false;
            }
            if (txtOwEndDate.Date != DateTime.MinValue && txtOwStartDate.Date > txtOwEndDate.Date)
            {
                JMessages.Error("لطفا تاریخ شروع و پایان را بصورت صحیح وارد کنید", "خطا");
                return false;
            }
            JPersonelContract contract = new JPersonelContract(_contractCode);
            contract.PCode = (int)txtPerson.Tag;
            contract.StartDate = txtOwStartDate.Date;
            contract.EndDate = txtOwEndDate.Date;
            contract.PersonelCode= _Code;
            if (_contractCode == 0)
            {
                result = contract.Insert() > 0;
            }
            else
            {
                result = contract.Update();
            }
            if (result) LoadContracts();
            btnAddOwner.Text = ClassLibrary.JLanguages._Text("Add");
            _contractCode = 0;
            return result;
        }

        private void btnAddOwner_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                if (SaveContract())
                {
                    txtPerson.Tag = 0;
                    txtPerson.Text = "";
                    txtOwStartDate.Text = "";
                    txtOwEndDate.Text = "";
                }
                else
                    JMessages.Error("عملیات ثبت با مشکل مواجه شده است", "خطا");
            }
        }

        private void btnEditOwner_Click(object sender, EventArgs e)
        {
            if (grdContract.SelectedRow != null)
            {
                _contractCode = Convert.ToInt32(grdContract.SelectedRow["Code"]);
                txtPerson.Text = grdContract.SelectedRow["OwnerName"].ToString();
                JPersonelContract owner = new JPersonelContract(_contractCode);
                txtPerson.Tag = owner.PCode;
                txtOwStartDate.Date = owner.StartDate;
                txtOwEndDate.Date = owner.EndDate;
                btnAddOwner.Text = ClassLibrary.JLanguages._Text("Save...");
            }
        }

        private void btnDeActiveOw_Click(object sender, EventArgs e)
        {
            if (grdContract.SelectedRow != null)
            {
                if (JMessages.Question("آیا می خواهید قرارداد انتخاب شده حذف شود؟", "حذف؟") == System.Windows.Forms.DialogResult.Yes)
                {
                    _contractCode = Convert.ToInt32(grdContract.SelectedRow["Code"]);
                    JPersonelContract owner = new JPersonelContract(_contractCode);
                    if (owner.Delete())
                        LoadContracts();
                    _contractCode = 0;
                }
            }
        }

        private void btnSearchOwner_Click(object sender, EventArgs e)
        {
            ClassLibrary.JFindPersonForm FindP = new ClassLibrary.JFindPersonForm();
            FindP.ShowDialog();
            if (FindP.SelectedPerson != null)
            {
                txtPerson.Text = FindP.SelectedPerson.Name;
                txtPerson.Tag = FindP.SelectedPersonCode;
            }
        }

        private void grdContract_OnRowDBClick(object Sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            btnEditOwner.PerformClick();
        }

        private void btnProperties_Click(object sender, EventArgs e)
        {
            Globals.Property.JDefinePropertyForm DefinePropertyForm = new Globals.Property.JDefinePropertyForm("BusManagment.JPersonel", 1);
            DefinePropertyForm.ShowDialog();
        }
    }
}
