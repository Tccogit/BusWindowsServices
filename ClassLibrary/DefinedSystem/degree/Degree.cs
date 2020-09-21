using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JDegree: JSubBaseDefine
    {
        /// <summary>
        /// مدرک تحصیلی
        /// </summary>
        public JDegree()
            : base(JBaseDefine.DegreeCode)
        {
        }
        /// <summary>
        /// مدارک تحصیلی
        /// </summary>
        public class JDegrees : JSubBaseDefines
        {
            //public JCitiy[] Items;
            public JDegrees()
                : base(JBaseDefine.DegreeCode)
            {

            }
        }
    }
}
