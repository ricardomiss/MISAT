using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "Deducciones")]
    public class Deducciones
    {
        [XmlElement(ElementName = "Deduccion")]
        public List<Deduccion> Deduccion { get; set; }
        [XmlAttribute(AttributeName = "TotalImpuestosRetenidos")]
        public string TotalImpuestosRetenidos { get; set; }
        [XmlAttribute(AttributeName = "TotalOtrasDeducciones")]
        public string TotalOtrasDeducciones { get; set; }
    }

    [XmlRoot(ElementName = "Deduccion")]
    public class Deduccion
    {
        [XmlAttribute(AttributeName = "Clave")]
        public string Clave { get; set; }
        [XmlAttribute(AttributeName = "Concepto")]
        public string Concepto { get; set; }
        [XmlAttribute(AttributeName = "Importe")]
        public string Importe { get; set; }
        [XmlAttribute(AttributeName = "TipoDeduccion")]
        public string TipoDeduccion { get; set; }
    }
}