using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.IO;
using System.Xml;

namespace DSW.HT
{
    public class Setting
    {
        private static NameValueCollection m_settings;
        private static string m_settingsPath;
        private static XmlNodeList nodeList;

        static Setting()
        {
            ReadSettingXML();

            m_settings = new NameValueCollection();
            m_settings.Add("ApiAddress", nodeList.Item(0).Attributes["value"].Value);
        }

        private static void ReadSettingXML()
        {
            var root = ReadXMLFile();
            nodeList = root.ChildNodes.Item(0).ChildNodes;
        }

        private static XmlElement ReadXMLFile()
        {
            m_settingsPath = Path.GetDirectoryName(new Uri(
            System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath);
            m_settingsPath += @"\Setting.xml";

            if (!File.Exists(m_settingsPath))
                throw new FileNotFoundException(
                                  m_settingsPath + " could not be found.");

            System.Xml.XmlDocument xdoc = new XmlDocument();
            xdoc.Load(m_settingsPath);
            XmlElement root = xdoc.DocumentElement;

            return root;
        }

        public static string Get(string key)
        {
            if (nodeList == null)
            {
                return String.Empty;
            }

            foreach (XmlNode xn in nodeList)
            {
                if (xn.Attributes["key"].Value == key)
                {
                    return xn.Attributes["value"].Value;
                }
            }

            return String.Empty;
        }

        public static string ApiAddress
        {
            get { return m_settings.Get("ApiAddress"); }
            set { m_settings.Set("ApiAddress", value); }
        }

        public static void Update()
        {
            XmlTextWriter tw = new XmlTextWriter(m_settingsPath,
                                               System.Text.UTF8Encoding.UTF8);
            tw.WriteStartDocument();
            tw.WriteStartElement("configuration");
            tw.WriteStartElement("appSettings");

            for (int i = 0; i < m_settings.Count; ++i)
            {
                tw.WriteStartElement("add");
                tw.WriteStartAttribute("key", string.Empty);
                tw.WriteRaw(m_settings.GetKey(i));
                tw.WriteEndAttribute();

                tw.WriteStartAttribute("value", string.Empty);
                tw.WriteRaw(m_settings.Get(i));
                tw.WriteEndAttribute();
                tw.WriteEndElement();
            }

            tw.WriteEndElement();
            tw.WriteEndElement();

            tw.Close();
        }
    }
}
