using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "Nomina")]
    public class Nomina
    {
        [XmlElement(ElementName = "Deducciones")]
        public Deducciones Deducciones { get; set; }
    }
}