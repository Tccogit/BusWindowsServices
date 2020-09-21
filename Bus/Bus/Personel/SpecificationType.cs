using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.Personel
{
    public class JSpecificationType : ClassLibrary.JSubBaseDefine
    {
        public JSpecificationType()
            : base(ClassLibrary.JBaseDefine.SpecificationType)
        {
        }
    }

    public class JSpecificationTypes : ClassLibrary.JSubBaseDefines
    {
        public JSpecificationTypes()
            : base(ClassLibrary.JBaseDefine.SpecificationType)
        {
        }
    }
}
