using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace BusManagment.Line
{

    public class JLineNodePath
    {
        public int Code { get; set; }
        /// <summary>
        /// Station Code
        /// </summary>
        public int SCode { get; set; }
        /// <summary>
        /// Line Code
        /// </summary>
        public int LCode { get; set; }
        public int Order { get; set; }
          public int Insert()
        {
            PathTable AT = new PathTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            return Code;
        }

        public bool Update()
        {
            PathTable AT = new PathTable();
            AT.SetValueProperty(this);
            return AT.Update();
        }

        public bool Delete()
        {
            PathTable AT = new PathTable();
            AT.SetValueProperty(this);
            return AT.Delete();
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTPath where code=" + pCode.ToString());
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
            Node.Name = "Path";
            Node.MouseClickAction = new JAction("Path","BusManagment.Line.JLineNodePathse.ListView");

            return Node;
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "BusManagment.Line.JLineNodePathse");
            Node.MouseDBClickAction = new JAction("EditPath", "BusManagment.Line.PathForm.ShowDialog", null, new object[] { (int)pRow["Code"] });
            return Node;
            
            //AUTOMOBILE.Automobile.JAutomobileForm AForm = new Automobile.JAutomobileForm((int)pRow["Code"]);
            //AForm.ShowDialog();
            //return null;
        }
    }

    public class JLineNodePathse
    {

        public void ListView()
        {
            JSystem.Nodes.DataTable = GetDataTable();
            JSystem.Nodes.ObjectBase = new JAction("Path", "BusManagment.Line.JLineNodePathse.GetNode");

            JAction ActInsertAutombile = new JAction("Insert", "BusManagment.Line.PathForm.ShowDialog");
            
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
                DB.setQuery("select * from AUTPath");
                return DB.Query_DataTable();
            }
            catch(Exception ex)
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


    public class JPathPath
    {
        public JLineNodePath[] Nodes;
    }
}
