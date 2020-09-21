using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JPersonTable: JTable
    {
        /// <summary>
        /// کد فرد 
        /// </summary>
        //public int Code;
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
        /// توضیحات
        /// </summary>
        public string PDesc;
        /// <summary>
        /// جنسیت
        /// </summary>
        public bool Gender;
        /// <summary>
        /// متوفی
        /// </summary>
        public bool Died;
        /// <summary>
        /// ممنوع المعامله
        /// </summary>
        public bool Blocked;
        /// <summary>
        /// 
        /// </summary>
        public int OldChangeName;
        /// <summary>
        /// 
        /// </summary>
        public int NewChangeName;

        /// <summary>
        /// کد تصویر شخص در سیستم بایگانی
        /// </summary>
        public int PersonImageCode;

        /// <summary>
        /// کد تصویر امضا در سیستم بایگانی
        /// </summary>
        public int SignatureImageCode;

        ///// <summary>
        ///// افراد تحت تکفل
        ///// </summary>
        //public int Suport ;
        ///// <summary>
        
        //public string Mobile ;
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
        /// <summary>
        /// ناقص بودن اطلاعات شخص
        /// </summary>
        public bool IncompleteInformation;

        public JPersonTable()
            : base(JTableNamesClassLibrary.PersonTable) // "person"
        {

        }    
    }


  public enum JPersonTableEnum
    {
        /// <summary>
        /// کد فرد 
        /// </summary>
        Code,
        /// <summary>
        /// نام
        /// </summary>
        Name,
        /// <summary>
        /// نام خانوادگی
        /// </summary>
        Fam,
        /// <summary>
        /// 
        /// </summary>
        FatherName,
        /// <summary>
        /// شماره شناسنامه
        /// </summary>
        ShSh,
        /// <summary>
        /// کد محل تولد
        /// </summary>
        BirthplaceCode,
        /// <summary>
        /// تاریخ تولد
        /// </summary>
        BthDate,
        /// <summary>
        /// محل صدور شناسنامه 
        /// </summary>
        Sader,
        /// <summary>
        /// شماره ملی
        /// </summary>
        ShMeli,
        /// <summary>
        /// جنسیت
        /// </summary>
        Gender,
        /// <summary>
        /// متوفی
        /// </summary>
        Died,
        /// <summary>
        /// ممنوع المعامله
        /// </summary>
        Blocked,
      /// <summary>
      /// ناقص بودن اطلاعات شخص
      /// </summary>
      IncompleteInformation,

    }

}
