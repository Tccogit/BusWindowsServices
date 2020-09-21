using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    class JCLetterAttachmetTable : ClassLibrary.JTable
    {
        #region feilds
        /// <summary>
        /// کد نامه
        /// </summary>
        public int letter_code;
        /// <summary>
        /// نام فایل
        /// </summary>
        public string file_name;
        /// <summary>
        /// عنوان فایل
        /// </summary>
        public string file_title;
        /// <summary>
        /// نوع ضمیمه
        /// </summary>
        public int file_type;
        /// <summary>
        /// کد پست ایجاد کننده
        /// </summary>
        public int creator_user_post;
        /// <summary>
        /// کد کاربر ایجاد کننده
        /// </summary>
        public int creator_user_code;
        /// <summary>
        /// نام کامل ایجاد کننده
        /// </summary>
        public string creator_user_full_title;
        /// <summary>
        /// تاریخ و زمان ایجاد
        /// </summary>
        public DateTime create_date_time;
        /// <summary>
        /// کد نسخه قبلی
        /// </summary>
        public int previous_version_code;
        /// <summary>
        /// کد فایل ضمیمه
        /// </summary>
        public int letter_file_code;
        /// <summary>
        /// کد فایل ضمیمه در آرشیو
        /// </summary>
        public int archive_file_code;
        /// <summary>
        /// وضعیت حذف
        /// </summary>
        public bool is_deleted;
        /// <summary>
        /// کد پست حذف کننده
        /// </summary>
        public int deleted_user_post;
        /// <summary>
        /// کد کاربر حذف کننده
        /// </summary>
        public int deleted_user_code;
        /// <summary>
        /// نام کامل حذف کننده
        /// </summary>
        public string deleted_user_full_title;
        /// <summary>
        /// وضعیت فایل اصلی بودن
        /// </summary>
        public bool is_main_file;
        /// <summary>
        /// تاریخ و زمان حذف
        /// </summary>
        public DateTime deleted_create_date_time;
        /// <summary>
        /// نوع سایر فایل های غیر از ورد و اسکن شده ها
        /// </summary>
        public int other_file_type;
        #endregion feilds

        public JCLetterAttachmetTable()
            : base(JTableNamesLetters.Letterattachmentfile + "," +
            LetterAttachmets.previous_version_code + "," +
            LetterAttachmets.letter_file_code + "," +
            LetterAttachmets.archive_file_code + "," +
            LetterAttachmets.deleted_user_post + "," +
            LetterAttachmets.deleted_user_code + "," +
            LetterAttachmets.other_file_type)
        {
        }  
    }

    public enum LetterAttachmets
    {
        Code,
        /// <summary>
        /// کد نامه
        /// </summary>
        letter_code,
        /// <summary>
        /// نام فایل
        /// </summary>
        file_name,
        /// <summary>
        /// عنوان فایل
        /// </summary>
        file_title,
        /// <summary>
        /// نوع ضمیمه
        /// </summary>
        file_type,
        /// <summary>
        /// کد پست ایجاد کننده
        /// </summary>
        creator_user_post,
        /// <summary>
        /// کد کاربر ایجاد کننده
        /// </summary>
        creator_user_code,
        /// <summary>
        /// نام کامل ایجاد کننده
        /// </summary>
        creator_user_full_title,
        /// <summary>
        /// تاریخ و زمان ایجاد
        /// </summary>
        create_date_time,
        /// <summary>
        /// کد نسخه قبلی
        /// </summary>
        previous_version_code,
        /// <summary>
        /// کد فایل ضمیمه
        /// </summary>
        letter_file_code,
        /// <summary>
        /// کد فایل ضمیمه در آرشیو
        /// </summary>
        archive_file_code,
        /// <summary>
        /// وضعیت حذف
        /// </summary>
        is_deleted,
        /// <summary>
        /// کد پست حذف کننده
        /// </summary>
        deleted_user_post,
        /// <summary>
        /// کد کاربر حذف کننده
        /// </summary>
        deleted_user_code,
        /// <summary>
        /// نام کامل حذف کننده
        /// </summary>
        deleted_user_full_title,
        /// <summary>
        /// وضعیت فایل اصلی بودن
        /// </summary>
        is_main_file,
        /// <summary>
        /// تاریخ و زمان حذف
        /// </summary>
        deleted_create_date_time,
        /// <summary>
        /// نوع سایر فایل های غیر از ورد و اسکن شده ها
        /// </summary>
         other_file_type,
    }
}
