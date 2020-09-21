using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ClassLibrary
{
    class JDecisionTable : JTable
    {

       #region Property

        /// <summary>
        /// کددادخواست
        /// </summary>
        public int PetitionCode;
        /// <summary>
        /// تاریخ رای
        /// </summary>
        public DateTime Date;
        /// <summary>
        /// شماره دادنامه
        /// </summary>
        public string number;
        /// <summary>
        /// نوع رای
        /// </summary>
        public int TypeDecision;
        /// <summary>
        /// بر علیه شرکت
        /// </summary>
        public bool AgainstCompany;
        /// <summary>
        /// نوع آرا / قرار
        /// </summary>
        public bool Type;
        /// <summary>
        /// قطعی
        /// </summary>
        public bool Conclusive;
        /// <summary>
        /// توضیحات رای
        /// </summary>
        public string DecisionDesc;

       #endregion

        public JDecisionTable()
            : base(JTableNamesLegal.Decision, "")
        {
        }
    }
    public enum LegDecision
    {
        #region Property

        Code,
        /// <summary>
        /// کددادخواست
        /// </summary>
        PetitionCode,
        /// <summary>
        /// تاریخ رای
        /// </summary>
        Date,
        /// <summary>
        /// شماره دادنامه
        /// </summary>
        number,
        /// <summary>
        /// نوع رای
        /// </summary>
        TypeDecision,
        /// <summary>
        /// بر علیه شرکت
        /// </summary>
        AgainstCompany,
        /// <summary>
        /// نوع آرا / قرار
        /// </summary>
        Type,
        /// <summary>
        /// قطعی
        /// </summary>
        Conclusive,
        /// <summary>
        /// توضیحات رای
        /// </summary>
        DecisionDesc,

       #endregion
    }
}
