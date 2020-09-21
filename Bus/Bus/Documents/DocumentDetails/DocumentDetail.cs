using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusManagment.Documents
{
    public class JAUTDocumentDetail
    {
        #region Properties
        public int Code { get; set; }
        public int DocumentCode { get; set; }
        public int OwnerPCode { get; set; }
        public int BusCode { get; set; }
        public int CardCount { get; set; }
        public decimal Amount { get; set; }
        public bool SentToBank { get; set; }
        #endregion Properties

        public int Insert(JDataBase pDB)
        {
            JAUTDocumentDetailTable AT = new JAUTDocumentDetailTable();
            AT.SetValueProperty(this);
            Code = AT.Insert(pDB);
            return Code;
        }

        public bool Update(JDataBase pDB)
        {
            JAUTDocumentDetailTable AT = new JAUTDocumentDetailTable();
            AT.SetValueProperty(this);
            if (AT.Update(pDB))
            {
                return true;
            }
            else
                return false;
        }

        public bool GetData(JDataBase pDB, int pCode)
        {
            JDataBase DB;
            if (pDB != null)
                DB = pDB;
            else
                DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTDocumentDetail where code=" + pCode.ToString());
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
                if (pDB == null)
                    DB.Dispose();
            }
        }

    }

    public class JAUTDocumentDetails
    {
        public static DataTable GetData(int pDocumentCode)
        {

            JDataBase DB = new JDataBase();
            try
            {
                string query = @"
               Select SentToBank , OwnerPCode, clsAllPerson.Name OwnerName  ,  BusCode , BUSNumber ,CardCount Count ,Cast(Amount AS bigint)  SumPrice
	        	from AUTDocumentDetail
	        	Inner Join clsAllPerson ON AUTDocumentDetail.OwnerPCode = clsAllPerson .Code  
				Inner Join AUTBus ON BusCode = AUTBus.Code 
                 WHERE 1=1 ";
                if (pDocumentCode > 0)
                    query += " AND DocumentCode = " + pDocumentCode;
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
        public static bool Delete(JDataBase DB, int pDocumentCode)
        {
            try
            {
                string query = @"delete from AUTDocumentDetail where DocumentCode = " + pDocumentCode;
                DB.setQuery(query);
                return DB.Query_Execute() >= 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        /// <summary>
        /// انتخاب بستانکاری  اتوبوس ها
        /// </summary>
        /// <param name="pDocumentCode"></param>
        /// <returns></returns>
        public static DataTable GetBusCredit(int DocumentCode = 0)
        {

            JDataBase DB = new JDataBase();
            try
            {

                //  string WhereStr = "";
                // if (DocumentCode > 0)
                //   WhereStr = " And dd.DocumentCode = " + DocumentCode;
                string query = "";
                if (DocumentCode > 120000101 & DocumentCode < 121099999)
                {
                    //and TafziliCode1 <> 20000001
                    query = @"select TOP 100 PERCENT " + DocumentCode + @" DocumentCode,a.TafziliCode1 OwnerPCode,(select Name From clsAllPerson where Code = TafziliCode1)OwnerName,
                                (select finBankAccount.AccountNo from finBankAccount where PCode=TafziliCode1) AccountNo,cast(a.TottalPrice*10 as bigint) TotalPrice,cast(a.PaymentPrice*10 as bigint) PaymentPrice from (
                                select TafziliCode1,cast(sum(BesPrice) as float)TottalPrice,cast(sum(BesPrice) as float)PaymentPrice from FinDocumentDetails where DocCode in(" + DocumentCode + @")
                                and TafziliCode1 in (select ObjectCode from finComparativeCode)
                                and TafziliCode1 in (select PCode from finBankAccount)
                                group by TafziliCode1)a";
                }
                else
                {
//                    query = @"select TOP 100 PERCENT DocumentCode,OwnerPCode,OwnerName,AccountNo,TotalPrice,PaymentPrice+pTotalPrice PaymentPrice from
//                                    (
//	                                    select TOP 100 PERCENT *,
//	                                    LAG(TotalPrice,1,0) OVER (PARTITION BY AccountNo order by AccountNo,TotalPrice) pTotalPrice
//	                                    from
//	                                    (
//		                                    select TOP 100 PERCENT Max(DocCode) DocumentCode,TafziliCode1 OwnerPCode,
//                                                                            (select Name From clsAllPerson where Code = TafziliCode1)OwnerName,
//                                                                            (select finBankAccount.AccountNo from finBankAccount where PCode=TafziliCode1) AccountNo
//                                                                            ,CAST(sum(BesPrice)*10 - sum(BedPrice)*10 AS BIGINT) TotalPrice
//                                                                            ,CASE WHEN CAST(sum(BesPrice)*10 - sum(BedPrice)*10 AS BIGINT)<0 THEN 0 ELSE 
//											                                    CAST(sum(BesPrice)*10 - sum(BedPrice)*10 AS BIGINT)
//										                                    END PaymentPrice
//                                                                            from FinDocumentDetails
//																			left join FinDocument on FinDocument.code = FinDocumentDetails.DocCode
//                                                                            where MoeinCode = 3 and (select finBankAccount.AccountNo from finBankAccount where PCode=TafziliCode1) IS NOT NULL
//                                                                            and FinDocument.IsOk = 1
//                                                                            group by TafziliCode1,MoeinCode
//                                                                            having sum(BesPrice) <> sum(BedPrice)
//                                                                            order by TotalPrice 
//	                                    ) as a
//	                                    order by AccountNo,TotalPrice
//                                    )b
//                                    order by TotalPrice";
                    query = @"select TOP 100 PERCENT DocumentCode,OwnerPCode,OwnerName,TafsiliCode,TotalPrice * 10 TotalPrice,PaymentPrice * 10 PaymentPrice from
                                    (
	                                    select TOP 100 PERCENT *
	                                    from
	                                    (
		                                    select TOP 100 PERCENT Max(DocCode) DocumentCode,TafziliCode1 OwnerPCode,
                                                                            (select Name From clsAllPerson where Code = TafziliCode1)OwnerName,
                                                                            --(select finTafzili.Code from finTafzili
																			--where ObjectCode=
																			TafziliCode1 TafsiliCode
                                                                            ,CAST(sum(BesPrice) - sum(BedPrice) AS BIGINT) TotalPrice
                                                                            ,CASE WHEN CAST(sum(BesPrice) - sum(BedPrice) AS BIGINT)<0 THEN 0 ELSE 
											                                    CAST(sum(BesPrice) - sum(BedPrice) AS BIGINT)
										                                    END PaymentPrice
                                                                            from FinDocumentDetails
																			left join FinDocument on FinDocument.code = FinDocumentDetails.DocCode
                                                                            where MoeinCode = 3
                                                                            and FinDocument.IsOk = 1
																			and (select finBankAccount.AccountNo from finBankAccount where PCode=TafziliCode1) IS NOT NULL
                                                                            group by TafziliCode1,MoeinCode
                                                                            having sum(BesPrice) <> sum(BedPrice)
                                                                            order by TotalPrice 
	                                    ) as a
	                                    order by TafsiliCode,TotalPrice
                                    )b
                                    order by PaymentPrice";
                }

                //                string query = @"select Pay.OwnerPCode OwnerPCode,ab.Code BusCode,cap.Name OwnerName,Pay.BusCode-30000000 BusNumber,ab.LastLineNumber,
                //                                fba.AccountNo,(Doc.Price-Pay.Price) * 10 as TotalPrice,isnull(Fin.Price,0) * 10 as PaymentPrice from
                //                                (
                //                                select OwnerPCode,(select 30000000+BusNumber from autbus where code = BusCode) BusCode,sum(PaymentPrice) Price from AUTPaymentDetail group by OwnerPCode,BusCode
                //                                ) Pay
                //                                inner join
                //                                (
                //                                select OwnerCode,(select 30000000+BusNumber from autbus where code = BusCode) BusCode,sum(Price) Price from AUTDailyPerformanceRportOnBus where Error=0 and DocumentCode>0 group by OwnerCode,BusCode
                //                                ) Doc
                //                                ON Doc.BusCode=Pay.BusCode and Doc.OwnerCode=Pay.OwnerPCode
                //                                left join
                //                                (
                //                                select TafziliCode1,TafziliCode2,sum(BesPrice)-sum(BedPrice) Price from FinDocumentDetails where MoeinCode=3 group by TafziliCode1,TafziliCode2 
                //                                ) Fin
                //                                ON Pay.BusCode=Fin.TafziliCode2 and Pay.OwnerPCode=Fin.TafziliCode1
                //                                left join (
                //                                select Code,Name from clsAllPerson
                //                                ) cap on cap.Code = Pay.OwnerPCode
                //                                left join (
                //                                select Code,BusNumber,lastlineNumber from AUTBus
                //                                )ab on ab.BUSNumber = (pay.BusCode - 30000000)
                //                                left join (select * from finBankAccount) fba on fba.PCode = Pay.OwnerPCode
                //                                where
                //                                isnull(Fin.Price,0)>0";

                //                string  query = @"select dd.Code,dd.DocumentCode,dd.OwnerPCode,dd.BusCode,cap.Name OwnerName,ab.BUSNumber,
                //                                    ab.LastLineNumber,fba.AccountNo,Amount * 10 as TotalPrice,Amount * 10 as PaymentPrice
                //                                    from AUTDocumentDetail dd
                //                                    left join clsAllPerson cap on cap.Code = dd.OwnerPCode
                //                                    left join AUTBus ab on ab.Code = dd.BusCode
                //                                    left join finBankAccount fba on fba.PCode = dd.OwnerPCode
                //                                    Where SentToBank = 0 " + WhereStr + @"
                //                                    Order by dd.DocumentCode";

                //                string Very - Old - query = @"
                //            	Select Document.OwnerPCode , Document.BusCode, clsAllPerson .Name OwnerName, AUTBus .BUSNumber ,AUTBus.LastLineNumber 
                //					,IsNull((Select Top 1 AccountNo FROM finBankAccount WHERE PCode = clsAllPerson.Code Order By finBankAccount.Code Desc  ), '') AccountNo
                //	            	,Cast( Document.TotalPrice - ISNULL(Payments .PaymentPrice, 0)  AS bigint) * 10 as TotalPrice
                //	            	,Cast( Document.TotalPrice - ISNULL(Payments .PaymentPrice, 0)  AS bigint) * 10 as PaymentPrice
                //                    from 
                //		            (Select OwnerPCode, BusCode, SUM(Amount) TotalPrice from AUTDocumentDetail Group By OwnerPCode, BusCode) Document
                //		            LEFT JOIN 
                //		            (Select OwnerPCode, BusCode, SUM(PaymentPrice) PaymentPrice from AUTPaymentDetail  Group By OwnerPCode, BusCode)  Payments
                //		            ON Document .OwnerPCode = Payments .OwnerPCode AND Document.BusCode = Payments .BusCode 
                //	                Left JOIN clsAllPerson ON clsAllPerson .Code = Document.OwnerPCode 
                //	                Left JOIN AUTBus ON AUTBus .Code = Document.BusCode 
                //	           WHERE Document.TotalPrice >ISNULL(Payments .PaymentPrice , 0)
                //               order by OwnerName";
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

        public static string GetWebQueryBusCredit()
        {
            string query = @"
            	Select Document.OwnerPCode as Code , Document.BusCode, clsAllPerson .Name OwnerName, AUTBus .BUSNumber  
					,IsNull((Select Top 1 AccountNo FROM finBankAccount WHERE PCode = clsAllPerson.Code Order By finBankAccount.Code Desc  ), '') AccountNo
	            	,Cast( Document.TotalPrice - ISNULL(Payments .PaymentPrice, 0)  AS bigint) TotalPrice
	            	,Cast( Document.TotalPrice - ISNULL(Payments .PaymentPrice, 0)  AS bigint) PaymentPrice
                    from 
		            (Select OwnerPCode, BusCode, SUM(Amount) TotalPrice from AUTDocumentDetail Group By OwnerPCode, BusCode) Document
		            LEFT JOIN 
		            (Select OwnerPCode, BusCode, SUM(PaymentPrice) PaymentPrice from AUTPaymentDetail  Group By OwnerPCode, BusCode)  Payments
		            ON Document .OwnerPCode = Payments .OwnerPCode AND Document.BusCode = Payments .BusCode 
	                Left JOIN clsAllPerson ON clsAllPerson .Code = Document.OwnerPCode 
	                Left JOIN AUTBus ON AUTBus .Code = Document.BusCode 
	           WHERE Document.TotalPrice >ISNULL(Payments .PaymentPrice , 0)";
            return query;
        }


    }


}
