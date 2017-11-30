using System.IO;
using System.Reflection;
using System.Xml;

namespace Framework
{
    public class Configuration
    {
        private static string browser;
        private static string url;
        private static int implicitWait;

        private static readonly XmlReader reader = XmlReader.Create(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "..\\..\\..\\config.xml");
        private static XmlNodeType node;

        public static void ReadXml()
        {
            while (reader.Read())
            {
                node = reader.NodeType;
                if (node == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "browser":
                            reader.Read();
                            browser = reader.Value;
                            break;
                        case "url":
                            reader.Read();
                            url = reader.Value;
                            break;
                        case "implicitWait":
                            reader.Read();
                            implicitWait = int.Parse(reader.Value);
                            break;
                    }
                }
            }
            reader.Close();
        }

        public static string GetBrowser()
        {
            ReadXml();
            return browser;
        }

        public static string GetUrl()
        {
            ReadXml();
            return url;
        }

        public static int GetTimeWait()
        {
            ReadXml();
            return implicitWait;
        }
    }
}
