using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "Parte")]
    public class Parte
    {
        [XmlElement(ElementName = "InformacionAduanera")]
        public InformacionAduanera InformacionAduanera { get; set; }

        [XmlAttribute(AttributeName = "ClaveProdServ")]
        public string ClaveProdServ { get; set; }
        [XmlAttribute(AttributeName = "NoIdentificacion")]
        public string NoIdentificacion { get; set; }
        [XmlAttribute(AttributeName = "Cantidad")]
        public decimal Cantidad { get; set; }
        [XmlAttribute(AttributeName = "Unidad")]
        public string Unidad { get; set; }
        [XmlAttribute(AttributeName = "Descripcion")]
        public string Descripcion { get; set; }
        [XmlAttribute(AttributeName = "ValorUnitario")]
        public decimal ValorUnitario { get; set; }
        [XmlAttribute(AttributeName = "Importe")]
        public decimal Importe { get; set; }
    }
}