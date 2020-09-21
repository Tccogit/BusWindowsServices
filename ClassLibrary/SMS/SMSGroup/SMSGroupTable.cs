using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary.SMS
{
    class JSMSGroupTable : ClassLibrary.JTable
    {
        public JSMSGroupTable()
            : base("SMSGroup")
        {
        }

        public int GroupCode;
        public int PersonCode;
        public string Mobile;
    }
}
