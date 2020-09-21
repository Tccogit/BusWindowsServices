using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using Globals;

namespace ClassLibrary
{
    class permissionobject
    {
    }
    public class JPermissionObject : JCore
    {
        public string ClassName;
        public int ObjectCode;
        private JPermissionDefineClass _Permission;

        public JPermissionObject(string pClassName, int pObjectCode)
        {
            ClassName = pClassName;
            ObjectCode = pObjectCode;
            _Permission = new JPermissionDefineClass(ClassName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>کد کاربرها را برمیگرداند</returns>
        public int[] GetUsersCode()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT " + PermissionUser.User_post_Code + " FROM (" + JSQLViews.Permission +
                    ") AS P WHERE ClassName=" + JDataBase.Quote(ClassName) +
                    " AND ObjectCode=" + ObjectCode.ToString() +
                    " Group By UsersCode");
                DB.Query_DataReader();
                int[] lUserCode = new int[DB.RecordCount];
                int count = 0;
                while (DB.DataReader.Read())
                {
                    lUserCode[count] = int.Parse(DB.DataReader[0].ToString());
                }
                return lUserCode;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return new int[0];
        }

        public Employment.JEOrganizationChart[] GetUsersPost()
        {
            int[] Codes = GetUsersCode();
            int count = 0;
            if (Codes != null)
            {
                Employment.JEOrganizationChart[] Users = new Employment.JEOrganizationChart[Codes.Length];
                foreach (int code in Codes)
                {
                    Users[count] = new Employment.JEOrganizationChart();
                    Users[count].GetData(code);
                    count++;
                }
                return Users;
            }
            return new Employment.JEOrganizationChart[0];
        }

        //public JPermissionDecision[] GetPermissions()
        //{
        //    JPermissionDefineClass Permission = new JPermissionDefineClass(ClassName);
        //    return Permission.Items;
        //}

        public void ShowDialog()
        {
            JPermissionSetObjectForm PSO = new JPermissionSetObjectForm(this);
            PSO.ShowDialog();

        }
    }

}
