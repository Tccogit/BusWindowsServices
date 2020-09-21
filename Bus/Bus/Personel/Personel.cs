using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusManagment.Personel
{
    public class JPersonel : JSystem
    {
        public int Code { get; set; }
        public int PersonCode { get; set; }
        public string CertificateNumber { get; set; }
        public DateTime CertificateDate { get; set; }
        public DateTime CertificateExpirationDate { get; set; }
        public int CertificateType { get; set; }
        public string PersonelCode { get; set; }
        public int Specification { get; set; }
        public int FleetCode { get; set; }
        public int EmployeeType { get; set; }

        public JPersonel()
        {
        }
        public JPersonel(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }

        public int Insert()
        {
            if (!JPermission.CheckPermission("BusManagment.Personel.JPersonel.Insert"))
                return 0;
            JPersonelTable AT = new JPersonelTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            if (Code > 0)
                Nodes.DataTable.Merge(JPersonels.GetDataTable(Code));
            return Code; 
        }

        public bool Update()
        {
            if (!JPermission.CheckPermission("BusManagment.Personel.JPersonel.Update"))
                return false;
            JPersonelTable AT = new JPersonelTable();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                Nodes.Refreshdata(Nodes.CurrentNode, JPersonels.GetDataTable(Code).Rows[0]);
                return true;
            }
            else
                return false;
        }

        public bool Delete()
        {
            if (!JPermission.CheckPermission("BusManagment.Personel.JPersonel.Delete"))
                return false;
            if (JMessages.Question("آیا میخواهید پرسنل انتخاب شده حذف شود؟", "") == System.Windows.Forms.DialogResult.Yes)
            {
                JPersonelTable AT = new JPersonelTable();
                AT.SetValueProperty(this);
                if (AT.Delete())
                {
                    Nodes.Delete(Nodes.CurrentNode);
                    return true;
                }
            }
            return false;
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTPersonel where code=" + pCode.ToString());
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
            Node.Name = "Personel";
            Node.MouseClickAction = new JAction("Personel", "BusManagment.Personel.JPersonels.ListView");

            return Node;
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "Personel.JPersonel");
            Node.MouseDBClickAction = new JAction("EditFleet", "BusManagment.Personel.JPersonelForm.ShowDialog", null, new object[] { (int)pRow["Code"] });
            JAction DeleteItem = new JAction("Delete", "BusManagment.Personel.JPersonel.Delete", null, new object[] { (int)pRow["Code"] });
            JAction EditItem = new JAction("Edit...", "BusManagment.Personel.JPersonelForm.ShowDialog", null, new object[] { (int)pRow["Code"] });
            JAction NewItem = new JAction("New...", "BusManagment.Personel.JPersonelForm.ShowDialog", null, new object[] { });
            Node.Popup.Insert(DeleteItem);
            Node.Popup.Insert(EditItem);
            Node.Popup.Insert(NewItem);

            return Node;
        }
    }

    public class JPersonels : JSystem
    {
        public void ListView()
        {
            JSystem.Nodes.DataTable = GetDataTable();
            JSystem.Nodes.ObjectBase = new JAction("Personel", "BusManagment.Personel.JPersonel.GetNode");
            JAction ActInsertAutombile = new JAction("Insert", "BusManagment.Personel.JPersonelForm.ShowDialog");
            JAction NewItem = new JAction("New...", "BusManagment.Personel.JPersonelForm.ShowDialog", null, new object[] { });

            JToolbarNode InsertAutombile = new JToolbarNode();
            InsertAutombile.Click = NewItem;
            InsertAutombile.Icon = JImageIndex.Add;

            JSystem.Nodes.AddToolbar(InsertAutombile);
        }

        public JNode[] TreeView()
        {
            return null;
        }

        public static string GetWebQuery()
        {
            return @"SELECT [AUTPersonel].[Code] 
                    , clsPerson.Fam+ ' - ' + clsPerson.Name AS Name
                  ,[AUTPersonel].[PersonCode]
                  ,[CertificateNumber]
                  ,(Select Fa_Date From StaticDates Where En_Date = [CertificateExpirationDate]) [CertificateExpirationDate]
                  ,(Select Fa_Date From StaticDates Where En_Date = [CertificateDate]) [CertificateDate]
                  ,subdefineCer.name [CertificateType]
                  ,[PersonelCode]
                  ,subdefineSpe.name Specification
                  ,AUTFleet.Name Fleet
                  ,subdefineEmp.name EmployeeType
              FROM [dbo].[AUTPersonel]
              Inner Join clsPerson ON [AUTPersonel].PersonCode = clsPerson .Code
              Left Join AUTFleet ON AUTFleet .Code = [AUTPersonel].FleetCode
              Left Join subdefine subdefineSpe on subdefineSpe .Code = [AUTPersonel].[Specification]
              Left Join subdefine subdefineEmp on subdefineEmp .Code = [AUTPersonel].[EmployeeType]
              Left Join subdefine subdefineCer on subdefineCer .Code = [AUTPersonel].[CertificateType] ";
        }

        public static DataTable GetDataTable(int pCode = 0)
        {
            if (!JPermission.CheckPermission("BusManagment.Personel.JPersonels.GetDataTable"))
                return null;
            JDataBase DB = new JDataBase();
            try
            {
                string query = @"SELECT [AUTPersonel].[Code] 
                    , clsPerson.Fam+ ' - ' + clsPerson.Name AS Name
                  ,[AUTPersonel].[PersonCode]
                  ,[CertificateNumber]
                  ,(Select Fa_Date From StaticDates Where En_Date = [CertificateExpirationDate]) [CertificateExpirationDate]
                  ,(Select Fa_Date From StaticDates Where En_Date = [CertificateDate]) [CertificateDate]
                  ,subdefineCer.name [CertificateType]
                  ,[PersonelCode]
                  ,subdefineSpe.name Specification
                  ,AUTFleet.Name Fleet
                  ,subdefineEmp.name EmployeeType
              FROM [dbo].[AUTPersonel]
              Inner Join clsPerson ON [AUTPersonel].PersonCode = clsPerson .Code
              Left Join AUTFleet ON AUTFleet .Code = [AUTPersonel].FleetCode
              Left Join subdefine subdefineSpe on subdefineSpe .Code = [AUTPersonel].[Specification]
              Left Join subdefine subdefineEmp on subdefineEmp .Code = [AUTPersonel].[EmployeeType]
              Left Join subdefine subdefineCer on subdefineCer .Code = [AUTPersonel].[CertificateType] ";
                if (pCode > 0)
                    query += " Where [AUTPersonel].Code = " + pCode;
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
    }
}
