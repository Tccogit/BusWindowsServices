using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment
{
    class JOwnerTable:ClassLibrary.JTable
    {
        public DateTime StartDate;
        public DateTime EndDate;
        public int BusCode;
        public int CodePerson;
        public bool IsActive;
        public JOwnerTable()
            : base("AUTBusOwner")
        {
        }
    }
}
