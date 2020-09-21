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
    public partial class JPersonIn : ClassLibrary.JBaseForm
    {
        public JPersonIn()
        {
            InitializeComponent();
            _FillComboBoxes();
        }
        public JPersonIn(int pCode)        
        {
            _PCode = pCode;
            InitializeComponent();
            _FillComboBoxes();
            _ShowData();
        }

        private int _PCode;

        /// <summary>
        /// 
        /// </summary>
        private void _FillComboBoxes()
        {
            DataTable dtBirthPalce = new DataTable();
            dtBirthPalce = (new JCities()).GetList();
            DataRow dr;
            dr = dtBirthPalce.NewRow();
            dr["Code"] = "-1";
            dr["name"] = "-----------";
            dtBirthPalce.Rows.InsertAt(dr, 0);
            cmbBirthPlace.DataSource = dtBirthPalce;
            cmbBirthPlace.DisplayMember = "name";
            cmbBirthPlace.ValueMember = "Code";

            DataTable dtIssuPlace = new DataTable();
            dtIssuPlace = (new JCities()).GetList();
            DataRow drIssue;
            drIssue = dtIssuPlace.NewRow();
            drIssue["Code"] = "-1";
            drIssue["name"] = "-----------";            
            dtIssuPlace.Rows.InsertAt(drIssue, 0);
            cmbIssuPlace.DataSource = dtIssuPlace;
            cmbIssuPlace.DisplayMember = "name";
            cmbIssuPlace.ValueMember = "Code";

            DataTable dtHCity = new DataTable();
            dtHCity = (new JCities()).GetList();
            DataRow drHCity;
            drHCity = dtHCity.NewRow();
            drHCity["Code"] = "-1";
            drHCity["name"] = "-----------";
            dtHCity.Rows.InsertAt(drHCity, 0);
            cmbHCity.DataSource = dtHCity;
            cmbHCity.DisplayMember = "name";
            cmbHCity.ValueMember = "Code";

            DataTable dtWCity = new DataTable();
            dtWCity = (new JCities()).GetList();
            DataRow drWCity;
            drWCity = dtWCity.NewRow();
            drWCity["Code"] = "-1";
            drWCity["name"] = "-----------";
            dtWCity.Rows.InsertAt(drWCity, 0);
            cmbWCity.DataSource = dtWCity;
            cmbWCity.DisplayMember = "name";
            cmbWCity.ValueMember = "Code";
        }
        /// <summary>
        /// نمایش فیلدها در داخل تکست باکسها
        /// </summary>
        private void _ShowData()
        {
            JPerson person = new JPerson(_PCode);
            txtCode.Text = person.Code.ToString();
            txtName.Text = person.Name;
            txtLastName.Text = person.Fam;
            txtFatherName.Text = person.FatherName;
            txtIDNo.Text = person.ShSh;
            txtNationalCode.Text = person.ShMeli;
            txtBirthDate.Text = JDateTime.FarsiDate(person.BthDate);
            cmbBirthPlace.SelectedValue = person.BirthplaceCode;
            cmbIssuPlace.SelectedValue = person.Sader;
            rbMan.Checked = person.Gender;
        }

        private void JPersonIn_Load(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtLastName.Text.Trim() == "")
            {
                string[] parameters = { "@Value" };
                string[] values = { JLanguages._Text("LastName") };                
                string msg = JLanguages._Text("PleaseEnter", parameters, values);
                JMessages.Error(msg, "Error");
                txtLastName.Focus();
                return;
            }
            /// درج شخص جدید
            if (State == JFormState.Insert)
            {
                JPerson person = new JPerson();
                person.Name = txtName.Text;
                person.Fam = txtLastName.Text;
                person.ShSh = txtIDNo.Text;
                person.FatherName = txtFatherName.Text;
                person.ShMeli = txtNationalCode.Text;
                person.BthDate = txtBirthDate.Date;
                person.BirthplaceCode =Convert.ToInt32(cmbBirthPlace.SelectedValue);
                person.Sader = Convert.ToInt32(cmbIssuPlace.SelectedValue);
                person.Gender=rbMan.Checked;
                
                person.HAddress = txtHAddress.Text;
                person.MCity = Convert.ToInt32(cmbHCity.SelectedValue);
                person.HPostalCode = txtHPostalCode.Text;
                person.HTel = txtHTel.Text;
                person.HFax = txtHFax.Text;
                person.Mobile = txtMobile.Text;
                person.HEmail = txtHEmail.Text;

                person.WAddress = txtWAddress.Text;
                person.WCity = Convert.ToInt32(cmbWCity.SelectedValue);
                person.WPostCode = txtWPostalCode.Text;
                person.WTel = txtWTel.Text;
                person.WFax = txtFax.Text;
                person.WWebSite = txtWWebSite.Text;
                person.WEmail = txtWEmail.Text;

                _PCode = person.insert();
                if (_PCode > 0)
                {
                    txtCode.Text = _PCode.ToString();
                    btnSave.Enabled = false;
                    State = JFormState.Update;
                    return;
                }
                else
                    if (_PCode == -1)
                    {
                        JMessages.Error("PersonExists", "Error");
                    }
            }
            /// ویرایش شخص جاری
            if (State == JFormState.Update)
            {
                JPerson person = new JPerson();
                person.Code = _PCode;
                person.Name = txtName.Text;
                person.Fam = txtLastName.Text;
                person.ShSh = txtIDNo.Text;
                person.FatherName = txtFatherName.Text;
                person.ShMeli = txtNationalCode.Text;
                person.BthDate = txtBirthDate.Date;
                person.BirthplaceCode = Convert.ToInt32(cmbBirthPlace.SelectedValue);
                person.Sader = Convert.ToInt32(cmbIssuPlace.SelectedValue);
                person.Gender = rbMan.Checked;
                person.Update();
            }

        }

        private void txtHEmail_Leave(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabWAddress;
        }

        private void txtWEmail_Leave(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabImages;
        }

        private void txtFatherName_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtHAddress_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (State == JFormState.Insert)
            {
                dataGridView1.DataSource = JPerson.SearchPerson(0, txtName.Text, txtLastName.Text, txtFatherName.Text, txtIDNo.Text,
                     Convert.ToInt32(cmbBirthPlace.SelectedValue), txtBirthDate.Date, DateTime.MinValue,
                     Convert.ToInt32(cmbIssuPlace.SelectedValue), txtNationalCode.Text);
            }
        }

      
    
    }
}
