using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "Impuestos")]
    public class Impuestos
    {
        [XmlElement(ElementName = "Traslados")]
        public Traslados Traslados { get; set; }
        [XmlElement(ElementName = "Retenciones")]
        public Retenciones Retenciones { get; set; }

        [XmlAttribute(AttributeName = "TotalImpuestosRetenidos")]
        public decimal TotalImpuestosRetenidos { get; set; }

        [XmlAttribute(AttributeName = "TotalImpuestosTrasladados")]
        public decimal TotalImpuestosTrasladados { get; set; }
    }
}