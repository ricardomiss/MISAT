using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "Fault", Namespace = WSNamespaces.s)]
    public class Fault
    {
        [XmlElement(ElementName = "faultcode", Namespace = "")]
        public string Faultcode { get; set; }
        [XmlElement(ElementName = "faultstring", Namespace = "")]
        public string Faultstring { get; set; }
    }
}