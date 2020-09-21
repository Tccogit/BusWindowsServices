using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JAddressTable : JTable
    {
        public JAddressTable()
            : base("clsPersonAddress")
        {
        }
        /// <summary>
        /// کد شخص
        /// </summary>
        public int PCode;
        /// <summary>
        /// نوع آدرس
        /// </summary>
        public JAddressTypes AddressType;
        /// <summary>
        /// آدرس
        /// </summary>
        public string Address;
        /// <summary>
        /// شهر
        /// </summary>
        public int City;
        /// <summary>
        /// کد پستی
        /// </summary>
        public string PostalCode;
        /// <summary>
        /// تلفن
        /// </summary>
        public string Tel;
        /// <summary>
        /// فاکس
        /// </summary>
        public string Fax;
        /// <summary>
        /// همراه
        /// </summary>
        public string Mobile;
        /// <summary>
        /// ایمیل
        /// </summary>
        public string Email;
        /// <summary>
        /// وب سایت
        /// </summary>
        public string WebSite;

        /// <summary>
        /// نام کلاس
        /// </summary>
        public string ClassName;

        /// <summary>
        /// کد
        /// </summary>
        public int ObjectCode;

         /// <summary>
        /// استان
        /// </summary>
        public int State;
    }
}
