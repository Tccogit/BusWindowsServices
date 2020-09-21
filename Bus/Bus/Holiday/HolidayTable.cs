using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.Holiday
{
    class HolidayTable : ClassLibrary.JTable
    {
        public DateTime Date;
        public string Description;
        public short HoliDaysType;
        public short DateType;
        public HolidayTable()
            : base("AUTHolidays")
        {
        }
    }
}
