using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JSQLViews
    {
        public static string Permission = @"
            SELECT        dbo.PermissionUser.*, dbo.PermissionDefineClass.ClassName, dbo.PermissionDefineClass.SQL
            FROM            dbo.PermissionDefineClass INNER JOIN
            dbo.PermissionUser ON dbo.PermissionDefineClass.Code = dbo.PermissionUser.DefineClassCode";

        public static string UserList = @"
            SELECT        dbo.us.*
            FROM            (SELECT        dbo.PermissionUser.UserCode
            FROM            dbo.Permission INNER JOIN
            dbo.PermissionUser ON dbo.Permission.Code = dbo.PermissionUser.PermissionCode
            WHERE        (dbo.Permission.ClassName = @ClassName)
            GROUP BY dbo.PermissionUser.UserCode) AS p INNER JOIN
            dbo." + JTableNamesClassLibrary.UsersTable + " us ON p.UserCode = dbo." + JTableNamesClassLibrary.UsersTable + ".code";

        public static string UserPermission=@"SELECT        dbo.PermissionUser.*, dbo.PermissionDefineClass.ClassName, dbo.PermissionDecision.Name
FROM            dbo.PermissionDecision INNER JOIN
                         dbo.PermissionDefineClass ON dbo.PermissionDecision.PermissionDefineCode = dbo.PermissionDefineClass.Code INNER JOIN
                         dbo.PermissionUser ON dbo.PermissionDecision.Code = dbo.PermissionUser.DecisionCode AND 
                         dbo.PermissionDefineClass.Code = dbo.PermissionUser.DefineClassCode
WHERE        (dbo.PermissionUser.HasPermission = 1)";
        /// <summary>
        /// اشخاص 
        /// </summary>
//        public static string VPerson = @" SELECT     dbo.ExternalTables.Code, dbo.ExternalTables.ExternalCode AS pcode, dbo.person.FirstName, dbo.person.LastName, dbo.person.FatherName, 
//                      dbo.person.ShSh, dbo.person.BirthplaceCode, dbo.person.BirthDate, dbo.person.shMelli
//                      FROM dbo.ExternalTables INNER JOIN
//                      dbo.person ON dbo.ExternalTables.Code = dbo.person.Code ";
        
    }
}
