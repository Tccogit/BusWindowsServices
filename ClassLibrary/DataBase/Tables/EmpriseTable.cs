using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Automation
{
    class JAEmpriseTable : JTable
    {
        #region Properties
         public int Code { get; set; }
        public int User_post_code { get; set; }
        public string Description { get; set; }

        #endregion

        public JAEmpriseTable() :
            base(JTableNamesAutomation.Emprise, "")
        {
        }

    }
    public enum Emprise
    {
       #region Properties
        Code,
        User_post_code,
        Description,

       #endregion
    }


}
