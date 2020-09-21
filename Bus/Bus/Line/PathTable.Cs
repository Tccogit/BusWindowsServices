using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.Line
{
    class PathTable :ClassLibrary.JTable
    {
        public int SCode;
        public int LCode;
        public int Order;
        public PathTable()
            : base("AUTPath")
        {
        }
    }
}
