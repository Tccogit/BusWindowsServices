using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace BusManagment
{
    public class JBusDevise
    {

        public int Code { get; set; }
        /// <summary>
        /// Car Code
        /// </summary>
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int BusCode { get; set; }
        public int DeviceCode { get; set; }
        public int Installer { get; set; }
        public bool Active { get; set; }

        public JBusDevise()
        {
        }
        public JBusDevise(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }
        public int Insert(JDataBase db = null)
        {
            JBusDeviseTable AT = new JBusDeviseTable();
            AT.SetValueProperty(this);
            if (db == null)
                Code = AT.Insert();
            else
                Code = AT.Insert(db);

            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JBusDevise", Code, 0, 0, 0, "ثبت دستگاه اتوبوس", "", 0);

            return Code;
        }
        public bool Delete()
        {
            JBusDeviseTable AT = new JBusDeviseTable();
            AT.SetValueProperty(this);
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JBusDevise", AT.Code, 0, 0, 0, "حذف دستگاه اتوبوس", "", 0);
            return AT.Delete();
        }
        public bool Update()
        {
            JBusDeviseTable AT = new JBusDeviseTable();
            AT.SetValueProperty(this);
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JBusDevise", AT.Code, 0, 0, 0, "ویرایش دستگاه اتوبوس", "", 0);
            return AT.Update();
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTBusDevise where code=" + pCode.ToString());
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

    public class JBusDevices
    {

        public static void DeleteByBusCode(int pBusCode, JDataBase DB)
        {
            DB.setQuery(@" Delete from AUTBusDevise  WHERE BusCode = " + pBusCode.ToString());
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
                                ,(Select Fa_Date from StaticDates Where En_Date =  ABD.StartDate) as N'تاریخ شروع'
                                ,(Select Fa_Date from StaticDates Where En_Date =  ABD.EndDate) as N'تاریخ پایان'
                                ,CASE WHEN AD.Type=1 THEN N'کنسول' ELSE N'کارتخوان' END as N'نوع دستگاه' 
                                from AUTBus AB
                                inner join AUTBusDevise ABD ON AB.Code = ABD.BusCode
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
                        ,(Select Fa_Date from StaticDates Where En_Date =  ABD.StartDate) StartDate
                        ,(Select Fa_Date from StaticDates Where En_Date =  ABD.EndDate) EndDate
                        ,CASE WHEN AD.Type=1 THEN N'کنسول' ELSE N'کارتخوان' END DeviceType
                        ,AD.ID DeviceID,AD.Tel,AD.MacAddress,AD.IMEI,ABD.BusCode,ABD.DeviceCode 
                        , person.Name InstallerName
                        from AUTBus AB
                        inner join AUTBusDevise ABD ON AB.Code = ABD.BusCode
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
    }
}
