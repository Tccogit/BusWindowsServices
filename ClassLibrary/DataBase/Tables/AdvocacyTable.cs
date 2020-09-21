using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ClassLibrary
{
    class JAdvocacyTable : JTable
    {

        #region Property        
        /// <summary>
        /// تاریخ شروع وکالت
        /// </summary>
        public DateTime StartDate;
        /// <summary>
        /// تاریخ پایان وکالت
        /// </summary>
        public DateTime EndDate;
        /// <summary>
        /// کد نامه محضر
        /// </summary>
        public int NotaryCode;
        /// <summary>
        /// توضیحات اختیارات
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// نوع انحلال
        /// </summary>
        public int Breakup_Type { get; set; }
        /// <summary>
        /// تاریخ انحلال
        /// </summary>
        public DateTime BreakupDate { get; set; }
        /// <summary>
        /// کد نامه انحلال از محضر
        /// </summary>
        public int Breakup_Notary { get; set; }
        /// <summary>
        /// کد نامه انحلال از دادگاه
        /// </summary>
        public int Breakup_tribunal { get; set; }
        /// <summary>
        /// توضیح انحلال
        /// </summary>
        public string BreakupDesc { get; set; }
        /// <summary>
        /// وضعیت وکالت
        /// </summary>
        public Boolean State { get; set; }
        /// <summary>
        /// نوع وکالت
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// تایید شده توسط واحد حقوقی
        /// </summary>
        public Boolean Confirm { get; set; }
        /// <summary>
        /// کد اموال
        /// </summary>
        public int FinanceCode { get; set; }
        #endregion

        public JAdvocacyTable()
            : base(JTableNamesLegal.AdvocacyTable, "")
        {
        }
    }

    public enum LegAdvocacy
    {
        #region Property

        Code,
        /// <summary>
        /// تاریخ شروع وکالت
        /// </summary>
        StartDate,
        /// <summary>
        /// تاریخ پایان وکالت
        /// </summary>
        EndDate,
        /// <summary>
        /// کد نامه محضر
        /// </summary>
        NotaryCode,
        /// <summary>
        /// توضیحات اختیارات
        /// </summary>
        Description,
        /// <summary>
        /// نوع انحلال
        /// </summary>
        Breakup_Type,
        /// <summary>
        /// تاریخ انحلال
        /// </summary>
        BreakupDate,
        /// <summary>
        /// کد نامه انحلال از محضر
        /// </summary>
        Breakup_Notary,
        /// <summary>
        /// کد نامه انحلال از دادگاه
        /// </summary>
        Breakup_tribunal,
        /// <summary>
        /// توضیح انحلال
        /// </summary>
        BreakupDesc,
        /// <summary>
        /// وضعیت وکالت
        /// </summary>
        State,
        /// <summary>
        /// نوع وکالت
        /// </summary>
        Type,
        /// <summary>
        /// تایید شده توسط واحد حقوقی
        /// </summary>
        Confirm,
        /// <summary>
        /// کد اموال
        /// </summary>
        FinanceCode,
        #endregion
    }
}
