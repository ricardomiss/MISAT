using System.Xml;
using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "solicitud", Namespace = WSNamespaces.dmt2)]
    public class solicitud
    {
        [XmlAttribute(AttributeName = "EstadoComprobante")]
        public string EstadoComprobante { get; set; }
        [XmlAttribute(AttributeName = "FechaInicial")]
        public string FechaInicial { get; set; }
        [XmlAttribute(AttributeName = "FechaFinal")]
        public string FechaFinal { get; set; }
        [XmlAttribute(AttributeName = "RfcEmisor")]
        public string RfcEmisor { get; set; }
        [XmlAttribute(AttributeName = "RfcSolicitante")]
        public string RfcSolicitante { get; set; }
        [XmlAttribute(AttributeName = "TipoSolicitud")]
        public string TipoSolicitud { get; set; }
        [XmlAttribute(AttributeName = "RfcReceptor")]
        public string RfcReceptor { get; set; }
        [XmlAttribute(AttributeName = "TipoComprobante")]
        public string? TipoComprobante { get; set; }
        [XmlAttribute(AttributeName = "RfcACuentaTerceros")]
        public string RfcACuentaTerceros { get; set; }
        [XmlAttribute(AttributeName = "Complemento")]
        public string? Complemento { get; set; }


        [XmlElement(ElementName = "RfcReceptores", Namespace = WSNamespaces.dmt2)]
        public List<RfcReceptores> RfcReceptores { get; set; }
        [XmlAnyElement]
        public XmlElement Signature { get; set; }
    }

    [XmlRoot(ElementName = "RfcReceptores", Namespace = WSNamespaces.dmt2)]
    public class RfcReceptores
    {
        public string RfcReceptor { get; set;  }
    }
}