using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.DirectoryServices;
using System.Data;

namespace ClassLibrary
{
    public class GetInfoActiveDirectory
    {
       
        public static string GetCurrentUserName()
        {
            return  WindowsIdentity.GetCurrent().Name;
            
        }

        public static string GetCurrentDomain()
        {
            return WindowsIdentity.GetCurrent().Name;

        }

        public System.Collections.Generic.SortedList<string, string> GetUsersInGroup(string domain, string group)
        {
            System.Collections.Generic.SortedList<string,string> groupMemebers = new System.Collections.Generic.SortedList<string,string>();
            string sam = "";
            string fname = "";
            string lname = "";
            string active = "";


            DirectoryEntry de = new DirectoryEntry("LDAP://DC=3EPAD,DC=NET");
            DirectorySearcher ds = new DirectorySearcher(de);
            ds.Filter = "(&(objectClass=user)(objectCategory=person))";
            ds.PropertiesToLoad.Add("givenname");
            ds.PropertiesToLoad.Add("samaccountname");
            ds.PropertiesToLoad.Add("sn");
            ds.PropertiesToLoad.Add("useraccountcontrol");
            foreach (SearchResult sr in ds.FindAll())
            {
                try
                {
                    try
                    {
                        sam = sr.Properties["samaccountname"][0].ToString();
                        fname = sr.Properties["givenname"][0].ToString();
                        lname = sr.Properties["sn"][0].ToString();
                        active = sr.Properties["useraccountcontrol"][0].ToString();
                    }
                    catch
                    {
                    }
                }
                catch (Exception e)
                {
                }
                if (active.ToString() != "514")
                {
                    groupMemebers.Add(sam.ToString(), (fname.ToString() + " " + lname.ToString()));
                }
            }
            return groupMemebers;
        }
         

    }
}
