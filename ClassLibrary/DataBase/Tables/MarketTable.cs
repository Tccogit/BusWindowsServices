using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Estates
{
    class jMarketTable : JTable
    {

        #region Property

        /// <summary>
        /// شماره مجتمع
        /// </summary>
        public int MarketNumber { get; set; }
        /// <summary>
        /// عنوان
        /// </summary>
        public int Title { get; set; }
        /// <summary>
        /// زیربنا
        /// </summary>
        public int Infrastructure { get; set; }
        /// <summary>
        /// تاریخ شروع ساخت
        /// </summary>
        public int StartBuilding { get; set; }
        /// <summary>
        /// تاریخ پایان
        /// </summary>
        public int EndBuilding { get; set; }
        /// <summary>
        /// پروانه ساخت
        /// </summary>
        public int PermitBuilding { get; set; }
        /// <summary>
        /// پروانه بهره برداری
        /// </summary>
        public int PermitResult { get; set; }
        /// <summary>
        /// نام مدیریت
        /// </summary>
        public int ManagerName { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
        #endregion

        public jMarketTable()
            : base(JTableNamesEstate.Market,"" )
        {
        }
    }

    public enum estMarket
    {

        #region Property
        Code,
        /// <summary>
        /// شماره مجتمع
        /// </summary>
        MarketNumber ,
        /// <summary>
        /// عنوان
        /// </summary>
        Title ,
        /// <summary>
        /// زیربنا
        /// </summary>
        Infrastructure,
        /// <summary>
        /// تاریخ شروع ساخت
        /// </summary>
        StartBuilding ,
        /// <summary>
        /// تاریخ پایان
        /// </summary>
        EndBuilding ,
        /// <summary>
        /// پروانه ساخت
        /// </summary>
        PermitBuilding ,
        /// <summary>
        /// پروانه بهره برداری
        /// </summary>
        PermitResult ,
        /// <summary>
        /// نام مدیریت
        /// </summary>
        ManagerName ,
        /// <summary>
        /// توضیحات
        /// </summary>
        Description,
        #endregion
    }
}
