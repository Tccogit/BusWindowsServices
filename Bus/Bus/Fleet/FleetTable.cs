using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.Fleet
{
    class FleetTable :ClassLibrary.JTable
    {
        public string Name;
        public int FleetType;
        public DateTime StartDate;
        public DateTime EndDate;
         public FleetTable()
            : base("AUTFleet")
        {
        }

    }
}
