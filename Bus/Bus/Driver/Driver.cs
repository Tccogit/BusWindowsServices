using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using ClassLibrary;
namespace BusManagment.Driver
{

    public enum JDriverLogType
    {
        Loggin = 1,
        Logout = 2,
    }

    public class JDriver
    {
        public int Code { get; set; }
        public int PersonCode { get; set; }
        public int EmploymentCode { get; set; }
        public string CertificateNumber { get; set; }
        public DateTime CertificateDate { get; set; }
        public DateTime CertificateExpirationDate { get; set; }
        public int CertificateType { get; set; }

        public int Insert()
        {
            DriveTable AT = new DriveTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            return Code;
        }
        public bool Update()
        {
            DriveTable AT = new DriveTable();
            AT.SetValueProperty(this);
            return AT.Update();
        }

        public bool Delete()
        {
            DriveTable AT = new DriveTable();
            AT.SetValueProperty(this);
            return AT.Delete();
        }
        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTDrive where code=" + pCode.ToString());
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
            Node.Name = "Driver";
            Node.MouseClickAction = new JAction("Driver", "BusManagment.Driver.JDriverse.ListView");

            return Node;
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "Driver.JDriver");
            Node.MouseDBClickAction = new JAction("EditDriver", "BusManagment.Driver.DriverForm.ShowDialog", null, new object[] { (int)pRow["Code"] });
            return Node;
        }
    }
    public class JDriverse
    {

        public void ListView()
        {
            JSystem.Nodes.DataTable = GetDataTable();
            JSystem.Nodes.ObjectBase = new JAction("Driver", "BusManagment.Driver.JDriver.GetNode");
            JAction ActInsertAutombile = new JAction("Insert", "BusManagment.Driver.DriverForm.ShowDialog");

            JToolbarNode InsertAutombile = new JToolbarNode();
            InsertAutombile.Click = ActInsertAutombile;
            InsertAutombile.Icon = JImageIndex.Add;

            JSystem.Nodes.AddToolbar(InsertAutombile);
        }

        public JNode[] TreeView()
        {
            return null;
        }
        public static DataTable GetDataTable()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTDrive");
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
        public static int GetDriverPersonCode(string DriverCardCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = @"select PCode from Cards where CardCode = " + DriverCardCode;
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

    }

    public class JDriverLog
    {
        public int Code { get; set; }
        public DateTime EventDate { get; set; }
        public int LogType { get; set; }
        public int Insert()
        {
            JDriverLogTable AT = new JDriverLogTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            return Code;
        }
        public bool Update()
        {
            JDriverLogTable AT = new JDriverLogTable();
            AT.SetValueProperty(this);
            return AT.Update();
        }

        public bool Delete()
        {
            JDriverLogTable AT = new JDriverLogTable();
            AT.SetValueProperty(this);
            return AT.Delete();
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTDriveLog where code=" + pCode.ToString());
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
        }//end of GetData Method
        public static JNode GetTreeNode()
        {
            JNode Node = new JNode(0, 0);
            Node.Name = "DriverLog";
            Node.MouseClickAction = new JAction("DriverLog", "BusManagment.Driver.JDriverseLogs.ListView");

            return Node;
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "Driver.JDriverLog");
            Node.MouseDBClickAction = new JAction("EditDriver", "BusManagment.Driver.DriverLogForm.ShowDialog", null, new object[] { (int)pRow["Code"] });
            return Node;
        }
    }
    public class JDriverseLogs
    {
        //ooo
        public void ListView()
        {
            JSystem.Nodes.DataTable = GetDataTable();
            JSystem.Nodes.ObjectBase = new JAction("DriverLog", "Driver.JDriverLog.GetNode");
            JAction ActInsertAutombile = new JAction("Insert", "BusManagment.Driver.DriverLogForm.ShowDialog");

            JToolbarNode InsertAutombile = new JToolbarNode();
            InsertAutombile.Click = ActInsertAutombile;
            InsertAutombile.Icon = JImageIndex.Add;

            JSystem.Nodes.AddToolbar(InsertAutombile);
        }

        public JNode[] TreeView()
        {
            return null;
        }
        public DataTable GetDataTable()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTDriveLog");
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

        public static DataTable GetBusDriver()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"select cap.Code,cap.Name DriverName from Cards c 
                                left join clsAllPerson cap on cap.Code = c.PCode
                                where RfidNumber in (
                                select DriverCardSerial from AUTDailyPerformanceRportOnBus
                                )
                                and cap.Code IS NOT NULL
                                group by cap.Code,cap.Name");
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

        public static string GetWebDriverPerformanceReportQueryWithMultiDriver(int[] DriverCode, DateTime? StartEventDate = null, DateTime? EndEventDate = null, int ZoneCode = 0, int LineNumber = 0, int BusNumebr = 0, int CardType = -1, int BusOwner = 0, int fromId = 0, int ToId = 0)
        {

            string PermitionSql = " and " + ClassLibrary.JPermission.getObjectSql("BusManagment.Bus.JBuses.GetAllBusesOnly", "DP.BusCode");
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

            string Query = "", WhereStr = "";
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            if (StartEventDate.HasValue == true || DriverCode.Length > 0 || ZoneCode > 0 || LineNumber > 0 || BusNumebr > 0 || CardType > -1)
            {
                WhereStr = " where 1=1 ";

                if (DriverCode.Length > 0)
                {
                    WhereStr += @" and ALLP.Code in (" + DriverCode;
                    for (int i = 0; i < DriverCode.Length; i++)
                    {
                        WhereStr += @"" + DriverCode[i].ToString() + @",";
                    }
                    WhereStr = WhereStr.Remove(WhereStr.Length - 1, 1);
                    WhereStr += ") ";
                }

                if (ZoneCode > 0)
                    WhereStr += " and AZ.Code = " + ZoneCode;
                if (LineNumber > 0)
                    WhereStr += " and AL.Code = " + LineNumber;
                if (BusNumebr > 0)
                    WhereStr += " and DP.BusCode = " + BusNumebr;
                if (CardType > -1)
                    WhereStr += " and DP.CardType = " + CardType;
                if (BusOwner > 0)
                    WhereStr += " and DP.OwnerCode = " + BusOwner;

                if (StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime)
                {
                    DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day);
                    DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day);
                    WhereStr += @" and DP.Date between '" + StartDTime.ToShortDateString() + "' and '" + EndDTime.ToShortDateString() + "'";
                }

            }

            if (ToId == 0) ToId = 1000000;

            Query = @"select b.* from (
                            select row_number() over (order by A.TransactionCount)ROWID,A.* from (
                            select isnull(ALLP.Name,AB.BUSNumber) as DriverName,sum(cast(DP.TCount as float)) as TransactionCount,sum(cast(DP.Price as float)) * 10 as InCome
                            from [dbo].[AUTDailyPerformanceRportOnBus] DP
                            left join [dbo].[AUTBus] AB on DP.BusCode = AB.Code
                            left join [dbo].[AUTLine] AL on DP.LineNumber = AL.LineNumber
                            left join [dbo].[AUTZone] AZ on AL.ZoneCode = AZ.Code
                            left join [dbo].[AUTFleet] AF on AL.Fleet = AF.Code 
							left join [dbo].[clsAllPerson] ALLP on DP.DriverPersonCode = ALLP.Code  
							" + WhereStr + PermitionSql + FinalCardType + @"
                            group by ALLP.Name,AB.BUSNumber)A )B where B.RowID between " + fromId + @" and " + ToId;

            return Query;
        }

        public static string GetWebDriverPerformanceReportQuery(int DriverCode = 0, int ZoneCode = 0, int LineNumber = 0, int BusNumebr = 0, int DayType = -1, DateTime? StartEventDate = null, DateTime? EndEventDate = null, int OwnerCode = 0, bool CalcService = false, int CardType = -1, int FleetCode = 0, int MinTransaction = 0, int MaxTransaction = 0)
        {

            string PermitionSql = " and " + ClassLibrary.JPermission.getObjectSql("BusManagment.Bus.JBuses.GetAllBusesOnly", "DP.BusCode");
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

            string Query = "", Having = "", WhereStr = " where Dp.TCount > 0 and DP.Price > 0 and DP.TicketPrice > 0 and DP.Error = 0 ";
            string WhereDateStr = "";
            string WhereMinMaxStr = "";
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            if (DriverCode > 0 || ZoneCode > 0 || LineNumber > 0 || BusNumebr > 0 || DayType > -1 || StartEventDate.HasValue == true || OwnerCode > 0 || CalcService == true || CardType > -1 || FleetCode > 0)
            {
                if (DriverCode > 0)
                    WhereStr += @" and DP.DriverPersonCode=" + DriverCode;

                if (ZoneCode > 0)
                    WhereStr += @" and AZ.Code=" + ZoneCode;

                if (FleetCode > 0)
                    WhereStr += @" and AL.Fleet = " + FleetCode;

                if (LineNumber > 0)
                    WhereStr += @" and AL.Code=" + LineNumber;

                if (OwnerCode > 0)
                {
                    WhereStr += @" and DP.OwnerCode = " + OwnerCode;
                }
                else
                {
                    if (BusNumebr > 0)
                        WhereStr += @" and DP.BusCode=" + BusNumebr;
                }

                if (StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime)
                {
                    DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day);
                    DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day);
                    WhereStr += @" and DP.[Date] between '" + StartDTime.ToShortDateString() + "' and '" + EndDTime.ToShortDateString() + "'";
                    WhereDateStr += @" between '" + StartDTime.ToShortDateString() + "' and '" + EndDTime.ToShortDateString() + "'";
                }

                //if(CalcService==true)

                if (DayType > -1)
                    WhereStr += " and DP.IsHoliDay = " + DayType;

                if (CardType > -1)
                    WhereStr += @" and DP.CardType=" + CardType;

            }

            if (MinTransaction > 0)
            {
                WhereMinMaxStr += " and TransactionCount/WorkDay > " + MinTransaction;
            }

            if (MaxTransaction > 0)
            {
                WhereMinMaxStr += " and TransactionCount/WorkDay < " + MaxTransaction;
            }

            Query = @"select *,CASE WHEN WorkDay=0 THEN 0 ELSE  TransactionCount/WorkDay END AvgWork from
(
	select top 100 percent max(DP.Code) as Code,cap.Name as OwnerName,DP.DriverPersonCode as PersonelCode,ALLP.Name as DriverName,DP.DriverCardSerial
                            ,AF.Name as FleetName,AZ.Name as ZoneName,
                            DP.LineNumber,AB.BUSNumber,DP.CardType,DP.TicketPrice * 10 as TicketPrice,sum(DP.TCount) as TransactionCount,sum(DP.Price) * 10 as InCome
							,
								(
									select count(*) from
									( 
										select Date from [AUTDailyPerformanceRportOnBus] AP1 
										where AP1.DriverCardSerial=dp.DriverCardSerial 
										and ap1.BusNumber = ab.BusNumber
										and ap1.TicketPrice=dp.TicketPrice
										and ap1.LineNumber=dp.LineNumber
										and ap1.CardType=dp.CardType
										and AP1.Date " + WhereDateStr + @"
										group by Date
									)a
								) WorkDay,
								(SELECT sum(DATEDIFF(minute, FirstStationDate,LastStationDate)) FROM AutBusServices ABC WHERE ABC.LineNumber=DP.LineNumber and abc.Date " + WhereDateStr + @" and abc.BusNumber=AB.BusNumber and abc.DriverPersonCode=dp.DriverPersonCode) KarKard
                            from [dbo].[AUTDailyPerformanceRportOnBus] DP
                            left join [dbo].[AUTBus] AB on DP.BusCode = AB.Code
                            left join [dbo].[AUTLine] AL on DP.LineNumber = AL.LineNumber
                            left join [dbo].[AUTZone] AZ on AL.ZoneCode = AZ.Code
                            left join [dbo].[AUTFleet] AF on AL.Fleet = AF.Code 
                            left join [dbo].[clsAllPerson] ALLP on DP.DriverPersonCode = ALLP.Code
                            left join AUTBusOwner abo on DP.BusCode = abo.BusCode and abo.IsActive=1
							left join clsAllPerson cap on abo.CodePerson = cap.Code
							" + WhereStr + PermitionSql + FinalCardType + @"
							group by cap.Name,DP.CardType,DP.DriverPersonCode,ALLP.Name,DP.DriverCardSerial,AF.Name,AZ.Name,DP.LineNumber,AB.BUSNumber,DP.TicketPrice
) as a
where 1=1 " + WhereMinMaxStr;

            return Query;
        }

    }
}

