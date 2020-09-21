using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusManagment.Documents
{
    public class JAUTPayment : JSystem
    {
        #region Properties
        public int Code{get;set;}
        public DateTime PaymentDate{get;set;}
        public string Description{get;set;}
        public string Register_Full_Title{get;set;}
        public int Register_Post_Code{get;set;}
        public int Register_User_Code{get;set;}
        #endregion Properties

        public JAUTPayment(JDataBase pDB, int pCode)
        {
            if (pCode > 0)
                this.GetData(pDB, pCode);
        }

        public JAUTPayment( int pCode)
        {
            if (pCode > 0)
                this.GetData(null, pCode);
        }

        public JAUTPayment()
        {
        }

        public bool GetData(JDataBase pDB, int pCode)
        {
            JDataBase DB;
            if (pDB != null)
                DB = pDB;
            else
                DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTPayment where code=" + pCode.ToString());
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
                if (pDB == null)
                    DB.Dispose();
            }
        }

        public int Insert(JDataBase pDB, bool isWebProject)
        {
            //if (!JPermission.CheckPermission("BusManagment.Documents.JAUTPayment.Insert"))
             //   return 0;
           
            JAUTPaymentTable AT = new JAUTPaymentTable();
            AT.SetValueProperty(this);
            Code = AT.Insert(pDB);
            if (Code > 0)
                if (!isWebProject)
                    Nodes.DataTable.Merge(JAUTPayments.GetDataTable(pDB, Code));
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JAUTPayment", Code, 0, 0, 0, "ثبت سند پرداخت", "", 0);
            return Code;
        }

        public bool Update(JDataBase pDB)
        {
            JAUTPaymentTable AT = new JAUTPaymentTable();
            AT.SetValueProperty(this);
            if (AT.Update(pDB))
            {
                Nodes.Refreshdata(Nodes.CurrentNode, JAUTPayments.GetDataTable(pDB, Code).Rows[0]);
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("BusManagment.JAUTPayment", AT.Code, 0, 0, 0, "ویرایش سند پرداخت", "", 0);
                return true;
            }
            else
                return false;
        }

        public bool Delete()
        {
            JAUTPaymentTable AT = new JAUTPaymentTable();
            AT.SetValueProperty(this);
            if (AT.Delete())
            {
                Nodes.Delete(Nodes.CurrentNode);
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("BusManagment.JAUTPayment", AT.Code, 0, 0, 0, "حذف سند پرداخت", "", 0);
                return true;
            }
            else return false;
        }

        public bool CascadeDelete(JDataBase db)
        {
            BusManagment.Documents.JAUTDocument document1 = new BusManagment.Documents.JAUTDocument();
            document1.Code = 400000000 + Code;
            {
                if (document1.CascadeDelete(db))
                {
                    BusManagment.Documents.JAUTDocument document2 = new BusManagment.Documents.JAUTDocument();
                    document2.Code = 700000000 + Code;
                    {
                        if (document1.CascadeDelete(db))
                        {
                            JAUTPaymentTable AT = new JAUTPaymentTable();
                            AT.SetValueProperty(this);
                            if (JAUTPaymentDetails.Delete(db, this.Code))
                            {
                                if (AT.Delete(db))
                                {
                                    ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                                    jHistory.Save("BusManagment.JAUTPayment", AT.Code, 0, 0, 0, "حذف سند پرداخت و جزئیات", "", 0);
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public static JNode GetTreeNode()
        {
            JNode Node = new JNode(0, 0);
            Node.Name = "Payments";
            Node.MouseClickAction = new JAction("Payments", "BusManagment.Documents.JAUTPayments.ListView");
            return Node;
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "Documents.JAUTPayment");
            Node.MouseDBClickAction = new JAction("Edit...", "BusManagment.Documents.JPaymentForm.ShowDialog", null, new object[] { (int)pRow["Code"] });
            //JAction DeleteItem = new JAction("Delete", "BusManagment.Documents.JPaymentForm.Delete", null, new object[] { (int)pRow["Code"] });
            JAction NewItem = new JAction("New...", "BusManagment.Documents.JPaymentForm.ShowDialog", null, new object[] { 0 });
            JAction EditItem = new JAction("Edit...", "BusManagment.Documents.JPaymentForm.ShowDialog", null, new object[] { (int)pRow["Code"] });
            //Node.Popup.Insert(DeleteItem);
            Node.Popup.Insert(EditItem);
            Node.Popup.Insert(NewItem);

            return Node;
        }
    }

    public class JAUTPayments : JSystem
    {
        public void ListView()
        {
            JSystem.Nodes.DataTable = GetDataTable(null, 0);
            JSystem.Nodes.ObjectBase = new JAction("Bus", "BusManagment.Documents.JAUTPayment.GetNode");
            JAction actInsert = new JAction("Insert", "BusManagment.Documents.JPaymentForm.ShowDialog");
            JToolbarNode nodeInsert = new JToolbarNode();
            nodeInsert.Click = actInsert;
            nodeInsert.Icon = JImageIndex.Add;
            JSystem.Nodes.AddToolbar(nodeInsert);
        }

        public ClassLibrary.JNode[] TreeView()
        {
            JNode[] Node = new JNode[2];
            Node[0] = Documents.JAUTPayment.GetTreeNode();

            return Node;
        }

        public static string GetWebQuery()
        {
            return @" Select 
		                ap.Code
		                ,ap.PaymentDate as PaymentDate 
		                , ap.Description, 
                        REPLACE(convert(varchar,cast((SELECT SUM(PaymentPrice) * 10 FROM AUTPaymentDetail WHERE PaymentCode = ap.Code) as money),1),'.00','')Price
		                ,ap.Register_Full_Title 
                        from AUTPayment ap ";

        }

        public static DataTable GetDataTable(JDataBase pDB, int pCode = 0)
        {
            //if (!JPermission.CheckPermission("BusManagment.Documents.JAUTPayments.GetDataTable"))
             //   return null;
            JDataBase DB;
            if (pDB != null)
                DB = pDB;
            else
                DB = new JDataBase();
            try
            {
                string query = @" Select 
		                AUTPayment.Code
		                ,PaymentDate
		                , Description, Register_Full_Title 
                        from AUTPayment ";
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
                if (pDB == null)
                    DB.Dispose();
            }
        }
    }
}
