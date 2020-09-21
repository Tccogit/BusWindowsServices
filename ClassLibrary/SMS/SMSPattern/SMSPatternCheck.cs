using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using Automation;

namespace ClassLibrary.SMS
{
    public class JSMSPatternCheck_WF
    {
        public void ReferShow(int pCode, int referCode)
        {
            SMSReceivedForm smsReceivedForm = new SMSReceivedForm(pCode, referCode);
            smsReceivedForm.ShowDialog();
        }
    }
    public class JSMSPatternCheck
    {
        public const string _ConstClassName_SQL = "ClassLibrary.SMS.JSMSPatternCheck_SQL"; // SQL Query
        public const string _ConstClassName_STR = "ClassLibrary.SMS.JSMSPatternCheck_STR"; // Fixed String
        public const string _ConstClassName_WF = "ClassLibrary.SMS.JSMSPatternCheck_WF";   // WorkFlow

        public void CheckSMSes()
        {
            try
            {
                DataTable SMSes = JSMSesReceiveds.GetDataTable(true);
                DataTable Patterns = JSMSPatterns.GetDataTable();
                foreach (DataRow sms in SMSes.Rows)
                {
                    foreach (DataRow smsPattern in Patterns.Rows)
                    {
                        // Validate Received Number
                        if (ValidateNumbers(smsPattern["WhiteList"].ToString(), sms["Sender_Number"].ToString(), true) == true
                         && ValidateNumbers(smsPattern["BlackList"].ToString(), sms["Sender_Number"].ToString(), false) == false)
                        {
                            // Validate Pattern
                            if (ValidatePattern(sms["SMS_Text"].ToString(), smsPattern["Pattern"].ToString()) == true)
                            {
                                // Change SMS Status
                                sms["Status"] = 1;
                                if (UpdateSMSStatus(Convert.ToInt32(sms["Code"]), 1))
                                {
                                    // Temporary DataTable For Using in SQL, Method and WorkFlow
                                    DataTable temp = SMSes.Clone();
                                    temp.Columns.Add("Len_SMS_Text");
                                    temp.Columns.Add("Trim_SMS_Text");
                                    temp.Columns.Add("Trim_Len_SMS_Text");
                                    temp.Columns.Add("NoSpace_SMS_Text");
                                    temp.Columns.Add("NoSpace_Len_SMS_Text");
                                    temp.Columns.Add("LastSendTime");
                                    temp.Columns.Add("PatternCode");
                                    DataRow dr = temp.NewRow();
                                    dr["Code"] = sms["Code"];
                                    dr["SMS_Text"] = sms["SMS_Text"];
                                    dr["Sender_Number"] = sms["Sender_Number"];
                                    dr["Sender_PersonCode"] = sms["Sender_PersonCode"];
                                    dr["Sender_Full_Title"] = sms["Sender_Full_Title"];
                                    dr["Send_Date"] = sms["Send_Date"];
                                    dr["Service_Read_Date"] = sms["Service_Read_Date"];
                                    dr["Status"] = sms["Status"];
                                    dr["Len_SMS_Text"] = sms["SMS_Text"].ToString().Length;
                                    dr["Trim_SMS_Text"] = sms["SMS_Text"].ToString().Trim();
                                    dr["Trim_Len_SMS_Text"] = sms["SMS_Text"].ToString().Trim().Length;
                                    dr["NoSpace_SMS_Text"] = sms["SMS_Text"].ToString().Replace(" ", "");
                                    dr["NoSpace_Len_SMS_Text"] = sms["SMS_Text"].ToString().Replace(" ", "").Length;
                                    string timeLimit = String.Format("{0:0}", GetLastSendTime(Convert.ToInt32(smsPattern["Code"]), sms["Sender_Number"].ToString()));
                                    dr["LastSendTime"] = Convert.ToInt64(timeLimit);
                                    dr["PatternCode"] = smsPattern["Code"];
                                    temp.Rows.Add(dr);

                                    // Get Results And Add To Temp DataTable
                                    string[] results = GetResults(sms["SMS_Text"].ToString(), smsPattern["Pattern"].ToString());
                                    if (results != null)
                                        for (int i = 0; i < results.Length; i++)
                                        {
                                            string colName = "_R" + i.ToString();
                                            temp.Columns.Add(colName);
                                            temp.Rows[0][colName] = results[i];
                                        }
                                    // Actions
                                    DoAction(sms, smsPattern, temp);
                                    break;
                                }
                            }
                        }
                    }

                    // No Pattern Mode
                    if (Convert.ToInt32(sms["Status"]) == 0)
                    {
                        foreach (DataRow smsPattern in JSMSPatterns.GetNullPatterns().Rows)
                        {
                            // Validate Received Number
                            if (ValidateNumbers(smsPattern["WhiteList"].ToString(), sms["Sender_Number"].ToString(), true) == true
                             && ValidateNumbers(smsPattern["BlackList"].ToString(), sms["Sender_Number"].ToString(), false) == false)
                            {
                                // Change SMS Status
                                sms["Status"] = 1;
                                if (UpdateSMSStatus(Convert.ToInt32(sms["Code"]), 1))
                                {
                                    // Temporary DataTable For Using in SQL, Method and WorkFlow
                                    DataTable temp = SMSes.Clone();
                                    temp.Columns.Add("Len_SMS_Text");
                                    temp.Columns.Add("Trim_SMS_Text");
                                    temp.Columns.Add("Trim_Len_SMS_Text");
                                    temp.Columns.Add("NoSpace_SMS_Text");
                                    temp.Columns.Add("NoSpace_Len_SMS_Text");
                                    temp.Columns.Add("LastSendTime");
                                    temp.Columns.Add("PatternCode");
                                    DataRow dr = temp.NewRow();
                                    dr["Code"] = sms["Code"];
                                    dr["SMS_Text"] = sms["SMS_Text"];
                                    dr["Sender_Number"] = sms["Sender_Number"];
                                    dr["Sender_PersonCode"] = sms["Sender_PersonCode"];
                                    dr["Sender_Full_Title"] = sms["Sender_Full_Title"];
                                    dr["Send_Date"] = sms["Send_Date"];
                                    dr["Service_Read_Date"] = sms["Service_Read_Date"];
                                    dr["Status"] = sms["Status"];
                                    dr["Len_SMS_Text"] = sms["SMS_Text"].ToString().Length;
                                    dr["Trim_SMS_Text"] = sms["SMS_Text"].ToString().Trim();
                                    dr["Trim_Len_SMS_Text"] = sms["SMS_Text"].ToString().Trim().Length;
                                    dr["NoSpace_SMS_Text"] = sms["SMS_Text"].ToString().Replace(" ", "");
                                    dr["NoSpace_Len_SMS_Text"] = sms["SMS_Text"].ToString().Replace(" ", "").Length;
                                    string timeLimit = String.Format("{0:0}", GetLastSendTime(Convert.ToInt32(smsPattern["Code"]), sms["Sender_Number"].ToString()));
                                    dr["LastSendTime"] = Convert.ToInt64(timeLimit);
                                    dr["PatternCode"] = smsPattern["Code"];
                                    temp.Rows.Add(dr);

                                    // Actions
                                    DoAction(sms, smsPattern, temp);

                                }
                            }
                        }
                    }

                    if (Convert.ToInt32(sms["Status"]) == 0)
                    {
                        UpdateSMSStatus(Convert.ToInt32(sms["Code"]), 2);

                    }
                }
            }
            catch (Exception ex) { }
        }

        public void DoAction(DataRow sms, DataRow smsPattern, DataTable temp)
        {
            switch (Convert.ToInt32(smsPattern["Type"]))
            {
                case 0: // SQL
                    // Check Time Limitation
                    if (CheckTimeLimit(Convert.ToInt32(smsPattern["Code"]), sms["Sender_Number"].ToString(), Convert.ToInt64(smsPattern["TimeLimit"])) == true)
                    {
                        SendSQLSMS(smsPattern, sms, temp, _ConstClassName_SQL);
                    }
                    break;
                case 1: // Method
                    JAction jAction = new JAction("SMSAction", smsPattern["Action"].ToString(), new object[] { temp }, null);
                    jAction.run();
                    break;
                case 2: // WorkFlow
                    foreach (string item in smsPattern["Action"].ToString().Split(','))
                    {
                        try
                        {
                            SendToWrokFlow(Convert.ToInt32(item), _ConstClassName_WF, Convert.ToInt32(smsPattern["Code"]), temp);
                        }
                        catch { }
                    }

                    break;
                case 3: // Fixed String
                    // Check Time Limitation
                    if (CheckTimeLimit(Convert.ToInt32(smsPattern["Code"]), sms["Sender_Number"].ToString(), Convert.ToInt64(smsPattern["TimeLimit"])) == true)
                    {
                        SendSQLSMS(smsPattern, sms, temp, _ConstClassName_STR);
                    }
                    break;
            }
        }

        public bool UpdateSMSStatus(int code, int status)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Update SMSesReceived SET Status=" + status + " Where Code = " + code);
                if (db.Query_Execute() >= 0)
                    return true;
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool ValidateNumbers(string numbers, string num, bool EmptyDefaultValue)
        {
            if (numbers.Trim().Length == 0) return EmptyDefaultValue;
            string[] numarray = numbers.Split(',');
            foreach (string item in numarray)
            {
                if (item == num)
                    return true;
            }
            return false;
        }

        public bool ValidatePattern(string inputString, string pattern)
        {
            try
            {
                Match match = Regex.Match(inputString.Replace("‎", ""), pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                if (match.Success) return true;
            }
            catch
            {
            }
            return false;
        }

        public string[] GetResults(string inputString, string pattern)
        {
            try
            {
                List<string> results = new List<string>();
                Match match = Regex.Match(inputString.Replace("‎", ""), pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                if (match.Success)
                    foreach (Capture item in match.Groups)
                        results.Add(item.Value);
                return results.ToArray();
            }
            catch
            {
            }
            return null;
        }

        public bool CheckTimeLimit(int patternCode, string number, long timeLimit)
        {
            DataTable DT = JSMSSends.GetDataTable("[Description] = N'PC" + patternCode + "N" + number + "' and ClassName = N'" + _ConstClassName_SQL + "'  order by RegDate desc");
            if (DT.Rows.Count == 0 || DT.Rows[0]["RegDate"] == null) return true;
            DateTime LastSendMessageDate = Convert.ToDateTime(DT.Rows[0]["RegDate"]);
            TimeSpan timeSpan = new TimeSpan(JDateTime.Now().Ticks);
            timeSpan = timeSpan.Subtract(new TimeSpan(LastSendMessageDate.Ticks));
            if (Math.Round(timeSpan.TotalMinutes) >= timeLimit) return true;

            return false;
        }

        public double GetLastSendTime(int patternCode, string number)
        {
            DataTable DT = JSMSSends.GetDataTable("[Description] = N'PC" + patternCode + "N" + number + "' and ClassName = N'" + _ConstClassName_SQL + "'  order by RegDate desc");
            if (DT.Rows.Count == 0 || DT.Rows[0]["RegDate"] == null) return 999999999;
            DateTime LastSendMessageDate = Convert.ToDateTime(DT.Rows[0]["RegDate"]);
            TimeSpan timeSpan = new TimeSpan(JDateTime.Now().Ticks);
            timeSpan = timeSpan.Subtract(new TimeSpan(LastSendMessageDate.Ticks));
            return Math.Round(timeSpan.TotalMinutes);

            return 0;
        }

        public void SendSQLSMS(DataRow smsPattern, DataRow sms, DataTable temp, string _ClassName)
        {
            JDataBase db = new JDataBase();
            try
            {
                string message = smsPattern["Action"].ToString();
                if (_ClassName == _ConstClassName_SQL)
                {
                    string query = message;
                    foreach (DataColumn column in temp.Columns)
                        query = query.Replace("@" + column.ColumnName, temp.Rows[0][column.ColumnName].ToString().Replace("'", "''"));
                    db.setQuery(query);

                    DataTable query_result = db.Query_DataTable();

                    if (query_result.Rows.Count > 0)
                    {
                        message = query_result.Rows[0][0].ToString();
                    }
                    else
                        return;
                }
                JSMSSend jSMSSend = new JSMSSend();
                jSMSSend.Mobile = sms["Sender_Number"].ToString();
                jSMSSend.Text = message;
                jSMSSend.Send = 0;
                jSMSSend.RegDate = JDateTime.Now();
                jSMSSend.Description = "PC" + smsPattern["Code"].ToString() + "N" + sms["Sender_Number"].ToString();
                jSMSSend.Project = "ERP";
                jSMSSend.ClassName = _ClassName;
                jSMSSend.ObjectCode = Convert.ToInt32(sms["Code"]);
                jSMSSend.SendDevice = Convert.ToInt32(JSMSSendType.WebService);
                jSMSSend.Insert(db, true);
            }
            finally
            {
                db.Dispose();
            }

        }

        public void SendToWrokFlow(int _workFlowCode, string _ClassName, int _DynamicClassCode, DataTable _PublicDataRow)
        {
            int _ReferCode = 0;
            JWorkFlow StartWorkFlow = new JWorkFlow(_PublicDataRow, _ReferCode);
            StartWorkFlow.GetData(_workFlowCode, _ClassName, _DynamicClassCode);
            foreach (JWorkFlow WorkFlow in StartWorkFlow.GetNextNodes())
            {

                if (WorkFlow.NodeType == JNodeType.Employment)
                {
                    DataTable posts = WorkFlow.GetPosts();
                    List<string> Recivers = new List<string>();
                    for (int i = 0; i < posts.Rows.Count; i++)
                    {
                        Recivers.AddRange(posts.Rows[i]["Code"].ToString().Split(';'));
                    }

                    JDataBase db = new JDataBase();
                    try
                    {
                        foreach (string Reciver in Recivers)
                        {
                            int d;
                            if (int.TryParse(Reciver, out d))
                            {
                                int _ObjectCode = Convert.ToInt32(_PublicDataRow.Rows[0]["Code"]); // SMS Code
                                string _title = "پیام کوتاه دریافتی";
                                string _full_title = _PublicDataRow.Rows[0]["Sender_Full_Title"] + " (" + _PublicDataRow.Rows[0]["Sender_Number"] + ")";

                                Employment.JEOrganizationChart jeoc = new Employment.JEOrganizationChart(d);

                                Automation.JARefer tmprefer = new Automation.JARefer();
                                tmprefer.send_date_time = JDateTime.Now();

                                tmprefer.sender_code = 0;
                                tmprefer.sender_full_title = _full_title;
                                tmprefer.sender_post_code = 0;
                                tmprefer.receiver_code = Convert.ToInt32(jeoc.user_code);
                                tmprefer.receiver_full_title = jeoc.full_Name;
                                tmprefer.receiver_post_code = d;
                                tmprefer.register_user_code = 0;
                                tmprefer.register_Date_Time = JDateTime.Now();
                                tmprefer.status = ClassLibrary.Domains.JAutomation.JReferStatus.Current;
                                tmprefer.is_active = true;
                                tmprefer.ReferGroup = 1;
                                tmprefer.parent_code = 0;
                                tmprefer.description = "";
                                tmprefer.WorkFlowCode = WorkFlow.Code;

                                tmprefer.object_code = tmprefer.SendToAutomation(_ObjectCode,
                                                                                "", _title, _ClassName, _DynamicClassCode, db,
                                                                                _full_title, 0,
                                                                                0, false, true);
                                if (tmprefer.Send(db, true, true) > 0)
                                {
                                    WorkFlow.RUNSQL();
                                    WorkFlow.RUNACTION();
                                }
                                else
                                {
                                    // Error
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        JSystem.Except.AddException(ex);
                    }
                }
            }
        }

        public void AddLog(string Log)
        {
            string path = @"C:\ERP\SMSServiceLogFile.txt";
            System.IO.File.AppendAllText(path, "\r\n" + DateTime.Now.ToString() + " - " + Log);

        }
    }
}
