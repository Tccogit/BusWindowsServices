using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JGroupSMS : JSubBaseDefine
    {
        public JGroupSMS()
            : base(JBaseDefine.SMSGroup)
        {
        }
    }
    public class JGroupSMSs : JSubBaseDefines
    {
        public JGroupSMSs()
            : base(JBaseDefine.SMSGroup)
        {
        }
    }
}
