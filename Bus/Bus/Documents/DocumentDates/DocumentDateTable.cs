using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.Documents
{
    public class JAUTDocumentDateTable :JTable
    {
        public JAUTDocumentDateTable()
            : base("AUTDocumentDate")
        {
        }
        #region Properties
        /// <summary>
        /// کد سند
        /// </summary>
        public int DocumentCode;
        /// <summary>
        /// تاریخ
        /// </summary>
        public DateTime Date;
        /// <summary>
        /// این تاریخ صادر شده
        /// </summary>
        public bool IsIssued;
        
        #endregion Properties 
    }
}
