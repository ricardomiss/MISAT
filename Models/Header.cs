using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "Header")]
    public class Header
    {
        [XmlElement(ElementName = "Security", Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis200401-wss-wssecurity-secext-1.0.xsd")]
        public Security Security { get; set; }
    }
}