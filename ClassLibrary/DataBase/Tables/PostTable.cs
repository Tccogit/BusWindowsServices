using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Employment
{

    public class JEPostTable :JTable 
    {
        public int UnitCode;
        public int MetierCode;
        public int State;
        public int ActiveUserCode;
        
        public JEPostTable()
            : base("empposts")
        {
        }
    }
}
