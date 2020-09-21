using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary.Controllers.SMS
{
    public partial class JQuickSMS : UserControl
    {
        public string _ClassName = "ClassLibrary.Controllers.SMS.JQuickSMS";
        public int _ObjectCode = 0;
        public int _TotalSMSParts = 0;
        public int _TotalSMSes = 0;
        public string receivers;
        public string Receivers
        {
            get
            {
                return receivers;
            }
            set
            {
                receivers = value;
                txtTo.Text = value;
            }
        }
        public string[] _Receivers
        {
            get
            {
                if (Receivers == null) return null;
                return Receivers.Split(',');
            }
            set
            {
                Receivers = "";
                foreach (string item in value)
                {
                    Receivers += "," + item;
                }
                if (Receivers.Length > 3)
                    Receivers = Receivers.Substring(1);
            }
        }

        public JQuickSMS()
        {
            InitializeComponent();
            txtContent_TextChanged(null, null);
        }

        private void txtContent_TextChanged(object sender, EventArgs e)
        {
            int txtLength = Convert.ToInt32(txtContent.Text.Length);

            lblTotalSMS.Text = "تعداد کاراکتر: " + txtContent.Text.Length.ToString() + " (هر اس ام اس " + (txtLength <= 70 ? "70" : "67") + " کاراکتر)";
            if (txtLength <= 70)
                _TotalSMSParts = 1;
            else
                _TotalSMSParts = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(txtLength) / 67));
            lblTotalSMS.Text = "تعداد SMSها: " + _TotalSMSParts.ToString() + " عدد";
            _TotalSMSes = _TotalSMSParts * (_Receivers != null ? _Receivers.Length : 0);
            lblTotalSMSxRecievers.Text = "تعداد SMSها در گیرندگان: " + _TotalSMSes.ToString() + " عدد";
            lblSpacesBefore.Text = "تعداد فاصله ها قبل از متن: " + SpacesBefore(txtContent.Text).ToString() + " عدد";
            lblSpacesAfter.Text = "تعداد فاصله ها بعد از متن: " + SpacesAfter(txtContent.Text).ToString() + " عدد";
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

        public int SendSMS()
        {
            if (txtContent.Text.Length == 0) return 0;
            JSMSSend jSMSSend = new JSMSSend();
            jSMSSend.ClassName = _ClassName;
            jSMSSend.ObjectCode = _ObjectCode;
            jSMSSend.Description = "QuickSMS";
            jSMSSend.Project = "ERP";
            jSMSSend.SendDevice = Convert.ToInt32(JSMSSendType.WebService);
            jSMSSend.Send = 0;
            jSMSSend.Mobile = Receivers;
            jSMSSend.PersonCode = JMainFrame.CurrentPersonCode;
            jSMSSend.RegDate = JDateTime.Now();
            jSMSSend.Text = txtContent.Text;
            return jSMSSend.Insert();
        }
    }
}