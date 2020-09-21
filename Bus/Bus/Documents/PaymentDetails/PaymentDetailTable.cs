using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.Documents
{
    public class JAUTPaymentDetailTable:JTable
    {
        public JAUTPaymentDetailTable()
            : base("AUTPaymentDetail")
        {

        }
        #region Properties
        /// <summary>
        /// کد پرداخت
        /// </summary>
        public int PaymentCode;
        /// <summary>
        /// کد مالک
        /// </summary>
        public int OwnerPCode;
        /// <summary>
        /// کد اتوبوس
        /// </summary>
        public int BusCode; 
        /// <summary>
        /// مبلغ پرداخت شده
        /// </summary>
        public decimal TotalPrice;
        /// <summary>
        /// مبلغ قابل پرداخت
        /// </summary>
        public decimal PaymentPrice;
        #endregion Properties
    }
}
