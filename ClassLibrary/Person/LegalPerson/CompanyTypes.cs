using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// کلاس انواع شرکتها که از تعاریف پایه مشتق شده است
    /// </summary>
    public class JCompanyType : JSubBaseDefine
    {
        public JCompanyType()
            : base(JBaseDefine.CompanyTypes)
        {
        }
    }

    public class JCompanyTypes : JSubBaseDefines
    {
        public JCompanyTypes()
            : base(JBaseDefine.CompanyTypes)
        {
        }
    }
}
