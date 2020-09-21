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
    public partial class JShiftForm : ClassLibrary.JBaseForm
    {
        int _Code;
        public JShiftForm()
        {
            InitializeComponent();
        }
        public JShiftForm(int pCode)
        {
            InitializeComponent();
            _Code = pCode;
            LoadData();
        }

        private void LoadData()
        {
            JShift shift = new JShift(_Code);
            txtTitle.Text = shift.Title;
            txtStartTime.Text = shift.StartTime.ToString();
            txtEndTime.Text = shift.EndTime.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            JShift shift = new JShift(_Code);
            shift.Title = txtTitle.Text;
            TimeSpan time = new TimeSpan();
            if (TimeSpan.TryParse(txtStartTime.Text, out time))
                shift.StartTime = time;
            else
            {
                JMessages.Error("لطفا زمان شروع را بصورت صحیح وارد کنید.", "");
                return;
            }
            if (TimeSpan.TryParse(txtEndTime.Text, out time))
                shift.EndTime = time;
            else
            {
                JMessages.Error("لطفا زمان پایان را بصورت صحیح وارد کنید.", "");
                return;
            }
            if (_Code > 0)
                shift.Update();
            else
                shift.Insert(false);
        }
    }
}
