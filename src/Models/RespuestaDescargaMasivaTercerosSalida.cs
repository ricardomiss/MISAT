using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "RespuestaDescargaMasivaTercerosSalida", Namespace = WSNamespaces.dmt2)]

    public class RespuestaDescargaMasivaTercerosSalida
    {
        [XmlElement(ElementName = "Paquete", Namespace = WSNamespaces.dmt2)]
        public string Paquete { get; set; }

    }
}