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
    public partial class SMSForm : ClassLibrary.JBaseForm
    {
        bool isCanceled;
        int _Code, _ReferCode, _TotalSMSes, _TotalSMSParts, _Total;
        DataTable _Recievers;
        public const string _ConstClassName = "ClassLibrary.SMS.JSMSes";

        public SMSForm() : this(0) { }

        public SMSForm(int code)
        {
            InitializeComponent();
            _Code = code;
            if (_Code > 0) _ReferCode = (new Automation.JARefer()).FindRefer(_ConstClassName, _Code, 0);
        }

        public SMSForm(int code, int referCode)
        {
            InitializeComponent();
            _Code = code;
            _ReferCode = referCode;
        }

        private void GenerateRecieversDataTable()
        {
            _Recievers = new DataTable();
            _Recievers.Columns.Add("PersonCode");
            _Recievers.Columns.Add("PersonName");
            _Recievers.Columns.Add("Mobile");
            _Recievers.Columns.Add("Status");
            dgrMobiles.DataSource = _Recievers;
        }

        private bool Save()
        {
            JSMSes jSMSes;
            if (_Code > 0)
                jSMSes = new JSMSes(_Code);
            else
                jSMSes = new JSMSes();

            //Saving Base Information
            jSMSes.SMS_Text = txtContent.Text;
            jSMSes.SMS_Type = ClassLibrary.Domains.JClassLibrary.JSMSType.SendSMS;
            if (_Code <= 0)
            {
                jSMSes.Code = _Code;
                jSMSes.Register_User_Post_Code = JMainFrame.CurrentPostCode;
                jSMSes.Register_User_Code = JMainFrame.CurrentUserCode;
                jSMSes.Register_Full_Title = JMainFrame.CurrentPostTitle;
                jSMSes.Register_Date_Time = JDateTime.Now();
            }
            jSMSes.Status = ClassLibrary.Domains.JClassLibrary.JSMSStatus.NotSend;
            jSMSes.TotalSentSMS = _TotalSMSes;

            if (_Code > 0)
            {
                if (jSMSes.Update() == false) return false;
            }
            else
                _Code = jSMSes.Insert();

            return true;
        }

        private void _SetForm()
        {
            if (_Code > 0)
            {
                JSMSes jSMSes = new JSMSes(_Code);
                txtContent.Text = jSMSes.SMS_Text;
                _Recievers = jSMSes.SMSDetailsForView;
                dgrMobiles.DataSource = _Recievers;
                CalculateSMSes();

                if (_ReferCode > 0)
                {
                    refersText1.TotalRefers = true;
                    refersText1.LoadRefer(_ReferCode);
                    jRefersTextRTB1.LoadRefer(_ReferCode);

                    Automation.JARefer jaRefer = new Automation.JARefer(_ReferCode);
                    if (jaRefer.receiver_post_code != JMainFrame.CurrentPostCode
                        || jaRefer.status == ClassLibrary.Domains.JAutomation.JReferStatus.Sent)
                    {
                        _ChangeFormView("NoChangeNoRefer");
                    }

                }

                _SetStatus(jSMSes);
            }
        }

        private void _SetStatus(JSMSes jSMSes)
        {
            if (jSMSes.Status == Convert.ToInt32(ClassLibrary.Domains.JClassLibrary.JSMSStatus.Sent))
            {
                lblStatus.Text = "SMS در تاریخ " + JDateTime.FarsiDate(jSMSes.Send_Date_Time) + " " + jSMSes.Send_Date_Time.Hour.ToString("00") + ":" + jSMSes.Send_Date_Time.Minute.ToString("00") + ":" + jSMSes.Send_Date_Time.Second.ToString("00")
                    + " توسط " + jSMSes.Send_Full_Title + " ارسال شده است.";
                _ChangeFormView("NoChange");
            }
            else
            {
                lblStatus.Text = "SMS هنوز ارسال نشده است.";
            }
        }

        private void _ChangeFormView(string State)
        {
            if (State.ToLower() == "nochange")
            {
                panel3.Visible = false;
                btnSave.Enabled = false;
                txtContent.ReadOnly = true;
            }
            else if (State.ToLower() == "nochangenorefer")
            {
                panel3.Visible = false;
                btnRefer.Enabled = false;
                btnSave.Enabled = false;
                txtContent.ReadOnly = true;
                btnRefer.Enabled = false;
            }

        }

        private void Refer()
        {
            CalculateSMSes();

            JSMSes jSMSes = new JSMSes(_Code);

            DataTable _DT = jSMSes.GetDataTable(_Code);

            string Mobiles = "";
            foreach (DataRow item in (new JSMSes(_Code)).SMSDetailsForView.Rows)
            {
                Mobiles += item["Mobile"].ToString().Trim() + ",";
            }
            if (Mobiles.Length > 3) Mobiles = Mobiles.Substring(0, Mobiles.Length - 1);

            _DT.Columns.Add("TotalSMSParts");
            _DT.Columns.Add("TotalRecievers");
            _DT.Columns.Add("TotalSMS");
            _DT.Columns.Add("TotalSMS_Day");
            _DT.Columns.Add("TotalSMS_Month");
            _DT.Columns.Add("Mobiles");
            _DT.Columns.Add("CurrentPostCode");
            _DT.Columns.Add("isUnit");
            if (_DT.Rows.Count > 0)
            {
                _DT.Rows[0]["TotalSMSParts"] = _TotalSMSParts;
                _DT.Rows[0]["TotalRecievers"] = (new JSMSes(_Code)).SMSDetailsForView.Rows.Count;
                _DT.Rows[0]["TotalSMS"] = _TotalSMSes;
                _DT.Rows[0]["Mobiles"] = Mobiles;
                _DT.Rows[0]["CurrentPostCode"] = JMainFrame.CurrentPostCode;
                _DT.Rows[0]["TotalSMS_Day"] = JSMSess.GetTotalSMS_Day(JDateTime.Now().Year, JDateTime.Now().Month, JDateTime.Now().Day, JMainFrame.CurrentPostCode) + _TotalSMSes;
                _DT.Rows[0]["TotalSMS_Month"] = JSMSess.GetTotalSMS_Month(JDateTime.Now().Year, JDateTime.Now().Month, JMainFrame.CurrentPostCode) + _TotalSMSes;
                _DT.Rows[0]["isUnit"] = (new Employment.JEOrganizationChart(JMainFrame.CurrentPostCode)).is_unit;
            }


            Automation.Refer.frmRecieverSelector frmrs =
                new Automation.Refer.frmRecieverSelector
                    (_DT, null, _ConstClassName, 0, _Code, "پیام کوتاه ارسالی", _ReferCode);
            if (frmrs.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                _ChangeFormView("NoChangeNoRefer");
                _ReferCode = frmrs.ReferCode;
                refersText1.TotalRefers = true;
                refersText1.LoadRefer(frmrs.ReferCode);
            }
        }

        private void CalculateSMSes()
        {
            int txtLength = Convert.ToInt32(txtContent.Text.Length);

            lblSMSChars.Text = "تعداد کاراکتر: " + txtContent.Text.Length.ToString() + " (هر اس ام اس " + (txtLength <= 70 ? "70" : "67") + " کاراکتر)";
            if (txtLength <= 70)
                _TotalSMSParts = 1;
            else
                _TotalSMSParts = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(txtLength) / 67));
            lblTotalSMS.Text = "تعداد SMSها: " + _TotalSMSParts.ToString() + " عدد";
            _TotalSMSes = _TotalSMSParts * _Recievers.Rows.Count;
            lblTotalSMSxRecievers.Text = "تعداد SMSها در گیرندگان: " + _TotalSMSes.ToString() + " عدد";
            lblSpacesBefore.Text = "تعداد فاصله ها قبل از متن: " + SpacesBefore(txtContent.Text).ToString() + " عدد";
            lblSpacesAfter.Text = "تعداد فاصله ها بعد از متن: " + SpacesAfter(txtContent.Text).ToString() + " عدد";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtContent_TextChanged(object sender, EventArgs e)
        {
            CalculateSMSes();
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

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            try
            {
                JFindPersonForm JFPF = new JFindPersonForm();
                JFPF.MultiSelect = true;
                JFPF.ShowDialog();
                if (JFPF.SelectedPersonsCode.Length != 0)
                {
                    if (_Code == 0)
                    {
                        Save();
                        if (_Code == 0) return;
                    }

                    for (int i = 0; i < JFPF.SelectedPersonsCode.Length; i++)
                    {
                        JAllPerson Person = new JAllPerson(JFPF.SelectedPersonsCode[i]);
                        JPersonAddress jPersonAddress = new JPersonAddress(JFPF.SelectedPersonsCode[i]);
                        JSMSesDetails jSMSesDetails = new JSMSesDetails();
                        jSMSesDetails.Mobile = jPersonAddress.Mobile;
                        jSMSesDetails.PersonCode = Person.Code;
                        jSMSesDetails.SMS_Code = _Code;
                        jSMSesDetails.SMSSendCode = 0;
                        jSMSesDetails.Insert();
                    }
                    _Recievers = (new JSMSes(_Code)).SMSDetailsForView;
                    dgrMobiles.DataSource = _Recievers;
                    dgrMobiles.Refresh();
                    CalculateSMSes();
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);

            }

        }

        private void SMSForm_Load(object sender, EventArgs e)
        {
            GenerateRecieversDataTable();
            _SetForm();
            DateTime datetime = JDateTime.Now();
            lblStatusDay.Text = "تعداد SMS های ارسال شده امروز: " + JSMSess.GetTotalSMS_Day(datetime.Year, datetime.Month, datetime.Day, JMainFrame.CurrentPostCode).ToString() + " عدد";
            lblStatusMonth.Text = "تعداد SMSهای ارسال شده این ماه: " + JSMSess.GetTotalSMS_Month(datetime.Year, datetime.Month, JMainFrame.CurrentPostCode).ToString() + " عدد";

        }

        private void btnAddNonPerson_Click(object sender, EventArgs e)
        {
            JTextInputDialogForm jTextInput = new JTextInputDialogForm("شماره همراه", "", false);
            if (jTextInput.ShowDialog() == DialogResult.OK)
            {
                if (_Code == 0)
                {
                    Save();
                    if (_Code == 0) return;
                }

                JSMSesDetails jSMSesDetails = new JSMSesDetails();
                jSMSesDetails.Mobile = jTextInput.Text;
                jSMSesDetails.PersonCode = 0;
                jSMSesDetails.SMS_Code = _Code;
                jSMSesDetails.SMSSendCode = 0;
                jSMSesDetails.Insert();
                _Recievers = (new JSMSes(_Code)).SMSDetailsForView;
                dgrMobiles.DataSource = _Recievers;
                dgrMobiles.Refresh();
                CalculateSMSes();
            }
        }

        private void btnDeleteFromGroup_Click(object sender, EventArgs e)
        {
            if (dgrMobiles.SelectedRows.Count <= 0) return;
            JSMSesDetails jSMSesDetails = new JSMSesDetails();
            for (int i = dgrMobiles.SelectedRows.Count - 1; i >= 0; i--)
            {
                jSMSesDetails.Code = Convert.ToInt32(dgrMobiles.SelectedRows[i].Cells["Code"].Value);
                if (jSMSesDetails.Delete() > 0)
                    dgrMobiles.Rows.Remove(dgrMobiles.SelectedRows[i]);
            }
            _Recievers = (new JSMSes(_Code)).SMSDetailsForView;
            //dgrMobiles.DataSource = _Recievers;
            dgrMobiles.Refresh();
            CalculateSMSes();
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            SMSGroupSelect smsGroupSelect = new SMSGroupSelect();
            if (smsGroupSelect.ShowDialog() == DialogResult.OK)
            {
                if (_Code == 0)
                {
                    Save();
                    if (_Code == 0) return;
                }
                JSMSesDetailss.SaveRange(JSMSGroups.GetGroupData(smsGroupSelect.SelectedGroup), _Code.ToString());
                _Recievers = (new JSMSes(_Code)).SMSDetailsForView;
                dgrMobiles.DataSource = _Recievers;
                dgrMobiles.Refresh();
                CalculateSMSes();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                JMessages.Information("اطلاعات با موفقیت ذخیره شد.", "نامه");
                if (JMessages.Question("آیا می خواهید فرم بسته شود؟", "خروج") == DialogResult.Yes)
                    this.Close();
            }
        }

        public void SendSMS(DataTable _DT)
        {
            if (_DT.Rows.Count == 0) return;
            int code = Convert.ToInt32(_DT.Rows[0]["Code"]);
            if (_DT.Rows[0]["Mobiles"].ToString().Trim().Length < 5)
            {
                //JMessages.Error("هیچ شماره ای در لیست وجود ندارد.", "ارسال اس ام اس");
                return;
            }

            JSMSes jSMSes = new JSMSes(code);
            if (jSMSes.Status == Domains.JClassLibrary.JSMSStatus.Sent)
            {
                JMessages.Error("این اس ام اس قبلا فرستاده شده است.", "ارسال اس ام اس");
                return;
            }
            jSMSes.Status = Convert.ToInt32(Domains.JClassLibrary.JSMSStatus.Sent);

            string Mobiles = _DT.Rows[0]["Mobiles"].ToString();
            JSMSSend jSMSSend = new JSMSSend();
            jSMSSend.ClassName = _ConstClassName;
            jSMSSend.Description = "SMSForm";
            jSMSSend.Project = "ERP";
            jSMSSend.SendDevice = Convert.ToInt32(JSMSSendType.WebService);
            jSMSSend.Send = 0;
            jSMSSend.Mobile = Mobiles;
            jSMSSend.PersonCode = JMainFrame.CurrentPersonCode;
            jSMSSend.RegDate = JDateTime.Now();
            jSMSSend.Text = _DT.Rows[0]["SMS_Text"].ToString();
            int SMSSendCode = jSMSSend.Insert();
            if (SMSSendCode > 0)
            {
                jSMSes.Send_Date_Time = JDateTime.Now();
                jSMSes.Send_Full_Title = JMainFrame.CurrentPostTitle;
                jSMSes.Send_User_Code = JMainFrame.CurrentUserCode;
                jSMSes.Send_User_Post_Code = JMainFrame.CurrentPostCode;
                jSMSes.Update();
                JSMSesDetailss.SetSMSSendCodeToSMS(_Code, SMSSendCode);
                _ChangeFormView("NoChange");
                _SetStatus(jSMSes);
                JMessages.Information("اس ام اس با موفقیت ارسال شد.", "SMS");
            }
        }

        private void btnRefer_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled == true) Save();
            Refer();
        }

        private void btnSentList_Click(object sender, EventArgs e)
        {
            SMSSentList smsSentList = (new SMSSentList());
            if (smsSentList.ShowDialog() == DialogResult.OK)
            {
                if (_Code == 0)
                {
                    Save();
                    if (_Code == 0) return;
                }
                JSMSesDetailss.SaveRange((new JSMSes(smsSentList._SMSesCode)).SMSDetailsForView, _Code.ToString());
                _Recievers = (new JSMSes(_Code)).SMSDetailsForView;
                dgrMobiles.DataSource = _Recievers;
                dgrMobiles.Refresh();
                CalculateSMSes();
            }
        }
    }
}
