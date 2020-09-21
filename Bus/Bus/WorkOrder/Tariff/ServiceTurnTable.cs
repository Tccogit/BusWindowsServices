using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.WorkOrder.Tariff
{
    public class ServiceTurnTable : ClassLibrary.JTable
    {
        public int BusNumber;
        public DateTime FromDate;
        public DateTime ToDate;
        public int FirstDay;
        public int SecondDay;
        public ServiceTurnTable()
            : base("AUTBusServiceTurn")
        {
        }
    }
}
