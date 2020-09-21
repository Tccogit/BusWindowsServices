using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.Documents
{
    public class JAUTDocumentTable :JTable
    {
        public JAUTDocumentTable()
            : base("AUTDocument")
        {
        }
        #region Properties
        /// <summary>
           /// <summary>
        /// تاریخ صدور
        /// </summary>
        public DateTime IssueDate;
        /// <summary>
        /// وضعیت
        /// </summary>
        public bool IsClosed;
        /// <summary>
        /// عنوان ثبت کننده
        /// </summary>
        public string Register_Full_Title;
        /// <summary>
        ///کد  پست سازمانی
        /// </summary>
        public int Register_Post_Code;
        /// <summary>
        /// کد کاربری
        /// </summary>
        public int Register_User_Code;
         /// <summary>
        /// شرح
        /// </summary>
        public string Description;
        /// <summary>
        /// همه تاریخ ها
        /// </summary>
        public bool AllDates;
        /// <summary>
        /// شماره سند
        /// </summary>
        public int DocumentCode;
        #endregion Properties

    }
}
