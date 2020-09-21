using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassLibrary;

namespace BusManagment.Reports
{
    public class JDailyPerformanceRportOnBus
    {

        public int Code { get; set; }
        public DateTime Date { get; set; }
        public int BusCode { get; set; }
        public int DriverCode { get; set; }
        public int OwnerCode { get; set; }
        public int LineCode { get; set; }
        public int ZoneCode { get; set; }
        public int Price { get; set; }
        public int TCount { get; set; }
        public int DocumentCode { get; set; }

        public JDailyPerformanceRportOnBus()
        {
        }

        public bool Update(DateTime pDate,
            uint pBusCode,
            string pDriverCode,
            int pOwnerCode,
            uint pLineCode,
            int pZoneCode,
            uint pPrice)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery(@"SELECT Code FROM AUTDailyPerformanceRportOnBus
                            WHERE 
                            CAST(Date as date)=CAST('" + pDate.ToString("yyyy-MM-dd") + @"' as date) AND
                            BusCode=@BusCode AND
                            DriverCode=@DriverCode AND
                            OwnerCode=@OwnerCode AND
                            LineCode=@LineCode AND
                            ZoneCode=@ZoneCode AND 
                            DocumentCode <> 0 AND DocumentCode IS NOT Null ");
                DB.AddParams("Date", pDate);
                DB.AddParams("BusCode", Convert.ToInt32(pBusCode));
                DB.AddParams("DriverCode", pDriverCode);
                DB.AddParams("OwnerCode", pOwnerCode);
                DB.AddParams("LineCode", Convert.ToInt32(pLineCode));
                DB.AddParams("ZoneCode", pZoneCode);
                DB.AddParams("Price", Convert.ToInt32(pPrice));
                System.Data.DataTable DT = DB.Query_DataTable();
                if (DT.Rows.Count > 1)
                {
                }
                else
                    if (DT.Rows.Count == 1)
                    {
                        DB.setQuery(@"UPDATE AUTDailyPerformanceRportOnBus SET Price=Price+@Price , TCount=TCount+1
                                    WHERE Code = " + DT.Rows[0][0].ToString());
                        if (DB.Query_Execute() >= 0) return true;
                        return false;
                    }
                    else
                    {
                        DB.setQuery(@"INSERT INTO AUTDailyPerformanceRportOnBus 
                                        (Code,Date,BusCode,DriverCode,OwnerCode,LineCode,ZoneCode,Price,TCount)
                                        Values(
                                        isnull((Select MAX(Code) From AUTDailyPerformanceRportOnBus), 0) + 1,
                                        @Date,
                                        @BusCode,
                                        @DriverCode,
                                        @OwnerCode,
                                        @LineCode,
                                        @ZoneCode,
                                        @Price,
                                        1
                                        )");
                        if (DB.Query_Execute() >= 0) return true;
                        return false;
                    }
            }
            finally
            {
                DB.Dispose();
            }
            return false;
        }

        public static DataTable ReportDialyPerformance(string pSelect, string pWhere, string pGroupby)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                if (pSelect.Trim() == string.Empty)
                    pSelect = " tbl.Code, tbl.Date, tbl.BUSNumber, tbl.DriverName, tbl.BusOwnerName, tbl.LineName, tbl.LineNumber, tbl.ZoneName, " +
                      "tbl.AddressZone, tbl.TelZone, tbl.Price";

                db.setQuery("select " + pSelect + @" from (select dbo.AUTDailyPerformanceRportOnBus.Code, dbo.AUTDailyPerformanceRportOnBus.Date, dbo.AUTBus.BUSNumber, dbo.clsAllPerson.Name AS DriverName,
	                    clsAllPerson_1.Name AS BusOwnerName, dbo.AUTLine.LineName, dbo.AUTLine.LineNumber, dbo.AUTZone.Name AS ZoneName,
	                    dbo.AUTZone.Address AS AddressZone, dbo.AUTZone.Tel AS TelZone, dbo.AUTDailyPerformanceRportOnBus.Price , dbo.AUTDailyPerformanceRportOnBus.DriverCode,dbo.AUTDailyPerformanceRportOnBus.OwnerCode,dbo.AUTDailyPerformanceRportOnBus.LineCode,dbo.AUTDailyPerformanceRportOnBus.ZoneCode,dbo.AUTDailyPerformanceRportOnBus.BusCode " +
                      @" FROM         AUTDailyPerformanceRportOnBus 
                        left JOIN  AUTZone		ON  AUTZone.Code = AUTDailyPerformanceRportOnBus.ZoneCode 
                        left JOIN  AUTBus		ON AUTDailyPerformanceRportOnBus.BusCode = AUTBus.BUSNumber 
                        left JOIN  AUTBusOwner	ON AUTDailyPerformanceRportOnBus.OwnerCode = AUTBusOwner.Code
                        left JOIN  AUTLine		ON AUTDailyPerformanceRportOnBus.LineCode = AUTLine.LineNumber
                        left JOIN  Cards		ON AUTDailyPerformanceRportOnBus.DriverCode = Cards.CardCode 
                        left JOIN  clsAllPerson ON Cards.PCode = clsAllPerson.Code 
                        left JOIN  clsAllPerson AS clsAllPerson_1 ON clsAllPerson_1.Code = AUTBusOwner.CodePerson ) tbl " + " " + pWhere + " " + pGroupby);

                return db.Query_DataTable();

            }
            catch
            {
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }

        public void ShowForm()
        {
            DailyPerformanceRportOnBusForm form = new DailyPerformanceRportOnBusForm();
            form.ShowDialog();
        }

        public static bool UpdateDocumentCode(int[] Codes, int DocumentCode)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery(string.Format(@"UPDATE AUTDailyPerformanceRportOnBus SET DocumentCode = {0}
                    WHERE Code IN({1})", DocumentCode, JDataBase.GetInSQLClause(Codes)));
                if (DB.Query_Execute() >= 0) return true;
                return false;
            }
            catch
            {
                return false;

            }
            finally
            {
                DB.Dispose();
            }
        }

        /// <summary>
        /// انتخاب تاریخ ها جهت صدور سند
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDatesToIssueDocument()
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery(string.Format(@" Select Distinct  CAST(Date AS Date ) Date
                    -- (Select Fa_Date FROM StaticDates WHERE En_Date = CAST(Date AS Date )) Date 
                      from AUTDailyPerformanceRportOnBus 
                      WHERE DocumentCode = 0 OR DocumentCode IS NULL ORDER BY Date  "));
                return DB.Query_DataTable();
            }
            catch
            {
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        /// <summary>
        /// انتخاب ناوگان ها جهت صدور سند - ناوگان ها
        /// </summary>
        /// <returns></returns>
        public static DataTable GetFleetsToIssueDocument()
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery(string.Format(@"Select distinct af.Name FleetName,af.Code FleetCode
                                                from AUTDailyPerformanceRportOnBus adp
                                                left join AUTBus ab on adp.BusCode = ab.Code
                                                left join AUTFleet af on ab.FleetCode = af.Code
                                                WHERE adp.Tcount > 0 and adp.SetPrinter = 1 and adp.CardType=0 And (adp.DocumentCode < 1 OR adp.DocumentCode IS NULL)
                                                And af.Name Is NOT NULL and adp.Error = 0"));
                return DB.Query_DataTable();
            }
            catch
            {
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        /// <summary>
        /// انتخاب تاریخ ها جهت صدور سند - سال ها
        /// </summary>
        /// <returns></returns>
        public static DataTable GetYearDatesToIssueDocument(int FleetCode)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery(string.Format(@"Select Distinct substring(dbo.DateEnToFa(adp.Date),0,5) Date
                                            from AUTDailyPerformanceRportOnBus adp
                                            left join AUTBus ab on adp.BusCode = ab.Code
                                            WHERE adp.Error = 0 and adp.Tcount > 0 and adp.SetPrinter = 1 and adp.CardType=0 
                                            And (adp.DocumentCode < 1 OR adp.DocumentCode IS NULL) and ab.FleetCode = " + FleetCode.ToString() + " and ab.active = 1 ORDER BY Date "));
                return DB.Query_DataTable();
            }
            catch
            {
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        /// <summary>
        /// انتخاب تاریخ ها جهت صدور سند - ماه ها
        /// </summary>
        /// <returns></returns>
        public static DataTable GetMonthDatesToIssueDocument(int Year, int FleetCode)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery(string.Format(@"Select Distinct  substring(dbo.DateEnToFa(adp.Date),6,2) Date
                                                from AUTDailyPerformanceRportOnBus adp
                                                left join AUTBus ab on adp.BusCode = ab.Code
                                                WHERE adp.Error = 0 and adp.Tcount > 0 and adp.SetPrinter = 1 and adp.CardType=0 And (adp.DocumentCode < 1 OR adp.DocumentCode IS NULL)
                                                AND (substring(dbo.DateEnToFa(adp.Date),0,5)=" + Year + @") 
                                                and ab.FleetCode = " + FleetCode + @" and ab.active = 1
                                                ORDER BY Date "));
                return DB.Query_DataTable();
            }
            catch
            {
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        /// <summary>
        /// انتخاب تاریخ ها جهت صدور سند - تاریخ کامل بر اساس سال و ماه
        /// </summary>
        /// <returns></returns>
        public static DataTable GetFullDatesToIssueDocument(int Year, int Month, int FleetCode)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery(string.Format(@"Select Distinct  CAST(Date AS Date ) Date,SUM(adp.TCount) TCount
                                                from AUTDailyPerformanceRportOnBus adp
                                                left join AUTBus ab on adp.BusCode = ab.Code
                                                WHERE (substring(dbo.DateEnToFa(adp.Date),0,5)=" + Year + @"
                                                AND substring(dbo.DateEnToFa(adp.Date),6,2)=" + Month + @") AND 
                                                (adp.DocumentCode < 1 OR adp.DocumentCode IS NULL) And adp.CardType=0 and adp.Tcount > 0 and adp.SetPrinter = 1 and adp.Error = 0
                                                and ab.FleetCode = " + FleetCode + @" and ab.active = 1
                                                GROUP BY Date
                                                ORDER BY Date  "));
                return DB.Query_DataTable();
            }
            catch
            {
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        /// <summary>
        /// خروجی گزارش بر اساس تاریخ ها
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDriversReportByDate(DateTime[] Dates, int[] FleetCode = null)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {

                string FleetCodeQuery = "";
                if (FleetCode.Length > 0)
                {
                    FleetCodeQuery = " And AUTBus.FleetCode in (";
                    for (int i = 0; i < FleetCode.Length; i++)
                    {
                        FleetCodeQuery += FleetCode[i].ToString() + ",";
                    }
                    FleetCodeQuery = FleetCodeQuery.Remove(FleetCodeQuery.Length - 1, 1);
                    FleetCodeQuery += ")";
                }

                string strDates = "";
                for (int i = 0; i < Dates.Length; i++)
                {
                    strDates += "'" + Dates[i].ToString("yyyy-MM-dd") + "'"; ;
                    if (Dates.Length > 0 && i < Dates.Length - 1)
                        strDates += ", ";
                }
                DB.setQuery(string.Format(@" SELECT   
                        OwnerCode , clsAllPerson .Name OwnerName ,fba.AccountNo , AUTBus.Code BusCode , AUTBus .BUSNumber,AUTBus.LastLineNumber 
                          ,Sum(TCount) 'Count', Sum(cast(Price as float)) * 10.0 as SumPrice
                          FROM   [AUTDailyPerformanceRportOnBus] 
                          Left JOIN clsAllPerson ON clsAllPerson .Code = [AUTDailyPerformanceRportOnBus].OwnerCode 
                          Left JOIN AUTBus  ON AUTBus.Code = [AUTDailyPerformanceRportOnBus].BusCode 
                          LEFT JOIN finBankAccount fba ON fba.PCode = [AUTDailyPerformanceRportOnBus].OwnerCode
                          WHERE AUTBus.Active = 1 and Error = 0 and Tcount > 0 and SetPrinter = 1 and CardType=0 and (DocumentCode < 1 OR DocumentCode IS NULL )
                           AND (Cast ([AUTDailyPerformanceRportOnBus].Date AS Date) IN ({0}))
                           " + FleetCodeQuery + @" 
                          Group By [AUTDailyPerformanceRportOnBus].OwnerCode , clsAllPerson .Name,fba.AccountNo
						  , AUTBus.Code , AUTBus .BUSNumber,AUTBus.LastLineNumber
                          order by OwnerName 
         ", strDates));
                return DB.Query_DataTable();
            }
            catch
            {
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        /// <summary>
        /// بروزرسانی گزارش جهت درج کد اسناد ارسالی به بانک
        /// </summary>
        /// <returns></returns>
        public static int SetReportDocumentCode(JDataBase pDB, DateTime[] Dates, int[] Owners, int DocumentCode, int FleetCode = 0)
        {
            //ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string strOwners = JDataBase.GetInSQLClause(Owners);
                string strDates = "";
                for (int i = 0; i < Dates.Length; i++)
                {
                    strDates += "'" + Dates[i].ToString("yyyy-MM-dd") + "'";
                    if (Dates.Length > 0 && i < Dates.Length - 1)
                        strDates += ", ";
                }
                pDB.setQuery(string.Format(@" UPDATE [AUTDailyPerformanceRportOnBus] SET DocumentCode = {0}
                                    WHERE (DocumentCode < 1 OR DocumentCode is NULL) AND OwnerCode IN {1} 
                                    AND (Cast ([AUTDailyPerformanceRportOnBus].Date AS Date) IN ({2})) And CardType = 0 And SetPrinter = 1 And TCount > 0 And ERROR = 0 ", DocumentCode, strOwners, strDates));
                return pDB.Query_Execute();
            }
            catch
            {
                return -1;
            }
            finally
            {
                // DB.Dispose();
            }
        }

    }


}
