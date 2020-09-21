using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JOtherPersonsTable :JTable
    {
        public JOtherPersonsTable()
            : base(JTableNamesClassLibrary.OtherPerson)
        {
        }
        /// <summary>
        /// نام
        /// </summary>
        public string Title;
        /// <summary>
        /// شماره تلفن
        /// </summary>
        public string Phone;
        /// <summary>
        /// آدرس
        /// </summary>
        public string Address;
        /// <summary>
        /// سایر توضیحات
        /// </summary>
        public string Description;
    }
}
