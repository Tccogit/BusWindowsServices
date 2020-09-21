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
    public partial class JSignatureMenForm : JBaseForm
    {
        /// <summary>
        /// سازنده فرم
        /// </summary>
        /// <param name="pPCode">کد شخص حقوقی</param>
        public JSignatureMenForm(int pPCode)
        {
            InitializeComponent();
            _Person = new JPerson(pPCode);
        }

        public JSignatureMenForm(int pCode, int pPCode)
        {
            InitializeComponent();
            //_PCode = pPCode;
            _Person = new JPerson(pPCode);
            _signMan.Code = pCode;
            _signMan.GetData(pCode);
            _ShowData();
        }

        public JSignatureMenForm(JSignatureMen pSignMan)
        {
            InitializeComponent();
            _signMan = pSignMan;
            _Person = new JPerson(pSignMan.SignPCode);
            //_PCode = pSignMan.PCode;
            _ShowData();
        }

        private void _ShowData()
        {
            try
            {
                //txtFatherName.Text = _signMan.FatherName;
                //txtLastName.Text = _signMan.LastName;
                //txtName.Text = _signMan.FirstName;
                //txtShSh.Text = _signMan.IDNo;
                txtCode.Text = _signMan.SignPCode.ToString();
                txtFatherName.Text = _Person.FatherName;
                txtLastName.Text = _Person.Fam;
                txtName.Text = _Person.Name;
                txtShSh.Text = _Person.ShSh;
                
                txtDesc.Text = _signMan.Description;
                txtPost.Text = _signMan.Post;
                checkBox1.Checked = _signMan.Active;

                txtFromDate.Text =JDateTime.FarsiDate(_signMan.FromDate);
                txtToDate.Text = JDateTime.FarsiDate(_signMan.ToDate);
            }
            catch
            {
            }
        }
        public JSignatureMen Result;
        /// <summary>
        /// کد شخص حقوقی
        /// </summary>
        //private int _PCode;
        private JPerson _Person;
        private JSignatureMen _signMan = new JSignatureMen();

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Trim() == "")
            {
                string[] parameters = { "@Value" };
                string[] values = { "PersonCode" };
                string msg = JLanguages._Text("PleaseEnter", parameters, values);
                JMessages.Error(msg, "Error");
                txtCode.Focus();
                return;
            }
            if(txtFromDate.Date!=DateTime.MinValue && txtToDate.Date !=DateTime.MinValue)
                if (txtToDate.Date < txtFromDate.Date)
                {
                    JMessages.Error("لطفا تاریخ شروع و پایان را بصورت صحیح وارد کنید. ", "خطا");
                    return;
                }
            if (State == JFormState.Insert)
                _signMan.Code = 0;
            if (State == JFormState.Update)
                _signMan.Changed = true;
            _signMan.FirstName = txtName.Text;
            _signMan.LastName = txtLastName.Text;
            _signMan.IDNo = txtShSh.Text;
            _signMan.FatherName = txtFatherName.Text;
            _signMan.Description = txtDesc.Text;
            _signMan.Post = txtPost.Text;
            _signMan.Active = checkBox1.Checked;
            _signMan.SignPCode = txtCode.IntValue;
            _signMan.FromDate = txtFromDate.Date;
            _signMan.ToDate = txtToDate.Date;
            Result = _signMan;
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private bool _CheckPersonCode(int pPCode)
        {
            if (!_Person.getData(pPCode))
            {
                JMessages.Error("PersonDoesNotExists", "Error");
                return false;
            }
            return true;
        }
        private void btnPerson_Click(object sender, EventArgs e)
        {
            JFindPersonForm searchForm = new JFindPersonForm(JPersonTypes.RealPerson);
            if (searchForm.ShowDialog() == DialogResult.OK)
            {
                txtCode.Text = searchForm.SelectedPerson.Code.ToString();
                if (_CheckPersonCode(searchForm.SelectedPerson.Code))
                {
                    _signMan.SignPCode = searchForm.SelectedPerson.Code;
                    _ShowData();
                }
            }
        }
    }
}
