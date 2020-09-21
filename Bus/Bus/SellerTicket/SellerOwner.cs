using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
namespace BusManagment.SellerTicket
{
    public class JSellerOwner :JSystem
    {
        #region Properties
        public int Code { get; set; }
        public int PCode { get; set; }
        public int Code_sellerTicket { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active { get; set; }
        #endregion Properties

        public JSellerOwner()
        {
        }
        public JSellerOwner(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }
        public int Insert(JDataBase db = null)
        { 
            JSellerTicketOwnerTable AT = new JSellerTicketOwnerTable();
            AT.SetValueProperty(this);
            if (db == null)
                Code = AT.Insert();
            else
                Code = AT.Insert(db);
            return Code;
        }
        public bool Update()
        {
            JSellerTicketOwnerTable AT = new JSellerTicketOwnerTable();
            AT.SetValueProperty(this);
            return AT.Update();
        }

        public bool Delete()
        {
            JSellerTicketOwnerTable AT = new JSellerTicketOwnerTable();
            AT.SetValueProperty(this);
            return AT.Delete();
        }
        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTSeller where code=" + pCode.ToString());
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

    public class JSellerOwners : JSystem
    {

        public DataTable GetWebPrices(int pSellerOwnersCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"Select ROW_NUMBER() over (order by AUTSeller.pCode desc) as N'ردیف', 
	                AUTSeller.pCode as N'کد شخص', clsAllPerson.Name as N'نام شخص'
                , (Select Fa_Date FROM StaticDates WHERE En_Date = AUTSeller.StartDate ) as N'تاریخ شروع'
                , (Select Fa_Date FROM StaticDates WHERE En_Date = AUTSeller.EndDate) as N'تاریخ پایان'
                , case AUTSeller.Active when 0 then N'False' else N'True' end as N'وضعیت' from AUTSeller 
                Inner Join clsAllPerson ON AUTSeller .PCode = clsAllPerson.Code WHERE AUTSeller.Code_sellerTicket = " + pSellerOwnersCode.ToString());
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

        public static DataTable GetDataTable(int pSellerTicketCode )
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = @" Select AUTSeller.Code, clsAllPerson.Name 
	                    , (Select Fa_Date FROM StaticDates WHERE En_Date = AUTSeller.StartDate ) StartDate
	                    , (Select Fa_Date FROM StaticDates WHERE En_Date = AUTSeller.EndDate) EndDate
	                    , AUTSeller.Active from AUTSeller 
	                    Inner Join clsAllPerson ON AUTSeller .PCode = clsAllPerson.Code WHERE AUTSeller.Code_sellerTicket =  " + pSellerTicketCode;
                DB.setQuery(query);
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
    }
}
