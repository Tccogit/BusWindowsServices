using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.Reader
{
    class JReaderTable : ClassLibrary.JTable
    {
        public long MicID;
        public int ReaderVersion;
        public int ModuleVersion;
        public int ModuleSerial;
        public int SamSerial;
        public int SamVersion;
        public int BusNumber;
        public int ReaderId;
        public long IMEI;
        public DateTime VersionDate;
        public JReaderTable()
            : base("ReaderVersion")
        {
        }
    }
}
