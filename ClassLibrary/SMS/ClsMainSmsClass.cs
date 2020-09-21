using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml.Linq;
using System.ServiceModel;

namespace ClassLibrary.SMS
{
    public class ClsMainSmsClass
    {
        public static bool SendSms(JDataBase Db, string MessageStr, string Reciver, string ClassName, int ObjectCode = 0)
        {
            if (MessageStr == null | MessageStr == "" | MessageStr.Length == 0)
                return false;
            if (Reciver == null | Reciver == "" | Reciver.Length == 0)
                return false;
            if (ClassName == null | ClassName == "" | ClassName.Length == 0)
                return false;
            Db.setQuery(@"SELECT  [Code]
                                 ,[UrlFromat]
                                 ,[UserName]
                                 ,[PassWord]
                                 ,[Number]
                                 ,[ClassName]
                                 ,[ObjectCode]
                              FROM [SMSPanelSetting]
                              where [ClassName] = N'" + ClassName + @"'
                              and [ObjectCode] = " + ObjectCode);
            System.Data.DataTable Dt = Db.Query_DataTable();

            StringBuilder _StringBuilder = new StringBuilder();
            string[] ReciverMessage = Reciver.Split(',');
            if (Dt != null & Dt.Rows.Count > 0)
            {
                for (int i = 0; i < ReciverMessage.Length; i++)
                {

                    string url = Dt.Rows[0]["UrlFromat"].ToString().Replace("@UserName", Dt.Rows[0]["UserName"].ToString()).Replace("@Password", Dt.Rows[0]["PassWord"].ToString())
                    .Replace("@Message", MessageStr).Replace("@Reciver", ReciverMessage[i].ToString()).Replace("@Number", Dt.Rows[0]["Number"].ToString());

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    string StatusReponse = response.StatusCode.ToString();

                }
            }

            return true;
        }

        private static Dictionary<string, System.Data.DataRow> SMSPanelSetting = new Dictionary<string, System.Data.DataRow>();
        public static bool SendSmsWebService(JDataBase Db, string MessageStr, string Reciver, string ClassName, int ObjectCode, int pCode)
        {
            if (MessageStr == null | MessageStr == "" | MessageStr.Length == 0)
                return false;
            if (Reciver == null | Reciver == "" | Reciver.Length == 0)
                return false;
            if (ClassName == null | ClassName == "" | ClassName.Length == 0)
                return false;
            System.Data.DataRow DtRows = null;
            if (!SMSPanelSetting.TryGetValue(ClassName + ObjectCode, out DtRows))
            {
                Db.setQuery(@"SELECT top 1 [Code]
                                 ,[UrlFromat]
                                 ,[UserName]
                                 ,[PassWord]
                                 ,[Number]
                                 ,[ClassName]
                                 ,[ObjectCode]
                              FROM [SMSPanelSetting]
                              where [ClassName] = N'" + ClassName + @"'
                              and [ObjectCode] = " + ObjectCode);
                System.Data.DataTable Dt = Db.Query_DataTable();
                if (Dt != null & Dt.Rows.Count > 0)
                {
                    DtRows = Dt.Rows[0];
                    try
                    {
                        SMSPanelSetting.Add(ClassName + ObjectCode, DtRows);
                    }
                    catch { }
                }
                else
                    return false;
            }
            string[] ReciverMessage = Reciver.Split(',');
            for (int i = 0; i < ReciverMessage.Length; i++)
            {
                System.Threading.Thread SendSM = new System.Threading.Thread(SendSmsToWebSrviceThread);
                List<object> L = new List<object>();
                L.Add(DtRows);
                L.Add(MessageStr);
                L.Add(ReciverMessage[i]);
                L.Add(pCode);
                SendSM.Start(L);
            }
            return true;
        }

        public static void SendSmsToWebSrviceThread(object OParam)
        {
            try
            {
                List<object> L = (List<object>)OParam;
                System.Data.DataRow DtRows = (System.Data.DataRow)L[0];
                string MessageStr = (string)L[1];
                string ReciverMessage = (string)L[2];
                int code = (int)L[3];

                string url = DtRows["UrlFromat"].ToString().Replace("@UserName", DtRows["UserName"].ToString()).Replace("@Password", DtRows["PassWord"].ToString())
                .Replace("@Message", MessageStr).Replace("@Reciver", ReciverMessage).Replace("@Number", DtRows["Number"].ToString());

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                string StatusReponse = response.StatusCode.ToString();

                response.Close();
                JDataBase SendSMSDB = new JDataBase();
                try
                {
                    SendSMSDB.setQuery(@"update SMSSend set Send = '1',SendDate=getdate(),DeliveryDate=getdate() where Code = " + code);
                    SendSMSDB.Query_Execute();
                }
                finally
                {
                    SendSMSDB.Dispose();
                }
                System.Threading.Thread.Sleep(100);
            }
            catch (Exception ex)
            {

            }

        }

        public void SendSMSService()
        {
            bool res;
            ClassLibrary.JDataBase SendSMSDB = new JDataBase();
            try
            {
                SendSMSDB.setQuery(@"select SMSSend.Code,Mobile,Text,SMSPanelSetting.ClassName,SMSPanelSetting.ObjectCode from SMSSend left join SMSPanelSetting on isnull(SendDevice,1) = SMSPanelSetting.Code where SMSSend.Send = 0");
                System.Data.DataTable Dt = SendSMSDB.Query_DataTable();

                if (Dt != null)
                {
                    if (Dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < Dt.Rows.Count; i++)
                        {
                            try
                            {
                                SendSMSDB.setQuery(@"update SMSSend set Send = '2',SendDate=getdate(),DeliveryDate=getdate() where Code = " + Dt.Rows[i]["Code"].ToString());
                                SendSMSDB.Query_Execute();
                                res = SendSmsWebService(SendSMSDB, Dt.Rows[i]["Text"].ToString(), Dt.Rows[i]["Mobile"].ToString(), Dt.Rows[i]["ClassName"].ToString(), int.Parse(Dt.Rows[i]["ObjectCode"].ToString()),int.Parse(Dt.Rows[i]["Code"].ToString()));
                            }
                            catch
                            {
                                //SendSMSDB.setQuery(@"update SMSSend set Send = '2',SendDate=getdate(),DeliveryDate=getdate() where Code = " + Dt.Rows[i]["Code"].ToString());
                                //SendSMSDB.Query_Execute();
                            }
                        }
                    }
                }
            }
            finally
            {
                SendSMSDB.Dispose();
            }
        }
    }
}
