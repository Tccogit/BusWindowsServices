using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Xml;

namespace ClassLibrary
{
    public class JSerialization: JCore
    {
        /// <summary>
        /// برای تبدیل هر نوع شیء به ایکس ام ال استفاده میشود
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static XmlDocument SerilizeXML(object obj)
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(obj.GetType());
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                System.IO.StringWriter writer = new System.IO.StringWriter(sb);
                ser.Serialize(writer, obj);
                XmlDocument _doc = new XmlDocument();
                _doc.LoadXml(sb.ToString());
                return _doc;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null ;
            }
        }

        public static object DeserializeXML(XmlDocument xmlDoc, Type objType)
        {
            XmlSerializer ser = new XmlSerializer(objType);
            XmlNodeReader reader = new XmlNodeReader(xmlDoc.DocumentElement); 
            object _obj = ser.Deserialize(reader);
            return _obj;
        }
    }
}
