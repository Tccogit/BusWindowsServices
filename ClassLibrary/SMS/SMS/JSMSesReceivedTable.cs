using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary.SMS
{
    public class JSMSesReceivedTable : ClassLibrary.JTable
    {
        public JSMSesReceivedTable()
            : base("SMSesReceived")
        { }

        public string SMS_Text;
        public string Sender_Number;
        public int Sender_PersonCode;
        public string Sender_Full_Title;
        public DateTime Send_Date;
        public DateTime Service_Read_Date;
        public int Status;

    }
}
