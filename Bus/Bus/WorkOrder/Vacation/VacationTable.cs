using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.WorkOrder
{
    public class JAUTVacationTable : JTable
    {
        public JAUTVacationTable()
            : base("AUTVacation")
        {
        }

        /// <summary>
        /// کد راننده
        /// </summary>
        public int DriverPCode ;
        /// <summary>
        /// نوع مرخصی
        /// </summary>
        public int VacationType ;
        /// <summary>
        /// از تاریخ و ساعت
        /// </summary>
        public DateTime FromDate ;
        /// <summary>
        /// تا تاریخ وساعت
        /// </summary>
        public DateTime ToDate ;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description ;
    }
}
