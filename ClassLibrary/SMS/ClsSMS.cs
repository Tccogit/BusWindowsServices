using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using AxMmCtlLib;
using System.Net;
using System.IO;

namespace ClassLibrary
{
    /// <summary>
    /// روشهای ارسال اس ام اس
    /// </summary>
    public enum JSMSSendType
    {
        GSM = 1,
        WebService = 2
    }
    public class JClsSMS : JSystem
    {
        //private Gsm objGsm;
        //private SmsConstants objSmsConstants;

        //private frmSendOptions objFrmSendOptions;
        //private frmDataWap objFrmDataWap;
        //private frmGsmReceiveOptions objFrmGsmReceiveOptions;

        public System.Windows.Forms.ListView lvReceivedMessages;
        public System.Windows.Forms.ListView lvSentMessages;

        ///////////
        #region Properties
        
        public string PortName { set; get; }
        public int iFlowControl { set; get; }
        public string StrDeviceSpeed { set; get; }
        public string Pincode { set; get; }
        public string StrError { set; get; }

        public int DeviceSpeed;
        #endregion
        ////////////////
        /// <summary>
        /// 
        /// </summary>
        public JClsSMS(bool pService)
        {
            //objGsm = new GsmClass();
            //objSmsConstants = new SmsConstantsClass();
        }
        /// <summary>
        /// 
        /// </summary>
        public JClsSMS()
        {
            //objGsm = new GsmClass();
            //objSmsConstants = new SmsConstantsClass();

            //Display Mobile Messaging Toolkit Info
            //lblInfo.Text = String.Format("Mobile Messaging Toolkit {0}; Build: {1}; Module: {2}", objGsm.Version, objGsm.Build, objGsm.Module);

            //objFrmDataWap = new frmDataWap();
            //objFrmGsmReceiveOptions = new frmGsmReceiveOptions();
            //objFrmSendOptions = new frmSendOptions();
        }

        private void UpdateResult(int nResult)
        {
            //StrError = string.Format("{0}: {1}", nResult, objGsm.GetErrorDescription(objGsm.LastError));
        }

		//public System.Windows.Forms.ListView ReceiveSMS()
		//{
		//	int nFormat;
		//	SmsMessage objSmsMessage;
		//	GsmDeliveryReport objDeliveryReport;
		//	lvReceivedMessages = new System.Windows.Forms.ListView() ;
		//	lvSentMessages = new System.Windows.Forms.ListView();

		//	if (!int.TryParse(StrDeviceSpeed, out DeviceSpeed))
		//	{
		//		DeviceSpeed = 0;
		//	}

		//	// Opens the COM-Port to the GSM modem.
		//	objGsm.Open(PortName, Pincode, iFlowControl, DeviceSpeed);
		//	UpdateResult(objGsm.LastError);

		//	// Checks if PIN is valid, or required.
		//	if (objGsm.LastError == 36101)
		//	{   // 36101 means: Invalid Pin entered. See also www.activexperts.com/support/errorcodes
		//		JMessages.Error("Invalid Pin entered: SIM card can be blocked after a number of false attempts in a row.", "");
		//		return null;
		//	}

		//	int iType = objSmsConstants.GSM_MESSAGESTATE_ALL;
		//	bool bDelete = false;// objFrmGsmReceiveOptions.DeleteAfterReceive;
		//	int iStorageType = 1;// objFrmGsmReceiveOptions.MessageStorage;

		//	if (objGsm.LastError == 0)
		//	{
		//		// Gets all the SMS Messages from the GSM modem that are unread.
		//		objGsm.Receive(iType, bDelete, iStorageType, 10000);
		//	}

		//	UpdateResult(objGsm.LastError);

		//	if (objGsm.LastError != 0)
		//	{
		//		// Closes the GSM Modem                
		//		objGsm.Close();
		//		return null; ;
		//	}

		//	// Gets the first SMS Message
		//	//objSmsMessage = (SmsMessage)objGsm.GetFirstSms();

		//	while (objGsm.LastError == 0)
		//	{
		//		System.Windows.Forms.ListViewItem item;
		//		//nFormat = objSmsMessage.BodyFormat;

		//		//if (objSmsMessage.BodyFormat != objSmsConstants.BODYFORMAT_TEXT)
		//		//{
		//		//	item = new System.Windows.Forms.ListViewItem(new string[] { DateTime.Now.ToShortTimeString(), objSmsMessage.FromAddress, objSmsMessage.Body });
		//		//}
		//		//else
		//		//{
		//		//	item = new System.Windows.Forms.ListViewItem(new string[] { DateTime.Now.ToShortTimeString(), objSmsMessage.FromAddress, "<DATA>" });
		//		//}


		//		//lvReceivedMessages.Items.Insert(0, item);

		//		// Gets the next SMS Message
		//		//objSmsMessage = (SmsMessage)objGsm.GetNextSms();
		//	}

		//	// Gets the first Delivery Report
		//	//objDeliveryReport = (GsmDeliveryReport)objGsm.GetFirstReport();
		//	int nSMSMessagesCompletedCount = 0;
		//	List<string> lsReferences;

		//	while (objGsm.LastError == 0)
		//	{
		//		foreach (System.Windows.Forms.ListViewItem item in lvSentMessages.Items)
		//		{
		//			lsReferences = (List<string>)item.Tag;
		//			for (int i = 0; i < lsReferences.Count; i++)
		//			{
		//				//if (lsReferences[i] == objDeliveryReport.Reference)
		//				//{
		//				//	// Delete found delivery report from SIM card.
		//				//	object objDlv = objDeliveryReport;
		//				//	objGsm.DeleteReport(ref objDlv);

		//				//	// Check if the status of the delivery report is failed.
		//				//	if (objDeliveryReport.Status != objSmsConstants.GSM_STATUS_MESSAGE_DELIVERED_SUCCESSFULLY)
		//				//	{
		//				//		// This part of the message has been failed.
		//				//		// The whole SMS Message is compromised and therefor considered to be failed.
		//				//		// Replace the current list in the items tag to an empty list so the program will not
		//				//		// look for delivery reports again for this specific SMS Message.                               
		//				//		item.Tag = new List<string>();
		//				//		item.SubItems[3].Text = "Sent (delivery failed)";
		//				//		nSMSMessagesCompletedCount++;

		//				//		// We need to break this for loop now since we do not want
		//				//		// to let the program check if the list is empty and put the status on Sent (delivered).
		//				//		break;
		//				//	}

		//					// Remove current delivery report from the deliveryreport list
		//					// of this SMS Message
		//					//lsReferences.Remove(objDeliveryReport.Reference);
		//					//item.Tag = lsReferences;

		//					// If the list of references is empty then all the delivery reports are received.
		//					// Since we checked in the if statement above if the message status was not Delivered successfully.
		//					// We can assume here that the status is Delivered successfully.
		//					if (lsReferences.Count == 0)
		//					{
		//						item.SubItems[3].Text = "Sent (delivered)";
		//						nSMSMessagesCompletedCount++;
		//					}

		//					break;
		//				}
		//			}
		//		}

		//		// Gets the next Delivery Report
		//		//objDeliveryReport = (GsmDeliveryReport)objGsm.GetNextReport();
		//	//}

		//	if (nSMSMessagesCompletedCount != 0)
		//	{
		//		//JMessages.Information(string.Format("{0} Delivery Report(s) received. Please check the \"Sent Messages\" view for status updates.", nSMSMessagesCompletedCount), 
		//		 //   string.Format("{0} Delivery Report(s) received", nSMSMessagesCompletedCount), "");
		//		JMessages.Information(string.Format("{0} Delivery Report(s) received. Please check the \"Sent Messages\" view for status updates.", nSMSMessagesCompletedCount),"");
		//	}

		//	// Closes the GSM Modem
		//	objGsm.Close();
		//	return lvReceivedMessages;
		//}

		//public bool SendSMS(string Recipient, string Message, string BodyType)
		//{
		//	object obj;
		//	string strMessageReference;
		//	//SmsMessage objSmsMessage = new SmsMessageClass();

		//	System.Windows.Forms.ListView lvReceivedMessages = new System.Windows.Forms.ListView();
		//	System.Windows.Forms.ListView lvSentMessages = new System.Windows.Forms.ListView();


		//	string strName = PortName;

		//	StrDeviceSpeed = "115200";
		//	if (!int.TryParse(StrDeviceSpeed, out DeviceSpeed))
		//	{
		//		DeviceSpeed = 0;
		//	}

		//	// Opens the COM-Port of the GSM modem.
		//	objGsm.Open(strName, Pincode, objSmsConstants.GSM_FLOWCONTROL_AUTO, DeviceSpeed);
		//	UpdateResult(objGsm.LastError);

		//	//if (objGsm.LastError != 36134)
		//	//{
                           
		//	//}

		//	if (objGsm.LastError != 0)
		//	{
		//		// Checks if PIN is valid, or required.
		//		if (objGsm.LastError == 36101)
		//		{   // 36101 means: Invalid Pin entered. See also www.activexperts.com/support/errorcodes
		//			JMessages.Error("Invalid Pin entered: SIM card can be blocked after a number of false attempts in a row.", "");
		//		}
		//		objGsm.Close();
		//		return false;
		//	}
            
		//	//Message Settings
		//	//objSmsMessage.Clear();
		//	//objSmsMessage.ToAddress = Recipient;
		//	//objSmsMessage.Body = Message;
		//	//objSmsMessage.RequestDeliveryReport = objFrmSendOptions.DeliveryReport;

		//	//if (objFrmSendOptions.ImmediateDisplay)
		//	//{
		//		//objSmsMessage.DataCoding |= objSmsConstants.DATACODING_FLASH;
		//	//}

		//		int iMultipart = 1;// objFrmSendOptions.MultiPart;

		//	if (BodyType == "Unicode")
		//	{
		//		//objSmsMessage.DataCoding |= objSmsConstants.DATACODING_UNICODE;
		//	}
		//	else if (BodyType == "Data")
		//	{
		//		//objSmsMessage.BodyFormat = objSmsConstants.BODYFORMAT_HEX;
		//		//objSmsMessage.DataCoding |= objSmsConstants.DATACODING_8BIT_DATA;
		//	}
		//	else if (BodyType == "Data (UDH)")
		//	{
		//		//objSmsMessage.BodyFormat = objSmsConstants.BODYFORMAT_HEX;
		//		//objSmsMessage.DataCoding |= objSmsConstants.DATACODING_8BIT_DATA;
		//		//objSmsMessage.HasUdh = true;
		//	}

		//	//obj = objSmsMessage;
		//	// Sends the SMS Message
		//	//objGsm.SendSms(ref obj, iMultipart, 10000);
		//	UpdateResult(objGsm.LastError);
		//	//objSmsMessage = (SmsMessage)obj;
		//	//strMessageReference = objSmsMessage.Reference;

		//	if (objGsm.LastError == 0)
		//	{
		//		System.Windows.Forms.ListViewItem item;

		//		//if (objFrmSendOptions.DeliveryReport)
		//		//{
		//			//item = new System.Windows.Forms.ListViewItem(new string[] { DateTime.Now.ToShortTimeString(), strMessageReference, objSmsMessage.ToAddress, "Sent (delivery pending)", Message });
		//		//}
		//		//else
		//		//{
		//		//    item = new System.Windows.Forms.ListViewItem(new string[] { DateTime.Now.ToShortTimeString(), strMessageReference, objSmsMessage.ToAddress, "Sent", Message });
		//		//}

		//		// Creating a list of references for each sms message sent.
		//		// This is because multipart messages contain multiple references.
		//		// 1 delivery report can only contain 1 reference each so we need all the 
		//		// references to set the messages to sent (delivered). This list will help
		//		// to keep track of what delivery reports are already received.
		//		List<string> lsReferences = new List<string>();
		//		//foreach (string strReference in strMessageReference.Split(','))
		//		//{
		//		//	lsReferences.Add(strReference);
		//		//}

		//		//item.Tag = lsReferences;
		//		//lvSentMessages.Items.Insert(0, item);
		//	}
            
		//	//Closes the GSM device
		//	objGsm.Close();

		//	return true;
		//}

		//public bool SendSMSByService(string Recipient, string Message, string BodyType)
		//{
		//	object obj;
		//	string strMessageReference;
		//	//SmsMessage objSmsMessage = new SmsMessageClass();

		//	System.Windows.Forms.ListView lvReceivedMessages = new System.Windows.Forms.ListView();
		//	System.Windows.Forms.ListView lvSentMessages = new System.Windows.Forms.ListView();


		//	string strName = PortName;


		//	if (!int.TryParse(StrDeviceSpeed, out DeviceSpeed))
		//	{
		//		DeviceSpeed = 0;
		//	}

		//	// Opens the COM-Port of the GSM modem.
		//	objGsm.Open(strName, Pincode, objSmsConstants.GSM_FLOWCONTROL_AUTO, DeviceSpeed);
		//	UpdateResult(objGsm.LastError);

		//	if (objGsm.LastError != 0)
		//	{
		//		// Checks if PIN is valid, or required.
		//		if (objGsm.LastError == 36101)
		//		{   // 36101 means: Invalid Pin entered. See also www.activexperts.com/support/errorcodes
		//			JMessages.Error("Invalid Pin entered: SIM card can be blocked after a number of false attempts in a row.", "");
		//		}
		//		objGsm.Close();
		//		return false;
		//	}

		//	//Message Settings
		//	//objSmsMessage.Clear();
		//	//objSmsMessage.ToAddress = Recipient;
		//	//objSmsMessage.Body = Message;
		//	//objSmsMessage.RequestDeliveryReport = objFrmSendOptions.DeliveryReport;

		//	//if (objFrmSendOptions.ImmediateDisplay)
		//	//{
		//		//objSmsMessage.DataCoding |= objSmsConstants.DATACODING_FLASH;
		//	//}

		//	int iMultipart = 1;// objFrmSendOptions.MultiPart;

		//	if (BodyType == "Unicode")
		//	{
		//		//objSmsMessage.DataCoding |= objSmsConstants.DATACODING_UNICODE;
		//	}
		//	else if (BodyType == "Data")
		//	{
		//		//objSmsMessage.BodyFormat = objSmsConstants.BODYFORMAT_HEX;
		//		//objSmsMessage.DataCoding |= objSmsConstants.DATACODING_8BIT_DATA;
		//	}
		//	else if (BodyType == "Data (UDH)")
		//	{
		//		//objSmsMessage.BodyFormat = objSmsConstants.BODYFORMAT_HEX;
		//		//objSmsMessage.DataCoding |= objSmsConstants.DATACODING_8BIT_DATA;
		//		//objSmsMessage.HasUdh = true;
		//	}

		//	//obj = objSmsMessage;
		//	// Sends the SMS Message
		//	//objGsm.SendSms(ref obj, iMultipart, 10000);
		//	//UpdateResult(objGsm.LastError);
		//	//objSmsMessage = (SmsMessage)obj;
		//	//strMessageReference = objSmsMessage.Reference;

		//	if (objGsm.LastError == 0)
		//	{
		//		System.Windows.Forms.ListViewItem item;

		//		//if (objFrmSendOptions.DeliveryReport)
		//		//{
		//			//item = new System.Windows.Forms.ListViewItem(new string[] { DateTime.Now.ToShortTimeString(), strMessageReference, objSmsMessage.ToAddress, "Sent (delivery pending)", Message });
		//		//}
		//		//else
		//		//{
		//		//    item = new System.Windows.Forms.ListViewItem(new string[] { DateTime.Now.ToShortTimeString(), strMessageReference, objSmsMessage.ToAddress, "Sent", Message });
		//		//}

		//		// Creating a list of references for each sms message sent.
		//		// This is because multipart messages contain multiple references.
		//		// 1 delivery report can only contain 1 reference each so we need all the 
		//		// references to set the messages to sent (delivered). This list will help
		//		// to keep track of what delivery reports are already received.
		//		List<string> lsReferences = new List<string>();
		//		//foreach (string strReference in strMessageReference.Split(','))
		//		//{
		//		//	lsReferences.Add(strReference);
		//		//}

		//		//item.Tag = lsReferences;
		//		//lvSentMessages.Items.Insert(0, item);
		//	}

		//	//Closes the GSM device
		//	objGsm.Close();

		//	return true;
		//}
    }

    public class JWebServiceSMS
    {
        private static readonly object syncLock = new object();
        public string Validate_Number(string Number)
        {
            string ret = Number.Trim();
            if (ret.Substring(0, 4) == "0098")
            {
                ret = ret.Remove(0, 4);
            }
            if (ret.Substring(0, 3) == "098")
            {
                ret = ret.Remove(0, 3);
            }
            if (ret.Substring(0, 3) == "+98")
            {
                ret = ret.Remove(0, 3);
            }
            if (ret.Substring(0, 2) == "98")
            {
                ret = ret.Remove(0, 2);
            }
            if (ret.Substring(0, 1) == "0")
            {
                ret = ret.Remove(0, 1);
            }
            return "+98" + ret;
        }
        public string Validate_Message(ref string Message, bool IsPersian)
        {
            char cr = (char)13;
            Message = Message.Replace(cr.ToString(), string.Empty);

            if (Message.EndsWith(Environment.NewLine))
            {
                Message = Message.TrimEnd(Environment.NewLine.ToCharArray());
            }
            if (IsPersian)
            {
                return C2Unicode(Message);
            }
            else
            {
                return Message;
            }
        }
        public string C2Unicode(string Message)
        {
            int i;
            int preUnicode_Number;
            string preUnicode;
            string ret = "";
            for (i = 0; i < Message.Length; i++)
            {
                preUnicode_Number = 4 - string.Format("{0:X}", (int)(Message.Substring(i, 1)[0])).Length;
                preUnicode = string.Format("{0:D" + preUnicode_Number.ToString() + "}", 0);
                ret = ret + preUnicode + string.Format("{0:X}", (int)(Message.Substring(i, 1)[0]));
            }
            return ret;
        }
        public static void FindTxtLanguageAndcount(string unicodeString, ref bool IsPersian, ref int SMSCount)
        {
            unicodeString = unicodeString.Replace("\r\n", "a");
            IsPersian = FindTxtLanguage(unicodeString);
            decimal msgCount = 0;
            int strLength = unicodeString.Length;
            if (IsPersian == true && strLength <= 70)
                msgCount = 1;
            else if (IsPersian == true && strLength > 70)
                msgCount = Convert.ToInt32(Math.Ceiling(strLength / 67.0));
            else if (IsPersian == false && strLength <= 160)
                msgCount = 1;
            else if (IsPersian == false && strLength > 160)
                msgCount = Convert.ToInt32(Math.Ceiling(strLength / 157.0));

            SMSCount = Convert.ToInt16(msgCount);
        }
        public static bool FindTxtLanguage(string unicodeString)
        {
            const int MaxAnsiCode = 255;
            bool IsPersian = true;
            if (unicodeString != string.Empty)
                IsPersian = unicodeString.ToCharArray().Any(c => c > MaxAnsiCode);
            else
                IsPersian = true;
            return IsPersian;
        }
        public string[] SendSMS_Single(string Message, string DestinationAddress, string Number, string userName, string password, string IP_Send, string Company, bool IsFlash)
        {
            string rawMessage = Message;
            string strIsPersian;
            string Identity = string.Empty;
            string[] RetValue = new string[2];
            RetValue[0] = "False";
            RetValue[1] = "0";
            bool IsPersian = FindTxtLanguage(Message);
            Validate_Message(ref Message, IsPersian);
            if (IsPersian)
            {
                Message = C2Unicode(Message);
                strIsPersian = "true";
            }
            else
            {
                strIsPersian = "false";
            }

            lock (syncLock)
            {
                try
                {
                    Random _Random = new Random();
                    Identity = string.Format("{0:yyyyMMddHHmmssfff}", DateTime.Now) + string.Format("{0:000}", _Random.Next(1000));
                    string dcs = IsPersian ? "8" : "0";
                    string msgClass = IsFlash ? "0" : "1";
                    StringBuilder _StringBuilder = new StringBuilder();
                    _StringBuilder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                    _StringBuilder.Append(Environment.NewLine);
                    _StringBuilder.Append("<!DOCTYPE smsBatch PUBLIC \"-//PERVASIVE//DTD CPAS 1.0//EN\" \"http://www.ubicomp.ir/dtd/Cpas.dtd\">");
                    _StringBuilder.Append(Environment.NewLine);
                    _StringBuilder.Append("<smsBatch company=\"" + Company + "\" batchID=\"" + Company + "+" + Identity + "\">");
                    _StringBuilder.Append(Environment.NewLine);
                    _StringBuilder.Append("<sms msgClass=\"" + msgClass + "\" binary=\"" + strIsPersian + "\" dcs=\"" + dcs + "\"" + ">");
                    _StringBuilder.Append(Environment.NewLine);
                    _StringBuilder.Append("<destAddr><![CDATA[" + Validate_Number(DestinationAddress) + "]]></destAddr>");
                    _StringBuilder.Append(Environment.NewLine);
                    _StringBuilder.Append("<origAddr><![CDATA[" + Validate_Number(Number) + "]]></origAddr>");
                    _StringBuilder.Append(Environment.NewLine);
                    _StringBuilder.Append("<message><![CDATA[" + Message + "]]></message>");
                    _StringBuilder.Append(Environment.NewLine);
                    _StringBuilder.Append("</sms>");
                    _StringBuilder.Append(Environment.NewLine);
                    _StringBuilder.Append("</smsBatch>");

                    string dataToPost = _StringBuilder.ToString();
                    byte[] buf = System.Text.UTF8Encoding.UTF8.GetBytes(_StringBuilder.ToString());
                    WebRequest objWebRequest = WebRequest.Create(IP_Send);
                    objWebRequest.Method = "POST";
                    objWebRequest.ContentType = "text/xml";
                    byte[] byt = System.Text.Encoding.UTF8.GetBytes(userName + ":" + password);
                    objWebRequest.Headers.Add("authorization", "Basic " + Convert.ToBase64String(byt));
                    Stream _Stream = objWebRequest.GetRequestStream();
                    StreamWriter _StreamWriter = new StreamWriter(_Stream);
                    _StreamWriter.Write(dataToPost);
                    _StreamWriter.Flush();
                    _StreamWriter.Close();
                    _Stream.Close();

                    WebResponse objWebResponse = objWebRequest.GetResponse();
                    Stream objResponseStream = objWebResponse.GetResponseStream();
                    StreamReader objStreamReader = new StreamReader(objResponseStream);
                    string dataToReceive = objStreamReader.ReadToEnd();
                    objStreamReader.Close();
                    objResponseStream.Close();
                    objWebResponse.Close();

                    if (dataToReceive.IndexOf("CHECK_OK") > 0)
                    {
                        RetValue[0] = "CHECK_OK";
                        RetValue[1] = Identity;
                        string[] Tonumber = new string[1];
                        Tonumber[0] = DestinationAddress;
                    }
                    else
                    {
                        try
                        {
                            string msg;
                            int firstIndex = dataToReceive.IndexOf("CDATA[");
                            int LastIndex = dataToReceive.IndexOf("]");
                            msg = dataToReceive.Substring(firstIndex, LastIndex - firstIndex);
                            RetValue[1] = msg;
                            return RetValue;
                        }
                        catch
                        {

                        }
                    }
                }
                catch (Exception ex)
                {
                    return RetValue;
                }
                return RetValue;
            }
        }
        public string[] SendSMS_Batch(string Message, string[] DestinationAddress, string Number, string userName, string password, string IP_Send, string Company, bool IsFlash)
        {
            int sentItems = 0;
            int smsPart = 0;
            int counter = 0;
            string[] RetValue = new string[2];
            RetValue[0] = "False";
            RetValue[1] = "0";
            bool IsPersian = false;
            FindTxtLanguageAndcount(Message, ref IsPersian, ref smsPart);

            if (DestinationAddress.Length * smsPart > 100)
            {
                int batchLength = (int)(100 / smsPart);
                int batchCount = (int)(DestinationAddress.Length / batchLength);
                int batchIndex = 0;
                string[] remainDestinationAddress = new string[DestinationAddress.Length - (batchCount * batchLength)];
                string[] batchDestinationAddress = new string[batchLength];
                for (int i = 0; i < batchCount; i++)
                {
                    for (int j = 0; j < batchLength; j++)
                    {
                        batchDestinationAddress[j] = DestinationAddress[batchIndex + j];
                        counter += 1;
                    }

                    RetValue = SendSMS_Batch_Devided(Message, batchDestinationAddress, Number, userName, password, IP_Send, Company, IsPersian, IsFlash);
                    batchIndex += (batchLength);

                    if (RetValue[0] == "CHECK_OK")
                    {
                        sentItems += batchLength;
                    }

                }
                int diff = DestinationAddress.Length - counter;
                for (int k = 0; k < diff; k++)
                {
                    remainDestinationAddress[k] = DestinationAddress[counter + k];

                }

                RetValue = SendSMS_Batch_Devided(Message, remainDestinationAddress, Number, userName, password, IP_Send, Company, IsPersian, IsFlash);
                if (RetValue[0] == "CHECK_OK")
                {
                    sentItems += diff;
                }
                if ((sentItems * 1.0 / DestinationAddress.Length) > 0.9)
                {
                    RetValue[0] = "CHECK_OK";
                }
            }
            else
            {
                RetValue = SendSMS_Batch_Devided(Message, DestinationAddress, Number, userName, password, IP_Send, Company, IsPersian, IsFlash);
            }

            return RetValue;
        }
        public string[] SendSMS_Batch_Devided(string Message, string[] DestinationAddress, string Number, string userName, string password, string IP_Send, string Company, bool IsPersian, bool IsFlash)
        {
            string rawMessage = Message;
            string strIsPersian;
            string Identity = string.Empty;
            string[] RetValue = new string[2];
            RetValue[0] = "False";
            RetValue[1] = "0";
            Validate_Message(ref Message, IsPersian);
            if (IsPersian)
            {
                Message = C2Unicode(Message);
                strIsPersian = "true";
            }
            else
            {
                strIsPersian = "false";
            }

            lock (syncLock)
            {
                try
                {
                    Random _Random = new Random(Guid.NewGuid().GetHashCode());
                    Identity = string.Format("{0:yyyyMMddHHmmssfff}", DateTime.Now) + string.Format("{0:000}", _Random.Next(1000));
                    string dcs = IsPersian ? "8" : "0";
                    string msgClass = IsFlash ? "0" : "1";
                    StringBuilder _StringBuilder = new StringBuilder();
                    _StringBuilder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                    _StringBuilder.Append(Environment.NewLine);
                    _StringBuilder.Append("<!DOCTYPE smsBatch PUBLIC \"-//PERVASIVE//DTD CPAS 1.0//EN\" \"http://www.ubicomp.ir/dtd/Cpas.dtd\">");
                    _StringBuilder.Append(Environment.NewLine);
                    _StringBuilder.Append("<smsBatch company=\"" + Company + "\" batchID=\"" + Company + "+" + Identity + "\">");
                    _StringBuilder.Append(Environment.NewLine);
                    _StringBuilder.Append("<sms msgClass=\"" + msgClass + "\" binary=\"" + strIsPersian + "\" dcs=\"" + dcs + "\"" + ">");
                    _StringBuilder.Append(Environment.NewLine);

                    for (int i = 0; i < DestinationAddress.Length; i++)
                    {
                        _StringBuilder.Append("<destAddr><![CDATA[" + Validate_Number(DestinationAddress[i]) + "]]></destAddr>");
                        _StringBuilder.Append(Environment.NewLine);
                    }

                    _StringBuilder.Append("<origAddr><![CDATA[" + Validate_Number(Number) + "]]></origAddr>");
                    _StringBuilder.Append(Environment.NewLine);
                    _StringBuilder.Append("<message><![CDATA[" + Message + "]]></message>");
                    _StringBuilder.Append(Environment.NewLine);
                    _StringBuilder.Append("</sms>");
                    _StringBuilder.Append(Environment.NewLine);
                    _StringBuilder.Append("</smsBatch>");

                    string dataToPost = _StringBuilder.ToString();

                    byte[] buf = System.Text.UTF8Encoding.UTF8.GetBytes(_StringBuilder.ToString());
                    WebRequest objWebRequest = WebRequest.Create(IP_Send);
                    objWebRequest.Method = "POST";
                    objWebRequest.ContentType = "text/xml";
                    byte[] byt = System.Text.Encoding.UTF8.GetBytes(userName + ":" + password);
                    objWebRequest.Headers.Add("authorization", "Basic " + Convert.ToBase64String(byt));
                    Stream _Stream = objWebRequest.GetRequestStream();
                    StreamWriter _StreamWriter = new StreamWriter(_Stream);
                    _StreamWriter.Write(dataToPost);
                    _StreamWriter.Flush();
                    _StreamWriter.Close();
                    _Stream.Close();

                    WebResponse objWebResponse = objWebRequest.GetResponse();
                    Stream objResponseStream = objWebResponse.GetResponseStream();
                    StreamReader objStreamReader = new StreamReader(objResponseStream);
                    string dataToReceive = objStreamReader.ReadToEnd();
                    objStreamReader.Close();
                    objResponseStream.Close();
                    objWebResponse.Close();

                    if (dataToReceive.IndexOf("CHECK_OK") > 0)
                    {
                        RetValue[0] = "CHECK_OK";
                        RetValue[1] = Identity;
                    }
                    else
                    {
                        try
                        {
                            string msg;
                            int firstIndex = dataToReceive.IndexOf("CDATA[");
                            int LastIndex = dataToReceive.IndexOf("]");
                            msg = dataToReceive.Substring(firstIndex, LastIndex - firstIndex);
                            RetValue[1] = msg;
                            return RetValue;
                        }
                        catch
                        {

                        }
                    }
                }
                catch (Exception ex)
                {
                    return RetValue;
                }
            }
            return RetValue;
        }
    }
}
