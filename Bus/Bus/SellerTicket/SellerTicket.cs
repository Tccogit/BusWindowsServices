using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace BusManagment.SellerTicket
{
    public class JSellerTicket : JSystem
    {
        #region Properties
        public int Code { get; set; }
        public string Adress { get; set; }
        public string Tel { get; set; }
        public int Type { get; set; }
        public int StationCode { get; set; }//  نام ایستگاه
        public decimal longs { get; set; }//  طول جغرافیایی
        public decimal lat { get; set; }//    عرض جغرافیایی
        #endregion Properties

        public JSellerTicket()
        {
        }
        public JSellerTicket(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }

        public int Insert(bool isWeb = false)
        {
            if (!JPermission.CheckPermission("BusManagment.SellerTicket.JSellerTicket.Insert"))
                return 0;
            JSellerTicketTable AT = new JSellerTicketTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            if (Code > 0 && !isWeb)
                Nodes.DataTable.Merge(JSellerTickets.GetDataTable(Code));
            return Code;
        }
        public bool Update(bool isWeb = false)
        {
            if (!JPermission.CheckPermission("BusManagment.SellerTicket.JSellerTicket.Update"))
                return false;
            JSellerTicketTable AT = new JSellerTicketTable();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                if (!isWeb)
                    Nodes.Refreshdata(Nodes.CurrentNode, JSellerTickets.GetDataTable(Code).Rows[0]);
                return true;
            }
            else
                return false;
        }

        public bool Delete(bool isWeb = false)
        {
            if (!JPermission.CheckPermission("BusManagment.SellerTicket.JSellerTicket.Delete"))
                return false;
            JSellerTicketTable AT = new JSellerTicketTable();
            AT.SetValueProperty(this);
            if (AT.Delete())
            {
                if (!isWeb)
                    Nodes.Delete(Nodes.CurrentNode);
                return true;
            }
            else return false;
        }
        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTSellerTicket where code=" + pCode.ToString());
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
            Node.Name = "SellerTickets";
            Node.MouseClickAction = new JAction("SellerTicket", "BusManagment.SellerTicket.JSellerTickets.ListView");

            return Node;
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "SellerTicket.JSellerTicket");

            JAction DeleteItem = new JAction("Delete", "BusManagment.SellerTicket.SellerForm.Delete", null, new object[] { (int)pRow["Code"] });
            JAction EditItem = new JAction("Edit...", "BusManagment.SellerTicket.SellerForm.ShowDialog", null, new object[] { (int)pRow["Code"] });
            JAction NewItem = new JAction("New...", "BusManagment.SellerTicket.SellerForm.ShowDialog", null, new object[] { });
            Node.MouseDBClickAction = EditItem;
            Node.Popup.Insert(DeleteItem);
            Node.Popup.Insert(EditItem);
            Node.Popup.Insert(NewItem);

            return Node;

        }
    }

    public class JSellerTickets : JSystem
    {

        public static void DeleteBySellerTicketCode(int pSellerCode, JDataBase DB)
        {
            DB.setQuery(@" Delete from AUTSeller  WHERE Code_sellerTicket = " + pSellerCode.ToString());
            DB.Query_Execute();
        }

        public void ListView()
        {
            JSystem.Nodes.DataTable = GetDataTable();
            JSystem.Nodes.ObjectBase = new JAction("Seller", "BusManagment.SellerTicket.JSellerTicket.GetNode");

            JAction ActInsertAutombile = new JAction("Insert", "BusManagment.SellerTicket.SellerForm.ShowDialog");

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
            return @"select AUTSellerTicket.Code 
                    , AUTSellerTicket.Adress Address
                    , AUTSellerTicket.Tel
                    , subdefine .name Type
                    , AUTStation.Name  StationName
                    , AUTSellerTicket.longs, AUTSellerTicket.lat 
					, AUTZone .Name ZoneName
                      from AUTSellerTicket 
                      left Join AUTStation ON AUTSellerTicket.StationCode = AUTStation.Code
					  left join AUTZone on AUTZone . Code = AUTStation . ZoneCode 
                      Left Join subdefine on AUTSellerTicket.Type = subdefine.Code";
        }

        public static DataTable GetDataTable(int pCode = 0)
        {
            if (!JPermission.CheckPermission("BusManagment.SellerTicket.JSellerTickets.GetDataTable"))
                return null;
            JDataBase DB = new JDataBase();
            try
            {

                string query = @" select AUTSellerTicket.Code 
                    , AUTSellerTicket.Adress Address
                    , AUTSellerTicket.Tel
                    , subdefine .name Type
                    , AUTStation.Name  StationName
                    , AUTSellerTicket.longs, AUTSellerTicket.lat 
					, AUTZone .Name ZoneName
                      from AUTSellerTicket 
                      left Join AUTStation ON AUTSellerTicket.StationCode = AUTStation.Code
					  left join AUTZone on AUTZone . Code = AUTStation . ZoneCode 
                      Left Join subdefine on AUTSellerTicket.Type = subdefine.Code  ";
                if (pCode > 0)
                    query += " WHERE AUTSellerTicket.Code = " + pCode;
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
