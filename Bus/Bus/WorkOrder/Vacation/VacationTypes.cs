using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.WorkOrder
{
    public class JVacationType : ClassLibrary.JSubBaseDefine
    {
        public JVacationType()
            : base(ClassLibrary.JBaseDefine.VacationType)
        {
        }
    }

    public class JVacationTypes : ClassLibrary.JSubBaseDefines
    {
        public JVacationTypes()
            : base(ClassLibrary.JBaseDefine.VacationType)
        {
        }
    }
}
