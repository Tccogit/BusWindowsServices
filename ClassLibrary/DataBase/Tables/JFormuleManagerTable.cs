using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    class JFormuleManagerTable : JTable
    {
        public JFormuleManagerTable()
            : base("FormuleManager")
        {

        }

        #region Fields
        public int user_code;
        public string Name;
        public string ClassName;
        public string Formule;
        public bool Numeric;
        #endregion
    }
}
