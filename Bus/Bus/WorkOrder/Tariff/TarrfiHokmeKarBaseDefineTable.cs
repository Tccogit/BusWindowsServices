using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.WorkOrder
{
    class TarrfiHokmeKarBaseDefineTable : ClassLibrary.JTable
    {
        public DateTime StartDate;
        public DateTime EndDate;
        public int ZoneCode;
        public int LineCode;
        public int Seri;
        public int ShiftCode;
        public int DatePeriod;

        public TarrfiHokmeKarBaseDefineTable()
            : base("AutTarrfiHokmeKarBaseDefine")
        {
        }
    }
}
