using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "Envelope", Namespace = WSNamespaces.s)]
    public class Envelope
    {
        [XmlElement(ElementName = "Header", Namespace = WSNamespaces.s)]
        public Header Header { get; set; }
        [XmlElement(ElementName = "Body", Namespace = WSNamespaces.s)]
        public Body Body { get; set; }

    }

    [XmlRoot(ElementName = "Body")]
    public class Body
    {
        [XmlElement(ElementName = "Autentica", Namespace = WSNamespaces.dmt)]
        public Autentica Autentica { get; set; }
        [XmlElement(ElementName = "AutenticaResponse", Namespace = WSNamespaces.dmt)]
        public AutenticaResponse AutenticaResponse { get; set; }
        [XmlElement(ElementName = "Fault", Namespace = WSNamespaces.s)]
        public Fault Fault { get; set; }
    }

    public class Autentica
    {
    }
}
