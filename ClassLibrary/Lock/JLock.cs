using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using NovinAfzar;

namespace ClassLibrary.Lock
{
    enum Password
    {
        sepad,
    }

    public class JLock : JCore
    {
        //NovinAfzar.clsHIDLock HidLock = new clsHIDLock();
        public static bool OKLock = true;
        public string VID
        {
            get
            {
                return "109.232.151.192";
            }
        }
        int[] key = { 58 ,166,110,227,31 ,55 ,210,10 ,211,126,153,49 ,165,254,106,143 };

        public void Init()
        {
            //HidLock.Init();
        }

        public void GetFirstDevice()
        {
            //HidLock.GetFirstDevice();
        }

        public void GetNextDevice()
        {
            //HidLock.GetNextDevice();
        }

        public int GetDeviceCount()
        {
            return 0;// HidLock.GetDeviceCount();
        }

        public string GetEncryption(string pData, string pDeviceSerial)
        {
            Init();
            //HidLock.SelectDevice(pDeviceSerial);
            //string PWD = HidLock.ConvStringToDelimiteredString(Password.sepad.ToString(), 16, ".");
            //string enc = HidLock.GetEncryption(VID, PWD, pData, 10);
            return "";// enc;
        }

        public string GetDecryption(string pData, string pDeviceSerial)
        {
            Init();
            //HidLock.SelectDevice(pDeviceSerial);
            //string plok = "*"+"7"+"_"+"M"+"K"+"k"+"k"+"&"+"@";
            //string PWD = HidLock.ConvStringToDelimiteredString(plok, 16, ".");
            //string enc = HidLock.GetDecryption(VID, PWD, pData, 16);
            return "";// enc;
        }

        public bool CheckLock()
        {
            if (!OKLock)
            {
                Init();
                GetFirstDevice();
                //if (HidLock.ErrNo == 0)
                //{

                //    HidLock.SelectDevice(HidLock.DeviceSerial);
                //    string enc = GetDecryption(JMainFrame.GetKey(key), HidLock.DeviceSerial);
                //    enc = HidLock.ConvDelimiteredStringToString(enc, 32, ".").Trim(new char[] { '\0' });
                //    OKLock = JMainFrame.KeyName == enc;
                //}
            }
            
            return OKLock;

        }
    }
}
