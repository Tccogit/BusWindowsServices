using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusManagment.WorkOrder
{
    public class JAUTVacation :JSystem
    {
        #region Properties
        public int Code { get; set; }
        /// <summary>
        /// کد راننده
        /// </summary>
        public int DriverPCode { get; set; }
        /// <summary>
        /// نوع مرخصی
        /// </summary>
        public int VacationType { get; set; }
        /// <summary>
        /// از تاریخ و ساعت
        /// </summary>
        public DateTime FromDate { get; set; }
        /// <summary>
        /// تا تاریخ وساعت
        /// </summary>
        public DateTime ToDate { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
        #endregion Properties

        public JAUTVacation()
        {
        }
        public JAUTVacation(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTVacation where code=" + pCode.ToString());
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

        public int Insert(bool isWebProject)
        {
            if (!JPermission.CheckPermission("BusManagment.WorkOrder.JAUTVacation.Insert"))
                return 0;
            JAUTVacationTable AT = new JAUTVacationTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            if (Code > 0)
                if (!isWebProject)
                    Nodes.DataTable.Merge(JAUTVacations.GetDataTable(Code));
            return Code;
        }

        public bool Update()
        {
            if (!JPermission.CheckPermission("BusManagment.WorkOrder.JAUTVacation.Update"))
                return false;
            JAUTVacationTable AT = new JAUTVacationTable();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                Nodes.Refreshdata(Nodes.CurrentNode, JAUTVacations.GetDataTable(Code).Rows[0]);
                return true;
            }
            else
                return false;
        }

        public bool Delete()
        {
            if (!JPermission.CheckPermission("BusManagment.WorkOrder.JAUTVacation.Delete"))
                return false;
             JAUTVacationTable AT = new JAUTVacationTable();
            AT.SetValueProperty(this);
            if (JMessages.Question("آیا میخواهید مرخصی انتخاب شده حذف شود؟", "") == System.Windows.Forms.DialogResult.Yes)
            {
                if (AT.Delete())
                {
                    Nodes.Delete(Nodes.CurrentNode);
                    return true;
                }
                else return false;
            }
            return false;
        }

        public static JNode GetTreeNode()
        {
            JNode Node = new JNode(0, 0);
            Node.Name = "RegisterVacation";
            Node.MouseClickAction = new JAction("Vacatrion", "BusManagment.WorkOrder.JAUTVacations.ListView");
            return Node;
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "BusManagment.WorkOrder.JTariff");
            Node.MouseDBClickAction = new JAction("EditFleet", "BusManagment.WorkOrder.JVacationForm.ShowDialog", null, new object[] { (int)pRow["Code"],0 });
            JAction DeleteItem = new JAction("Delete", "BusManagment.WorkOrder.JAUTVacation.Delete", null, new object[] { (int)pRow["Code"] });
            JAction NewItem = new JAction("New...", "BusManagment.WorkOrder.JVacationForm.ShowDialog", null, new object[] { });
            JAction EditItem = new JAction("Edit...", "BusManagment.WorkOrder.JVacationForm.ShowDialog", null, new object[] { (int)pRow["Code"],0 });
            Node.Popup.Insert(DeleteItem);
            Node.Popup.Insert(EditItem);
            Node.Popup.Insert(NewItem);
            return Node;
        }
    }

    public class JAUTVacations : JSystem
    {
        public static DataTable GetDataTable(int pCode = 0)
        {
            if (!JPermission.CheckPermission("BusManagment.WorkOrder.JAUTVacations.GetDataTable"))
                return null;
            JDataBase DB = new JDataBase();
            try
            {
                string query = @" Select AUTVacation.Code, DriverPCode, clsAllPerson .Name  , subdefine.name  VacationType
	                ,(Select Fa_date from StaticDates Where En_Date = CAST(FromDate As Date)) + ' - '+ CAST(CAST (FromDate As Time) AS varchar(5)) FromDate
	                ,(Select Fa_date from StaticDates Where En_Date = CAST(ToDate As Date)) + ' - '+ CAST(CAST (ToDate As Time) AS varchar(5)) ToDate
	                , Description 
	                from AUTVacation  
	                Inner Join clsAllPerson ON clsAllPerson .Code = AUTVacation .DriverPCode 
	                Inner Join subdefine  ON subdefine .Code = AUTVacation .VacationType  ";
                if (pCode > 0)
                    query += " WHERE AUTVacation.Code = " + pCode;
                DB.setQuery(query + " ORDER BY ToDate Desc "); 
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
            JSystem.Nodes.ObjectBase = new JAction("Vacation", "BusManagment.WorkOrder.JAUTVacation.GetNode");
            JAction ActInsertAutombile = new JAction("Insert", "BusManagment.WorkOrder.JVacationForm.ShowDialog");
            JToolbarNode InsertAutombile = new JToolbarNode();
            InsertAutombile.Click = ActInsertAutombile;
            InsertAutombile.Icon = JImageIndex.Add;
            JSystem.Nodes.AddToolbar(InsertAutombile);
        }
    }

}
