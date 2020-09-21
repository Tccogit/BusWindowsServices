using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;


namespace ClassLibrary
{
    class JReportTable : JTable
    {

        #region Property

        /// <summary>
        /// عنوان فرم 
        /// </summary>
        public string Title;
        /// <summary>
        /// تب ها
        /// </summary>
        public string Tabs;
        /// <summary>
        /// 
        /// </summary>
        public int Project = 0;

        #endregion
        public JReportTable()
            : base(JTableNamesReport.Report, "")
    {
    }

    }
}
