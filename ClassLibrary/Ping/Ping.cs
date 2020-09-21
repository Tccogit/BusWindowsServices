using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Diagnostics;


namespace ClassLibrary
{
    public class JPing
    {
        public static bool Ping(string pIpAddress)
        {
            Ping pingSender = new Ping ();
            PingOptions options = new PingOptions ();
            options.Ttl = 128;

            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            //options.DontFragment = true;

            // Create a buffer of 1 bytes of data to be transmitted.
            string data = "a";
            byte[] buffer = Encoding.ASCII.GetBytes (data);
            int timeout = 5000;
            PingReply reply = pingSender.Send(pIpAddress, timeout, buffer, options);
            if (reply.Status == IPStatus.Success)
                return true;
            else
                return false;
        }


        public static bool PingWait(string pIpAddress, string pMessage)
        {
            Process myProcess = Process.GetCurrentProcess();

            JFormWait FS = new JFormWait();
            FS.lbMessage.Text = pMessage;
            FS.Enabled = false;
            try
            {
                Ping pingSender = new Ping();
                PingOptions options = new PingOptions();

                // Use the default Ttl value which is 128,
                // but change the fragmentation behavior.
                options.DontFragment = true;

                // Create a buffer of 1 bytes of data to be transmitted.
                string data = "a";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 1000;
                PingReply reply = null;
                do
                {
                    try
                    {
                        reply = pingSender.Send(pIpAddress, timeout, buffer, options);
                    }
                    catch
                    {
                    }
                    if (reply == null || reply.Status != IPStatus.Success)
                    {
                        if (!FS.Enabled)
                        {
                            FS.Enabled = true;
                            FS.Show();
                            myProcess.PriorityClass = ProcessPriorityClass.BelowNormal;
                        }
                    }
                    System.Windows.Forms.Application.DoEvents();
                    if (JFormWait.Status == 1)
                    {
                        myProcess.PriorityClass = ProcessPriorityClass.Normal;
                        System.Windows.Forms.Application.Exit();
                        System.Windows.Forms.Application.ExitThread();
                        return false;
                    }
                    
                } while (reply==null || reply.Status != IPStatus.Success);

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                myProcess.PriorityClass = ProcessPriorityClass.Normal;
                FS.Close();
                FS.Dispose();
            }
        }

    }
}
