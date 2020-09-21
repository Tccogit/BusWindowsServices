using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ClassLibrary.EMail
{
    public class JEMailSend
    {
        #region Constructor
        public JEMailSend()
        {
        }
        public JEMailSend(int code)
        {
            GetData(code);
        }
        #endregion

        #region Properties
        public int Code { get; set; }
        public int EmailCode { get; set; }
        public int Parent_EmailCode { get; set; }
        public int Sender_User_Code { get; set; }
        public int Sender_Post_Code { get; set; }
        public string Sender_Full_Title { get; set; }
        public int Register_User_Code { get; set; }
        public int Register_Post_Code { get; set; }
        public string Register_Full_Title { get; set; }
        public DateTime Register_Date { get; set; }
        public string Subject { get; set; }
        public string MessageFrom { get; set; }
        public string MessageTo { get; set; }
        public string CC { get; set; }
        public string BCC { get; set; }
        public string Text { get; set; }
        public string HTML { get; set; }
        public DateTime DateSent { get; set; }
        public int Status { get; set; }
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
                JEMailSendTable jEMailSend = new JEMailSendTable();
                jEMailSend.SetValueProperty(this);
                jEMailSend.Set_ComplexInsert(false);
                return jEMailSend.Insert(_db);
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
                JEMailSendTable jEMailSend = new JEMailSendTable();
                jEMailSend.SetValueProperty(this);
                return jEMailSend.Update(_db);
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
                db.setQuery("SELECT * FROM EMailSend Where Code = '" + code + "'");
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

        public void ReferShow(int pCode, int referCode)
        {
            (new EmailSendForm(pCode, referCode)).ShowDialog();
        }

    }

    public class JEMailSends
    {
        public static DataTable GetCustomeDataTable(string where)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("SELECT * FROM EMailSend " + (where.Length > 0 ? "Where " + where : ""));
                return db.Query_DataTable();

            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
