using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ClassLibrary
{
    class jMarketUsageTable : JTable
    {
        public int Code;
        public int UsageCode;
        public int GroundCode;
        public string Infrastructure;

        public jMarketUsageTable()
            : base(JTableNamesEstate.MarketUsage,"" )
        {
        }
    }

    public enum estMarketUsage
    {
        Code,
        MarketCode,
        UsageCode,
        Infrastructure,
    }

}
