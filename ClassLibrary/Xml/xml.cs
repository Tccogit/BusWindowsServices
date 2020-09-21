using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JXMLNode: JSystem
    {
        public string Usula;
        public string Name;
        public string Action;
        public string Popup;
        public string Arg;
        public string Icon;
        public string ConstArg;
        public string Refresh;
    }

    public class JXml: JSystem
    {

        const string node = 
@"<node 
type=%usual% 
name=%name%  
action=%action% 
popup=%popup% 
arg=%arg% 
icon=%icon%
constarg=%constarg%
refesh=%refresh%>
</node>";
        const string backnode = "<node type='usual' name='Back'  action='' popup='' arg=''></node>";
        
        public string XML;
        
        public JXml()
        {
        }
        /// <summary>
        ///ساخت اکس ام ال برای نمایش در لیست ویو یا تری ویو
        /// </summary>
        /// <param name="SQL"></param>
        /// <returns></returns>
       public string CreateViewXML(string SQL)
        {
            int count = 1;
            string xml;
            JDataBase db = JGlobal.MainFrame.GetDBO();
            db.setQuery(SQL);
            if (!db.Query_DataReader())
                return null;
            xml = "<nodes>";
            xml += backnode;
            while (db.DataReader.Read())
            {
                xml += node;
                xml = xml.Replace("%usual%", db.QuoteField("usual"));
                xml = xml.Replace("%name%", db.QuoteField("name"));
                xml = xml.Replace("%action%",  db.QuoteField("action"));
                xml = xml.Replace("%popup%", db.QuoteField("popup"));
                xml = xml.Replace("%arg%", db.QuoteField("arg"));
                xml = xml.Replace("%icon%", db.QuoteField("icon"));
                count++;
            }
            xml += "</nodes>";
            XML = xml;
            return xml;
        }
        public string CreateViewXML(JXMLNode[] PNodes)
        {
            int count = 1;
            string xml;
            xml = "<nodes>";
            xml += backnode;
            foreach (JXMLNode PNode in PNodes)
            {
                xml += node;
                xml = xml.Replace("%usual%", JDataBase.Quote(PNode.Usula));
                xml = xml.Replace("%name%",  JDataBase.Quote(PNode.Name));
                xml = xml.Replace("%action%",  JDataBase.Quote(PNode.Action));
                xml = xml.Replace("%popup%",  JDataBase.Quote(PNode.Popup));
                xml = xml.Replace("%arg%", JDataBase.Quote(PNode.Arg));
                xml = xml.Replace("%icon%", JDataBase.Quote(PNode.Icon));
                xml = xml.Replace("%constarg%", JDataBase.Quote(PNode.ConstArg));
                xml = xml.Replace("%refresh%", JDataBase.Quote(PNode.Refresh));
                count++;
            }
            xml += "</nodes>";
            XML = xml;
            return xml;
        }
    }
}
