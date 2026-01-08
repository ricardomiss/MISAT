using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "AutenticaResponse", Namespace = WSNamespaces.dmt)]
    public class AutenticaResponse
    {
        [XmlElement(ElementName = "AutenticaResult")]
        public string AutenticaResult { get; set; }
    }
}