using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    class JPersonTable: JTable
    {
        /// <summary>
        /// کد فرد 
        /// </summary>
       // public int Code = 0;
        /// <summary>
        /// نام
        /// </summary>
        public string Name;
        /// <summary>
        /// نام خانوادگی
        /// </summary>
        public string Fam;
        /// <summary>
        /// 
        /// </summary>
        public string FatherName;
        /// <summary>
        /// شماره شناسنامه
        /// </summary>
        public string ShSh ;
        /// <summary>
        /// کد محل تولد
        /// </summary>
        public int BirthplaceCode ;
        /// <summary>
        /// تاریخ تولد
        /// </summary>
        public DateTime BthDate;
        /// <summary>
        /// محل صدور شناسنامه 
        /// </summary>
        public int Sader ;
        /// <summary>
        /// شماره ملی
        /// </summary>
        public string ShMeli ;
        /// <summary>
        /// جنسیت
        /// </summary>
        public bool Gender;

        ///// <summary>
        ///// افراد تحت تکفل
        ///// </summary>
        //public int Suport ;
        ///// <summary>
        
        //public string Mobile ;
        ///// <summary>
        ///// متوفی 
        ///// </summary>
        //public bool Die ;
        ///// <summary>
        ///// ممنوع المعامله
        ///// </summary>
        //public bool Block ;
        ///// <summary>
        ///// تفصیلی
        ///// </summary>
        //public Int64 Detailed ;
        ///// <summary>
        ///// تاریخ فوت
        ///// </summary>
        //public DateTime DieDate ;
        ///// <summary>
        ///// تائید حقوقی جهت ثبت قراردادها
        ///// </summary>
        //public bool LegelConfirm;

        public JPersonTable()
            : base(JTableNamesClassLibrary.PersonTable) // "person"
        {

        }    
    }

    /// <summary>
    /// 
    /// </summary>
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
