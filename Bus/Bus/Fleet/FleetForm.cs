using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BusManagment.Fleet
{
    public partial class JFleetForm :ClassLibrary.JBaseForm
    {
        private int Code;
        public JFleetForm()
        {
            InitializeComponent();
            State = ClassLibrary.JFormState.Insert;
            JFleetTypes types = new JFleetTypes();
            types.SetComboBox(cmbFleetType);
        }

        public JFleetForm(int PCode)
        {
            InitializeComponent();
            Code = PCode;
            LoadData(Code);
            State = ClassLibrary.JFormState.Update;
        }
        public void LoadData(int Code) {
            JFleet objFleet = new JFleet();
            objFleet.GetData(Code);
            txtName.Text = objFleet.Name.ToString();
            DateStart.Date =objFleet.StartDate;
            DateEnd.Date = objFleet.EndDate;
            JFleetTypes types = new JFleetTypes();
            types.SetComboBox(cmbFleetType, objFleet.FleetType);
        }

        public void Delete()
        {
            if (ClassLibrary.JMessages.Question("آیا تمایل دارید مورد انتخاب شده حذف گردد", "اخطار!") == System.Windows.Forms.DialogResult.Yes)
            {
                JFleet objAutoDefine = new JFleet();
                objAutoDefine.Code = Code;
                if (objAutoDefine.Delete())
                {
                    Close();
                }
                else
                {
                    ClassLibrary.JMessages.Message("پردازش با خطا مواجه شد" , "" , ClassLibrary.JMessageType.Error);
                }
            }
            else
            {
                Close();
            }
        }
        private void SetData(JFleet objFleet) {
            objFleet.Code = Code;
            objFleet.Name =txtName.Text;
            objFleet.StartDate = DateStart.Date;
            objFleet.EndDate = DateEnd.Date;
            if (cmbFleetType.SelectedValue != null)
                objFleet.FleetType = Convert.ToInt32(cmbFleetType.SelectedValue);
        }

        private bool Validation()
        {
            bool result = true;

            if (result && (txtName.Text == null || txtName.Text.Trim() == string.Empty))
            {
                result = false;
                txtName.Focus();
               ClassLibrary.JMessages.Error("لطفاً عنوان را وارد کنید.", "");
            }

            if (result && DateStart.Date != DateTime.MinValue && !DateStart.IsValidDate())
            {
                result = false;
                DateStart.Focus();
                ClassLibrary.JMessages.Error("تاریخ آغاز معتبر نیست", "");
            }

            if (result && DateEnd.Date != DateTime.MinValue && !DateEnd.IsValidDate())
            {
                result = false;
                DateEnd.Focus();
                ClassLibrary.JMessages.Error("تاریخ پایان معتبر نیست", "");
            }

            if (DateEnd.Date != DateTime.MinValue && DateStart.Date > DateEnd.Date)
            {
                ClassLibrary.JMessages.Error("لطفا تاریخ شروع و پایان را بصورت صحیح وارد کنید", "خطا");
                return false;
            }
            return result;
        }

        private int Save()
        {
            JFleet objAutoDefine = new JFleet();
            SetData(objAutoDefine);
            if (State == ClassLibrary.JFormState.Insert)
                Code = objAutoDefine.Insert();
            else
                if (State == ClassLibrary.JFormState.Update)
                    objAutoDefine.Update();
            State = ClassLibrary.JFormState.Update;
            return Code;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                Save();
                Close();
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (Validation())
                Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
