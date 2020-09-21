using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.UnpaidBlackList
{
    public class UnpaidBlackListTable : ClassLibrary.JTable
    {
        //public int Code;
        public int pCode;
        public DateTime FromDate;
        public DateTime ToDate;
        public DateTime InsertDate;
        //
        public bool PayAfterFinish;

        public UnpaidBlackListTable()
            : base("UnpaidBlackList")
        {
        }
    }
}
