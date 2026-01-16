using System.Xml;
using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "PeticionDescargaMasivaTercerosEntrada", Namespace = WSNamespaces.dmt2)]
    public class PeticionDescargaMasivaTercerosEntrada
    {
        [XmlElement(ElementName = "peticionDescarga", Namespace = WSNamespaces.dmt2)]
        public peticionDescarga PeticionDescarga { get; set; }
    }

    [XmlRoot(ElementName = "peticionDescarga", Namespace = WSNamespaces.dmt2)]
    public class peticionDescarga
    {
        [XmlAttribute(AttributeName = "IdPaquete")]
        public string IdPaquete { get; set; }
        [XmlAttribute(AttributeName = "RfcSolicitante")]
        public string RfcSolicitante { get; set; }

        [XmlAnyElement]
        public XmlElement Signature { get; set; }
    }
}