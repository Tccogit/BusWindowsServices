using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
namespace BusManagment.BusEvent
{
    public class JBusEventDetailes
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int BusEventCode { get; set; }

        public int Insert(JDataBase db = null)
        {
            JDataBase _db = db;
            if (db == null)
                _db = new JDataBase();
            try
            {
                _db.setQuery(@"
                        insert into [AUTBusEventDetailes] values
                        (
                        (select isnull(max(Code),0)+1 from [AUTBusEventDetailes] where code < 10000)
                        ,N'" + Name + @"'
                        ," + BusEventCode + @"
                        ,getdate()
                        )
                        select isnull(max(Code),0) from [AUTBusEventDetailes] where code < 10000
                        ");
                Code = (int)_db.Query_ExecutSacler();
            }
            finally
            {
                if (db == null)
                    _db.Dispose();
            }

            return Code;
        }

        public JBusEventDetailes()
        {

        }

        public JBusEventDetailes(int pCode)
        {
            this.GetData(pCode);
        }

        public bool Update()
        {
            BusEventDetailesTable AT = new BusEventDetailesTable();
            AT.SetValueProperty(this);
            return AT.Update();
        }

        public bool Delete()
        {
            BusEventDetailesTable AT = new BusEventDetailesTable();
            AT.SetValueProperty(this);
            return AT.Delete();
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTBusEventDetailes where code=" + pCode.ToString());
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
            Node.Name = "Price";
            Node.MouseClickAction = new JAction("Price", "BusManagment.BusEvent.JBusEvents.ListView");

            return Node;
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "BusManagment.BusEvent.JBusEvent");
            Node.MouseDBClickAction = new JAction("EditPrice", "BusManagment.Price.JBusEventForm.ShowDialog", null, new object[] { (int)pRow["Code"] });
            return Node;

            //AUTOMOBILE.Automobile.JAutomobileForm AForm = new Automobile.JAutomobileForm((int)pRow["Code"]);
            //AForm.ShowDialog();
            //return null;
        }
    }

    public class JBusEventDetailess
    {
        public DataTable GetEvents()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@" select * from AUTBusEventDetailes");
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

