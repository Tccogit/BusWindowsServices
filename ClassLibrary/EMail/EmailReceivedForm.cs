using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary.EMail
{
    public partial class EmailReceivedForm : ClassLibrary.JBaseForm
    {
        int _Code, _ReferCode;

        public const string _ConstClassName = "ClassLibrary.EMail.JEMailManager";

        public EmailReceivedForm()
            : this(0)
        { }

        public EmailReceivedForm(int code)
        {
            InitializeComponent();
            _Code = code;
            if (_Code > 0) _ReferCode = (new Automation.JARefer()).FindRefer(_ConstClassName, _Code, 0);
        }

        public EmailReceivedForm(int code, int referCode)
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
            DataTable _DT = JEMailReceiveds.GetCustomDataTable("Code=" + _Code);

            Automation.JARefer jaRefer = new Automation.JARefer(_ReferCode);
            Automation.JWorkFlow jWorkFlow = new Automation.JWorkFlow();
            jWorkFlow.GetData(jaRefer.WorkFlowCode, "", 0);

            Automation.Refer.frmRecieverSelector frmrs =
                new Automation.Refer.frmRecieverSelector
                    (_DT, null, _ConstClassName, jWorkFlow.DynamicClassCode, _Code, "ایمیل دریافتی", _ReferCode);
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
                JEMailReceived jEMailReceived = new JEMailReceived(_Code);
                webBrowser1.DocumentText = (jEMailReceived.HTML == null || jEMailReceived.HTML == "" ? jEMailReceived.Text : jEMailReceived.HTML);
                webBrowser1.Document.RightToLeft = true;
                if (jEMailReceived.Relevant_Person_Code > 0)
                {
                    JAllPerson jallPerson = new JAllPerson(jEMailReceived.Relevant_Person_Code);
                    txtFrom.Text = jallPerson.Name + " - " + jEMailReceived.MessageFrom;
                    btnRelevantPerson.Visible = false;
                }
                else
                {
                    txtFrom.Text = jEMailReceived.MessageFrom;
                    btnRelevantPerson.Visible = true;
                }
                txtTo.Text = jEMailReceived.MessageTo;
                txtSubject.Text = jEMailReceived.Subject;
                lblDate.Text = "تاریخ ارسال: " + JDateTime.FarsiDate(jEMailReceived.DateSent);

                jArchiveList1.DataBaseClassName = "Email";
                jArchiveList1.DataBaseObjectCode = 0;
                jArchiveList1.ClassName = JEMailManager._ConstClassName;
                jArchiveList1.ObjectCode = _Code;
                jArchiveList1.LoadList();

                if (jEMailReceived.Status == 3)
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

        private void EmailReceivedForm_Load(object sender, EventArgs e)
        {
            _SetForm();
        }

        private void btnRefer_Click(object sender, EventArgs e)
        {
            Refer();
        }

        private void btnReply_Click(object sender, EventArgs e)
        {
            EmailSendForm emailSendForm = new EmailSendForm(_Code, true);
            emailSendForm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRelevantPerson_Click(object sender, EventArgs e)
        {
            ClassLibrary.JFindPersonForm jFindPersonForm = new JFindPersonForm();
            jFindPersonForm.ShowDialog();
            JEMailReceived jEMailReceived = new JEMailReceived(_Code);
            if (jFindPersonForm.SelectedPerson.Code > 0)
            {
                jEMailReceived.Relevant_Person_Code = jFindPersonForm.SelectedPerson.Code;
                jEMailReceived.Update();

                if (jEMailReceived.Relevant_Person_Code > 0)
                {
                    txtFrom.Text = jFindPersonForm.SelectedPerson.Name + " - " + jEMailReceived.MessageFrom;
                    btnRelevantPerson.Visible = false;
                }
                else
                {
                    txtFrom.Text = jEMailReceived.MessageFrom;
                    btnRelevantPerson.Visible = true;
                }
            }
        }
    }
}
