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
    public partial class JTariffForm :ClassLibrary.JBaseForm
    {
        private int _Code; 
        public JTariffForm()
        {
            InitializeComponent();
            State = ClassLibrary.JFormState.Insert;
            LoadComboBox();

        }
        public JTariffForm(int PCode)
        {
            InitializeComponent();
            _Code = PCode;
            LoadComboBox();
            if (PCode > 0)
            {
                Load1(PCode);
                State = ClassLibrary.JFormState.Update;
                personDriver.ReadOnly = true;
            }
            else
                State = ClassLibrary.JFormState.Insert;
        }

        private void LoadComboBox()
        {
            //personDriver.ShowPersonImage = true;
            cmbBus.DataSource = BusManagment.Bus.JBuses.GetDataTable(0);
            cmbBus.DisplayMember = "BUSNumber";
            cmbBus.ValueMember = "Code";

            cmbLine.DataSource = BusManagment.Line.JLines.GetDataTable(0);
            cmbLine.DisplayMember = "LineNumber";
            cmbLine.ValueMember = "Code";

            cmbShift.DataSource = JShifts.GetDataTable(0);
            cmbShift.DisplayMember = "Title";
            cmbShift.ValueMember = "Code";

        }
        private void Load1(int PCode){
            JTariff objTarrif = new JTariff(PCode);
            //txtEndDate.Date  = objTarrif.EndDate;
            //txtStartDate.Date  = objTarrif.StartDate;
            txtStartDate.Date = objTarrif.Date;
            cmbShift.SelectedValue = objTarrif.ShiftCode;
            cmbLine.SelectedValue = objTarrif.LineCode;
            cmbBus.SelectedValue = objTarrif.BusCode;
            personDriver.SelectedCode = objTarrif.DriverCode;
        }
         
        private bool Validate()
        {
            if (personDriver.SelectedCode == 0)
            {
                JMessages.Error("لطفا راننده را انتخاب کنید", "");
                return false;
            }
            if (cmbBus.SelectedIndex == -1)
            {
                JMessages.Error("لطفا شماره اتوبوس را از لیست انتخاب کنید", "");
                return false;
            }
            if (cmbLine.SelectedIndex == -1)
            {
                JMessages.Error("لطفا شماره خط را از لیست انتخاب کنید", "");
                return false;
            }
            if (cmbShift.SelectedIndex == -1)
            {
                JMessages.Error("لطفا شیفت را از لیست انتخاب کنید", "");
                return false;
            }
            if (txtStartDate.Date == DateTime.MinValue)
            {
                JMessages.Error("لطفا تاریخ شروع را وارد کنید", "خطا");
                return false;
            }
            //if (txtEndDate.Date == DateTime.MinValue)
            //{
            //    JMessages.Error("لطفا تاریخ پایان را وارد کنید", "خطا");
            //    return false;
            //}
            if (txtEndDate.Date != DateTime.MinValue && txtStartDate.Date > txtEndDate.Date)
            {
                JMessages.Error("لطفا تاریخ شروع و پایان را بصورت صحیح وارد کنید", "خطا");
                return false;
            }
            return true;
        }
        private int Save()
        {
            if (Validate())
            {
                JTariff objAutoDefine = new JTariff(_Code);
                objAutoDefine.DriverCode = personDriver.SelectedCode;
                objAutoDefine.BusCode = (int)cmbBus.SelectedValue;
                objAutoDefine.LineCode = (int)cmbLine.SelectedValue;
                objAutoDefine.ShiftCode = (int)cmbShift.SelectedValue;
                //objAutoDefine.StartDate = txtStartDate.Date;
                //objAutoDefine.EndDate = txtEndDate.Date;
                objAutoDefine.Date = txtStartDate.Date;
                if (State == ClassLibrary.JFormState.Insert)
                {
                    _Code = objAutoDefine.Insert();
                    State = ClassLibrary.JFormState.Update;
                }
                if (State == ClassLibrary.JFormState.Update)
                {
                    if (objAutoDefine.Update())
                        return _Code;
                    else 
                        return 0;
                }
                else
                    return _Code;
            }
            else
                return 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Save() > 0)
                DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dateEnd_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void cmbShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            int shiftCode;
            if (cmbShift.SelectedValue!=null && int.TryParse(cmbShift.SelectedValue.ToString(), out shiftCode))
            {
                if (shiftCode > 0)
                {
                    JShift shift = new JShift(shiftCode);
                    lbStartTime.Text = shift.StartTime.ToString().Substring(0, 5);
                    lbEndTime.Text = shift.EndTime.ToString().Substring(0, 5);
                }

            }
        }

        private void JTariffForm_Shown(object sender, EventArgs e)
        {
            cmbShift_SelectedIndexChanged(null, null);
        }

    }
}
