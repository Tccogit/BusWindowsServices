using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.Documents
{
    public class JAUTPaymentTable :JTable
    {
        public JAUTPaymentTable()
            :base("AUTPayment")
        {
        }
        public DateTime PaymentDate;
        public string Description;
        public string Register_Full_Title;
        public int Register_Post_Code;
        public int Register_User_Code;
    }
}
