using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ClassLibrary
{
    public class TablesName : JBase
    {



        public static string GetFieldsType(string TableName)
        {            
            string str = "";
            Assembly asm = Assembly.Load("ClassLibrary");
            Type type = asm.GetType("ClassLibrary.TablesName");
            Module m = asm.GetModule("ClassLibrary.TablesName." + TableName);

            Assembly asm1 = Assembly.Load("ClassLibrary.TablesName.Refer");

            object type1 = asm1.GetExportedTypes();
            //object type2 = asm.GetCustomAttributes(("ClassLibrary.TablesName." + TableName);            

//            Type type = TableName.GetType();
            //CharEnumerator type = TableName.GetEnumerator();
                FieldInfo[] fInfo = type.GetFields();
                foreach (var inf in fInfo)
                {
                    if (inf.Name.ToString() == TableName)
                        str=inf.Name.ToString()+",";
                }
                return str.Remove((str.Length-1),1);
        //= (Tasks1).GetType().Name. .previouse_task_code;
        }

        public static string workfolderTable = "workfolder";
        public enum workfolder
        {
            Code,
             Name,
             Limitation,
             ParentCode,
        }

        public static string SubsidiariesTable = "Subsidiaries";
        public enum Subsidiaries
        {
            Code,
            name,
            managing_director,
            phone_number,
            address,
            server_name,
            server_user,
            server_pass,
            database_name,
            access_code,
            description,
        }

        

       
    }
}
