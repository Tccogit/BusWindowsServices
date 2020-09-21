using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.WorkOrder
{
    class HokmeKarTable:ClassLibrary.JTable
    {
        public int DriverPCode;
        public DateTime Date;
        public int NahveyeHamkariCode;
        public int OnvaneShoghliCode;
        public int VaziayeHamkariCode;
        public int ZoneCode;
        public int LineCode;
        public int BusNumber;
        public int Seri;
        public int FaliyatCode;
        public DateTime StartDate;
        public DateTime EndDate;
        public int Status;
        public int NumOfService;
        public int NumOfHolidayService;
        public int MorningShiftNumOfservice;
        public int EveningShiftNumOfservice;
        public int MorningShiftNumOfHolidayservice;
        public int EveningShiftNumOfHolidayservice;
        public HokmeKarTable()
            : base("AutTarrifHokmeKar")
        {
        }
    }
}
