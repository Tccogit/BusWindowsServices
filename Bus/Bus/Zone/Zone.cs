using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace BusManagment.Zone
{
    public class JZone : JSystem
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Tel { get; set; }
        public int ChiefPersonCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        public JZone()
        {
        }
        public JZone(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }

        public int Insert(bool isWeb = false)
        {
            if (!JPermission.CheckPermission("BusManagment.Zone.JZone.Insert"))
                return 0;
            ZoneTable AT = new ZoneTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            if (Code > 0 && !isWeb)
                Nodes.DataTable.Merge(JZones.GetDataTable(Code));
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JZone", Code, 0, 0, 0, "ثبت مناطق", "", 0);
            return Code;
        }

        public bool Update(bool isWeb = false)
        {
            if (!JPermission.CheckPermission("BusManagment.Zone.JZone.Update"))
                return false;
            ZoneTable AT = new ZoneTable();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                if (!isWeb)
                    Nodes.Refreshdata(Nodes.CurrentNode, JZones.GetDataTable(Code).Rows[0]);
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("BusManagment.JZone", AT.Code, 0, 0, 0, "ویرایش مناطق", "", 0);
                return true;
            }
            else
                return false;
        }

        public bool Delete(bool isWeb = false)
        {
            if (!JPermission.CheckPermission("BusManagment.Zone.JZone.Delete"))
                return false;
            ZoneTable AT = new ZoneTable();
            AT.SetValueProperty(this);
            if (AT.Delete())
            {
                if (!isWeb)
                    Nodes.Delete(Nodes.CurrentNode);
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("BusManagment.JZone", AT.Code, 0, 0, 0, "حذف مناطق", "", 0);
                return true;
            }
            else return false;
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTZone where code=" + pCode.ToString());
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
            Node.Name = "Zone";
            Node.MouseClickAction = new JAction("Zone", "BusManagment.Zone.JZones.ListView");

            return Node;
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "BusManagment.Zone.JZone");
            JPopupMenu pMenu = new JPopupMenu("BusManagment.Bus.JBuses", Node.Code);
            JAction deleteAction = new JAction("delete...", "BusManagment.Zone.JZone.Delete", null, new object[] { (int)pRow["Code"] });
            JAction editAction = new JAction("Edit...", "BusManagment.Zone.JZoneForm.ShowDialog", null, new object[] { (int)pRow["Code"] });
            JAction newAction = new JAction("new...", "BusManagment.Zone.JZoneForm.ShowDialog", null, null);

            pMenu.Insert(deleteAction);
            pMenu.Insert(editAction);
            pMenu.Insert(newAction);

            Node.Popup = pMenu;
            Node.MouseDBClickAction = editAction;
            return Node;

        }
    }


    public class JZones : JSystem
    {

        public static DataTable GetDataTable(int pCode = 0)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = "select *,(cast(Code as varchar) + ' - ' + Name)NameWithCode from AUTZone "
                     + " Where " + JPermission.getObjectSql("BusManagment.Zone.JZones.GetDataTable", "AUTZone.Code");
                if (pCode > 0)
                    query += " AND  Code = " + pCode;
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

        public void ListView()
        {
            JSystem.Nodes.DataTable = GetDataTable(0);
            JSystem.Nodes.ObjectBase = new JAction("Zone", "BusManagment.Zone.JZone.GetNode");
            JAction ActInsertAutombile = new JAction("Insert", "BusManagment.Zone.JZoneForm.ShowDialog");

            JToolbarNode InsertAutombile = new JToolbarNode();
            InsertAutombile.Click = ActInsertAutombile;
            InsertAutombile.Icon = JImageIndex.Add;

            JSystem.Nodes.AddToolbar(InsertAutombile);
        }

        public JNode[] TreeView()
        {
            return null;
        }

        public static string GetWebQuery()
        {
            return @"SELECT     
                    dbo.AUTZone.Code, dbo.AUTZone.Name, dbo.AUTZone.Address, dbo.AUTZone.Tel, dbo.AUTZone.Description, dbo.AUTZone.ChiefPersonCode AS N'کد پرسنلی رئیس منطقه', 
                    dbo.clsAllPerson.Name AS N'نام رئیس منطقه'
                    FROM         dbo.AUTZone LEFT OUTER JOIN
                    dbo.clsAllPerson ON dbo.AUTZone.ChiefPersonCode = dbo.clsAllPerson.Code";
        }

        public static string GetWebReportQuery(int ZoneCode = 0, int DayType = -1, DateTime? StartEventDate = null, DateTime? EndEventDate = null,
            int CardType = -1, int FleetCode = 0, Boolean noSHowTicketTypeCard = false, Boolean ChkCityPay = false, Boolean ChkCityWay = false, Boolean ChkTabriz = false, string BankType = "1")
        {

            string PermitionSql = " And " + JPermission.getObjectSql("BusManagment.Bus.JBuses.GetWebBusTransactionReportQuery", "adp.BusCode");
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
                FinalCardType = "and adp.CardType in (" + String.Join(",", JDataBase.DataTableToStringtArray(DtCardType, "Type")) + ")";
                mydb.Dispose();
            }

            string Query = "", WhereStr = "", WhereStrFleet = "", WhereServiceStr = "", WhereStrBank = "";
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day);
            DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day);
            if (ZoneCode > 0 || DayType > -1 || StartEventDate.HasValue == true || CardType > -1 || FleetCode > 0)
            {
                WhereStr = " where adp.TCount > 0 and adp.Price > 0 and adp.TicketPrice > 0 and adp.Error = 0 and ab.Active = 1 and ab.IsValid = 1 ";

                if (ZoneCode > 0)
                    WhereStr += @" and az.Code=" + ZoneCode;

                if (FleetCode > 0)
                    WhereStrFleet += @" and FleetCode = " + FleetCode;

                if (StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime)
                {
                    WhereStr += @" and adp.[Date] between '" + StartDTime.ToShortDateString() + " 00:00:00' and '" + EndDTime.ToShortDateString() + " 23:59:59'";
                    WhereServiceStr += @" and [Date] between '" + StartDTime.ToShortDateString() + " 00:00:00' and '" + EndDTime.ToShortDateString() + " 23:59:59'";
                }

                if (CardType > -1)
                    WhereStr += @" and adp.CardType=" + CardType;

                if (DayType > -1)
                    WhereStr += " and adp.ISHoliDay = " + DayType;

            }
            if (!string.IsNullOrWhiteSpace(BankType))
                WhereStrBank += @" and BankType IN ( " + BankType + ")";

            if (noSHowTicketTypeCard)
            {
                Query = @"select top 100 percent max(adp.Code)Code,af.Name FleetName,az.Name ZoneName,
                        sum(adp.Tcount)TransactionCount,sum(cast(adp.Price as bigint))*10  InCome ,
                        (
                            select sum(a.NumOfService) from AutBusServices a 
                                where zoneCode = az.code " + WhereServiceStr + @"
                        
                        ) ServiceCount
                        ,case adp.Banktype when 0 then N'کارت تبریز'  when 1 then N'کارت تبریز2' when 2 then N'کارت CityWay' when 3 then N'کارت CityPay' else N'نامشخص' end BankType 
                        ,adp.CityBankResponse
                        from 
                        (select * from AUTDailyPerformanceRportOnBus where BusCode in (select Code from AUTBus where 1 = 1 " + WhereStrFleet + @")) adp
                        left join [dbo].[AUTBus] AB on adp.BusCode = AB.Code
                        left join AUTLine al on al.LineNumber = adp.LineNumber
                        left join AUTZone az on az.Code = al.ZoneCode
                        left join AUTFleet af on af.Code = al.Fleet
                        " + WhereStr + WhereStrBank + FinalCardType + PermitionSql + @"
                        group by af.Name,az.Name,az.code,adp.Banktype,adp.CityBankResponse";
            }
            else if (ChkCityPay || ChkCityWay || ChkTabriz)
            {
                Query = @"select top 100 percent max(adp.Code)Code,af.Name FleetName,az.Name ZoneName,adp.CardType,cast(adp.TicketPrice * 10.0 as float) TicketPrice,
                        sum(adp.Tcount)TransactionCount,sum(cast(adp.Price as bigint))*10  InCome ,
                        (
                            select sum(a.NumOfService) from AutBusServices a 
                                where zoneCode = az.code " + WhereServiceStr + @"
                        
                        ) ServiceCount
                        ,case adp.Banktype when 0 then N'کارت تبریز'  when 1 then N'کارت تبریز2' when 2 then N'کارت CityWay' when 3 then N'کارت CityPay' else N'نامشخص' end BankType 
                        ,adp.CityBankResponse
                        from 
                        (select * from AUTDailyPerformanceRportOnBus where BusCode in (select Code from AUTBus where 1 = 1 " + WhereStrFleet + @")) adp
                        left join [dbo].[AUTBus] AB on adp.BusCode = AB.Code
                        left join AUTLine al on al.LineNumber = adp.LineNumber
                        left join AUTZone az on az.Code = al.ZoneCode
                        left join AUTFleet af on af.Code = al.Fleet
                        " + WhereStr + WhereStrBank + FinalCardType + PermitionSql + @"
                        group by af.Name,az.Name,adp.CardType,adp.TicketPrice,az.code,adp.Banktype,adp.CityBankResponse";
            }
            else
            {
                Query = @"select top 100 percent max(adp.Code)Code,af.Name FleetName,az.Name ZoneName,adp.CardType,cast(adp.TicketPrice * 10.0 as float) TicketPrice,
                        sum(adp.Tcount)TransactionCount,sum(cast(adp.Price as bigint))*10  InCome ,
                        (
                            select sum(a.NumOfService) from AutBusServices a 
                                where zoneCode = az.code " + WhereServiceStr + @"
                        
                        ) ServiceCount
                        from 
                        (select * from AUTDailyPerformanceRportOnBus where BusCode in (select Code from AUTBus where 1 = 1 " + WhereStrFleet + @")) adp
                        left join [dbo].[AUTBus] AB on adp.BusCode = AB.Code
                        left join AUTLine al on al.LineNumber = adp.LineNumber
                        left join AUTZone az on az.Code = al.ZoneCode
                        left join AUTFleet af on af.Code = al.Fleet
                        " + WhereStr + FinalCardType + PermitionSql + @"
                        group by af.Name,az.Name,adp.CardType,adp.TicketPrice,az.code";
            }
            return Query;
        }


        public static string GetWebReportQueryForChart(int ZoneCode = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null, int CardType = -1)
        {
            string Query = "", WhereStr = "";
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day);
            DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day);
            if (ZoneCode > 0 || StartEventDate.HasValue == true || CardType > -1)
            {
                WhereStr = " where BusCode in (select Code from AUTBus) and adp.TCount > 0 and adp.Price > 0 and adp.TicketPrice > 0 and adp.Error = 0 and ab.Active = 1 and ab.IsValid = 1 and az.code is not null ";

                if (ZoneCode > 0)
                    WhereStr += @" and az.Code=" + ZoneCode;

                if (StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime)
                {
                    WhereStr += @" and adp.[Date] between '" + StartDTime.ToShortDateString() + " 00:00:00' and '" + EndDTime.ToShortDateString() + " 23:59:59'";
                }

                if (CardType > -1)
                    WhereStr += @" and adp.CardType=" + CardType;

            }

            Query = @"select  az.Name,az.code,sum(tcount)sCount,sum(price)sPrice from AUTDailyPerformanceRportOnBus adp
                        left join [dbo].[AUTBus] AB on adp.BusCode = AB.Code
                                                left join AUTLine al on al.LineNumber = adp.LineNumber
                                                left join AUTZone az on az.Code = al.ZoneCode
                        " + WhereStr + @"
                        group by az.Name,az.code";
            return Query;
        }

    }

}
