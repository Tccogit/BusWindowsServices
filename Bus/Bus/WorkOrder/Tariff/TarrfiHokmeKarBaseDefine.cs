using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace BusManagment.WorkOrder
{
    public class JTarrfiHokmeKarBaseDefine : JSystem
    {
        public int Code { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ZoneCode { get; set; }
        public int LineCode { get; set; }
        public int Seri { get; set; }
        public int ShiftCode { get; set; }
        public int DatePeriod { get; set; }

        public JTarrfiHokmeKarBaseDefine()
        {
        }
        public JTarrfiHokmeKarBaseDefine(int pCode)
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
            TarrfiHokmeKarBaseDefineTable AT = new TarrfiHokmeKarBaseDefineTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
           // if (Code > 0 && !isWeb)
                //Nodes.DataTable.Merge(JTarrfiHokmeKarBaseDefines.GetDataTable(Code));
            return Code;
        }

        public bool Update(bool isWeb = false)
        {
            //if (!JPermission.CheckPermission("BusManagment.WorkOrder.JTariff.Update"))
            //    return false;
            TarrfiHokmeKarBaseDefineTable AT = new TarrfiHokmeKarBaseDefineTable();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                //if (!isWeb)
                //    Nodes.Refreshdata(Nodes.CurrentNode, JTarrfiHokmeKarBaseDefines.GetDataTable(Code).Rows[0]);
                return true;
            }
            else
                return false;
        }

        public bool Delete(bool isWeb = false)
        {
            //   if (!JPermission.CheckPermission("BusManagment.WorkOrder.JTariff.Delete"))
            //     return false;
            TarrfiHokmeKarBaseDefineTable AT = new TarrfiHokmeKarBaseDefineTable();
            AT.SetValueProperty(this);
            if (AT.Delete())
            {
                if (!isWeb)
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
                DB.setQuery("select * from AutTarrfiHokmeKarBaseDefine where code=" + pCode.ToString());
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
            Node.MouseClickAction = new JAction("WorkOrder", "BusManagment.WorkOrder.JTarrfiHokmeKarBaseDefines.ListView");

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

    public class JTarrfiHokmeKarBaseDefines : JSystem
    {


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
            return @"SELECT at.[Code]
                      ,at.[StartDate]
                      ,at.[EndDate]
                      ,isnull(az.Name,N'همه') ZoneName
                      ,isnull(cast(al.LineNumber as nvarchar(6)), N'همه') LineNumber
                      ,[Seri]
                      ,s.Title ShiftName
                      ,[InsertDate]
                      FROM [AutTarrfiHokmeKarBaseDefine] at
                      left join AUTLine al on at.LineCode = al.Code
                      left join AUTZone az on az.Code = at.ZoneCode
                      left join AUTShift s on s.Code = at.ShiftCode";
        }


    }
}


