//test
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//zarrin
namespace ClassLibrary
{
    public class JMainFrame : JCore
    {
        public static Dictionary<String, String> _FConfig;
        public static Dictionary<String, String> FConfig
        {
            get
            {
                if (_FConfig == null)
                {
                    _FConfig = new Dictionary<string, string>();
                }
                if (_FConfig.Count == 0)
                {
                    try
                    {
                        String[] fConfig = System.IO.File.ReadAllText(JConfig.appPath + "\\config.txt").Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

                        for (int i = 0; i < fConfig.Length; i++)
                            _FConfig.Add(fConfig[i].Split('=')[0], fConfig[i].Split('=')[1]);
                    }
                    catch
                    {

                    }
                }

                return _FConfig;
            }
        }

        public static string Server01 = FConfig.GetValueOrNull("Server01");
        public static string Server02 = FConfig.GetValueOrNull("Server02");
        public static string Server03 = FConfig.GetValueOrNull("Server03");

        private static Dictionary<String, Object> _KeyValue = new Dictionary<string, object>();
        private static Globals.JUser _CurrentUser;
        public static Globals.JUser CurrentUser
        {
            get {
                if (IsWeb())
                {
                    return WebClassLibrary.SessionManager.Current.MainFrame.CurrentUser;
                }
                else
                {
                    return _CurrentUser;
                }
                
            }

            set {
                if (IsWeb())
                {
                }
                else
                {
                    _CurrentUser = value;
                }
            }
        }

        private static ClassLibrary.JPerson _CurrentPerson;
        public static ClassLibrary.JPerson CurrentPerson
        {
            get
            {
                if (IsWeb())
                {
                    return WebClassLibrary.SessionManager.Current.MainFrame.CurrentPerson;
                }
                else
                {
                    return _CurrentPerson;
                }

            }

            set
            {
                if (IsWeb())
                {
                }
                else
                {
                    _CurrentPerson = value;
                }
            }
        }

        private static int _Terminated = 0;
        public static int Terminated
        {
            get
            {
                if (IsWeb())
                {
                    return WebClassLibrary.SessionManager.Current.MainFrame.Terminated;
                }
                else
                {
                    return _Terminated;
                }
            }
            set
            {
                if (IsWeb())
                {
                    WebClassLibrary.JMainFrame mainFrame = WebClassLibrary.SessionManager.Current.MainFrame;
                    mainFrame.Terminated = value;
                    mainFrame.Save();
                }
                else
                {
                    _Terminated = value;
                }
            }
        }
        /// <summary>
        /// کد کاربر
        /// </summary>
        private static int _CurrentUserCode = 0;
        /// <summary>
        /// کد کاربر
        /// </summary>
        public static int CurrentUserCode
        {
            get
            {
                try
                {
                    if (IsWeb())
                    {
                        return WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
                    }
                    else
                    {
                        if (_CurrentUserCode < 1)
                            return 0;
                        return _CurrentUserCode;
                    }
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                if (IsWeb())
                {
                    WebClassLibrary.JMainFrame mainFrame = WebClassLibrary.SessionManager.Current.MainFrame;
                    mainFrame.CurrentUserCode = value;
                    mainFrame.Save();
                }
                else
                {
                    _CurrentUserCode = value;
                }
            }
        }

        /// <summary>
        /// تایم کاربر
        /// </summary>
        private static int _TimeLogin = (new JConfig()).TimeLogin;
        public static int TimeLogin
        {
            get
            {
                if (IsWeb())
                {
                    return WebClassLibrary.SessionManager.Current.MainFrame.TimeLogin;
                }
                else
                {
                    return _TimeLogin;
                }
            }
            set
            {
                if (IsWeb())
                {
                    WebClassLibrary.JMainFrame mainFrame = WebClassLibrary.SessionManager.Current.MainFrame;
                    mainFrame.TimeLogin = value;
                    mainFrame.Save();
                }
                else
                {
                    _TimeLogin = value;
                }
            }
        }
        /// <summary>
        /// شرکت پیش فرض سیستم
        /// </summary>
        private static int _CompanyDefault;
        public static int CompanyDefault
        {
            get
            {
                if (IsWeb())
                {
                    return WebClassLibrary.SessionManager.Current.MainFrame.CompanyDefault;
                }
                else
                {
                    return _CompanyDefault;
                }
            }
            set
            {
                if (IsWeb())
                {
                    WebClassLibrary.JMainFrame mainFrame = WebClassLibrary.SessionManager.Current.MainFrame;
                    mainFrame.CompanyDefault = value;
                    mainFrame.Save();
                }
                else
                {
                    _CompanyDefault = value;
                }
            }
        }

        private static int _CurrentPersonCode = 0;
        public static int CurrentPersonCode
        {
            get
            {
                if (IsWeb())
                {
                    return WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;
                }
                else
                {
                    return _CurrentPersonCode;
                }
            }
            set
            {
                if (IsWeb())
                {
                    WebClassLibrary.JMainFrame mainFrame = WebClassLibrary.SessionManager.Current.MainFrame;
                    mainFrame.CurrentPersonCode = value;
                    mainFrame.Save();
                }
                else
                {
                    _CurrentPersonCode = value;
                }
            }
        }

        private static int _CurrentPostCode = 0;
        public static int CurrentPostCode
        {
            get
            {
                if (IsWeb())
                {
                    return WebClassLibrary.SessionManager.Current.MainFrame.CurrentPostCode;
                }
                else
                {
                    return _CurrentPostCode;
                }
            }
            set
            {
                if (IsWeb())
                {
                    WebClassLibrary.JMainFrame mainFrame = WebClassLibrary.SessionManager.Current.MainFrame;
                    mainFrame.CurrentPostCode = value;
                    mainFrame.Save();
                }
                else
                {
                    _CurrentPostCode = value;
                }
            }
        }


        private static bool _IsAdmin = false;
        public static bool IsAdmin
        {
            get
            {
                if (IsWeb())
                {
                    return WebClassLibrary.SessionManager.Current.MainFrame.IsAdmin;
                }
                else
                {
                    return _IsAdmin;
                }
            }
            set
            {
                if (IsWeb())
                {
                    WebClassLibrary.JMainFrame mainFrame = WebClassLibrary.SessionManager.Current.MainFrame;
                    mainFrame.IsAdmin = value;
                    mainFrame.Save();
                }
                else
                {
                    _IsAdmin = value;
                }
            }
        }

        private static string _CurrentPostTitle = "";
        public static string CurrentPostTitle
        {
            get
            {
                if (IsWeb())
                {
                    return WebClassLibrary.SessionManager.Current.MainFrame.CurrentPostTitle;
                }
                else
                {
                    return _CurrentPostTitle;
                }
            }
            set
            {
                if (IsWeb())
                {
                    WebClassLibrary.JMainFrame mainFrame = WebClassLibrary.SessionManager.Current.MainFrame;
                    mainFrame.CurrentPostTitle = value;
                    mainFrame.Save();
                }
                else
                {
                    _CurrentPostTitle = value;
                }
            }
        }

        private static int _BaseCurrentPostCode = 0;
        public static int BaseCurrentPostCode
        {
            get
            {
                if (IsWeb())
                {
                    return WebClassLibrary.SessionManager.Current.MainFrame.BaseCurrentPostCode;
                }
                else
                {
                    return _BaseCurrentPostCode;
                }
            }
            set
            {
                if (IsWeb())
                {
                    WebClassLibrary.JMainFrame mainFrame = WebClassLibrary.SessionManager.Current.MainFrame;
                    mainFrame.BaseCurrentPostCode = value;
                    mainFrame.Save();
                }
                else
                {
                    _BaseCurrentPostCode = value;
                }
            }
        }

        private static bool _Successor = false;
        public static bool Successor
        {
            get
            {
                if (IsWeb())
                {
                    return WebClassLibrary.SessionManager.Current.MainFrame.Successor;
                }
                else
                {
                    return _Successor;
                }
            }
            set
            {
                if (IsWeb())
                {
                    WebClassLibrary.JMainFrame mainFrame = WebClassLibrary.SessionManager.Current.MainFrame;
                    mainFrame.Successor = value;
                    mainFrame.Save();
                }
                else
                {
                    _Successor = value;
                }
            }
        }

        private static string _BaseCurrentPostTitle = "";
        public static string BaseCurrentPostTitle
        {
            get
            {
                if (IsWeb())
                {
                    return WebClassLibrary.SessionManager.Current.MainFrame.BaseCurrentPostTitle;
                }
                else
                {
                    return _BaseCurrentPostTitle;
                }
            }
            set
            {
                if (IsWeb())
                {
                    WebClassLibrary.JMainFrame mainFrame = WebClassLibrary.SessionManager.Current.MainFrame;
                    mainFrame.BaseCurrentPostTitle = value;
                    mainFrame.Save();
                }
                else
                {
                    _BaseCurrentPostTitle = value;
                }
            }
        }

        private static JDataBase _GlobalDataBase;
        public static JDataBase GlobalDataBase
        {
            get
            {
                if (IsWeb())
                {
                    return WebClassLibrary.SessionManager.Current.MainFrame.GlobalDataBase;
                }
                else
                {
                    if (_GlobalDataBase == null)
                        _GlobalDataBase = new JDataBase();
                    return _GlobalDataBase;
                }
            }
        }
        public static string hdlock="1";
        public static string currentlock = "0";

        public static string Key = "";




        public JMainFrame()
        {
        }
        private static JConfig _Config;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JDataBase GetDBO()
        {
            JDataBase DB = new JDataBase();
            return DB;
        }

        public JDataBase GetSharesDB()
        {
            JConfig DC = new JConfig();
            DC.Server = GetConfig().ServerSaham;
            DC.Database = GetConfig().DatabaseSaham; //"newsahamdatabase";
            DC.Username = GetConfig().UsernameSaham; //"sa";
            DC.Password = GetConfig().PasswordSaham;
            
            JDataBase DB = new JDataBase(DC);
            return DB;
        }

        public JDataBase GetArchiveDB()
        {
            JConfig DC = new JConfig();
            DC.Server = GetConfig().ServerArchive;
            DC.Database = GetConfig().DatabaseArchive; //"newsahamdatabase";
            DC.Username = GetConfig().UsernameArchive; //"sa";
            DC.Password = GetConfig().PasswordArchive;

            JDataBase DB = new JDataBase(DC);
            return DB;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JConfig GetConfig()
        {
            if (_Config == null)
                _Config = new JConfig();
            return _Config;
        }
        /// <summary>
        ///  جستجوی اطلاعات کاربر بر اساس کد پرسنلی
        /// </summary>
        /// <returns></returns>

        public void SetCurrentUser(int pCode)
        {
            _CurrentUserCode = pCode;
        }
        /// <summary>
        /// کد چارت فعال را بر میگرداند
        /// </summary>
        public static int GetActiveChartCode()
        {
            //JDataBase db = new JDataBase();
            //try
            //{
            //    db.setQuery("Select * from charts  Where is_active = 1 order by Code Desc ");
            //    DataTable charts = db.Query_DataTable();
            //    if (charts.Rows.Count == 0)
            //    {
            //        JMessages.Error("چارت فعالی در سیستم تعریف نشده است", "Error");
            //        return 0;
            //    }
            //    else
            //    {
            //        return Convert.ToInt32(charts.Rows[0]["Code"]);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    JSystem.Except.AddException(ex);
            //    return 0;
            //}
            return 5;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="EnumType"></param>
        /// <param name="TheListBox"></param>
        public static JKeyValue[] EnumToListBox(Type EnumType)
        {
            Array Values = System.Enum.GetValues(EnumType);
            JKeyValue[] L = new JKeyValue[Values.Length];
            int count = 0;
            foreach (int Value in Values)
            {
                string Display = JLanguages._Text(Enum.GetName(EnumType, Value));
                L[count] = new JKeyValue();
                L[count].Key = Display;
                L[count].Value = Value;
                count++;
            }
            return L;

        }


        public static JKeyValue[] EnumToListBoxKey(Type EnumType)
        {
            Array Values = System.Enum.GetValues(EnumType);
            JKeyValue[] L = new JKeyValue[Values.Length];
            int count = 0;
            foreach (int Value in Values)
            {
                string Display = JLanguages._Text(Enum.GetName(EnumType, Value));
                L[count] = new JKeyValue();
                L[count].Key = Display;
                L[count].Value = Enum.GetName(EnumType, Value);
                count++;
            }
            return L;

        }


        public static string GetKey(int[] pkey)
        {
            string[] sKey = new string[pkey.Length];
            for (int i = 0; i < pkey.Length; i++)
            {
                //if ((i + 1) % 2 == 1)
                 //   pkey[i]--;
                sKey[i] = pkey[i].ToString();
            }
            return String.Join(".", sKey);
        }

        public static bool Check()
        {
            return JFreeClass.Check();
        }

        public static bool _IsAndroid = false;
       public static bool IsAndroid
        {
            get
            {
                return _IsAndroid;
            }

            set
            {
                _IsAndroid = value;
            }
        }
        public static bool IsWeb()
        {
            try
            {
                return System.Web.HttpRuntime.AppDomainAppId != null;
            }
            catch
            {
                return false;
            }
        }

		public static void SetKeyValue(string pName, Object pValue)
		{
			try
			{
				_KeyValue.Remove(pName);
			}
			catch
			{
			}

			try
			{
				_KeyValue.Add(pName, pValue);
			}
			catch
			{
			}
		}
		public static Object GetKeyValue(string pName)
		{
			Object Values;
			if( _KeyValue.TryGetValue(pName,out Values))
				return Values;
			return null;
		}
	}

    public class JKeyValue
    {
        public string Key;
        public object Value;

        public override string ToString()
        {
            try
            {
                return JLanguages._Text(Key);
            }
            catch
            {
                return Key;
            }
        }

    }


}
