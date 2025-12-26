using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "CfdiRelacionados")]
    public class CfdiRelacionados
    {
        [XmlElement(ElementName = "CfdiRelacionado")]
        public List<CfdiRelacionado> CfdiRelacionado { get; set; }

        [XmlAttribute(AttributeName = "TipoRelacion")]
        public string TipoRelacion { get; set; }
    }

    [XmlRoot(ElementName = "CfdiRelacionado")]
    public class CfdiRelacionado
    {
        [XmlAttribute(AttributeName = "UUID")]
        public string UUID { get; set; }
    }
}
