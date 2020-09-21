using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JHistoryTable:JTable
    {
        //public int HCode;
        public int ObjectCode;
        public int ObjectCode1;
        public int ObjectCode2;
        public int ObjectCode3;
        public string ClassName;
        public DateTime Date;
        public int UserCode;
        public int PostCode;
        public string History;
        public bool AllFields;
        public string Description;

        public JHistoryTable()
            : base(JTableNamesClassLibrary.History)
        {
        }

    }

    public enum JHistoryTableEnum
    {
        Code,
        ObjectCode,
        ObjectCode1,
        ObjectCode2,
        ObjectCode3,
        ClassName,
        Date,
        UserCode,
        PostCode,
        History,
        AllFields,
        Description
    }
}
