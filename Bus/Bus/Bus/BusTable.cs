using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace BusManagment.Bus 
{
    public class JBusTable : ClassLibrary.JTable
    {
       
        public int CarCode;
        public double BUSNumber;
        public bool Active;
        public int FleetCode;
        //public int ImageCode;


        //public double LastLatitude;
        //public double LastLongitude;

        public int IsValid;
        public JBusTable()
            : base("AUTBus")
        {
        }
    }
}
