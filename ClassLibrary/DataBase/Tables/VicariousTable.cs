using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ClassLibrary
{
    class JVicariousTable : JTable
    {
        #region Property

        /// <summary>
        /// کد شخص
        /// </summary>
        public int Person_Code { get; set; }
        /// <summary>
        /// کد وکالت
        /// </summary>
        public int Advocacy_Code { get; set; }

        #endregion

        public JVicariousTable()
            : base(JTableNamesLegal.LegVicariousTable)
        {

        }
    }

    public enum Vicarious
    {
        Code,
        Person_Code,
        Advocacy_Code,
    }
}
