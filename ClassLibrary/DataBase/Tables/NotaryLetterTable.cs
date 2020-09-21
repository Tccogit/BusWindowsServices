using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ClassLibrary
{
    class JNotaryLetterTable : JTable
    {

        #region Property

        /// <summary>
        /// کد محضر
        /// </summary>
        public int Notary_Code { get; set; }
        /// <summary>
        /// کد وکالت
        /// </summary>
        public int Advocacy_Code { get; set; }
        /// <summary>
        /// شماره نامه
        /// </summary>
        public string LetterNumber { get; set; }
        /// <summary>
        /// تاریخ نامه
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// موضوع
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }

        #endregion

        public JNotaryLetterTable()
            : base(JTableNamesLegal.LegNotaryLetterTable)
        {

        }
    }

    public enum NotaryLetter
    {

    #region Property

        Code,
        /// <summary>
        /// کد محضر
        /// </summary>
        Notary_Code,
        /// <summary>
        /// کد وکالت
        /// </summary>
        Advocacy_Code,
        /// <summary>
        /// شماره نامه
        /// </summary>
        LetterNumber,
        /// <summary>
        /// تاریخ نامه
        /// </summary>
        Date,
        /// <summary>
        /// موضوع
        /// </summary>
        Subject,
        /// <summary>
        /// توضیحات
        /// </summary>
        Description,
    #endregion
    }
}
