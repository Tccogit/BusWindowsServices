using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JStaticAction
    {
        /// <summary>
        /// لیست اشخاص را در لیست ویو برمیگرداند
        /// </summary>
        /// <returns></returns>
        public static JAction _PersonsDBClick()
        {
            return new JAction("Persons", "ClassLibrary.JPersons.ListView", null, null, true);
        }

        public static JAction _LegalPersonsDBClick()
        {
            return new JAction("LegalPersons", "ClassLibrary.JOrganizations.ListView" ,null, null, true);
        }

        public static JAction _OtherPersonsDBClick()
        {
            return new JAction("OtherPersons", "ClassLibrary.JOtherPersons.ListView", null, null, true);
        }

        /// <summary>
        /// فرم ویرایش اطلاعات پایه را بر میگرداند
        /// </summary>
        /// <param name="pCode"></param>
        /// <param name="pBCode"></param>
        /// <returns></returns>
        public static JAction _SubBaseDefineEdit(int pCode, int pBCode)
        {
            return new JAction("Edit...", "ClassLibrary.JSubBaseDefine.EditForm", new object[] { pCode }, new object[] { pBCode });
        }
        public static JAction _SubBaseDefineDelete(int pCode, int pBCode)
        {
            return new JAction("Delete", "ClassLibrary.JSubBaseDefine.Delete", new object[] { pCode }, new object[] { pBCode });
        }
        public static JAction _SubBaseDefineInsert(int pBCode)
        {
            return new JAction("New...", "ClassLibrary.JSubBaseDefine.ShowDialog", null, new object[] { pBCode });
        }
        public static JAction _PersonDelete(int pCode)
        {
            return new JAction("Delete", "ClassLibrary.JPerson.Delete", new object[] { pCode }, null, false);
        }
        public static JAction _PersonDBClick(int pCode)
        {
            return new JAction("Edit...", "ClassLibrary.JPerson.ShowDialog", null,new object[] { pCode }, false);
        }
        public static JAction _PersonsSearch()
        {
            return new JAction("Search", "ClassLibrary.JPersons.Search");
        }
        public static JAction _OtherPersonsSearch()
        {
            return new JAction("Search", "ClassLibrary.JPersons.Search");
        }
        public static JAction _LegalPersonsSearch()
        {
            return new JAction("Search", "ClassLibrary.JOrganizations.Search");
        }
        public static JAction _PersonsNew()
        {
            return new JAction("New...", "ClassLibrary.JPerson.ShowDialog");
        }
        public static JAction _OtherPersonsNew()
        {
            return new JAction("New...", "ClassLibrary.JOtherPerson.ShowDialog");
        }
        public static JAction _LegalPersonsNew()
        {
            return new JAction("New...", "ClassLibrary.JOrganization.ShowDialog");
        }
        public static JAction _ShowConfig()
        {
            return new JAction("Configuration", "ClassLibrary.JConfig.ShowForm");
        }
        public static JAction _ShowChangePassword()
        {
            return new JAction("ChangePassword", "ClassLibrary.JConfig.ShowChangePasswordForm");
        }
        public static JAction _ShowGroupSMSEmployee()
        {
            return new JAction("GroupSMSEmployee", "ClassLibrary.JGroupSMSEmployee.ShowDialog");
        }
        public static JAction _ShowGroupSMSSQL()
        {
            return new JAction("GroupSMSSQL", "ClassLibrary.JGroupSMSSQL.ShowDialog");
        }
        public static JAction _ShowSendSMSSQL()
        {
            return new JAction("GroupSMSSQL", "ClassLibrary.JSMSSend.ShowDialog");
        }
        public static JAction _UserDelete(int pCode)
        {
            return new JAction("Delete", "ClassLibrary.JUser.Delete", new object[] { pCode }, null, false);
        }
        public static JAction _UserPermission(int pCode)
        {
            return new JAction("Permission", "ClassLibrary.JPermission.formShow", new object[] { pCode }, null);
        }
        public static JAction _UserActive(int pCode)
        {
            return new JAction("Active", "ClassLibrary.JUser.SetActive", new object[] { pCode }, null);
        }
        public static JAction _UserDeActive(int pCode)
        {
            return new JAction("DeActive", "ClassLibrary.JUser.SetDeActive", new object[] { pCode }, null);
        }
        public static JAction _UserDBClick(int pCode)
        {
            return new JAction("Edit...", "ClassLibrary.JUser.ShowDialog", new object[] { pCode }, null, false);
        }
        public static JAction _UsersDBClick()
        {
            return new JAction("Users", "ClassLibrary.JUsers.ListView", null, null, true);
        }
        public static JAction _Permission()
        {
            return new JAction("Permission", "ClassLibrary.JPermission.ListView", null, null, true);
        }
        public static JAction _PermissionTreeView()
        {
            return new JAction("Permission", "ClassLibrary.JPermission.TreeView", null, null, true);
        }
        public static JAction _PermissionDefine()
        {
            return new JAction("PermissionDefine", "ClassLibrary.JPermission.ShowDefinePermission", null, null, false);
        }
        public static JAction _PermissionShowDll()
        {
            return new JAction("PermissionDefine", "ClassLibrary.JPermission.ShowLoadDLL", null, null, false);
        }
        public static JAction _PermissionShowClass()
        {
            return new JAction("PermissionDefine", "ClassLibrary.JPermission.ShowClassForm", null, null, false);
        }

        //public static JNode _Successor()
        //{
        //    JNode Node = new JNode(0, "ClassLibrary.JSuccessor");
        //    Node.Name = "Successor";
        //    JAction Ac = new JAction("Successor", "ClassLibrary.JSuccessor.ShowForm");
        //    //Node.DBClick = Ac;
        //    Node.MouseDBClickAction = Ac;
        //    Node.MouseClickAction = Ac;

        //    return Node;
        //}
    }
}
