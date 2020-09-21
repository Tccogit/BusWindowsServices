using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ClassLibrary
{
    class jMarketLocationTable : JTable
    {
        public int Code { get; set; }
        public int MarketCode { get; set; }
        public int GroundCode { get; set; }
        public string occupancy { get; set; }

        public jMarketLocationTable()
            : base(JTableNamesEstate.MarketLocation,"" )
        {
        }
    }

    public enum estMarketLocation
    {
        Code,
        MarketCode,
        GroundCode,
        occupancy,
    }
}
