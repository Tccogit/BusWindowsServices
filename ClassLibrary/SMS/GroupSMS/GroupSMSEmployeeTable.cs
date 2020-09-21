using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JGroupSMSEmployeeTable : JTable
    {
        public JGroupSMSEmployeeTable()
            : base("SMSGroup")
        {
        }
        /// <summary>
        /// کد گروه
        /// </summary>
        public int GroupCode;
        /// <summary>
        /// کد پرسنلی
        /// </summary>
        public int PersonCode;
    }
}
