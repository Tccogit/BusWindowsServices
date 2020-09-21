using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.WorkOrder
{
    class EzamBeTable:ClassLibrary.JTable
    {
        public int TarrifCode;
        public int LineCode;
        public int EzamBe;
        public int BusCodeBeJa;
        public float NumOfSevice;
        public DateTime StartTime;
        public DateTime FinishTime;
        public int DriverPCode;
        public EzamBeTable()
            : base("AutTarrifEzamBe")
        {
        }
    }
}
