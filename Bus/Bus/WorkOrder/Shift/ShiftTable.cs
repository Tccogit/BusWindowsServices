using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.WorkOrder
{
    public class JShiftTable :JTable
    {
        public JShiftTable()
            : base("AUTShift")
        {
        }

        #region Properties
        /// <summary>
        /// عنوان
        /// </summary>
        public string Title ;
        /// <summary>
        /// زمان شروع
        /// </summary>
        public TimeSpan StartTime;
        /// <summary>
        /// زمان پایان
        /// </summary>
        public TimeSpan EndTime;
        #endregion Properties
    }
}
