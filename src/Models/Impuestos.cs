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
        public string TotalImpuestosRetenidos { get; set; }

        [XmlAttribute(AttributeName = "TotalImpuestosTrasladados")]
        public string TotalImpuestosTrasladados { get; set; }
    }
}