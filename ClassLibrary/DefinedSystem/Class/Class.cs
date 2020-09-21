using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class JClass: JSubBaseDefine
    {
        public JClass()
            : base(JBaseDefine.ClassCode)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class JClasses : JSubBaseDefines
    {
        //public JClass[] Items;
        public JClasses()
            : base(JBaseDefine.ClassCode)
        {

        }
    }
}
