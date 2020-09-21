using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JSettingPrintTable : JTable
    {
        public JSettingPrintTable()
            : base(JTableNamesClassLibrary.ClsSettingPrint)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name;
        /// <summary>
        /// 
        /// </summary>
        public string FieldList;
        /// <summary>
        /// 
        /// </summary>
        public bool LandScape;
        /// <summary>
        /// 
        /// </summary>
        public string MarginL;
        /// <summary>
        /// 
        /// </summary>
        public string MarginR;
        /// <summary>
        /// 
        /// </summary>
        public string MarginT;
        /// <summary>
        /// 
        /// </summary>
        public string MarginB;
        /// <summary>
        /// 
        /// </summary>
        public string Header;
        /// <summary>
        /// 
        /// </summary>
        public string Footer;
    }
}
