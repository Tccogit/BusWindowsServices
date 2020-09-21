using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
namespace Employment
{
    public class JContractTable :JTable
    {

        /// <summary>
        /// کد شخص
        /// </summary>
        public int PCode ;
        /// <summary>
        /// تاریخ استخدام
        /// </summary>
        public DateTime DateEmployee ;
        /// <summary>
        /// تاریخ قرارداد
        /// </summary>
        public DateTime DateContract ;
        /// <summary>
        /// تاریخ شروع قرارداد
        /// </summary>
        public DateTime DateStart ;
        /// <summary>
        /// تاریخ پایان قرارداد
        /// </summary>
        public DateTime DateEnd ; 
        /// <summary>
        /// محل فعالیت که از چارت سازمانی خوانده میشود
        /// </summary>
        public int ChartCode ;
        /// <summary>
        /// نوع فعالیت که جزو تعاریف اولیه می باشد
        /// </summary>
        public int ActivityType ;
        /// <summary>
        /// نوع شیفت
        /// </summary>
        public int ShiftCode ;
        /// <summary>
        /// وضعیت قرارداد
        /// </summary>
        public int State;
        public JContractTable()
            : base("empcontract", "UserCode, ChartCode, ActivityType, ShiftCode")
        {
        }
    }
}
