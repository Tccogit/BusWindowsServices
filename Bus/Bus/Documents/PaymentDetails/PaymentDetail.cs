using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusManagment.Documents
{
    public class JAUTPaymentDetail:JSystem
    {
        #region Properties
        public int Code{get;set;}
        /// <summary>
        /// کد پرداخت
        /// </summary>
        public int PaymentCode{get;set;}
        /// <summary>
        /// کد مالک
        /// </summary>
        public int OwnerPCode{get;set;}
        /// <summary>
        /// کد اتوبوس
        /// </summary>
        public int BusCode{get;set;}
        /// <summary>
        /// مبلغ پرداخت شده
        /// </summary>
        public decimal TotalPrice{get;set;}
        /// <summary>
        /// مبلغ قابل پرداخت
        /// </summary>
        public decimal PaymentPrice{get;set;}
        #endregion Properties

        public int Insert(JDataBase pDB)
        {
            JAUTPaymentDetailTable AT = new JAUTPaymentDetailTable();
            AT.SetValueProperty(this);
            Code = AT.Insert(pDB);
            return Code;
        }
   
    }

    public class JAUTPaymentDetails : JSystem
    {
        public static DataTable GetData(int pDocumentCode)
        {

            JDataBase DB = new JDataBase();
            try
            {
              string query = @"
              Select AUTPaymentDetail.OwnerPCode ,AUTPaymentDetail.BusCode , clsAllPerson .Name 
					,IsNull((Select Top 1 AccountNo FROM finBankAccount WHERE PCode = clsAllPerson.Code Order By finBankAccount.Code Desc  ), '') AccountNo
                    , AUTBus.BUSNumber,Cast( TotalPrice AS bigint) TotalPrice ,Cast( PaymentPrice AS bigint) PaymentPrice
             from AUTPaymentDetail 
	            INNER JOIN clsAllPerson ON clsAllPerson .Code = AUTPaymentDetail.OwnerPCode 
	            INNER JOIN AUTBus ON AUTBus .Code = AUTPaymentDetail.BusCode  ";
                if (pDocumentCode > 0)
                    query += " AND PaymentCode = " + pDocumentCode;
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
        public static bool Delete(JDataBase DB, int pPaymentCodeCode)
        {
            try
            {
                string query = @"delete from AUTPaymentDetail where PaymentCode = " + pPaymentCodeCode;
                DB.setQuery(query);
                return DB.Query_Execute() >= 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }
    }

}
