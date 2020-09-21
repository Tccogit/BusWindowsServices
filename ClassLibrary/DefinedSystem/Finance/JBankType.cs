using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JBankType : JSubBaseDefine
    {
        public JBankType()
            : base(JBaseDefine.BankTypes)
        {
        }
    }

    public class JBankTypes : JSubBaseDefines
    {
        public JBankTypes()
            : base(JBaseDefine.BankTypes)
        {
        }
    }
}
