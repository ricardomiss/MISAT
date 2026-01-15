using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "VerificaSolicitudDescarga", Namespace = WSNamespaces.dmt2)]
    public class VerificaSolicitudDescarga : SolicitaDescarga
    {
    }

    [XmlRoot(ElementName = "VerificaSolicitudDescargaResponse", Namespace = WSNamespaces.dmt2)]
    public class VerificaSolicitudDescargaResponse
    {
        [XmlElement(ElementName = "VerificaSolicitudDescargaResult")]
        public VerificaSolicitudResult Result { get; set; }
    }

    public class VerificaSolicitudResult : SolicitudResult
    {
        [XmlElement(ElementName = "IdsPaquetes")]
        public List<string> IdsPaquetes { get; set; }

        [XmlAttribute(AttributeName = "EstadoSolicitud")]
        public int EstadoSolicitud { get; set; }
        [XmlAttribute(AttributeName = "CodigoEstadoSolicitud")]
        public int CodigoEstadoSolicitud { get; set; }
        [XmlAttribute(AttributeName = "NumeroCFDIs")]
        public int NumeroCFDIs { get; set; }

    }
}
