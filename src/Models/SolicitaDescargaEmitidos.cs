using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "SolicitaDescargaEmitidos", Namespace = WSNamespaces.dmt2)]
    public class SolicitaDescargaEmitidos : SolicitaDescarga
    {
    }

    [XmlRoot(ElementName = "SolicitaDescargaEmitidosResponse", Namespace = WSNamespaces.dmt2)]
    public class SolicitaDescargaEmitidosResponse : SolicitaDescargaResponse
    {
        [XmlElement(ElementName = "SolicitaDescargaEmitidosResult")]
        public override SolicitaDescargaResult Result { get; set; }
    }
}
