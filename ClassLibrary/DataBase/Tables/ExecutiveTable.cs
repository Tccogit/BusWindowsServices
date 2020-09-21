using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ClassLibrary
{
    class JExecutiveTable : JTable
    {
        #region Property
        /// <summary>
        /// کد رای
        /// </summary>
        public int DecisionCode;
        /// <summary>
        /// تاریخ اجرائیه
        /// </summary>
        public DateTime ExecuteDate;
        /// <summary>
        /// شماره کلاسه اجرائی
        /// </summary>
        public string ExecuteNum;
        /// <summary>
        /// توضیحات اجرائیه
        /// </summary>
        public string ExeDesc;
        /// <summary>
        /// شماره کلاسه اجرای احکام
        /// </summary>
        public string ExeNum;

        #endregion

        public JExecutiveTable()
            : base(JTableNamesLegal.Executive, "")
        {
        }
    }

    public enum LegExecute
    {
        #region Property

        Code,
        /// <summary>
        /// کد رای
        /// </summary>
        DecisionCode,
        /// <summary>
        /// تاریخ اجرائیه
        /// </summary>
        ExecuteDate,
        /// <summary>
        /// شماره کلاسه اجرائی
        /// </summary>
        ExecuteNum,
        /// <summary>
        /// توضیحات اجرائیه
        /// </summary>
        ExeDesc,
        /// <summary>
        /// شماره کلاسه اجرای احکام
        /// </summary>
        ExeNum,

        #endregion
    }
}
