using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    class JReferTable : JTable
    {

        #region Properties
        /// <summary>
        ///کد جدول Object
        /// </summary>
        public int object_code ;
        /// <summary>
        ///کد پدر
        /// </summary>
        public int parent_code;
        /// <summary>
        ///کد وطیفه
        /// </summary>
        public int task_code;
        /// <summary>
        /// نوع ارجاع
        /// </summary>
        public int refertype;
        /// <summary>
        /// کد پست فرستنده
        /// </summary>      
        public int sender_post_code ;
        /// <summary>
        /// کد کاربر فرستنده
        /// </summary>
        public int sender_code ;
        /// <summary>
        /// عنوان کامل فرستنده
        /// </summary>
        public string sender_full_title ;
        /// <summary>
        /// تاریخ و زمان ارجاع
        /// </summary>
        public DateTime send_date_time = JDateTime.Now();
        /// <summary>
        /// کد پست گیرنده
        /// </summary>      
        public int receiver_post_code ;
        /// <summary>
        ///کد کاربر گیرنده
        /// </summary>
        public int receiver_code ;
        /// <summary>
        /// عنوان کامل گیرنده
        /// </summary>
        public string receiver_full_title ;
        /// <summary>
        /// وضعیت ارجاع
        /// </summary>
        public int status ;
        /// <summary>
        /// سطح محرمانگی
        /// </summary>
        public int secret_level ;
        /// <summary>
        /// تاریخ و زمان پاسخ
        /// </summary>
        public DateTime response_date_time;
        /// <summary>
        /// تاریخ و زمان مشاهده
        /// </summary>
        public DateTime view_date_time;
        /// <summary>
        /// فعال / غیر فعال
        /// </summary>
        public bool is_active ;
        /// <summary>
        /// دوره پاسخ
        /// </summary>
        public DateTime respite_date_time ;
        /// <summary>
        /// فوریت
        /// </summary>
        public int urgency ;
        /// <summary>
        /// پیام عادی
        /// </summary>
        public string message ;
        /// <summary>
        /// پیام محرمانه
        /// </summary>
        public string message_secret ;
        /// <summary>
        /// پاسخ عادی
        /// </summary>
        public string response ;
        /// <summary>
        /// پاسخ عادی
        /// </summary>
        public string response_secret ;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string description;
        /// <summary>
        /// کد کاربر ثبت کننده
        /// </summary>
        public int register_user_code;
        /// <summary>
        /// تاریخ و زمان ثبت
        /// </summary>
        public DateTime register_Date_Time;
        /// <summary>
        /// ضمائم
        /// </summary>
        public string attachments;

        #endregion

        public JReferTable()
            : base(JTableNamesAutomation.Refer,
            Refer.parent_code  +"," +
            Refer.task_code +"," +
            Refer.receiver_post_code +"," +
            Refer.response_date_time +"," +
            Refer.view_date_time)
        {
        }
    }

    public enum ReferFolder
    {
        ReferCode,
        ReferFolderCode,
        PostCode,
    }

    public enum Refer
        {
        Code,
        /// <summary>
        ///کد جدول Object
        /// </summary>
         object_code ,
        /// <summary>
        ///کد پدر
        /// </summary>
         parent_code,
        /// <summary>
        ///کد وطیفه
        /// </summary>
         task_code,
        /// <summary>
        /// نوع ارجاع
        /// </summary>
         refertype,
        /// <summary>
        /// کد پست فرستنده
        /// </summary>      
         sender_post_code ,
        /// <summary>
        /// کد کاربر فرستنده
        /// </summary>
         sender_code ,
        /// <summary>
        /// عنوان کامل فرستنده
        /// </summary>
         sender_full_title ,
        /// <summary>
        /// تاریخ و زمان ارجاع
        /// </summary>
         send_date_time ,
        /// <summary>
        /// کد پست گیرنده
        /// </summary>      
         receiver_post_code ,
        /// <summary>
        ///کد کاربر گیرنده
        /// </summary>
         receiver_code ,
        /// <summary>
        /// عنوان کامل گیرنده
        /// </summary>
         receiver_full_title ,
        /// <summary>
        /// وضعیت ارجاع
        /// </summary>
         status ,
        /// <summary>
        /// سطح محرمانگی
        /// </summary>
         secret_level ,
        /// <summary>
        /// تاریخ و زمان پاسخ
        /// </summary>
         response_date_time,
        /// <summary>
        /// تاریخ و زمان مشاهده
        /// </summary>
         view_date_time,
        /// <summary>
        /// فعال / غیر فعال
        /// </summary>
         is_active ,
        /// <summary>
        /// دوره پاسخ
        /// </summary>
         respite_date_time ,
        /// <summary>
        /// فوریت
        /// </summary>
         urgency ,
        /// <summary>
        /// پیام عادی
        /// </summary>
         message ,
        /// <summary>
        /// پیام محرمانه
        /// </summary>
         message_secret ,
        /// <summary>
        /// پاسخ عادی
        /// </summary>
          response ,
        /// <summary>
        /// پاسخ عادی
        /// </summary>
         response_secret ,
        /// <summary>
        /// توضیحات
        /// </summary>
         description,
        /// <summary>
        /// کد کاربر ثبت کننده
        /// </summary>
         register_user_code,
        /// <summary>
        /// تاریخ و زمان ثبت
        /// </summary>
         register_Date_Time,
        /// <summary>
        /// ضمائم
        /// </summary>
         attachments,
        }


}
