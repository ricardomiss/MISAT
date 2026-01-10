using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "Traslados")]
    public class Traslados
    {
        [XmlElement(ElementName = "Traslado")]
        public List<Traslado> Traslado { get; set; }
    }

    [XmlRoot(ElementName = "Traslado")]
    public class Traslado
    {
        [XmlAttribute(AttributeName = "Base")]
        public decimal Base { get; set; }
        [XmlAttribute(AttributeName = "Impuesto")]
        public string Impuesto { get; set; }
        [XmlAttribute(AttributeName = "TipoFactor")]
        public string TipoFactor { get; set; }
        [XmlAttribute(AttributeName = "TasaOCuota")]
        public decimal TasaOCuota { get; set; }
        [XmlAttribute(AttributeName = "Importe")]
        public decimal Importe { get; set; }
    }
}