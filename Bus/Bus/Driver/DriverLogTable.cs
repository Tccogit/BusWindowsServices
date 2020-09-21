using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.Driver
{
    public class JDriverLogTable : ClassLibrary.JTable
    {
        public DateTime EventDate;
        public int LogType;
        public JDriverLogTable()
            : base("AUTDriveLog")
        {
        }
    }
}
