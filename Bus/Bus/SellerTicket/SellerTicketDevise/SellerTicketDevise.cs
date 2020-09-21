using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace BusManagment
{
    public class JSellerTicketDevise
    {  

        public int Code { get; set; }
        /// <summary>
        /// SellerTicekt Code
        /// </summary>
        public DateTime StartDate{ get; set; }
        public DateTime EndDate{ get; set; }
        public int SellerTicketCode { get; set; }
        public int DeviceCode { get; set; }
        public int Installer { get; set; }
        public bool Active { get; set; }

        public JSellerTicketDevise()
        {
        }
        public JSellerTicketDevise(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }
        public int Insert(JDataBase db = null)
        {
            JSellerTicketTable AT = new JSellerTicketTable();
            AT.SetValueProperty(this);
            if (db == null)
                Code = AT.Insert();
            else
                Code = AT.Insert(db);
            return Code;
        }
        public bool Delete()
        {
            JSellerTicketTable AT = new JSellerTicketTable();
            AT.SetValueProperty(this);
            return AT.Delete();
        }
        public bool Update()
        {
            JSellerTicketTable AT = new JSellerTicketTable();
            AT.SetValueProperty(this);
            return AT.Update();
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTSellerTicketDevice where code=" + pCode.ToString());
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

    public class JSellerTicketDevises
    {

        public static void DeleteByBusCode(int pBusCode, JDataBase DB)
        {
            DB.setQuery(@" Delete from AUTSellerTicketDevice  WHERE BusCode = " + pBusCode.ToString());
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
                                from AUTSellerTicket AB
                                inner join AUTSellerTicketDevice ABD ON AB.Code = ABD.SellerTicketCode
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
                        ,AD.ID DeviceID,AD.Tel,AD.MacAddress,AD.IMEI,ABD.SellerTicketCode,ABD.DeviceCode 
                        , person.Name InstallerName
                        from AUTSellerTicket AB
                        inner join AUTSellerTicketDevice ABD ON AB.Code = ABD.SellerTicketCode
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
