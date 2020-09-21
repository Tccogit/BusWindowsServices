using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.BusEvent
{
    class BusEventDetailesTable:ClassLibrary.JTable
    {
        public string Name;
        public int BusEventCode;
        public BusEventDetailesTable()
            : base("AUTBusEventDetailes")
        {
        }
    }
}
