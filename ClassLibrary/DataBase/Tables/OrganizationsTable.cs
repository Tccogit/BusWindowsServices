using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ClassLibrary 
{
    public class JOrganizationsTable : JTable
    {
        public string Name;
        public int ParentCode;
        public string Managing_Director;
        //public string phone_number;
        //public string address;
        public int Access_Code;
        public string Description;
        /// <summary>
        /// شماره ثبت
        /// </summary>
        public string RegisterNo;
        /// <summary>
        /// محل ثبت
        /// </summary>
        public int RegisterPlace;
        /// <summary>
        /// تاریخ ثبت
        /// </summary>
        public DateTime RegisterDate;
        /// <summary>
        /// موضوع
        /// </summary>
        public string Subject;
        /// <summary>
        /// نوع شرکت
        /// </summary>
        public int CompanyType;
        /// <summary>
        /// وضعیت (فعال - غیر فعال - ورشکسته - منحل شده) 
        /// </summary>
        public int Status;

        /// <summary>
        /// کد تصویر آرم در سیستم آرشیو
        /// </summary>
        public int ArmArchiveCode;
        /// <summary>
        /// شناسه ملی
        /// </summary>
        public string ShenaseMeli;
        /// <summary>
        /// کد اقتصادی شرکت
        /// </summary>
        public string CommercialCode;
        
        /// <summary>
        /// کانکشن استرینگ جهت اتصال به بانک اطلاعاتی شرکت
        /// </summary>
        public string ConnectionString;

        
        public JOrganizationsTable()
            : base(JTableNamesClassLibrary.LegalPerson,"ParentCode")
        {
        }
    }
    enum JOrganizationsTableEnum
    {
        Code,
        Name,
        ParentCode,
        Managing_Director,
        //phone_number,
        //address,
        Access_Code,
        Description,
        /// <summary>
        /// شماره ثبت
        /// </summary>
        RegisterNo,
        /// <summary>
        /// محل ثبت
        /// </summary>
        RegisterPlace,
        /// <summary>
        /// تاریخ ثبت
        /// </summary>
        RegisterDate,
        /// <summary>
        /// موضوع
        /// </summary>
        Subject,
        /// <summary>
        /// نوع شرکت
        /// </summary>
        CompanyType,
        /// <summary>
        /// وضعیت (فعال - غیر فعال - ورشکسته - منحل شده) 
        /// </summary>
        Status,
        /// <summary>
        /// کد تصویر آرم در سیستم آرشیو
        /// </summary>
        ArmArchiveCode,
    }

}
