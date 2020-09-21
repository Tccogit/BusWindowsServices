using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ClassLibrary
{
    class AdvocateTable : JTable
    {
        #region Property

        /// <summary>
        /// کد شخص
        /// </summary>
        public int Person_Code { get; set; }
        /// <summary>
        /// کد وکالت
        /// </summary>
        public int Advocacy_Code { get; set; }
        /// <summary>
        /// تاریخ شروع
        /// </summary>
        public DateTime Start_Date { get; set; }
        /// <summary>
        /// تاریخ پایان
        /// </summary>
        public DateTime End_Date { get; set; }

        #endregion

       public AdvocateTable()
       : base(JTableNamesLegal.AdvocacyTable)
        {

        }
    }

    public enum LegAdvocate
    {
        Code,
        /// <summary>
        /// کد شخص
        /// </summary>
        Person_Code,
        /// <summary>
        /// کد وکالت
        /// </summary>
        Advocacy_Code,
        /// <summary>
        /// تاریخ شروع
        /// </summary>
        Start_Date,
        /// <summary>
        /// تاریخ پایان
        /// </summary>
        End_Date,
    }
}
