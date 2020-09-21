using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ClassLibrary
{
    public class JTaskTable : JTable
    {

        #region Properties
        
        /// <summary>
        /// نوع شی
        /// </summary>
        public int previouse_task_code;
        /// <summary>
        /// آدرس تابعی که هنگام انتخاب شی باید اجرا شود
        /// </summary>
        public string next_task_code;
        /// <summary>
        /// کد شی در سیستم خودش
        /// </summary>
        public int objecttype;
        /// <summary>
        /// کد پست فرستنده
        /// </summary>
        public string title;
        /// <summary>
        /// کد کاربر فرستنده
        /// </summary>
        public string description;

        #endregion

        public JTaskTable()
            : base(JTableNamesAutomation.Tasks)
        {

        }
    }

         /// <summary>
        /// جدول مرحله
        /// Tasks
        /// </summary>
        public enum Tasks
        {
         Code,
         previouse_task_code,
        /// <summary>
        /// آدرس تابعی که هنگام انتخاب شی باید اجرا شود
        /// </summary> 
         next_task_code,
        /// <summary>
        /// کد شی در سیستم خودش
        /// </summary>
         objecttype,
        /// <summary>
        /// کد پست فرستنده
        /// </summary>
         title,
        /// <summary>
        /// کد کاربر فرستنده
        /// </summary>
         description,
        }
}
