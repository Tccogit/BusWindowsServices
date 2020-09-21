using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JConnectionsTable: JTable
    {

        public string ClassName;
        public int ObjectCode;
        public string DataBaseName;
        public string ServerName;
        public string UserName;
        public string Password;

        public JConnectionsTable()
            : base("clsConnections")
        {
        }
    }
}
