using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "Timestamp", Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility1.0.xsd")]
    public class Timestamp
    {
        [XmlElement(ElementName = "Created", Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility1.0.xsd")]
        public string Created { get; set; }
        [XmlElement(ElementName = "Expires", Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility1.0.xsd")]
        public string Expires { get; set; }

        [XmlAttribute (AttributeName = "Id", Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility1.0.xsd")]
        public string Id { get; set; } = "_0";
    }
}