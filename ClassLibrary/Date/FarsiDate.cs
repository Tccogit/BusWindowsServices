using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace ClassLibrary
{
    /// <summary>
    /// کلاس مربوط به تاریخ 
    /// </summary>
    public class JDateTime : JSystem
    {
        public JDateTime()
        {
        }

        public static string FarsiDate(DateTime date)
        {
            if (date == DateTime.MinValue)
                return "";

            string strDate = "";
            try
            {
                PersianCalendar calendar = new PersianCalendar();
                strDate = calendar.GetYear(date).ToString() + "/";
                if (calendar.GetMonth(date).ToString().Length < 2)
                    strDate += "0";
                strDate += calendar.GetMonth(date).ToString() + "/";

                if (calendar.GetDayOfMonth(date).ToString().Length < 2)
                    strDate += "0";
                strDate += calendar.GetDayOfMonth(date).ToString();
                if (date.Hour + date.Minute + date.Second > 0)
                    strDate += " " + date.ToString("HH:mm:ss");

            }
            catch
            {
                strDate = "";
            }
            return strDate;
        }

        public static string FarsiDateReverse(DateTime date)
        {
            if (date == DateTime.MinValue)
                return "";

            string strDate = "";
            try
            {
                PersianCalendar calendar = new PersianCalendar();
                if (date.Hour + date.Minute + date.Second > 0)
                    strDate += date.ToString("HH:mm:ss") + "   ";

                strDate += calendar.GetDayOfMonth(date).ToString() + "/";
                if (calendar.GetMonth(date).ToString().Length < 2)
                    strDate += "0";
                strDate += calendar.GetMonth(date).ToString() + "/";

                if (calendar.GetDayOfMonth(date).ToString().Length < 2)
                    strDate += "0";
                strDate += calendar.GetYear(date).ToString() ;

            }
            catch
            {
                strDate = "";
            }
            return strDate;
        }


        public static string FarsiYear(DateTime pDate)
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            return pc.GetYear(pDate).ToString();
        }

        public static string FarsiMonth(DateTime pDate)
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            return pc.GetMonth(pDate).ToString();
        }
        public static string FarsiDayInMonth(DateTime pDate)
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            return pc.GetDayOfMonth(pDate).ToString();
        }

        public static string FarsiDay(DateTime pDate)
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();

            switch (pc.GetDayOfWeek(pDate))
            {
                case DayOfWeek.Saturday:
                    return "شنبه";
                    break;
                case DayOfWeek.Sunday:
                    return "یکشنبه";
                    break;
                case DayOfWeek.Monday:
                    return "دوشنبه";
                    break;
                case DayOfWeek.Tuesday:
                    return "سه شنبه";
                    break;
                case DayOfWeek.Wednesday:
                    return "چهارشنبه";
                    break;
                case DayOfWeek.Thursday:
                    return "پنجشنبه";
                    break;
                case DayOfWeek.Friday:
                    return "جمعه";
                    break;
            }
            return "";
        }

        public static string StringDate(string pFarsiDate)
        {
            if (JDateTime.GregorianDate(pFarsiDate) == DateTime.MinValue)
            {
                return "";
            }
            else
            {
				string Year = JMoney.NumberToString(pFarsiDate.Split('-', '/')[0]);
				string Month = pFarsiDate.Split('-', '/')[1];
                string Day = JMoney.NumberToString(pFarsiDate.Split('/')[2]);
                switch (Convert.ToInt32(Month))
                {
                    case 1:
                        Month = "فروردین";
                        break;
                    case 2:
                        Month = "اردیبهشت";
                        break;
                    case 3:
                        Month = "خرداد";
                        break;
                    case 4:
                        Month = "تیر";
                        break;
                    case 5:
                        Month = "مرداد";
                        break;
                    case 6:
                        Month = "شهریور";
                        break;
                    case 7:
                        Month = "مهر";
                        break;
                    case 8:
                        Month = "آبان";
                        break;
                    case 9:
                        Month = "آذر";
                        break;
                    case 10:
                        Month = "دی";
                        break;
                    case 11:
                        Month = "بهمن";
                        break;
                    case 12:
                        Month = "اسفند";
                        break;
                    default:
                        Month = "";
                        break;
                }
                return Day + " " + Month + " " + Year;
            }
        }

        public static string AddMonthFarsi(string pFfarsiDate, int pValue)
        {
            try
            {
                int Year = Convert.ToInt32(pFfarsiDate.Split('-','/')[0]);
				int Month = Convert.ToInt32(pFfarsiDate.Split('-', '/')[1]);
				int Day = Convert.ToInt32(pFfarsiDate.Split('-', '/')[2]);

                Month = Month + pValue;

                if (Month > 12)
                {
                    Year = Year + (Month / 12);
                    Month = Month % 12;
                    if (Month == 0)
                    {
                        Month = 12;
                        Year--;
                    }
                }
                string strTemp = Year.ToString() + "/" + (Month >= 10 ? Month.ToString() : "0" + Month.ToString()) + "/" + (Day >= 10 ? Day.ToString() : "0" + Day.ToString());
                /// در صورتی که تاریخ بدست آمده معتبر نباشد یک روز به تاریخ اضافه میشود
                bool Checked = false;
                while (GregorianDate(strTemp) == DateTime.MinValue)
                {
                    Day++;
                    if (Day > 31)
                    {
                        Day = 1;
                        if (!Checked)
                        {
                            Checked = true;
                            Month++;
                            if (Month > 12)
                            {
                                Month = 1;
                                Year++;
                            }
                        }
                    }
                    strTemp = FarsiDate(GregorianDate(Year.ToString() + "/" + (Month >= 10 ? Month.ToString() : "0" + Month.ToString()) + "/" + (Day >= 10 ? (Day).ToString() : "0" + (Day).ToString())));
                }
                return (strTemp);
            }
            catch
            {
                return ("");
            }
        }


        public static DateTime GregorianDate(string farsiDate)
        {
            return GregorianDate(farsiDate, "0:0:0");
        }

        public static DateTime GregorianDate(string farsiDate, string time)
        {
            PersianCalendar calendar = new PersianCalendar();
            try
            {
				int Year = Convert.ToInt32(farsiDate.Split('-', '/',' ',':')[0]);
				int Month = Convert.ToInt32(farsiDate.Split('-', '/', ' ', ':')[1]);
				int Day = Convert.ToInt32(farsiDate.Split('-', '/', ' ', ':')[2]);

                int Hour = 0;
                int Minute = 0;
                int Second = 0;

                try
                {
                    Hour = Convert.ToInt32(time.Split(':')[0]);
                    Minute = Convert.ToInt32(time.Split(':')[1]);
                    Second = Convert.ToInt32(time.Split(':')[2]);
                }
                catch
                {
                }
                DateTime D =  calendar.ToDateTime(Year, Month, Day, Hour, Minute, Second, 0);
				return D;
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        public static DateTime GregorianDate(int Year, int Month, int Day)
        {
            try
            {
                PersianCalendar calendar = new PersianCalendar();
                return calendar.ToDateTime(Year, Month, Day, 0, 0, 0, 0);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        public DateTime toDay
        {
            get
            {
                return Now();
            }
        }

        public static DateTime Now()
        {
            return DateTime.Now;
            JDataBase Db = new JDataBase();
            try
            {
                return Db.GetCurrentDateTime();
            }
            finally
            {
                Db.Dispose();
            }
        }

        public static DateTime Now(JDataBase Db)
        {
            try
            {
                return Db.GetCurrentDateTime();
            }
            finally
            {
            }
        }
        public static string GetStringTime(DateTime time)
        {
            int h = time.Hour;
            int m = time.Minute;
            string strH = h < 10 ? "0" + h.ToString() : h.ToString();
            string strM = m < 10 ? "0" + m.ToString() : m.ToString();
            return strH + ":" + strM;
        }
    }
}
