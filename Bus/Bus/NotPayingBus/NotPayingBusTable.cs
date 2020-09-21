using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.NotPayingBus
{
    class NotPayingBusTable : ClassLibrary.JTable
    {
        public int BusCode;
        public DateTime FromDate;
        public DateTime ToDate;
        public NotPayingBusTable()
            : base("AUTNotPayingBus")
        {
        }
    }
}
