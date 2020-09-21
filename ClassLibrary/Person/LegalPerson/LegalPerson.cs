using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ArchivedDocuments;
using Finance;

namespace ClassLibrary
{
    public partial class JLegalPerson : ClassLibrary.JBaseForm
    {
        private JOrganization _organ;
        public JLegalPerson()
        {
            InitializeComponent();
            _organ = new JOrganization();
            _organ.SignatureMen = JSignatureMen.LoadSignatureMen(0);
            /// مقداردهی متغیرهای آرم شرکت
            imgLogo.ClassName = _organ.GetType().FullName;
            imgLogo.SubjectCode = JConstantArchiveSubjects.LegalPersonArm.GetHashCode();
            imgLogo.AutoChange = false;
            ///
            /// مقداردهی پراپرتی های لیست آرشیو
            ArchiveListPerson.ClassName = (new JOrganization()).GetType().FullName;
            ArchiveListPerson.SubjectCode = JConstantArchiveSubjects.OtherImagesArchiveCode.GetHashCode();
            ArchiveListPerson.PlaceCode = JConstantArchivePalces.GeneralArchive.GetHashCode();
            ///
            _BindGrid();            
            _FillComboBoxes();
            ShowSharePCode();
            tabControl2.TabPages.Remove(tabAssets);
        }

        public JLegalPerson(JOrganization pOrgan)
        {
            InitializeComponent();
            _organ = pOrgan;            
            InitialForm();
        }

        public void ShowSharePCode()
        {
            if (JPermission.CheckPermission("ClassLibrary.JPersonIn.ShowSharePCode", 0, JMainFrame.CurrentPostCode, false))
            {
                pnlSharePCode.Visible = true;
                if (_organ.Code == 0)
					txtSharePCode.Text = "0";// (JPersons.GetMaxSharePCode() + 1).ToString();
            }
        }
        private void InitialForm()
        {
            _FillComboBoxes();
            /// مقداردهی متغیرهای آرم شرکت
            imgLogo.ClassName = _organ.GetType().FullName;
            imgLogo.SubjectCode = JConstantArchiveSubjects.LegalPersonArm.GetHashCode();
            imgLogo.PlaceCode = JConstantArchivePalces.GeneralArchive.GetHashCode();
            imgLogo.ObjectCode = _organ.Code;
            imgLogo.ArchiveCode = _organ.ArmArchiveCode;
            imgLogo.AutoChange = false;
            ///
            /// مقداردهی پراپرتی های لیست آرشیو
            ArchiveListPerson.ClassName = _organ.GetType().FullName;
            ArchiveListPerson.ObjectCode = _organ.Code;
            ArchiveListPerson.SubjectCode = JConstantArchiveSubjects.OtherImagesArchiveCode.GetHashCode();
            ///
            _ShowData();
            tabControl2.TabPages.Remove(tabAssets);
            tabControl2.TabPages.Remove(tabContract);
            ShowAssetTab();
            ShowSharePCode();
            if (JPermission.CheckPermission("Legal.JGeneralContract.ShowForms", false))
                tabControl2.TabPages.Add(tabContract);

            properties.ClassName = "ClassLibrary.JLegalPerson";
            properties.ObjectCode = 1;
            CheckChangeDesc();
        }

        private void _FillComboBoxes()
        {
            try
            {
                JCities cities = new JCities();
                JSubBaseDefine nullDeff = new JSubBaseDefine(0);
                nullDeff.Code = -1;
                nullDeff.Name = "-----------";

                cmbLocationRegister.BaseCode = JBaseDefine.CityCode;
                cmbCity.BaseCode = JBaseDefine.CityCode;
                cmbType.BaseCode = JBaseDefine.CompanyTypes;

                /// محل ثبت
                //cmbLocationRegister.Items.Clear();
                //cmbLocationRegister.Items.Add(nullDeff);
                //cmbLocationRegister.SelectedItem = nullDeff;
                cities.SetComboBox(cmbLocationRegister, _organ.RegisterPlace);
                //foreach (JSubBaseDefine city in cities.Items)
                //{
                //    cmbLocationRegister.Items.Add(city);
                //    if (_organ.RegisterPlace != 0 && _organ.RegisterPlace == city.Code)
                //        cmbLocationRegister.SelectedItem = city;
                //}
                /// آدرس - شهر
                //cmbCity.Items.Clear();
                //cmbCity.Items.Add(nullDeff);
                //cmbCity.SelectedItem = nullDeff;
                cities.SetComboBox(cmbCity, _organ.Address.City);
                //foreach (JSubBaseDefine city in cities.Items)
                //{
                //    cmbCity.Items.Add(city);
                //    if (_organ.Address.City != 0 && _organ.Address.City == city.Code)
                //        cmbCity.SelectedItem = city;
                //}

                /// نوع شرکت
                JCompanyTypes coTypes = new JCompanyTypes();
                //cmbType.Items.Clear();
                //cmbType.Items.Add(nullDeff);
                //cmbType.SelectedItem = nullDeff;
                coTypes.SetComboBox(cmbType, _organ.CompanyType);
                //foreach (JSubBaseDefine type in coTypes.Items)
                //{
                //    cmbType.Items.Add(type);
                //    if (_organ.CompanyType != 0 && _organ.CompanyType == type.Code)
                //        cmbType.SelectedItem = type;
                //}
                //dataGridView1.Rows.Add(
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
        /// <summary>
        /// تشکیل جدول صاحبان امضاء
        /// </summary>
        private void _BindGrid()
        {
            grdSignatureMen.DataSource = _organ.SignatureMen;
            grdSignatureMen.Columns[JSignatureMenFields.Code.ToString()].Visible = false;
            grdSignatureMen.Columns[JSignatureMenFields.PCode.ToString()].Visible = false;
        }

        private void _ShowData()
        {
            try
            {
                JAllPerson tmpAllPerson = new JAllPerson(_organ.Code);
                txtTafsiliCode.Text = tmpAllPerson.TafsiliCode.ToString();

                txtCode.Text = _organ.Code.ToString();
                txtName.Text = _organ.Name;
                txtRegisterNo.Text = _organ.RegisterNo;
                txtSubject.Text = _organ.Subject;
                txtDesc.Text = _organ.Description;
                txtAddress.Text = _organ.Address.Address;
                txtEmail.Text = _organ.Address.Email;
                txtZipCode.Text = _organ.Address.PostalCode;
                txtSite.Text = _organ.Address.WebSite;
                txtTel.Text = _organ.Address.Tel;
                txtFax.Text = _organ.Address.Fax;
                txtCommercialCode.Text = _organ.CommercialCode;
                txtShenaseMeli.Text = _organ.ShenaseMeli;
                txtDateReg.Date = _organ.RegisterDate;
                cmbCity.SelectedValue = _organ.Address.City;
                cmbLocationRegister.SelectedValue = _organ.RegisterPlace;
                //txtSharePCode.Text = tmpAllPerson.SharePCode.ToString();
                switch (_organ.Status)
                {
                    case JCompanyStatuses.Active: { rbActive.Checked = true; break; }
                    case JCompanyStatuses.Deactive: { rbDeactive.Checked = true; break; }
                    case JCompanyStatuses.Broke: { rbBroke.Checked = true; break; }
                    case JCompanyStatuses.Dissolved: { rbDissolved.Checked = true; break; }
                }
                _BindGrid();
                properties.ValueObjectCode = _organ.Code;
                //imgLogo.LoadDataFromArchive();
                //grdSignatureMen.DataSource = _organ.SignatureMen;
                //grdSignatureMen.Columns[JSignatureMenFields.Code.ToString()].Visible = false;
                //grdSignatureMen.Columns[JSignatureMenFields.PCode.ToString()].Visible = false;
                btnSave.Enabled = false;
            }
            catch
            {
            }
        }
        private bool _CheckControlValues()
        {
            if (txtName.Text.Trim() == "")
            {
                string[] parameters = { "@Value", };
                string[] values = { "Name", };
                string msg = JLanguages._Text("PleaseEnter", parameters, values);
                JMessages.Error(msg, "Error");
                txtName.Focus();
                return false;
            }

            if (cmbCity.SelectedItem == null)
            {
                string[] parameters = { "@Value" };
                string[] values = { "City" };
                string msg = JLanguages._Text("PleaseSelectFromList", parameters, values);
                JMessages.Error(msg, "Error");
                cmbCity.Focus();
                return false;
            }
            if (cmbLocationRegister.SelectedItem == null)
            {
                string[] parameters = { "@Value" };
                string[] values = { "RegisterPlace" };
                string msg = JLanguages._Text("PleaseSelectFromList", parameters, values);
                JMessages.Error(msg, "Error");
                cmbLocationRegister.Focus();
                return false;
            }
            if (cmbType.SelectedItem == null)
            {
                string[] parameters = { "@Value" };
                string[] values = { "CompanyType" };
                string msg = JLanguages._Text("PleaseSelectFromList", parameters, values);
                JMessages.Error(msg, "Error");
                cmbType.Focus();
                return false;
            }

            if ((grdSignatureMen.DataSource == null))
            {
                   JMessages.Error( " لطفا صاحبان امضا را وارد کنید " , "Error");
            }
            return true;

        }
        private bool _Save()
        {
            if ((txtShenaseMeli.Text == "") || (txtShenaseMeli.Text == "0"))
            {
                JMessages.Error(" لطفا شناسه ملی را وارد کنید ", "Error");
                return false;
            }
            if ((txtTafsiliCode.Text != "") && (txtTafsiliCode.Text != "0"))
                if (JAllPerson.CheckTafsiliCode(Convert.ToInt32(txtTafsiliCode.Text), _organ.Code))
                    JMessages.Error(" این کد تفصیلی تعریف شده است ","");

            if ((txtShenaseMeli.Text != "") && (txtShenaseMeli.Text != "0"))
                if (JOrganization.CheckShenaseMeli((txtShenaseMeli.Text), _organ.Code))
                    JMessages.Error(" این شناسه ملی تعریف شده است ", "");

            if (!_CheckControlValues())
                return false;
            _organ.Name = txtName.Text;
            _organ.RegisterNo = txtRegisterNo.Text;
            _organ.Subject = txtSubject.Text;
            _organ.Description = txtDesc.Text;
            _organ.CompanyType = Convert.ToInt32(cmbType.SelectedValue);
            _organ.RegisterPlace = Convert.ToInt32(cmbLocationRegister.SelectedValue);
            _organ.Access_Code = 0;
            _organ.CommercialCode = txtCommercialCode.Text;
            _organ.ShenaseMeli = txtShenaseMeli.Text;            
            _organ.RegisterDate = txtDateReg.Date;
            _organ.ConnectionString = "";

            _organ.Address.Address = txtAddress.Text;
            _organ.Address.City = Convert.ToInt32(cmbCity.SelectedValue);
            _organ.Address.Email = txtEmail.Text;
            _organ.Address.PostalCode = txtZipCode.Text;
            _organ.Address.WebSite = txtSite.Text;
            _organ.Address.Tel = txtTel.Text;
            _organ.Address.Fax = txtFax.Text;
            _organ.Address.Mobile = "";
            _organ._SharePCode = txtSharePCode.IntValue;

            if (rbActive.Checked) _organ.Status = JCompanyStatuses.Active;
            if (rbBroke.Checked) _organ.Status = JCompanyStatuses.Broke;
            if (rbDeactive.Checked) _organ.Status = JCompanyStatuses.Deactive;
            if (rbDissolved.Checked) _organ.Status = JCompanyStatuses.Dissolved;
            _organ._TafsiliCode = txtTafsiliCode.IntValue;

            ///-------------- INSERT
            if (State == JFormState.Insert)
            {
                if (!JPermission.CheckPermission("ClassLibrary.JOrganization.Insert"))
                    return false;
                int _PCode = _organ.Insert();
                if (_PCode > 0)
                {
                    _organ.Code = _PCode;
                    ArchiveListPerson.ObjectCode = _PCode;
                    ArchiveListPerson.ArchiveList();
                    _organ.Address.PCode = _PCode;
                    imgLogo.ObjectCode = _PCode;
                    txtCode.Text = _PCode.ToString();
                    btnSave.Enabled = false;
                    State = JFormState.Update;
                    properties.ValueObjectCode = _PCode;
                    properties.Save(null);
                    return true;
                }
                else
                {
                    // JMessages.Error("ErrorInInputData", "Error");
                    return false;
                }
            }

            ///--------------- UPDATE
            if (State == JFormState.Update)
            {
                if (!JPermission.CheckPermission("ClassLibrary.JOrganization.Insert"))
                    return false;
                if (_organ.Update())
                {
                    properties.Save(null);
                    ArchiveListPerson.ArchiveList();
                    return true;
                }
                return false;
            }
            return false;
        }
        private void btmSave_Click(object sender, EventArgs e)
        {
            if (_Save())
                btnSave.Enabled = false;
        }

        private void btmAddAuthorizedSignatory_Click(object sender, EventArgs e)
        {
            JSignatureMenForm form = new JSignatureMenForm(_organ.Code);
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (_organ.SignatureList == null)
                    _organ.SignatureList = new List<JSignatureMen>();
                _organ.SignatureList.Add(form.Result);
                DataRow row = ((DataTable)grdSignatureMen.DataSource).NewRow();
                //JTable.SetToDataRow(form.Result, row);
                row[JSignatureMenFields.FatherName.ToString()] = form.Result.FatherName;
                row[JSignatureMenFields.FirstName.ToString()] = form.Result.FirstName;
                row["ShSh"] = form.Result.IDNo;
                row[JSignatureMenFields.LastName.ToString()] = form.Result.LastName;
                row[JSignatureMenFields.SignPCode.ToString()] = form.Result.SignPCode;

                row[JSignatureMenFields.Post.ToString()] = form.Result.Post;
                row[JSignatureMenFields.Active.ToString()] = form.Result.Active;
                row[JSignatureMenFields.Description.ToString()] = form.Result.Description;
                row["FromDate"] = JDateTime.FarsiDate(form.Result.FromDate);
                row["ToDate"] = JDateTime.FarsiDate(form.Result.ToDate);
                ((DataTable)grdSignatureMen.DataSource).Rows.Add(row);
                btnSave.Enabled = true;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void btmdelAuthorizedSignatory_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdSignatureMen.SelectedRows == null)
                    return;
                DataRow row = ((DataRowView)grdSignatureMen.SelectedRows[0].DataBoundItem).Row;
                JSignatureMen signMan = _organ.SignatureList[grdSignatureMen.SelectedRows[0].Index];
                signMan.Deleted = true;
                /// افزودن به لیست حذفی ها
                _organ.DelSignatureList.Add(_organ.SignatureList[grdSignatureMen.SelectedRows[0].Index]);
                _organ.SignatureList.RemoveAt(grdSignatureMen.SelectedRows[0].Index);
                ((DataTable)grdSignatureMen.DataSource).Rows.RemoveAt(grdSignatureMen.SelectedRows[0].Index);
                btnSave.Enabled = true;
            }
            catch
            {
            }
        }

        private void btnEditSigMen_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdSignatureMen.SelectedRows == null)
                    return;
                DataRow row = ((DataRowView)grdSignatureMen.SelectedRows[0].DataBoundItem).Row;
                JSignatureMen signMan = _organ.SignatureList[grdSignatureMen.SelectedRows[0].Index];
                JSignatureMenForm signForm = new JSignatureMenForm(signMan);
                signForm.State = JFormState.Update;
                if (signForm.ShowDialog() == DialogResult.OK)
                {
                    ///اختصاص مقادیر شیء انتخاب شده به ستونهای ROW
                    //JTable.SetToDataRow(form.Result, row);
                    row[JSignatureMenFields.Active.ToString()] = signForm.Result.Active;
                    row[JSignatureMenFields.Description.ToString()] = signForm.Result.Description;
                    row[JSignatureMenFields.FatherName.ToString()] = signForm.Result.FatherName;
                    row[JSignatureMenFields.FirstName.ToString()] = signForm.Result.FirstName;
                    row["ShSh"] = signForm.Result.IDNo;
                    row[JSignatureMenFields.LastName.ToString()] = signForm.Result.LastName;
                    row[JSignatureMenFields.SignPCode.ToString()] = signForm.Result.SignPCode;
                    row[JSignatureMenFields.Post.ToString()] = signForm.Result.Post;
                    row["FromDate"] = JDateTime.FarsiDate(signForm.Result.FromDate);
                    row["ToDate"] = JDateTime.FarsiDate(signForm.Result.ToDate);
                    btnSave.Enabled = true;
                }
            }
            catch
            { }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void jArchiveImage1_OnAddFile(object Sender, EventArgs e)
        {
            if (imgLogo.ObjectCode == 0)
            {
                JMessages.Error("PleaseSaveChanges", "Error");
            }
        }

        private void jArchiveImage1_AfterFileAdded(object Sender, EventArgs e)
        {
            _organ.ArmArchiveCode = imgLogo.ArchiveCode;
            _organ.Update();
        }


        private void txtName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (State == JFormState.Insert)
                {
                   grdLegalPerson.DataSource = JOrganization.SearchPerson(0, txtName.Text, "", txtRegisterNo.Text, (Convert.ToInt32(cmbLocationRegister.SelectedValue)), txtSubject.Text, (Convert.ToInt32(cmbType.SelectedValue)), 0);
                }
            }

            catch
            {

            }
        }

        private void _ClearForm()
        {
            try
            {
                _organ = null;
                _organ = new JOrganization();
                txtRegisterNo.Text = "";
                txtSite.Text = "";
                txtSubject.Text = "";
                txtTel.Text = "";
                txtZipCode.Text = "";
                txtAddress.Text = "";
                txtCode.Text = "";
                txtDesc.Text = "";
                txtEmail.Text = "";
                txtFax.Text = "";
                txtName.Text = "";
                cmbCity.SelectedIndex = 0;
                cmbLocationRegister.SelectedIndex = 0;
                cmbType.SelectedIndex = 0;
                imgLogo.Image = null;
                ArchiveListPerson.ClearList();
                ArchiveListPerson.ObjectCode = 0;
            }
            catch
            {
            }
        }
        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            if (_Save())
            {
                _ClearForm();                
                State = JFormState.Insert;
                txtName.Focus();
            }
        }

        private void JLegalPerson_Shown(object sender, EventArgs e)
        {
            txtName.Focus();
        }

        private void JLegalPerson_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnSave.Enabled)
            {
                DialogResult result = JMessages.Confirm("DoYouWantTotSaveChanges?", "SaveChanges");
                if (result==DialogResult.Yes)
                {
                    btnSave.PerformClick();
                    Close();
                    return;
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
                else
                    e.Cancel = false;
            }
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((TabControl)sender).SelectedTab == tabAssets)
                if (grdAssets.DataSource == null)
                {
                    JAsset asset = new JAsset();
                    grdAssets.DataSource = asset.GetAssetPerson(_organ.Code);

                    grdAssets.Columns["AClassName"].Visible = false;
                    grdAssets.Columns["TClassName"].Visible = false;
                    grdAssets.Columns["PersonCode"].Visible = false;
                    grdAssets.Columns["TransferObjectCode"].Visible = false;
                    grdAssets.Columns["FinanceObjectCode"].Visible = false;
                }
            if (tabControl2.SelectedTab == tabContract)
            {
                grdContracts.DataSource = Legal.JSubjectContracts.PersonContractHistory(_organ.Code);
                grdContracts.Columns["ContractCode"].Visible = false;
                grdContracts.Columns["ClassName"].Visible = false;
                grdContracts.Columns["ObjectCode"].Visible = false;
            }
        }
        public void ShowAssetTab()
        {
            if (JPermission.CheckPermission("ClassLibrary.JLegalPerson.ShowAssetTab", 0, JMainFrame.CurrentPostCode, false))
            {
                tabControl2.TabPages.Add(tabAssets);
            }
        }

        private void grdLegalPerson_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            JOrganization pOrg = new JOrganization(Convert.ToInt32(grdLegalPerson.SelectedRows[0].Cells["Code"].Value));
            _organ = pOrg;
            State = JFormState.Update;
            grdAssets.DataSource = null;
            grdContracts.DataSource = null;
            InitialForm();
        }

        private List<JAction> CreateActions(string pTClassName, int pTransferObjectCode, string pAClassName, int pAssetObjectCode)
        {
            List<JAction> actions = new List<JAction>();
            /// اکشن مشاهده قرارداد
            if (pTClassName == "Legal.JSubjectContract")
            {
                Legal.JSubjectContract contract = new Legal.JSubjectContract(pTransferObjectCode);
                Legal.JContractdefine contractDefine = new Legal.JContractdefine(contract.Type);
                JAction viewContract = new JAction("ContractInformation...", "Legal.JGeneralContract.ShowForms", null, new object[] { contractDefine.ContractType, contract.Code, true });
                actions.Add(viewContract);
            }

            /////  مشخصات دارایی
            JAction unitAction = new JAction();
            if (pAClassName == "RealEstate.JUnitBuild")
            {
                RealEstate.JUnitBuild build = new RealEstate.JUnitBuild(pAssetObjectCode);
                unitAction = new JAction("UnitInfo...", "RealEstate.JUnitBuild.ShowDialog", new object[] { pAssetObjectCode }, null);
                actions.Add(unitAction);
            }
            return actions;
        }

        private void grdAssets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (grdAssets.RowCount > 0)
            {
                grdAssets.ClearActions();
                List<JAction> actions = CreateActions(
                   grdAssets.Rows[e.RowIndex].Cells["TClassName"].Value.ToString(),
                   Convert.ToInt32(grdAssets.Rows[e.RowIndex].Cells["TransferObjectCode"].Value),
                   grdAssets.Rows[e.RowIndex].Cells["AClassName"].Value.ToString(),
                   Convert.ToInt32(grdAssets.Rows[e.RowIndex].Cells["FinanceObjectCode"].Value));
                foreach (JAction action in actions)
                {
                    grdAssets.AddAction(action);
                }
            }
        }

        private void grdContracts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (grdContracts.RowCount > 0)
            {
                grdContracts.ClearActions();
                List<JAction> actions = CreateActions(
                  "Legal.JSubjectContract",
                   Convert.ToInt32(grdContracts.Rows[e.RowIndex].Cells["ContractCode"].Value),
                   grdContracts.Rows[e.RowIndex].Cells["ClassName"].Value.ToString(),
                   Convert.ToInt32(grdContracts.Rows[e.RowIndex].Cells["ObjectCode"].Value));
                foreach (JAction action in actions)
                {
                    grdContracts.AddAction(action);
                }
            }
        }
        public void CheckChangeDesc()
        {
            if (JPermission.CheckPermission("ClassLibrary.JLegalPerson.CheckChangeDesc", false))
                txtDesc.ReadOnly = false;
            else
                txtDesc.ReadOnly = true;
        }

        private void txtTafsiliCode_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

    }
}