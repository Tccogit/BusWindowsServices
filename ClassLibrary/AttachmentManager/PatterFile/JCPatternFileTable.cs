using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    class JCPatternFileTable : ClassLibrary.JTable
    {
        public string name;
        public int type;
        public string pattern;

        public JCPatternFileTable()
            : base("patternfile")
        {
        }
    }
}
