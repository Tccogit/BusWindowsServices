using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Security;
using System.Runtime.InteropServices;

namespace ClassLibrary
{
    public class JEnryption: JCore
    {
        /// <summary>
        /// رمزگذاری رشته
        /// </summary>
        /// <param name="pSimpleStr"></param>
        /// <returns></returns>
        public static string EncryptStr(string pSimpleStr)
        {
            return EncryptStr(pSimpleStr, JConfig.EncryptKey);
        }
        public static string EncryptStr(string pSimpleStr, string pEncryptKey)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(pSimpleStr);

            string key = pEncryptKey;

            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        /// رمزگشایی رشته
        /// </summary>
        /// <param name="pEncrypted"></param>
        /// <returns></returns>
        public static string DecryptStr(string pEncrypted)
        {
            return DecryptStr(pEncrypted, JConfig.EncryptKey);
        }

        public static string DecryptStr(string pEncrypted, string pEncryptKey)
        {
            try
            {
                byte[] keyArray;
                if (pEncrypted == null)
                    return null;
                byte[] toEncryptArray = Convert.FromBase64String(pEncrypted);
                string key = pEncryptKey;

                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;

                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(
                                     toEncryptArray, 0, toEncryptArray.Length);
                tdes.Clear();
                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch(Exception ex)
            {
                JSystem.Except.AddException(ex);
                return "";
            }
        }

        //  Call this function to remove the key from memory after use for security.
        [System.Runtime.InteropServices.DllImport("KERNEL32.DLL", EntryPoint = "RtlZeroMemory")]
        public static extern bool ZeroMemory(ref string Destination, int Length);

        /// <summary>
        /// رمز گذاری فایل
        /// </summary>
        /// <param name="sInputFilename"></param>
        /// <param name="sOutputFilename"></param>
        /// <param name="sKey"></param>
        public static void EncryptFile(string sInputFilename, string sOutputFilename)
        {
            EncryptFile(sInputFilename, sOutputFilename, JConfig.EncryptFileKey);
        }

        public static void EncryptFile(string sInputFilename, string sOutputFilename, string pEncryptFileKey)
        {
            string sKey = pEncryptFileKey;
            FileStream fsInput = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read);
            FileStream fsEncrypted = new FileStream(sOutputFilename, FileMode.Create, FileAccess.Write);

            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            ICryptoTransform desencrypt = DES.CreateEncryptor();
            CryptoStream cryptostream = new CryptoStream(fsEncrypted, desencrypt, CryptoStreamMode.Write);

            byte[] bytearrayinput = new byte[fsInput.Length];
            fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
            cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
            cryptostream.Close();
            fsInput.Close();
            fsEncrypted.Close();
        }

        /// <summary>
        /// رمز گشایی فایل
        /// </summary>
        /// <param name="sInputFilename"></param>
        /// <param name="sOutputFilename"></param>
        /// <param name="sKey"></param>
        public static void DecryptFile(string sInputFilename, string sOutputFilename)
        {
            DecryptFile(sInputFilename, sOutputFilename, JConfig.EncryptFileKey);
        }

        public static void DecryptFile(string sInputFilename, string sOutputFilename, string pEncryptFileKey)
        {
            string sKey = pEncryptFileKey;
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            //A 64 bit key and IV is required for this provider.
            //Set secret key For DES algorithm.
            DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            //Set initialization vector.
            DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);

            //Create a file stream to read the encrypted file back.
            FileStream fsread = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read);
            //Create a DES decryptor from the DES instance.
            ICryptoTransform desdecrypt = DES.CreateDecryptor();
            //Create crypto stream set to read and do a 
            //DES decryption transform on incoming bytes.
            CryptoStream cryptostreamDecr = new CryptoStream(fsread, desdecrypt, CryptoStreamMode.Read);
            //Print the contents of the decrypted file.
            StreamWriter fsDecrypted = new StreamWriter(sOutputFilename);
            fsDecrypted.Write(new StreamReader(cryptostreamDecr).ReadToEnd());
            fsDecrypted.Flush();
            fsDecrypted.Close();
        }  /// <summary>
        /// رمز گذاری فایل به صورت خط به خط
        /// </summary>
        /// <param name="sInputFilename"></param>
        /// <param name="sOutputFilename"></param>
        /// <param name="sKey"></param>
        public static void EncryptFile2(string sInputFilename, string sOutputFilename)
        {
            System.IO.StreamReader reader = File.OpenText(sInputFilename);
            TextWriter wr = new StreamWriter(sOutputFilename);
            string Line = null;
            while ((Line = reader.ReadLine()) != null)
            {
                wr.WriteLine(EncryptStr(Line));
                //wr.Write(Writer.NewLine);
            }
            wr.Close();
        }

    }
}
