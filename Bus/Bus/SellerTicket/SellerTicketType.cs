using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.SellerTicket
{

    class JSellerTicketType : ClassLibrary.JSubBaseDefine
    {
        public JSellerTicketType()
            : base(ClassLibrary.JBaseDefine.TypeSallerTicket)
        {
        }
    }
    public class JSellerTicketTypes : ClassLibrary.JSubBaseDefines
    {
        public JSellerTicketTypes()
            : base(ClassLibrary.JBaseDefine.TypeSallerTicket)
        {
        }
    } 
}
