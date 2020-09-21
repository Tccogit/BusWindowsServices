using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Employment
{
    public class JEPersonPostTable :JTable
    {
        /// <summary>
        /// کد شخص
        /// </summary>
        public int PCode;
        /// <summary>
        /// کد پست
        /// </summary>
        public int PostCode ;
        /// <summary>
        /// وضعیت پست
        /// </summary>
        public int State ;
        /// <summary>
        /// تاریخ شروع
        /// </summary>
        public DateTime DateStart ;
        /// <summary>
        /// تاریخ پایان
        /// </summary>
        public DateTime DateEnd ;
        /// <summary>
        /// شماره قرارداد
        /// </summary>
        public int ContractCode ;
        
        public JEPersonPostTable()
            : base("personpost")
        { 
        }
    }
}
