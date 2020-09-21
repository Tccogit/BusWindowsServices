using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment
{
    class JBusOfflineFilesTable:ClassLibrary.JTable
    {
        public DateTime Date;
        public int SenderPersonCode;
        public int ArchiveCode;
        public int Status;
        public DateTime ProcessDate;
        public int TransactionCount;
        public int BusCode;
        public string Discription;
        public JBusOfflineFilesTable()
            : base("AUTBusOfflineFiles")
        {
        }
    }
}
