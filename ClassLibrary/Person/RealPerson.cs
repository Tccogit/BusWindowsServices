using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JRealPerson:JSystem
    {
        /// <summary>
        /// کد فرد 
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public int PCode { get; set; }
        /// <summary>
        /// نام
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// نام خانوادگی
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FatherName { get; set; }
        /// <summary>
        /// شماره شناسنامه
        /// </summary>
        public string IDNo { get; set; }
        /// <summary>
        /// کد محل تولد
        /// </summary>
        public int BirthPlaceCode { get; set; }
        /// <summary>
        /// تاریخ تولد
        /// </summary>
        public string BirthDate { get; set; }
        /// <summary>
        /// محل صدور شناسنامه 
        /// </summary>
        public int IssuPlaceCode { get; set; }
        /// <summary>
        /// شماره ملی
        /// </summary>
        public string NationalCode { get; set; }
        /// <summary>
        /// جنسیت
        /// </summary>
        public bool Gender { get; set; }
    }
}
