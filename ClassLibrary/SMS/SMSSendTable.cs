using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ClassLibrary
{
    public class JSMSSendTable : JTable
    {
        public JSMSSendTable()
            : base("SMSSend")
        {
        }        
        /// <summary>
        ///  موبیل
        /// </summary>
        public string Mobile ;
        /// <summary>
        ///  متن
        /// </summary>
        public string Text ;
        /// <summary>
        ///  ارسال شده
        /// </summary>
        public int Send ;
        /// <summary>
        ///  تاریخ ثبت
        /// </summary>
        public DateTime RegDate ;
        /// <summary>
        ///  تاریخ ارسال
        /// </summary>
        public DateTime SendDate ;
        /// <summary>
        ///  توضیحات
        /// </summary>
        public string Description ;
        /// <summary>
        ///  نام پروژه
        /// </summary>
        public string Project ;
        /// <summary>
        ///  
        /// </summary>
        public string ClassName ;
        /// <summary>
        ///  
        /// </summary>
        public int ObjectCode ;
        /// <summary>
        ///  تایید دریافت تاریخ
        /// </summary>
        public DateTime DeliveryDate ;
        /// <summary>
        ///  کد شخص ارسال کننده پیامک
        /// </summary>
        public int PersonCode;
        /// <summary>
        ///  نوع ارسال با چه وسیله ای
        /// </summary>
        public int SendDevice;
        public string BatchId;
    }
}
