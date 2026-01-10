using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "InformacionGlobal")]
    public class InformacionGlobal
    {
        [XmlElement(ElementName = "Periodicidad")]
        public string Periodicidad { get; set; }
        [XmlElement(ElementName = "Meses")]
        public string Meses { get; set; }
        [XmlElement(ElementName = "Año")]
        public string Año { get; set; }
    }
}