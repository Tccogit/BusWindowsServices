using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary.Person.PersonChange
{
    public class jRelationTables:JTable
    {

        public string MasterTableName;
        public string SlaveTableName;

        public jRelationTables()
            : base("ClsRelationTables")
        {
        }
    }
}
