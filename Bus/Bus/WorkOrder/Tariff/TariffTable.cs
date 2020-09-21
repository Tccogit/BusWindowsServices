using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.WorkOrder
{
    class TariffTable:ClassLibrary.JTable
    {
        public int LineCode;
        public float NumOfService;
        public int BusCode;
        public int DriverCode;
        public int DriverWorkType;
        public int DriverWorkStatus;
        //public DateTime StartDate;
        //public DateTime EndDate;
        public DateTime Date;
        public string StartTime;
        public string EndTime;
        public int ShiftCode;
        public int FaliyatCode;
        public int OnvaneShoghliCode;
        public int GozareshCode;
        public int ZoneCode;
        public int DailyLineTransactionCount;
        public int MinNumOfService;
        public TariffTable()
            : base("AUTTariff")
        {
        }
    }
}
