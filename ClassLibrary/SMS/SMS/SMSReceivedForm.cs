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
    public partial class SMSReceivedForm : ClassLibrary.JBaseForm
    {
        int _Code, _ReferCode;
        string _Sender_Number;
        public const string _ConstClassName = "ClassLibrary.SMS.JSMSPatternCheck_WF";

        public SMSReceivedForm()
            : this(0)
        { }

        public SMSReceivedForm(int code)
        {
            InitializeComponent();
            _Code = code;
            if (_Code > 0) _ReferCode = (new Automation.JARefer()).FindRefer(_ConstClassName, _Code);
        }

        public SMSReceivedForm(int code, int referCode)
        {
            InitializeComponent();
            _Code = code;
            _ReferCode = referCode;
        }

        private void _ChangeFormView(string State)
        {
            if (State.ToLower() == "norefer")
            {
                btnRefer.Enabled = false;
            }
            else if (State.ToLower() == "norefernoreply")
            {
                btnRefer.Enabled = false;
                btnReply.Enabled = false;
            }
            else if (State.ToLower() == "noreply")
            {
                btnReply.Enabled = false;
            }

        }

        private void Refer()
        {
            DataTable _DT = JSMSesReceiveds.GetCustomDataTable("Code=" + _Code);

            Automation.JARefer jaRefer = new Automation.JARefer(_ReferCode);
            Automation.JWorkFlow jWorkFlow = new Automation.JWorkFlow();
            jWorkFlow.GetData(jaRefer.WorkFlowCode, "", 0);

            Automation.Refer.frmRecieverSelector frmrs =
                new Automation.Refer.frmRecieverSelector
                    (_DT, null, _ConstClassName, jWorkFlow.DynamicClassCode, _Code, "پیام کوتاه دریافتی", _ReferCode);
            if (frmrs.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                _ChangeFormView("NoReferNoReply");
                _ReferCode = frmrs.ReferCode;
                jRefersTextRTB1.LoadRefer(frmrs.ReferCode);
            }
        }

        private void _SetForm()
        {
            if (_Code > 0)
            {
                JSMSesReceived jSMSesReceived = new JSMSesReceived(_Code);
                txtMessage.Text = jSMSesReceived.SMS_Text;
                lblNumber.Text = "شماره : " + jSMSesReceived.Sender_Number;
                lblSendDate.Text = "تاریخ ارسال : " + JDateTime.FarsiDate(jSMSesReceived.Send_Date) + " " + jSMSesReceived.Send_Date.ToString("HH:mm:ss");
                lblSender.Text = "فرستنده : " + jSMSesReceived.Sender_Full_Title;
                dgrRecentMessages.DataSource = JSMSesReceiveds.GetRecentMessage(jSMSesReceived.Sender_Number);
                _Sender_Number = jSMSesReceived.Sender_Number;

                if (jSMSesReceived.Status == 3)
                {
                    _ChangeFormView("NoReply");
                }
                if (_ReferCode > 0)
                {
                    jRefersTextRTB1.LoadRefer(_ReferCode);

                    Automation.JARefer jaRefer = new Automation.JARefer(_ReferCode);
                    if (jaRefer.receiver_post_code != JMainFrame.CurrentPostCode
                        || jaRefer.status == ClassLibrary.Domains.JAutomation.JReferStatus.Sent)
                    {
                        _ChangeFormView("NoReferNoReply");
                    }
                }
            }
        }

        private void SMSReceivedForm_Load(object sender, EventArgs e)
        {
            _SetForm();
        }

        private void btnRefer_Click(object sender, EventArgs e)
        {
            Refer();
        }

        private void btnReply_Click(object sender, EventArgs e)
        {
            QuickSMSForm quickSMSForm = (new QuickSMSForm(_Sender_Number, "ClassLibrary.SMS.SMSReceivedForm", _Code, 8));
            if (quickSMSForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                JSMSesReceived jSMSesReceived = new JSMSesReceived(_Code);
                jSMSesReceived.Status = 3;
                bool result = jSMSesReceived.Update();
                _ChangeFormView("NoReply");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgrRecentMessages_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgrRecentMessages.SelectedRows.Count > 0)
                (new SMSReceivedForm(Convert.ToInt32(dgrRecentMessages.SelectedRows[0].Cells["Code"].Value))).ShowDialog();
        }

    }
}
