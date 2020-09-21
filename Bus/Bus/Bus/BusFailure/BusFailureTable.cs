using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment
{
    class JBusFailureTable : ClassLibrary.JTable
    {
        public DateTime Date;
        public int BusCode;
        public int BusFailureCode;
        public string Description;
        public JBusFailureTable()
            : base("AUTBusFailure")
        {
        }
    }
}
