using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace BusManagment
{
    public class JBusFailure
    {

        public int Code { get; set; }
        public DateTime Date { get; set; }
        public int BusCode { get; set; }
        public int BusFailureCode { get; set; }
        public string Description { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public JBusFailure()
        {
        }
        public JBusFailure(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }
        public int Insert(JDataBase db = null)
        {
            JBusFailureTable AT = new JBusFailureTable();
            AT.SetValueProperty(this);
            if (db == null)
                Code = AT.Insert();
            else
                Code = AT.Insert(db);
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JBusFailure", Code, 0, 0, 0, "ثبت دلیل عدم کارکرد اتوبوس", "", 0);
            return Code;
        }
        public bool Delete()
        {
            JBusFailureTable AT = new JBusFailureTable();
            AT.SetValueProperty(this);
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JBusFailure", AT.Code, 0, 0, 0, "حذف دلیل عدم کارکرد اتوبوس", "", 0);
            return AT.Delete();
        }
        public bool Update()
        {
            JBusFailureTable AT = new JBusFailureTable();
            AT.SetValueProperty(this);
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JBusFailure", AT.Code, 0, 0, 0, "ویرایش دلیل عدم کارکرد اتوبوس", "", 0);
            return AT.Update();
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTBusFailure where code=" + pCode.ToString());
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

    public class JBusFailures
    {

        public static void DeleteByBusCode(int pBusCode, JDataBase DB)
        {
            DB.setQuery(@" Delete from AUTBusFailure  WHERE BusCode = " + pBusCode.ToString());
            DB.Query_Execute();
        }

        public static DataTable GetDataTable(int pBusCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"select abf.Code,abf.[Date],ab.BUSNumber,sdf.name FailureName,
                    abf.[Description],abf.InsertDate
                    from AUTBusFailure abf
                    left join AutBus ab on ab.Code = abf.BusCode
                    left join subdefine sdf on sdf.Code = abf.BusFailureCode Where abf.BusCode = " + pBusCode.ToString());
                return DB.Query_DataTable();
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static string GetWebQuery()
        {
            string PermitionSql = " And " + JPermission.getObjectSql("BusManagment.Bus.JBuses.GetAllBusesOnly", "abf.BusCode");
            return @"select abf.Code,abf.[Date],abf.StartTime,abf.EndTime,ab.BUSNumber,sdf.name FailureName,
                    abf.[Description],abf.InsertDate
                    from AUTBusFailure abf
                    left join AutBus ab on ab.Code = abf.BusCode
                    left join subdefine sdf on sdf.Code = abf.BusFailureCode
                    where 1 = 1 " + PermitionSql;
        }

    }
}
