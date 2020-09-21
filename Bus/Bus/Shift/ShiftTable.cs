using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.Shift
{
    class ShiftTable : ClassLibrary.JTable
    {
        public string Title;
        public TimeSpan StartTime;
        public TimeSpan EndTime;
        public DateTime StartDate;
        public DateTime EndDate;
        public ShiftTable()
            : base("AUTShift")
        {
        }
    }
}
