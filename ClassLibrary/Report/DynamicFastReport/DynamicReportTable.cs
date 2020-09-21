using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JDynamicReportTable: ClassLibrary.JTable
    {
        public string Content;
        public string FileName;
        public string Caption;
        public DateTime CreateDate;
        public int CreatorUserCode;
        public int CreatorPostCode;
        public DateTime LastUpdate;
        public JReportType ReportType;
        public Int64 ReportCode;
        public string Label;
        public bool DefaultPrint;
        public int FileWordCode;
        public bool AccessAll;

        public JDynamicReportTable()
            : base("clsDynamicReport")
        {
        }
    }
}
