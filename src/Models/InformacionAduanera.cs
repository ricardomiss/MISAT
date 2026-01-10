using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "InformacionAduanera")]
    public class InformacionAduanera
    {
        [XmlAttribute(AttributeName = "NumeroPedimento")]
        public string NumeroPedimento { get; set; }
    }
}