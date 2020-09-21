using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
namespace BusManagment.Line
{
    public class JLineServices : JSystem
    {
        public int Code { get; set; }
        public int LineCode { get; set; }
        public int ShiftCode { get; set; }
        public float NumOfSerivec { get; set; }

        public int Insert(bool isWeb = false)
        {
            //if (!JPermission.CheckPermission("BusManagment.Line.JLine.Insert"))
            //    return 0;
            LineServicesTable AT = new LineServicesTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            if (Code > 0 && !isWeb)
                Nodes.DataTable.Merge(JLineServicess.GetDataTable(Code));
            //ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            //jHistory.Save("BusManagment.JLine", Code, 0, 0, 0, "ثبت خطوط", "", 0);
            return Code;
        }
        public JLineServices()
        {
        }
        public JLineServices(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }
        public JLineServices(string pLineNumber)
        {
            if (pLineNumber.Length > 0)
                this.GetData(pLineNumber);
        }
        public bool Update(bool isWeb = false)
        {
            //if (!JPermission.CheckPermission("BusManagment.Line.JLine.Update"))
            //    return false;
            LineServicesTable AT = new LineServicesTable();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                if (!isWeb)
                    Nodes.Refreshdata(Nodes.CurrentNode, JLineServicess.GetDataTable(Code).Rows[0]);
                /// ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                //jHistory.Save("BusManagment.JLine", AT.Code, 0, 0, 0, "ویرایش خطوط", "", 0);
                return true;
            }
            else
                return false;
        }

        public bool Delete(bool isWeb = false)
        {
            //if (!JPermission.CheckPermission("BusManagment.Line.JLine.Delete"))
            //    return false;
            LineServicesTable AT = new LineServicesTable();
            AT.SetValueProperty(this);
            if (AT.Delete())
            {
                if (!isWeb)
                    Nodes.Delete(Nodes.CurrentNode);
                // ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                //jHistory.Save("BusManagment.JLine", AT.Code, 0, 0, 0, "حذف خطوط", "", 0);
                return true;
            }
            else return false;
        }
        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AutLineServices where code=" + pCode.ToString());
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
                DB.setQuery("select top 1 * from AutLineServices where LineCode=" + pLineNumber);
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
            Node.Name = "Line";
            Node.MouseClickAction = new JAction("Line", "BusManagment.Line.JLineServicess.ListView");

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

    public class JLineServicess : JSystem
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
                string query = @"select a.Code N'کد',al.LineNumber N'شماره خط',ash.Title N'شیفت',NumOfSerivec N'تعداد سرویس' from AutLineServices a
                                                                            left join AUTLine al on al.Code = a.LineCode
                                                                            left join AUTShift ash on ash.Code = a.ShiftCode a.TarrifCode 
                                                                             ";
                //+ " Where " + JPermission.getObjectSql("BusManagment.Line.JLineServicess.GetDataTable", "L.Code");
                if (pCode > 0)
                    query += " where a.LineCode = " + pCode;
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
            return @"select a.Code N'کد',al.LineNumber N'شماره خط',ash.Title N'شیفت',NumOfSerivec N'تعداد سرویس' from AutLineServices a
                                                                            left join AUTLine al on al.Code = a.LineCode
                                                                            left join AUTShift ash on ash.Code = a.ShiftCode a.TarrifCode";
        }


      

    }
}
