using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ClassLibrary.EMail
{
    public class JEMailReceived
    {
        public JEMailReceived()
        {
        }
        public JEMailReceived(int code)
        {
            GetData(code);
        }

        #region Properties
        public int Code { get; set; }
        public int EmailCode { get; set; }
        public string UID { get; set; }
        public string Subject { get; set; }
        public string MessageFrom { get; set; }
        public string MessageTo { get; set; }
        public string CC { get; set; }
        public string BCC { get; set; }
        public string Text { get; set; }
        public string HTML { get; set; }
        public DateTime DateSent { get; set; }
        public int Status { get; set; }
        public int Relevant_Person_Code { get; set; }
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
                JEMailReceivedTable jEMailReceivedTable = new JEMailReceivedTable();
                jEMailReceivedTable.Set_ComplexInsert(false);
                jEMailReceivedTable.SetValueProperty(this);
                return jEMailReceivedTable.Insert(_db);
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
                JEMailReceivedTable jEMailReceivedTable = new JEMailReceivedTable();
                jEMailReceivedTable.SetValueProperty(this);
                return jEMailReceivedTable.Update(_db);
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
                db.setQuery("Delete From EMailReceived Where Code=" + Code);
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
                db.setQuery("SELECT * FROM EMailReceived Where Code = '" + code + "'");
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
        #endregion
    }

    public class JEMailReceiveds
    {
        public static bool isEmailInDB(string uid, int emailCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Select * From EMailReceived Where UID = '" + uid + "' and EmailCode = " + emailCode.ToString());
                DataTable DT = db.Query_DataTable();
                if (DT != null && DT.Rows.Count > 0) return true;
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        public static DataTable GetUnProccessedEmails()
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Select * From EMailReceived Where Status=0");
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public static DataTable GetCustomDataTable(string where)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Select * From EMailReceived " + (where.Trim().Length > 0 ? "Where " + where : ""));
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public static void ChangeStatusToProccessed(int code)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Update EMailReceived Set Status = 1 Where Code=" + code);
                db.Query_Execute();
            }
            finally
            {
                db.Dispose();
            }
        }

        public static int GetRelevantPerson(string email)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("select PCode from clsPersonAddress where LOWER(Email) = LOWER('" + email + "')");
                DataTable dt = db.Query_DataTable();
                if (dt != null && dt.Rows.Count > 0)
                    return Convert.ToInt32(dt.Rows[0][0]);
                return 0;
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
