using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AxMmCtlLib;

namespace ClassLibrary
{
    public class JClsSmsService : JSystem
    {
        //private Gsm objGsm;
        //private SmsConstants objSmsConstants;

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
        public JClsSmsService()
        {
            //objGsm = new GsmClass();
            //objSmsConstants = new SmsConstantsClass();
        }

        private void UpdateResult(int nResult)
        {
            //StrError = string.Format("{0}: {1}", nResult, objGsm.GetErrorDescription(objGsm.LastError));
        }

        //public bool SendSMSByService(string Recipient, string Message, string BodyType)
        //{
            
        //}
        public bool SendSMSByService(string Recipient, string Message, string BodyType)
        {                
            //Gsm objGsm = new Gsm();
            try
            {
                object obj;
                //string strMessageReference;
                //SmsMessage objSmsMessage = new SmsMessageClass();

                //string strName = PortName;
                //if (!int.TryParse(StrDeviceSpeed, out DeviceSpeed))
                //{
                //    DeviceSpeed = 0;
                //}

                //// Opens the COM-Port of the GSM modem.
                //objGsm.Open(strName, Pincode,0 , DeviceSpeed);//objSmsConstants.GSM_FLOWCONTROL_AUTO
                ////UpdateResult(objGsm.LastError);

                ////if (objGsm.LastError != 0)
                ////{
                ////    // Checks if PIN is valid, or required.
                ////    if (objGsm.LastError == 36101)
                ////    {   // 36101 means: Invalid Pin entered. See also www.activexperts.com/support/errorcodes
                ////        //JMessages.Error("Invalid Pin entered: SIM card can be blocked after a number of false attempts in a row.", "");
                ////    }
                ////    objGsm.Close();
                ////    return false;
                ////}

                ////Message Settings
                //objSmsMessage.Clear();
                //objSmsMessage.ToAddress = Recipient;
                //objSmsMessage.Body = Message;
                //objSmsMessage.RequestDeliveryReport = true;// objFrmSendOptions.DeliveryReport;

                ////if (objFrmSendOptions.ImmediateDisplay)
                ////{
                //objSmsMessage.DataCoding =16 ;//|= objSmsConstants.DATACODING_FLASH;
                ////}

                //int iMultipart = 0;// objSmsConstants.MULTIPART_OK;// objFrmSendOptions.MultiPart;

                //if (BodyType == "Unicode")
                //{
                //    objSmsMessage.DataCoding =24;//|= objSmsConstants.DATACODING_UNICODE;
                //}

                //obj = objSmsMessage;
                //// Sends the SMS Message
                //objGsm.SendSms(ref obj, iMultipart, 10000);
                ////UpdateResult(objGsm.LastError);
                //objSmsMessage = (SmsMessage)obj;
                ////strMessageReference = objSmsMessage.Reference;

                //objGsm.Close();

                return true;
            }
            finally             
            { 
                
            }
        }

    }
}
