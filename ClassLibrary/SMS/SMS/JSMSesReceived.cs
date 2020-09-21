using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassLibrary.SMS
{
    public class JSMSesReceived
    {
        #region Constructor
        public JSMSesReceived()
        {
            Sender_Full_Title = "";
        }
        public JSMSesReceived(int code)
        {
            Sender_Full_Title = "";
            GetData(code);
        }

        #endregion

        #region Properties
        public int Code { get; set; }
        public string SMS_Text { get; set; }
        public string Sender_Number { get; set; }
        public int Sender_PersonCode { get; set; }
        public string Sender_Full_Title { get; set; }
        public DateTime Send_Date { get; set; }
        public DateTime Service_Read_Date { get; set; }
        public int Status { get; set; }

        #endregion

        #region Methods
        public bool Update()
        {
            JDataBase db = new JDataBase();
            try
            {
                JSMSesReceivedTable jSMSesReceivedTable = new JSMSesReceivedTable();
                jSMSesReceivedTable.SetValueProperty(this);
                if (jSMSesReceivedTable.Update(db))
                    return true;
                else
                    return false;
            }
            finally
            {
                db.Dispose();
            }
        }
        public int Insert()
        {
            JDataBase db = new JDataBase();
            try
            {
                JSMSesReceivedTable jSMSesReceivedTable = new JSMSesReceivedTable();
                jSMSesReceivedTable.SetValueProperty(this);
                return jSMSesReceivedTable.Insert(db);
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
                db.setQuery("SELECT * FROM SMSesReceived Where Code = '" + code + "'");
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

    public class JSMSesReceiveds
    {
        public static DataTable GetDataTable()
        {
            return GetDataTable(false);
        }
        public static DataTable GetDataTable(bool getNew)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Select * From SMSesReceived" + (getNew == true ? " Where Status = 0" : ""));
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
                db.setQuery("Select * From SMSesReceived Where " + where);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public static DataTable GetRecentMessage(string number)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(@"select SMSesReceived.Code, Sender_Number Mobile,SMS_Text Question, (select top 1 SMSSend.Text from SMSSend where SMSSend.Description = 'QuickSMS' and ClassName = 'ClassLibrary.SMS.SMSReceivedForm' and SMSSend.ObjectCode = SMSesReceived.Code) Answer,Sender_Full_Title, Send_Date from SMSesReceived where Code in
                            (select ObjectCode from Objects where ClassName = 'ClassLibrary.SMS.JSMSPatternCheck_WF' and DynamicClassCode = 1) and SMSesReceived.Sender_Number = '" + number + "'");
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public static DataTable GetReplies(int ReceivedSMSCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("select * from SMSSend where ClassName='ClassLibrary.SMS.SMSReceivedForm' and Description = 'QuickSMS' and ObjectCode=" + ReceivedSMSCode.ToString() + " order by RegDate desc");
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
