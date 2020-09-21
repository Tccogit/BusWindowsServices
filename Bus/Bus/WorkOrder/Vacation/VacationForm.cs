using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BusManagment.WorkOrder
{
    public partial class JVacationForm : JBaseForm
    {
        int _Code;
        int _DriverPCode;
        public JVacationForm()
        {
            InitializeComponent();
            LoadComboBox();
        }

        public JVacationForm(int pCode, int pDriverPCode)
        {
            InitializeComponent();
            _Code = pCode;
            _DriverPCode = pDriverPCode;
            ShowData();
            LoadComboBox();
        }

        private void ShowData()
        {
            JAUTVacation vacation = new JAUTVacation(_Code);
            personDriver.SelectedCode = vacation.DriverPCode;
            txtFromDate.Date = vacation.FromDate;
            txtFromTime.Text = vacation.FromDate.ToString("HH:mm");
            txtToDate.Date = vacation.ToDate;
            txtToTime.Text = vacation.ToDate.ToString("HH:mm");
            txtDesc.Text = vacation.Description;
            cmbVationType.SelectedValue = vacation.VacationType;
        }

        private void LoadComboBox()
        {
            personDriver.Text = "راننده";
            personDriver.FilterPerson = " Code IN (Select PersonCode From AUTPersonel)";

            JAUTVacation vacation = new JAUTVacation(_Code);
            BusManagment.WorkOrder.JVacationTypes types = new JVacationTypes();
            types.SetComboBox(cmbVationType, vacation.VacationType);

            if (_Code == 0)
            {
                txtFromDate.Date = (new JDataBase()).GetCurrentDateTime();
                txtToDate.Date = txtFromDate.Date;
                txtFromTime.Text = "00:00";
                txtToTime.Text = "23:59";
            }
            else
                personDriver.Enabled = false;
            if (_DriverPCode > 0)
                personDriver.SelectedCode = _DriverPCode;
        }

        private bool Validate()
        {
            if (personDriver.SelectedCode == 0)
            {
                JMessages.Error("لطفاً راننده را انتخاب کنید.", "");
                return false;
            }
            if (cmbVationType.SelectedValue == null)
            {
                JMessages.Error("لطفاً نوع مرخصی را انتخاب کنید.", "");
                return false;
            }
            if (txtFromDate.Date == DateTime.MinValue)
            {
                JMessages.Error("لطفاً تاریخ شروع را وارد کنید.", "");
                return false;
            }
            if (txtFromTime.Text == "")
            {
                JMessages.Error("لطفاً ساعت شروع را وارد کنید.", "");
                return false;
            }
            if (txtToDate.Date == DateTime.MinValue)
            {
                JMessages.Error("لطفاً تاریخ پایان را وارد کنید.", "");
                return false;
            }
            if (txtToTime.Text == "")
            {
                JMessages.Error("لطفاً ساعت پایان را وارد کنید.", "");
                return false;
            }
            if (JDateTime.GregorianDate(txtFromDate.Text, txtFromTime.Text) >= JDateTime.GregorianDate(txtToDate.Text, txtToTime.Text))
            {
                JMessages.Error("لطفاً تاریخ شروع و پایان را بصورت صحیح وارد کنید.", "");
                return false;
            }
            return true;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                JAUTVacation vacation = new JAUTVacation(_Code);
                vacation.Description = txtDesc.Text;
                vacation.DriverPCode = personDriver.SelectedCode;
                vacation.FromDate = JDateTime.GregorianDate(txtFromDate.Text, txtFromTime.Text);
                vacation.ToDate = JDateTime.GregorianDate(txtToDate.Text, txtToTime.Text);
                vacation.VacationType = Convert.ToInt32(cmbVationType.SelectedValue);
                if (_Code == 0)
                {
                    if (vacation.Insert(_DriverPCode>0) > 0)
                    {
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else
                    {
                        JMessages.Error("عملیات ثبت با مشکل مواجه شده است", "");
                    }
                }
                else
                {
                    if(vacation.Update())
                    {
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else
                    {
                        JMessages.Error("عملیات ثبت با مشکل مواجه شده است", "");
                    }

                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
