using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.Fleet
{
    public class JFleetType : ClassLibrary.JSubBaseDefine
    {
        public JFleetType()
            : base(ClassLibrary.JBaseDefine.TypeFleet)
        {
        }
    }
    public class JFleetTypes : ClassLibrary.JSubBaseDefines
    {
        public JFleetTypes()
            : base(ClassLibrary.JBaseDefine.TypeFleet)
        {
        }
    }
}
