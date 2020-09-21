using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusManagment.AVL
{
    public static class JAVLTransaction
    {
        public static DataTable GetDataTable(string buses = "")
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery("Select * from AUTAvlTransaction where Code in (select MAX(code) From AUTAvlTransaction GROUP BY BUSCode) AND BusCode in(" + buses + ")");
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }

        }

        public static bool SetBusPosition(Int64 recordNumber, uint BusSerial, float Lat, float Lng, DateTime Date, ClassLibrary.JDataBase db)
        {
            //ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery("Select * from AUTBusPosition where BusSerial = " + BusSerial);

                string date = Date.ToString("yyyy-MM-dd HH:mm:ss");
                if (db.Query_DataTable().Rows.Count > 0)
                {
                    db.setQuery(@"update AUTBusPosition set LastRecordNumber = " + recordNumber + @", Lat = '" + Lat.ToString() + "', Lng = '" + Lng.ToString() + "', Date = CAST('" + date + "' as datetime)" +
                                    " where BusSerial = " + BusSerial + " and Date < CAST('" + date + "' as datetime)");
                    db.Query_Execute();
                    return true;
                }
                else
                {
                    db.setQuery("insert into AUTBusPosition(Code, BusSerial, Lat, Lng, [Date], LastRecordNumber)" +
                                "VALUES(isnull((Select MAX(Code) From AUTBusPosition), 0) + 1, " + BusSerial + ", '" + Lat + "', '" + Lng + "', CAST('" + date + "' as datetime), " + recordNumber + ")");
                    if (db.Query_Execute() >= 0) return true;
                    return false;
                }
            }
            finally
            {
                //db.Dispose();
            }
        }
    }
}
