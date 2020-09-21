using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment
{
    class JBusDeviseTable:ClassLibrary.JTable
    {
        public DateTime StartDate;
        public DateTime EndDate;
        public int BusCode;
        public int Installer;
        public int DeviceCode;
        public bool Active;     
        public JBusDeviseTable()
            : base("AUTBusDevise")
        {
        }
    }
}
