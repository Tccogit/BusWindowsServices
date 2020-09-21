using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Automation
{
    class JKartablTable : JTable
    {
        #region Properties
        
        /// <summary>
        ///کد پست کاربر 
        /// </summary>
        public int User_post_code;
        /// <summary>
        ///کد پدر
        /// </summary>
        public int parent_code;
        /// <summary>
        ///نام کارتابل 
        /// </summary>
        public string Name;
        /// <summary>
        ///  تاریخ ایجاد 
        /// </summary>
        public DateTime Create_Date_Time;

        #endregion

        public JKartablTable() :
            base(JTableNamesAutomation.Folders, "")
        {
          
        }
        
    }

    public enum Kartabl
    {
        Code,
        /// <summary>
        ///کد پست کاربر 
        /// </summary>
        User_post_code,
        /// <summary>
        ///کد پدر
        /// </summary>
        parent_code,
        /// <summary>
        ///نام کارتابل 
        /// </summary>
        Name,
        /// <summary>
        ///  تاریخ ایجاد 
        /// </summary>
        Create_Date_Time,
    }
    

    class JDynamickartablTable : JTable
    {
        #region Properties

        /// <summary>
        /// کد کارتابل
        /// </summary>
        public int Kartabl_code;
        /// <summary>
        ///کد پست کاربر
        /// </summary>
        public int User_post_code;
        /// <summary>
        /// نوع شی
        /// </summary>
        public string Object_type;

        #endregion
        public JDynamickartablTable() :
            base(JTableNamesAutomation.DynamicKartabl, "")
        {
        }
    }

     public enum Dynamickartabl
     {
        #region Properties
        /// <summary>
        /// کد
        /// </summary>
        Code,
        /// <summary>
        /// کد کارتابل
        /// </summary>
        Kartabl_code,
        /// <summary>
        ///کد پست کاربر
        /// </summary>
        User_post_code,
        /// <summary>
        /// نوع شی
        /// </summary>
        Object_type,
        #endregion
     }

}
