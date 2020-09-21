using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary.EMail
{
    public class JEMailReceivedTable : ClassLibrary.JTable
    {
        public JEMailReceivedTable()
            : base("EMailReceived")
        {
        }

        #region Properties
        public int EmailCode;
        public string UID;
        public string Subject;
        public string MessageFrom;
        public string MessageTo;
        public string CC;
        public string BCC;
        public string Text;
        public string HTML;
        public DateTime DateSent;
        public int Status;
        public int Relevant_Person_Code;
        #endregion

    }
}
