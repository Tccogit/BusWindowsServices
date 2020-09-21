using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary.SMS
{
    public class JSMSPatternTable : ClassLibrary.JTable
    {
        public JSMSPatternTable()
            : base("SMSPattern")
        {
        }

        public string WhiteList;
        public string BlackList;
        public string Pattern;
        public int Type;
        public string Action;
        public int TimeLimit;

    }
}
