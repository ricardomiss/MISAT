using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "ACuentaTerceros")]
    public class ACuentaTerceros
    {
        [XmlAttribute(AttributeName = "RFCACuentaTerceros")]
        public string RFCACuentaTerceros { get; set; }
        [XmlAttribute(AttributeName = "NombreACuentaTerceros")]
        public string NombreACuentaTerceros { get; set; }
        [XmlAttribute(AttributeName = "RegimenFiscalACuentaTerceros")]
        public string RegimenFiscalACuentaTerceros { get; set; }
        [XmlAttribute(AttributeName = "DomicilioFiscalACuentaTerceros")]
        public string DomicilioFiscalACuentaTerceros { get; set; }
    }
}