using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace BusManagment.Bus
{
    public class JBus : JSystem
    {


        public int Code { get; set; }
        /// <summary>
        /// Car Code
        /// </summary>
        public int CarCode { get; set; }
        /// <summary>
        /// BUS Number
        /// </summary>
        public double BUSNumber { get; set; }
        public int FleetCode { get; set; } //ناوگان
        public bool Active { get; set; }
        public int IsValid { get; set; }
        //public int ImageCode { get; set; }

        public JBus()
        {
        }
        public JBus(int pCode)
        {
            if (pCode > 0)
                GetData(pCode);
        }
        public JBus(string pBusNumber)
        {
            if (pBusNumber.Length > 0)
                GetData(pBusNumber);
        }
        public int Insert(bool isWeb = false)
        {
            ClassLibrary.JConnection C = new ClassLibrary.JConnection();
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase(C.GetConnection("Server02", 0));
            try
            {
                if (!JPermission.CheckPermission("BusManagment.Bus.JBus.Insert"))
                    return 0;
                JBusTable AT = new JBusTable();
                AT.SetValueProperty(this);
                Code = AT.Insert(db);
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("BusManagment.JBus", Code, 0, 0, 0, "ثبت اتوبوس", "", 0);
                return Code;
            }
            finally
            {
                db.Dispose();
            }
        }




        public bool Delete(bool isWeb = false)
        {

            ClassLibrary.JConnection C = new ClassLibrary.JConnection();
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase(C.GetConnection("Server02", 0));
            try
            {
                if (!JPermission.CheckPermission("BusManagment.Bus.JBus.Delete"))
                    return false;
                JBusTable AT = new JBusTable();
                AT.SetValueProperty(this);
                if (AT.Delete(db))
                {
                    if (!isWeb)
                        Nodes.Delete(Nodes.CurrentNode);
                    ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                    jHistory.Save("BusManagment.JBus", AT.Code, 0, 0, 0, "حذف اتوبوس", "", 0);
                    return true;
                }
                else return false;
            }
            finally
            {
                db.Dispose();
            }
        }
        public bool Update(bool isWeb = false)
        {
            ClassLibrary.JConnection C = new ClassLibrary.JConnection();
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase(C.GetConnection("Server02", 0));
            try
            {
                if (!JPermission.CheckPermission("BusManagment.Bus.JBus.Update"))
                    return false;
                JBusTable AT = new JBusTable();
                AT.SetValueProperty(this);
                if (AT.Update(db))
                {
                    if (!isWeb)
                        Nodes.Refreshdata(Nodes.CurrentNode, JBuses.GetDataTable(Code).Rows[0]);
                    ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                    jHistory.Save("BusManagment.JBus", AT.Code, 0, 0, 0, "ویرایش اتوبوس", "", 0);
                    return true;
                }
                else
                    return true;
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTBus where code=" + pCode.ToString());
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

        public bool GetData(string pBusNumber)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select top 1 * from AUTBus where BUSNumber=" + pBusNumber);
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

        public static JNode GetTreeNode()
        {
            JNode Node = new JNode(0, 0);
            Node.Name = "Bus";
            Node.MouseClickAction = new JAction("Bus", "BusManagment.Bus.JBuses.ListView");

            return Node;
        }
        public void ShowDialog(int pCode)
        {
            JBusForm form = new JBusForm(pCode);
            form.ShowDialog();
        }
        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "BusManagment.Bus.JBuses");
            Node.MouseDBClickAction = new JAction("EditAutomobile", "BusManagment.Bus.JBusForm.ShowDialog", null, new object[] { (int)pRow["Code"] });
            JPopupMenu pMenu = new JPopupMenu("BusManagment.Bus.JBuses", Node.Code);

            JAction deleteAction = new JAction("delete...", "BusManagment.Bus.JBus.Delete", null, new object[] { (int)pRow["Code"] });
            JAction editAction = new JAction("edit...", "BusManagment.Bus.JBus.ShowDialog", new object[] { (int)pRow["Code"] }, null);
            JAction newAction = new JAction("new...", "BusManagment.Bus.JBus.ShowDialog", new object[] { 0 }, null);

            pMenu.Insert(deleteAction);
            pMenu.Insert(editAction);
            pMenu.Insert(newAction);

            Node.Popup = pMenu;
            return Node;

        }

        public void DeleteItem(int pCode, bool RefreshList = true)
        {
            if (JMessages.Question("از حذف این مورد مطمئن هستید؟", "حذف") != System.Windows.Forms.DialogResult.Yes)
                return;

            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Delete From AUTBus Where Code=" + pCode.ToString());
                db.Query_Execute();
                if (RefreshList)
                    JSystem.Nodes.RefreshDataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

    }

    public class JBuses : JSystem
    {
        public void ListView()
        {
            JSystem.Nodes.DataTable = GetDataTable();
            JSystem.Nodes.ObjectBase = new JAction("Bus", "BusManagment.Bus.JBus.GetNode");

            JAction ActInsertAutombile = new JAction("Insert", "BusManagment.Bus.JBusForm.ShowDialog");

            JToolbarNode InsertAutombile = new JToolbarNode();
            InsertAutombile.Click = ActInsertAutombile;
            InsertAutombile.Icon = JImageIndex.Add;

            JSystem.Nodes.AddToolbar(InsertAutombile);
        }

        public JNode[] TreeView()
        {
            return null;
        }

        public static DataTable GetDataTable(int pCode = 0)
        {
            if (!JPermission.CheckPermission("BusManagment.Bus.JBuses.GetDataTable"))
                return null;
            JDataBase DB = new JDataBase();
            try
            {
                string query = @"Select AUTBus.Code 
		,  AUTAutomobile.Plaque	
		, AUTBus.BUSNumber
		, AUTFleet.Name FleetName
		, AUTBus.Active  
		, (Select IMEI FROM AUTDevice WHERE Code = (Select TOP 1 DeviceCode FROM AUTBusDevise WHERE BusCode = AUTBus .Code Order by StartDate Desc )) GSMSerial
		, (Select Tel FROM AUTDevice WHERE Code = (Select TOP 1 DeviceCode FROM AUTBusDevise WHERE BusCode = AUTBus .Code Order by StartDate Desc )) Mobile
		,(Select Fa_Date From StaticDates Where En_date =  (Select TOP 1 StartDate  FROM AUTBusDevise WHERE BusCode = AUTBus .Code Order by StartDate Desc )) StateChangeDate
        ,Properties.*
		from AUTBus 
		inner join AUTFleet  on AUTFleet.Code = AUTBus.FleetCode
		inner join AUTAutomobile  on AUTAutomobile.code = AUTBus.CarCode 
		left join [Propperty_ClassName_BusManagment.JBus_1] Properties ON Properties.ObjectCode = AUTBus.Code WHERE 1 = 1 "
                + " AND " + JPermission.getObjectSql("BusManagment.Bus.JBuses.GetDataTable", "AUTBus.Code");
                if (pCode > 0)
                    query += " AND AUTBus.Code = " + pCode;
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




        public static DataTable GetAllBusesOnly()
        {
            return GetAllBusesOnly(0);
        }

        public static DataTable GetAllBusesOnly(int LineCode = 0)
        {
            string BusQuery = "";
            JDataBase DB = new JDataBase();
            DB.setQuery(@"select ISNULL(IsAdmin,0)IsAdmin from users where Code = " + ClassLibrary.JMainFrame.CurrentUserCode);
            DataTable DtBusCheck = DB.Query_DataTable();
            if (DtBusCheck.Rows[0]["IsAdmin"].ToString() != "True")
            {
                BusQuery = " and len(BusNumber)=4 and BusNumber < 6999 ";
            }

            try
            {
                string WhereLine = "";
                if (LineCode > 0)
                    WhereLine = " and LastLineNumber in (SELECT LineNumber FROM AUTLine Where Code = " + LineCode + ")";
                string query = "";
                string PermitionSql = " And " + JPermission.getObjectSql("BusManagment.Bus.JBuses.GetAllBusesOnly", "Code");
                if (PermitionSql.Length > 5)
                    query = @"Select Code,BusNumber from AUTBus Where Active = 1 and IsValid = 1 " + WhereLine + PermitionSql + BusQuery + " Order By BusNumber ASC";
                else
                    query = @"Select Code,BusNumber from AUTBus Where Active = 1 and IsValid = 1 " + WhereLine + BusQuery + " Order By BusNumber ASC";
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


        public static int GetBusCode(int BusNumber)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = @" Select AUTBus.Code from AUTBus 
                                    Where AUTBus.BUSNumber = '" + BusNumber + "'";
                DB.setQuery(query);
                DataTable dt = DB.Query_DataTable();
                if (dt.Rows.Count > 0)
                    return Convert.ToInt32(dt.Rows[0][0]);
                return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static bool CheckExists(int pCode, int pBusNumber)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = string.Format(@" Select AUTBus.Code from AUTBus WHERE Code <> {0}
                                    AND AUTBus.BUSNumber = '{1}'", pCode, pBusNumber);
                DB.setQuery(query);
                DataTable dt = DB.Query_DataTable();
                return (dt.Rows.Count > 0);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static int GetBusOwnerCode(uint BusNumber)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = @"select AUTBusOwner.Code from AUTBusOwner
                                inner join AUTBus on AUTBus.Code = AUTBusOwner.BusCode
                                where AUTBus.BUSNumber = '" + BusNumber + "'";
                DB.setQuery(query);
                DataTable dt = DB.Query_DataTable();
                if (dt.Rows.Count > 0)
                    return Convert.ToInt32(dt.Rows[0][0]);
                return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static string GetWebQuery()
        {
            string PermitionSql = " And " + JPermission.getObjectSql("BusManagment.Bus.JBuses.GetWebQuery", "AUTBus.Code");
            if (PermitionSql.Length < 5)
            {

                PermitionSql = "";
            }
            return @"Select top 100 percent AUTBus.Code 
		,  AUTAutomobile.Plaque	
		, AUTBus.BUSNumber
		, AUTBus.LastLineNumber LineNumber
		, cap.Name as OwnerName
		, abo.OwnerCount
		,(select value from finComparativeCode where ObjectCode=abo.CodePerson) TafziliCode
		,(select f.AccountNo from finBankAccount f where f.PCode=abo.CodePerson) AccountNo
		, dbo.DateEnToFa(abo.EndDate) EndDateContract
		, AUTFleet.Name FleetName
		, AUTBus.Active 
        , AUTBus.IsValid
		, aht.IMEI GSMSerial
		, (Select ID FROM AUTDevice WHERE Code = (Select TOP 1 DeviceCode FROM AUTBusDevise WHERE DeviceCode in (select Code from AUTDevice where Type = 2) and BusCode = AUTBus .Code Order by StartDate Desc )) Reader1Serial
		, (Select ID FROM AUTDevice WHERE Code = (Select TOP 1 DeviceCode FROM AUTBusDevise WHERE DeviceCode in (select Code from AUTDevice where Type = 2) and BusCode = AUTBus .Code Order by StartDate asc )) Reader2Serial
        , AUTBus.LastDate LastAvlDate
        , AUTBus.TicketLastDate, aht.ConsulVersion
		from AUTBus 
		left join AUTFleet  on AUTFleet.Code = AUTBus.FleetCode
		left join AUTAutomobile  on AUTAutomobile.code = AUTBus.CarCode 
		left join (select *, COUNT(*) over (PARTITION BY BusCode) OwnerCount from AUTBusOwner where IsActive = 1) abo on AUTBus.Code = abo.BusCode
		left join clsAllPerson cap on cap.Code = abo.CodePerson
        left join
        (
            select BusSerial,IMEI, ConsulVersion from
            (
            select BusSerial,IMEI, cast(cast(substring([Version],1,1) AS INT)AS NVARCHAR)+
                                                cast(cast(substring([Version],2,1) AS INT)AS NVARCHAR)+
                                                cast(cast(substring([Version],3,1) AS INT)AS NVARCHAR) ConsulVersion, ROW_NUMBER() over (partition by BusSerial order by date desc) row_numb from AUTHeaderTransaction
            ) aht where row_numb = 1
        ) aht on aht.BusSerial = AUTBus.BUSNumber
        where 1=1 " + PermitionSql;
        }


        public static string GetWebBusTransactionReportQuery(int ZoneCode = 0, int LineNumber = 0, int PersonelCode = 0, int BUSNumber = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null, TimeSpan? StartTime = null, TimeSpan? EndTime = null, int CardType = -1, int DayType = -1, int FleetCode = 0, Int64 PassengerCard = 0, string BankType = "1")
        {
            string PermitionSql = " And " + JPermission.getObjectSql("BusManagment.Bus.JBuses.GetWebBusTransactionReportQuery", "dbo.AUTTicketTransaction.BusCode");
            if (PermitionSql.Length < 5)
            {
                PermitionSql = "";
            }
            string PermitionSqlZone = " And " + JPermission.getObjectSql("BusManagment.Zone.JZones.GetDataTable", "AUTTicketTransaction.ZoneCode");
            if (PermitionSqlZone.Length < 5)
            {
                PermitionSqlZone = "";
            }

            string CardTypePermitionSql = JPermission.getObjectSql("BusManagment.Card.JCards.GetDataTable", "Code");
            string FinalCardType = "";
            if (CardTypePermitionSql == " 1 = 1 ")
            {
                CardTypePermitionSql = "";
            }
            else
            {
                JDataBase mydb = new JDataBase();
                try
                {
                    mydb.setQuery("Select Type From AutCardType Where " + CardTypePermitionSql);
                    DataTable DtCardType = mydb.Query_DataTable();
                    FinalCardType = "and dbo.AUTTicketTransaction.CardType in (" + String.Join(",", JDataBase.DataTableToStringtArray(DtCardType, "Type")) + ")";
                }
                finally
                {
                    mydb.Dispose();
                }
            }

            string Query = "", WhereStr = @" where 1=1 and dbo.AUTTicketTransaction.TicketPrice > 0 
                                                        and len(dbo.AUTTicketTransaction.busnumber)>=4";
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            if (ZoneCode > 0 || LineNumber > 0 || PersonelCode > 0 || BUSNumber > 0 || StartEventDate.HasValue == true || StartTime.HasValue == true || CardType > -1 || DayType > -1 || FleetCode > 0)
            {


                if (ZoneCode > 0)
                    WhereStr += @" and AUTTicketTransaction.ZoneCode = " + ZoneCode;

                if (FleetCode > 0)
                    WhereStr += " and AutLine.Fleet = " + FleetCode;

                if (LineNumber > 0)
                    WhereStr += @" and AutLine.Code = " + LineNumber;

                if (PersonelCode > 0)
                    WhereStr += @" and dbo.AUTTicketTransaction.DriverPersonCode=" + PersonelCode;

                if (BUSNumber > 0)
                    WhereStr += @" and dbo.AUTTicketTransaction.BusCode=" + BUSNumber;

                if ((StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime) && !StartTime.HasValue)
                    WhereStr += @" and convert(date,dbo.AUTTicketTransaction.EventDate) between '" + StartEventDate.Value.Date.ToShortDateString() + " 00:00:00' and '" + EndEventDate.Value.Date.ToShortDateString() + " 23:59:59'";

                if ((StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime) && StartTime.HasValue)
                {
                    DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day, StartTime.Value.Hours, StartTime.Value.Minutes, StartTime.Value.Seconds);
                    DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day, EndTime.Value.Hours, EndTime.Value.Minutes, EndTime.Value.Seconds);
                    WhereStr += @" and dbo.AUTTicketTransaction.EventDate between '" + StartDTime.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + EndDTime.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                }

                if (DayType > -1)
                {
                    if (DayType == 0)
                        WhereStr += " and cast(dbo.AUTTicketTransaction.EventDate as date) not in (select Date from AutHolidays)";
                    if (DayType == 1)
                        WhereStr += " and cast(dbo.AUTTicketTransaction.EventDate as date) in (select Date from AutHolidays)";
                }

                if (CardType > -1)
                    WhereStr += @" and AUTTicketTransaction.CardType = " + CardType;


            }
            if (!string.IsNullOrWhiteSpace(BankType))
                WhereStr += @" and AUTTicketTransaction.BankType IN ( " + BankType + ")";


            if (PassengerCard > 0)
                WhereStr += @" and AUTTicketTransaction.PassengerCardSerial = " + PassengerCard;

            Query = @"SELECT top 100 percent
                        max(dbo.AUTTicketTransaction.Code) Code,
						max(dbo.AUTTicketTransaction.TransactionId)TransactionId,
						dbo.AUTTicketTransaction.FleetName,
                        dbo.AUTTicketTransaction.LineNumber, dbo.AUTTicketTransaction.BUSNumber,
                        dbo.AUTTicketTransaction.DriverPersonName as DriverName,
                        case when dbo.AUTTicketTransaction.PassengerCardSerial2 = 0 then dbo.AUTTicketTransaction.PassengerCardSerial else Cast(dbo.AUTTicketTransaction.PassengerCardSerial as decimal(20,0))+POWER(CAST(2 as decimal(20,0)),63)-1 end PassengerCardSerial,
                        dbo.AUTTicketTransaction.CardType,
                        case dbo.AUTTicketTransaction.Banktype when 0 then N'کارت تبریز'  when 1 then N'کارت تبریز2' when 2 then N'کارت CityWay' when 3 then N'کارت CityPay' else N'نامشخص' end BankType ,
                        dbo.AUTTicketTransaction.TicketPrice * 10 as TicketPrice,
                        dbo.AUTTicketTransaction.RemainPrice * 10 RemainPrice, 
                        dbo.AUTTicketTransaction.EventDate,
                        min(dbo.AUTTicketTransaction.RecievedDate) RecievedDate 
                       
                        FROM dbo.AUTTicketTransaction Left Join AutLine on AUTTicketTransaction.LineNumber = AutLine.LineNumber"
                + WhereStr
                + PermitionSql
                + PermitionSqlZone
                + @"
    				group by EventDate, BusNumber,Banktype,DriverCardSerial,AUTTicketTransaction.PassengerCardSerial2 ,AUTTicketTransaction.LineNumber,FleetCode,BusCode,PassengerCardSerial,CardType,TicketPrice,RemainPrice,ReaderId,FleetName,DriverPersonName";

            return Query;
        }

        public static string GetWebBusPerPerformanceReportQueryWithMuliBus(int ZoneCode = 0, int LineNumber = 0, int[] BusNumebr = null, DateTime? StartEventDate = null, DateTime? EndEventDate = null, int OwnerCode = 0, int CardType = -1)
        {
            string PermitionSql = " And " + JPermission.getObjectSql("BusManagment.Bus.JBuses.GetWebQuery", "DP.BusCode");
            if (PermitionSql.Length < 5)
            {
                PermitionSql = "";
            }

            string CardTypePermitionSql = JPermission.getObjectSql("BusManagment.Card.JCards.GetDataTable", "Code");
            string FinalCardType = "";
            if (CardTypePermitionSql == " 1 = 1 ")
            {
                CardTypePermitionSql = "";
            }
            else
            {
                JDataBase mydb = new JDataBase();
                mydb.setQuery("Select Type From AutCardType Where " + CardTypePermitionSql);
                DataTable DtCardType = mydb.Query_DataTable();
                FinalCardType = "and DP.CardType in (" + String.Join(",", JDataBase.DataTableToStringtArray(DtCardType, "Type")) + ")";
                mydb.Dispose();
            }

            string Query = "", WhereStr = " where 1=1 ";
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            if (StartEventDate.HasValue == true || BusNumebr.Length > 0 || ZoneCode > 0 || LineNumber > 0 || OwnerCode > 0 || CardType > -1)
            {
                if (BusNumebr.Length > 0)
                {
                    WhereStr += @" and DP.BusCode in (";
                    for (int i = 0; i < BusNumebr.Length; i++)
                    {
                        WhereStr += @"" + BusNumebr[i].ToString() + @",";
                    }
                    WhereStr = WhereStr.Remove(WhereStr.Length - 1, 1);
                    WhereStr += ") ";
                }

                if (ZoneCode > 0)
                    WhereStr += " and AZ.Code = " + ZoneCode;

                if (LineNumber > 0)
                    WhereStr += " and AL.Code = " + LineNumber;

                if (OwnerCode > 0)
                    WhereStr += " and DP.OwnerCode = " + OwnerCode;

                if (CardType > -1)
                    WhereStr += " and DP.CardType = " + CardType;


                if (StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime)
                {
                    DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day);
                    DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day);
                    WhereStr += @" and DP.[Date] between '" + StartDTime.ToShortDateString() + "' and '" + EndDTime.ToShortDateString() + "'";
                }



            }


            Query = @"select top 100 percent max(DP.Code) as Code,AF.Name as FleetName,AZ.Name as ZoneName,
                            DP.LineNumber,AB.BUSNumber,DP.CardType,sum(DP.TCount) as TransactionCount,sum(DP.Price) * 10 as InCome,
                            (N''+cast(AB.BUSNumber as varchar)+N' - کارت نوع '+cast(DP.CardType as varchar)) as ColumnName
                            from [dbo].[AUTDailyPerformanceRportOnBus] DP
                            left join [dbo].[AUTBus] AB on DP.BusCode = AB.Code
                            left join [dbo].[AUTLine] AL on DP.LineNumber = AL.LineNumber
                            left join [dbo].[AUTZone] AZ on AL.ZoneCode = AZ.Code
                            left join [dbo].[AUTFleet] AF on AL.Fleet = AF.Code  
                            " + WhereStr + PermitionSql + FinalCardType + @"
							group by AB.BUSNumber,AF.Name,AZ.Name,DP.LineNumber,DP.CardType ";


            return Query;
        }


        public static string GetWebBusPerformanceReportQueryAccounting(int ZoneCode = 0, int LineNumber = 0, int BusNumebr = 0, int DayType = -1, DateTime? StartEventDate = null, DateTime? EndEventDate = null, int OwnerCode = 0, bool CalcService = false, int TransactionType = 0, int CardType = -1, int FleetCode = 0)
        {
            string PermitionSql = " And " + JPermission.getObjectSql("BusManagment.Bus.JBuses.GetWebBusPerformanceReportQuery", "DP.BusCode");
            if (PermitionSql.Length < 5)
            {
                PermitionSql = "";
            }

            string PermitionSqlZone = " And " + JPermission.getObjectSql("BusManagment.Zone.JZones.GetDataTable", "AZ.Code");
            if (PermitionSqlZone.Length < 5)
            {
                PermitionSqlZone = "";
            }

            string CardTypePermitionSql = JPermission.getObjectSql("BusManagment.Card.JCards.GetDataTable", "Code");
            string FinalCardType = "";
            if (CardTypePermitionSql == " 1 = 1 ")
            {
                CardTypePermitionSql = "";
            }
            else
            {
                JDataBase mydb = new JDataBase();
                mydb.setQuery("Select Type From AutCardType Where " + CardTypePermitionSql);
                DataTable DtCardType = mydb.Query_DataTable();
                FinalCardType = "and DP.CardType in (" + String.Join(",", JDataBase.DataTableToStringtArray(DtCardType, "Type")) + ")";
                mydb.Dispose();
            }

            DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day);
            DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day);
            string Query = "", WhereStr = " where DP.TCount > 0 and DP.Error = 0 and DP.TicketPrice > 0 and DP.Price > 0 and ab.Active = 1 and ab.IsValid = 1 ";
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            if (ZoneCode > 0 || LineNumber > 0 || BusNumebr > 0 || DayType > -1 || StartEventDate.HasValue == true || OwnerCode > 0 || CalcService == true || TransactionType > 0 || CardType > -1 || FleetCode > 0)
            {
                if (ZoneCode > 0)
                    WhereStr += @" and AZ.Code=" + ZoneCode;

                if (LineNumber > 0)
                    WhereStr += @" and AL.Code=" + LineNumber;

                if (FleetCode > 0)
                    WhereStr += " and AB.FleetCode = " + FleetCode;

                if (OwnerCode > 0)
                {
                    WhereStr += @" and DP.OwnerCode = " + OwnerCode;
                }
                else
                {
                    if (BusNumebr > 0)
                        WhereStr += @" and DP.BusCode=" + BusNumebr;
                }

                if (DayType > -1)
                    WhereStr += " and DP.IsHoliday = " + DayType;


                if (StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime)
                {

                    WhereStr += @" and DP.[Date] between '" + StartDTime.ToShortDateString() + " 00:00:00' and '" + EndDTime.ToShortDateString() + " 23:59:59'";
                }

                //if(CalcService==true)

                //if (TransactionType > 0)
                //{
                //    if (TransactionType == 1)
                //        WhereStr += @" and DP.DocumentCode = 0";
                //    if (TransactionType == 2)
                //        WhereStr += @" and DP.DocumentCode > 0";
                //}

                if (CardType > -1)
                    WhereStr += @" and DP.CardType=" + CardType;

            }



            //            Query = @"select top 100 percent max(DP.Code) AS Code,AF.Name as FleetName,AZ.Name as ZoneName,
            //                            DP.LineNumber,AB.BUSNumber,CAP.Name,DP.CardType,DP.TicketPrice * 10 as TicketPrice,sum(DP.TCount) as TransactionCount,sum(DP.Price) * 10 as InCome
            //                            from [dbo].[AUTDailyPerformanceRportOnBus] DP
            //                            left join [dbo].[AUTBus] AB on DP.BusCode = AB.Code
            //                            left join [dbo].[AUTLine] AL on DP.LineNumber = AL.LineNumber
            //                            left join [dbo].[AUTZone] AZ on AL.ZoneCode = AZ.Code
            //                            left join [dbo].[AUTFleet] AF on AB.FleetCode = AF.Code   
            //							left join [dbo].[clsAllPerson] CAP on DP.OwnerCode = CAP.Code
            //                            " + WhereStr + PermitionSql + FinalCardType + PermitionSqlZone + @"
            //							GROUP BY dp.CardType,AF.Name,AZ.Name,DP.LineNumber,AB.BUSNumber,CAP.Name,DP.TicketPrice,DP.BusCode,DP.OwnerCode";

            Query = @"select top 100 percent max(DP.Code) AS Code,Dp.Date,AF.Name as FleetName,AZ.Name as ZoneName,
                            DP.LineNumber,AB.BUSNumber,CAP.Name,DP.CardType,
							sum(DP.TCount) as TransactionCount,sum(DP.Price) * 10 as InCome
                            ,max(DP.DocumentCode) * 10 PaymentIncome
							,(sum(DP.Price) - max(DP.DocumentCode)) * 10 Mandeh
                            from [dbo].[AUTDailyPerformanceRportOnBus] DP
                            left join [dbo].[AUTBus] AB on DP.BusCode = AB.Code
                            left join [dbo].[AUTLine] AL on DP.LineNumber = AL.LineNumber
                            left join [dbo].[AUTZone] AZ on AL.ZoneCode = AZ.Code
                            left join [dbo].[AUTFleet] AF on AB.FleetCode = AF.Code   
							left join [dbo].[clsAllPerson] CAP on DP.OwnerCode = CAP.Code
                            " + WhereStr + PermitionSql + FinalCardType + PermitionSqlZone + @"
							GROUP BY Dp.Date,dp.CardType,AF.Name,AZ.Name,DP.LineNumber,AB.BUSNumber,CAP.Name,DP.BusCode,DP.OwnerCode";


            return Query;
        }


        public static string GetWebBusPerformanceReportQuery(int ZoneCode = 0, int LineNumber = 0, int BusCode = 0, int DayType = -1, DateTime? StartEventDate = null, DateTime? EndEventDate = null, int OwnerCode = 0, bool CalcService = false, int TransactionType = 0, int CardType = -1, int FleetCode = 0,
            int MinTransaction = 0, int MaxTransaction = 0, Boolean ChkCityPay = false, Boolean ChkCityWay = false, Boolean ChkTabriz = false, string BankType = "1")
        {
            string PermitionSql = " And " + JPermission.getObjectSql("BusManagment.Bus.JBuses.GetWebBusPerformanceReportQuery", "DP.BusCodeBus");
            if (PermitionSql.Length < 5)
            {
                PermitionSql = "";
            }

            string PermitionSqlZone = " And " + JPermission.getObjectSql("BusManagment.Zone.JZones.GetDataTable", "AZ.Code");
            if (PermitionSqlZone.Length < 5)
            {
                PermitionSqlZone = "";
            }

            string CardTypePermitionSql = JPermission.getObjectSql("BusManagment.Card.JCards.GetDataTable", "Code");
            string FinalCardType = "";
            if (CardTypePermitionSql == " 1 = 1 ")
            {
                CardTypePermitionSql = "";
            }
            else
            {
                JDataBase mydb = new JDataBase();
                mydb.setQuery("Select Type From AutCardType Where " + CardTypePermitionSql);
                DataTable DtCardType = mydb.Query_DataTable();
                FinalCardType = "and DP.CardType in (" + String.Join(",", JDataBase.DataTableToStringtArray(DtCardType, "Type")) + ")";
                mydb.Dispose();
            }

            DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day);
            DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day);
            string Query = "", WhereServiceStr = "", BankWhereStr = "", ShiftWhereStr = " where Error = 0 and TCount > 0 ", WhereStr = " where ab.Active = 1 and ab.IsValid = 1 ";
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            if (ZoneCode > 0 || LineNumber > 0 || BusCode > 0 || DayType > -1 || StartEventDate.HasValue == true || OwnerCode > 0 || CalcService == true || TransactionType > 0 || CardType > -1 || FleetCode > 0)
            {
                if (ZoneCode > 0)
                    WhereStr += @" and AZ.Code=" + ZoneCode;

                if (LineNumber > 0)
                    WhereStr += @" and AL.Code=" + LineNumber;

                if (FleetCode > 0)
                    WhereStr += " and AB.FleetCode = " + FleetCode;

                if (OwnerCode > 0)
                {
                    ShiftWhereStr += @" and OwnerPCode = " + OwnerCode;
                }
                else
                {
                    if (BusCode > 0)
                        ShiftWhereStr += @" and BusCodeBus =" + BusCode;
                }

                if (DayType > -1)
                    ShiftWhereStr += " and IsHoliday = " + DayType;


                if (StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime)
                {

                    ShiftWhereStr += @" and [Date] between '" + StartDTime.ToShortDateString() + " 00:00:00' and '" + EndDTime.ToShortDateString() + " 23:59:59'";
                    WhereServiceStr += @" and [Date] between '" + StartDTime.ToShortDateString() + " 00:00:00' and '" + EndDTime.ToShortDateString() + " 23:59:59'";
                }

                //if(CalcService==true)

                if (TransactionType > 0)
                {
                    if (TransactionType == 1)
                        ShiftWhereStr += @" and DocumentCode = 0";
                    if (TransactionType == 2)
                        ShiftWhereStr += @" and DocumentCode > 0";
                }


                if (CardType > -1)
                    ShiftWhereStr += @" and CardType=" + CardType;

            }
            String WhereMinMaxStr = "";
            if (MinTransaction > 0)
            {
                WhereMinMaxStr += " and TransactionCount/WorkDay > " + MinTransaction;
            }

            if (MaxTransaction > 0)
            {
                WhereMinMaxStr += " and TransactionCount/WorkDay < " + MaxTransaction;
            }

            if (!string.IsNullOrWhiteSpace(BankType))
                BankWhereStr += @" and BankType IN ( " + BankType + ")";
            if (ChkCityPay || ChkCityWay || ChkTabriz)
            {
                Query = @"select * into #tmpShift from [dbo].AUTShiftDriver " + ShiftWhereStr + BankWhereStr + @"
                        <#PreviusSQL#>
                        select *,CASE WHEN WorkDay=0 THEN 0 ELSE  TransactionCount/WorkDay END AvgWork 
                        from
                        (select top 100 percent max(DP.Code) AS Code
                            ,AF.Name as FleetName
                            ,AZ.Name as ZoneName
                            ,DP.LineNumber
                            ,AB.BUSNumber
                            ,CAP.Name
                            ,DP.CardType
                            ,DP.TicketPrice * 10 as TicketPrice
                            ,sum(DP.TCount) as TransactionCount
                            ,sum(cast(DP.TCount * DP.TicketPrice as BIGINT)) * 10 as InCome
                            ,case DP.Banktype when 0 then N'کارت تبریز'  when 1 then N'کارت تبریز' when 2 then N'کارت CityWay' when 3 then N'کارت CityPay' else N'نامشخص' end BankType 
                            ,DP.CityBankResponse
                            ,(
                                select sum(a.NumOfService) from AutBusServices a 
                                    where BusNumber=AB.BUSNumber and lineNumber=DP.LineNumber " + WhereServiceStr + @"
                        
                             ) ServiceCount
                             ,(
									select count(*) from
									( 
										select Date from #tmpShift AP1 
										where 1=1
										and ap1.BusNumber = ab.BusNumber
										and ap1.TicketPrice=dp.TicketPrice
										and ap1.LineNumber=dp.LineNumber
										and ap1.CardType=dp.CardType
										" + WhereServiceStr + @"
										group by Date
									)a
								) WorkDay
                            ,ALT.TransactionCount MinTransactionCount

                            from #tmpShift DP
                            left join [dbo].[AUTBus] AB on DP.BusCodeBus = AB.Code
                            left join [dbo].[AUTLine] AL on DP.LineNumber = AL.LineNumber
                            left join [dbo].[AUTZone] AZ on AL.ZoneCode = AZ.Code
                            left join [dbo].[AUTFleet] AF on AB.FleetCode = AF.Code   
							left join [dbo].[clsAllPerson] CAP on DP.OwnerPCode = CAP.Code
                            left join [dbo].[AUTDailyLineTransactionCount] ALT on ALT.LineCode=AL.Code

                            " + WhereStr + PermitionSql + FinalCardType + PermitionSqlZone + @"
							GROUP BY dp.CardType,AF.Name,AZ.Name,DP.LineNumber,AB.BUSNumber,CAP.Name,DP.TicketPrice,DP.BusCodeBus,DP.OwnerPCode,ALT.TransactionCount,DP.Banktype,DP.CityBankResponse
) as a
where 1=1 " + WhereMinMaxStr;
            }
            else
            {
                Query = @"select * into #tmpShift from [dbo].AUTShiftDriver " + ShiftWhereStr + @"
                        <#PreviusSQL#>
                        select *,CASE WHEN WorkDay=0 THEN 0 ELSE  TransactionCount/WorkDay END AvgWork 
                        from
                        (select top 100 percent max(DP.Code) AS Code,AF.Name as FleetName,AZ.Name as ZoneName,
                            DP.LineNumber,AB.BUSNumber,CAP.Name,DP.CardType,DP.TicketPrice * 10 as TicketPrice,sum(DP.TCount) as TransactionCount,sum(cast(DP.TCount * DP.TicketPrice as BIGINT)) * 10 as InCome,
                            (
                                select sum(a.NumOfService) from AutBusServices a 
                                    where BusNumber=AB.BUSNumber and lineNumber=DP.LineNumber " + WhereServiceStr + @"
                        
                            ) ServiceCount,
								(
									select count(*) from
									( 
										select Date from #tmpShift AP1 
										where 1=1
										and ap1.BusNumber = ab.BusNumber
										and ap1.TicketPrice=dp.TicketPrice
										and ap1.LineNumber=dp.LineNumber
										and ap1.CardType=dp.CardType
										" + WhereServiceStr + @"
										group by Date
									)a
								) WorkDay
                            ,ALT.TransactionCount MinTransactionCount

                            from #tmpShift DP
                            left join [dbo].[AUTBus] AB on DP.BusCodeBus = AB.Code
                            left join [dbo].[AUTLine] AL on DP.LineNumber = AL.LineNumber
                            left join [dbo].[AUTZone] AZ on AL.ZoneCode = AZ.Code
                            left join [dbo].[AUTFleet] AF on AB.FleetCode = AF.Code   
							left join [dbo].[clsAllPerson] CAP on DP.OwnerPCode = CAP.Code
                            left join [dbo].[AUTDailyLineTransactionCount] ALT on ALT.LineCode=AL.Code

                            " + WhereStr + PermitionSql + FinalCardType + PermitionSqlZone + @"
							GROUP BY dp.CardType,AF.Name,AZ.Name,DP.LineNumber,AB.BUSNumber,CAP.Name,DP.TicketPrice,DP.BusCodeBus,DP.OwnerPCode,ALT.TransactionCount
) as a
where 1=1 " + WhereMinMaxStr;
            }
            return Query;
        }
        //        public static string GetCompareBusPerformanceReportQuery( int LineNumber = 0, int BusCode = 0, int toYear = 0, int toMount = 0, int fromYear = 0, int fromMount = 0)
        //        {
        //            string PermitionSql = " And " + JPermission.getObjectSql("BusManagment.Bus.JBuses.GetCompareBusPerformanceReportQuery", "DP.BusCodeBus");
        //            if (PermitionSql.Length < 5)
        //            {
        //                PermitionSql = "";
        //            }


        //            string Query = "", WhereServiceStr = "", ShiftWhereStr = " where Error = 0 and TCount > 0 ", WhereStr = " where ab.Active = 1 and ab.IsValid = 1 ";
        //            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
        //            if ( LineNumber > 0 || BusCode > 0 || toYear>0 || toMount>0)
        //            {

        //                if (LineNumber > 0)
        //                    WhereStr += @" and AL.Code=" + LineNumber;
        //                else
        //                {
        //                    if (BusCode > 0)
        //                        ShiftWhereStr += @" and BusCodeBus =" + BusCode;
        //                }


        //                if (StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime)
        //                {

        //                    ShiftWhereStr += @" and [Date] between '" + StartDTime.ToString("yyyy/MM/dd") + " 00:00:00' and '" + EndDTime.ToString("yyyy/MM/dd") + " 23:59:59'";
        //                    WhereServiceStr += @" and [Date] between '" + StartDTime.ToString("yyyy/MM/dd") + " 00:00:00' and '" + EndDTime.ToString("yyyy/MM/dd") + " 23:59:59'";
        //                }





        //            Query = @"
        //                        IF OBJECT_ID('tempdb..#tmpShift') IS NOT NULL DROP Table #tmpShift
        //                        select * into #tmpShift from [dbo].AUTShiftDriver a " + ShiftWhereStr + @"
        //                        <#PreviusSQL#>
        //                        select *,CASE WHEN WorkDay=0 THEN 0 ELSE  TransactionCount/WorkDay END AvgWork
        //                                ,CASE WHEN WorkDay=0 THEN 0 ELSE(MinTransactionCount*WorkDay)/WorkDay END AllMinAvgWork 
        //                                ,CASE WHEN ServiceCount=0 THEN 0 ELSE  TransactionCount/ServiceCount END AvgService 
        //                                ,MinTransactionCount*WorkDay AllMinTransactionCount 
        //                                ,CASE WHEN ServiceCount=0 THEN 0 ELSE (MinTransactionCount*WorkDay)/ServiceCount END AllMinAvgService 
        //                        from
        //                        (select top 100 percent max(DP.Code) AS Code,AF.Name as FleetName,AZ.Name as ZoneName,
        //                            DP.LineNumber,AB.BUSNumber,CAP.Name,DP.CardType,DP.TicketPrice * 10 as TicketPrice,sum(DP.TCount) as TransactionCount,sum(cast(DP.TCount * DP.TicketPrice as BIGINT)) * 10 as InCome,
        //                            isnull  (
        //                                        (
        //                                            select sum(a.DoneServiceCount) from AUTServicingStatus a 
        //                                            where BusNumber=AB.BUSNumber and lineNumber=DP.LineNumber " + WhereServiceStr + @"

        //                                        ),0
        //                                    ) ServiceCount,
        //								(
        //									select count(*) from
        //									( 
        //										select Date from #tmpShift AP1 
        //										where 1=1
        //										and ap1.BusNumber = ab.BusNumber
        //										and ap1.TicketPrice=dp.TicketPrice
        //										and ap1.LineNumber=dp.LineNumber
        //										and ap1.CardType=dp.CardType
        //										" + WhereServiceStr + @"
        //										group by Date
        //									)a
        //								) WorkDay
        //                            ,ALT.TransactionCount MinTransactionCount

        //                            from #tmpShift DP
        //                            left join [dbo].[AUTBus] AB on DP.BusCodeBus = AB.Code
        //                            left join [dbo].[AUTLine] AL on DP.LineNumber = AL.LineNumber
        //                            left join [dbo].[AUTZone] AZ on AL.ZoneCode = AZ.Code
        //                            left join [dbo].[AUTFleet] AF on AB.FleetCode = AF.Code   
        //							left join [dbo].[clsAllPerson] CAP on DP.OwnerPCode = CAP.Code
        //                            left join [dbo].[AUTDailyLineTransactionCount] ALT on ALT.LineCode=AL.Code
        //                            " + WhereStr + PermitionSql + FinalCardType + PermitionSqlZone + @"
        //							GROUP BY dp.CardType,AF.Name,AZ.Name,DP.LineNumber,AB.BUSNumber,CAP.Name,DP.TicketPrice,DP.BusCodeBus,DP.OwnerPCode,ALT.TransactionCount
        //) as a
        //where 1=1 " + WhereMinMaxStr;

        //            return Query;
        //        }

        public static string GetMulFunctionOfBusQuery()
        {
            return @"select ab.Code,ab.BusNumber,af.Name as FleetName,ab.LastLineNumber as LineNumber,
                        ab.LastDate as AvlLastDate,ab.TicketLastDate,ab.LastSimCardCharge from AutBus ab
                        left join AutFleet af on ab.FleetCode = af.Code
                        where LEN(ab.BusNumber)=4 and ab.BusNumber < 7999";
        }

        public static string GetFinanceForTelegramRobot(DateTime pDate, int pOwnerCode)
        {
            string Return = "";
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(
                    @"select Description,TotalPrice from AutPaymentDetail APD
                        inner join  AutPayment AP ON AP.Code = APD.PaymentCode
                        where 
                        OwnerPCode in
						(
							select distinct abo.CodePerson from permissionUser pu
							inner join PermissionDecision pd on pu.DecisionCode = pd.Code
							inner join PermissionDefineClass PDF ON PDF.Code=pd.PermissionDefineCode
							inner join autbus a on a.code=pu.ObjectCode
							inner join AutBusOwner abo on abo.BusCode = a.Code
							where User_Post_Code = (select Code 
							from organizationchart where user_code = (select Code from users where pcode=" + pOwnerCode + @"))
							and pd.code=1000433 
							and '" + pDate.ToString("yyyy-MM-dd") + @"' between abo.startdate and isnull(abo.enddate,'" + pDate.ToString("yyyy-MM-dd") + @"')
						) and                        
                        AP.PaymentDate = '" + pDate.ToString("yyyy-MM-dd") + @"'
                        "
                );
                DataTable DT = DB.Query_DataTable();
                foreach (DataRow DR in DT.Rows)
                {
                    Return += DR["Description"].ToString()
                        + " مبلغ " + DR["TotalPrice"].ToString() + " ریال"
                        + Environment.NewLine;
                }
            }
            finally
            {
                DB.Dispose();
            }
            return Return;
        }

        public static string GetWorkForTelegramRobot(DateTime pDate, int pOwnerCode)
        {
            string Return = "";
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(
                    @"
                    select BusNumber,Sum(TCount) TranCount,SUM(TCount*TicketPrice) TranPrice from autshiftDriver 
                      where 
                        OwnerPCode in
						(
							select distinct abo.CodePerson from permissionUser pu
							inner join PermissionDecision pd on pu.DecisionCode = pd.Code
							inner join PermissionDefineClass PDF ON PDF.Code=pd.PermissionDefineCode
							inner join autbus a on a.code=pu.ObjectCode
							inner join AutBusOwner abo on abo.BusCode = a.Code
							where User_Post_Code = (select Code 
							from organizationchart where user_code = (select Code from users where pcode=" + pOwnerCode + @"))
							and pd.code=1000433 
							and '" + pDate.ToString("yyyy-MM-dd") + @"' between abo.startdate and isnull(abo.enddate,'" + pDate.ToString("yyyy-MM-dd") + @"')
						) and
                        Date = '" + pDate.ToString("yyyy-MM-dd") + @"'
                        Group By BusNumber
						"
                );
                DataTable DT = DB.Query_DataTable();
                foreach (DataRow DR in DT.Rows)
                {
                    Return += "اتوبوس " + DR["BusNumber"].ToString()
                        + " کارکرد " + DR["TranCount"].ToString()
                        + " تراکنش به مبلغ " + DR["TranPrice"].ToString();
                }
            }
            finally
            {
                DB.Dispose();
            }
            return Return;
        }




    }
}
