using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace BusManagment.Bus
{
    public class JBusOwner
    {

        public int Code { get; set; }
        /// <summary>
        /// Car Code
        /// </summary>
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int BusCode { get; set; }
        public int CodePerson { get; set; }
        public bool IsActive { get; set; }

        public JBusOwner()
        {
        }
        public JBusOwner(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }
        public int Insert(JDataBase db = null)
        {
            JOwnerTable AT = new JOwnerTable();
            AT.SetValueProperty(this);
            if (db == null)
                Code = AT.Insert();
            else
                Code = AT.Insert(db);
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JBusOwner", Code, 0, 0, 0, "ثبت مالک اتوبوس", "", 0);
            return Code;
        }
        public bool Delete()
        {
            JOwnerTable AT = new JOwnerTable();
            AT.SetValueProperty(this);
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JBusOwner", AT.Code, 0, 0, 0, "حذف مالک اتوبوس", "", 0);
            return AT.Delete();
        }
        public bool Update()
        {
            JOwnerTable AT = new JOwnerTable();
            AT.SetValueProperty(this);
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JBusOwner", AT.Code, 0, 0, 0, "ویرایش مالک اتوبوس", "", 0);
            return AT.Update();
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTBusOwner where Code=" + pCode.ToString());
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

    public class JBusOwners
    {

        public static void DeleteByBusCode(int pBusCode, JDataBase DB)
        {
            DB.setQuery(@" Delete from AUTBusOwner  WHERE BusCode = " + pBusCode.ToString());
            DB.Query_Execute();
        }

        public DataTable GetWebOwners(int pBusCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"Select
                                    ROW_NUMBER() over (order by AUTBusOwner.CodePerson desc) as N'ردیف',
                                    AUTBusOwner.CodePerson as N'کد شخص',
                                    clsAllPerson.Name as N'نام شخص',
                                    dbo.DateEnToFa(AUTBusOwner.StartDate) as N'تاریخ شروع',
                                    dbo.DateEnToFa(AUTBusOwner.EndDate) as N'تاریخ پایان',
                                    case AUTBusOwner.IsActive  when 0 then N'False' else N'True' end as 'وضعیت'
                                    FROM dbo.AUTBusOwner  
                                    INNER JOIN dbo.AUTBus  ON AUTBusOwner.BusCode = AUTBus.Code
                                    INNER JOIN dbo.clsAllPerson  ON clsAllPerson.Code = AUTBusOwner.CodePerson
                                    WHERE AUTBusOwner.BusCode= " + pBusCode.ToString());
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static DataTable GetDataTable(int pBusCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"SELECT 
		                AUTBusOwner.code, clsAllPerson.Name, AUTBusOwner.IsActive
		                ,dbo.DateEnToFa(AUTBusOwner.StartDate) StartDate
		                ,dbo.DateEnToFa(AUTBusOwner.EndDate) EndDate
		                FROM dbo.AUTBusOwner  
		                INNER JOIN dbo.AUTBus  ON AUTBusOwner.BusCode = AUTBus.Code
		                INNER JOIN dbo.clsAllPerson  ON clsAllPerson.Code = AUTBusOwner.CodePerson " +
                          " WHERE AUTBusOwner.BusCode=" + pBusCode.ToString());
                return DB.Query_DataTable();
            }
            finally
            {
                DB.Dispose();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pBusCode"></param>
        /// <returns></returns>
        public static DataTable GetAllOwners()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"SELECT 
		                AUTBusOwner.code,clsAllPerson.Code OwnerPCode,  clsAllPerson.Name, AUTBusOwner.IsActive
		                ,dbo.DateEnToFa(AUTBusOwner.StartDate) StartDate
		                ,dbo.DateEnToFa(AUTBusOwner.EndDate) EndDate
		                FROM dbo.AUTBusOwner  
		                INNER JOIN dbo.AUTBus  ON AUTBusOwner.BusCode = AUTBus.Code
		                INNER JOIN dbo.clsAllPerson  ON clsAllPerson.Code = AUTBusOwner.CodePerson ");
                         //  (pBusCode > 0 ? @" WHERE AUTBusOwner.BusCode=" + pBusCode.ToString() : ""));
                return DB.Query_DataTable();
            }
            finally
            {
                DB.Dispose();
            }
        }

        /// <summary>
        /// دریافت تمامی مالکان اتوبوس ها
        /// </summary>
        /// <returns></returns>
        public static DataTable GetBusOwners(int pCode = 0)
        {

            string PermitionSql = " and " + ClassLibrary.JPermission.getObjectSql("BusManagment.Bus.JBusOwners.GetBusOwners", "cap.Code");
            if (PermitionSql.Length < 5)
            {
                PermitionSql = "";
            }

            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"SELECT cap.Code as Code,cap.Name,(cast(Code as varchar) + ' - '+cap.Name)OwnerWithCode FROM clsAllPerson cap WHERE cap.Code IN (
		                SELECT DISTINCT CodePerson FROM AUTBusOwner ao)
                        " + PermitionSql + (pCode > 0 ? " and cap.Code = " + pCode : "") + @"
		                ORDER BY cap.Name");
                return DB.Query_DataTable();
            }
            finally
            {
                DB.Dispose();
            }
        }

        /// <summary>
        /// چک میکند که اتوبوس بیش از یک مالک فعال نداشته باشد
        /// </summary>
        /// <param name="pBusCode"></param>
        /// <returns></returns>
        public static bool CheckHasOneActiveOwner(int pBusCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"SELECT Code From AUTBusOwner  WHERE AUTBusOwner.BusCode=" + pBusCode.ToString() + " AND ISActive = 1 ");
                return (DB.Query_DataTable().Rows.Count == 0);
            }
            finally
            {
                DB.Dispose();
            }
        }
    }
}

