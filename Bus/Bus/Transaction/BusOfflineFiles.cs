using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace BusManagment
{
    public class JBusOfflineFiles
    {  

        public int Code { get; set; }
        public DateTime Date { get; set; }
        public int SenderPersonCode { get; set; }
        public int ArchiveCode { get; set; }
        public int Status { get; set; }
        public DateTime ProcessDate { get; set; }
        public int TransactionCount { get; set; }
        public int BusCode { get; set; }
        public string Discription { get; set; }

        public JBusOfflineFiles()
        {
        }
        public JBusOfflineFiles(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }
        public int Insert(JDataBase db = null)
        {
            JBusOfflineFilesTable AT = new JBusOfflineFilesTable();
            AT.SetValueProperty(this);
            if (db == null)
                Code = AT.Insert();
            else
                Code = AT.Insert(db);
            return Code;
        }
        public bool Delete()
        {
            JBusOfflineFilesTable AT = new JBusOfflineFilesTable();
            AT.SetValueProperty(this);
            return AT.Delete();
        }
        public bool Update()
        {
            JBusOfflineFilesTable AT = new JBusOfflineFilesTable();
            AT.SetValueProperty(this);
            return AT.Update();
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTBusOfflineFiles where code=" + pCode.ToString());
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
    }

    public class JBusOfflineFileses
    {

        public static DataTable GetDataTable(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"SELECT abof.code,abof.Date,cap.Name,ab.BusNumber,abof.Discription,abof.ArchiveCode,abof.[Status],abof.ProcessDate,abof.TransactionCount,abof.InsertDate
                                FROM AUTBusOfflineFiles abof
                                LEFT JOIN clsAllPerson cap ON abof.SenderPersonCode = cap.Code 
                                Left Join AutBus ab on ab.Code = abof.BusCode
                                where abof.code=" + pCode.ToString());
                return DB.Query_DataTable();
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static string GetWebQuery()
        {
            return @"SELECT top 100 percent abof.code,abof.Date,cap.Name,ab.BusNumber,abof.Discription,abof.ArchiveCode,abof.[Status],abof.ProcessDate,abof.TransactionCount,abof.InsertDate
                                FROM AUTBusOfflineFiles abof
                                LEFT JOIN clsAllPerson cap ON abof.SenderPersonCode = cap.Code
                                Left Join AutBus ab on ab.Code = abof.BusCode";
        }
    }
}
