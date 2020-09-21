using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.DynamicDashboard
{
    class DynamicDashboardTable : ClassLibrary.JTable
    {
        public string Title;
        public string SqlQuery;
        public int Type;
        public string ChartX;
        public string ChartY;
        public int RefreshTimeSec;
        public DynamicDashboardTable()
          : base("AUTDynamicDashboard")
        {
        }
    }
}
