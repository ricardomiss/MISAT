using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot("Retenciones")]
    public class Retenciones
    {
        [XmlElement("Retencion")]
        public List<Retencion> Retencion { get; set; }
    }

    [XmlRoot("Retencion")]
    public class Retencion
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