using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace BusManagment.SMS
{
    class JSMSTable: ClassLibrary.JTable
    {
        public int Code;
        public string Mobile;
        public string Text;
        public string send;
        public DateTime Regdate;
        public DateTime Senddate;
        public string Description;
        public string project;
        public string ClassName;
        public int ObjectCode;
        public int PersonCode;
        public DateTime DeliveryDate;
        public int SendDevice;
        public string batchId;

        public JSMSTable() : base("SMSSend") { }



    }
}
