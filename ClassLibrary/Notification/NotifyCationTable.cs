using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary 
{
    class JNotifyCationTable: JTable
    {
        public int PostCode;
        public string Message;
        public bool Visite;
        public DateTime DateSend;
        public DateTime DateVisite;
        public int ObjectCode;
        public string Action;

        public JNotifyCationTable()
            : base("Notification")
        {
        }
    }
}
