using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ClassLibrary
{
    public class JSubjectContractTable : JTable
    {
        #region Properties
        
        /// <summary>
        /// نوع قرارداد
        /// </summary>
        public int Type;
        /// <summary>
        /// شماره قرارداد
        /// </summary>
        public string Number;
        /// <summary>
        /// تاریخ قرارداد
        /// </summary>
        public DateTime Date;
        /// <summary>
        /// تاریخ تحویل
        /// </summary>
        public DateTime DateDeliver;
        /// <summary>
        /// تاریخ شروع قرارداد
        /// </summary>
        public DateTime StartDate;
        /// <summary>
        /// تاریخ پایان قرارداد
        /// </summary>
        public DateTime EndDate;
        /// <summary>
        /// محل انجام
        /// </summary>
        public int Location;
        /// <summary>
        /// کد اموال
        /// </summary>
        public int FinanceCode;
        /// <summary>
        /// میزان سهم مشخص گردد
        /// </summary>
        public string FinancePercent;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Descrition;

        #endregion Properties

        public JSubjectContractTable()
            : base(JTableNamesLegal.SubjectContract, "")
        {
        }
    }

    public enum LegSubjectContract
    {
        #region Properties
        
        Code,
        /// <summary>
        /// نوع قرارداد
        /// </summary>
        Type,
        /// <summary>
        /// شماره قرارداد
        /// </summary>
        Number,
        /// <summary>
        /// تاریخ قرارداد
        /// </summary>
        Date,
        DateFa,
        /// <summary>
        /// تاریخ تحویل
        /// </summary>
        DateDeliver,
        /// <summary>
        /// تاریخ شروع قرارداد
        /// </summary>
        StartDate,
        StartDateFa,
        /// <summary>
        /// تاریخ پایان قرارداد
        /// </summary>
        EndDate,
        EndDateFa,
        /// <summary>
        /// محل انجام
        /// </summary>
        Location,
        /// <summary>
        /// کد اموال
        /// </summary>
        FinanceCode,
        /// <summary>
        /// میزان سهم مشخص گردد
        /// </summary>
        FinancePercent,
        /// <summary>
        /// توضیحات
        /// </summary>
        Descrition,

        #endregion Properties
    }
}
