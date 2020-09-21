using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.Personel
{
    public class JEmploymentType : ClassLibrary.JSubBaseDefine
    {
        public JEmploymentType()
            : base(ClassLibrary.JBaseDefine.EmploymentType)
        {
        }
    }

    public class JEmploymentTypes : ClassLibrary.JSubBaseDefines
    {
        public JEmploymentTypes()
            : base(ClassLibrary.JBaseDefine.EmploymentType)
        {
        }
    }
}
