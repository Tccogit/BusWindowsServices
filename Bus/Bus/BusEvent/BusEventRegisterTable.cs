using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.BusEvent
{
    class BusEventRegisterTable : ClassLibrary.JTable
    {
        public int BusEventDetailesCode;
        public int BusCode;
        public int DriverPCode;
        public DateTime StartDate;
        public DateTime EndDate;
        public string StartTime;
        public string EndTime;
        public int Status;
        public BusEventRegisterTable()
            : base("AUTBusEventRegister")
        {
        }
    }
}
