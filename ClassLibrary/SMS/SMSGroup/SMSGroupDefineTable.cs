using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary.SMS
{
    class JSMSGroupDefineTable : ClassLibrary.JTable
    {
        public JSMSGroupDefineTable() :
            base("SMSGroupDefine")
        { }

        public string Name;
        public string SQL;
        public int UserCode;
    }
}
