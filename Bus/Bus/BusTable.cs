using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace AUTOMOBILE
{
    class BusTable : ClassLibrary.JTable
    {
       
        public int CarCode;
        public int BCode;
        public int ConsoleCode;
        public DateTime startDate;
        public bool Active;

        public BusTable()
            : base("AUTBus")
        {
        }
    }
}
