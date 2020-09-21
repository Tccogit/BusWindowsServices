//test
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassLibrary
{
    enum JKeyName
    {
        zarrinderafsh,
        EPAD,
    }
    public class JMainFrame : JCore
    {
        public static int Terminated = 0;
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
                if (_CurrentUserCode < 1)
                    return 0;
                return _CurrentUserCode;
            }
            set
            {
                _CurrentUserCode = value;
            }
        }
        public static int CurrentPersonCode = 0;
        public static int CurrentPostCode = 0;
        public static string CurrentPostTitle = "";

        public static string KeyName = JKeyName.EPAD.ToString();
        private static JDataBase _GlobalDataBase;
        public static JDataBase GlobalDataBase
        {
            get
            {
                if (_GlobalDataBase == null)
                    _GlobalDataBase = new JDataBase();
                return _GlobalDataBase;
            }
        }

        public JMainFrame()
        {
        }
        private JConfig _Config;
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
#warning 'چارت فعال محاسبه شود و جایگزین خروجی شود'
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
                string Display = Enum.GetName(EnumType, Value);
                L[count] = new JKeyValue();
                L[count].Key = Display;
                L[count].Value = Value;
                count++;
            }
            return L;

        }

        public static string GetKey(int[] pkey)
        {
            string[] sKey = new string[pkey.Length];
            for (int i = 0; i < pkey.Length; i++)
            {
                if ((i + 1) % 2 == 1)
                    pkey[i]--;
                sKey[i] = pkey[i].ToString();
            }
            return String.Join(".", sKey);
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
