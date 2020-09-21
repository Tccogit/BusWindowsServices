using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ClassLibrary
{
    class JSubReportTable : JTable
    {

        #region Property

        /// <summary>
        /// کد گزارش
        /// </summary>
        public int ReportCode;
        /// <summary>
        /// نام تب
        /// </summary>
        public string TabTitle;
        /// <summary>
        /// فیلدها
        /// </summary>
        public string Fields;
        /// <summary>
        /// جداول
        /// </summary>
        public string Tables;
        /// <summary>
        /// فیلدهای مخفی
        /// </summary>
        public string Hide;
        /// <summary>
        /// 
        /// </summary>
        public string GroupBy;
        #endregion

        public JSubReportTable()
            : base(JTableNamesReport.SubReport, "")
        {
        }
    }
}
