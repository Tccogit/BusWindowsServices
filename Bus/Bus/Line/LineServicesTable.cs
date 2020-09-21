using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.Line
{
    class LineServicesTable:ClassLibrary.JTable
    {
        public int LineCode;
        public int ShiftCode;
        public float NumOfSerivec;
        public LineServicesTable()
            : base("AutLineServices")
        {
        }
    }
}
