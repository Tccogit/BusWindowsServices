using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.BusEvent
{
    class BusEventPalceTable:ClassLibrary.JTable
    {
        public string Name;
        public int BusEventDetailesCode;
        public double Longitude;
        public double Latitude;
        public int Radius;
        public BusEventPalceTable()
            : base("AUTBusEventPlace")
        {
        }
    }
}
