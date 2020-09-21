using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ArchivedDocuments;

namespace ClassLibrary
{
    public partial class JOtherPersonForm : ClassLibrary.JBaseForm
    {
        public JOtherPersonForm()
        {
            InitializeComponent();
            _Person = new JOtherPerson();            
        }
        public JOtherPersonForm(JOtherPerson pPerson)        
        {
            InitializeComponent();
            _Person = pPerson;            
            _ShowData();
            State = JFormState.Update;
        }

        public JOtherPerson _Person;
        /// <summary>
        /// نام شخص انتخاب شده
        /// </summary>
        public JAllPerson SelectedPerson;// { get; set; }
                            
        /// <summary>
        /// نمایش فیلدها در داخل تکست باکسها
        /// </summary>
        private void _ShowData()
        {
            try
            {
                txtCode.Text = _Person.Code.ToString();
                txtTel.Text = _Person.Phone;
                txtTitle.Text = _Person.Title;
                txtDesc.Text = _Person.Description;
                txtHAddress.Text = _Person.Address;
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
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
            /// نام خوانوادگی
            if (txtTitle.Text.Trim() == "")
            {
                string[] parameters = { "@Value" };
                string[] values = { "LastName" };
                string msg = JLanguages._Text("PleaseEnter", parameters, values);
                JMessages.Error(msg, "Error");
                txtTitle.Focus();
                return false;
            }
            return true;
        }

        private int _Save()
        {
            if (!_CheckControlValues())
                return 0;

            #region Set Control Values To Properties
            _Person.Phone = txtTel.Text.Trim();
            _Person.Title = txtTitle.Text.Trim(); ;
            _Person.Description = txtDesc.Text.Trim();
            _Person.Address = txtHAddress.Text.Trim();

            #endregion Set Control Values To Properties

            /// درج شخص جدید
            if (State == JFormState.Insert)
            {              
                int _PCode = _Person.insert();
                if (_PCode > 0)
                {
                    _Person.Code = _PCode;                    
                    _Person.Update(false);                  
                    txtCode.Text = _PCode.ToString();
                    btnSave.Enabled = false;
                    State = JFormState.Update;                   
                    return _PCode;                
                }
                return 0;
            }            
            /// ویرایش شخص جاری
            else if (State == JFormState.Update)
            {                
                if (_Person.Update())
                {                   
                    btnSave.Enabled = false;
                    return _Person.Code;
                }
                return 0;
            }
            return 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int Code = _Save();
            if (Code > 0)
            {
                SelectedPerson = new JAllPerson(Code);
                State = JFormState.Update;
            }
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
            try
            {
                if (State == JFormState.Insert)
                {
                    grdPerson.DataSource = JOtherPerson.SearchPerson(0, txtTitle.Text, txtTel.Text, txtHAddress.Text, txtDesc.Text);                   
                    //grdPerson.Columns["Title"].Visible = false;
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
                _Person = null;
                _Person = new JOtherPerson();
                txtCode.Text = "";
                txtDesc.Text = "";
                txtHAddress.Text = "";                
                txtTitle.Text = "";
                txtTel.Text = "";
            }
            catch
            {
            }               
        }
        private void btnSaveNew_Click(object sender, EventArgs e)
        {          
            DialogResult = DialogResult.Retry;
        }

        private void btnDelNew_Click(object sender, EventArgs e)
        {
            if (_Person.Delete())
            {
                _ClearForm();
                State = JFormState.Insert;
                txtTitle.Focus();
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
            if (grdPerson.SelectedRows != null)
                {
                    //JOtherPerson tmp = new JOtherPerson(Convert.ToInt32(grdPerson.CurrentRow.Cells[1].Value));
                    if (Convert.ToInt32(grdPerson.CurrentRow.Cells[0].Value) > 0)
                    {
                        #region Set Control Values To Properties
                        
                        _Person.Phone = grdPerson.CurrentRow.Cells[2].Value.ToString();
                        _Person.Title = grdPerson.CurrentRow.Cells[1].Value.ToString();
                        _Person.Description = grdPerson.CurrentRow.Cells[3].Value.ToString();
                        _Person.Address = grdPerson.CurrentRow.Cells[4].Value.ToString();
                        _Person.Code = Convert.ToInt32(grdPerson.CurrentRow.Cells[0].Value);
                        btnSave.Enabled = false;
                        Close();
                        #endregion Set Control Values To Properties                                      
                    }
                }            

        }
    }
}
