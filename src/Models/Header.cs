using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "Header")]
    public class Header
    {
        [XmlElement(ElementName = "Security", Namespace = WSNamespaces.o)]
        public Security Security { get; set; }

        [XmlElement(ElementName = "respuesta", Namespace = WSNamespaces.dmt2)]
        public respuesta Respuesta { get; set; }
    }

    public class respuesta
    {
        [XmlAttribute(AttributeName = "CodEstatus")]
        public int CodEstatus { get; set; }
        [XmlAttribute(AttributeName = "Mensaje")]
        public string Mensaje { get; set; }
    }
}