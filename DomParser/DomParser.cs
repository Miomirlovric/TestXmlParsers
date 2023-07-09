using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DomParser
{
    public class DomParser
    {
        public IEnumerable<string> ReadGrandChildren(Stream stream)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(stream);
            var list = new List<string>();
            var nodeList = doc.GetElementsByTagName("GrandChild");
            foreach (XmlElement element in nodeList)
            {
                list.Add(element.InnerText);
            }
            return list;
        }
    }
}
