using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;


namespace ClassLibrary
{
    public class JConnectionTable: JTable
    {
        public JConnectionTable()
            : base(JTableNamesClassLibrary.ConnectionsTable)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        public string ClassName;
        /// <summary>
        /// 
        /// </summary>
        public int ObjectCode;
        /// <summary>
        /// 
        /// </summary>
        public string ServerName;
        /// <summary>
        /// 
        /// </summary>
        public string DataBaseName;
        /// <summary>
        /// 
        /// </summary>
        public string UserName;
        /// <summary>
        /// 
        /// </summary>
        public string Password;
        /// <summary>
        /// 
        /// </summary>
        public JDataBaseType DataBaseType;
    }
}
