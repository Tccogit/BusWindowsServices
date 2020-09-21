using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
namespace BusManagment.BusEvent
{
    public class JBusEventRegister
    {
        public int Code { get; set; }
        public int BusEventDetailesCode { get; set; }
        public int BusCode { get; set; }
        public int DriverPCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int Status { get; set; }

        public int Insert(JDataBase db = null)
        {
            if (db == null)
                db = new JDataBase();
            BusEventRegisterTable AT = new BusEventRegisterTable();
            AT.IsView = true;
            AT.SetValueProperty(this);

            Code = AT.Insert(0, db, true);

            return Code;
        }


        public JBusEventRegister()
        {

        }

        public JBusEventRegister(int pCode)
        {
            this.GetData(pCode);
        }

        public bool Update()
        {
            ClassLibrary.JConnection C = new ClassLibrary.JConnection();
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase(C.GetConnection("Server02", 0));

            BusEventRegisterTable AT = new BusEventRegisterTable();
            AT.IsView = true;
            AT.SetValueProperty(this);
            return AT.Update(db);
        }

        public bool Delete()
        {
            BusEventRegisterTable AT = new BusEventRegisterTable();
            AT.IsView = true;
            AT.SetValueProperty(this);
            return AT.Delete();
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTBusEventRegister where code=" + pCode.ToString());
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

    public class JBusEventRegisters
    {
        public DataTable GetEvents()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@" select * from AUTBusEventRegister");
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

