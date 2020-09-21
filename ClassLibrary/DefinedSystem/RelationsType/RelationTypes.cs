using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JFamilyRelationType:JSubBaseDefine
    {
       
            public JFamilyRelationType()
            : base(JBaseDefine.FamilyRelation)
            {
            }
    }

        /// <summary>
        /// 
        /// </summary>
        public class JFamilyRelationTypes : JSubBaseDefines
        {
            //public JFamilyRelationType[] Items;
            public JFamilyRelationTypes()
                : base(JBaseDefine.FamilyRelation)
            {

            }

        }
    
}
