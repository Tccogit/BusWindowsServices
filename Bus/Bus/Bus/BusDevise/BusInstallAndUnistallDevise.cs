using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace BusManagment
{
    public class JBusInstallAndUnistallDevise
    {  

        public int Code { get; set; }
        public DateTime EventDate { get; set; }
        public int BusCode { get; set; }
        public int DeviceCode { get; set; }
        public int Installer { get; set; }
        public bool Type { get; set; }
        public int BusFailureCode { get; set; }
        public string Description { get; set; }

        public JBusInstallAndUnistallDevise()
        {
        }
        public JBusInstallAndUnistallDevise(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }
        public int Insert(JDataBase db = null)
        {
            JBusInstallAndUnistallDeviseTable AT = new JBusInstallAndUnistallDeviseTable();
            AT.SetValueProperty(this);
            if (db == null)
                Code = AT.Insert();
            else
                Code = AT.Insert(db);

            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JBusInstallAndUnistallDevise", Code, 0, 0, 0, "ثبت نصب و فک دستگاه اتوبوس", "", 0);
            return Code;
        }
        public bool Delete()
        {
            JBusInstallAndUnistallDeviseTable AT = new JBusInstallAndUnistallDeviseTable();
            AT.SetValueProperty(this);
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JBusInstallAndUnistallDevise", AT.Code, 0, 0, 0, "حذف نصب و فک دستگاه اتوبوس", "", 0);
            return AT.Delete();
        }
        public bool Update()
        {
            JBusInstallAndUnistallDeviseTable AT = new JBusInstallAndUnistallDeviseTable();
            AT.SetValueProperty(this);
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JBusInstallAndUnistallDevise", AT.Code, 0, 0, 0, "ویرایش نصب و فک دستگاه اتوبوس", "", 0);
            return AT.Update();
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTBusInstallAndUnistallDevise where code=" + pCode.ToString());
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

    public class JBusInstallAndUnistallDevises
    {

        public static void DeleteByBusCode(int pBusCode, JDataBase DB)
        {
            DB.setQuery(@" Delete from AUTBusInstallAndUnistallDevise  WHERE BusCode = " + pBusCode.ToString());
            DB.Query_Execute();
        }

        public DataTable GetWebDevices(int pBusCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"select ROW_NUMBER() over (order by AD.ID desc) as N'ردیف',
                                ABD.DeviceCode as N'کد دستگاه',
                                person.Code as N'کد نصاب'
                                ,person.Name as N'نام نصاب'
                                ,(Select Fa_Date from StaticDates Where En_Date =  ABD.EventDate) as N'تاريخ'
                                ,CASE WHEN AD.Type=1 THEN N'کنسول' ELSE N'کارتخوان' END as N'نوع دستگاه' 
                                from AUTBus AB
                                inner join AUTBusInstallAndUnistallDevise ABD ON AB.Code = ABD.BusCode
                                inner join AUTDevice AD ON AD.Code = ABD.DeviceCode
                                inner join clsAllPerson person on person.Code = ABD.Installer
                                WHERE AB.Code=" + pBusCode.ToString());
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
                DB.setQuery(@"select ABD.Code
                        ,(Select Fa_Date from StaticDates Where En_Date =  ABD.EventDate) EventDate
                        ,CASE WHEN AD.Type=1 THEN N'کنسول' ELSE N'کارتخوان' END DeviceType
                        ,AD.ID DeviceID,AD.Tel,AD.MacAddress,AD.IMEI,ABD.BusCode,ABD.DeviceCode 
                        , person.Name InstallerName
                        from AUTBus AB
                        inner join AUTBusInstallAndUnistallDevise ABD ON AB.Code = ABD.BusCode
                        inner join AUTDevice AD ON AD.Code = ABD.DeviceCode
                        inner join clsAllPerson person on person.Code = ABD.Installer
                        WHERE AB.Code=" + pBusCode.ToString());
                return DB.Query_DataTable();
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static string GetWebQuery()
        {
            return @"select ABD.Code,AB.BUSNumber
                        ,(Select Fa_Date from StaticDates Where En_Date =  ABD.EventDate) EventDate
                        ,CASE WHEN AD.Type=1 THEN N'کنسول' ELSE N'کارتخوان' END DeviceType
                        ,AD.Tel,AD.IMEI 
                        , person.Name InstallerName
                        ,CASE ABD.[TYPE] WHEN 0 THEN N'نصب' ELSE N'فک' END AS [Type]
                        ,sdf.name FailureName
                        ,Description
                        from AUTBus AB
                        inner join AUTBusInstallAndUnistallDevise ABD ON AB.Code = ABD.BusCode
                        inner join AUTDevice AD ON AD.Code = ABD.DeviceCode
                        inner join clsAllPerson person on person.Code = ABD.Installer
                        left join subdefine sdf on sdf.Code = ABD.BusFailureCode";
        }
    }
}
