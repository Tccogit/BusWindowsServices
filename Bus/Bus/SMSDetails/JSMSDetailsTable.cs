using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace BusManagment.SMSDetails
{
    class JSMSDetailsTable : ClassLibrary.JTable
    {
        public int SMSMasterCode;
        public int Status;
        public int PersonCode;

        public JSMSDetailsTable() : base("SMSDetails") { }
    }
}
