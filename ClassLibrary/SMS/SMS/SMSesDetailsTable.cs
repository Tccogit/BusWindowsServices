using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary.SMS
{
    public class JSMSesDetailsTable : ClassLibrary.JTable
    {
        public JSMSesDetailsTable()
            : base("SMSesDetails")
        { }

        public int SMS_Code;
        public int PersonCode;
        public string Mobile;
        public int SMSSendCode;

    }
}
