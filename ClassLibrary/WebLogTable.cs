using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ClassLibrary
{
    public class JShareWebLogTable : JTable
    {
        public JShareWebLogTable()
            : base("ShareWebLog")
        {
        }
        #region Properties
        public string TableName;
        public int ChangedCode;
        public char Operation;
        public bool Applyed;
        #endregion Properties
    }
}
