using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment
{
    class JSellerTicketTable:ClassLibrary.JTable
    {
        public DateTime StartDate;
        public DateTime EndDate;
        public int SellerTicketCode;
        public int Installer;
        public int DeviceCode;
        public bool Active;
        public JSellerTicketTable()
            : base("AUTSellerTicketDevice")
        {
        }
    }
}
