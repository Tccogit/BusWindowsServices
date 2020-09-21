using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
namespace BusManagment.Fleet
{
    public class JFleet : JSystem
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int FleetType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int Insert(bool isWeb = false)
        {
            if (!ClassLibrary.JPermission.CheckPermission("BusManagment.Fleet.JFleet.Insert"))
                return 0;

            FleetTable AT = new FleetTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            if (Code > 0 && !isWeb)
                Nodes.DataTable.Merge(JFleets.GetDataTable(Code));
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JFleet", Code, 0, 0, 0, "ثبت ناوگان", "", 0);
            return Code;
        }
        public bool Update(bool isWeb = false)
        {
            if (!ClassLibrary.JPermission.CheckPermission("BusManagment.Fleet.JFleet.Update"))
                return false;
            FleetTable AT = new FleetTable();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                if (!isWeb)
                    Nodes.Refreshdata(Nodes.CurrentNode, JFleets.GetDataTable(Code).Rows[0]);
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("BusManagment.JFleet", AT.Code, 0, 0, 0, "ویرایش ناوگان", "", 0);
                return true;
            }
            else
                return false;
        }

        public bool Delete(bool isWeb = false)
        {
            if (!ClassLibrary.JPermission.CheckPermission("BusManagment.Fleet.JFleet.Delete"))
                return false;
            FleetTable AT = new FleetTable();
            AT.SetValueProperty(this);
            if (AT.Delete())
            {
                if (!isWeb)
                    Nodes.Delete(Nodes.CurrentNode);
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("BusManagment.JFleet", AT.Code, 0, 0, 0, "حذف ناوگان", "", 0);
                return true;
            }
            else return false;
        }
        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTFleet where code=" + pCode.ToString());
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
            Node.Name = "Fleet";
            Node.MouseClickAction = new JAction("Fleet", "BusManagment.Fleet.JFleets.ListView");

            return Node;
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "Fleet.JFleet");
            Node.MouseDBClickAction = new JAction("EditFleet", "BusManagment.Fleet.JFleetForm.ShowDialog", null, new object[] { (int)pRow["Code"] });
            JAction DeleteItem = new JAction("Delete", "BusManagment.Fleet.JFleetForm.Delete", null, new object[] { (int)pRow["Code"] });
            JAction NewItem = new JAction("New...", "BusManagment.Fleet.JFleetForm.ShowDialog", null, new object[] { });
            JAction EditItem = new JAction("Edit...", "BusManagment.Fleet.JFleetForm.ShowDialog", null, new object[] { (int)pRow["Code"] });
            Node.Popup.Insert(DeleteItem);
            Node.Popup.Insert(EditItem);
            Node.Popup.Insert(NewItem);

            return Node;

        }
    }

    public class JFleets : JSystem
    {

        public void ListView()
        {
            JSystem.Nodes.DataTable = GetDataTable(0);
            JSystem.Nodes.ObjectBase = new JAction("Fleet", "BusManagment.Fleet.JFleet.GetNode");

            JAction ActInsertAutombile = new JAction("Insert", "BusManagment.Fleet.JFleetForm.ShowDialog");

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
            //if (!ClassLibrary.JPermission.CheckPermission("BusManagment.Fleet.JFleets.GetDataTable"))
            //    return null;
            JDataBase DB = new JDataBase();
            try
            {
                string query = @"select Code, Name,(cast(Code as varchar) + ' - ' + Name)NameWithCode
                    , (Select Name From subdefine Where Code = FleetType ) FleetType
                    , StartDate
                    , EndDate from AUTFleet";
                if (pCode > 0)
                    query += " WHERE Code = " + pCode;
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
            return @"select Code, Name
                    , (Select Name From subdefine Where Code = FleetType ) FleetType
                    , (SELECT Fa_Date FROM StaticDates WHERE En_Date = StartDate) StartDate
                    , (SELECT Fa_Date FROM StaticDates WHERE En_Date = EndDate) EndDate from AUTFleet";

        }
    }
}
