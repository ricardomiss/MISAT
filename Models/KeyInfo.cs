using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "KeyInfo")]
    public class KeyInfo
    {
        [XmlElement(ElementName = "SecurityTokenReference", Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis200401-wss-wssecurity-secext-1.0.xsd")]
        public SecurityTokenReference SecurityTokenReference { get; set; }
    }

    [XmlRoot(ElementName = "SecurityTokenReference")]
    public class SecurityTokenReference
    {
        [XmlElement(ElementName = "Reference", Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis200401-wss-wssecurity-secext-1.0.xsd")]
        public KeyReference Reference { get; set; }
    }

    [XmlRoot(ElementName = "Reference")]
    public class KeyReference
    {
        [XmlAttribute(AttributeName = "ValueType")]
        public string ValueType { get; set; } = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wssx509-token-profile-1.0#X509v3";
        [XmlAttribute(AttributeName = "URI")]
        public string URI { get; set; }
    }
}