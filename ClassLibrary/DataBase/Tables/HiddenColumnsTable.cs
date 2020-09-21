using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    class JHiddenColumnsTable : JTable
    {
        public JHiddenColumnsTable()
            : base("HiddenColumns")
        {
        }

        public int user_code;
        public string ClassName;
        public string Columns;

    }
}
