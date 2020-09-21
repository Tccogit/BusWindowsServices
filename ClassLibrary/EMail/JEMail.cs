using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary.EMail
{
    public class JEMail
    {
        #region Constructor
        public JEMail()
        {
        }
        public JEMail(int pCode)
        {
            GetData(pCode);
        }
        #endregion

        #region Properties
        public int Code { get; set; }
        public int UserCode { get; set; }
        public int UserPostCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ServerName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool AutoSync { get; set; }
        #endregion

        #region Methods
        public int Insert()
        {
            return Insert(null);
        }
        public int Insert(JDataBase db)
        {
            JDataBase _db = null;
            try
            {
                if (db == null) _db = new JDataBase();
                else _db = db;
                JEMailTable jEMailTable = new JEMailTable();
                jEMailTable.SetValueProperty(this);
                return jEMailTable.Insert(_db);
            }
            finally
            {
                if (db == null)
                    _db.Dispose();
            }
        }
        public bool Update()
        {
            return Update(null);
        }
        public bool Update(JDataBase db)
        {
            JDataBase _db;
            if (db == null) _db = new JDataBase();
            else _db = db;
            try
            {
                JEMailTable jEMailTable = new JEMailTable();
                jEMailTable.SetValueProperty(this);
                return jEMailTable.Update(_db);
            }
            finally
            {
                if (db == null) _db.Dispose();
            }
        }

        public bool Delete()
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Delete From Email Where Code=" + Code);
                return db.Query_Execute() >= 0 ? true : false;
            }
            finally
            {
                db.Dispose();
            }
        }

        #endregion

        #region GetData
        public void GetData(int code)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("SELECT * FROM EMail Where Code = '" + code + "'");
                db.Query_DataReader();
                if (db.DataReader.Read())
                    JTable.SetToClassProperty(this, db.DataReader);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "ClassLibrary.EMail.JEMails");
            Node.Name = pRow["Subject"].ToString();
            Node.Icone = JImageIndex.Default.GetHashCode();
            //اکشن ویرایش
            JAction editAction = new JAction();

            if (pRow != null)
                editAction = new JAction("Edit...", "ClassLibrary.EMail.JEMails.ShowSendForm", new object[] { Node.Code }, null);

            //اکشن حذف
            JAction deleteaction = new JAction("Delete...", "ClassLibrary.EMails.JEMail.DeleteEMail", new object[] { Node.Code }, null);
            Node.DeleteClickAction = deleteaction;
            //اکشن جدید
            JAction newAction = new JAction("ایمیل جدید...", "ClassLibrary.EMail.JEMails.ShowNewSMSForm", null, null);
            Node.MouseDBClickAction = editAction;

            JPopupMenu pMenu = new JPopupMenu("ClassLibrary.EMail.JEMails", Node.Code);

            pMenu.Insert(editAction);
            pMenu.Insert(deleteaction);
            pMenu.Insert(newAction);
            Node.Popup = pMenu;
            return Node;

        }
        #endregion

    }

    public class JEMails
    {
        public void ShowNewSMSForm()
        {
            (new EmailSendForm()).ShowDialog();
            JSystem.Nodes.RefreshDataTable();
        }

        public void ShowSendForm(int code)
        {
            (new EmailSendForm(code)).ShowDialog();
        }

        public static JNode GetNode()
        {
            JNode Node = new JNode(0, "ClassLibrary.EMail.JEMails");
            Node.Name = "EMail";

            JAction Ac = new JAction("EMailSendForm", "ClassLibrary.EMail.JEMails.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }


        public void ListView()
        {
            JSystem.Nodes.ObjectBase = new JAction("GetEMail", "ClassLibrary.EMail.JEMail.GetNode");
            JSystem.Nodes.DataTable = JEMailSends.GetCustomeDataTable("Register_Post_Code=" + JMainFrame.CurrentPostCode);

            JAction newAction = new JAction("New...", "ClassLibrary.EMail.JEMails.ShowNewSMSForm", null, null);

            JToolbarNode TN = new JToolbarNode();
            TN.Icon = JImageIndex.Add;
            TN.Hint = "ایمیل جدید...";
            TN.Click = newAction;
            JSystem.Nodes.AddToolbar(TN);
        }

        public void DeleteEMail(int code)
        {
            JEMailSend jEMailSend = new JEMailSend(code);
            string classname = EmailSendForm._ConstClassName;

            DataTable dt = (new Automation.JARefer()).FindReferByObjectcode(code, classname);

            if (dt != null)
                if (dt.Rows.Count > 0 && CanDeleteEMailCompletely())
                {
                    if (JMessages.Question("برای این ایمیل " + dt.Rows.Count.ToString() + " ارجاع وجود دارد، آیا مطمئن هستید؟", "حذف") == DialogResult.Yes)
                    {
                        (new Automation.JARefer()).DeleteObjectAndRefers(classname, 0, code);
                        jEMailSend.Delete();
                        ArchivedDocuments.JArchiveDocument jArchDoc = new ArchivedDocuments.JArchiveDocument();
                        jArchDoc.DeleteArchive(classname, code, true);
                        JSystem.Nodes.Delete(JSystem.Nodes.CurrentNode);
                    }
                    return;
                }
                else if (dt.Rows.Count > 0)
                {
                    JMessages.Error("ایمیل ارجاع داده شده قابل حذف نیست.", "حذف");
                    return;
                }

            if (JMessages.Question("آیا از حذف این آیتم مطمئن هستید؟", "حذف") == DialogResult.Yes)
            {
                jEMailSend.Delete();
                //ArchivedDocuments.JArchiveDocument jArchDoc = new ArchivedDocuments.JArchiveDocument();
                //jArchDoc.DeleteArchive(classname, code, true);
                JSystem.Nodes.Delete(JSystem.Nodes.CurrentNode);
            }

        }
        public bool CanDeleteEMailCompletely()
        {
            if (JPermission.CheckPermission("ClassLibrary.EMail.JEMails.CanDeleteEMailCompletely"))
                return true;
            return false;
        }

        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int userCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Select * from Email" + (userCode > 0 ? " Where UserCode=" + userCode.ToString() : ""));
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

    }
}
