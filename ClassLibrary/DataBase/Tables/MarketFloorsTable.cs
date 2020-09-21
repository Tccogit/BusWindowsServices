using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ClassLibrary
{
    class jMarketFloors : JTable
    {
        #region Property

        public int Code { get; set; }        
        public string MarketCode { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Infrastructure { get; set; }
        public string Description { get; set; }

        #endregion

        public jMarketFloors()
            : base(JTableNamesEstate.MarketFloors,"" )
        {
        }
    }

    public enum estMarketFloors
    {
         #region Property

        Code,
        MarketCode,
        Name,
        Number,
        Infrastructure ,
        Description,

        #endregion
    }

}
