using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.Zone
{
    class ZoneTable : ClassLibrary.JTable
    {
        public string Name;
        public string Address;
        public string Description;
        public string Tel;
        public int ChiefPersonCode;
        public DateTime StartDate;
        public DateTime FinishDate;
          public ZoneTable()
            : base("AUTZone")
        {
        }
    }
}
