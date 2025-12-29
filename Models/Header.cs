using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "Header")]
    public class Header
    {
        [XmlElement(ElementName = "Security", Namespace = WSNamespaces.o)]
        public Security Security { get; set; }
    }
}