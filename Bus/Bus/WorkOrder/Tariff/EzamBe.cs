using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace BusManagment.WorkOrder
{
    public class JEzamBe : JSystem
    {
        public int Code { get; set; }
        public int TarrifCode { get; set; }
        public int LineCode { get; set; }
        public int EzamBe { get; set; }
        public int BusCodeBeJa { get; set; }
        public float NumOfSevice { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public int DriverPCode { get; set; }
        public JEzamBe()
        {
        }
        public JEzamBe(int pCode)
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
            string Query = @"
            DECLARE @EzamBeCode int = (SELECT ISNULL(MAX(Code), 0) + 1 FROM [dbo].[AutTarrifEzamBe])
            INSERT INTO [dbo].[AutTarrifEzamBe]
                        ([Code]
                        ,[TarrifCode]
                        ,[DriverPCode]
                        ,[LineCode]
                        ,[EzamBe]
                        ,[BusCodeBeJa]
                        ,[NumOfSevice]
                        ,[FirstStationCode]
                        ,[LastStationCode]
                        ,[StartTime]
                        ,[FinishTime]
                        ,[IsOk]
                        ,[InsertDate])
                    VALUES
                        (@EzamBeCode
                        ," + this.TarrifCode + @"
                        ," + this.DriverPCode + @"
                        ," + this.LineCode + @"
                        ," + this.EzamBe + @"
                        ," + this.BusCodeBeJa + @"
                        ," + this.NumOfSevice + @"
                        ,null
                        ,null
                        ,'" + this.StartTime + @"'
                        ,'" + this.FinishTime + @"'
                        ,1
                        ,GETDATE())
                INSERT INTO [dbo].[AutBusServices]
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
                        ('" + this.StartTime.ToString("yyyy-MM-dd") + @"'
                        ,(SELECT BusNumber FROM AUTBus WHERE Code = (SELECT BusCode FROM AUTTAriff WHERE Code = " + this.TarrifCode + @"))
                        ,null
                        ,'" + this.StartTime + @"'
                        ,null
                        ,'" + this.FinishTime + @"'
                        ,null
                        ," + this.DriverPCode + @"
                        ,GETDATE()
                        ,0
                        ,4
                        ,0
                        ," + this.NumOfSevice + @"
                        ,@EzamBeCode
                        ,(Select LineNumber from AUTLine Where Code=" + this.LineCode + @" ))

					    declare @tarrif_code int = (select TarrifCode from AutTarrifEzamBe where code = @EzamBeCode)
					    if((select Status from AUTTariff where code = @tarrif_code) = 1)
					    begin
                            exec [dbo].[SP_TarrifeTaeeidByTarrifCode]
                            @tarif_code = @tarrif_code
					    end

                        SELECT @EzamBeCode";
            //,(SELECT BusNumber FROM AUTBus WHERE Code = " + (this.BusCodeBeJa > 0 ? this.BusCodeBeJa.ToString() : "(SELECT BusCode FROM AUTTAriff WHERE Code = " + this.TarrifCode + ")") + @")
            EzamBeTable AT = new EzamBeTable();
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            DataTable dt = new DataTable();
            Db.setQuery(Query);
            Db.beginTransaction("EzamBeInsert");
            try
            {
                dt = Db.Query_DataTable();
                Code = Convert.ToInt32(dt.Rows[0][0]);
                Db.Commit();
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
                Db.Rollback("EzamBeInsert");
            }
            finally
            {
                Db.Dispose();
            }
            if (Code > 0 && !isWeb)
                Nodes.DataTable.Merge(JEzamBes.GetDataTable(Code));
            return Code;
        }

        public bool Update(bool isWeb = false)
        {
            //if (!JPermission.CheckPermission("BusManagment.WorkOrder.JTariff.Update"))
            //    return false;
            string Query = @"
                    UPDATE [dbo].[AutTarrifEzamBe]
                    SET
                         DriverPCode = " + this.DriverPCode + @"
                        ,LineCode = " + this.LineCode + @"
                        ,EzamBe = " + this.EzamBe + @"
                        ,BusCodeBeJa = " + this.BusCodeBeJa + @"
                        ,NumOfSevice = " + this.NumOfSevice + @"
                        ,StartTime = '" + this.StartTime + @"'
                        ,FinishTime = '" + this.FinishTime + @"'
                    WHERE Code = " + Code + @"
                    UPDATE AutBusServices
                    SET
                         Date = '" + this.StartTime.ToString("yyyy-MM-dd") + @"'
                        ,FirstStationDate = '" + this.StartTime + @"'
                        ,LastStationDate = '" + this.FinishTime + @"'
                        ,DriverPersonCode = " + this.DriverPCode + @"
                        ,NumOfService = " + this.NumOfSevice + @"
                    WHERE Date = '" + this.StartTime.ToString("yyyy-MM-dd") + "' AND isok<>11 and EzamBeCode = " + Code + @"

					declare @tarrif_code int = (select TarrifCode from AutTarrifEzamBe where code = " + Code + @")
					if((select Status from AUTTariff where code = @tarrif_code) = 1)
					begin
                        exec [dbo].[SP_TarrifeTaeeidByTarrifCode]
                        @tarif_code = @tarrif_code
					end
					select 1";
            //,BusNumber = (SELECT BusNumber FROM AUTBus WHERE Code = " + (this.BusCodeBeJa > 0 ? this.BusCodeBeJa.ToString() : "(SELECT BusCode FROM AUTTAriff WHERE Code = " + this.TarrifCode + ")") + @")
            EzamBeTable AT = new EzamBeTable();
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            DataTable dt = new DataTable();
            Db.setQuery(Query);
            Db.beginTransaction("EzamBeUpdate");
            try
            {
                if (Convert.ToInt32(Db.Query_DataTable().Rows[0][0]) == 1)
                {
                    if (!isWeb)
                        Nodes.Refreshdata(Nodes.CurrentNode, JEzamBes.GetDataTable(Code).Rows[0]);
                    Db.Commit();
                    return true;
                }
                else
                {
                    Db.Rollback("EzamBeUpdate");
                    return false;
                }
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
                Db.Rollback("EzamBeUpdate");
                return false;
            }
            finally { Db.Dispose(); }
        }

        public static bool Approve(int pCode)
        {
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            Db.setQuery(@"DECLARE @StartDate DATETIME
                              UPDATE AutTarrifEzamBe SET IsOk = 1, @StartDate = StartTime  WHERE Code = " + pCode + @"
                              UPDATE AutBusServices SET IsOk = 4 WHERE Date = CAST(@StartDate AS DATE) AND isok<>11 and EzamBeCode = " + pCode);
            Db.beginTransaction("EzamBeApprove");
            try
            {
                if (Db.Query_Execute() >= 0)
                {
                    Db.Commit();
                    return true;
                }
                else
                {
                    Db.Rollback("EzamBeApprove");
                    return false;
                }
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
                Db.Rollback("EzamBeApprove");
                return false;
            }
            finally { Db.Dispose(); }
        }
        public static bool Disapprove(int pCode)
        {
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            Db.setQuery(@"DECLARE @StartDate DATETIME
                              UPDATE AutTarrifEzamBe SET IsOk = 0, @StartDate = StartTime  WHERE Code = " + pCode + @"
                              UPDATE AutBusServices SET IsOk = 3 WHERE Date = CAST(@StartDate AS DATE) AND isok<>11 and EzamBeCode = " + pCode);
            Db.beginTransaction("EzamBeDisapprove");
            try
            {
                if (Db.Query_Execute() >= 0)
                {
                    Db.Commit();
                    return true;
                }
                else
                {
                    Db.Rollback("EzamBeDisapprove");
                    return false;
                }
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
                Db.Rollback("EzamBeDisapprove");
                return false;
            }
            finally { Db.Dispose(); }
        }

        public bool Delete()
        {
            //   if (!JPermission.CheckPermission("BusManagment.WorkOrder.JTariff.Delete"))
            //     return false;
            EzamBeTable AT = new EzamBeTable();
            AT.SetValueProperty(this);
            //if (JMessages.Question("آیا میخواهید سرویس انتخاب شده حذف شود؟", "") == System.Windows.Forms.DialogResult.Yes)
            // {
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            Db.setQuery(@"DELETE FROM AutBusServices WHERE Date = '" + this.StartTime.ToString("yyyy-MM-dd") + "' AND isok<>11 and EzamBeCode = " + Code + @"
					    declare @tarrif_code int = (select TarrifCode from AutTarrifEzamBe where code = " + Code + @")
					    if((select Status from AUTTariff where code = @tarrif_code) = 1)
					    begin
                            exec [dbo].[SP_TarrifeTaeeidByTarrifCode]
                            @tarif_code = @tarrif_code
					    end
                        select 1");
            Db.beginTransaction("EzamBeDelete");
            try
            {
                if (Convert.ToInt32(Db.Query_DataTable().Rows[0][0]) == 1)
                {
                    if (AT.Delete())
                    {
                        Db.Commit();
                        return true;
                    }
                    else
                    {
                        Db.Rollback("EzamBeDelete");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
                Db.Rollback("EzamBeDelete");
                return false;
            }
            finally { Db.Dispose(); }
            // }
            return false;
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AutTarrifEzamBe where code=" + pCode.ToString());
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
            Node.MouseClickAction = new JAction("WorkOrder", "BusManagment.WorkOrder.JEzamBes.ListView");

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
    }

    public class JEzamBes : JSystem
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
            return @"select * from AutTarrifEzamBe";
        }

        public static DataTable GetDataTable(int pCode = 0)
        {
            //if (!JPermission.CheckPermission("BusManagment.WorkOrder.JEzamBes.GetDataTable"))
            //    return null;
            JDataBase DB = new JDataBase();
            try
            {
                string query = @"select * from AutTarrifEzamBe";
                //if (pCode > 0)
                //  query += " where th.DriverPCode = " + pCode;

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


