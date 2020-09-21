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
    public partial class JPersonForm : JBaseForm
    {
        /// <summary>
        /// 
        /// </summary>
        private JPerson _Person;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCode">0 = فرد نامشخص</param>
        public JPersonForm(JPerson pPerson)
        {
            InitializeComponent();
            ShowItems();
            _Person = pPerson;

            if (_Person.Code>0)
                ShowData();
        }
        /// <summary>
        /// پر کردن آیتمهای مدرک و رشته تحصیلی
        /// </summary>
        private void ShowItems()
        {

        }

        private void ShowData()
        {
            cmbBirth.Sorted = true;
            JCities Cities = new JCities();
            foreach (JSubBaseDefine BS in Cities.Items)
            {
                cmbBirth.Items.Add(BS);
                if (BS.Code == _Person.BirthplaceCode)
                    cmbBirth.SelectedItem = BS;
            }

            txtCode.Text = _Person.Code.ToString();
            txtName.Text = _Person.Name;
            txtFam.Text=_Person.Fam;
            txtFatherName.Text=_Person.FatherName;
            txtBirthDate.Text=_Person.BthDate;
            txtShMeli.Text=_Person.ShMeli;
            txtShSh.Text=_Person.ShSh;
            rdoMen.Checked = _Person.Gender;
            rdoWomen.Checked = (!_Person.Gender);
            btnSave.Enabled = false;
            //txtCode.Enabled = true;
            if (txtName.Enabled)
                txtName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            JPerson oldPerson = new JPerson(_Person.Code);
            
//            oldPerson = _Person;            
            _Person.Name = txtName.Text;
            _Person.Fam = txtFam.Text;
            _Person.FatherName = txtFatherName.Text;
            _Person.ShSh = txtShSh.Text;
            _Person.BirthplaceCode =((JSubBaseDefine) cmbBirth.SelectedItem).Code;
            _Person.ShMeli = txtShMeli.Text;
            _Person.BthDate = txtBirthDate.Text;
            _Person.Gender = rdoMen.Checked;

            if (State == JFormState.Insert)
            {
                txtCode.Text = _Person.insert().ToString();

            }
            if (State == JFormState.Update)
            {
                _Person.Update(oldPerson);
            }
            btnSave.Enabled = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtBirthDate_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void cmbBirth_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void JPersonForm_Load(object sender, EventArgs e)
        {

        }


    }
}
