using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JAllPersonTable:JTable 
    {
        public JAllPersonTable()
            : base(JTableNamesClassLibrary.AllPerson)
        {
        }
        #region Properties
        /// <summary>
        /// کد
        /// </summary>
        public int Code;
        /// <summary>
        /// نام
        /// </summary>
        public string Name;
        /// <summary>
        /// شماره شناسنامه / شماره ثبت
        /// </summary>
        public string IDNo;
        /// <summary>
        /// فعال / غیر فعال
        /// </summary>
        public bool Active;
        /// <summary>
        /// نوع شخص (حقیقی / حقوقی)
        /// </summary>
        public int PersonType;

        #endregion
    }
}
