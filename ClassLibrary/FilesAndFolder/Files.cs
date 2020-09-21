using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace ClassLibrary
{
    #region Files Static Functions
    /// <summary>
    /// توابع کار با فایلها
    /// </summary>
    public class JFiles : JCore
    {
        public static string GetExecutingDirectory()
        {
            var location = new Uri(Assembly.GetEntryAssembly().GetName().CodeBase);
            return (new FileInfo(location.AbsolutePath).Directory.FullName) + Path.DirectorySeparatorChar;
        }
        
        public static string getUniqueFileName(string BasePath, string BaseFile)
        {
            int index = 0;
            string filename = Path.GetFileNameWithoutExtension(BaseFile);
            string extension = Path.GetExtension(BaseFile);
            while (File.Exists(BasePath + BaseFile))
            {
                index++;
                BaseFile = filename + '(' + index.ToString() + ")." + extension;
            }
            return BaseFile;
        }

        public static bool CreateEmptyFile(string FileName)
        {
            if (File.Exists(FileName))
                return false;
            FileStream F = File.Create(FileName);
            F.Close();
            return true;
        }

        public static bool DeleteFile(string FileName)
        {
            if (File.Exists(FileName))
            {
                File.Delete(FileName);
                return true;
            }
            return false;
        }

        /// <summary>
        ///  بدست آوردن پسوند فایل از روی نام فایل
        /// </summary>
        /// <param name="pfileName">نام فایل</param>
        /// <returns>پسوند</returns>
        public static string GetExtension(string pfileName)
        {
            pfileName = pfileName.ToLower();
            char[] strArray = pfileName.ToCharArray();
            Array.Reverse(strArray);
            string strReversed = new string(strArray);
            string strExtension = "";
            if (strReversed.IndexOf('.') > 0)
            {
                strExtension = strReversed.Substring(0, strReversed.IndexOf('.'));
            }
            //-------------------------------------
            char[] strArrayExtension = strExtension.ToCharArray();
            Array.Reverse(strArrayExtension);
            string strTemp = new string(strArrayExtension);
            return "." + strTemp;
        }
    }
    #endregion

    #region File Types
    /// <summary>
    /// انواع فایل
    /// </summary>
    public enum JFileTypes
    {
        /// <summary>
        /// فایل تصویر
        /// </summary>
        Image = 1,
        /// <summary>
        /// فایل ورد
        /// </summary>
        WordDocument = 2,
        /// <summary>
        /// فایل اکسل
        /// </summary>
        ExcelDocument = 3,
        /// <summary>
        /// فایل صوتی
        /// </summary>
        Sound = 4,
        /// <summary>
        /// فایل اتوکد
        /// </summary>
        Autocad = 5,
        /// <summary>
        /// سایر انواع فایل
        /// </summary>
        Other = 100
    }
    #endregion

    #region File Class

    public class JFile: JBase
    {

        #region Constructor
        public JFile()
        {
            this.FileType = JFileTypes.Other;
        }
        public JFile(JFileTypes pFileType)
        {
            this.FileType = pFileType;
        }
        #endregion

        /// <summary>
        ///انواع منبع فایل
        /// </summary>
        public enum JFileSource
        {
            FromDisk, FromMemory, FromArchive
        }

        #region File Properties
        /// <summary>
        /// منبع فایل
        /// </summary>
        public JFileSource FileSource { get; set; }


        private string _FileName;
        /// <summary>
        /// نام فایل بهمراه مسیر
        /// </summary>
        public string FileName
        {
            get
            {
                return _FileName;
            }

            set
            {
                //FileSource = JFileSource.FromDisk;
                _FileName = value;
            }
        }
        /// <summary>
        /// سایز فایل
        /// </summary>
        public Int64 Size
        {
            get
            {
                if (_Content == null)
                    return 0;
                return _Content.Length;
            }
        }
        /// <summary>
        /// نوع فایل
        /// </summary>
        public JFileTypes FileType { get; set; }
        private string _Extension;
        /// <summary>
        /// پسوند فایل
        /// </summary>
        public string Extension
        {
            get
            {
                if (this.FileSource == JFileSource.FromDisk)
                {
                    if (_FileName.Trim() != "")
                        return JFiles.GetExtension(_FileName);
                    else
                        return "";
                }
                else
                    return _Extension;
            }
            set
            {
                _Extension = value;
            }
        }

        private byte[] _Content;
        /// <summary>
        /// محتوای فایل بصورت بایت
        /// </summary>
        public byte[] Content
        {
            get
            {
                if (_Content == null && FileSource == JFileSource.FromDisk && File.Exists(_FileName))
                {
                    _Load();
                    return _Content;
                }
                else //if (FileSource == JFileSource.FromMemory)
                {
                    return _Content;
                }
            }
            set
            {
                _Content = value;
            }
        }

        public MemoryStream Stream
        {
            get
            {
                if (_Content != null)
                {
                    System.IO.MemoryStream stream = new System.IO.MemoryStream(_Content);
                    object tObject = stream;
                    JSystem.AddObject(ref tObject);
                    
                    return stream;
                }
                return null;
            }
        }

        /// <summary>
        ///محتوای فایل بصورت متن 
        /// </summary>
        string _FileText;
        public string FileText 
        {
            get
            {
                if (_FileText != null && _FileText.Length > 0 || _Content == null)
                    return _FileText;
                return System.Text.Encoding.UTF8.GetString(_Content);
            }

            set
            {
                _FileText = value;
            }
        }
        #endregion Properties

        /// <summary>
        /// لود محتوای فایل
        /// </summary>
        /// <returns></returns>
        private bool _Load()
        {
            FileStream fs = new FileStream(_FileName, FileMode.Open, FileAccess.Read);
            byte[] content = new byte[fs.Length];
            try
            {
                fs.Read(content, 0, System.Convert.ToInt32(fs.Length));
                _Content = content;

                return true;
                //FileSource = JFileSource.FromMemory;
            }
            finally
            {
                fs.Close();
            }
        }

        /// <summary>
        /// رایت محتوای فایل
        /// </summary>
        /// <returns></returns>
        public bool Write()
        {
            FileStream fs = new FileStream(_FileName, FileMode.Create, FileAccess.Write);
            
            try
            {
                if (_Content == null)
                {
                    _Content = System.Text.Encoding.UTF8.GetBytes(FileText);
                }

                fs.Write(_Content, 0, System.Convert.ToInt32(_Content.Length));
                return true;
            }
            finally
            {
                fs.Close();
            }
        }

        public bool Exists()
        {
            return File.Exists(_FileName);
        }

        public bool Read()
        {
            return _Load();
        }

        public string ReadFileText()
        {
            _FileText = System.Text.Encoding.UTF8.GetString(_Content);
            return _FileText;
        }
        /// <summary>
        /// باز کردن فایل بر روی کامپیوتر با استفاده از نرم افزار مربوط به فایل
        /// </summary>
        /// <returns></returns>
        public bool Open()
        {
            try
            {

                string FileName = System.IO.Path.GetTempPath() + "Temp" + this.Extension; 
                ///حذف فایل در صورت وجود
                if (File.Exists(FileName))
                    File.Delete(FileName);
                File.WriteAllBytes(FileName, this.Content);
                ///  اطمینان ازینکه محتوای فایل درست ذخیره شده است
                if (!File.Exists(FileName))
                {
                    JMessages.Error("SystemCanNotOpenFile", "Error");
                    return false;
                }
                /// اجرا
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = new System.Diagnostics.ProcessStartInfo(@FileName);
                return proc.Start();
            }
            catch (Exception ex)
            {
                if (ex is System.ComponentModel.Win32Exception)
                    JMessages.Error("SystemCanNotOpenFile", "Error");
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        public bool Delete()
        {
            try
            {
                ///حذف فایل در صورت وجود
                if (File.Exists(FileName))
                {
                    File.Delete(FileName);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override void Dispose()
        {
            if (_Content != null)
                Array.Resize(ref _Content, 0);
            if (Stream != null)
                Stream.Dispose();
            base.Dispose();
        }
        
    #endregion
    }
}