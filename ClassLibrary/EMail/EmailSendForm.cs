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
    public partial class EmailSendForm : ClassLibrary.JBaseForm
    {
        int _Code, _ReferCode, _ParentCode;

        public const string _ConstClassName = "ClassLibrary.EMail.JEMailSend";

        public EmailSendForm() : this(0, false) { }

        public EmailSendForm(int code) : this(code, false) { }

        public EmailSendForm(int code, bool isReply)
        {
            InitializeComponent();
            if (isReply)
            {
                _ParentCode = code;
            }
            else
                _Code = code;

            if (_Code > 0) _ReferCode = (new Automation.JARefer()).FindRefer(_ConstClassName, _Code, 0);
        }

        public EmailSendForm(int code, int referCode)
        {
            InitializeComponent();
            _Code = code;
            _ReferCode = referCode;
        }

        private bool Save()
        {
            JEMailSend jEMailSend;
            if (_Code > 0)
                jEMailSend = new JEMailSend(_Code);
            else
                jEMailSend = new JEMailSend();

            //Saving Base Information
            jEMailSend.Text = txtContent.Text;
            jEMailSend.HTML = "<html><body><div style=\"font-family:Tahoma; font-size:14px\">" + txtContent.Text.Replace("\r\n", "<br/>") + "</div></body></html>";
            if (_ParentCode > 0)
                jEMailSend.Parent_EmailCode = _ParentCode;
            if (_Code <= 0)
            {
                // First Time action
                jEMailSend.Register_Post_Code = JMainFrame.CurrentPostCode;
                jEMailSend.Register_User_Code = JMainFrame.CurrentUserCode;
                jEMailSend.Register_Full_Title = JMainFrame.CurrentPostTitle;
                jEMailSend.Register_Date = JDateTime.Now();
            }
            if (cmbFrom.Items.Count > 0 && cmbFrom.SelectedIndex >= 0)
            {
                jEMailSend.MessageFrom = (new JEMail(Convert.ToInt32(cmbFrom.SelectedValue))).UserName;
                jEMailSend.EmailCode = Convert.ToInt32(cmbFrom.SelectedValue);
            }
            else
            {
                jEMailSend.MessageFrom = "";
                jEMailSend.EmailCode = 0;
            }
            jEMailSend.MessageTo = "";
            for (int i = 0; i < lsbTo.Items.Count; i++)
                jEMailSend.MessageTo = ";" + lsbTo.Items[i].ToString();
            if (jEMailSend.MessageTo.Length > 0) jEMailSend.MessageTo = jEMailSend.MessageTo.Substring(1);

            jEMailSend.Subject = txtSubject.Text;
            jEMailSend.Status = 0;

            if (_Code > 0)
            {
                if (jEMailSend.Update() == true)
                {
                    jArchiveList1.ArchiveList();
                    return true;
                }
            }
            else
            {
                _Code = jEMailSend.Insert();
                if (_Code > 0)
                {
                    jArchiveList1.DataBaseClassName = "Email";
                    jArchiveList1.DataBaseObjectCode = 0;
                    jArchiveList1.ClassName = _ConstClassName;
                    jArchiveList1.ObjectCode = _Code;
                    jArchiveList1.ArchiveList();
                    return true;
                }
            }

            return false;
        }

        private void _SetForm()
        {
            cmbFrom.DisplayMember = "Name";
            cmbFrom.ValueMember = "Code";
            cmbFrom.DataSource = JEMails.GetDataTable(JMainFrame.CurrentUserCode);
            if (_ParentCode > 0)
            {
                JEMailReceived jEMailReceived = new JEMailReceived(_ParentCode);
                lsbTo.Items.Add(jEMailReceived.MessageFrom);
                txtSubject.Text = "پاسخ: " + jEMailReceived.Subject;
                txtContent.Text = "\r\n\r\n-- " + "از: " + jEMailReceived.MessageFrom + "\r\n-- "
                    + "به: " + jEMailReceived.MessageTo + "\r\n-- " + "موضوع: " + jEMailReceived.Subject
                    + "\r\n-- " + "تاریخ: " + JDateTime.FarsiDate(jEMailReceived.DateSent) + " " + jEMailReceived.DateSent.Hour.ToString("00") + ":" + jEMailReceived.DateSent.Minute.ToString("00") + ":" + jEMailReceived.DateSent.Second.ToString("00")
                    + "\r\n-- " + jEMailReceived.Text.Replace("\r\n", "\r\n-- ");
            }

            if (_Code > 0)
            {
                JEMailSend jEMailSend = new JEMailSend(_Code);
                txtContent.Text = jEMailSend.Text;
                txtSubject.Text = jEMailSend.Subject;
                cmbFrom.SelectedText = jEMailSend.MessageFrom;
                lsbTo.Items.AddRange(jEMailSend.MessageTo.Split(';'));

                jArchiveList1.DataBaseClassName = "Email";
                jArchiveList1.DataBaseObjectCode = 0;
                jArchiveList1.ClassName = _ConstClassName;
                jArchiveList1.ObjectCode = _Code;
                jArchiveList1.LoadList();

                if (_ReferCode > 0)
                {
                    jRefersTextRTB1.LoadRefer(_ReferCode);

                    Automation.JARefer jaRefer = new Automation.JARefer(_ReferCode);
                    if (jaRefer.receiver_post_code != JMainFrame.CurrentPostCode
                        || jaRefer.status == ClassLibrary.Domains.JAutomation.JReferStatus.Sent)
                    {
                        _ChangeFormView("NoChangeNoRefer");
                    }

                }

                _SetStatus(jEMailSend);
            }
        }

        private void _SetStatus(JEMailSend jEMailSend)
        {
            if (jEMailSend.Status == Convert.ToInt32(ClassLibrary.Domains.JClassLibrary.JEMailStatus.Sent))
            {
                lblStatus.Text = "ایمیل در تاریخ " + JDateTime.FarsiDate(jEMailSend.DateSent) + " " + jEMailSend.DateSent.Hour.ToString("00") + ":" + jEMailSend.DateSent.Minute.ToString("00") + ":" + jEMailSend.DateSent.Second.ToString("00")
                    + " توسط " + jEMailSend.Sender_Full_Title + " ارسال شده است.";
                _ChangeFormView("NoChange");
            }
            else if (jEMailSend.Status == Convert.ToInt32(ClassLibrary.Domains.JClassLibrary.JEMailStatus.Draft))
            {
                lblStatus.Text = "پیش نویس";
            }
            else if (jEMailSend.Status == Convert.ToInt32(ClassLibrary.Domains.JClassLibrary.JEMailStatus.ReadyForSend))
            {
                lblStatus.Text = "در حال ارسال...";
                _ChangeFormView("NoChange");
            }
            else if (jEMailSend.Status == Convert.ToInt32(ClassLibrary.Domains.JClassLibrary.JEMailStatus.SendError))
            {
                lblStatus.Text = "ارسال ایمیل با خطا مواجه شد.";
                _ChangeFormView("NoChange");
            }
            else
            {
                lblStatus.Text = "نامشخص";
            }
        }

        private void _ChangeFormView(string State)
        {
            if (State.ToLower() == "nochange")
            {
                btnSave.Enabled = false;
                btnAddRecpt.Enabled = false;
                btnAddRecptManual.Enabled = false;
                btnDeleteRecpt.Enabled = false;
                txtContent.ReadOnly = true;
            }
            else if (State.ToLower() == "nochangenorefer")
            {
                btnRefer.Enabled = false;
                btnSave.Enabled = false;
                txtContent.ReadOnly = true;
                btnRefer.Enabled = false;
            }

        }

        private void Refer()
        {
            JEMailSend jEMailSend = new JEMailSend(_Code);

            if (jEMailSend.EmailCode == 0)
            {
                JMessages.Error("لطفا یک ایمیل به عنوان فرستنده انتخاب کنید.", "ارجاع");
                return;
            }

            DataTable _DT = JEMailSends.GetCustomeDataTable("Code=" + _Code);

            Automation.Refer.frmRecieverSelector frmrs =
                new Automation.Refer.frmRecieverSelector
                    (_DT, null, _ConstClassName, 0, _Code, "ایمیل ارسالی", _ReferCode);
            if (frmrs.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                _ChangeFormView("NoChangeNoRefer");
                _ReferCode = frmrs.ReferCode;
                jRefersTextRTB1.LoadRefer(frmrs.ReferCode);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int SpacesBefore(string text)
        {
            int i = 0;
            for (; i < text.Length; i++)
                if (text[i] != ' ') break;
            return i;
        }
        private int SpacesAfter(string text)
        {
            int i = text.Length - 1;
            for (; i >= 0; i--)
                if (text[i] != ' ') break;
            return text.Length - i - 1;
        }

        private void EmailSendForm_Load(object sender, EventArgs e)
        {
            _SetForm();
            DateTime datetime = JDateTime.Now();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Save())
                JMessages.Error("ثبت اطلاعات با خطا مواجه شد.", "ثبت");
            else
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public void SendEMail(DataTable _DT)
        {
            JEMailSend jEMailSend = new JEMailSend(Convert.ToInt32(_DT.Rows[0]["Code"]));
            jEMailSend.Status = ClassLibrary.Domains.JClassLibrary.JEMailStatus.ReadyForSend;
            jEMailSend.DateSent = JDateTime.Now();
            jEMailSend.Sender_Full_Title = JMainFrame.CurrentPostTitle;
            jEMailSend.Sender_Post_Code = JMainFrame.CurrentPostCode;
            jEMailSend.Sender_User_Code = JMainFrame.CurrentUserCode;
            jEMailSend.Update();
        }

        private void btnRefer_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled == true) Save();
            Refer();
        }

        private void btnAddRecpt_Click(object sender, EventArgs e)
        {
            JFindPersonForm jFindPersonForm = new JFindPersonForm();
            jFindPersonForm.ShowDialog();
            if (jFindPersonForm.SelectedPerson.Code > 0)
            {
                JPersonAddress jPersonAddress = new JPersonAddress(jFindPersonForm.SelectedPerson.Code);
                if (jPersonAddress.Email != null && jPersonAddress.Email.Trim().Length > 0 && lsbTo.Items.Contains(jPersonAddress.Email.Trim()) == false)
                    lsbTo.Items.Add(jPersonAddress.Email.Trim());
            }
        }

        private void btnAddRecptManual_Click(object sender, EventArgs e)
        {
            JTextInputDialogForm jTextInputDialogForm = new JTextInputDialogForm("پست الکترونیک", "", false);
            jTextInputDialogForm.ShowDialog();

            if (jTextInputDialogForm.Text.Trim().Length > 0 && lsbTo.Items.Contains(jTextInputDialogForm.Text.Trim()) == false)
                lsbTo.Items.Add(jTextInputDialogForm.Text.Trim());
        }

        private void btnDeleteRecpt_Click(object sender, EventArgs e)
        {
            if (lsbTo.SelectedIndex >= 0)
                lsbTo.Items.RemoveAt(lsbTo.SelectedIndex);
        }
    }
}
