using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.OnlineReader
{
    class OnlineReaderConfigTable: ClassLibrary.JTable
    {

        public Int64 IMEI;
        public string ServerIP;
        public int ServerPort;
        public int BaudRate;
        public DateTime DateTime;
        public int LineNumber;
        public int StationId;
        public int ReaderId;
        public string Pricetable;
        public DateTime GetConfigDate;
        public int SendOldTicketCount;
        public bool Disable;
        public int CRC;

        public OnlineReaderConfigTable() : base("AUTOnlineReaderConfig") { }
    }
}
