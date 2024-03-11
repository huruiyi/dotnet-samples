using System.Collections.Generic;
using System.Xml.Serialization;
using Fairy.ConApp.Model;

namespace Fairy.ConApp.Model
{
    public class Root2
    {
        public Class3 Class3 { get; set; }

        [XmlElement("c2")]
        public List<Class2> List { get; set; }
    }
}
