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
    public partial class QuickSMSForm : ClassLibrary.JBaseForm
    {
        int _TotalSMSPartsLimit;
        public QuickSMSForm(string receivers, string className, int objectCode, int totalSMSPartsLimit)
        {
            InitializeComponent();
            jQuickSMS1.Receivers = receivers;
            jQuickSMS1._ClassName = className;
            jQuickSMS1._ObjectCode = objectCode;
            _TotalSMSPartsLimit = totalSMSPartsLimit;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnRefer_Click(object sender, EventArgs e)
        {
            if (jQuickSMS1._TotalSMSParts > _TotalSMSPartsLimit)
            {
                JMessages.Error("تعداد SMS ها بیش از حد مجاز می باشد.", "ارسال پیام");
                return;
            }
            if (jQuickSMS1.SendSMS() > 0)
            {
                JMessages.Information("پیام کوتاه با موفقیت ارسال شد.", "ارسال پیام");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
                JMessages.Error("ارسال پیام با خطا مواجه شد.", "ارسال پیام");
        }

        private void QuickSMSForm_Load(object sender, EventArgs e)
        {

        }
    }
}
