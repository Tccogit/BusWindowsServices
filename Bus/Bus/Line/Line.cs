using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
namespace BusManagment.Line
{
    public class JLine : JSystem
    {
        public int Code { get; set; }
        public string LineName { get; set; }
        public double LineNumber { get; set; }
        public int Fleet { get; set; }
        public int ZoneCode { get; set; }
        public int LineType { get; set; }
        public int NumOfServicePerDay { get; set; }
        public int TimeOfService { get; set; }
        public bool Status { get; set; }
        public bool Rotate { get; set; }
        public float Distance { get; set; }
        public int Color { get; set; }
        public bool IsDrawn { get; set; }
        //ccc
        public int Insert(bool isWeb = false)
        {
            if (!JPermission.CheckPermission("BusManagment.Line.JLine.Insert"))
                return 0;
            LineTable AT = new LineTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            if (Code > 0 && !isWeb)
                Nodes.DataTable.Merge(JLines.GetDataTable(Code));
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JLine", Code, 0, 0, 0, "ثبت خطوط", "", 0);
            return Code;
        }
        public JLine()
        {
        }
        public JLine(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }
        public JLine(string pLineNumber)
        {
            if (pLineNumber.Length > 0)
                this.GetData(pLineNumber);
        }
        public bool Update(bool isWeb = false)
        {
            if (!JPermission.CheckPermission("BusManagment.Line.JLine.Update"))
                return false;
            LineTable AT = new LineTable();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                if (!isWeb)
                    Nodes.Refreshdata(Nodes.CurrentNode, JLines.GetDataTable(Code).Rows[0]);
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                //jHistory.Save("BusManagment.JLine", AT.Code, 0, 0, 0, "ویرایش خطوط", "", 0);
                return true;
            }
            else
                return false;
        }

        public bool Delete(bool isWeb = false)
        {
            if (!JPermission.CheckPermission("BusManagment.Line.JLine.Delete"))
                return false;
            LineTable AT = new LineTable();
            AT.SetValueProperty(this);
            if (AT.Delete())
            {
                if (!isWeb)
                    Nodes.Delete(Nodes.CurrentNode);
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("BusManagment.JLine", AT.Code, 0, 0, 0, "حذف خطوط", "", 0);
                return true;
            }
            else return false;
        }
        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTLine where code=" + pCode.ToString());
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
        public bool GetData(string pLineNumber)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select top 1 * from AUTLine where LineNumber=" + pLineNumber);
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
        public bool HasStation()
        {
            return HasStation(Code);
        }
        public bool HasStation(int pCode)
        {
            JDataBase db = new JDataBase();
            db.setQuery("select Code from autlinestation where LineCode = " + pCode);
            DataTable dt = db.Query_DataTable();
            if (dt != null && dt.Rows.Count > 0)
                return true;
            else return false;
        }
        public bool HasPrice()
        {
            return HasPrice(Code);
        }
        public bool HasPrice(int pCode)
        {
            JDataBase db = new JDataBase();
            db.setQuery("select Code from autPrice where LineCode = " + pCode);
            DataTable dt = db.Query_DataTable();
            if (dt != null && dt.Rows.Count > 0)
                return true;
            else return false;
        }
        public static JNode GetTreeNode()
        {
            JNode Node = new JNode(0, 0);
            Node.Name = "Line";
            Node.MouseClickAction = new JAction("Line", "BusManagment.Line.JLines.ListView");

            return Node;
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "Line.JLine");

            JPopupMenu pMenu = new JPopupMenu("BusManagment.Line.JLines", Node.Code);
            JAction deleteAction = new JAction("delete...", "BusManagment.Line.JLine.Delete", null, new object[] { (int)pRow["Code"] });
            JAction editAction = new JAction("Edit...", "BusManagment.Line.FormLine.ShowDialog", null, new object[] { (int)pRow["Code"] });
            JAction newAction = new JAction("new...", "BusManagment.Line.FormLine.ShowDialog", null, null);

            Node.MouseDBClickAction = editAction;
            pMenu.Insert(deleteAction);
            pMenu.Insert(editAction);
            pMenu.Insert(newAction);

            Node.Popup = pMenu;
            Node.MouseDBClickAction = editAction;
            return Node;

        }
    }

    public class JLines : JSystem
    {

        public void ListView()
        {
            JSystem.Nodes.DataTable = GetDataTable(0);
            JSystem.Nodes.ObjectBase = new JAction("Line", "BusManagment.Line.JLine.GetNode");

            JAction ActInsertAutombile = new JAction("Insert", "BusManagment.Line.FormLine.ShowDialog");

            JToolbarNode InsertAutombile = new JToolbarNode();
            InsertAutombile.Click = ActInsertAutombile;
            InsertAutombile.Icon = JImageIndex.Add;

            JSystem.Nodes.AddToolbar(InsertAutombile);
        }

        public JNode[] TreeView()
        {
            return null;
        }

        public static DataTable GetDataTable(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = @"
                                    SELECT 
	                                    L.[Code]
	                                    ,l.[LineName]
	                                    ,l.[LineNumber]
	                                    ,Z.[Name] AS 'ZoneName'
	                                    ,F.[Name] AS 'FleetName'
	                                    ,D.[name] AS 'LineType'
	                                    ,L.[Status]
	                                    ,l.[Rotate]
                                        ,l.[Distance]
										,(Select Name From AUTStation WHERE Code = (Select  Top 1  StationCode  from AUTLineStation WHERE LineCode = L.Code AND IsBack = 0 Order BY Priority )) Source
										,(Select Name From AUTStation WHERE Code = (Select  Top 1  StationCode  from AUTLineStation WHERE LineCode = L.Code AND IsBack = 0 Order BY Priority Desc )) Destination
                                    FROM AUTLine L
                                    INNER JOIN AUTZone Z ON L.ZoneCode = Z.Code
                                    INNER JOIN AUTFleet F ON L.Fleet = F.Code
                                    INNER JOIN subdefine D ON L.LineType = D.Code
                                "
                + " Where " + JPermission.getObjectSql("BusManagment.Line.JLines.GetDataTable", "L.Code");
                if (pCode > 0)
                    query += " AND  L.Code = " + pCode;
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

        public static DataTable GetWebDataTable(int pCode, int QueryType = 0)
        {

            string PermitionSql = " and " + ClassLibrary.JPermission.getObjectSql("BusManagment.Line.JLines.GetWebDataTable", "Code");
            if (PermitionSql.Length < 5)
            {
                PermitionSql = "";
            }

            JDataBase DB = new JDataBase();
            try
            {
                string query = "";
                if (QueryType == 0)
                    query = @"SELECT [Code],convert(nvarchar,[LineNumber])+' -> '+[LineName] as [lineName],LineNumber,(cast(Code as varchar)+' - '+cast(LineNumber as varchar))LineNumberWithCode FROM AUTLine ";
                else
                    query = @"SELECT [Code],(cast(Code as varchar)+' - '+cast(LineNumber as varchar))LineNumberWithCode FROM AUTLine ";
                if (pCode > 0)
                {
                    query += " WHERE Code = " + pCode + PermitionSql + " Order By LineNumber ASC";
                }
                else
                {
                    query += " WHERE 1 = 1 " + PermitionSql + " Order By LineNumber ASC";
                }
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

        public static DataTable GetSimpletWebDataTable(int pCode)
        {

            string PermitionSql = " and " + ClassLibrary.JPermission.getObjectSql("BusManagment.Line.JLines.GetWebDataTable", "Code");
            if (PermitionSql.Length < 5)
            {
                PermitionSql = "";
            }

            JDataBase DB = new JDataBase();
            try
            {
                string query = @"SELECT [Code],[LineNumber] as [lineName],LineNumber FROM AUTLine ";
                if (pCode > 0)
                {
                    query += " WHERE Code = " + pCode + PermitionSql + " Order By LineNumber ASC";
                }
                else
                {
                    query += " WHERE 1 = 1 " + PermitionSql + " Order By LineNumber ASC";
                }
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

        public static string GetWebQuery()
        {
            return @"SELECT top 100 percent
	                    L.[Code]
	                    ,l.[LineName]
	                    ,l.[LineNumber]
	                    ,Z.[Name] AS 'ZoneName'
	                    ,F.[Name] AS 'FleetName'
	                    ,D.[name] AS 'LineType'
                        ,L.[NumOfServicePerDay]
                        ,L.[TimeOfService]
	                    ,L.[Status] as N'وضعیت - فعال / غیرفعال'
	                    ,l.[Rotate] as N'چرخشی'
                        ,L.[Distance]
                    FROM AUTLine L
                    INNER JOIN AUTZone Z ON L.ZoneCode = Z.Code
                    INNER JOIN AUTFleet F ON L.Fleet = F.Code
                    INNER JOIN subdefine D ON L.LineType = D.Code";
        }


        public static string GetWebReportQuery(int ZoneCode = 0, int LineNumber = 0, int DayType = -1, DateTime? StartEventDate = null, DateTime? EndEventDate = null, int CardType = -1, int FleetCode = 0, bool chInCome = false, Boolean ChkCityPay = false, Boolean ChkCityWay = false, Boolean ChkTabriz = false, string BankType = "1")
        {

            string PermitionSql = " And " + JPermission.getObjectSql("BusManagment.Bus.JBuses.GetWebBusTransactionReportQuery", "adp.BusCode");
            if (PermitionSql.Length < 5)
            {
                PermitionSql = "";
            }

            string PermitionSqlZone = " And " + JPermission.getObjectSql("BusManagment.Zone.JZones.GetDataTable", "az.Code");
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
                FinalCardType = "and adp.CardType in (" + String.Join(",", JDataBase.DataTableToStringtArray(DtCardType, "Type")) + ")";
            }

            string Query = "", WhereStr = "", FleetWhereStr = "", WhereServiceStr = "", WhereStr2 = "", WhereStr3 = "", WhereStr4 = "", WhereStr5 = "", BankWhereStr = "";
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day);
            DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day);
            if (ZoneCode > 0 || LineNumber > 0 || StartEventDate.HasValue == true || CardType > -1 || DayType > -1 || FleetCode > 0)
            {

                WhereStr = " where adp.TCount > 0 and adp.Price > 0 and adp.TicketPrice > 0 and adp.Error = 0 ";

                if (ZoneCode > 0)
                    WhereStr += @" and az.Code=" + ZoneCode;

                if (FleetCode > 0)
                    FleetWhereStr += " and FleetCode = " + FleetCode;

                if (LineNumber > 0)
                    WhereStr += @" and al.Code=" + LineNumber;

                if (StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime)
                {
                    WhereStr += @" and adp.Date between '" + StartDTime.ToShortDateString() + " 00:00:00' and '" + EndDTime.ToShortDateString() + @" 23:59:59'";
                    WhereServiceStr += @" and Date between '" + StartDTime.ToShortDateString() + " 00:00:00' and '" + EndDTime.ToShortDateString() + @" 23:59:59'";
                }

                if (CardType > -1)
                    WhereStr += @" and adp.CardType=" + CardType;

                if (DayType > -1)
                    WhereStr += " and adp.IsHoliDay = " + DayType;

            }
            if (!string.IsNullOrWhiteSpace(BankType))
                BankWhereStr += @" and BankType IN ( " + BankType + ")";
            if (chInCome)
            {

                WhereStr2 += "and adp.Date not in (select Date from AUTHolidays where AUTHolidays.date between '" + StartDTime.ToShortDateString() + " 00:00:00' and '" + EndDTime.ToShortDateString() + @" 23:59:59')";
                WhereStr5 += "and adp.Date  in (select Date from AUTHolidays where AUTHolidays.date between '" + StartDTime.ToShortDateString() + " 00:00:00' and '" + EndDTime.ToShortDateString() + @" 23:59:59')";

                if (LineNumber > 0)
                {
                    WhereStr3 += "and line.Code =" + LineNumber;
                    WhereStr4 += "and lineCode =" + LineNumber;

                }
                Query = @"select ROW_NUMBER()OVER(order by l.LineNumber) Code,*,round((income/busreal),0) AvgInCome
                                    from (
                                            select
                                                 a.LineNumber,case when OrganizationalService = 0 then 0 else cast(cast(DoneServiceCount as float) * OrganizationalBus / OrganizationalService as decimal(6, 2)) end BusReal
												,cast(sum(adp.Tcount)as float)TransactionCount,a.DayKind,sum(cast(Price as float)) * 10.0   InCome,round((sum(cast(Price as float)) * 10.0)/((datediff(day,'" + StartDTime.ToShortDateString() + @"','" + EndDTime.ToShortDateString() + @"')+1)-(select count(*) from AUTHolidays where AUTHolidays.date between '" + StartDTime.ToShortDateString() + @"' and '" + EndDTime.ToShortDateString() + @"')),0)DailyIncome
                                             from(
                                                    select
                                                        service.LineNumber, line.ZoneCode
                                                        ,(select FLOOR(sum(c) * 1.0 / count(*)) from(select Date, count(*)c from(select Distinct buscode, Date from AUTTariff where 1 = 1   " + WhereStr4 + " and AUTTariff.LineCode = line.Code and AUTTariff.Date  between '" + StartDTime.ToShortDateString() + @"' and '" + EndDTime.ToShortDateString() + @"' and AUTTariff.Date not in (select Date from AUTHolidays where AUTHolidays.date between '" + StartDTime.ToShortDateString() + @"' and '" + EndDTime.ToShortDateString() + @"'))a group by Date)a) OrganizationalBus,
	                                                    (select sum(AUTTariff.MinNumOfService) from AUTTariff where 1 = 1   " + WhereStr4 + " and AUTTariff.LineCode = line.Code and AUTTariff.Date between '" + StartDTime.ToShortDateString() + @"' and '" + EndDTime.ToShortDateString() + @"' and AUTTariff.Date not in (select Date from AUTHolidays where AUTHolidays.date between '" + StartDTime.ToShortDateString() + @"' and '" + EndDTime.ToShortDateString() + @"' ) ) OrganizationalService,
	                                                    sum(DoneServiceCount) DoneServiceCount,
								                        N'روز عادی' DayKind
                                                    from
                                                    (select LineNumber, Date, sum(DoneServiceCount) DoneServiceCount from AUTServicingStatus group by LineNumber, Date) service
                                                        left join AUTLine line on line.LineNumber = service.LineNumber
                                                        where 1 = 1   " + WhereStr3 + " and service.Date between '" + StartDTime.ToShortDateString() + @"' and '" + EndDTime.ToShortDateString() + @"' and not exists(select code from AUTHolidays where AUTHolidays.date = service.Date)
                                                        group by service.LineNumber,line.ZoneCode,line.Code
				                                )a
                                                    left join(select * from AUTDailyPerformanceRportOnBus where BusCode in (select Code from AUTBus where 1 = 1 and IsValid = 1 and Active = 1  " + FleetWhereStr + @")) adp on  adp.LineNumber = a.LineNumber
                                                        left join AUTLine al on al.LineNumber = adp.LineNumber
                                                        left join AUTZone az on az.Code = al.ZoneCode
                                                        left join AUTFleet af on af.Code = al.Fleet
                                                        " + WhereStr + FinalCardType + PermitionSql + PermitionSqlZone + WhereStr2 + @"
							                        group by adp.LineNumber,DayKind,a.LineNumber,OrganizationalService,OrganizationalBus,DoneServiceCount


                                                        union all

                                               select
                                                     a.LineNumber,case when OrganizationalService = 0 then 0 else cast(cast(DoneServiceCount as float) * OrganizationalBus / OrganizationalService as decimal(6, 2)) end BusReal
												    ,cast(sum(adp.Tcount)as float)TransactionCount,a.DayKind,sum(cast(Price as float)) * 10.0   InCome,round((sum(cast(Price as float)) * 10.0)/(select count(*) from AUTHolidays where AUTHolidays.date between '" + StartDTime.ToShortDateString() + @"' and '" + EndDTime.ToShortDateString() + @"'),0)DailyIncome
                                              from(
                                                    select
                                                        service.LineNumber
                                                        , line.ZoneCode,
                                                        (select FLOOR(sum(c) * 1.0 / count(*)) from(select Date, count(*)c from(select Distinct buscode, Date from AUTTariff where 1 = 1   " + WhereStr4 + " and AUTTariff.Date in (select Date from AUTHolidays where AUTHolidays.date between '" + StartDTime.ToShortDateString() + @"' and '" + EndDTime.ToShortDateString() + @"'))a group by Date)a) OrganizationalBus,
	                                                    (select sum(AUTTariff.MinNumOfService) from AUTTariff where 1 = 1   " + WhereStr4 + " and AUTTariff.LineCode = line.Code and AUTTariff.Date between '" + StartDTime.ToShortDateString() + @"' and '" + EndDTime.ToShortDateString() + @"' and AUTTariff.Date in (select Date from AUTHolidays where AUTHolidays.date between '" + StartDTime.ToShortDateString() + @"' and '" + EndDTime.ToShortDateString() + @"' ) ) OrganizationalService,
	                                                    sum(DoneServiceCount) DoneServiceCount,
								                        N'روز تعطیل' DayKind
                                                    from
                                                    (select LineNumber, Date, sum(DoneServiceCount) DoneServiceCount from AUTServicingStatus group by LineNumber, Date) service
                                                        left join AUTLine line on line.LineNumber = service.LineNumber
                                                        where 1 = 1   " + WhereStr3 + " and service.Date between '" + StartDTime.ToShortDateString() + @"' and '" + EndDTime.ToShortDateString() + @"' and exists(select code from AUTHolidays where AUTHolidays.date = service.Date)
                                                        group by service.LineNumber,line.ZoneCode,line.Code
				                                )a
                                                    left join(select * from AUTDailyPerformanceRportOnBus where BusCode in (select Code from AUTBus where 1 = 1 and IsValid = 1 and Active = 1  " + FleetWhereStr + @")) adp on  adp.LineNumber = a.LineNumber
                                                        left join AUTLine al on al.LineNumber = adp.LineNumber
                                                        left join AUTZone az on az.Code = al.ZoneCode
                                                        left join AUTFleet af on af.Code = al.Fleet
                                                        " + WhereStr + FinalCardType + PermitionSql + PermitionSqlZone + WhereStr5 + @"
                                                        group by adp.LineNumber,DayKind,a.LineNumber,OrganizationalService,OrganizationalBus,DoneServiceCount
							
							)l
                                where  BusReal<>0.00";
            }
            else if (ChkCityPay || ChkCityWay || ChkTabriz)
            {
                Query = @"select top 100 percent max(adp.Code)Code,af.Name FleetName,az.Name ZoneName,adp.LineNumber,adp.CardType,
                        cast(adp.TicketPrice * 10.0 as float)TicketPrice,cast(sum(adp.Tcount)as float)TransactionCount,sum(cast(adp.Price as float)) * 10.0   InCome ,
                        (
                            select sum(a.NumOfService) from AutBusServices a 
                                where linenumber=adp.LineNumber " + WhereServiceStr + @"
                        
                        ) ServiceCount
                         ,case adp.Banktype when 0 then N'کارت تبریز'  when 1 then N'کارت تبریز' when 2 then N'کارت CityWay' when 3 then N'کارت CityPay' else N'نامشخص' end BankType 
                         ,adp.CityBankResponse
                        from  
                        (select * from AUTDailyPerformanceRportOnBus where BusCode in (select Code from AUTBus where 1 = 1 and IsValid = 1 and Active = 1 " + FleetWhereStr + @")) adp
                        left join AUTLine al on al.LineNumber = adp.LineNumber
                        left join AUTZone az on az.Code = al.ZoneCode
                        left join AUTFleet af on af.Code = al.Fleet
                       " + WhereStr + BankWhereStr + FinalCardType + PermitionSql + PermitionSqlZone + @"
                        group by af.Name,az.Name,adp.LineNumber,adp.CardType,adp.TicketPrice,adp.Banktype,adp.CityBankResponse";
            }
            else
            {
                Query = @"select top 100 percent max(adp.Code)Code,af.Name FleetName,az.Name ZoneName,adp.LineNumber,adp.CardType,
                        cast(adp.TicketPrice * 10.0 as float)TicketPrice,cast(sum(adp.Tcount)as float)TransactionCount,sum(cast(adp.Price as float)) * 10.0   InCome ,
                        (
                            select sum(a.NumOfService) from AutBusServices a 
                                where linenumber=adp.LineNumber " + WhereServiceStr + @"
                        
                        ) ServiceCount
                        from  
                        (select * from AUTDailyPerformanceRportOnBus where BusCode in (select Code from AUTBus where 1 = 1 and IsValid = 1 and Active = 1 " + FleetWhereStr + @")) adp
                        left join AUTLine al on al.LineNumber = adp.LineNumber
                        left join AUTZone az on az.Code = al.ZoneCode
                        left join AUTFleet af on af.Code = al.Fleet
                       " + WhereStr + FinalCardType + PermitionSql + PermitionSqlZone + @"
                        group by af.Name,az.Name,adp.LineNumber,adp.CardType,adp.TicketPrice";
            }
            return Query;
        }

    }
}
