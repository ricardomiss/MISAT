using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "KeyInfo")]
    public class KeyInfo
    {
        [XmlElement(ElementName = "SecurityTokenReference", Namespace = WSNamespaces.o)]
        public SecurityTokenReference SecurityTokenReference { get; set; }
    }

    [XmlRoot(ElementName = "SecurityTokenReference")]
    public class SecurityTokenReference
    {
        [XmlElement(ElementName = "Reference", Namespace = WSNamespaces.o)]
        public KeyReference Reference { get; set; }
    }

    [XmlRoot(ElementName = "Reference")]
    public class KeyReference
    {
        [XmlAttribute(AttributeName = "ValueType")]
        public string ValueType { get; set; } = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509v3";
        [XmlAttribute(AttributeName = "URI")]
        public string URI { get; set; }
    }
}