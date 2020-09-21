using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JSubBaseDefineTable: JTable
    {
        public int BCode = 0;
        public string Name = "";
        public int ParentCode = 0;

        public JSubBaseDefineTable()
            : base("subdefine")
        {
        }
    }
   
}
