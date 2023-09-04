using System.Xml;

namespace AppiumTestProject.Utils
{
    public static class ConfigUtils
    {
        private static string rezult;
        public static string GetAndroidConfig(string nodeName)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(@"../../../Config/AndroidConfig.xml");
            XmlElement xmlElement = xmlDocument.DocumentElement;

            foreach (XmlNode xmlNode in xmlElement)
            {
                if (xmlNode.Attributes.Count > 0)
                {
                    XmlNode attr = xmlNode.Attributes.GetNamedItem("settings");
                    foreach (XmlNode childNode in xmlNode.ChildNodes)
                    {
                        if (childNode.Name == nodeName)
                            rezult = childNode.InnerText;
                    }
                }
            }
            return rezult;
        }
    }
}
