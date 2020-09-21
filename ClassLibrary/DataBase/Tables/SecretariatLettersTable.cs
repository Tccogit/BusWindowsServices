using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Communication
{
    public class JSecretariatLettersTable : JTable
    {
        #region Properties
        
        /// <summary>
        /// کد نامه
        /// </summary>
        public int Letter_Code { get; set; }
        /// <summary>
        /// کد دبیرخانه
        /// </summary>
        public int secretariat_code { get; set; }
        /// <summary>
        /// شماره ثبت 
        /// </summary>
        public int register_no { get; set; }
        /// <summary>
        /// شماره نامه 
        /// </summary>
        public string letter_no { get; set; }
        /// <summary>
        /// تاریخ ثبت 
        /// </summary>
        public DateTime register_date_time { get; set; }
        /// <summary>
        /// پست ثبت کننده 
        /// </summary>
        public int register_post_code { get; set; }

        #endregion
        public JSecretariatLettersTable() :
            base(JTableNamesLetters.secretariatLetters, "")
        {
        }
    }

    public enum secretariatLetters
    {
         #region Properties
        
        Code,
        /// <summary>
        /// کد نامه
        /// </summary>
        Letter_Code,
        /// <summary>
        /// کد دبیرخانه
        /// </summary>
        secretariat_code,
        /// <summary>
        /// شماره ثبت 
        /// </summary>
        register_no,
        /// <summary>
        /// شماره نامه 
        /// </summary>
        letter_no,
        /// <summary>
        /// تاریخ ثبت 
        /// </summary>
        register_date_time,
        /// <summary>
        /// پست ثبت کننده 
        /// </summary>
        register_post_code,

        #endregion
    }
}
