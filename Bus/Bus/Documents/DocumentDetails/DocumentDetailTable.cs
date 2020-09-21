using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.Documents
{
    public class JAUTDocumentDetailTable :JTable
    {
        public JAUTDocumentDetailTable()
            : base("AUTDocumentDetail")
        {

        }
        #region Properties
        public int DocumentCode;
        public int OwnerPCode;
        public int BusCode;
        public int CardCount;
        public decimal Amount;
        public bool  SentToBank;
        #endregion Properties

    }
}

