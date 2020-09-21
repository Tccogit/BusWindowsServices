using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace BusManagment.WorkOrder
{
    public class JTariff : JSystem
    {
        public int Code { get; set; }
        public int LineCode { get; set; }
        public float NumOfService { get; set; }
        public int BusCode { get; set; }
        public int DriverCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DriverWorkType { get; set; }
        public int DriverWorkStatus { get; set; }
        //public DateTime StartDate { get; set; }
        //public DateTime EndDate { get; set; }
        public DateTime Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int ShiftCode { get; set; }
        public int FaliyatCode { get; set; }
        public int OnvaneShoghliCode { get; set; }
        public int GozareshCode { get; set; }
        public int ZoneCode { get; set; }
        public int DailyLineTransactionCount { get; set; }
        public int MinNumOfService { get; set; }
        public JTariff()
        {
        }
        public JTariff(int pCode)
        {
            if (pCode > 0)
            {
                this.GetData(pCode);
            }
        }
        public int Insert(bool isWeb = false)
        {
            //if (!JPermission.CheckPermission("BusManagment.WorkOrder.JTariff.Insert"))
            //    return 0;
            TariffTable AT = new TariffTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            if (Code > 0 && !isWeb)
                Nodes.DataTable.Merge(JTariffs.GetDataTable(Code));
            return Code;
        }

        public bool Update(bool isWeb = false)
        {
            //if (!JPermission.CheckPermission("BusManagment.WorkOrder.JTariff.Update"))
            //    return false;
            TariffTable AT = new TariffTable();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                if (!isWeb)
                    Nodes.Refreshdata(Nodes.CurrentNode, JTariffs.GetDataTable(Code).Rows[0]);
                return true;
            }
            else
                return false;
        }

        public bool Delete(bool isWeb = false, JDataBase db = null)
        {
            if (!JPermission.CheckPermission("BusManagment.WorkOrder.JTariff.Delete"))
                return false;
            TariffTable AT = new TariffTable();
            AT.SetValueProperty(this);
            if (isWeb || JMessages.Question("آیا میخواهید حکم انتخاب شده حذف شود؟", "") == System.Windows.Forms.DialogResult.Yes)
            {
                if (AT.Delete(db))
                {
                    if (!isWeb)
                        Nodes.Delete(Nodes.CurrentNode);
                    return true;
                }
                else return false;
            }
            return false;
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTTariff where code=" + pCode.ToString());
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
            Node.Name = "WorkOrder";
            Node.MouseClickAction = new JAction("WorkOrder", "BusManagment.WorkOrder.JTariffs.ListView");

            return Node;
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "BusManagment.WorkOrder.JTariff");
            Node.MouseDBClickAction = new JAction("EditFleet", "BusManagment.WorkOrder.JTariffForm.ShowDialog", null, new object[] { (int)pRow["Code"] });
            JAction DeleteItem = new JAction("Delete", "BusManagment.WorkOrder.JTariff.Delete", null, new object[] { (int)pRow["Code"] });
            JAction NewItem = new JAction("New...", "BusManagment.WorkOrder.JTariffForm.ShowDialog", null, new object[] { });
            JAction EditItem = new JAction("Edit...", "BusManagment.WorkOrder.JTariffForm.ShowDialog", null, new object[] { (int)pRow["Code"] });
            JAction VacationItem = new JAction("RegisterVacation...", "BusManagment.WorkOrder.JVacationForm.ShowDialog", null, new object[] { 0, Convert.ToInt32(pRow["DriverCode"]) });
            Node.Popup.Insert(VacationItem);
            Node.Popup.Insert(DeleteItem);
            Node.Popup.Insert(EditItem);
            Node.Popup.Insert(NewItem);
            return Node;
        }


        public static void ServiceProcessFunction(ClassLibrary.JDataBase Db)
        {
            //Service Set With Job This Process Not Need
            return;
            //Start
            Db.setQuery(@"select top 1000 TblA.*,TblB.LineCode,TblB.GoFirstStation,TblB.GoLastStation,TblB.BackFirstStation,TblB.BackLastStation from (
                            select
                            abps.[Code],abps.[EventDate],abps.[BusNumber],abps.[StationCode],abps.[InsertDate],abps.[IsProcessed],abps.[ProcessDate],ab.LastLineNumber
                            from AutBusPassingStations abps
                            left join AUTBus ab on abps.BusNumber = ab.BUSNumber
                            where abps.IsProcessed = 0 and abps.EventDate between DateADD(month , -1 ,getdate()) and getdate()
                            )TblA
                            left join (
                            select al.Code LineCode,al.LineNumber
                            ,(select top 1 StationCode from AUTLineStation where LineCode = al.Code and IsBack = 0 and Priority = 
                            (select min(Priority) from AUTLineStation where LineCode = al.Code and IsBack = 0)) GoFirstStation 
                            ,(select top 1 StationCode from AUTLineStation where LineCode = al.Code and IsBack = 0 and Priority = 
                            (select max(Priority) from AUTLineStation where LineCode = al.Code and IsBack = 0)) GoLastStation 
                            ,(select top 1 StationCode from AUTLineStation where LineCode = al.Code and IsBack = 1 and Priority = 
                            (select min(Priority) from AUTLineStation where LineCode = al.Code and IsBack = 1)) BackFirstStation 
                            ,(select top 1 StationCode from AUTLineStation where LineCode = al.Code and IsBack = 1 and Priority = 
                            (select max(Priority) from AUTLineStation where LineCode = al.Code and IsBack = 1)) BackLastStation 
                            from AUTLine al
                            where al.Code in (select distinct LineCode from AUTLineStation)
                            )TblB on TblA.LastLineNumber = TblB.LineNumber
                            ");
            DataTable DtStationPass = Db.Query_DataTable();
            if (DtStationPass != null)
            {
                if (DtStationPass.Rows.Count > 0)
                {
                    for (int i = 0; i < DtStationPass.Rows.Count; i++)
                    {
                        if (DtStationPass.Rows[i]["StationCode"].ToString() == DtStationPass.Rows[i]["GoFirstStation"].ToString() 
                            || DtStationPass.Rows[i]["StationCode"].ToString() == DtStationPass.Rows[i]["BackFirstStation"].ToString())
                        {
                            Db.setQuery(@"INSERT INTO [dbo].[AutBusServices]
                                               ([Date]
                                               ,[BusNumber]
                                               ,[FirstStationCode]
                                               ,[FirstStationDate]
                                               ,[LastStationCode]
                                               ,[LastStationDate]
                                               ,[DriverCardSerial]
                                               ,[DriverPersonCode]
                                               ,[InsertDate]
                                               ,[FromConsole]
                                               ,[IsOk]
                                               ,[Deleted]
                                               ,[NumOfService]
                                               ,[EzamBeCode]
                                               ,[LineNumber])
                                         VALUES
                                               (cast('" + DtStationPass.Rows[i]["EventDate"].ToString() + @"' as date)
                                               ," + DtStationPass.Rows[i]["BusNumber"].ToString() + @"
                                               ," + DtStationPass.Rows[i]["StationCode"].ToString() + @"
                                               ,'" + DtStationPass.Rows[i]["EventDate"].ToString() + @"'
                                               ,0
                                               ,null
                                               ,0
                                               ,0
                                               ,getdate()
                                               ,0
                                               ,4
                                               ,0
                                               ,1
                                               ,null
                                               ,null)");
                            Db.Query_Execute();
                        }
                        else if (DtStationPass.Rows[i]["StationCode"].ToString() == DtStationPass.Rows[i]["GoLastStation"].ToString() 
                                 || DtStationPass.Rows[i]["StationCode"].ToString() == DtStationPass.Rows[i]["BackLastStation"].ToString())
                        {
                            Db.setQuery(@"UPDATE [dbo].[AutBusServices]
                                           SET [LastStationCode] = " + DtStationPass.Rows[i]["StationCode"].ToString() + @"
                                              ,[LastStationDate] = '" + DtStationPass.Rows[i]["EventDate"].ToString() + @"'
                                              ,[InsertDate] = getdate()
                                         WHERE [BusNumber] = " + DtStationPass.Rows[i]["BusNumber"].ToString() + @" and [Date] = cast('" + DtStationPass.Rows[i]["EventDate"].ToString() + @"' as date) 
                                         and ([LastStationCode] = 0 or [LastStationCode] Is Null)");
                            Db.Query_Execute();
    }
                        Db.setQuery(@"update AutBusPassingStations set IsProcessed = 1 , ProcessDate = getdate() where Code = " + DtStationPass.Rows[i]["Code"].ToString());
                        Db.Query_Execute();
                    }
                }
            }
            //End
        }

    }

    public class JTariffs : JSystem
    {
        public void ListView()
        {
            JSystem.Nodes.DataTable = GetDataTable();
            JSystem.Nodes.ObjectBase = new JAction("Tariff", "BusManagment.WorkOrder.JTariff.GetNode");
            JAction ActInsertAutombile = new JAction("Insert", "BusManagment.WorkOrder.JTariffForm.ShowDialog");
            JToolbarNode InsertAutombile = new JToolbarNode();
            InsertAutombile.Click = ActInsertAutombile;
            InsertAutombile.Icon = JImageIndex.Add;
            JSystem.Nodes.AddToolbar(InsertAutombile);
        }

        public ClassLibrary.JNode[] TreeView()
        {
            JNode[] Node = new JNode[3];
            Node[0] = WorkOrder.JShift.GetTreeNode();
            Node[1] = WorkOrder.JTariff.GetTreeNode();
            Node[2] = WorkOrder.JAUTVacation.GetTreeNode();

            return Node;
        }

        public static string GetWebQuery()
        {
//            return @"Select 
//	             AUTTariff.Code,AUTTariff.Code TarrifCode, clsAllPerson.Name DriverName, AUTLine.LineNumber,
//				(select count(*) from AutBusServices where BusNumber = AUTBus.BusNumber and date = cast(AUTTariff.Date as date)) NumOfNimService
//				 , AUTBus .BUSNumber , AUTShift .Title Shift
//	            --, StartDate as date
//                , Date
//				,AUTTariff.StartTime
//				,AUTTariff.EndTime
//				,(select cast(min(FirstStationDate) as time) from AutBusServices where BusNumber = AUTBus.BusNumber and date = cast(AUTTariff.Date as date)) StartWork
//				,(select cast(max(LastStationDate) as time) from AutBusServices where BusNumber = AUTBus.BusNumber and date = cast(AUTTariff.Date as date)) EndWork
//             from AUTTariff 
//	            left join clsAllPerson on  AUTTariff.DriverCode = clsAllPerson.Code 
//	            left join AUTLine  on  AUTLine.Code  = AUTTariff.LineCode 
//	            left join AUTBus   on  AUTBus.Code  = AUTTariff.BusCode 
//	            left join AUTShift    on  AUTShift.Code  = AUTTariff.ShiftCode ";

            return @"Select 
	                    AUTTariff.Code,AUTTariff.Code TarrifCode, clsAllPerson.Name DriverName, AUTLine.LineNumber,
	                    srvs.NumOfNimService--(select count(*) from AutBusServices where BusNumber = AUTBus.BusNumber and date = cast(AUTTariff.Date as date) AND CAST(FirstStationDate AS TIME) BETWEEN AUTTariff.StartTime AND AUTTariff.EndTime) NumOfNimService
		                    , AUTBus .BUSNumber , AUTShift .Title Shift
		                    ,AUTTariff.DriverCode
                        , srvs.Date
	                    ,AUTTariff.StartTime
	                    ,AUTTariff.EndTime
	                    ,srvs.StartWork--,(select cast(min(FirstStationDate) as time) from AutBusServices where BusNumber = AUTBus.BusNumber and date = cast(AUTTariff.Date as date) AND CAST(FirstStationDate AS TIME) BETWEEN AUTTariff.StartTime AND AUTTariff.EndTime) StartWork
	                    ,srvs.EndWork--,(select cast(max(LastStationDate) as time) from AutBusServices where BusNumber = AUTBus.BusNumber and date = cast(AUTTariff.Date as date) AND CAST(FirstStationDate AS TIME) BETWEEN AUTTariff.StartTime AND AUTTariff.EndTime) EndWork
                        from AUTTariff 
	                        left join clsAllPerson on  AUTTariff.DriverCode = clsAllPerson.Code 
	                        left join AUTLine  on  AUTLine.Code  = AUTTariff.LineCode 
	                        left join AUTBus   on  AUTBus.Code  = AUTTariff.BusCode 
	                        left join AUTShift    on  AUTShift.Code  = AUTTariff.ShiftCode
	                        INNER JOIN (
		                        SELECT 
			                        CAST(MIN(bs.FirstStationDate) AS TIME)StartWork
			                        ,CAST(MAX(bs.FirstStationDate) AS TIME)EndWork
			                        ,COUNT(*) NumOfNimService
			                        ,bs.BusNumber
			                        ,bs.Date
		                        FROM AutBusServices bs INNER JOIN AUTTariff t ON t.date = bs.Date AND CAST(bs.FirstStationDate AS TIME) BETWEEN t.StartTime AND t.EndTime
		                        INNER JOIN AUTBus b ON b.Code = t.BusCode AND b.BUSNumber = bs.BusNumber
		                        GROUP BY bs.BusNumber,bs.Date,t.StartTime, t.EndTime
	                        ) srvs ON srvs.BusNumber = AUTBus.BUSNumber AND srvs.Date = CAST(AUTTariff.Date AS DATE)
		                    AND StartWork BETWEEN AUTTariff.StartTime AND AUTTariff.EndTime";
        }

        public static DataTable GetDataTable(int pCode = 0, int pShiftCode = 0)
        {
            //if (!JPermission.CheckPermission("BusManagment.WorkOrder.JTariffs.GetDataTable"))
            //    return null;
            JDataBase DB = new JDataBase();
            try
            {
                string query = @"Select 
	            AUTTariff.Code, clsAllPerson.Name DriverName,DriverWorkType,DriverWorkStatus, AUTLine.LineNumber,AUTTariff.NumOfService , AUTBus .BUSNumber , AUTShift .Title Shift
                , Date
				,AUTTariff.StartTime
				,AUTTariff.EndTime
             from AUTTariff 
	            inner join clsAllPerson on  AUTTariff.DriverCode = clsAllPerson.Code 
	            inner join AUTLine  on  AUTLine.Code  = AUTTariff.LineCode 
	            inner join AUTBus   on  AUTBus.Code  = AUTTariff.BusCode 
	            inner join AUTShift    on  AUTShift.Code  = AUTTariff.ShiftCode  WHERE  1=1 ";
                if (pCode > 0)
                    query += " AND AUTTariff.Code = " + pCode;
                if (pShiftCode > 0)
                    query += " AND AUTTariff.ShiftCode = " + pShiftCode;
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


