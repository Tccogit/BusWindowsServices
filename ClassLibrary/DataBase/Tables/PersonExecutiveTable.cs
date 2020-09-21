using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ClassLibrary
{
    class JPersonExecutiveTable : JTable
    {
        #region Property
        /// <summary>
        /// کد اجرائیه
        /// </summary>
        public int ExecutiveCode;
        /// <summary>
        /// کد شخص
        /// </summary>
        public int PersonCode;
        /// <summary>
        /// نوع شخص
        /// </summary>
        public int Type;

        #endregion

        public JPersonExecutiveTable()
            : base(JTableNamesLegal.PersonExecute, "")
        {
        }
    }

    public enum LegPersonExecutive
    {
        Code,
        /// <summary>
        /// کد اجرائیه
        /// </summary>
        ExecutiveCode,
        /// <summary>
        /// کد شخص
        /// </summary>
        PersonCode,
        /// <summary>
        /// نوع شخص
        /// </summary>
        Type,
    }
}
