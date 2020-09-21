using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace BusManagment.RTPIS
{
    public class JRTPIS
    {
    }
    public class JRTPISUpdate
    {
        public int code { get; set; }
        public Int64 IMEI { get; set; }
        public long Version { get; set; }
        DateTime DateUpDate { get; set; }

        public static bool Find(Int64 pIMEI,long pVersion)
        {
            JConnection C = new JConnection();
            JDataBase DB = new JDataBase(C.GetConnection("Server01", 0));
            try
            {
                DB.setQuery("select * from AUTRTPISUpdate where IMEI=" + pIMEI + " and Version=" + pVersion);
                return DB.Query_DataTable().Rows.Count > 0;
            }
            catch
            {
                return false;
            }
            finally
            {
                C.Dispose();
                DB.Dispose();
            }
        }

        public int Insert()
        {
            try
            {
                DateUpDate = DateTime.Now;
                JRTPISUpdateTable RUT = new JRTPISUpdateTable();
                RUT.SetValueProperty(this);
                return RUT.Insert();
            }
            catch
            {
                return 0;
            }
        }
    }

    public class JRTPISUpdateTable:JTable
    {

        public Int64 IMEI;
        public long Version;
        DateTime DateUpDate;


        public JRTPISUpdateTable()
            : base("AUTRTPISUpdate")
        {
        }
    }
}
