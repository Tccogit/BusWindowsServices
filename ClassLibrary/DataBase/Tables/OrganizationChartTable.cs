using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    class JOrganizationChartTable : JTable
    {
        #region Peroperties
        /// <summary>
        /// کد
        /// </summary>        
        public int code { get; set; }
        /// <summary>
        /// کد پست
        /// </summary>
        public int PostTitleCode { get; set; }
        /// <summary>
        /// کد شغل
        /// </summary>
        public int JobTitleCode { get; set; }
        /// <summary>
        /// عنوان
        /// </summary>
        public int user_code { get; set; }
        /// <summary>
        /// واحد هست یا نه
        /// </summary>
        public bool is_unit { get; set; }
        /// <summary>
        /// کد نود پدر
        /// </summary>
        public int parentcode { get; set; }
        /// <summary>
        /// کد دبیرخانه
        /// </summary>
        public int secretariat_code { get; set; }
        /// <summary>
        /// شماره پرسنلی
        /// </summary>        
        public int PersonNumber { get; set; }
        /// <summary>
        /// شماره کارت پرسنل
        /// </summary>        
        public int PersonCartNumber { get; set; }
        #endregion Peroperties

        public JOrganizationChartTable()
            : base(JTableNamesEmployment.OrganizationChart)
        {

        }
    }

    public enum OrganizationChart
    {
        #region Peroperties
        /// <summary>
        /// کد
        /// </summary>        
        code,
        /// <summary>
        /// عنوان
        /// </summary>
        title ,
        /// <summary>
        /// کد عنوان شغلی
        /// </summary>
        Metier_Code,
        /// <summary>
        /// کد کاربر منتصب
        /// </summary>
        user_code,
        /// <summary>
        /// کد چارت
        /// </summary>
        chart_code,
        /// <summary>
        /// واحد هست یا نه
        /// </summary>
        is_unit,
        /// <summary>
        /// کد نود پدر
        /// </summary>
        parentcode,
        /// <summary>
        /// کد دسترسی سریع
        /// </summary>
        AccessCode,        
        /// <summary>
        /// کد دبیرخانه
        /// </summary>
        secretariat_code,

        #endregion Peroperties
    }

}
