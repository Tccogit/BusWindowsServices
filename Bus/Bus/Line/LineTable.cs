using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.Line
{
    class LineTable:ClassLibrary.JTable
    {
        public string LineName;
        public double LineNumber;
        public int ZoneCode;
        public int LineType;
        public int NumOfServicePerDay;
        public int TimeOfService;
        public bool Status;
        public int Fleet;
        public bool Rotate;
        public float Distance;
        public int Color;
        public bool IsDrawn;
         public LineTable()
            : base("AUTLine")
        {
        }
    }
}
