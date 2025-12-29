using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "BinarySecurityToken")]
    public class BinarySecurityToken
    {
        [XmlAttribute(AttributeName = "Id", Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility1.0.xsd")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "ValueType")]
        public string ValueType { get; set; } = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile1.0#X509v3";
        [XmlAttribute(AttributeName = "EncodingType")]
        public string EncodingType { get; set; } = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soapmessage-security1.0#Base64Binary";
        
        [XmlText]
        public string Certificate { get; set; }
    }
}