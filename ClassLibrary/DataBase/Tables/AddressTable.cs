
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    class JPersonAddressTable : JTable
    {
        /// <summary>
        /// کد شخص
        /// </summary>
        public int PCode;
        /// <summary>
        /// نوع آدرس
        /// </summary>
        public int AddressType;
        /// <summary>
        /// شهر  
        /// </summary>
        public int City;
        /// آدرس  
        /// </summary>
        public string Address;
        /// <summary>
        /// کد پستی
        /// </summary>
        public string PostalCode;
        /// <summary>
        /// تلفن 
        /// </summary>
        public string Tel;
        /// <summary>
        /// فکس
        /// </summary>
        public string Fax;
        /// <summary>
        /// تلفن همراه
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
        public JPersonAddressTable()
            : base(JTableNamesClassLibrary.PersonAddress)
        {


        }
    }
}