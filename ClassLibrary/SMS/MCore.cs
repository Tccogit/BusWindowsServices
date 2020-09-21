using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mCore;

namespace ClassLibrary
{
    public class JSMSCorelib : JSystem
    {

        #region Properties        
        public mCore.SMS objSMS;
        #endregion

        public JSMSCorelib(string pPort, BaudRate pBaudRate, mCore.Encoding pEncoding)
        {
            try
            {
                if (objSMS == null)
                {
                    objSMS = new mCore.SMS();
                    objSMS.Port = pPort;
                    objSMS.BaudRate = pBaudRate;
                    objSMS.Encoding = pEncoding;
                }
            }
            catch(Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        public override void Dispose()
        {
            disConnect();
            objSMS.Dispose();
            base.Dispose();
        }

        public bool Connect()
        {
            try
            {
                if (!objSMS.IsConnected)
                {
                    return objSMS.Connect();
                }
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        public bool disConnect()
        {
            try
            {
                return objSMS.Disconnect();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        public bool SendSMS(string Mobile, string Text)
        {
            try
            {
                Connect();
                if (objSMS.Connect())
                    objSMS.SendSMS(Mobile, Text,false);

                if (objSMS.ErrorCode != 0)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
            }
        }

        public bool ReciveSMS()
        {
            try
            {
                Connect();
                if (objSMS.Connect())
                {
                    Inbox inbox = objSMS.Inbox();
                    foreach (Message M in inbox)
                    {
                        
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
            }
        }

    }
}
