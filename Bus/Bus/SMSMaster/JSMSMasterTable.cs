using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace BusManagment.SMSMaster
{
    class JSMSMasterTable : ClassLibrary.JTable
    {
        public DateTime RegisterDate;
        public DateTime SendDate;
        public int UserCode;
        public string Text;
        public string Description;
        public int IsSend;

        public JSMSMasterTable() : base("SMSMaster") { }
    }
}
