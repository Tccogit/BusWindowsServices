using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassLibrary.SMS
{
    public class JSMSesDetails
    {
        #region Constructor
        public JSMSesDetails()
        {
        }
        public JSMSesDetails(int code)
        {
            GetData(code);
        }
        #endregion

        #region Properties
        public int Code { get; set; }
        public int SMS_Code { get; set; }
        public int PersonCode { get; set; }
        public string Mobile { get; set; }
        public int SMSSendCode { get; set; }
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
                JSMSesDetailsTable jSMSesDetailsTable = new JSMSesDetailsTable();
                jSMSesDetailsTable.SetValueProperty(this);
                jSMSesDetailsTable.Set_ComplexInsert(false);
                return jSMSesDetailsTable.Insert(0, _db, false);
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
                JSMSesDetailsTable jSMSesDetailsTable = new JSMSesDetailsTable();
                jSMSesDetailsTable.SetValueProperty(this);
                return jSMSesDetailsTable.Update(_db);
            }
            finally
            {
                if (db == null) _db.Dispose();
            }
        }

        public int Delete()
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Delete From SMSesDetails Where Code = " + Code);
                return db.Query_Execute();
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
        #endregion
    }

    public class JSMSesDetailss
    {
        public static DataTable GetDataTable(int SMSesCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Select * From SMSesDetails Where SMS_Code = " + SMSesCode);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }

        }

        public static DataTable GetDataTableForView(int SMSesCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Select PersonCode, isnull(clsAllPerson.Name, N'ناشناس') PersonName, SMSesDetails.Mobile From SMSesDetails inner join clsAllPerson on clsAllPerson.Code = SMSesDetails.PersonCode Where SMS_Code = " + SMSesCode);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }

        }

        public static void DeleteAll(int SMSesCode, JDataBase db)
        {
            JDataBase _db;
            if (db == null) _db = new JDataBase();
            else _db = db;
            try
            {
                _db.setQuery("Delete From SMSesDetails Where SMS_Code = " + SMSesCode);
                _db.Query_Execute();
            }
            finally
            {
                if (db == null) _db.Dispose();
            }
        }
        public static void SetSMSSendCodeToSMS(int SMSesCode, int SMSSendCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Update SMSesDetails SET SMSSendCode = " + SMSSendCode + " Where SMS_Code = " + SMSesCode);
                db.Query_Execute();
            }
            finally
            {
                db.Dispose();
            }
        }

        public static string InsertQuery(string sms_code, string personCode, string mobile, string smsSendCode)
        {
            return "INSERT INTO SMSesDetails(Code, SMS_Code, PersonCode, Mobile, SMSSendCode)VALUES((Select MAX(Code)+1 From SMSesDetails)," + sms_code + "," + personCode + ",'" + mobile + "'," + smsSendCode + ") ";
        }

        public static int SaveRange(DataTable _DT, string SMS_Code)
        {
            if (_DT.Rows.Count > 2000)
            {
                if (JMessages.Question("تعداد شماره ها " + _DT.Rows.Count.ToString() + " می باشد و ممکن است کمی زمان ببرد. آیا تمایل به ادامه عملیات دارید؟", "افزودن شماره") != System.Windows.Forms.DialogResult.Yes) return 0;
            }
            // Saving Details
            JDataBase db = new JDataBase();
            try
            {
                string insertQuery = "";
                int i = 0;
                foreach (DataRow item in _DT.Rows)
                {
                    i++;
                    insertQuery += JSMSesDetailss.InsertQuery(SMS_Code, item["PersonCode"].ToString(), item["Mobile"].ToString(), "0");
                    if (i >= 1000)
                    {
                        db.setQuery(insertQuery);
                        db.Query_Execute();
                        insertQuery = "";
                        i = 0;
                    }

                }
                if (insertQuery != "")
                {
                    db.setQuery(insertQuery);
                    db.Query_Execute();
                }
                return 1;
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
