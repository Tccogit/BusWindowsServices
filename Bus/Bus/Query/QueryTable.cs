using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.Query
{
    class QueryTable : ClassLibrary.JTable
    {
        public string Name;
        public string QueryText;
        public QueryTable()
            : base("AUTConsoleQuery")
        {
        }
    }
}
