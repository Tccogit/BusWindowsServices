using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class jWorkFlowTable: ClassLibrary.JTable
    {

        public JNodeType NodeType;
        public int Ordered;
        public int PostCode;
        public int FormCode;
        public string Condition;

        public jWorkFlowTable()
            : base("FormWorkFlowNode")
        {
        }
    }
}
