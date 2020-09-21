using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.SellerTicket
{
    class JSellerTicketTable:ClassLibrary.JTable
    {   //جدول با جه های اتوبوس 
        public string Adress;
        public string Tel;
        public int Type;
        public int  StationCode;//  نام ایستگاه
        public decimal longs;//  طول جغرافیایی
        public decimal lat;//    عرض جغرافیایی
        public JSellerTicketTable()
            : base("AUTSellerTicket")
        {
        }

    }
  

}
