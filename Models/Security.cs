using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlType(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis200401-wss-wssecurity-secext-1.0.xsd")]
    [XmlRoot(ElementName = "Security")]
    public class Security
    {
        [XmlElement(ElementName = "Timestamp", Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility1.0.xsd")]
        public Timestamp Timestamp { get; set; }
        [XmlElement(ElementName = "BinarySecurityToken", Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis200401-wss-wssecurity-secext-1.0.xsd")]
        public BinarySecurityToken BinarySecurityToken { get; set; }
        [XmlElement(ElementName = "Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public Signature Signature { get; set; }

        [XmlAttribute(AttributeName = "mustUnderstand", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public string MustUnderstand { get; set; } = "1";
    }
}