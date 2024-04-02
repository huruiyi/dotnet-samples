using System.Collections.Generic;
using System.Xml.Serialization;
using Fairy.ConApp.Model;

namespace Fairy.ConApp.Model
{
    public class Root
    {
        public Class3 Class3 { get; set; }

        [XmlArrayItem("list")]
        [XmlArray("lists")]
        public List<Class2> List { get; set; }
    }
}
