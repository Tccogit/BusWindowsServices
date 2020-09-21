using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JPlaceTable : JTable
    {
        #region Properties
        public string Name;
        public string PostalCode;
        public string Tel;
        public string Fax;
        public string Email;
        public double Lattitude;
        public double Longitude;
        public int Altitude;
        public string Description;
        #endregion

        public JPlaceTable()
            : base("JPlaceTable")
        {
        }

    }
}
