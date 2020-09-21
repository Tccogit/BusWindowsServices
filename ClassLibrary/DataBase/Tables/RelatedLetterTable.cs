using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    class JRelatedLetterTable :JTable
    {
        #region Peroperties
        /// <summary>
        /// کد نامه
        /// </summary>
        public int letter_code;
        /// <summary>
        /// کد نامه وابسته
        /// </summary>
        public int dependent_LetterCode;
        /// <summary>
        /// نوع  عطف/پیرو
        /// </summary>
        public int type;
        
        #endregion Peroperties

        public JRelatedLetterTable()
            : base(JTableNamesLetters.LetterDependent, "")
        {
        }   
    }

    public enum LetterDependent
    {
        Code,
        /// <summary>
        /// کد نامه
        /// </summary>
        letter_code,
        /// <summary>
        /// کد نامه وابسته
        /// </summary>
        dependent_LetterCode,
        /// <summary>
        /// نوع  عطف/پیرو
        /// </summary>
        type,
    }
}

