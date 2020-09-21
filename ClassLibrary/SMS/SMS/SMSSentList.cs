using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary.SMS
{
    public partial class SMSSentList : ClassLibrary.JBaseForm
    {
        public int _SMSesCode;
        public SMSSentList()
        {
            InitializeComponent();
        }

        private void SMSSentList_Load(object sender, EventArgs e)
        {
            DataTable DT = (new JSMSess()).GetDataTable();
            DT.Columns.Add("FullTitle");
            DT.Columns["FullTitle"].Expression = "Register_Date_Time + ' - ' + SMS_Text";
            cmbSMS.DataSource = DT;
            cmbSMS.DisplayMember = "FullTitle";
            cmbSMS.ValueMember = "Code";
        }

        private void cmbSMS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSMS.SelectedIndex >= 0 && cmbSMS.SelectedValue.GetType() != typeof(DataRowView))
            {
                _SMSesCode = Convert.ToInt32(cmbSMS.SelectedValue);
                dgrSentList.DataSource = JSMSesDetailss.GetDataTableForView(_SMSesCode);
                dgrSentList.Columns[0].Visible = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
