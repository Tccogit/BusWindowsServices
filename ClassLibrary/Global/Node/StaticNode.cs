using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JStaticNode
    {
        public static JNode _PersonsNode()
        {
            JNode Node = new JNode(0, "ClassLibrary.JPersons");
            Node.Name = "Persons";

            JAction DBClick = JStaticAction._PersonsDBClick();
            Node.MouseClickAction = DBClick;
            Node.MouseDBClickAction = DBClick;
            Node.Popup.Insert(JStaticAction._PersonsNew());
            Node.Popup.Insert(JStaticAction._PersonsSearch());
            //Node.Visible = Globals.JPermission.Allow("ClassLibrary.JPersons", "Access1", 0, JMainFrame.CurrentUserCode);
            Node.Icone = JImageIndex.Customer.GetHashCode();
            return Node;
        }

        public JNode[] AllPersonTree()
        {
            JNode[] TNodes = new JNode[4];
            TNodes[0] = JStaticNode._PersonsNode();
            TNodes[1] = JStaticNode._LegalPersonsNode();
            TNodes[2] = JStaticNode._OtherPersonsNode();
            TNodes[3] = JStaticNode._PersonPropertiesNode();
            return TNodes;
        }
        /// <summary>
        /// همه اشخاص
        /// </summary>
        /// <returns></returns>
        public static JNode _AllPerson()
        {
            if (!ClassLibrary.JPermission.CheckPermission("ClassLibrary.JPersons.GetDataTable", false))
                return null;
            JNode Node = new JNode(0, "ClassLibrary.JAllPerson");
            Node.Name = "People";
            //Node.Icone = 4;
            Node.Hint = "People";

            JAction Ac = new JAction("People", "ClassLibrary.JAllPersons.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("People", "ClassLibrary.JStaticNode.AllPersonTree");
            Node.ChildsAction = CAc;
            Node.Icone = JImageIndex.UserGroup.GetHashCode();
            return Node;
        }

        public static JNode _BaseDefine()
        {
            JNode Node = new JNode(0, "ClassLibrary.JBaseDefine");
            Node.Name = "BaseDefine";
            //Node.Icone = 4;
            Node.Hint = "BaseDefine";

            JAction Ac = new JAction("JBaseDefine", "ClassLibrary.JBaseDefine.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("JBaseDefine", "ClassLibrary.JBaseDefine.TreeView");
            Node.ChildsAction = CAc;
            Node.Icone = JImageIndex.BaseDefine.GetHashCode();
            return Node;
        }

        public static JNode _LegalPersonsNode()
        {
            JNode Node = new JNode(0, "ClassLibrary.JOrganizations");
            Node.Name = "LegalPersons";

            JAction DBClick = JStaticAction._LegalPersonsDBClick();
            Node.MouseClickAction = DBClick;
            Node.MouseDBClickAction = DBClick;
            Node.Popup.Insert(JStaticAction._LegalPersonsNew());
            Node.Popup.Insert(JStaticAction._LegalPersonsSearch());
            //Node.Visible = Globals.JPermission.Allow("ClassLibrary.JPersons", "Access1", 0, JMainFrame.CurrentUserCode);
            Node.Icone = JImageIndex.Customer.GetHashCode();
            return Node;
        }

        public static JNode _OtherPersonsNode()
        {
            JNode Node = new JNode(0, "ClassLibrary.JOtherPersons");
            Node.Name = "OtherPersons";

            JAction DBClick = JStaticAction._OtherPersonsDBClick();
            Node.MouseClickAction = DBClick;
            Node.MouseDBClickAction = DBClick;
            Node.Popup.Insert(JStaticAction._OtherPersonsNew());
            //Node.Popup.Insert(JStaticAction._OtherPersonsSearch());
            Node.Icone = JImageIndex.Customer.GetHashCode();
            return Node;
        }

        public static JNode _PersonPropertiesNode()
        {
            JNode Node = new JNode(0, "ClassLibrary.JOtherPersons");
            Node.Name = "PersonProperties";

            JAction DBClick = new JAction("PersonProperties", "ClassLibrary.JAllPerson.ShowPropertiesDialog");
            Node.MouseClickAction = DBClick;
            Node.Popup.Insert(DBClick);
            Node.Icone = JImageIndex.Customer.GetHashCode();
            return Node;
        }

        public static JNode _Successor()
        {
            JNode Node = new JNode(0, "ClassLibrary.JSuccessor");
            Node.Name = "Successor";
            JAction Ac = new JAction("Successor", "ClassLibrary.JSuccessor.ShowForm");
            //Node.DBClick = Ac;            
            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;
            Node.Icone = JImageIndex.Successor.GetHashCode();
            return Node;
        }

        public static JNode _ConfigNode()
        {
            if (JPermission.CheckPermission("ClassLibrary.JStaticNode._ConfigNode", 0, JMainFrame.CurrentPostCode, false))
            {
                JNode Node = new JNode(0, "ClassLibrary.JConfig");
                Node.Name = "MainConfig";
                JAction DBClick = JStaticAction._ShowConfig();
                Node.MouseClickAction = DBClick;
                Node.MouseDBClickAction = DBClick;
                Node.Icone = JImageIndex.Config.GetHashCode();                
                return Node;
            }
            else
                return null;
        }

        public static JNode _ChangePassword()
        {
            JNode Node = new JNode(0, "ClassLibrary.JConfig");
            Node.Name = "ChangePassword";
            JAction DBClick = JStaticAction._ShowChangePassword();
            Node.MouseClickAction = DBClick;
            Node.MouseDBClickAction = DBClick;
            Node.Icone = JImageIndex.Changepassword.GetHashCode();
            return Node;
        }

        public static JNode _GroupSMSEmployee()
        {
            JNode Node = new JNode(0, "ClassLibrary.JGroupSMSEmployee");
            Node.Name = "SMSGroup";
            JAction DBClick = JStaticAction._ShowGroupSMSEmployee();
            Node.MouseClickAction = DBClick;
            Node.MouseDBClickAction = DBClick;
            Node.Icone = JImageIndex.SMSGroup.GetHashCode();
            return Node;
        }

        public static JNode _GroupSMSSQL()
        {
            JNode Node = new JNode(0, "ClassLibrary.JGroupSMSSQL");
            Node.Name = "SMSGroupSQL";
            JAction DBClick = JStaticAction._ShowGroupSMSSQL();
            Node.MouseClickAction = DBClick;
            Node.MouseDBClickAction = DBClick;
            Node.Icone = JImageIndex.SMSGroup.GetHashCode();
            return Node;
        }

        public static JNode _ShowSendSMSForm()
        {
            JNode Node = new JNode(0, "ClassLibrary.JSMSFrom");
            Node.Name = "SendSMS";
            JAction DBClick = JStaticAction._ShowSendSMSSQL();
            Node.MouseClickAction = DBClick;
            Node.MouseDBClickAction = DBClick;
            Node.Icone = JImageIndex.SMSGroup.GetHashCode();
            return Node;
        }

        public static JNode _ShowFormManager()
        {
            JNode Node = new JNode(0, "ClassLibrary.FormManagers");
            Node.Name = "فرم ساز";

            JAction Ac = new JAction("Form", "ClassLibrary.FormManagers.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction FormManagerListView = new JAction("FormManager", "ClassLibrary.FormManagers.GetFromManager", null, null);

            Node.ChildsAction = new JAction("FormManager", "ClassLibrary.JForms.GetFormNode", new object[] { FormManagerListView }, null, true);
            return Node;
        }

        public static JNode _Permission()
        {
            JNode Node = new JNode(0, "ClassLibrary.JPermission");
            Node.Name = "Permission";
            Node.ChildsAction = JStaticAction._PermissionTreeView();
            JAction DBClick = JStaticAction._Permission();
            Node.MouseClickAction = DBClick;
            Node.MouseDBClickAction = DBClick;
            Node.Icone = JImageIndex.Settings.GetHashCode();            
            return Node;
        }

        public static JNode _PermissionSet(int pCode)
        {
            JNode Node = new JNode(0, "ClassLibrary.JPermission");
            Node.Name = "PermissionSet";
            JAction DBClick = JStaticAction._UserPermission(pCode);
            Node.MouseClickAction = DBClick;
            Node.MouseDBClickAction = DBClick;
            Node.Icone = JImageIndex.Secrecy.GetHashCode();            
            return Node;
        }

        public static JNode _PermissionDefineForm()
        {
            JNode Node = new JNode(0, "ClassLibrary.JPermission");
            Node.Name = "PermissionDefine";
            JAction DBClick = JStaticAction._PermissionDefine();
            Node.MouseClickAction = DBClick;
            Node.MouseDBClickAction = DBClick;
            Node.Icone = JImageIndex.Secrecy.GetHashCode();                        
            return Node;
        }

        public static JNode _PermissionShowDllForm()
        {
            JNode Node = new JNode(0, "ClassLibrary.JPermission");
            Node.Name = "PermissionShowDLL";
            JAction DBClick = JStaticAction._PermissionShowDll();
            Node.MouseClickAction = DBClick;
            Node.MouseDBClickAction = DBClick;
            Node.Icone = JImageIndex.Secrecy.GetHashCode();            
            return Node;
        }

        public static JNode _PermissionShowClassForm()
        {
            JNode Node = new JNode(0, "ClassLibrary.JPermission");
            Node.Name = "PermissionShowClass";
            JAction DBClick = JStaticAction._PermissionShowClass();
            Node.MouseClickAction = DBClick;
            Node.MouseDBClickAction = DBClick;
            Node.Icone = JImageIndex.Secrecy.GetHashCode();            
            return Node;
        }

        public static JNode _PersonNode(JPerson pPerson)
        {
            JNode Node = new JNode(pPerson.Code, "ClassLibrary.JPerson");
            Node.Name = pPerson.Fam + " " + pPerson.Name;
            Node.Popup.Insert(JStaticAction._PersonDelete(pPerson.Code));

            Node.MouseDBClickAction = JStaticAction._PersonDBClick(pPerson.Code);

            Array.Resize(ref Node.Columns, 3);
            Node.Columns[0] = pPerson.Fam;
            Node.Columns[1] = pPerson.ShMeli;
            Node.Columns[2] = pPerson.FatherName;
            Node.Icone = JImageIndex.Users.GetHashCode();
            return Node;
        }

        public static JNode _UsersNode()
        {
            JNode Node = new JNode(0, "ClassLibrary.JUsers");
            Node.Name = "users";
            Node.MouseDBClickAction = JStaticAction._UsersDBClick();
            Node.MouseClickAction = JStaticAction._UsersDBClick();
            Node.Icone = JImageIndex.Users.GetHashCode();
            return Node;
        }

        public static JNode _SubBaseDefineNode(int pCode, int pBCode, string pName, string pBdName)
        {
            JNode Node = new JNode(pCode, "ClassLibrary.JSubBaseDefine");
            Node.Code = pCode;
            Node.Name = pName;

            JAction DBClick = JStaticAction._SubBaseDefineEdit(pCode, pBCode);
            Node.MouseDBClickAction = DBClick;

            JAction DeleteAction = JStaticAction._SubBaseDefineDelete(pCode, pBCode);
            Node.Popup.Insert(DeleteAction);

            JAction EditAction = JStaticAction._SubBaseDefineEdit(pCode, pBCode);
            Node.Popup.Insert(EditAction);

            JAction insertDefine = JStaticAction._SubBaseDefineInsert(pBCode);
            Node.Popup.Insert(insertDefine);

            try
            {
                Node.Icone = (int)Enum.Parse(Type.GetType("ClassLibrary.JImageIndex"), pBdName);
            }
            catch
            {
                Node.Icone = JImageIndex.Default.GetHashCode();
            }

            return Node;
        }

        public static JNode _OrganizationNode(JOrganization pOrganization)
        {
            JNode Node = new JNode(pOrganization.Code, "ClassLibrary.JOrganization");
            Node.Name = pOrganization.Name;
            //Node.Popup.Insert(JStaticAction._UserDelete(pOrganization.Code));
            JAction ja = new JAction("Edit...", "ClassLibrary.JOrganization.UpdateForm", new object[] { pOrganization.Code }, null, false);
            Node.MouseDBClickAction = ja;

            Array.Resize(ref Node.Columns, 3);
            Node.Columns[0] = pOrganization.Address.Tel;
            Node.Columns[1] = pOrganization.Address.Address;
            Node.Columns[2] = pOrganization.Description;

            JAction EditAction = new JAction("Edit...", "ClassLibrary.JOrganization.UpdateForm", new object[] { pOrganization.Code }, null);
            Node.MouseDBClickAction = EditAction;
            Node.MouseClickAction = EditAction;
            //Node.Icone = (int)JImageIndex.Default;
            Node.Popup.Insert(EditAction);

            JAction DeleteAction = new JAction("Delete", "ClassLibrary.JOrganization.Delete", new object[] { pOrganization.Code }, null);
            Node.Popup.Insert(DeleteAction);

            JAction InsertAction = new JAction("New", "ClassLibrary.JOrganization.InsertForm");
            Node.Popup.Insert(InsertAction);
            Node.Icone = JImageIndex.OrganizationChart.GetHashCode();
            return Node;
        }

        //public static JNode _PatternFileNode(Communication.JCPatternFile pPatternFile)
        //{
        //    JNode Node = new JNode(pPatternFile.Code, "Communication.JCPatternFiles");
        //    Node.Name = pPatternFile.Name;

        //    JAction EditAction = new JAction("Edit...", "Communication.JCPatternFile.UpdateForm", new object[] { pPatternFile.Code }, null);
        //    Node.MouseDBClickAction = EditAction;
        //    Node.MouseClickAction = EditAction;
        //    //Node.Icone = 5;
        //    Node.Popup.Insert(EditAction);

        //    JAction EnterAction = new JAction("", "", new object[] { pPatternFile.Code }, null);
        //    Node.EnterClickAction = EnterAction;


        //    JAction DeleteAction = new JAction("Delete", "Communication.JCPatternFile.Delete", new object[] { pPatternFile.Code }, null);
        //    Node.Popup.Insert(DeleteAction);

        //    JAction InsertAction = new JAction("New", "Communication.JCPatternFile.InsertForm");
        //    Node.Popup.Insert(InsertAction);
        //    Node.Icone = JImageIndex.Customer.GetHashCode();
        //    return Node;
        //}

        public static JNode _ReportManagment(ProjectsEnum pProj)
        {
            JNode Node = new JNode(pProj.GetHashCode(), "ClassLibrary.JReportManagement");
            Node.Name = "Reports";
            Node.Icone = (int)JImageIndex.report;

            Node.MouseDBClickAction = new JAction("Reports", "ClassLibrary.JReportManagements.ListView", new object[] { pProj }, null, true);
            Node.MouseClickAction = new JAction("Reports", "ClassLibrary.JReportManagements.ListView", new object[] { pProj }, null, true);
            Node.Icone = JImageIndex.Report.GetHashCode();
            return Node;
        }

        public static JNode _SetPermissions()
        {
            if (!JPermission.CheckPermission("ClassLibrary.JPermission.SetUserPermission",false))
                return null;
            JNode Node = new JNode(0, "Employment.SetPermissions");
            Node.Name = "SetPermissions";
            JAction Ac = new JAction("SetPermissions", "ClassLibrary.JPermissionsDefineClass.PermissionsListView");
            //Node.DBClick = Ac;
            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;
            Node.Icone = JImageIndex.Permission.GetHashCode();
            return Node;          
        }

    }
}
