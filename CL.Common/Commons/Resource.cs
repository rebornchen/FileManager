using System;
using System.Collections.Generic;

using System.IO;
using System.Xml;

namespace CL.Common
{
    /// <summary>
    ///Author   : Aricous
    ///Datetime : 20100712
    ///Function : Description
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Kind">报表种类[1,2..]</param>
        /// <param name="Name">配置文件的名称</param>
        /// <returns></returns>
        public static List<string> GetConfig(string Kind, string Name)
        {
            if (string.IsNullOrEmpty(Name)) return new List<string>();

            Dictionary<string, string> dic = new Dictionary<string, string>();
            List<string> list = new List<string>();
            string fullname = System.IO.Path.Combine(Manager.Config, Name);
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(fullname);
                XmlNodeList nodes = xmldoc.DocumentElement.ChildNodes;
                foreach (XmlElement node in nodes)
                    if (node.GetAttribute("id") == Kind)
                        foreach (XmlNode n in node.ChildNodes)
                            list.Add(n.InnerText);
            }
            catch (Exception ex)
            {
                Manager.Logger.Error(ex);
            }
            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetStandard()
        {
            XmlDocument doc = GetXmlDocument(this.GetType(), "Aricous.Common.Report.xml");
            if (doc != null)
            {
                XmlNodeList list = doc.GetElementsByTagName("Standard");
                if (list != null && list.Count > 0)
                {
                    XmlElement element = (XmlElement)list.Item(0);
                    var o = element.Attributes["name"];
                    if (o != null)
                    {
                        return o.Value;
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// 获取程序集嵌入的资源文件
        /// </summary>
        /// <param name="type"></param>
        /// <param name="file">文件名称
        /// <example>Aricous.Common.Report.xml</example>
        /// </param>
        /// <returns></returns>
        public XmlDocument GetXmlDocument(Type type, string file)
        {
            XmlDocument doc = new XmlDocument();
            using (Stream stream = type.Assembly.GetManifestResourceStream(file))
            {
                doc.Load(stream);
            }
            return doc;
        }
    }
}
