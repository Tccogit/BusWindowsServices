using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JFormsTable : JTable
    {
        public JFormsTable()
            : base("Forms")
        {
        }

        public string ClassName;
        public string FormName;
        public string SQL;
        public int user_code;
        public DateTime Date;
        public bool isMultiple;
        public string Action;
    }
}
