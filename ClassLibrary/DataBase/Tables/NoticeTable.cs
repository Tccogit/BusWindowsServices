using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ClassLibrary
{
    public class JNoticeTable : JTable
    {

        #region Property
        /// <summary>
        /// کد دادخواست یا شکواییه
        /// </summary>
        public int PetitionCode;
        /// <summary>
        /// کد فرد ارجاع کننده
        /// </summary>
        public int ReferPersonCode;
        /// <summary>
        /// تاریخ حضور
        /// </summary>
        public DateTime Date;
        /// <summary>
        /// ساعت حضور
        /// </summary>
        public string Time;
        /// <summary>
        /// علت حضور
        /// </summary>
        public string Reasons;
        /// <summary>
        /// نتیجه حضور
        /// </summary>
        public string Result;

        #endregion

        public JNoticeTable()
            : base(JTableNamesLegal.Notice)
        {

        }
    }

    public enum LegNotice
    {
        Code,
        /// <summary>
        /// کد دادخواست یا شکواییه
        /// </summary>
        PetitionCode,
        /// <summary>
        /// کد فرد ارجاع کننده
        /// </summary>
        ReferPersonCode,
        /// <summary>
        /// تاریخ حضور
        /// </summary>
        Date,
        /// <summary>
        /// ساعت حضور
        /// </summary>
        Time,
        /// <summary>
        /// علت حضور
        /// </summary>
        Reasons,
        /// <summary>
        /// نتیجه حضور
        /// </summary>
        Result,
    }
}
