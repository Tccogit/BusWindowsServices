using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.BusEvent
{
    class BusEventTable:ClassLibrary.JTable
    {
        public string Name;
        public int BusActive;
        public int DriverActive;
        public BusEventTable()
            : base("AUTBusEvent")
        {
        }
    }
}
