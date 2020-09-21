using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
namespace BusManagment.BusEvent
{
    public class JBusEventPlace
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int BusEventDetailesCode { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int Radius { get; set; }

        public int Insert(JDataBase db = null)
        {
            BusEventPalceTable AT = new BusEventPalceTable();
            AT.SetValueProperty(this);
            if (db == null)
                Code = AT.Insert();
            else
                Code = AT.Insert(db);

            return Code;
        }

        public JBusEventPlace()
        {

        }

        public JBusEventPlace(int pCode)
        {
            this.GetData(pCode);
        }

        public bool Update()
        {
            BusEventPalceTable AT = new BusEventPalceTable();
            AT.SetValueProperty(this);
            return AT.Update();
        }

        public bool Delete()
        {
            BusEventPalceTable AT = new BusEventPalceTable();
            AT.SetValueProperty(this);
            return AT.Delete();
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTBusEventPlace where code=" + pCode.ToString());
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

    public class JBusEventPlaces
    {
        public DataTable GetEvents()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@" select * from AUTBusEventPlace");
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

