using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;

namespace ClassLibrary.FilesAndFolder
{
    public static class JFolder
    {
        public static void CreateAndSetPermissionFolder(string path)
        {
            System.Threading.Thread T = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(TCreateAndSetPermissionFolder));
            T.Start(path);
        }

        private static void TCreateAndSetPermissionFolder(object pPath)
        {
            try
            {
                string path = pPath.ToString();
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                DirectorySecurity sec = Directory.GetAccessControl(path);
                // Using this instead of the "Everyone" string means we work on non-English systems.
                SecurityIdentifier everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
                sec.AddAccessRule(new FileSystemAccessRule(everyone, FileSystemRights.Modify | FileSystemRights.Synchronize, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
                Directory.SetAccessControl(path, sec);
            }
            catch (Exception ex)
            {
                JMainFrame.Except.AddException(ex);
            }

        }
    }
}
