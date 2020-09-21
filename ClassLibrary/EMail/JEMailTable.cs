using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary.EMail
{
    public class JEMailTable : ClassLibrary.JTable
    {
        public JEMailTable()
            : base("JEmailTable")
        {
        }

        #region Properties
        public int UserCode;
        public int UserPostCode;
        public string Name;
        public string Description;
        public string ServerName;
        public string UserName;
        public string Password;
        public bool AutoSync;
        #endregion
    }
}
