using System.Xml;
using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "Consulta", Namespace = WSNamespaces.tem)]
    public class Consulta
    {
        [XmlElement(ElementName = "expresionImpresa", Namespace = WSNamespaces.tem)]
        public XmlNode ExpresionImpresa { get; set; }
    }
}