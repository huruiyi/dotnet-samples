using System.Collections.Generic;
using System.Xml.Serialization;

namespace Fairy.ConApp.Model
{
    public class XRoot
    {
        [XmlArrayItem(typeof(X1)), XmlArrayItem(typeof(X2))]
        public List<XBase> List { get; set; }
    }
}