using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "CuentaPredial")]
    public class CuentaPredial
    {
        [XmlAttribute(AttributeName = "Numero")]
        public string Numero { get; set; }
    }
}