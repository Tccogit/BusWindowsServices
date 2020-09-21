using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.DynamicDashboard
{
    class UserDynamicDashboardTable : ClassLibrary.JTable
    {
        public int UserCode;
        public int DashboardCode;
        public UserDynamicDashboardTable()
          : base("AUTUserDynamicDashboard")
        {
        }
    }
}
