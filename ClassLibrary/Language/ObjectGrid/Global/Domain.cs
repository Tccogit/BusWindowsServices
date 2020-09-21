using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JDomain
    {
        public static JAutomation Automation = new JAutomation();
        public static JCommunication Communication = new JCommunication();
    }

    public class JAutomation
    {
        public int SendTypeCode = 101;
    }

    public class JCommunication
    {
        public int test = 102;
    }
}
