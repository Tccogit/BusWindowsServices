using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.Line
{
    public class JAUTFleetLinePointTable : ClassLibrary.JTable
    {
        public JAUTFleetLinePointTable() :
            base("AUTFleetLinePoints")
        {
        }

        #region Properties
        public int LineCode;
        public double Lattitude;
        public double Longitude;
        public int OrderNo;
        public int PathType;
        #endregion
    }
}
