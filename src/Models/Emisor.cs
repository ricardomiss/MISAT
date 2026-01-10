using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "Emisor")]
    public class Emisor
    {
        [XmlAttribute(AttributeName = "Rfc")]
        public string Rfc { get; set; }
        [XmlAttribute(AttributeName = "Nombre")]
        public string Nombre { get; set; }
        [XmlAttribute(AttributeName = "RegimenFiscal")]
        public string RegimenFiscal { get; set; }
    }
}