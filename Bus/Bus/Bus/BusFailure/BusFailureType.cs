using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment
{
    class JBusFailureType :ClassLibrary.JSubBaseDefine
    {
        public JBusFailureType()
            : base(ClassLibrary.JBaseDefine.BusFailureType)
        {
        }
    }

    public class JBusFailureTypes : ClassLibrary.JSubBaseDefines
    {
        public JBusFailureTypes()
            : base(ClassLibrary.JBaseDefine.BusFailureType)
        {
        }
    }
}
