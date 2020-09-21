using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.Card
{
    class CardTable : ClassLibrary.JTable
    {
        public int Type;
        public CardTable()
            : base("AUTCardType")
        {
        }
    }
}
