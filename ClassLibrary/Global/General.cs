using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JGeneral :JSystem
    {
        #region GET STRING of NUMBER
        /// <summary>
        /// عدد را بصورت سه رقم جدا برمیگرداند
        /// </summary>
        /// <param name="Money"></param>
        /// <returns></returns>
        public static string MoneyStr(string Money)
        {
            if (Money.StartsWith("-"))
            {
                Money = Money.Remove(0, 1);
                while (Money.StartsWith("0"))
                    Money = Money.Remove(0, 1);
                if (Money.Length <= 3)
                    return "-" + Money;
                int CountCamma = (Money.Length / 3);
                if ((Money.Length % 3) == 0) CountCamma -= 1;
                string TempStr = Money;
                for (int i = Money.Length - 3; i > 0; i -= 3)
                {
                    TempStr = TempStr.Insert(i, ",");
                }
                return ("-" + TempStr);
            }
            else
            {
                if (Money == "0")
                    return "0";
                while (Money.StartsWith("0"))
                    Money = Money.Remove(0, 1);
                if (Money.Length <= 3)
                    return Money;
                int CountCamma = (Money.Length / 3);
                //if (Money.StartsWith("-"))
                //    CountCamma--;
                if ((Money.Length % 3) == 0) CountCamma -= 1;
                string TempStr = Money;
                for (int i = Money.Length - 3; i > 0; i -= 3)
                {
                    TempStr = TempStr.Insert(i, ",");
                }
                return TempStr;
            }
        }        
        private string GetString1(int Number)
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
        private string GetString2(string Number)
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
        private string GetString3(string Number)
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
        /// <summary>
        /// عدد را بصورت حروف برمیگرداند
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        public string GetStringNumber(string Number)
        {
            bool Negative = false;
            string NumString = "";
            if (Number.StartsWith("-"))
            {
                Number = Number.Remove(0, 1);
                Negative = true;
            }
            if (Number.Contains("."))
                return GetStringNumber(Number.Split('.')[0]) + " ممیز " + GetStringNumber(Number.Split('.')[1]);
            if (Number.Contains("/"))
                return GetStringNumber(Number.Split('/')[0]) + " ممیز " + GetStringNumber(Number.Split('/')[1]);

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
                        NumString = (GetString3(Number.Substring(0, Number.Length % 3))) + "تریلیون " + GetStringNumber(Number.Substring(Number.Length % 3));
                    else
                        NumString = (GetString3(Number.Substring(0, Number.Length % 3))) + "تریلیون و " + GetStringNumber(Number.Substring(Number.Length % 3));
                else
                    if (Number.Substring(0, 3) != "000")
                        if (num % 1000000000 == 0)
                            NumString = (GetString3(Number.Substring(0, 3))) + "تریلیون " + GetStringNumber(Number.Substring(3));
                        else
                            NumString = (GetString3(Number.Substring(0, 3))) + "تریلیون و " + GetStringNumber(Number.Substring(3));
                    else
                        NumString = (GetString3(Number.Substring(0, 3))) + GetStringNumber(Number.Substring(3));

            if (Number.Length >= 10 && Number.Length <= 12)////////میلیارد
                if (Number.Length % 3 != 0)
                    if (num % 1000000000 == 0)
                        NumString = (GetString3(Number.Substring(0, Number.Length % 3))) + "میلیارد " + GetStringNumber(Number.Substring(Number.Length % 3));
                    else
                        NumString = (GetString3(Number.Substring(0, Number.Length % 3))) + "میلیارد و " + GetStringNumber(Number.Substring(Number.Length % 3));
                else
                    if (Number.Substring(0, 3) != "000")
                        if (num % 1000000000 == 0)
                            NumString = (GetString3(Number.Substring(0, 3))) + "میلیارد " + GetStringNumber(Number.Substring(3));
                        else
                            NumString = (GetString3(Number.Substring(0, 3))) + "میلیارد و " + GetStringNumber(Number.Substring(3));
                    else
                        NumString = (GetString3(Number.Substring(0, 3))) + GetStringNumber(Number.Substring(3));

            if (Number.Length >= 7 && Number.Length <= 9)//میلیون
                if (Number.Length % 3 != 0)
                    if (num % 1000000 == 0)
                        NumString = (GetString3(Number.Substring(0, Number.Length % 3))) + "میلیون " + GetStringNumber(Number.Substring(Number.Length % 3));
                    else
                        NumString = (GetString3(Number.Substring(0, Number.Length % 3))) + "میلیون و " + GetStringNumber(Number.Substring(Number.Length % 3));
                else
                    if (Number.Substring(0, 3) != "000")
                        if (num % 1000000 == 0)
                            NumString = (GetString3(Number.Substring(0, 3))) + "میلیون " + GetStringNumber(Number.Substring(3));
                        else
                            NumString = (GetString3(Number.Substring(0, 3))) + "میلیون و " + GetStringNumber(Number.Substring(3));
                    else
                        NumString = (GetString3(Number.Substring(0, 3))) + GetStringNumber(Number.Substring(3));

            if (Number.Length >= 4 && Number.Length <= 6)//هزار
                if (Number.Length % 3 != 0)
                    if (num % 1000 == 0)
                        NumString = (GetString3(Number.Substring(0, Number.Length % 3))) + "هزار " + GetStringNumber(Number.Substring(Number.Length % 3));
                    else
                        NumString = (GetString3(Number.Substring(0, Number.Length % 3))) + "هزار و " + GetStringNumber(Number.Substring(Number.Length % 3));
                else
                    if (Number.Substring(0, 3) != "000")
                        if (num % 1000 == 0)
                            NumString = (GetString3(Number.Substring(0, 3))) + "هزار " + GetStringNumber(Number.Substring(3));
                        else
                            NumString = (GetString3(Number.Substring(0, 3))) + "هزار و " + GetStringNumber(Number.Substring(3));
                    else
                        NumString = (GetString3(Number.Substring(0, 3))) + GetStringNumber(Number.Substring(3));

            if (Number.Length < 4 && Number != "")//<1000
                NumString = (GetString3(Number));
            if (Number == "")
                NumString = "";

            if (Negative)
                return "منفی " + NumString;
            return NumString;
        }
        #endregion

        /// <summary>
        /// تست عدد بودن یک نوع آبجکت
        /// </summary>
        /// <param name="pValue">مقدار</param>
        /// <returns>bool</returns>
        public static bool is_Number(object pValue)
        {
            try
            {
                double Num;
                bool test = double.TryParse(pValue.ToString().Replace(',','-'),out Num);
                return test;
            }
            catch
            {
                return false;
            }
        }


        public static byte[] StrToByteArray(string str)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            return encoding.GetBytes(str);
        }

        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        public static string ReverseDate(string s)
        {
            try
            {
                return s.Split('/')[2] + "/" + s.Split('/')[1] + "/" + s.Split('/')[0];
            }
            catch
            {
                return s;
            }
        }

        public static string ReverseNumber(string s,char pPoint)
        {
            try
            {
                return s.Split(pPoint)[1] + "/" + s.Split(pPoint)[0];
            }
            catch
            {
                return s;
            }
        }

        public static int StrintToNumber(string pS)
        {
            int Ret = 0;
            for (int i = 0; i < pS.Length; i++)
            {
                Ret += (int)pS[i];
            }
            return Ret;
        }

        public static Int64 GetInt64HashCode(string strText)
        {
            Int64 hashCode = 0;
            if (!string.IsNullOrEmpty(strText))
            {
                //Unicode Encode Covering all characterset
                byte[] byteContents = Encoding.Unicode.GetBytes(strText);
                System.Security.Cryptography.SHA256 hash =
                new System.Security.Cryptography.SHA256CryptoServiceProvider();
                byte[] hashText = hash.ComputeHash(byteContents);
                //32Byte hashText separate
                //hashCodeStart = 0~7  8Byte
                //hashCodeMedium = 8~23  8Byte
                //hashCodeEnd = 24~31  8Byte
                //and Fold
                Int64 hashCodeStart = BitConverter.ToInt64(hashText, 0);
                Int64 hashCodeMedium = BitConverter.ToInt64(hashText, 8);
                Int64 hashCodeEnd = BitConverter.ToInt64(hashText, 24);
                hashCode = hashCodeStart ^ hashCodeMedium ^ hashCodeEnd;
            }
            return (hashCode);
        }
        
        public static string ConvertToPersian(string pStr)
        {
            pStr = pStr.Replace('ي', 'ی');
            pStr = pStr.Replace("ي", "ی");
            pStr = pStr.Replace('ك', 'ک');
            return pStr;
        }

    }
}
