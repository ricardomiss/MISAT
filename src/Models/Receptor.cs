using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "Receptor")]
    public class Receptor
    {
        [XmlAttribute(AttributeName = "Rfc")]
        public string Rfc { get; set; }
        [XmlAttribute(AttributeName = "Nombre")]
        public string Nombre { get; set; }
        [XmlAttribute(AttributeName = "DomicilioFiscalReceptor")]
        public string DomicilioFiscalReceptor { get; set; }
        [XmlAttribute(AttributeName = "ResidenciaFiscal")]
        public string ResidenciaFiscal { get; set; }
        [XmlAttribute(AttributeName = "NumRegIdTrib")]
        public string NumRegIdTrib { get; set; }
        [XmlAttribute(AttributeName = "RegimenFiscalReceptor")]
        public string RegimenFiscalReceptor { get; set; }
        [XmlAttribute(AttributeName = "UsoCFDI")]
        public string UsoCFDI { get; set; }
    }
}