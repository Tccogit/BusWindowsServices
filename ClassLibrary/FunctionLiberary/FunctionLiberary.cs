using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    class JFunctionLiberary
    {
        /// <summary>
        /// تست عدد بودن یک نوع آبجکت
        /// </summary>
        /// <param name="pValue">مقدار</param>
        /// <returns>bool</returns>
        public static bool is_Number(object pValue)
        {
            try
            {
                int test = Convert.ToInt32(pValue);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
