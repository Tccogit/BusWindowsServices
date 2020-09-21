using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Communication
{
    class JCLetterCopyTable :JTable
    {
        #region Peroperties
        /// <summary>
        /// کد نامه
        /// </summary>
        public int letter_code;
        /// <summary>
        /// نوع رونوشت  - داخلی ، خارجی ، شرکت اقماری
        /// </summary>
        public int copy_type;
        /// <summary>
        /// کد پست گیرنده رونوشت
        /// </summary>
        public int receiver_post_code;
        /// <summary>
        /// کد کاربری گیرنده رونوشت
        /// </summary>
        public int receiver_user_code;
        /// <summary>
        /// نام کامل گیرنده رونوشت
        /// </summary>
        public string receiver_full_title;
        /// <summary>
        /// علت رونوشت
        /// </summary>
        public string copy_reason;
        /// <summary>
        /// کد پست اضافه کننده رونوشت
        /// </summary>
        public int register_post_code;
        /// <summary>
        /// کد کاربری اضافه کننده رونوشت
        /// </summary>
        public int register_user_code;
        /// <summary>
        /// نام کامل اضافه کننده رونوشت
        /// </summary>
        public string register_full_title;
        /// <summary>
        /// کد نحوه ارسال
        /// </summary>
        public int send_type;
        /// <summary>
        /// کد سازمان دریافت کننده رونوشت
        /// </summary>
        public int receiver_external_code;
        /// <summary>
        /// کد شرکت اقماری
        /// </summary>
        public int receiver_subsidiaries_code;
        /// <summary>
        /// وضعیت حذف
        /// </summary>
        public bool is_deleted;
        /// <summary>
        /// کد پست حذف کننده
        /// </summary>
        public int deleted_user_post;
        /// <summary>
        /// کد کاربر حرف کننده
        /// </summary>
        public int deleted_user_code;
        /// <summary>
        /// نام کامل حذف کننده
        /// </summary>
        public string deleted_user_full_title;
        #endregion Peroperties

        public JCLetterCopyTable()
            : base("lettercopy", "deleted_user_code,deleted_user_post,receiver_post_code,receiver_user_code,receiver_external_code,receiver_subsidiaries_code")
        {
        }   
    }

    public enum LetterCopy
    {


    }

}
