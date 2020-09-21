using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JRelationTable : JTable
    {

        #region Properties

        /// <summary>
        /// نام کلاس اصلی
        /// </summary>
        public string PrimaryClassName;
        /// <summary>
        /// کد کلاس اصلی
        /// </summary>
        public int PrimaryObjectCode;
        /// <summary>
        /// نام کلاس فرعی
        /// </summary>
        public string ForeignClassName;
        /// <summary>
        /// کد کلاس فرعی
        /// </summary>
        public int ForeignObjectCode;
        /// <summary>
        /// تاریخ ایجاد
        /// </summary>
        public DateTime CreateDate;
        /// <summary>
        /// کد پست کاربر
        /// </summary>
        public int UserPostCode;
        /// <summary>
        /// کد کاربر
        /// </summary>
        public int UserCode;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Comment;

        #endregion

        public JRelationTable()
            : base(JTableNamesClassLibrary.Relation, "")
        {
        }
    }
}
