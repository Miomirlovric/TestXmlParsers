using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SaxParser
{
    public class SaxParser
    {
        public delegate void mydelegate(object e, string a);
        public event mydelegate stringevent;
        public void ReadGrandChildren(Stream stream)
        {
            using (var reader = XmlReader.Create(stream))
            {
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (reader.Name == "GrandChild")
                            {
                                reader.Read();
                                stringevent?.Invoke(this, reader.Value);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
