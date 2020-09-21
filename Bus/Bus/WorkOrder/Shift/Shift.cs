using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusManagment.WorkOrder
{
    public class JShift : JSystem
    {
        #region Properties
        public int Code { get; set; }
        /// <summary>
        /// عنوان
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// زمان شروع
        /// </summary>
        public TimeSpan StartTime { get; set; }
        /// <summary>
        /// زمان پایان
        /// </summary>
        public TimeSpan EndTime { get; set; }
        #endregion Properties

        public JShift()
        {
        }

        public JShift( int pCode)
        {
            if (pCode > 0)
                this.GetData( pCode);
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTShift where code=" + pCode.ToString());
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

        public int Insert( bool isWebProject)
        {
            //if (!JPermission.CheckPermission("BusManagment.WorkOrder.JShift.Insert"))
            //    return 0;
            JShiftTable AT = new JShiftTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            if (Code > 0)
                if (!isWebProject)
                    Nodes.DataTable.Merge(JShifts.GetDataTable(Code));
            return Code;
        }

        public bool Update()
        {
            //if (!JPermission.CheckPermission("BusManagment.WorkOrder.JShift.Update"))
            //    return false;
            JShiftTable AT = new JShiftTable();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                Nodes.Refreshdata(Nodes.CurrentNode, JShifts.GetDataTable(Code).Rows[0]);
                return true;
            }
            else
                return false;
        }

        public bool Delete()
        {
            if (!JPermission.CheckPermission("BusManagment.WorkOrder.JShift.Delete"))
                return false; 
            if (CheckUsedInTariff())
            {
                JMessages.Error("این شیفت در احکام کار استفاده شده است و قابل حذف نیست.", "");
                return false;
            }
            JShiftTable AT = new JShiftTable();
            AT.SetValueProperty(this);
            if (JMessages.Question("آیا میخواهید شیفت انتخاب شده حذف شود؟", "") == System.Windows.Forms.DialogResult.Yes)
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

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "BusManagment.WorkOrder.JShift");
            Node.MouseDBClickAction = new JAction("EditFleet", "BusManagment.WorkOrder.JShiftForm.ShowDialog", null, new object[] { (int)pRow["Code"] });
            JAction DeleteItem = new JAction("Delete", "BusManagment.WorkOrder.JShift.Delete", null, new object[] { (int)pRow["Code"] });
            JAction NewItem = new JAction("New...", "BusManagment.WorkOrder.JShiftForm.ShowDialog", null, new object[] { });
            JAction EditItem = new JAction("Edit...", "BusManagment.WorkOrder.JShiftForm.ShowDialog", null, new object[] { (int)pRow["Code"] });
            Node.Popup.Insert(DeleteItem);
            Node.Popup.Insert(EditItem);
            Node.Popup.Insert(NewItem);
            return Node;
        }

        public static JNode GetTreeNode()
        {
            JNode Node = new JNode(0, 0);
            Node.Name = "Shifts";
            Node.MouseClickAction = new JAction("Shifts", "BusManagment.WorkOrder.JShifts.ListView");
            return Node;
        }
        /// <summary>
        /// چک میکند این شیفت در تعرفه ها استفاده شده یا نه
        /// </summary>
        /// <returns></returns>
        public bool CheckUsedInTariff()
        {
            return JTariffs.GetDataTable(0, this.Code).Rows.Count > 0;
        }
    }

    public class JShifts  :JSystem
    {
        public static DataTable GetDataTable(int pCode =0)
        {
            //if (!JPermission.CheckPermission("BusManagment.WorkOrder.JShifts.GetDataTable"))
            //    return null;
            JDataBase DB = new JDataBase();
            try
            {
                string query = @" Select * from AUTShift  ";
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

        public void ListView()
        {
            JSystem.Nodes.DataTable = GetDataTable(0);
            JSystem.Nodes.ObjectBase = new JAction("Shift", "BusManagment.WorkOrder.JShift.GetNode");
            JAction ActInsertAutombile = new JAction("Insert", "BusManagment.WorkOrder.JShiftForm.ShowDialog");
            JToolbarNode InsertAutombile = new JToolbarNode();
            InsertAutombile.Click = ActInsertAutombile;
            InsertAutombile.Icon = JImageIndex.Add;
            JSystem.Nodes.AddToolbar(InsertAutombile);
        }
    }
}
