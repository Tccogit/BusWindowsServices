using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary
{
    public enum SearchOnCode
    {
        Code,
        SharePCode,
    }
    public partial class JUCPerson : UserControl
    {
        public int SelectedCode
        {
            get
            {
                if (SearchOnCode != SearchOnCode.SharePCode)
                    return txtExportCode.IntValue;
                else
                    return JAllPerson.GetCodeBySharePCode(txtExportCode.Int64Value, CompanyCode);
            }
            set
            {
                if (SearchOnCode != SearchOnCode.SharePCode)
                    txtExportCode.Text = value.ToString();
                else
                {
                    string _Code = ManagementShares.ShareCompany.JSharepCode.GetData(CompanyCode, value).ToString();
                    if (_Code != "-1")
                        txtExportCode.Text = _Code;
                }

            }
        }

        private bool _TafsiliCode;
        public bool TafsiliCode
        {
            get
            {
                return _TafsiliCode;
            }
            set
            {
                _TafsiliCode = value;
                if (_TafsiliCode)
                    Code.Text = "TafsiliCode:";
                else
                    Code.Text = "PersonCode:";
            }
        }

        public bool IsDied = false;
        public bool IsBlock = false;

        public bool ReadOnly
        {
            get
            {
                return !btnSearch.Enabled;
            }
            set
            {
                btnSearch.Enabled = !value;
                button1.Enabled = !value;
                txtExportCode.ReadOnly = value;
            }
        }

        public string Text
        {
            get
            {
                return grpMain.Text;
            }
            set
            {
                grpMain.Text = value;
            }
        }

        public Int64 ShareSelectedCode
        {
            get
            {
                if (SearchOnCode == SearchOnCode.SharePCode)
                    return Convert.ToInt64(txtExportCode.Text);
                else
                    return JAllPerson.GetShareCodeByPCode(Convert.ToInt64(txtExportCode.Text), CompanyCode);
            }
            set
            {
				if (SearchOnCode == SearchOnCode.SharePCode)
					txtExportCode.Text = value.ToString();
				else
					txtExportCode.Text = JAllPerson.GetShareCodeByPCode(value, CompanyCode).ToString();

            }
        }

        /// <summary>
        /// نوع شخص
        /// </summary>
        private JPersonTypes _PersonType;
        public JPersonTypes PersonType
        {
            get
            {
                return _PersonType;
            }
            set
            {
                _PersonType = value;
            }
        }
        public string FilterPerson
        {
            get;
            set;
        }
        /// <summary>
        /// برچسب 
        /// </summary>
        private string _LableGroup;
        public string LableGroup
        {
            get
            {
                return _LableGroup;
            }
            set
            {
                _LableGroup = value;
                grpMain.Text = _LableGroup;
            }
        }
        private SearchOnCode _SearchOnCode;
        public SearchOnCode SearchOnCode
        {
            get { return _SearchOnCode; }
            set { _SearchOnCode = value; }
        }


        private int _CompanyCode = 1;
        public int CompanyCode
        {
            get
            {
                return _CompanyCode;
            }
            set
            {
                _CompanyCode = value;
            }
        }
        public JUCPerson()
        {
            InitializeComponent();
        }
        public delegate void CodeSelected(object Sender, EventArgs e);
        public event CodeSelected AfterCodeSelected;

        public void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int Code = 0;
                JFindPersonForm FPF = new JFindPersonForm(_PersonType, FilterPerson);
                FPF.CompanyCode = CompanyCode;
                if (FPF.ShowDialog() == DialogResult.OK)
                {
                    if (FPF.SelectedPerson != null)
                        Code = FPF.SelectedPerson.Code;
                    if (Code != 0)
                    {
                        if (SearchOnCode == SearchOnCode.SharePCode)
                        {
                            Int64 SharePCode = ManagementShares.ShareCompany.JSharepCode.GetData(CompanyCode, Code);
                            if (SharePCode <= 0)
                            {
                                ManagementShares.ShareCompany.JSharepCode SP = new ManagementShares.ShareCompany.JSharepCode();
                                SP.Insert(CompanyCode, Code);
                                SharePCode = SP.SharePCode;
                            }

                            txtExportCode.Text = SharePCode.ToString();

                        }
                        else
                        {
                            txtExportCode.Text = Code.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
        private void ClearControls()
        {
            lbName.Text = "";
            lbLastName.Text = "";
            lbIDNo.Text = "";
            lbFatherName.Text = "";
            lbBrthDate.Text = "";
            lbNationalNo.Text = "";

            lblTitle.Text = "";
            lblPhone.Text = "";
            lblAddress.Text = "";
            lblDesc.Text = "";
            lblMobile.Text = "";

            lbLName.Text = "";
            lbLEcoNo.Text = "";
            lbLRegNo.Text = "";
            lbLRegPlace.Text = "";
            lbLSubject.Text = "";
            lbLType.Text = "";
            grpReal.Visible = true;
            grpLegal.Visible = false;
            grpOtherPerson.Visible = false;

            foreach (Control label in grpReal.Controls)
            {
                if (label.Name.StartsWith("lb"))
                {
                    ((Label)label).BackColor = grpReal.BackColor;
                    ((Label)label).ForeColor = Color.Blue;
                    IsBlock = false;
                    IsDied = false;
                }
            }

            foreach (Control label in grpLegal.Controls)
            {
                if (label.Name.StartsWith("lb"))
                {
                    ((Label)label).BackColor = grpReal.BackColor;
                    ((Label)label).ForeColor = Color.Blue;
                    IsBlock = false;
                    IsDied = false;
                }
            }
        }
        private void txtExportCode_TextChanged(object sender, EventArgs e)
        {
            int Code = 0;
            Int64 SharePCode = txtExportCode.Int64Value;
            if (SharePCode == 0)
            {
                SelectedCode = 0;
                ClearControls();
                return;
            }
            /// جستجو بر اساس کد سهامداری
            if (_SearchOnCode == SearchOnCode.SharePCode)
            {
                //int pcode = 0;
                int pcode = ManagementShares.ShareCompany.JSharepCode.GetPersonShare(CompanyCode, Convert.ToInt64(SharePCode));
                if (pcode > 0)
                {
                    SelectedCode = pcode;
                    Code = pcode;
                }
                else
                {
                    Code = 0;
                }
            }
            else
            {
                Code = int.Parse(SharePCode.ToString());
            }
            JAllPerson tmp = new JAllPerson(Code);

            if (_TafsiliCode == true)
            {

                tmp.GetDataTafsiliCode(Code);
                Code = tmp.Code;
                lblTafsiliCode.Text = tmp.TafsiliCode.ToString();
            }
            if (AfterCodeSelected != null)
                AfterCodeSelected(sender, e);
            if (tmp.PersonType == JPersonTypes.RealPerson)
            {
                JPerson JDP = new JPerson();
                if (JDP.getData(Code))
                {
                    SelectedCode = JDP.Code;
                    if (SearchOnCode != SearchOnCode.SharePCode)
                        txtExportCode.Text = JDP.Code.ToString();
                    lbName.Text = JDP.Name;
                    lbLastName.Text = JDP.Fam;
                    lbIDNo.Text = JDP.ShSh;
                    lbFatherName.Text = JDP.FatherName;
                    lbBrthDate.Text = JDateTime.FarsiDate(JDP.BthDate);
                    lbNationalNo.Text = JDP.ShMeli;
                    grpReal.Visible = true;
                    grpLegal.Visible = false;
                    grpOtherPerson.Visible = false;

                    JPersonAddress tmpAddress = new JPersonAddress(Code, JAddressTypes.Home);
                    lblAddress.Text = tmpAddress.FullAddress;
                    lblPhone.Text = tmpAddress.Tel;
                    lblMobile.Text = tmpAddress.Mobile;

                    if (JDP.Died)
                    {
                        foreach (Control label in grpReal.Controls)
                        {
                            if (label.Name.StartsWith("lb"))
                            {
                                ((Label)label).BackColor = Color.Black;
                                ((Label)label).ForeColor = Color.White;
                                IsDied = true;
                            }
                        }
                    }
                    else
                        if (JDP.Blocked)
                        {
                            foreach (Control label in grpReal.Controls)
                            {
                                if (label.Name.StartsWith("lb"))
                                {
                                    ((Label)label).BackColor = Color.Red;
                                    ((Label)label).ForeColor = Color.White;
                                    IsBlock = true;
                                }
                            }
                        }
                        else
                        {
                            foreach (Control label in grpReal.Controls)
                            {
                                if (label.Name.StartsWith("lb"))
                                {
                                    ((Label)label).BackColor = grpReal.BackColor;
                                    ((Label)label).ForeColor = Color.Blue;
                                    IsBlock = false;
                                    IsDied = false;
                                }
                            }
                        }
                    lbLastName.Text = JDP.Fam;
                    lbIDNo.Text = JDP.ShSh;
                    lbFatherName.Text = JDP.FatherName;
                    lbBrthDate.Text = JDateTime.FarsiDate(JDP.BthDate);
                    lbNationalNo.Text = JDP.ShMeli;

                    //labDeadName.Text = JDP.Name.ToString() + "  " + JDP.Fam.ToString() + "  " + JDP.FatherName.ToString();
                    //labDeadshsh.Text = JDP.ShSh.ToString() + "  " + JDP.ShMeli.ToString() + "  " + JDateTime.FarsiDate(JDP.BthDate);
                }
                else
                    JMessages.Error("PersonCodeNotFound", "Error");
            }
            else if (tmp.PersonType == JPersonTypes.OtherPerson)
            {
                JOtherPerson JDP = new JOtherPerson();
                if (JDP.GetData(Code))
                {
                    SelectedCode = JDP.Code;
                    if (SearchOnCode != SearchOnCode.SharePCode)
                        txtExportCode.Text = JDP.Code.ToString();
                    lblTitle.Text = JDP.Title;
                    lblPhone.Text = JDP.Phone;
                    lblAddress.Text = JDP.Address;
                    lblDesc.Text = JDP.Description;
                    grpOtherPerson.Visible = true;
                    grpLegal.Visible = false;
                    grpReal.Visible = false;
                }
                else
                    JMessages.Error("PersonCodeNotFound", "Error");
            }
            else
            {
                JOrganization JOrg = new JOrganization();
                if (JOrg.GetData(Code))
                {
                    SelectedCode = JOrg.Code;
                    if (SearchOnCode != SearchOnCode.SharePCode)
                        txtExportCode.Text = JOrg.Code.ToString();
                    lbLName.Text = JOrg.Name;
                    lbLEcoNo.Text = JOrg.CommercialCode;
                    lbLRegNo.Text = JOrg.RegisterNo;
                    lbLRegPlace.Text = JOrg.RegisterPlaceText;
                    lbLSubject.Text = JOrg.Subject;
                    lbLType.Text = (new JSubBaseDefine(ClassLibrary.JBaseDefine.CompanyTypes, JOrg.CompanyType)).Name;
                    grpReal.Visible = false;
                    grpLegal.Visible = true;
                    grpOtherPerson.Visible = false;
                    IsDied = false;
                    //labDeadName.Text = JOrg.Name + "  " + JOrg.RegisterNo + "  " + JOrg.CommercialCode;
                    //labDeadshsh.Text =  JOrg.Subject;
                    //JOrg.Managing_Director.ToString() + "  " +
                    if (!(JOrg.Status == JCompanyStatuses.UnDefined_ || JOrg.Status == JCompanyStatuses.Active))
                    {
                        foreach (Control label in grpLegal.Controls)
                        {
                            if (label.Name.StartsWith("lb"))
                            {
                                ((Label)label).BackColor = Color.Red;
                                ((Label)label).ForeColor = Color.White;
                                IsBlock = true;
                            }
                        }
                    }
                    else
                    {
                        foreach (Control label in grpLegal.Controls)
                        {
                            if (label.Name.StartsWith("lb"))
                            {
                                ((Label)label).BackColor = grpReal.BackColor;
                                ((Label)label).ForeColor = Color.Blue;
                                IsBlock = false;
                                IsDied = false;
                            }
                        }
                    }
                    //
                }
                else
                    ClearControls();
                //JMessages.Error("OrganizationCodeNotFound", "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtExportCode.Text = "0";
        }
    }
}
