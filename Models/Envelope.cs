using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Envelope
    {
        [XmlElement(ElementName = "Header", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public Header Header { get; set; }
        [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public Body Body { get; set; }

    }

    [XmlRoot(ElementName = "Body")]
    public class Body
    {
        [XmlElement(ElementName = "Autentica", Namespace = "http://DescargaMasivaTerceros.gob.mx")]
        public Autentica Autentica { get; set; }
    }

    public class Autentica
    {
    }
}
