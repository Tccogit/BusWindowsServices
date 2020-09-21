using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JObjectTable: JTable
    {
        #region Properties
        /// <summary>
        /// نوع شی
        /// </summary>
        public int objecttype ;
        /// <summary>
        /// آدرس تابعی که هنگام انتخاب شی باید اجرا شود
        /// </summary>
        public string action ;
        /// <summary>
        /// کد شی در سیستم خودش
        /// </summary>
        public int externalcode ;
        /// <summary>
        /// کد پست فرستنده
        /// </summary>
        public int sender_post_code ;
        /// <summary>
        /// کد کاربر فرستنده
        /// </summary>
        public int sender_user_code ;
        /// <summary>
        /// عنوان کامل فرستنده
        /// </summary>
        public string sender_full_title ;
        /// <summary>
        /// تاریخ و زمان ایجاد
        /// </summary>
        public DateTime create_date_time ;
        /// <summary>
        /// عنوان شی
        /// </summary>
        public string title ;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string description;

        #endregion

        public JObjectTable()
            : base(JTableNamesAutomation.Objects)
        {

        }
    }
        public enum Objects
        {
            Code,
            /// <summary>
            /// آدرس تابعی که هنگام انتخاب شی باید اجرا شود
            /// </summary>
            action,
            /// <summary>
            /// کد شی در سیستم خودش
            /// </summary>
            ObjectCode,
            /// <summary>
            /// کد پست فرستنده
            /// </summary>
            sender_post_code,
            /// <summary>
            /// کد کاربر فرستنده
            /// </summary>
            sender_user_code,
            /// <summary>
            /// عنوان کامل فرستنده
            /// </summary>
            sender_full_title,
            /// <summary>
            /// تاریخ و زمان ایجاد
            /// </summary>
            create_date_time,
            /// <summary>
            /// عنوان شی
            /// </summary>
            title,
            /// <summary>
            /// توضیحات
            /// </summary>
            description,
        }

    }

