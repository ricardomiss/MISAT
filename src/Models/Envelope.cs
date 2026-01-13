using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "Envelope", Namespace = WSNamespaces.s)]
    public class Envelope
    {
        [XmlElement(ElementName = "Header", Namespace = WSNamespaces.s)]
        public Header Header { get; set; }
        [XmlElement(ElementName = "Body", Namespace = WSNamespaces.s)]
        public Body Body { get; set; }

    }

    [XmlRoot(ElementName = "Body")]
    public class Body
    {
        [XmlElement(ElementName = "Autentica", Namespace = WSNamespaces.dmt)]
        public Autentica Autentica { get; set; }
        [XmlElement(ElementName = "AutenticaResponse", Namespace = WSNamespaces.dmt)]
        public AutenticaResponse AutenticaResponse { get; set; }
        [XmlElement(ElementName = "Fault", Namespace = WSNamespaces.s)]
        public Fault Fault { get; set; }
        [XmlElement(ElementName = "SolicitaDescargaEmitidos", Namespace = WSNamespaces.dmt2)]
        public SolicitaDescargaEmitidos SolicitaDescargaEmitidos { get; set; }
        [XmlElement(ElementName = "SolicitaDescargaRecibidos", Namespace = WSNamespaces.dmt2)]
        public SolicitaDescargaRecibidos SolicitaDescargaRecibidos { get; set; }
        [XmlElement(ElementName = "SolicitaDescargaFolio", Namespace = WSNamespaces.dmt2)]
        public SolicitaDescargaFolio SolicitaDescargaFolio { get; set; }
        [XmlElement(ElementName = "SolicitaDescargaEmitidosResponse", Namespace = WSNamespaces.dmt2)]
        public SolicitaDescargaEmitidosResponse SolicitaDescargaEmitidosResponse { get; set; }
        [XmlElement(ElementName = "SolicitaDescargaRecibidosResponse", Namespace = WSNamespaces.dmt2)]
        public SolicitaDescargaRecibidosResponse SolicitaDescargaRecibidosResponse { get; set; }
        [XmlElement(ElementName = "SolicitaDescargaFolioResponse", Namespace = WSNamespaces.dmt2)]
        public SolicitaDescargaFolioResponse SolicitaDescargaFolioResponse { get; set; }

    }

    public abstract class SolicitaDescarga
    {
        [XmlElement(ElementName = "solicitud", Namespace = WSNamespaces.dmt2)]
        public solicitud Solicitud { get; set; }

    }

    [XmlRoot(ElementName = "SolicitaDescargaEmitidos", Namespace = WSNamespaces.dmt2)]
    public class SolicitaDescargaEmitidos : SolicitaDescarga
    {
    }

    [XmlRoot(ElementName = "SolicitaDescargaRecibidos", Namespace = WSNamespaces.dmt2)]
    public class SolicitaDescargaRecibidos : SolicitaDescarga
    {
    }

    [XmlRoot(ElementName = "SolicitaDescargaFolio", Namespace = WSNamespaces.dmt2)]
    public class SolicitaDescargaFolio : SolicitaDescarga
    {
    }

    public class SolicitaDescargaResult
    {
        [XmlAttribute(AttributeName = "CodEstatus")]
        public int CodEstatus { get; set; }
        [XmlAttribute(AttributeName = "Mensaje")]
        public string Mensaje { get; set; }
        [XmlAttribute(AttributeName = "IdSolicitud")]
        public string IdSolicitud { get; set; }
        [XmlAttribute(AttributeName = "RfcSolicitante")]
        public string RfcSolicitante { get; set; }
    }

    [XmlRoot(ElementName = "SolicitaDescargaEmitidosResponse", Namespace = WSNamespaces.dmt2)]
    public class SolicitaDescargaEmitidosResponse
    {
        [XmlElement(ElementName = "SolicitaDescargaEmitidosResult")]
        public SolicitaDescargaResult Result { get; set; }
    }

    [XmlRoot(ElementName = "SolicitaDescargaRecibidosResponse", Namespace = WSNamespaces.dmt2)]
    public class SolicitaDescargaRecibidosResponse
    {
        [XmlElement(ElementName = "SolicitaDescargaRecibidosResult")]
        public SolicitaDescargaResult Result { get; set; }
    }

    [XmlRoot(ElementName = "SolicitaDescargaFolioResponse", Namespace = WSNamespaces.dmt2)]
    public class SolicitaDescargaFolioResponse
    {
        [XmlElement(ElementName = "SolicitaDescargaFolioResult")]
        public SolicitaDescargaResult Result { get; set; }
    }

    public class Autentica
    {
    }
}
