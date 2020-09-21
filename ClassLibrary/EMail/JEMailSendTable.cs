using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary.EMail
{
    public class JEMailSendTable : ClassLibrary.JTable
    {

        public JEMailSendTable()
            : base("EmailSend")
        {
        }

        #region Properties
        public int EmailCode;
        public int Parent_EmailCode;
        public int Sender_User_Code;
        public int Sender_Post_Code;
        public string Sender_Full_Title;
        public int Register_User_Code;
        public int Register_Post_Code;
        public string Register_Full_Title;
        public DateTime Register_Date;
        public string Subject;
        public string MessageFrom;
        public string MessageTo;
        public string CC;
        public string BCC;
        public string Text;
        public string HTML;
        public DateTime DateSent;
        public int Status;
        #endregion

    }
}
