using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusManagment.Documents
{
    public class JAUTDocumentReport
    {
        public static JNode GetTreeNode()
        {
            JNode Node = new JNode(0, "Documents.JAUTDocumentReportForm");
            Node.Name = "Reports";
            JAction Ac = new JAction("Reports", "BusManagment.Documents.JAUTDocumentReportForm.ShowDialog", null, null, false);
            Node.MouseClickAction = Ac;
            return Node;
        }

        public static DataTable GetData(int pOwnerCode, int pBusCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string filter = " ";
                if (pOwnerCode > 0)
                {
                    filter += " AND OwnerPCode = " + pOwnerCode;
                }
                if (pBusCode > 0)
                {
                    filter += " AND BusCode = " + pBusCode;
                }
                string Query = string.Format(@"
                        Select (Select Fa_Date FROM StaticDates WHERE En_Date = Date) Date,clsAllPerson .Name  , AUTBus .BUSNumber ,Cast(Bed AS bigint) Bed , Cast(Bes AS bigint) Bes  from 
                        (
	                        Select AUTDocument.IssueDate 'Date' ,AUTDocument.Description , BusCode , OwnerPCode , Sum(Amount) Bes, 0 Bed from AUTDocument 
		                        INNER JOIN AUTDocumentDetail ON AUTDocument.Code = AUTDocumentDetail.DocumentCode 
		                        Where 1 = 1
		                        Group By AUTDocument.IssueDate ,AUTDocument.Description , BusCode , OwnerPCode
	                        Union All	

	                        Select AUTPayment.PaymentDate ,AUTPayment.Description , BusCode , OwnerPCode ,0 Bes, Sum(PaymentPrice) Bed from AUTPayment 
		                        INNER JOIN AUTPaymentDetail ON AUTPayment.Code = AUTPaymentDetail.PaymentCode 
		                        Where 1 = 1
		                        Group By AUTPayment.PaymentDate ,AUTPayment.Description , BusCode , OwnerPCode
                        ) A
                        Inner Join clsAllPerson ON clsAllPerson.Code = OwnerPCode 
                        Inner Join AUTBus ON AUTBus.Code = BusCode 
                         Where Bed>0 OR Bes>0 Order By   OwnerPCode , BusCode , Date ", filter);
                DB.setQuery(Query);
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

        public static string GetWebQuery(int pOwnerCode, int pBusCode, DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {

            //string PermitionSql = " AND " + ClassLibrary.JPermission.getObjectSql("BusManagment.Bus.JBuses.GetAllBusesOnly", "BusCode");
            //if (PermitionSql.Length < 5)
            //{
            //    PermitionSql = "";
            //}

            string PermitionSql = " and " + ClassLibrary.JPermission.getObjectSql("BusManagment.Bus.JBusOwners.GetBusOwners", "clsAllPerson.Code");
            if (PermitionSql.Length < 5)
            {
                PermitionSql = "";
            }


            string filter = " ";
            if (pOwnerCode > 0)
            {
                filter += " AND OwnerPCode = " + pOwnerCode;
            }
            //if (pBusCode > 0)
            //{
            //    filter += " AND BusCode = " + pBusCode;
            //}

            string WhereStr = "";
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            if (StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime)
            {
                WhereStr += " AND convert(date,Date) Between '" + StartEventDate.Value.Date.ToShortDateString() + " 00:00:00' and '"
                    + EndEventDate.Value.Date.ToShortDateString() + " 23:59:59'";
            }

            //            string QueryOLD = @"
            //                        Select top 100 percent clsAllPerson.Code As Code,DCode DocumentCode,(Select Fa_Date FROM StaticDates WHERE En_Date = Date) FaDate,Date as DocumentDate,
            //                        clsAllPerson .Name,clsAllPerson .TafsiliCode  ,A.Description, AUTBus .BUSNumber ,Cast(Bed AS bigint) * 10 as Bedehkar , Cast(Bes AS bigint) * 10 as Bestankar  from 
            //                        (
            //	                        Select max(AUTDocument.Code)DCode,AUTDocument.IssueDate 'Date' ,AUTDocument.Description , BusCode , OwnerPCode , Sum(Amount) * 10 as Bes, 0 Bed from AUTDocument 
            //		                        INNER JOIN AUTDocumentDetail ON AUTDocument.Code = AUTDocumentDetail.DocumentCode 
            //		                        Where 1 = 1 " + filter + PermitionSql + @"
            //		                        Group By AUTDocument.IssueDate ,AUTDocument.Description , BusCode , OwnerPCode
            //	                        Union All	
            //
            //	                        Select max(AUTPayment.Code)PCode,AUTPayment.PaymentDate ,AUTPayment.Description , BusCode , OwnerPCode ,0 Bes, Sum(PaymentPrice) * 10 as Bed from AUTPayment 
            //		                        INNER JOIN AUTPaymentDetail ON AUTPayment.Code = AUTPaymentDetail.PaymentCode 
            //		                        Where 1 = 1 " + filter + PermitionSql + @"
            //		                        Group By AUTPayment.PaymentDate ,AUTPayment.Description , BusCode , OwnerPCode
            //                        ) A
            //                        Inner Join clsAllPerson ON clsAllPerson.Code = OwnerPCode 
            //                        Inner Join AUTBus ON AUTBus.Code = BusCode 
            //                         Where (Bed>0 OR Bes>0) " + WhereStr + @" Order By   OwnerPCode , BusCode , Date ";

            string Query = @"Select top 100 percent clsAllPerson.Code As Code,DCode DocumentCode,(Select Fa_Date FROM StaticDates WHERE En_Date = Date) FaDate,Date as DocumentDate,
                        clsAllPerson .Name,clsAllPerson .TafsiliCode  ,A.Description ,Cast(Bed AS bigint) * 10 as Bedehkar , Cast(Bes AS bigint) * 10 as Bestankar  from 
                        (
	                        Select max(AUTDocument.Code)DCode,AUTDocument.IssueDate 'Date' ,AUTDocument.Description , OwnerPCode , Sum(Amount) * 10 as Bes, 0 Bed from AUTDocument 
		                        INNER JOIN AUTDocumentDetail ON AUTDocument.Code = AUTDocumentDetail.DocumentCode 
		                        Where 1 = 1 " + filter + @"
		                        Group By AUTDocument.IssueDate ,AUTDocument.Description , OwnerPCode
	                        Union All	

	                        Select max(AUTPayment.Code)PCode,AUTPayment.PaymentDate ,AUTPayment.Description , OwnerPCode ,0 Bes, Sum(PaymentPrice) * 10 as Bed from AUTPayment 
		                        INNER JOIN AUTPaymentDetail ON AUTPayment.Code = AUTPaymentDetail.PaymentCode 
		                        Where 1 = 1 " + filter + @"
		                        Group By AUTPayment.PaymentDate ,AUTPayment.Description , OwnerPCode
                        ) A
                        Inner Join clsAllPerson ON clsAllPerson.Code = OwnerPCode 
                        --Inner Join AUTBus ON AUTBus.Code = BusCode 
                         Where (Bed>0 OR Bes>0) " + WhereStr + @" " + PermitionSql + @"  Order By   OwnerPCode  , Date";

            return Query;
        }



        public static string GetDocumentDetaileWebQuery(int pOwnerCode, int pBusCode, DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {

            string PermitionSql = " AND " + ClassLibrary.JPermission.getObjectSql("BusManagment.Bus.JBuses.GetAllBusesOnly", "BusCode");
            if (PermitionSql.Length < 5)
            {
                PermitionSql = "";
            }

            string WhereStr = " where 1 = 1 ";
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            if (StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime)
            {
                WhereStr += " AND cast(ad.InsertDate as Date) Between '" + StartEventDate.Value.Date.ToShortDateString() + " 00:00:00' and '"
                    + EndEventDate.Value.Date.ToShortDateString() + " 23:59:59'";
            }

            if (pOwnerCode > 0)
            {
                WhereStr += " AND apd.OwnerPCode = " + pOwnerCode;
            }
            if (pBusCode > 0)
            {
                WhereStr += " AND apd.BusCode = " + pBusCode;
            }

            string Query = @"
                        select apd.Code,ab.BusNumber,Cap.Name as OwnerName,apd.PaymentPrice,ad.Description,ad.InsertDate from AUTPaymentDetail apd
                            left join AUTDocument ad on apd.PaymentCode = ad.Code
                            left join AUTBus ab on apd.BusCode = ab.Code
                            left join ClsAllPerson Cap on Cap.Code = apd.OwnerPCode " + WhereStr + PermitionSql;
            return Query;
        }



        public static string GetDocumentOwnerPaymentWebQuery(int pOwnerCode, int pBusCode, DateTime? StartEventDate = null, DateTime? EndEventDate = null, int DocumentCode = 0)
        {
            string PermitionSql = " AND " + ClassLibrary.JPermission.getObjectSql("BusManagment.Bus.JBuses.GetAllBusesOnly", "adprb.BusCode");
            if (PermitionSql.Length < 5)
            {
                PermitionSql = "";
            }

            //string CardTypePermitionSql = JPermission.getObjectSql("BusManagment.Card.JCards.GetDataTable", "Code");
            //string FinalCardType = "";
            //if (CardTypePermitionSql == " 1 = 1 ")
            //{
            //    CardTypePermitionSql = "";
            //}
            //else
            //{
            //    JDataBase mydb = new JDataBase();
            //    mydb.setQuery("Select Type From AutCardType Where " + CardTypePermitionSql);
            //    DataTable DtCardType = mydb.Query_DataTable();
            //    FinalCardType = "and DP.CardType in (" + String.Join(",", JDataBase.DataTableToStringtArray(DtCardType, "Type")) + ")";
            //}

            string WhereStr = " where adprb.CardType = 0 ";
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            if (StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime)
            {
                WhereStr += " AND adprb.[Date] Between '" + StartEventDate.Value.Date.ToShortDateString() + " 00:00:00' and '"
                    + EndEventDate.Value.Date.ToShortDateString() + " 23:59:59'";
            }

            if (pOwnerCode > 0)
            {
                WhereStr += " AND adprb.OwnerCode = " + pOwnerCode;
            }
            if (pBusCode > 0)
            {
                WhereStr += " AND adprb.BusCode = " + pBusCode;
            }

            if (DocumentCode > 0)
                WhereStr += " AND adprb.DocumentCode = " + DocumentCode;

            string Query = @"
                       select adprb.Code,
                            (Select Fa_Date FROM StaticDates WHERE En_Date = CAST(adprb.[Date] AS Date ))WorkDate
                            ,ab.BusNumber,cap.Name OwnerName,adprb.TicketPrice,adprb.Price,adprb.TCount TransactionCount,adprb.DocumentCode PaymentPrice
                            from AUTDailyPerformanceRportOnBus adprb
                            left join AutBus ab on ab.Code = adprb.BusCode
                            left join clsAllPerson cap on cap.Code = adprb.OwnerCode
                            left join AutDocument ad on ad.Code = adprb.DocumentCode" + WhereStr + PermitionSql;
            return Query;
        }


        public static string GetDocumentDriverPaymentWebQuery(int pDriverCode, int pBusCode, DateTime? StartEventDate = null, DateTime? EndEventDate = null, int DocumentCode = 0)
        {
            string PermitionSql = " AND " + ClassLibrary.JPermission.getObjectSql("BusManagment.Bus.JBuses.GetAllBusesOnly", "adprb.BusCode");
            if (PermitionSql.Length < 5)
            {
                PermitionSql = "";
            }

            //string CardTypePermitionSql = JPermission.getObjectSql("BusManagment.Card.JCards.GetDataTable", "Code");
            //string FinalCardType = "";
            //if (CardTypePermitionSql == " 1 = 1 ")
            //{
            //    CardTypePermitionSql = "";
            //}
            //else
            //{
            //    JDataBase mydb = new JDataBase();
            //    mydb.setQuery("Select Type From AutCardType Where " + CardTypePermitionSql);
            //    DataTable DtCardType = mydb.Query_DataTable();
            //    FinalCardType = "and DP.CardType in (" + String.Join(",", JDataBase.DataTableToStringtArray(DtCardType, "Type")) + ")";
            //}

            string WhereStr = " where adprb.CardType = 0 ";
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            if (StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime)
            {
                WhereStr += " AND adprb.[Date] Between '" + StartEventDate.Value.Date.ToShortDateString() + " 00:00:00' and '"
                    + EndEventDate.Value.Date.ToShortDateString() + " 23:59:59'";
            }

            if (pDriverCode > 0)
            {
                WhereStr += " AND cap.Code = " + pDriverCode;
            }
            if (pBusCode > 0)
            {
                WhereStr += " AND adprb.BusCode = " + pBusCode;
            }

            if (DocumentCode > 0)
                WhereStr += " AND adprb.DocumentCode = " + DocumentCode;

            string Query = @"
                       select adprb.Code,
                             dbo.DateEnToFa(adprb.[Date])WorkDate
                            ,ab.BusNumber,cap.Name DriverName,adprb.TicketPrice,adprb.Price,adprb.TCount TransactionCount,adprb.DocumentCode
                            ,ad.[Description],ad.InsertDate
                            from AUTDailyPerformanceRportOnBus adprb
                            left join AutBus ab on ab.Code = adprb.BusCode
							left join Cards c on c.RfidNumber = adprb.DriverCardSerial
                            left join clsAllPerson cap on cap.Code = c.PCode
                            left join AutDocument ad on ad.Code = adprb.DocumentCode " + WhereStr + PermitionSql;
            return Query;
        }



        public static string GetConsoleAndPortalTransactionWebQuery(int pBusCode, DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {
            string PermitionSql = " AND " + ClassLibrary.JPermission.getObjectSql("BusManagment.Bus.JBuses.GetAllBusesOnly", "ab.Code");
            if (PermitionSql.Length < 5)
            {
                PermitionSql = "";
            }

            string WhereStr = " where 1 = 1";
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            if (StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime)
            {
                WhereStr += " AND apr.[StartDate] Between '" + StartEventDate.Value.Date.ToShortDateString() + " 00:00:00' and '"
                    + EndEventDate.Value.Date.ToShortDateString() + " 23:59:59'";
            }

            if (pBusCode > 0)
            {
                WhereStr += " AND ab.Code = " + pBusCode;
            }

            string Query = @"
                       select apr.Code,apr.BusNumber,apr.StartDate,apr.EndDate,
                            apr.TicketCount ConsoleTicketCount,apr.TicketSent ConsoleTicketSent,
                            (select sum(Tcount) from AUTDailyPerformanceRportOnBus 
                            where Buscode = (select Code from AUTBus where BusNumber = apr.BusNumber) and CardType = 0 and [Date] between apr.StartDate and apr.EndDate)PortalTransaction 
                            ,case apr.State when 0 then N'عدم دریافت پرینت' else N'پرینت دریافت شده' end As Status
                            from AUTPrinterRporte apr
                            left join AutBus ab on ab.BusNumber = apr.BusNumber" + WhereStr + PermitionSql;
            return Query;
        }


        public static string GetPaymentedDocumentWebQuery(int pOwnerCode, int pBusCode, DateTime? StartEventDate = null, DateTime? EndEventDate = null, int DocumentCode = 0)
        {
            string PermitionSql = " AND " + ClassLibrary.JPermission.getObjectSql("BusManagment.Bus.JBuses.GetAllBusesOnly", "adprb.BusCode");
            if (PermitionSql.Length < 5)
            {
                PermitionSql = "";
            }

            string WhereStr = " where 1 = 1 ";
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            if (StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime)
            {
                WhereStr += " AND adprb.[Date] Between '" + StartEventDate.Value.Date.ToShortDateString() + " 00:00:00' and '"
                    + EndEventDate.Value.Date.ToShortDateString() + " 23:59:59'";
            }

            if (pOwnerCode > 0)
            {
                WhereStr += " AND adprb.OwnerCode = " + pOwnerCode;
            }
            if (pBusCode > 0)
            {
                WhereStr += " AND adprb.BusCode = " + pBusCode;
            }

            if (DocumentCode > 0)
                WhereStr += " AND adprb.DocumentCode = " + DocumentCode;

            string Query = @"
                       select adprb.Code,
                            (Select Fa_Date FROM StaticDates WHERE En_Date = CAST(adprb.[Date] AS Date ))WorkDate
                            ,ab.BusNumber,cap.Name OwnerName,adprb.TicketPrice,adprb.Price,adprb.TCount TransactionCount,adprb.DocumentCode
                            ,ad.[Description],ad.InsertDate
                            from AUTDailyPerformanceRportOnBus adprb
                            left join AutBus ab on ab.Code = adprb.BusCode
                            left join clsAllPerson cap on cap.Code = adprb.OwnerCode
                            left join AutDocument ad on ad.Code = adprb.DocumentCode " + WhereStr + PermitionSql;
            return Query;
        }



        public static string GetPeriodPaymentWebQuery(int pOwnerCode, int pBusCode, DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {

            string PermitionSql = " AND " + ClassLibrary.JPermission.getObjectSql("BusManagment.Bus.JBuses.GetAllBusesOnly", "BusCode");
            if (PermitionSql.Length < 5)
            {
                PermitionSql = "";
            }

            string WhereStr = " where 1 = 1 ";
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            if (StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime)
            {
                WhereStr += " AND cast(ad.InsertDate as Date) Between '" + StartEventDate.Value.Date.ToShortDateString() + " 00:00:00' and '"
                    + EndEventDate.Value.Date.ToShortDateString() + " 23:59:59'";
            }

            if (pOwnerCode > 0)
            {
                WhereStr += " AND apd.OwnerPCode = " + pOwnerCode;
            }
            if (pBusCode > 0)
            {
                WhereStr += " AND apd.BusCode = " + pBusCode;
            }

            string Query = @"
                        select max(apd.Code)Code,ab.BusNumber,Cap.Name as OwnerName,sum(apd.PaymentPrice)PaymentPrice,max(ad.Description)Description,max(ad.InsertDate)InsertDate from AUTPaymentDetail apd
                            left join AUTDocument ad on apd.PaymentCode = ad.Code
                            left join AUTBus ab on apd.BusCode = ab.Code
                            left join ClsAllPerson Cap on Cap.Code = apd.OwnerPCode " + WhereStr + PermitionSql + " GROUP BY ab.BusNumber,Cap.Name";
            return Query;
        }

        public static string GetLinePeriodPaymentWebQuery(int LineCode = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {

            string PermitionSql = " AND " + ClassLibrary.JPermission.getObjectSql("BusManagment.Bus.JBuses.GetAllBusesOnly", "BusCode");
            if (PermitionSql.Length < 5)
            {
                PermitionSql = "";
            }

            string WhereStr = " where 1 = 1 ";
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            if (StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime)
            {
                WhereStr += " AND cast(ad.InsertDate as Date) Between '" + StartEventDate.Value.Date.ToShortDateString() + " 00:00:00' and '"
                    + EndEventDate.Value.Date.ToShortDateString() + " 23:59:59'";
            }

            string Query = @"
                        select max(apd.Code)Code,ab.LastLineNumber,Cap.Name as OwnerName,
                            sum(apd.PaymentPrice)PaymentPrice,isnull(max(ad.InsertDate),getdate())InsertDate
                            from AUTPaymentDetail apd
                            left join AUTDocument ad on apd.PaymentCode = ad.Code
                            left join AUTBus ab on apd.BusCode = ab.Code
                            left join ClsAllPerson Cap on Cap.Code = apd.OwnerPCode 
                            " + WhereStr + PermitionSql + @"
                            GROUP BY ab.LastLineNumber,Cap.Name";
            return Query;
        }

        public static DataTable GetSumPeriodPaymentWebQuery(DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {
            string filter = "";
            JDataBase DB = new JDataBase();
            try
            {
                DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
                if (StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime)
                {
                    filter += " where ad.InsertDate Between '" + StartEventDate.Value.Date.ToShortDateString() + " 00:00:00' and '" +
                        EndEventDate.Value.Date.ToShortDateString() + " 23:59:59'";
                }
                string Query = @"
                   select max(apd.Code)Code,sum(apd.PaymentPrice)PaymentPrice,max(ad.InsertDate)InsertDate
                    from AUTPaymentDetail apd
                    left join AUTDocument ad on apd.PaymentCode = ad.Code " + filter;
                DB.setQuery(Query);
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


        public static DataTable GetSumData(int pOwnerCode, int pBusCode, DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {

            string PermitionSql = " and " + ClassLibrary.JPermission.getObjectSql("BusManagment.Bus.JBusOwners.GetBusOwners", "OwnerPCode");
            if (PermitionSql.Length < 5)
            {
                PermitionSql = "";
            }

            JDataBase DB = new JDataBase();
            try
            {
                string filter = " ", filter2 = " ";
                if (pOwnerCode > 0)
                {
                    filter += " AND OwnerPCode = " + pOwnerCode;
                    filter2 += " AND OwnerPCode = " + pOwnerCode;
                }
                //if (pBusCode > 0)
                //{
                //    filter += " AND BusCode = " + pBusCode;
                //    filter2 += " AND BusCode = " + pBusCode;
                //}

                DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
                if (StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime)
                {
                    filter += " AND convert(date,AUTDocument.IssueDate) Between '" + StartEventDate.Value.Date.ToShortDateString() + " 00:00:00' and '" +
                        EndEventDate.Value.Date.ToShortDateString() + " 23:59:59'";
                    filter2 += " AND convert(date,AUTPayment.PaymentDate) Between '" + StartEventDate.Value.Date.ToShortDateString() + " 00:00:00' and '" +
                        EndEventDate.Value.Date.ToShortDateString() + " 23:59:59'";
                }
                string Query = @"
                    Select ISNULL(Cast(Sum(Bed) AS bigint) , 0) * 10 as Bed  ,ISNULL(Cast(Sum(Bes) AS bigint), 0) * 10 as Bes   from 
                        (
	                        Select  Sum(Amount) * 10 as Bes, 0 Bed from AUTDocument 
		                        INNER JOIN AUTDocumentDetail ON AUTDocument.Code = AUTDocumentDetail.DocumentCode 
		                        Where 1 = 1 " + filter + PermitionSql + @"
		                        Group By    OwnerPCode
	                        Union All	

	                        Select  0 Bes, Sum(PaymentPrice) * 10 as Bed from AUTPayment 
		                        INNER JOIN AUTPaymentDetail ON AUTPayment.Code = AUTPaymentDetail.PaymentCode 
		                        Where 1 = 1 " + filter2 + PermitionSql + @"
		                        Group By   OwnerPCode
                        ) A ";
                DB.setQuery(Query);
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
