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
using Microsoft.VisualBasic;

namespace ClassLibrary
{
    public partial class JPersonIn : ClassLibrary.JBaseForm
    {

		private int _CompanyCode = ManagementShares.JShareCompany.GetDefault();
        public JPersonIn()
        {
            InitializeComponent();
            _Person = new JPerson();
            InitialForm();
        }
        public JPersonIn(JPerson pPerson)        
        {
            _Person = pPerson;
            InitializeComponent();
            InitialForm();
        }

		public JPersonIn(JPerson pPerson, int pCompanyCode)
		{
			_Person = pPerson;
			_CompanyCode = pCompanyCode;
			InitializeComponent();
			InitialForm();
		}
		
		public void ShowSharePCode()
        {
            if (JPermission.CheckPermission("ClassLibrary.JPersonIn.ShowSharePCode", 0, JMainFrame.CurrentPostCode, false))
            {
                pnlSharePCode.Visible = true;
                if (_Person.Code == 0)
					txtSharePCode.Text = (JPersons.GetMaxSharePCode(_CompanyCode)).ToString();
            }
        }
        private void InitialForm()
        {
            _FillComboBoxes();
            /// مقداردهی پراپرتی های لیست آرشیو
            ArchiveListPerson.ClassName = _Person.GetType().FullName;
            ArchiveListPerson.ObjectCode = _Person.Code;

            // نمونه کد اضافه کردن کلاسها و آبجکتهای چندتایی به لیست آرشیو
            //IDictionary<string, int[]> extraObject = new Dictionary<string, int[]>();
            //extraObject.Add("ClassLibrary.JOrganization", new int[] { 1000001, 1000002, 1000003, 1000005 });
            //ArchiveListPerson.ExtraObject = extraObject;

            ArchiveListPerson.SubjectCode = JConstantArchiveSubjects.OtherImagesArchiveCode.GetHashCode();
            ArchiveListPerson.PlaceCode = JConstantArchivePalces.GeneralArchive.GetHashCode();
            _ShowData();
            tabControl2.TabPages.Remove(tabAssets);
            tabControl2.TabPages.Remove(tabContracts);
            ShowAssetTab();
            ShowSharePCode();
            if (JPermission.CheckPermission("Legal.JGeneralContract.ShowForms", 0, JMainFrame.CurrentPostCode, false))
                tabControl2.TabPages.Add(tabContracts);
            properties.ClassName = "ClassLibrary.JRealPerson";
            properties.ObjectCode = 1;
			properties.AfterPropertyChanged += new Globals.Property.JPropertyValueUserControl.PropertyChanged(properties_AfterPropertyChanged);

            CheckChangeDesc();
        }

		void properties_AfterPropertyChanged(object Sender, EventArgs e)
		{
			btnSave.Enabled = true;
		}

        public JPerson _Person;
        private JFile _PersonImage;
        private JFile _SignatureImage;
        private bool _PersonImageChanged;
        private bool _SignatureImageChanged;       
                                    
        /// <summary>
        /// 
        /// </summary>
        private void _FillComboBoxes()
        {

            JCities cities1 = new JCities();
            JCities cities2 = new JCities();
            JCities cities3 = new JCities();
            JCities cities4 = new JCities();

            JSubBaseDefine nullDeff = new JSubBaseDefine(0);
            nullDeff.Code = -1;
            nullDeff.Name = "-----------";
            cmbBirthPlace.BaseCode = JBaseDefine.CityCode;
            cmbHCity.BaseCode = JBaseDefine.CityCode;
            cmbIssuPlace.BaseCode = JBaseDefine.CityCode;
            cmbWCity .BaseCode = JBaseDefine.CityCode;
                     
            cities1.SetComboBox(cmbBirthPlace, _Person.BirthplaceCode);          
            cities2.SetComboBox(cmbIssuPlace, _Person.Sader);           
            cities3.SetComboBox(cmbHCity, _Person.HomeAddress.City);           
            cities4.SetComboBox(cmbWCity, _Person.WorkAddress.City);           

            if (State == JFormState.Insert)
            {
                cmbBirthPlace.SelectedValue = -1;
                cmbHCity.SelectedValue = -1;
                cmbIssuPlace.SelectedValue = -1;
                cmbWCity.SelectedValue = -1;
            }
        }
        /// <summary>
        /// نمایش فیلدها در داخل تکست باکسها
        /// </summary>
        private void _ShowData()
        {
            JAllPerson tmpAllPerson = new JAllPerson(_Person.Code);
            txtTafsiliCode.Text = tmpAllPerson.TafsiliCode.ToString();

            txtCode.Text = _Person.Code.ToString();
            if (_Person.Died)
                txtCode.Text = txtCode.Text + " (" + JLanguages._Text("Died") + ")";
            txtName.Text = _Person.Name;
            txtLastName.Text = _Person.Fam;
            txtFatherName.Text = _Person.FatherName;
            txtIDNo.Text = _Person.ShSh;
            txtNationalCode.Text = _Person.ShMeli;
            txtBirthDate.Text = JDateTime.FarsiDate(_Person.BthDate);
            cmbBirthPlace.SelectedValue = _Person.BirthplaceCode;
			txtSharePCode.Text = ManagementShares.ShareCompany.JSharepCode.GetData(_CompanyCode, _Person.Code).ToString();
            cmbIssuPlace.SelectedValue = _Person.Sader;
            rbMan.Checked = _Person.Gender;
            if (_Person.Code != 0)
                rbWoman.Checked = !_Person.Gender;
            else
                rbMan.Checked = true;

            txtHAddress.Text = _Person.HomeAddress.Address;
            txtHEmail.Text = _Person.HomeAddress.Email;
            cmbHCity.SelectedValue = _Person.HomeAddress.City;
            txtHFax.Text = _Person.HomeAddress.Fax;
            txtHPostalCode.Text = _Person.HomeAddress.PostalCode;
            txtHTel.Text = _Person.HomeAddress.Tel;
            txtMobile.Text = _Person.HomeAddress.Mobile;

            txtWAddress.Text = _Person.WorkAddress.Address;
            txtWEmail.Text = _Person.WorkAddress.Email;
            cmbWCity.SelectedValue = _Person.WorkAddress.City;
            txtWFax.Text = _Person.WorkAddress.Fax;
            txtWPostalCode.Text = _Person.WorkAddress.PostalCode;
            txtWTel.Text = _Person.WorkAddress.Tel;
            txtWWebSite.Text = _Person.WorkAddress.WebSite;
            txtDesc.Text = _Person.PDesc;
            if (_Person.OldChangeName != 0)
            {
                gBProfileInformation.Text += " تغییر نام از شخص با کد " + _Person.OldChangeName;
            }
            if (_Person.NewChangeName != 0)
            {
                gBProfileInformation.Text += " تغییر نام به شخص با کد " + _Person.NewChangeName;
            }
            btnSave.Enabled = false;
            //// ویژگی ها
            properties.ValueObjectCode = _Person.Code;
            ////-------------------- بازیابی تصویر شخص و امضاء از بایگانی اسناد -----------------------///
            ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(),JConstantArchivePalces.GeneralArchive.GetHashCode() );
            try
            {
                if (archive.Retrieve(_Person.PersonImageCode)) 
                {
                    _PersonImage = archive.Content;
                    if (_PersonImage != null)
                        imgPicture.Image = System.Drawing.Image.FromStream(_PersonImage.Stream);
                }
                ////Signature
                archive.SubjectCode = JConstantArchiveSubjects.SignatureArchiveCode.GetHashCode();
                archive.PlaceCode = JConstantArchivePalces.GeneralArchive.GetHashCode();
                if (archive.Retrieve(_Person.SignatureImageCode))
                {
                    _SignatureImage = archive.Content;
                    imgSignature.Image = System.Drawing.Image.FromStream(_SignatureImage.Stream);
                }
     
                //imgSignature.Image = _Person.SignatureImage;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                archive.Dispose();
            }
            ///// ------------------------------------------------------------------------------------///
            //// بازیابی 
        }

        /// <summary>
        /// چک کردن مقادیر کنترلها
        /// </summary>
        /// <returns></returns>
        private bool _CheckControlValues()
        {
            /// نام خانوادگی
            if (txtLastName.Text.Trim() == "")
            {
                string[] parameters = { "@Value" };
                string[] values = { "LastName" };
                string msg = JLanguages._Text("PleaseEnter", parameters, values);
                JMessages.Error(msg, "Error");
                txtLastName.Focus();
                return false;
            }
            if (txtName.Text.Trim() == "")
            {
                string[] parameters = { "@Value" };
                string[] values = { "Name" };
                string msg = JLanguages._Text("PleaseEnter", parameters, values);
                JMessages.Error(msg, "Error");
                txtName.Focus();
                return false;
            }
            if (txtFatherName.Text.Trim() == "")
            {
                string[] parameters = { "@Value" };
                string[] values = { "FatherName" };
                string msg = JLanguages._Text("PleaseEnter", parameters, values);
                JMessages.Error(msg, "Error");
                txtFatherName.Focus();
                return false;

            }
            if (txtIDNo.Text.Trim() == "")
            {
                string[] parameters = { "@Value" };
                string[] values = { "shsh" };
                string msg = JLanguages._Text("PleaseEnter", parameters, values);
                JMessages.Error(msg, "Error");
                txtIDNo.Focus();
                return false;

            }
            
            ///محل تولد
            if (cmbBirthPlace.SelectedItem == null)
            {
                string[] parameters = { "@Value" };
                string[] values = { "Birthplace" };
                string msg = JLanguages._Text("PleaseSelectFromList", parameters, values);
                JMessages.Error(msg, "Error");
                cmbBirthPlace.Focus();
                return false;
            }
            ///محل صدور
            if (cmbIssuPlace.SelectedItem == null)
            {
                string[] parameters = { "@Value" };
                string[] values = { "IssuePlace" };
                string msg = JLanguages._Text("PleaseSelectFromList", parameters, values);
                JMessages.Error(msg, "Error");
                cmbIssuPlace.Focus();
                return false;
            }
            ///شهر محل سکونت
            if (cmbHCity.SelectedItem == null)
            {
                string[] parameters = { "@Value" };
                string[] values = { "City" };
                string msg = JLanguages._Text("PleaseSelectFromList", parameters, values);
                JMessages.Error(msg, "Error");
                tabControl2.SelectedTab = tabHAddress;
                cmbHCity.Focus();
                return false;
            }
            ///شهر محل کار
            if (cmbWCity.SelectedItem == null)
            {
                //string[] parameters = { "@Value" };
                //string[] values = { "City" };
                //string msg = JLanguages._Text("PleaseSelectFromList", parameters, values);
                //JMessages.Error(msg, "Error");
                //tabControl2.SelectedTab = tabWAddress;
                //cmbWCity.Focus();
                //return false;
            } 
            return true;
        }

        private bool _Save()
        {
            if ((txtTafsiliCode.Text != "") && (txtTafsiliCode.Text != "0"))
                if (JAllPerson.CheckTafsiliCode(Convert.ToInt32(txtTafsiliCode.Text), _Person.Code))
            {
                JMessages.Error(" این کد تفصیلی تعریف شده است ", "");
                return false;
            }
            if (_Person.NewChangeName != 0)
            {
                JMessages.Error("ChangeName", "ChangeName");
                return false;
            }
            if (JMainFrame.CurrentPostCode != 1 && !_CheckControlValues())
                return false;
			if (JMainFrame.CurrentPostCode != 1 && (txtNationalCode.Text == "") || (txtNationalCode.Text == "0"))
            {
                JMessages.Error("کد ملی را وارد کنید", "");
                txtNationalCode.Focus();
                return false;
            }
			if (JMainFrame.CurrentPostCode != 1 && !(JAllPerson.CheckCodeMeli(txtNationalCode.Text.Trim())))
            {
                JMessages.Error("کد ملی را درست وارد کنید", "");
                txtNationalCode.Focus();
                return false;
            }
            #region Set Control Values To Properties
            _Person.Name = txtName.Text.Trim();
            _Person.Fam = txtLastName.Text.Trim();
            _Person.ShSh = txtIDNo.Text.Trim();
            _Person.FatherName = txtFatherName.Text.Trim();
            _Person.ShMeli = txtNationalCode.Text.Trim();
            _Person.BthDate = txtBirthDate.Date;
            _Person.BirthplaceCode = (Convert.ToInt32(cmbBirthPlace.SelectedValue));
            _Person.Sader = Convert.ToInt32(cmbIssuPlace.SelectedValue);
            _Person.Gender = rbMan.Checked;

            _Person.HomeAddress.AddressType = JAddressTypes.Home;
            _Person.HomeAddress.Address = txtHAddress.Text.Trim();
            _Person.HomeAddress.City = (Convert.ToInt32(cmbHCity.SelectedValue));
            _Person.HomeAddress.PostalCode = txtHPostalCode.Text.Trim();
            _Person.HomeAddress.Tel = txtHTel.Text.Trim();
            _Person.HomeAddress.Fax = txtHFax.Text.Trim();
            _Person.HomeAddress.Mobile = txtMobile.Text.Trim();
            _Person.HomeAddress.Email = txtHEmail.Text.Trim();
            _Person.HomeAddress.WebSite = "";

            _Person.WorkAddress.AddressType = JAddressTypes.Work;
            _Person.WorkAddress.Address = txtWAddress.Text.Trim();
            _Person.WorkAddress.City = Convert.ToInt32(cmbWCity.SelectedValue);
            _Person.WorkAddress.PostalCode = txtWPostalCode.Text.Trim();
            _Person.WorkAddress.Tel = txtWTel.Text.Trim();
            _Person.WorkAddress.Fax = txtWFax.Text.Trim();
            _Person.WorkAddress.WebSite = txtWWebSite.Text.Trim();
            _Person.WorkAddress.Email = txtWEmail.Text.Trim();
            _Person.WorkAddress.Mobile = "";
            _Person.PDesc = txtDesc.Text;
            _Person.IncompleteInformation = false;
            _Person._TafsiliCode = txtTafsiliCode.IntValue;
			_Person._CompanyCode = _CompanyCode;
            _Person._SharePCode = txtSharePCode.Int64Value;
            #endregion Set Control Values To Properties

            #region Insert
            /// درج شخص جدید
            if (State == JFormState.Insert)
            {
                if (!JPermission.CheckPermission("ClassLibrary.JPerson.Insert"))
                    return false;
                //if (JPermission.CheckPermission("ClassLibrary.JPerson.Insert.SetCodeManual"))
                //{
                //    try
                //    {
                //        _Person.Code = int.Parse(Interaction.InputBox("NewCode", "Prompt", "0", 0, 0));
                //    }
                //    catch
                //    {

                //    }
                //    if (_Person.Code <= 0)
                //    {
                //        return false;
                //    }
                //}
                int _PCode = _Person.insert();
                if (_PCode > 0)
                {
                    _Person.Code = _PCode;
                    ArchiveListPerson.ObjectCode = _PCode;
                    ArchiveListPerson.ArchiveList();
                    _Person.WorkAddress.PCode = _Person.Code;
                    _Person.HomeAddress.PCode = _Person.Code;
                    properties.ValueObjectCode = _PCode;
                    properties.Save(null);
                    /// ---------------------  بایگانی تصویر شخص و امضاء--------------------------- ////
                    ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), JConstantArchivePalces.GeneralArchive.GetHashCode());
                    try
                    {
                        int ArchiveCode = 0;
                        if (_PersonImage != null)
                        {
                            ArchiveCode = archive.ArchiveDocument(_PersonImage, _Person.GetType().FullName, _Person.Code,JLanguages._Text("PersonPicture"), true);
                            _Person.PersonImageCode = ArchiveCode;
                        }
                        if (_SignatureImage != null)
                        {
                            archive.SubjectCode = JConstantArchiveSubjects.SignatureArchiveCode.GetHashCode();
                            ArchiveCode = archive.ArchiveDocument(_SignatureImage, _Person.GetType().FullName, _Person.Code, JLanguages._Text("SignaturePicture"), true);
                            _Person.SignatureImageCode = ArchiveCode;
                        }
                        _Person.Update(false);
                    
                        txtCode.Text = _PCode.ToString();
                        btnSave.Enabled = false;
                        State = JFormState.Update;
                    }
                    finally
                    {
                        archive.Dispose();
                    }
                    //// -------------------------------------------------------------////
                    return true;                
                }
                return false;
            }
            #endregion Insert

            #region Update
            /// ویرایش شخص جاری
            if (State == JFormState.Update)
            {
                if (!JPermission.CheckPermission("ClassLibrary.JPerson.Update"))
                    return false;
  
                if (_Person.Update())
                {
                    properties.Save(null);
                    #region Update Images
                    /// ---------------------  بروزرسانی تصویر شخص و امضاء--------------------------- ////
                    /// ---- تصویر شخص
                    if (_PersonImageChanged)
                    {
                        ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), JConstantArchivePalces.GeneralArchive.GetHashCode());
                        try
                        {
                            if (_Person.PersonImageCode == 0) /// در صورتی که تصویر جدید وارد شده باشد
                            {
                                int ArchiveCode = archive.ArchiveDocument(_PersonImage, _Person.GetType().FullName, _Person.Code, JLanguages._Text("PersonImage"), true);
                                _Person.PersonImageCode = ArchiveCode;
                                _Person.Update();
                            }
                            else
                            {
                                archive.UpdateArchive(_PersonImage, _Person.PersonImageCode, JLanguages._Text("PersonImage"), false);
                            }
                        }
                        finally
                        {
                            archive.Dispose();
                        }
                    }
                    ///---------- امضاء
                    if (_SignatureImageChanged)
                    {
                        ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(JConstantArchiveSubjects.SignatureArchiveCode.GetHashCode(), JConstantArchivePalces.GeneralArchive.GetHashCode());
                        try
                        {
                            if (_Person.SignatureImageCode == 0)  /// در صورتی که تصویر جدید وارد شده باشد
                            {
                                int ArchiveCode = archive.ArchiveDocument(_SignatureImage, _Person.GetType().FullName, _Person.Code, JLanguages._Text("SignaturePicture"), true);
                                _Person.SignatureImageCode = ArchiveCode;
                                _Person.Update();
                            }
                            else
                            {
                                archive.UpdateArchive(_SignatureImage, _Person.SignatureImageCode, JLanguages._Text("SignatureImage"), false);
                            }
                        }
                        finally
                        {
                            archive.Dispose();
                        }
                    }

                    //// -------------------------------------------------------------------------////
                    #endregion

                    ArchiveListPerson.ArchiveList();
                    btnSave.Enabled = false;
                    return true;
                }
                return false;
            }
            #endregion Update

            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Save();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Dispose();
            Close();
        }

        private void txtHAddress_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            
            try
            {
                if (State == JFormState.Insert && ((TextBox)sender).Text != "")
                {
                    grdPerson.DataSource = JPerson.SearchPerson(0, txtName.Text, txtLastName.Text, txtFatherName.Text, txtIDNo.Text,
                         Convert.ToInt32(cmbBirthPlace.SelectedValue), txtBirthDate.Date, DateTime.MinValue,
                         Convert.ToInt32(cmbIssuPlace.SelectedValue), txtNationalCode.Text, -1,"");
                    grdPerson.Columns["Title"].Visible = false;
                }
            }
            catch
            {
            }
        }

        //private void editMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (_Person.PersonImageCode != 0)
        //    {
        //        ArchivedDocuments.JImageForm imageForm = new ArchivedDocuments.JImageForm();
        //        if (imageForm.ShowDialog() == DialogResult.OK)
        //        {
        //            _PersonImage = imageForm.SelectedFile;
        //            imgPicture.Image = imageForm.SelectedImage;
        //            _PersonImageChanged = true;
        //            btnSave.Enabled = true;
        //        }
        //        imageForm.Dispose();
        //    }
        //}

        private void editSignature_Click(object sender, EventArgs e)
        {
            if (_Person.SignatureImageCode != 0)
            {
                ArchivedDocuments.JImageForm imageForm = new ArchivedDocuments.JImageForm();
                if (imageForm.ShowDialog() == DialogResult.OK)
                {
                    _SignatureImage = imageForm.SelectedFile;
                    imgSignature.Image = imageForm.SelectedImage;
                    _SignatureImageChanged = true;
                    btnSave.Enabled = true;
                }
                imageForm.Dispose();
            }
        }

        private void newImageItem_Click(object sender, EventArgs e)
        {
            if (_PersonImage != null)
            {
                _PersonImage = null;
                //_PersonImage.Dispose();
                imgPicture.Image=null;
            }
            ArchivedDocuments.JImageForm imageForm = new ArchivedDocuments.JImageForm();
            if (imageForm.ShowDialog() == DialogResult.OK)
            {
                _PersonImage = imageForm.SelectedFile;
                imgPicture.Image = imageForm.SelectedImage;
                btnSave.Enabled = true;
                _PersonImageChanged = true;
            }
            imageForm.Dispose();
        }

        private void mnuImages_Opening(object sender, CancelEventArgs e)
        {
            if (_Person.PersonImageCode == 0)
            {
                //editMenuItem.Enabled = false;
                newItem.Enabled = true;
                deleteImageItem.Enabled = false;
            }
            else
            {
                //editMenuItem.Enabled = true;
                newItem.Enabled = false;
                deleteImageItem.Enabled = true;
            }
        }

        private void newSignatureItem_Click(object sender, EventArgs e)
        {
            if (_Person.SignatureImageCode == 0)
            {
                ArchivedDocuments.JImageForm imageForm = new ArchivedDocuments.JImageForm();
                if (imageForm.ShowDialog() == DialogResult.OK)
                {
                    _SignatureImage = imageForm.SelectedFile;
                    imgSignature.Image = imageForm.SelectedImage;
                    _SignatureImageChanged = true;
                    btnSave.Enabled = true;                    
                }
                imageForm.Dispose();
            }
        }

        private void mnuSignatureImage_Opening(object sender, CancelEventArgs e)
        {
            if (_Person.SignatureImageCode == 0)
            {
                editSignature.Enabled = false;
                newSignatureItem.Enabled = true;
                deleteSignatureItem.Enabled = false;
            }
            else
            {
                editSignature.Enabled = true;
                newSignatureItem.Enabled = false;
                deleteSignatureItem.Enabled = true;
            }
        }

        private void deleteMenuItem_Click(object sender, EventArgs e)
        {
            if (JMessages.Question("Are you sure? You want to delete image?" , "Confirm") == DialogResult.Yes)
            {
                ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), JConstantArchivePalces.GeneralArchive.GetHashCode());
                try
                {
                    if (archive.DeleteArchive(_Person.PersonImageCode, true, true))
                    {
                        _Person.PersonImageCode = 0;
                        if (_Person.Update())
                        {
                            imgPicture.Image = null;
                            _PersonImage = null;
                        }
                        btnSave.Enabled = true;
                        _PersonImageChanged = true;
                    }
                }
                finally
                {
                    archive.Dispose();
                }
            }
        }

        private void deleteSignatureItem_Click(object sender, EventArgs e)
        {

            if (JMessages.Question("Are you sure? You want to delete image?", "Confirm") == DialogResult.Yes)
            {
                ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(JConstantArchiveSubjects.SignatureArchiveCode.GetHashCode(), JConstantArchivePalces.GeneralArchive.GetHashCode());
                try
                {
                    if (archive.DeleteArchive(_Person.SignatureImageCode, true))
                    {
                        _Person.SignatureImageCode= 0;
                        if (_Person.Update(false))
                            imgSignature.Image = null;
                    }
                }
                finally
                {
                    archive.Dispose();
                }
            }
        }

        private void jArchiveList1_OnAddFile(object Sender, EventArgs e)
        {
            //if (ArchiveListPerson.ObjectCode == 0)
            //{
            //    JMessages.Error("PleaseSaveChanges", "Error");
            //}
        }

        private void _ClearForm()
        {
            try
            {
                _Person = null;
                _Person = new JPerson();
                txtBirthDate.Text = "";
                txtCode.Text = "";
                txtFatherName.Text = "";
                txtHAddress.Text = "";
                txtHEmail.Text = "";
                txtHFax.Text = "";
                txtHPostalCode.Text = "";
                txtHTel.Text = "";
                txtIDNo.Text = "";
                txtLastName.Text = "";
                txtMobile.Text = "";
                txtName.Text = "";
                txtNationalCode.Text = "";
                txtWAddress.Text = "";
                txtWEmail.Text = "";
                txtWFax.Text = "";
                txtWPostalCode.Text = "";
                txtWTel.Text = "";
                txtWWebSite.Text = "";
                rbMan.Checked = true;
                
                cmbBirthPlace.SelectedIndex = 0;
                cmbHCity.SelectedIndex = 0;
                cmbIssuPlace.SelectedIndex = 0;
                cmbWCity.SelectedIndex = 0;
                imgPicture.Image = null;
                imgSignature.Image = null; 
                ArchiveListPerson.ClearList();
                ArchiveListPerson.ObjectCode = 0;
            }
            catch
            {
            }               
        }
        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            //if (_Save())
            //{
            //    _ClearForm();
            //    State = JFormState.Insert;
            //    txtLastName.Focus();
            //}            
            DialogResult = DialogResult.Retry;
        }

        private void btnDelNew_Click(object sender, EventArgs e)
        {
            if (_Person.Delete())
            {
                _ClearForm();
                State = JFormState.Insert;
                txtLastName.Focus();
            }  
        }

        private void JPersonIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnSave.Enabled)
            {
                DialogResult result = JMessages.Confirm("DoYouWantToSaveChanges?", "SaveChanges");
                if (result == DialogResult.Yes)
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

        private void grdPerson_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            JPerson pPerson = new JPerson(Convert.ToInt32(grdPerson.SelectedRows[0].Cells["Code"].Value));
            _Person = pPerson;
            State = JFormState.Update;
            grdAssets.DataSource = null;
            grdContracts.DataSource = null;
            InitialForm();
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Tab Assets
            if (((TabControl)sender).SelectedTab == tabAssets)
                if (grdAssets.DataSource == null)
                {
                    JAsset asset = new JAsset();
                    grdAssets.DataSource = asset.GetAssetPerson(_Person.Code);
                    if (grdAssets.DataSource != null)
                    {
                        grdAssets.Columns["AClassName"].Visible = false;
                        grdAssets.Columns["TClassName"].Visible = false;
                        grdAssets.Columns["PersonCode"].Visible = false;
                        grdAssets.Columns["TransferObjectCode"].Visible = false;
                        grdAssets.Columns["FinanceObjectCode"].Visible = false;
                        grdAssets.Columns["GroupCode"].Visible = false;
                    }
                }
            #endregion Tab Assets

            #region Tab Contracts
            if (tabControl2.SelectedTab == tabContracts)
            {
                grdContracts.DataSource = Legal.JSubjectContracts.PersonContractHistory(_Person.Code);
                grdContracts.Columns["ContractCode"].Visible = false;
                grdContracts.Columns["ClassName"].Visible = false;
                grdContracts.Columns["ObjectCode"].Visible = false;
            }
            #endregion Tab Contracts
        }
        public void ShowAssetTab()
        {
            if (JPermission.CheckPermission("ClassLibrary.JPersonIn.ShowAssetTab", 0, JMainFrame.CurrentPostCode, false))
            {
                tabControl2.TabPages.Add(tabAssets);
            }
        }

        private List<JAction> CreateActions(string pTClassName, int pTransferObjectCode, string pAClassName, int pAssetObjectCode)
        {
            List<JAction> actions = new List<JAction>();
            /// اکشن مشاهده قرارداد
            if (pTClassName=="Legal.JSubjectContract")
            {
                Legal.JSubjectContract contract = new Legal.JSubjectContract(pTransferObjectCode);
                Legal.JContractdefine contractDefine = new Legal.JContractdefine(contract.Type);
                JAction viewContract = new JAction("ContractInformation...", "Legal.JGeneralContract.ShowForms", null, new object[] { contractDefine.ContractType, contract.Code, true});
                actions.Add(viewContract);
            }

            /////  مشخصات دارایی
            JAction unitAction = new JAction();
            if (pAClassName == "RealEstate.JUnitBuild")
            {
                //RealEstate.JUnitBuild build = new RealEstate.JUnitBuild(pAssetObjectCode);
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

        private void txtHFax_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;

        }     

        public void CheckChangeDesc()
        {
            if (JPermission.CheckPermission("ClassLibrary.JPersonIn.CheckChangeDesc", false))
                txtDesc.ReadOnly = false;
            else
                txtDesc.ReadOnly = true;
        }

        private void btnSendSMS_Click(object sender, EventArgs e)
        {
            if (JPermission.CheckPermission("ClassLibrary.JSMSSend.Insert"))
            {
                JTextInputDialogForm TIDF = new JTextInputDialogForm("Text", "");
                TIDF.ShowDialog();

                if (TIDF.Text.Length > 0)
                {
                    JSMSSend SmSSend = new JSMSSend();
                    SmSSend.ClassName = "ClassLibrary.JPerson";
                    SmSSend.Description = "";
                    SmSSend.Mobile = txtMobile.Text;
                    SmSSend.ObjectCode = int.Parse("0" + txtCode.Text);
                    SmSSend.PersonCode = JMainFrame.CurrentPostCode;
                    SmSSend.Project = "ClassLibrary";
                    SmSSend.RegDate = JDateTime.Now();
                    SmSSend.Text = TIDF.Text;
                    SmSSend.Insert();
                }
            }
        }

        private void txtTafsiliCode_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void JPersonIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_PersonImage != null)
            {
                _PersonImage = null;
                imgPicture.Image = null;
            }
        }

        private void FillGridCards()
        {
            try
            {
                //dgListCards.DataSource = SmartCardSepad.JCardDefines.GetCards(_Person.Code);
                //dgListCards.Columns["Code"].Visible = false;
                //dgListCards.Columns["CardCode"].Visible = false;
                //dgListCards.Columns["rfidnumber"].Visible = false;
            }
            catch (Exception ex)
            {
                JMessages.Error(ex.Message, "Error");
            }
        }

        private void JPersonIn_Load(object sender, EventArgs e)
        {
            if (State != JFormState.Insert)
                FillGridCards();
        }

		private void txtSharePCode_TextChanged(object sender, EventArgs e)
		{
			btnSave.Enabled = true;
			if (txtSharePCode.Text.Length == 0)
			{
				btnNewShareCode.Visible = true;
			}
		}

		private void btnNewShareCode_Click(object sender, EventArgs e)
		{
			try
			{
				txtSharePCode.Text = JPersons.GetMaxSharePCode(_CompanyCode).ToString();
			}
			finally
			{
			}
		}
    }
}
