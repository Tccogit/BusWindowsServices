using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JPermissionControlTable : JTable
    {
        public int Parent_code;
        public String Class_Name;
        public String Object_Name;
        public int Status;
        public int Type;
        public int Class_Code;
        public int Decision_Code;
        //public int Object_Code;
        public String Description;

        public JPermissionControlTable()
            : base(JTableNamesPermission.PermissionControl,PermissionControl.Status + "," +
            PermissionControl.Type + "," +
            PermissionControl.Class_Code + "," +
            PermissionControl.Decision_Code)

        {
        }
    }
        
      public enum PermissionControl
      {
        Code,
        Parent_code,
        Class_Name,
        Object_Name,
        Status,
        Type,
        Class_Code,
        Decision_Code,
        //Object_Code,
        Description,
      }
}
