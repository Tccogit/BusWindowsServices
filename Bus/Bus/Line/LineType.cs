using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.Line
{
    class JLineType :ClassLibrary.JSubBaseDefine
    {
        public JLineType()
            : base(ClassLibrary.JBaseDefine.TypeLine)
        {
        }
    }

    public class JLineTypes : ClassLibrary.JSubBaseDefines
    {
        public JLineTypes()
            : base(ClassLibrary.JBaseDefine.TypeLine)
        {
        }
    }
}
