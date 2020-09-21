using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ClassLibrary
{
    class JSubjectAdvocacyTable : JTable
    {

        #region Property

        public int Code { get; set; }
        /// <summary>
        /// کد مجتمع
        /// </summary>
        public int Advocacy_Code { get; set; }
        /// <summary>
        /// کد موضوع
        /// </summary>
        public int SubjectCode { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }

        #endregion

        public JSubjectAdvocacyTable()
            : base(JTableNamesLegal.SubjectTable, "")
        {
        }
    }

    public enum LegSubject
    {
        #region Property

        Code,
        /// <summary>
        /// کد مجتمع
        /// </summary>
        Advocacy_Code,
        /// <summary>
        /// کد موضوع
        /// </summary>
        SubjectCode,
        /// <summary>
        /// توضیحات
        /// </summary>
        Description,

        #endregion
    }
}
