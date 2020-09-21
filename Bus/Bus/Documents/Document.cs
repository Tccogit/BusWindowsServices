using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusManagment.Documents
{
    public class JAUTDocument : JSystem
    {
        #region Properties
        public int Code { get; set; }
        /// <summary>
        /// تاریخ صدور
        /// </summary>
        public DateTime IssueDate { get; set; }
        /// <summary>
        /// وضعیت
        /// </summary>
        public bool IsClosed { get; set; }
        /// <summary>
        /// عنوان ثبت کننده
        /// </summary>
        public string Register_Full_Title { get; set; }
        /// <summary>
        ///کد  پست سازمانی
        /// </summary>
        public int Register_Post_Code { get; set; }
        /// <summary>
        /// کد کاربری
        /// </summary>
        public int Register_User_Code { get; set; }
        /// <summary>
        /// شرح
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// همه تاریخ ها
        /// </summary>
        public bool AllDates { get; set; }

        /// <summary>
        /// شماره سند
        /// </summary>
        public int DocumentCode { get; set; }

        #endregion Properties

        public JAUTDocument()
        {
        }

        public JAUTDocument(JDataBase pDB, int pCode)
        {
            if (pCode > 0)
                this.GetData(pDB, pCode);
        }
        public int Insert(JDataBase pDB)
        {
            return Insert(pDB, false);
        }
        public int Insert(JDataBase pDB, bool isWebProject)
        {
            //if (!JPermission.CheckPermission("BusManagment.Documents.JAUTDocument.Insert"))
            //    return 0;
            JAUTDocumentTable AT = new JAUTDocumentTable();
            AT.SetValueProperty(this);
            Code = AT.Insert(pDB);
            if (Code > 0)
                if (!isWebProject)
                    Nodes.DataTable.Merge(JAUTDocuments.GetDataTable(pDB, Code));
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JAUTDocument", Code, 0, 0, 0, "ثبت سند", "", 0);
            return Code;
        }
        public bool Update(JDataBase pDB, bool isWebProject = false)
        {
            if (!JPermission.CheckPermission("BusManagment.Documents.JAUTDocument.Update"))
                return false;
            JAUTDocumentTable AT = new JAUTDocumentTable();
            AT.SetValueProperty(this);
            if (AT.Update(pDB))
            {
                if (!isWebProject)
                    Nodes.Refreshdata(Nodes.CurrentNode, JAUTDocuments.GetDataTable(pDB, Code).Rows[0]);
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("BusManagment.JAUTDocument", AT.Code, 0, 0, 0, "ویرایش سند", "", 0);
                return true;
            }
            else
                return false;
        }

        public bool Delete()
        {
            if (!JPermission.CheckPermission("BusManagment.Documents.JAUTDocument.Delete"))
                return false;
            JAUTDocumentTable AT = new JAUTDocumentTable();
            AT.SetValueProperty(this);
            if (AT.Delete())
            {
                Nodes.Delete(Nodes.CurrentNode);
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("BusManagment.JAUTDocument", AT.Code, 0, 0, 0, "حذف سند", "", 0);
                return true;
            }
            else return false;
        }

        public bool CascadeDelete(JDataBase db)
        {
            JAUTDocumentTable AT = new JAUTDocumentTable();
            AT.SetValueProperty(this);
            if (JAUTDocumentDetails.Delete(db, this.Code))
            {
                if (AT.Delete(db))
                {
                    ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                    jHistory.Save("BusManagment.JAUTDocument", AT.Code, 0, 0, 0, "حذف سند و جزئیات", "", 0);
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

        public bool DeleteDate()
        {
            JAUTDocumentTable AT = new JAUTDocumentTable();
            AT.SetValueProperty(this);
            if (AT.Delete())
            {
                Nodes.Delete(Nodes.CurrentNode);
                return true;
            }
            else return false;
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
                DB.setQuery("select * from AUTDocument where code=" + pCode.ToString());
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

        public static JNode GetTreeNode()
        {
            JNode Node = new JNode(0, 0);
            Node.Name = "CloseTransactions";
            Node.MouseClickAction = new JAction("CloseTransactions", "BusManagment.Documents.JAUTDocuments.ListView");
            return Node;
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "Documents.JAUTDocument");
            Node.MouseDBClickAction = new JAction("EditDocument", "BusManagment.Documents.JDocumentForm.ShowDialog", null, new object[] { (int)pRow["Code"] });
            JAction DeleteItem = new JAction("Delete", "BusManagment.Documents.JDocumentForm.Delete", null, new object[] { (int)pRow["Code"] });
            JAction NewItem = new JAction("New...", "BusManagment.Documents.JDocumentForm.ShowDialog", null, new object[] { 0 });
            JAction EditItem = new JAction("Edit...", "BusManagment.Documents.JDocumentForm.ShowDialog", null, new object[] { (int)pRow["Code"] });
            Node.Popup.Insert(DeleteItem);
            Node.Popup.Insert(EditItem);
            Node.Popup.Insert(NewItem);

            return Node;
        }
    }

    public class JAUTDocuments : JSystem
    {
        public void ListView()
        {
            JSystem.Nodes.DataTable = GetDataTable(null, 0);
            JSystem.Nodes.ObjectBase = new JAction("Bus", "BusManagment.Documents.JAUTDocument.GetNode");
            JAction ActInsertAutombile = new JAction("Insert", "BusManagment.Documents.JDocumentForm.ShowDialog");
            JToolbarNode InsertAutombile = new JToolbarNode();
            InsertAutombile.Click = ActInsertAutombile;
            InsertAutombile.Icon = JImageIndex.Add;
            JSystem.Nodes.AddToolbar(InsertAutombile);
        }


        public ClassLibrary.JNode[] TreeView()
        {
            JNode[] Node = new JNode[3];
            Node[0] = Documents.JAUTDocument.GetTreeNode();
            Node[1] = Documents.JAUTPayment.GetTreeNode();
            Node[2] = Documents.JAUTDocumentReport.GetTreeNode();

            return Node;
        }

        public static string GetWebQuery()
        {
            return @"Select 
		                ad.Code
		                ,ad.IssueDate 
		                ,ad.IsClosed,
		                REPLACE(convert(varchar,cast((SELECT SUM(Amount) * 10 FROM AUTDocumentDetail WHERE DocumentCode = ad.Code) as money),1),'.00','')Price
		                ,Description, ad.Register_Full_Title 
                        from AUTDocument ad";

        }

        public static int GetMaxDocumentCode()
        {
            string query = @" Select 
		                        Max(DocumentCode)MDC 
                                from AUTDocument ";
            JDataBase DB = new JDataBase();
            DB.setQuery(query);
            DataTable Dt = DB.Query_DataTable();
            int MaxDocumentCode = 0;
            try
            {
                MaxDocumentCode = Convert.ToInt32(Dt.Rows[0][0].ToString());
            }
            catch { }
            return MaxDocumentCode;
        }


        public static DataTable GetDataTable(JDataBase pDB, int pCode = 0)
        {
            JDataBase DB;
            if (pDB != null)
                DB = pDB;
            else
                DB = new JDataBase();
            try
            {
                string query = @" Select 
		                AUTDocument.Code
		                ,(Select Fa_Date FROM StaticDates WHERE En_Date = IssueDate ) IssueDate 
		                ,IsClosed, Description, Register_Full_Title 
                        from AUTDocument ";
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
