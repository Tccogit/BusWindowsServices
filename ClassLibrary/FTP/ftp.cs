using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace ClassLibrary
{
    public class JFTP
    {
        public string HostName;
        public string UserName;
        public string PassWord;

        // Get the object used to communicate with the server.
        private static FtpWebRequest request;

        public JFTP()
        {
        }

        public bool Connect()
        {
            return Connect(UserName, PassWord, HostName);
        }

        public bool Connect(string pUser, string pPass, string pHost)
        {
            try
            {
                HostName = pHost;
                UserName = pUser;
                PassWord = pPass;
                request.Credentials = new NetworkCredential(pUser, pPass);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request = (FtpWebRequest)WebRequest.Create(pHost);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Upload(string pFile)
        {
            try
            {
                if (!File.Exists(pFile))
                    return false;
                if (request == null)
                    Connect();
                StreamReader sourceStream = new StreamReader(pFile);
                byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                sourceStream.Close();
                request.ContentLength = fileContents.Length;

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
