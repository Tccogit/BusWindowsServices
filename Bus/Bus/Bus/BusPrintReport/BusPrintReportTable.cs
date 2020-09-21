using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment
{
    class JBusPrintReportTable:ClassLibrary.JTable
    {
        public int BusNumber;
        public DateTime StartDate;
        public DateTime EndDate;
        public int TicketCount;
        public int TicketSent;
        public int State;
        public int DailyCode;
        public int ShiftDriverCode;
        public JBusPrintReportTable()
            : base("AUTPrinterRporte")
        {
        }
    }
}
