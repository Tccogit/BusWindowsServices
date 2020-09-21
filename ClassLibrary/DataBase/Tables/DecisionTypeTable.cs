using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ClassLibrary
{
    class JDecisionTypeTable : JTable
    {

        #region Property

        /// <summary>
        /// کد تصمیم
        /// </summary>
        public int DecisionCode;
        /// <summary>
        /// کد نوع رای
        /// </summary>
        public int Type;

        #endregion

        public JDecisionTypeTable()
            : base(JTableNamesLegal.DecisionType, "")
        {
        }
    }

    public enum LegDecisionType
    {
        
        #region Property
        Code,
        /// <summary>
        /// کد تصمیم
        /// </summary>
        DecisionCode,
        /// <summary>
        /// کد نوع رای
        /// </summary>
        Type,

        #endregion
    }
}
