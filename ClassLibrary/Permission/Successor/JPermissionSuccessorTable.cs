using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JPermissionSuccessorTable : JTable
    {
        public int DecisionCode;
        //public int DefineClassCode;
        public int ObjectCode;
        public int User_Post_Code;
        public bool HasPermission;
        public int Creator;
        public DateTime Start_Date;
        public DateTime End_Date;

        public JPermissionSuccessorTable()
            : base(JTableNamesPermission.PermissionUserSuccessor)
        {
        }
    }

        public enum PermissionSuccessor
        {
         Code,
         DecisionCode,
         //DefineClassCode,
         ObjectCode,
         User_post_Code,
         HasPermission,
         Creator,
         Start_Date,
         End_Date,
        }
}
