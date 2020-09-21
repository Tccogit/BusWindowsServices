using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Web;

namespace ClassLibrary
{
    /// <summary>
    /// کلاس مدیریت اطلاعات پیکره بندی سیستم
    /// </summary>
    public class JConfig
    {
        #region Configuration
        /// <summary>
        /// نام و یا آدرس سرور بانک اطلاعاتی
        /// </summary>
        public string Server { get; set; }
        public string WebServer { get; set; }
        /// <summary>
        /// نام بانک اطلاعاتی
        /// </summary>
        public string Database { get; set; }
        /// <summary>
        /// نام کاربری برای اتصال به بانک اطلاعاتی
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// کلمه عبور برای اتصال به بانک اطلاعاتی
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// سرور سهام
        /// </summary>
        public string ServerSaham { get; set; }
        /// <summary>
        ///  بانک اطلاعاتی سهام
        /// </summary>
        public string DatabaseSaham { get; set; }
        /// <summary>
        /// نام کاربری برای اتصال به بانک اطلاعاتی سهام
        /// </summary>
        public string UsernameSaham { get; set; }
        /// <summary>
        /// مسیر تصاویر
        /// </summary>
        public string BaseFileAddress = "\\\\projects-server\\images";
        /// <summary>
        /// نام فایل باسکول
        /// </summary>
        public int TimeLogin { get; set; }
        /// <summary>
        /// شرکت پیش فرض سیستم
        /// </summary>
        public int CompanyDefault { get; set; }
        /// <summary>
        ///شناسایی ویندوز یا اس کیو ال 
        ///در صورتی که مقدار درست باشد ویندوز در غیر اینصورت اس کیو ال 
        /// </summary>
        public bool IntegratedSecurity
        {
            get;
            set;

        }
        public JSMSSendType SMSSendType { get; set; }
        /// <summary>
        /// کلمه عبور برای اتصال به بانک اطلاعاتی سهام
        /// </summary>
        public string PasswordSaham { get; set; }
        /// <summary>
        /// شماره نسخه نرم افزار
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// بیشترین طول لیستها در صفحه نمایش
        /// </summary>
        public int MaxLenghList { get; set; }
        /// <summary>
        /// کلید رمزگذاری 
        /// </summary>
        //public static class JEncryptKey
        public string UpdateKies = @"";

        public static string EncryptKey
        {
            get
            {
                return JFreeClass.geKey();
            }
        }
        public string SahamWebConfig
        {
            get;
            set;
        }
        /// <summary>
        /// کلید رمزگذاری فایل
        /// </summary>
        public static string EncryptFileKey
        {
            get
            {
                return JFreeClass.geKey();
            }
        }
        /// <summary>
        /// تعداد حداکثر ورودهای ناموفق برای غیر فعال کردن کاربر
        /// </summary>
        public static int MaxLoginFailCount
        {
            get
            {
                return 3;
            }
        }
        /// <summary>
        /// تعداد ساعات برای چک کردن ورودهای ناموفق
        /// </summary>
        public static int MaxLoginFailMinute
        {
            get
            {
                return 20;
            }
        }

        public string CurrentLang = JLanguageNames.Farsi;
        /// <summary>
        /// کاراکتر جدا کننده در فایل تنظیمات
        /// </summary>
        static char SplitConfigChar
        {
            get
            {
                return '=';
            }
        }

        /// <summary>
        /// نام و یا آدرس سرور بانک اطلاعاتی آرشیو
        /// </summary>
        public string ServerArchive { get; set; }
        /// <summary>
        /// نام بانک اطلاعاتی آرشیو
        /// </summary>
        public string DatabaseArchive { get; set; }
        /// <summary>
        /// نام کاربری برای اتصال به بانک اطلاعاتی آرشیو
        /// </summary>
        public string UsernameArchive { get; set; }
        /// <summary>
        ///   کلمه عبور برای اتصال به بانک اطلاعاتی آرشیو
        /// </summary>
        public string PasswordArchive { get; set; }

        public string GSMModePort = "COM4";
        //public mCore.BaudRate GSMModeBaudRate = mCore.BaudRate.BaudRate_115200;
        //public mCore.Encoding GSMModeEncoding = mCore.Encoding.Unicode_16Bit;
        /// <summary>
        /// وب سرویس ارسال اس ام اس
        /// آدرس آی پی
        /// </summary>
        public string WebSmsIPAddress
        {
            get
            {
                return @"http://193.104.22.14:2055/CPSMSService/Access";
            }
        }
        /// <summary>
        /// وب سرویس ارسال اس ام اس
        /// UserName
        /// </summary>
        public string WebSmsUserName
        {
            get
            {
                return @"koohi1";
            }
        }
        /// <summary>
        /// وب سرویس ارسال اس ام اس
        /// Password
        /// </summary>
        public string WebSmsPassword
        {
            get
            {
                return @"asertvr3";
            }
        }
        /// <summary>
        /// وب سرویس ارسال اس ام اس
        /// Company
        /// </summary>
        public string WebSmsCompany
        {
            get
            {
                return @"KOOHI";
            }
        }
        /// <summary>
        /// وب سرویس ارسال اس ام اس
        /// Number
        /// </summary>
        public string WebSmsNumber
        {
            get
            {
                return @"10000144";
            }
        }

        public int MaxDaysPassCheck = 60;

        public string LDAPServer { get; set; }
        public string DomainName { get; set; }

        public string PersonSahamTableName = "General.OtherPerson";
        public string CitiesTableName = "General.Cities";
        public string SheetSahamTableName = "Sepad.Sheet";

        public string TempPath = System.IO.Path.GetTempPath();

        public int DefaultContractSheetCode = 0;
        private static System.IO.StreamReader Filereader;
        /// <summary>
        /// تنظیمات در فایل رمزنگاری شده
        /// </summary>
        private static string _appPath = "";

        public static string LoginPage = "Login.aspx";

        public static string appPath
        {
            get
            {
                if (JMainFrame.IsWeb() == false)
                {
                    if (_appPath.Length == 0)
                    {
                        _appPath = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                    }
                }
                else
                {
                    if (_appPath == null || _appPath.Trim() == "")
                    {
                        string configPath = "~/";
                        System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(configPath);
                        string __appPath = config.AppSettings.Settings["RootPath"].Value;
                        if (__appPath.EndsWith("\\") == true) __appPath = __appPath.Substring(0, __appPath.Length - 1);
                        _appPath = __appPath;
                    }
                    return _appPath;
                }
                return _appPath;
            }
        }

        public string ConfigFileName = "Enc.Config";
        /// <summary>
        /// تنظیمات در فایل رمزنگاری نشده و اصلی
        /// </summary>
        private string MainConfig = @"Connection.txt";
        #endregion
        public JConfig()
        {
            ReadFromFile();
            //  setStaticValues();
        }

        /// <summary>
        /// خواندن اطلاعات پیشفرض
        /// </summary>
        /// <returns></returns>
        public Boolean read()
        {
            Server = ".";
            Database = "ERP_AXON";
            Username = "erp";
            Password = "erp!@#";
            Version = "2014";
            MaxLenghList = 50;
            return true;
        }
        /// <summary>
        /// خواندن تنظیمات از فایل
        /// </summary>
        /// <returns></returns>
        public Boolean ReadFromFile()
        {
            try
            {
                if (Filereader == null)
                {
                    if (!System.IO.File.Exists(appPath + "\\" + ConfigFileName))
                    {
                        //if (System.IO.File.Exists(MainConfig))
                        //    JEnryption.EncryptFile2(MainConfig, ConfigFileName);
                        //else
                        read();
                        SaveToFile();
                        ShowForm();
                        return true;
                    }
                }
                //"ERPSepad"
                //$epad@#2
                //erp_sepad
                //192.168.3.38

                //CpXquysoSNotlZvQTjhj5g==
                Filereader = File.OpenText(appPath + "\\" + ConfigFileName);
                System.IO.StreamReader reader = Filereader;
                string configLine = null;
                // Decryption of the Config File 
                while ((configLine = JEnryption.DecryptStr(reader.ReadLine())) != null)
                {
                    int SplitIndex = configLine.IndexOf(SplitConfigChar);
                    string config = configLine.Substring(0, SplitIndex).Trim();
                    string value = configLine.Substring(SplitIndex + 1).Trim();
                    if (config == "Server")
                       Server = value;
                    //Server = "2.180.1.69,100";
                    if (config == "WebServer")
                        WebServer = value;
                    if (config == "Database")
                        Database = value;
                    if (config == "Username")
                        Username = value;
                    if (config == "Password")
                        Password = value;
                    /// بازیابی تنظیمات دیتابیس سهام
                    if (config == "ServerSaham")
                        ServerSaham = value;
                    if (config == "DatabaseSaham")
                        DatabaseSaham = value;
                    if (config == "UsernameSaham")
                        UsernameSaham = value;
                    if (config == "PasswordSaham")
                        PasswordSaham = value;

                    if (config == "PersonSahamTableName")
                        PersonSahamTableName = value;
                    if (config == "SheetSahamTableName")
                        SheetSahamTableName = value;
                    if (config == "MaxLenghList")
                        MaxLenghList = Convert.ToInt32(value);
                    if (config == "CurrentLang")
                        CurrentLang = value;
                    if (config == "IntegratedSecurity")
                        IntegratedSecurity = Convert.ToBoolean(value);
                    if (config == "BaseFileAddress")
                        BaseFileAddress = value;
                    if (config == "SahamWebConfig")
                        SahamWebConfig = value;

                    if (config == "TimeLogin")
                        TimeLogin = Convert.ToInt32(value);

                    if (config == "CompanyDefault")
                        CompanyDefault = Convert.ToInt32(value);

                    if (config == "ServerArchive")
                        ServerArchive = value;
                    if (config == "DatabaseArchive")
                        DatabaseArchive = value;
                    if (config == "UsernameArchive")
                        UsernameArchive = value;
                    if (config == "PasswordArchive")
                        PasswordArchive = value;
                    if (config == "SMSSendType")
                    {
                        if (value == "1")
                            SMSSendType = JSMSSendType.GSM;
                        if (value == "2")
                            SMSSendType = JSMSSendType.WebService;
                    }
                    if (config == "LDAPServer")
                        LDAPServer = value;
                    if (config == "DomainName")
                        DomainName = value;
                    if (config == "MaxDaysPassCheck")
                        int.TryParse(value, out MaxDaysPassCheck);

                }
                reader.Close();
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        /// <summary>
        /// ذخیره تنظیمات در فایل
        /// </summary>
        /// <returns></returns>
        public bool SaveToFile()
        {
            TextWriter wr = new StreamWriter(appPath + "\\" + ConfigFileName);
            string Line = "";
            try
            {
                Line = "Server= " + Server;
                wr.WriteLine(JEnryption.EncryptStr(Line));
                Line = "WebServer= " + WebServer;
                wr.WriteLine(JEnryption.EncryptStr(Line));
                Line = "Database= " + Database;
                wr.WriteLine(JEnryption.EncryptStr(Line));
                Line = "Username= " + Username;
                wr.WriteLine(JEnryption.EncryptStr(Line));
                Line = "Password= " + Password;
                wr.WriteLine(JEnryption.EncryptStr(Line));

                Line = "ServerSaham= " + ServerSaham;
                wr.WriteLine(JEnryption.EncryptStr(Line));
                Line = "DatabaseSaham= " + DatabaseSaham;
                wr.WriteLine(JEnryption.EncryptStr(Line));
                Line = "UsernameSaham= " + UsernameSaham;
                wr.WriteLine(JEnryption.EncryptStr(Line));
                Line = "PasswordSaham= " + PasswordSaham;
                wr.WriteLine(JEnryption.EncryptStr(Line));

                Line = "SahamWebConfig= " + SahamWebConfig;
                wr.WriteLine(JEnryption.EncryptStr(Line));

                Line = "PersonSahamTableName= " + PersonSahamTableName;
                wr.WriteLine(JEnryption.EncryptStr(Line));
                Line = "SheetSahamTableName= " + SheetSahamTableName;
                wr.WriteLine(JEnryption.EncryptStr(Line));
                Line = "MaxLenghList= " + MaxLenghList;
                wr.WriteLine(JEnryption.EncryptStr(Line));
                Line = "CurrentLang= " + CurrentLang;
                wr.WriteLine(JEnryption.EncryptStr(Line));
                Line = "IntegratedSecurity= " + IntegratedSecurity.ToString();
                wr.WriteLine(JEnryption.EncryptStr(Line));
                Line = "BaseFileAddress= " + BaseFileAddress;
                wr.WriteLine(JEnryption.EncryptStr(Line));
                Line = "TimeLogin= " + TimeLogin;
                wr.WriteLine(JEnryption.EncryptStr(Line));
                Line = "CompanyDefault= " + CompanyDefault;
                wr.WriteLine(JEnryption.EncryptStr(Line));

                Line = "ServerArchive= " + ServerArchive;
                wr.WriteLine(JEnryption.EncryptStr(Line));
                Line = "DatabaseArchive= " + DatabaseArchive;
                wr.WriteLine(JEnryption.EncryptStr(Line));
                Line = "UsernameArchive= " + UsernameArchive;
                wr.WriteLine(JEnryption.EncryptStr(Line));
                Line = "PasswordArchive= " + PasswordArchive;
                wr.WriteLine(JEnryption.EncryptStr(Line));
                Line = "SMSSendType= " + SMSSendType.GetHashCode().ToString();
                wr.WriteLine(JEnryption.EncryptStr(Line));
                Line = "LDAPServer= " + LDAPServer;
                wr.WriteLine(JEnryption.EncryptStr(Line));
                Line = "DomainName= " + DomainName;
                wr.WriteLine(JEnryption.EncryptStr(Line));
                Line = "MaxDaysPassCheck=" + MaxDaysPassCheck;
                wr.WriteLine(JEnryption.EncryptStr(Line));




                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                wr.Close();
            }
        }
        /// <summary>
        /// ذخیره اطلاعات در فایل  یا رجیستری
        /// </summary>
        /// <returns></returns>
        public Boolean save()
        {
            return true;
        }
        /// <summary>
        /// نمایش فرم تنظیمات
        /// </summary>
        public void ShowForm()
        {
            JConfigForm form = new JConfigForm();
            form.ShowDialog();
        }
        /// <summary>
        /// نمایش فرم تنظیمات
        /// </summary>
        public void ShowChangePasswordForm()
        {
            Globals.JChangePass form = new Globals.JChangePass();
            form.ShowDialog();
        }

        // اطلاعات دیتابیس اتوبوسرانی
        public static string AUTServerName
        {
            get
            {
                string MySQLHost = "localhost";
                JMainFrame.FConfig.TryGetValue("MySQLHost", out MySQLHost);
                return MySQLHost;
            }
        }
       // public static string AUTServerName = "185.178.220.87";
        public static string AUTUserName = "root";
        public static string AUTPassword
        {
            get
            {
                string pass;
                pass = JMainFrame.FConfig.GetValueOrNull("MySQLPass");
                if (pass == null)
                    pass = "MyPaSsTaB1392";
                return pass;
            }
        }
        public static string AUTDataBase = "bus";
        public static float CityCenterLong = 46.294956F;
        public static float CityCenterLat =  38.068636F;
        public static float CountryMinLat = 25.025681F;
        public static float CountryMaxLat = 39.808479F;
        public static float CountryMinLng = 43.838613F;
        public static float CountryMaxLng = 63.353207F;

        /// <summary>
        /// افزودن تاریخ بین دو بازه در جدول staticDate
        /// </summary>
        /// <param name="pDateIn"></param>
        /// <param name="pDateOut"></param>
        /// <returns></returns>
        public static bool AddDateToStaticDate(DateTime pDateIn, DateTime pDateOut)
        {
            JDataBase db = new JDataBase();
            try
            {
                for (DateTime date = pDateIn; date <= pDateOut; date = date.AddDays(1))
                {
                    db.setQuery("INSERT INTO [dbo].[StaticDates]  ([En_Date],[Fa_Date]) " +
                                "VALUES " +
                               "(" + date + ", dbo.MiladiTOShamsi(" + date + ") )");
                    db.Query_Execute();
                }
                return true;
            }
            catch
            {
                return false;
            }
            return true;
        }

    }

    /// <summary>
    /// نمایش لیست و درخت
    /// </summary>
    public class JConfigs : JSystem
    {
        public void ListView()
        {
            Nodes.Insert(JStaticNode._ConfigNode());
            Nodes.Insert(JStaticNode._ChangePassword());
            Nodes.Insert(JStaticNode._GroupSMSEmployee());
            Nodes.Insert(JStaticNode._GroupSMSSQL());

        }
        public JNode[] TreeView()
        {
            JNode[] N = new JNode[5];
            N[0] = JStaticNode._ConfigNode();
            N[1] = JStaticNode._ChangePassword();
            N[2] = JStaticNode._GroupSMSEmployee();
            N[3] = JStaticNode._GroupSMSSQL();

            return N;
        }


    }
}
