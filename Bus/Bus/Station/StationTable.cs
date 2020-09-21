using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.Station
{
    class StationTable:ClassLibrary.JTable
    {
        #region Properties
        public string Name;
        public int ZoneCode;
        public int StationTypeCode;
        public decimal Lat;
        public decimal Lng;
        public bool isTerminal;
        public string Address;
        public string StationCode;
        public int Radius;
        public int Angle;
        public Int64 IMEI;
        public int MinSpeed;
        public int ImageCode;
        #endregion

        public StationTable()
            : base("AUTStation") 
        {
        }
    }
}
