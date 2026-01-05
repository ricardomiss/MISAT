using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "Timestamp", Namespace = WSNamespaces.u)]
    public class Timestamp
    {
        [XmlElement(ElementName = "Created", Namespace = WSNamespaces.u)]
        public string Created { get; set; }
        [XmlElement(ElementName = "Expires", Namespace = WSNamespaces.u)]
        public string Expires { get; set; }

        [XmlAttribute(AttributeName = "Id", Namespace = WSNamespaces.u)]
        public string Id { get; set; } = "_0";
    }
}