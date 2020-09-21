using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary.SMS
{
    public class JSMSesTable : ClassLibrary.JTable
    {
        public JSMSesTable()
            : base("SMSes")
        { }

        public string SMS_Text;
        public int SMS_Type;
        public int Register_User_Post_Code;
        public int Register_User_Code;
        public string Register_Full_Title;
        public DateTime Register_Date_Time;
        public int Send_User_Post_Code;
        public int Send_User_Code;
        public string Send_Full_Title;
        public DateTime Send_Date_Time;
        public string RecievedNumber;
        public int TotalSentSMS;
        public int Status;

    }
}
