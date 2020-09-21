using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JStaticDate
    {
        /// <summary>
        /// تاریخ میلادی
        /// </summary>
        public DateTime En_Date
        {
            get;
            set;
        }
        /// <summary>
        /// تاریخ شمسی
        /// </summary>
        public string Fa_Date
        {
            get;
            set;
        }
        /// <summary>
        /// تاریخ قمری
        /// </summary>
        public string Ar_Date
        {
            get;
            set;
        }

        public bool Insert()
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery(" SELECT COUNT(*) FROM " + JTableNamesClassLibrary.StaticDates + " WHERE " + JStaticDatesEnum.En_Date.ToString() + "= '" + En_Date.ToString("yyyy/MM/dd") + "' AND " + JStaticDatesEnum.Fa_Date.ToString() + "='" + JDateTime.FarsiDate(En_Date) + "'");
                int count = (int)DB.Query_ExecutSacler();
                if (count > 0)
                    return false;
                DB.setQuery(" INSERT INTO " + JTableNamesClassLibrary.StaticDates + " (" + JStaticDatesEnum.En_Date.ToString() + ", "
                    + JStaticDatesEnum.Fa_Date.ToString() + ") VALUES (@En_Date, @Fa_Date)");
                DB.Params["En_Date"] = En_Date;
                DB.Params["Fa_Date"] = JDateTime.FarsiDate(En_Date);
                int res = DB.Query_Execute();
                return (res > 0);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }
        public static bool InsertAll(DateTime pFromDate, DateTime pToDate)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            JStaticDate date = new JStaticDate();
            date.En_Date = pFromDate;
            //DateTime dtTemp = date.En_Date;
            //TimeSpan span= pToDate.Subtract(pFromDate);
            while (DateTime.Compare(pFromDate, pToDate) <= 0)
            //for (int i=span.Days; ; i++)
            {
                date.Insert();
                pFromDate = pFromDate.AddDays(1);
                date.En_Date = pFromDate;
            }
            return true;
        }
    }


    public enum JStaticDatesEnum
    {
        En_Date, Fa_Date, Ar_Date
    }
}
