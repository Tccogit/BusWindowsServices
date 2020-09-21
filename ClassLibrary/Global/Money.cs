using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// کلاسی شامل توابع مربوط به اعداد پولی
    /// </summary>
    public class JMoney
    {
        #region Functions
        /// <summary>
        /// تبدیل فرمت پول به عدد
        /// </summary>
        /// <param name="Money"></param>
        /// <returns></returns>
        public static string RemoveMoney(string Money)
        {
            string TempStr = Money;
            TempStr = TempStr.Replace(",", "");
            //for (int i = 0; i < TempStr.Length; i++)
            //    if ((TempStr[i] == ',')) //|| (TempStr[i] == '-')
            //        TempStr = TempStr.Remove(i, 1);
            return TempStr;
        }

        /// <summary>
        /// تبدیل عدد به فرمت پولی
        /// </summary>
        /// <param name="pDigit"></param>
        /// <returns></returns>
        public static string DecimalToMoney(decimal pDigit)
        {
            string Money = decimal.Round(pDigit, 0).ToString();
            return StringToMoney(Money);
        }
        /// <summary>
        /// تبدیل رشته به فرمت پولی
        /// </summary>
        /// <param name="Money"></param>
        /// <returns></returns>
        public static string StringToMoney(string pInputStr)
        {
            try {
                string str = "";
                if (pInputStr.IndexOf('.') != -1)
                {
                    str = pInputStr.Substring(pInputStr.IndexOf('.'), pInputStr.Length - pInputStr.IndexOf('.'));
                    pInputStr = pInputStr.Substring(0, pInputStr.IndexOf('.'));
                }
                if (pInputStr.StartsWith("-"))
                {
                    pInputStr = pInputStr.Remove(0, 1);
                    while (pInputStr.StartsWith("0"))
                        pInputStr = pInputStr.Remove(0, 1);
                    if (pInputStr.Length <= 3)
                        return "-" + pInputStr;
                    int CountCamma = (pInputStr.Length / 3);
                    if ((pInputStr.Length % 3) == 0) CountCamma -= 1;
                    string TempStr = pInputStr;
                    for (int i = pInputStr.Length - 3; i > 0; i -= 3)
                    {
                        TempStr = TempStr.Insert(i, ",");
                    }
                    return ("-" + TempStr);
                }
                else
                {
                    while (pInputStr.StartsWith("00"))
                        pInputStr = pInputStr.Remove(0, 1);
                    if (pInputStr.Length <= 3)
                        return pInputStr;
                    int CountCamma = (pInputStr.Length / 3);
                    //if (Money.StartsWith("-"))
                    //    CountCamma--;
                    if ((pInputStr.Length % 3) == 0) CountCamma -= 1;
                    string TempStr = pInputStr;
                    for (int i = pInputStr.Length - 3; i > 0; i -= 3)
                    {
                        TempStr = TempStr.Insert(i, ",");
                    }
                    return TempStr + str;
                    //if (str == "")
                    //    return TempStr;
                    //else
                    //    return TempStr +"." + str; 
                }
            }
            catch
            {
                return pInputStr;
            }
        }

        /// <summary>
        /// تبدیل عدد به حروف
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        public static string NumberToString(string Number)
        {
            if (Number.Contains(","))
                Number = RemoveMoney(Number);
            bool Negative = false;
            string NumString = "";
            if (Number.StartsWith("-"))
            {
                Number = Number.Remove(0, 1);
                Negative = true;
            }
            if (Number.Contains("."))
                return NumberToString(Number.Split('.')[0]) + " ممیز " + NumberToString(Number.Split('.')[1]);
            while (Number.StartsWith("0"))
            {
                //if (Number == "0")
                //  return "صفر";
                Number = Number.Remove(0, 1);
            }
            if (Number == "")
                return NumString;

            Int64 num = Convert.ToInt64(Number);

            if (Number.Length >= 13 && Number.Length <= 15)////////تریلیون
                if (Number.Length % 3 != 0)
                    if (num % 1000000000000 == 0)
                        NumString = (GetString3(Number.Substring(0, Number.Length % 3))) + "تریلیون " + NumberToString(Number.Substring(Number.Length % 3));
                    else
                        NumString = (GetString3(Number.Substring(0, Number.Length % 3))) + "تریلیون و " + NumberToString(Number.Substring(Number.Length % 3));
                else
                    if (Number.Substring(0, 3) != "000")
                        if (num % 1000000000 == 0)
                            NumString = (GetString3(Number.Substring(0, 3))) + "تریلیون " + NumberToString(Number.Substring(3));
                        else
                            NumString = (GetString3(Number.Substring(0, 3))) + "تریلیون و " + NumberToString(Number.Substring(3));
                    else
                        NumString = (GetString3(Number.Substring(0, 3))) + NumberToString(Number.Substring(3));

            if (Number.Length >= 10 && Number.Length <= 12)////////میلیارد
                if (Number.Length % 3 != 0)
                    if (num % 1000000000 == 0)
                        NumString = (GetString3(Number.Substring(0, Number.Length % 3))) + "میلیارد " + NumberToString(Number.Substring(Number.Length % 3));
                    else
                        NumString = (GetString3(Number.Substring(0, Number.Length % 3))) + "میلیارد و " + NumberToString(Number.Substring(Number.Length % 3));
                else
                    if (Number.Substring(0, 3) != "000")
                        if (num % 1000000000 == 0)
                            NumString = (GetString3(Number.Substring(0, 3))) + "میلیارد " + NumberToString(Number.Substring(3));
                        else
                            NumString = (GetString3(Number.Substring(0, 3))) + "میلیارد و " + NumberToString(Number.Substring(3));
                    else
                        NumString = (GetString3(Number.Substring(0, 3))) + NumberToString(Number.Substring(3));

            if (Number.Length >= 7 && Number.Length <= 9)//میلیون
                if (Number.Length % 3 != 0)
                    if (num % 1000000 == 0)
                        NumString = (GetString3(Number.Substring(0, Number.Length % 3))) + "میلیون " + NumberToString(Number.Substring(Number.Length % 3));
                    else
                        NumString = (GetString3(Number.Substring(0, Number.Length % 3))) + "میلیون و " + NumberToString(Number.Substring(Number.Length % 3));
                else
                    if (Number.Substring(0, 3) != "000")
                        if (num % 1000000 == 0)
                            NumString = (GetString3(Number.Substring(0, 3))) + "میلیون " + NumberToString(Number.Substring(3));
                        else
                            NumString = (GetString3(Number.Substring(0, 3))) + "میلیون و " + NumberToString(Number.Substring(3));
                    else
                        NumString = (GetString3(Number.Substring(0, 3))) + NumberToString(Number.Substring(3));

            if (Number.Length >= 4 && Number.Length <= 6)//هزار
                if (Number.Length % 3 != 0)
                    if (num % 1000 == 0)
                        NumString = (GetString3(Number.Substring(0, Number.Length % 3))) + "هزار " + NumberToString(Number.Substring(Number.Length % 3));
                    else
                        NumString = (GetString3(Number.Substring(0, Number.Length % 3))) + "هزار و " + NumberToString(Number.Substring(Number.Length % 3));
                else
                    if (Number.Substring(0, 3) != "000")
                        if (num % 1000 == 0)
                            NumString = (GetString3(Number.Substring(0, 3))) + "هزار " + NumberToString(Number.Substring(3));
                        else
                            NumString = (GetString3(Number.Substring(0, 3))) + "هزار و " + NumberToString(Number.Substring(3));
                    else
                        NumString = (GetString3(Number.Substring(0, 3))) + NumberToString(Number.Substring(3));

            if (Number.Length < 4 && Number != "")//<1000
                NumString = (GetString3(Number));
            if (Number == "")
                NumString = "";

            if (Negative)
                return "منفی " + NumString;
            return NumString;
        }
        #endregion Functions

        #region GET STRING of NUMBER
        private static string GetString1(int Number)
        {
            string NumString;
            switch (Number)
            {
                case 1:
                    NumString = "یک ";
                    break;
                case 2:
                    NumString = "دو ";
                    break;
                case 3:
                    NumString = "سه ";
                    break;
                case 4:
                    NumString = "چهار ";
                    break;
                case 5:
                    NumString = "پنج ";
                    break;
                case 6:
                    NumString = "شش ";
                    break;
                case 7:
                    NumString = "هفت ";
                    break;
                case 8:
                    NumString = "هشت ";
                    break;
                case 9:
                    NumString = "نه ";
                    break;
                default:
                    NumString = "";
                    break;
            }
            return NumString;
        }
        private static string GetString2(string Number)
        {
            string NumString = "";
            int num = Convert.ToInt16(Number);
            if (num < 20)
            {
                switch (num)
                {
                    case 10:
                        NumString = "ده ";
                        break;
                    case 11:
                        NumString = "یازده ";
                        break;
                    case 12:
                        NumString = "دوازده ";
                        break;
                    case 13:
                        NumString = "سیزده ";
                        break;
                    case 14:
                        NumString = "چهارده ";
                        break;
                    case 15:
                        NumString = "پانزده ";
                        break;
                    case 16:
                        NumString = "شانزده ";
                        break;
                    case 17:
                        NumString = "هفده ";
                        break;
                    case 18:
                        NumString = "هجده ";
                        break;
                    case 19:
                        NumString = "نوزده ";
                        break;
                    default:
                        NumString = "";
                        break;
                }
            }
            else
            {
                switch (num / 10)
                {
                    case 2:
                        NumString = "بیست ";
                        break;
                    case 3:
                        NumString = "سی ";
                        break;
                    case 4:
                        NumString = "چهل ";
                        break;
                    case 5:
                        NumString = "پنجاه ";
                        break;
                    case 6:
                        NumString = "شصت ";
                        break;
                    case 7:
                        NumString = "هفتاد ";
                        break;
                    case 8:
                        NumString = "هشتاد ";
                        break;
                    case 9:
                        NumString = "نود ";
                        break;
                    default:
                        NumString = "";
                        break;
                }
            }
            if (num > 20 && num % 10 != 0)
                NumString = NumString + "و " + GetString1(num % 10);
            else if (num < 10)
                NumString = GetString1(num % 10);
            return NumString;
        }
        private static string GetString3(string Number)
        {
            string NumString = "";
            int num = Convert.ToInt16(Number);
            switch (num / 100)
            {
                case 1:
                    NumString = "صد ";
                    break;
                case 2:
                    NumString = "دویست ";
                    break;
                case 3:
                    NumString = "سیصد ";
                    break;
                case 4:
                    NumString = "چهارصد ";
                    break;
                case 5:
                    NumString = "پانصد ";
                    break;
                case 6:
                    NumString = "ششصد ";
                    break;
                case 7:
                    NumString = "هفتصد ";
                    break;
                case 8:
                    NumString = "هشتصد ";
                    break;
                case 9:
                    NumString = "نهصد ";
                    break;
                default:
                    NumString = "";
                    break;
            }
            if (num >= 100)
            {
                //string tempStr = Number.Substring(1,2);
                string tempStr = (num % 100).ToString();
                if (num % 100 != 0)
                    NumString = NumString + "و " + GetString2(tempStr);
                else
                    NumString = NumString + GetString2(tempStr);
            }
            else
                NumString = GetString2(Number);
            return NumString;
        }
        
        #endregion
    }
}
