using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "AutenticaResponse", Namespace = "http://DescargaMasivaTerceros.gob.mx")]
    public class AutenticaResponse
    {
        [XmlElement(ElementName = "AutenticaResult")]
        public string AutenticaResult { get; set; }
    }
}