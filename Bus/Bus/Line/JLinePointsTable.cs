using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.Line
{
    public class JLinePointsTable : ClassLibrary.JTable
    {
        public JLinePointsTable() :
            base("AUTFleetLinePoints")
        {
        }

        public int LineCode;
        public float Latitude;
        public float Longitude;
        public int OrderNo;
        public int PathType;

    }
}
