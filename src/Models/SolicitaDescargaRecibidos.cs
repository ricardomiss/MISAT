using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "SolicitaDescargaRecibidos", Namespace = WSNamespaces.dmt2)]
    public class SolicitaDescargaRecibidos : SolicitaDescarga
    {
    }

    [XmlRoot(ElementName = "SolicitaDescargaRecibidosResponse", Namespace = WSNamespaces.dmt2)]
    public class SolicitaDescargaRecibidosResponse : SolicitaDescargaResponse
    {
        [XmlElement(ElementName = "SolicitaDescargaRecibidosResult")]
        public override SolicitaDescargaResult Result { get; set; }
    }
}
