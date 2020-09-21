using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.Query
{
    class QueryTableAuto : ClassLibrary.JTable
    {
        public string Name;
        public string QueryText;
        public string DataBaseName;
        public int LineNumber;
        public int BusCode;
        public QueryTableAuto()
            : base("" + ClassLibrary.JMainFrame.Server01 + @"erp_tabrizbus.dbo.AUTConsoleQueryAuto")
        {
        }
    }
}
