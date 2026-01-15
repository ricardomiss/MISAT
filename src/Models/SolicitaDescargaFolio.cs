using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "SolicitaDescargaFolio", Namespace = WSNamespaces.dmt2)]
    public class SolicitaDescargaFolio : SolicitaDescarga
    {
    }

    [XmlRoot(ElementName = "SolicitaDescargaFolioResponse", Namespace = WSNamespaces.dmt2)]
    public class SolicitaDescargaFolioResponse : SolicitaDescargaResponse
    {
        [XmlElement(ElementName = "SolicitaDescargaFolioResult")]
        public override SolicitaDescargaResult Result { get; set; }
    }
}
