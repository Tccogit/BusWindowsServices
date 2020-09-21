using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace BusManagment.DynamicDashboard
{
    public class JDynamicDashboard : JSystem
    {
        public int Code { get; set; }
        public string Title { get; set; }
        public string SqlQuery { get; set; }
        public int Type { get; set; }
        public string ChartX { get; set; }
        public string ChartY { get; set; }
        public int RefreshTimeSec { get; set; }

        public JDynamicDashboard()
        {
        }
        public JDynamicDashboard(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }

        public int Insert(bool isWeb = false)
        {
            if (!JPermission.CheckPermission("BusManagment.DynamicDashboard.JDynamicDashboard.Insert"))
                return 0;
            DynamicDashboardTable AT = new DynamicDashboardTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            if (Code > 0 && !isWeb)
                Nodes.DataTable.Merge(JDynamicDashboards.GetDataTable(Code));
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JDynamicDashboard", Code, 0, 0, 0, "ثبت کوئری داشبورد", "", 0);
            return Code;
        }

        public bool Update(bool isWeb = false)
        {
            if (!JPermission.CheckPermission("BusManagment.DynamicDashboard.JDynamicDashboard.Update"))
                return false;
            DynamicDashboardTable AT = new DynamicDashboardTable();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                if (!isWeb)
                    Nodes.Refreshdata(Nodes.CurrentNode, JDynamicDashboards.GetDataTable(Code).Rows[0]);
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("BusManagment.JDynamicDashboard", AT.Code, 0, 0, 0, "ویرایش کوئری داشبورد", "", 0);
                return true;
            }
            else
                return false;
        }

        public bool Delete(bool isWeb = false)
        {
            if (!JPermission.CheckPermission("BusManagment.DynamicDashboard.JDynamicDashboard.Delete"))
                return false;
            DynamicDashboardTable AT = new DynamicDashboardTable();
            AT.SetValueProperty(this);
            if (AT.Delete())
            {
                if (!isWeb)
                    Nodes.Delete(Nodes.CurrentNode);
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("BusManagment.JDynamicDashboard", AT.Code, 0, 0, 0, "حذف کوئری داشبورد", "", 0);
                return true;
            }
            else return false;
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTDynamicDashboard where code=" + pCode.ToString());
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
            Node.Name = "DynamicDashboard";
            Node.MouseClickAction = new JAction("DynamicDashboard", "BusManagment.DynamicDashboard.JDynamicDashboards.ListView");

            return Node;
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "BusManagment.DynamicDashboard.JDynamicDashboard");
            JPopupMenu pMenu = new JPopupMenu("BusManagment.Bus.JBuses", Node.Code);
            JAction deleteAction = new JAction("delete...", "BusManagment.DynamicDashboard.JDynamicDashboard.Delete", null, new object[] { (int)pRow["Code"] });
            JAction editAction = new JAction("Edit...", "BusManagment.DynamicDashboard.JDynamicDashboardForm.ShowDialog", null, new object[] { (int)pRow["Code"] });
            JAction newAction = new JAction("new...", "BusManagment.DynamicDashboard.JDynamicDashboardForm.ShowDialog", null, null);

            pMenu.Insert(deleteAction);
            pMenu.Insert(editAction);
            pMenu.Insert(newAction);

            Node.Popup = pMenu;
            Node.MouseDBClickAction = editAction;
            return Node;

        }
    }


    public class JDynamicDashboards : JSystem
    {

        public static DataTable GetDataTable(int pCode = 0)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = "select * from AUTDynamicDashboard "
                     + " Where " + JPermission.getObjectSql("BusManagment.DynamicDashboard.JDynamicDashboards.GetDataTable", "AUTDynamicDashboard.Code");
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
            JSystem.Nodes.ObjectBase = new JAction("DynamicDashboard", "BusManagment.DynamicDashboard.JDynamicDashboard.GetNode");
            JAction ActInsertAutombile = new JAction("Insert", "BusManagment.DynamicDashboard.JDynamicDashboardForm.ShowDialog");

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
            return @"SELECT [Code]
                      ,[Title]
                      ,[SqlQuery]
                      ,[Type]
                      ,[ChartX]
                      ,[ChartY]
                      ,[RefreshTimeSec]
                  FROM [AUTDynamicDashboard]";
        }

    }

}
