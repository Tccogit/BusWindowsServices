using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment
{
    class JBusInstallAndUnistallDeviseTable:ClassLibrary.JTable
    {
        public DateTime EventDate;
        public int BusCode;
        public int Installer;
        public int DeviceCode;
        public bool Type;
        public int BusFailureCode;
        public string Description;
        public JBusInstallAndUnistallDeviseTable()
            : base("AUTBusInstallAndUnistallDevise")
        {
        }
    }
}
