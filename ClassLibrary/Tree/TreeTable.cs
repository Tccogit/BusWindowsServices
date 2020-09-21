using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JTreeTable:JTable
    {
        public int TreeCode;
        public string Name;
        public int ParentCode;
        public int ObjectCode;
        public Boolean State;
        public int MainCode;
        public int ExtraCode1;
        public int ExtraCode2;
        //public string  ActionXML;
        public string ClassName;

        public JTreeTable()
            : base("tree")
        {
        }
    }
}
