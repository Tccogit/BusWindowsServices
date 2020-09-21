using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ClassLibrary
{
    public class JSMSGetTable : JTable
    {
        public JSMSGetTable()
            : base("SMSGet")
        {
        }
        public int Code;
        /// <summary>
        ///  موبیل
        /// </summary>
        public string Mobile;
        /// <summary>
        ///  متن
        /// </summary>
        public string Text;
        /// <summary>
        ///  خوانده شده
        /// </summary>
        public bool Read;
        /// <summary>
        ///  تاریخ خواندن 
        /// </summary>
        public DateTime ReadDate;
        /// <summary>
        ///  کد شخص دریافت کننده پیامک
        /// </summary>
        public int PersonCode;
    }
}
