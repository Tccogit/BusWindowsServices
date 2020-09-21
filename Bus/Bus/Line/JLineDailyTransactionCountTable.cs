using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.Line
{
    public class JLineDailyTransactionCountTable : ClassLibrary.JTable
    {
        public JLineDailyTransactionCountTable() :
            base("AUTDailyLineTransactionCount")
        {
        }

        public int LineCode;
        public int TransactionCount;

    }
}
