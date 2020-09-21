using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace BusManagment.WorkOrder
{
    public class JHokmeKar : JSystem
    {
        public int Code { get; set; }
        public int DriverPCode { get; set; }
        public DateTime Date { get; set; }
        public int NahveyeHamkariCode { get; set; }
        public int OnvaneShoghliCode { get; set; }
        public int VaziayeHamkariCode { get; set; }
        public int ZoneCode { get; set; }
        public int LineCode { get; set; }
        public int BusNumber { get; set; }
        public int Seri { get; set; }
        public int FaliyatCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
        public int NumOfService { get; set; }
        public int NumOfHolidayService { get; set; }
        public int MorningShiftNumOfservice { get; set; }
        public int EveningShiftNumOfservice { get; set; }
        public int MorningShiftNumOfHolidayservice { get; set; }
        public int EveningShiftNumOfHolidayservice { get; set; }
        public JHokmeKar()
        {
        }
        public JHokmeKar(int pCode)
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
            HokmeKarTable AT = new HokmeKarTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            if (Code > 0 && !isWeb)
                Nodes.DataTable.Merge(JHokmeKars.GetDataTable(Code));
            return Code;
        }

        public bool Update(bool isWeb = false)
        {
            //if (!JPermission.CheckPermission("BusManagment.WorkOrder.JTariff.Update"))
            //    return false;
            HokmeKarTable AT = new HokmeKarTable();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                if (!isWeb)
                    Nodes.Refreshdata(Nodes.CurrentNode, JHokmeKars.GetDataTable(Code).Rows[0]);
                return true;
            }
            else
                return false;
        }

        public bool Delete()
        {
            //   if (!JPermission.CheckPermission("BusManagment.WorkOrder.JTariff.Delete"))
            //     return false;
            HokmeKarTable AT = new HokmeKarTable();
            AT.SetValueProperty(this);
            if (AT.Delete())
            {
                Nodes.Delete(Nodes.CurrentNode);
                return true;
            }
            else return false;
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AutTarrifHokmeKar where code=" + pCode.ToString());
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

        public static bool FindDuplicate(int pCode, int pBusNumber, int pSeri, DateTime pStartDate)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AutTarrifHokmeKar where Code <> @Code and BusNumber = @BusNumber and Seri = @Seri and StartDate = @StartDate and Status=1");
                DB.AddParams("Code", pCode.ToString());
                DB.AddParams("BusNumber", pBusNumber.ToString());
                DB.AddParams("Seri", pSeri.ToString());
                DB.AddParams("StartDate", pStartDate.ToString("yyyy-MM-dd"));
                DataTable dt = DB.Query_DataTable();
                if (dt.Rows.Count == 0)
                {
                    return false;
                }
            }
            finally
            {
                DB.Dispose();
            }
            return true;
        }

        public static JNode GetTreeNode()
        {
            JNode Node = new JNode(0, 0);
            Node.Name = "WorkOrder";
            Node.MouseClickAction = new JAction("WorkOrder", "BusManagment.WorkOrder.JHokmeKars.ListView");

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

    public class JHokmeKars : JSystem
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
            return @"select th.Code, cap.Name,th.Date,s.Name NahveyeHamkari,s2.name OnvaneShoghli,s3.name VaziayeHamkari,
                        Az.Name ZoneName,Al.LineNumber ,th.BusNumber,Th.Seri,s4.name FaliyatCode
                        from AutTarrifHokmeKar th
                        left join clsAllPerson cap on cap.Code = th.DriverPCode
                        left join subdefine s on s.Code = th.NahveyeHamkariCode
                        left join subdefine s2 on s2.Code = th.OnvaneShoghliCode
                        left join subdefine s3 on s3.Code = th.VaziayeHamkariCode
                        left join AUTZone az on az.Code = th.ZoneCode
                        left join AUTLine al on al.code = th.LineCode
                        left join subdefine s4 on s4.Code = th.FaliyatCode";
        }

        public static DataTable GetDataTable(int pCode = 0)
        {
            //if (!JPermission.CheckPermission("BusManagment.WorkOrder.JHokmeKars.GetDataTable"))
            //    return null;
            JDataBase DB = new JDataBase();
            try
            {
                string query = @"select th.Code,cap.Name,th.Date,s.Name NahveyeHamkari,s2.name OnvaneShoghli,s3.name VaziayeHamkari,
                                    Az.Name ZoneName,Al.LineNumber ,th.BusNumber,Th.Seri,s4.name FaliyatCode
                                    from AutTarrifHokmeKar th
                                    left join clsAllPerson cap on cap.Code = th.DriverPCode
                                    left join subdefine s on s.Code = th.NahveyeHamkariCode
                                    left join subdefine s2 on s2.Code = th.OnvaneShoghliCode
                                    left join subdefine s3 on s3.Code = th.VaziayeHamkariCode
                                    left join AUTZone az on az.Code = th.ZoneCode
                                    left join AUTLine al on al.code = th.LineCode
                                    left join subdefine s4 on s4.Code = th.FaliyatCode";
                if (pCode > 0)
                    query += " where th.DriverPCode = " + pCode;

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


