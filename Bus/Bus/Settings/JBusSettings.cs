using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusManagment.Settings
{
    public class JBusSettings
    {
        public static bool Set(string KeyName, object KeyValue)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery("Select * from AUTSettings Where KeyName = N'" + KeyName + "'");
                if (db.Query_DataReader() && db.DataReader.Read())
                    db.setQuery("Update AUTSettings SET KeyValue = N'" + KeyValue + "' Where KeyName=N'" + KeyName + "'");
                else
                    db.setQuery("Insert into AUTSettings (KeyName, KeyValue) VALUES(N'" + KeyName + "', N'" + KeyValue + "')");
                db.DataReader.Close();
                return db.Query_Execute() >= 0 ? true : false;
            }
            finally
            {
                db.Dispose();
            }
        }

        public static object Get(string KeyName)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery("Select * from AUTSettings where KeyName = N'" + KeyName + "'");
                DataTable dt = db.Query_DataTable();
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["KeyValue"];
                }
                else
                {
                    return "";
                }
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
