using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ClassLibrary;
using BusManagment.DynamicDashboard;

namespace BusManagment.UserDynamicDashboard
{
    public class JUserDynamicDashboard : JSystem
    {
        public int Code { get; set; }
        public string Title { get; set; }
        public string SqlQuery { get; set; }
        public int Type { get; set; }
        public string ChartX { get; set; }
        public string ChartY { get; set; }
        public int RefreshTimeSec { get; set; }

        public JUserDynamicDashboard()
        {
        }
        public JUserDynamicDashboard(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }

        public int Insert(bool isWeb = false)
        {
            if (!JPermission.CheckPermission("BusManagment.UserDynamicDashboard.JUserDynamicDashboard.Insert"))
                return 0;
            UserDynamicDashboardTable AT = new UserDynamicDashboardTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            if (Code > 0 && !isWeb)
                Nodes.DataTable.Merge(JUserDynamicDashboards.GetDataTable(Code));
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JUserDynamicDashboard", Code, 0, 0, 0, "ثبت اشخاص دارنده داشبورد", "", 0);
            return Code;
        }

        public bool Update(bool isWeb = false)
        {
            if (!JPermission.CheckPermission("BusManagment.UserDynamicDashboard.JUserDynamicDashboard.Update"))
                return false;
            UserDynamicDashboardTable AT = new UserDynamicDashboardTable();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                if (!isWeb)
                    Nodes.Refreshdata(Nodes.CurrentNode, JUserDynamicDashboards.GetDataTable(Code).Rows[0]);
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("BusManagment.JUserDynamicDashboard", AT.Code, 0, 0, 0, "ویرایش اشخاص دارنده داشبورد", "", 0);
                return true;
            }
            else
                return false;
        }

        public bool Delete(bool isWeb = false)
        {
            if (!JPermission.CheckPermission("BusManagment.UserDynamicDashboard.JUserDynamicDashboard.Delete"))
                return false;
            UserDynamicDashboardTable AT = new UserDynamicDashboardTable();
            AT.SetValueProperty(this);
            if (AT.Delete())
            {
                if (!isWeb)
                    Nodes.Delete(Nodes.CurrentNode);
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("BusManagment.JUserDynamicDashboard", AT.Code, 0, 0, 0, "حذف اشخاص دارنده داشبورد", "", 0);
                return true;
            }
            else return false;
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTUserDynamicDashboard where code=" + pCode.ToString());
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
            Node.Name = "UserDynamicDashboard";
            Node.MouseClickAction = new JAction("UserDynamicDashboard", "BusManagment.UserDynamicDashboard.JUserDynamicDashboards.ListView");

            return Node;
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "BusManagment.UserDynamicDashboard.JUserDynamicDashboard");
            JPopupMenu pMenu = new JPopupMenu("BusManagment.Bus.JBuses", Node.Code);
            JAction deleteAction = new JAction("delete...", "BusManagment.UserDynamicDashboard.JUserDynamicDashboard.Delete", null, new object[] { (int)pRow["Code"] });
            JAction editAction = new JAction("Edit...", "BusManagment.UserDynamicDashboard.JUserDynamicDashboardForm.ShowDialog", null, new object[] { (int)pRow["Code"] });
            JAction newAction = new JAction("new...", "BusManagment.UserDynamicDashboard.JUserDynamicDashboardForm.ShowDialog", null, null);

            pMenu.Insert(deleteAction);
            pMenu.Insert(editAction);
            pMenu.Insert(newAction);

            Node.Popup = pMenu;
            Node.MouseDBClickAction = editAction;
            return Node;

        }
    }


    public class JUserDynamicDashboards : JSystem
    {

        public static DataTable GetDataTable(int pCode = 0)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = "select * from AUTUserDynamicDashboard "
                     + " Where " + JPermission.getObjectSql("BusManagment.UserDynamicDashboard.JUserDynamicDashboards.GetDataTable", "AUTUserDynamicDashboard.Code");
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
            JSystem.Nodes.ObjectBase = new JAction("UserDynamicDashboard", "BusManagment.UserDynamicDashboard.JUserDynamicDashboard.GetNode");
            JAction ActInsertAutombile = new JAction("Insert", "BusManagment.UserDynamicDashboard.JUserDynamicDashboardForm.ShowDialog");

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
            return @"SELECT a.[Code]
                          ,u.username UserName
                          ,b.title DashboardTitle
                      FROM [AUTUserDynamicDashboard] a
                      left join AUTDynamicDashboard b on a.[DashboardCode] = b.code
                      left join users u on u.code = a.[UserCode]";
        }

    }

}
