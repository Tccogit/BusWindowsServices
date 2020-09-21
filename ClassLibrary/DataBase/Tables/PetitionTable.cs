using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;


namespace ClassLibrary
{
    class JPetitionTable : JTable
    {

       #region Property

        /// <summary>
        /// شکوائیه / دادخواست
        /// </summary>
        public int Type;
        /// <summary>
        /// شماره دادخواست
        /// </summary>
        public string Number;
        /// <summary>
        /// تاریخ
        /// </summary>
        public DateTime Date;
        /// <summary>
        /// کد موضوع
        /// </summary>
        public int Subject_Code;
        /// <summary>
        /// کد دادگاه
        /// </summary>
        public int judicialCode;
        /// <summary>
        /// کد مقام ارجاع کننده
        /// </summary>
        public int PostReferCode;
        /// <summary>
        /// توضیحات درخواست
        /// </summary>
        public string RequestDescription;
        /// <summary>
        /// دلائل
        /// </summary>
        public string ReasonsDescription;

       #endregion

   public JPetitionTable()
   : base(JTableNamesLegal.Petition, "")
    {
    }

    }

    public enum LegPetition
    {
        
        #region Property
        Code,
        /// <summary>
        /// شکوائیه / دادخواست
        /// </summary>
        Type,
        /// <summary>
        /// شماره دادخواست
        /// </summary>
        Number,
        /// <summary>
        /// تاریخ
        /// </summary>
        Date,
        /// <summary>
        /// کد موضوع
        /// </summary>
        Subject_Code,
        /// <summary>
        /// کد دادگاه
        /// </summary>
        judicialCode,
        /// <summary>
        /// کد مقام ارجاع کننده
        /// </summary>
        PostReferCode,
        /// <summary>
        /// توضیحات درخواست
        /// </summary>
        RequestDescription,
        /// <summary>
        /// دلائل
        /// </summary>
        ReasonsDescription,

       #endregion
    }
}
