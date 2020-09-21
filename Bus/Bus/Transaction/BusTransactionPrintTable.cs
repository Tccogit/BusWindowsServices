using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment
{
    class JBusTransactionPrintTable:ClassLibrary.JTable
    {
        public int BusCode;
        public int PersonCode;
        public DateTime FromDate;
        public DateTime ToDate;
        public DateTime ReportDate;
        public int TransactionCount;
        public Int64 Income;
        public JBusTransactionPrintTable()
            : base("AUTBusTransactionPrint")
        {
        }
    }
}
