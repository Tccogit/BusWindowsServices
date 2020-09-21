using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
namespace BusManagment.OnlineReader
{
    public class OnlineReaderConfig
    {
        public int Code { get; set; }
        public Int64 IMEI { get; set; }
        public string ServerIP { get; set; }
        public int ServerPort { get; set; }
        public int BaudRate { get; set; }
        public DateTime DateTime { get; set; }
        public int LineNumber { get; set; }
        public int StationId { get; set; }
        public int ReaderId { get; set; }
        public string Pricetable { get; set; }
        public DateTime GetConfigDate { get; set; }
        public int SendOldTicketCount { get; set; }
        public bool Disable { get; set; }
        public int CRC { get; set; }

        public int Insert(bool isweb = false)
        {
            if (!JPermission.CheckPermission("BusManagment.OnlineReader.OnlineReaderConfig.Insert"))
                return 0;
            OnlineReaderConfigTable ORC = new OnlineReaderConfigTable();
            ORC.SetValueProperty(this);
            Code = ORC.Insert(0, true);
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.OnlineReaderConfig", Code, 0, 0, 0, "تنظیمات کارتخوان آنلاین", "", 0);
            return Code;

        }
        public OnlineReaderConfig()
        {

        }
        public OnlineReaderConfig(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }
        public bool Update(bool isWeb = false)

        {
            //ClassLibrary.JConnection C = new ClassLibrary.JConnection();
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();// C.GetConnection("Server02", 0));
            //** This Is view in Server01
            try
            {
                OnlineReaderConfigTable ORC = new OnlineReaderConfigTable();
                ORC.SetValueProperty(this);
                return ORC.Update(db);
            }
            finally
            {
                db.Dispose();
            }
        }
        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from Erp_tabrizbus2.dbo.AUTOnlineReaderConfig where code=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public class OnlineReaderConfigs
        {
            public DataTable GetOnlineReaderConfig()
            {
                JDataBase db = new JDataBase();
                try
                {
                    db.setQuery("select * from Erp_tabrizbus2.dbo.AUTOnlineReaderConfig");
                    return db.Query_DataTable();
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                    return null;
                }
                finally
                {
                    db.Dispose();
                }
            }
        }


    }
}
