using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Estates
{
    class JGroundTable : JTable 
    {
        public JGroundTable():base(JTableNamesEstate.GroundTable)
        {
            
        }
        #region field

       
        /// <summary>
        /// اراضی
        /// </summary>
        public int Land;
       
        /// <summary>
        /// پلاک اصلی
        /// </summary>

        public string MainAve;
         /// <summary>
        /// پلاک فرعی
        /// </summary>
        public string SubNo;
        
        /// <summary>
        /// بخش
        /// </summary>
        public string Section;
        /// <summary>
        /// شماره بلوک
        /// </summary>
        public string BlockNum;
        /// <summary>
        /// شماره قطعه
        /// </summary>
        public string PartNum;
        /// <summary>
        /// کاربری
        /// </summary>
        public int Usage;
        /// <summary>
        /// مساحت
        /// </summary>
        public double Area;       
        /// <summary>
        /// توضیحات مربوط به زمین
        /// </summary>
        public string Comment;
        /// <summary>
        /// تاریخ جاری را ثبت سیستم می کند
        /// </summary>
        public DateTime Date;
        /// <summary>
        /// شخصی که اطلاعات را ثبت سیستم می کند
        /// </summary>
        public int Person;
  
       

        #endregion

    }
    enum JGroundTableEnum
    {
        Code,
        Land,
       
        /// <summary>
        /// پلاک اصلی
        /// </summary>

         MainAve,
         /// <summary>
        /// پلاک فرعی
        /// </summary>
        SubNo,
        
        /// <summary>
        /// بخش
        /// </summary>
        Section,
        /// <summary>
        /// شماره بلوک
        /// </summary>
        BlockNum,
        /// <summary>
        /// شماره قطعه
        /// </summary>
        PartNum,
        /// <summary>
        /// کاربری
        /// </summary>
        Usage,
        /// <summary>
        /// مساحت
        /// </summary>
        Area,       
        /// <summary>
        /// توضیحات مربوط به زمین
        /// </summary>
        Comment,
        /// <summary>
        /// تاریخ جاری را ثبت سیستم می کند
        /// </summary>
        Date,
        /// <summary>
        /// شخصی که اطلاعات را ثبت سیستم می کند
        /// </summary>
        Person
  
    }
}
