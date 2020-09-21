using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Employment
{
    public class JEChartTable : ClassLibrary.JTable
    {
        public int Code;
        public string Title;
        public bool is_active;

        public JEChartTable()
            : base("Charts")
        {
        }
    }
    public enum Charts
    {
        #region Properties
        Code,
        Title,
        is_active,

        #endregion
    }
}
