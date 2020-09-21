using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JActionTable : JTable
    {
        public string ActioName;
        public string FunctionName;
        
        public string Arg;
        public string ConstArg;

        public JActionTable()
            : base("Actions")
        {
        }
    }
}
