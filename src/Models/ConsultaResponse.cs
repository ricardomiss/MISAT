using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "ConsultaResponse", Namespace = WSNamespaces.tem)]
    public class ConsultaResponse
    {
        [XmlElement(ElementName = "ConsultaResult")]
        public ConsultaResult ConsultaResult { get; set; }
    }

    [XmlRoot(ElementName = "ConsultaResult")]
    public class ConsultaResult
    {
        [XmlElement(ElementName = "CodigoEstatus", Namespace = WSNamespaces.a)]
        public string CodigoEstatus { get; set; }
        [XmlElement(ElementName = "EsCancelable", Namespace = WSNamespaces.a)]
        public string EsCancelable { get; set; }
        [XmlElement(ElementName = "Estado", Namespace = WSNamespaces.a)]
        public string Estado { get; set; }
        [XmlElement(ElementName = "EstatusCancelacion", Namespace = WSNamespaces.a)]
        public string? EstatusCancelacion { get; set; }
        [XmlElement(ElementName = "ValidacionEFOS", Namespace = WSNamespaces.a)]
        public string ValidacionEFOS { get; set; }
    }
}