using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JFormObjectsTable : JTable
    {
        public JFormObjectsTable() :
            base("FormObjects")
        {
        }

        public int FormCode;
        public int ObjectCode;
        public DateTime Date;
        public string Comment;
        public string Description;
		public int NoStorage;

    }
}
