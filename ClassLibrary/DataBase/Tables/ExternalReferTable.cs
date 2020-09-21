using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Automation
{
    class JExternalReferTable : JTable
    {
        #region Properties        
        /// <summary>
        /// کد ارجاع
        /// </summary>
        public int Refer_Code { get; set; }
        /// <summary>
        /// گیرنده کد
        /// </summary>
        public int receiver_external_code { get; set; }
        /// <summary>
        /// نام گیرنده
        /// </summary>
        public string receiver_full_title { get; set; }
        /// <summary>
        /// کد
        /// </summary>
        public int Send_Type { get; set; }
        /// <summary>
        /// کد
        /// </summary>
        public DateTime Send_Date { get; set; }
        /// <summary>
        /// کد
        /// </summary>
        public bool ConfirmReceiver { get; set; }
        /// <summary>
        /// کد
        /// </summary>
        public string Description { get; set; }
        #endregion

        public JExternalReferTable() :
            base(JTableNamesAutomation.ExternalRefer, "")
        {
        }
    }
    public enum ExternalRefer
    {
         #region Properties
  
        Code,
        /// <summary>
        ///کد ارجاع 
        /// </summary>
        Refer_Code,
        /// <summary>
        ///گیرنده کد
        /// </summary>
        receiver_external_code,
        /// <summary>
        /// نام گیرنده
        /// </summary>
        receiver_full_title,
        /// <summary>
        /// نوع ارسال
        /// </summary>
        Send_Type,
        /// <summary>
        /// تاریخ ارسال
        /// </summary>
        Send_Date,
        /// <summary>
        /// تایید دریافت گیرنده
        /// </summary>
        ConfirmReceiver,
        /// <summary>
        /// توضیحات
        /// </summary>
        Description,
        #endregion
    }
}

