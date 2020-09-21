using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.CardBlackList
{
    class CardBlackListTable : ClassLibrary.JTable
    {
        public Int64 RfidNumber;
        public CardBlackListTable()
            : base("AUTCardBlackList")
        {
        }
    }
}
