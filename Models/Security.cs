using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlType(Namespace = WSNamespaces.o)]
    [XmlRoot(ElementName = "Security")]
    public class Security
    {
        [XmlElement(ElementName = "Timestamp", Namespace = WSNamespaces.u)]
        public Timestamp Timestamp { get; set; }
        [XmlElement(ElementName = "BinarySecurityToken", Namespace = WSNamespaces.o)]
        public BinarySecurityToken BinarySecurityToken { get; set; }
        [XmlElement(ElementName = "Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public Signature Signature { get; set; }

        [XmlAttribute(AttributeName = "mustUnderstand", Namespace = WSNamespaces.s)]
        public string MustUnderstand { get; set; } = "1";
    }
}