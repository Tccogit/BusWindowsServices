using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.Price
{
    class PriceTable:ClassLibrary.JTable
    {
        public int LineCode;
        public int Price;
        public DateTime StartDate;
        public DateTime Enddate;
        public TimeSpan StartTime;
        public TimeSpan EndTime;
         public PriceTable()
            : base("AUTPrice")
        {
        }
    }
}
