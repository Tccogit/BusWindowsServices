using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace ClassLibrary.SMS
{
    public class JSMSes
    {
        #region Constructor
        public JSMSes()
        {
        }
        public JSMSes(int code)
        {
            GetData(code);
        }
        #endregion

        #region Properties
        public int Code { get; set; }
        public string SMS_Text { get; set; }
        public int SMS_Type { get; set; }
        public int Register_User_Post_Code { get; set; }
        public int Register_User_Code { get; set; }
        public string Register_Full_Title { get; set; }
        public DateTime Register_Date_Time { get; set; }
        public int Send_User_Post_Code { get; set; }
        public int Send_User_Code { get; set; }
        public string Send_Full_Title { get; set; }
        public DateTime Send_Date_Time { get; set; }
        public string RecievedNumber { get; set; }
        public int TotalSentSMS { get; set; }
        public int Status { get; set; }
        #endregion

        #region Methods
        public void ReferShow(int pCode, int referCode)
        {
            GetData(pCode);
            if (SMS_Type == Domains.JClassLibrary.JSMSType.SendSMS)
                (new SMSForm(pCode, referCode)).ShowDialog();
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "ClassLibrary.SMS.JSMSes");
            Node.Name = pRow["SMS_Text"].ToString();
            Node.Icone = JImageIndex.Default.GetHashCode();
            //اکشن ویرایش
            JAction editAction = new JAction();

            if (pRow != null)
                editAction = new JAction("edit...", "ClassLibrary.SMS.SMSForm.ShowDialog", null, new object[] { Node.Code });

            //اکشن حذف
            JAction deleteaction = new JAction("Delete...", "ClassLibrary.SMS.JSMSes.DeleteSMS", new object[] { Node.Code }, null);
            Node.DeleteClickAction = deleteaction;
            //اکشن جدید
            JAction newAction = new JAction("پیام کوتاه جدید...", "ClassLibrary.SMS.JSMSess.ShowNewSMSForm", null, null);
            Node.MouseDBClickAction = editAction;

            JPopupMenu pMenu = new JPopupMenu("ClassLibrary.SMS.JSMSess", Node.Code);

            pMenu.Insert(editAction);
            pMenu.Insert(deleteaction);
            pMenu.Insert(newAction);
            Node.Popup = pMenu;
            return Node;

        }

        public void DeleteSMS(int code)
        {
            JSMSes jSMSes = new JSMSes(code);
            string classname = SMSForm._ConstClassName;

            DataTable dt = (new Automation.JARefer()).FindReferByObjectcode(code, classname);

            if (dt != null)
                if (dt.Rows.Count > 0 && CanDeleteSMSCompletely())
                {
                    if (JMessages.Question("برای این اس ام اس " + dt.Rows.Count.ToString() + " ارجاع وجود دارد، آیا مطمئن هستید؟", "حذف") == DialogResult.Yes)
                    {
                        (new Automation.JARefer()).DeleteObjectAndRefers(classname, 0, code);
                        jSMSes.Delete();
                        JSMSesDetailss.DeleteAll(code, null);
                        //ArchivedDocuments.JArchiveDocument jArchDoc = new ArchivedDocuments.JArchiveDocument();
                        //jArchDoc.DeleteArchive(classname, code, true);
                        JSystem.Nodes.Delete(JSystem.Nodes.CurrentNode);
                    }
                    return;
                }
                else if (dt.Rows.Count > 0)
                {
                    JMessages.Error("اس ام اس ارجاع داده شده قابل حذف نیست.", "حذف");
                    return;
                }

            if (JMessages.Question("آیا از حذف این آیتم مطمئن هستید؟", "حذف") == DialogResult.Yes)
            {
                jSMSes.Delete();
                JSMSesDetailss.DeleteAll(code, null);
                //ArchivedDocuments.JArchiveDocument jArchDoc = new ArchivedDocuments.JArchiveDocument();
                //jArchDoc.DeleteArchive(classname, code, true);
                JSystem.Nodes.Delete(JSystem.Nodes.CurrentNode);
            }

        }
        public bool CanDeleteSMSCompletely()
        {
            if (JPermission.CheckPermission("ClassLibrary.SMS.JSMSes.CanDeleteSMSCompletely"))
                return true;
            return false;
        }


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
                JSMSesTable jSMSesTable = new JSMSesTable();
                jSMSesTable.SetValueProperty(this);
                return jSMSesTable.Insert(_db);
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
                JSMSesTable jSMSesTable = new JSMSesTable();
                jSMSesTable.SetValueProperty(this);
                return jSMSesTable.Update(_db);
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
                db.setQuery("Delete From SMSes Where Code=" + Code);
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
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from SMSes where Code=" + code + "";
                Db.setQuery(Query);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, Db.DataReader);
                    return;
                }
                else
                {
                    return;
                }
            }
            finally
            {
                Db.Dispose();
            }
        }

        public DataTable GetDataTable(int code)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from SMSes where Code=" + code + "";
                Db.setQuery(Query);
                return Db.Query_DataTable();
            }
            finally
            {
                Db.Dispose();
            }
        }

        public DataTable SMSDetailsForView
        {
            get
            {
                JDataBase Db = new JDataBase();
                try
                {
                    string Query = @"select SMSesDetails.Code , PersonCode, isnull(clsAllPerson.Name, N'ناشناس') PersonName, SMSesDetails.Mobile, '-' as Status from SMSesDetails
                                        left join clsAllPerson on clsAllPerson.Code = SMSesDetails.PersonCode
                                        where SMSesDetails.SMS_Code = " + Code;
                    Db.setQuery(Query);
                    return Db.Query_DataTable();
                }
                finally
                {
                    Db.Dispose();
                }
            }
        }

        public DataTable SMSDetails
        {
            get
            {
                return JSMSesDetailss.GetDataTable(Code);
            }
        }
        #endregion
    }

    public class JSMSess
    {
        public void ShowNewSMSForm()
        {
            (new SMSForm()).ShowDialog();
            JSystem.Nodes.RefreshDataTable();
        }

        public static JNode GetNode()
        {
            JNode Node = new JNode(0, "ClassLibrary.SMS.JSMSess");
            Node.Name = "SMS";

            JAction Ac = new JAction("SMSForm", "ClassLibrary.SMS.JSMSess.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }


        public void ListView()
        {
            JSystem.Nodes.ObjectBase = new JAction("GetSMS", "ClassLibrary.SMS.JSMSes.GetNode");
            JSystem.Nodes.DataTable = GetDataTable();

            JAction newAction = new JAction("New...", "ClassLibrary.SMS.JSMSess.ShowNewSMSForm", null, null);

            JToolbarNode TN = new JToolbarNode();
            TN.Icon = JImageIndex.Add;
            TN.Hint = "SMS جدید...";
            TN.Click = newAction;
            JSystem.Nodes.AddToolbar(TN);
        }

        public DataTable GetDataTable()
        {
            return GetDataTable("");
        }
        public DataTable GetDataTable(string where)
        {
            JDataBase db = new JDataBase();
            try
            {
                string query = @"select Code,(select Fa_Date from StaticDates where En_Date = CAST(Send_Date_Time as date)) as Send_Date_Time, SMS_Text, Register_Full_Title, Send_Full_Title,(select Fa_Date from StaticDates where En_Date = CAST(Register_Date_Time as date)) as Register_Date_Time , CASE Status When 0 THEN N'ارسال نشده' WHEN 1 THEN N'ارسال شده' END as Status from SMSes where Register_User_Post_Code = " + JMainFrame.CurrentPostCode + " OR Send_User_Post_Code = " + JMainFrame.CurrentPostCode;
                db.setQuery("Select tbl.* From (" + query + ") tbl Order By tbl.Register_Date_Time desc");
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public static int GetTotalSMS_Day(int year, int month, int day, int PostCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                string query = @"Select isnull(Sum(TotalSentSMS), 0) From SMSes Where Status = 1 AND Send_User_Post_Code = " + JMainFrame.CurrentPostCode
                    + " AND YEAR(Send_Date_Time)= " + year + " and MONTH(Send_Date_Time) = " + month + " and DAY(Send_Date_Time) = " + day;
                db.setQuery(query);
                DataTable DT = db.Query_DataTable();
                return DT.Rows.Count > 0 ? Convert.ToInt32(DT.Rows[0][0]) : 0;
            }
            finally
            {
                db.Dispose();
            }
        }
        public static int GetTotalSMS_Month(int year, int month, int PostCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                string query = @"Select isnull(Sum(TotalSentSMS), 0) From SMSes Where Status = 1 AND Send_User_Post_Code = " + JMainFrame.CurrentPostCode
                    + " AND YEAR(Send_Date_Time)= " + year + " and MONTH(Send_Date_Time) = " + month;
                db.setQuery(query);
                DataTable DT = db.Query_DataTable();
                return DT.Rows.Count > 0 ? Convert.ToInt32(DT.Rows[0][0]) : 0;
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
