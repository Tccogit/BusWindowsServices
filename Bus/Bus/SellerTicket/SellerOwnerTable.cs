using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.SellerTicket
{
    class JSellerTicketOwnerTable : ClassLibrary.JTable
    {    //جدول صاحبان باجه 
        public int Code_sellerTicket;
        public int PCode;
        public DateTime StartDate;
        public DateTime EndDate;
        public bool Active;
        public JSellerTicketOwnerTable()
            : base("AUTSeller")
        {
        }
    }
}
