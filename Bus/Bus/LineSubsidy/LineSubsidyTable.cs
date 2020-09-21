using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.LineSubsidy
{
    class JLineSubsidyTable : ClassLibrary.JTable
    {
        public Double Linenumber;
        public DateTime StartDate;
        public DateTime EndDate;
        public int MaxServiceSubsidyPrice;
        public int MinServiceSubsidyPrice;
        public int MaxTransactionSubsidyPrice;
        public int MinTransactionSubsidyPrice;
        public int ServicePrice;
        public int TransactionPrice;
        public int MaxSubsidyPrice; 
        public JLineSubsidyTable() : base("AUTLineSubsidy") { }
    }
}
