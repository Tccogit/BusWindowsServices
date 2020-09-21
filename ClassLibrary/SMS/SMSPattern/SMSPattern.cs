using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassLibrary.SMS
{
    public class JSMSPattern
    {
        #region Constructor
        public JSMSPattern()
        {
        }
        #endregion

        #region Properties
        public int Code { get; set; }
        public string WhiteList { get; set; }
        public string BlackList { get; set; }
        public string Pattern { get; set; }
        public int Type { get; set; }
        public string Action { get; set; }
        public int TimeLimit { get; set; }
        #endregion
    }

    public class JSMSPatterns
    {
        public static DataTable GetDataTable()
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Select * From SMSPattern where Pattern is not null");
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
        public static DataTable GetNullPatterns()
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Select * From SMSPattern where Pattern is null");
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
