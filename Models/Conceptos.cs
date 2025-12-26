using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "Conceptos")]
    public class Conceptos
    {
        [XmlElement(ElementName = "Concepto")]
        public List<Concepto> Concepto { get; set; }
    }

    [XmlRoot(ElementName = "Concepto")]
    public class Concepto
    {
        [XmlElement(ElementName = "Impuestos")]
        public Impuestos Impuestos { get; set; }
        [XmlElement(ElementName = "ACuentaTerceros")]
        public ACuentaTerceros ACuentaTerceros { get; set; }
        [XmlElement(ElementName = "InformacionAduanera")]
        public InformacionAduanera InformacionAduanera { get; set; }
        [XmlElement(ElementName = "CuentaPredial")]
        public CuentaPredial CuentaPredial { get; set; }
        [XmlElement(ElementName = "ComplementoConcepto")]
        public ComplementoConcepto ComplementoConcepto { get; set; }
        [XmlElement(ElementName = "Parte")]
        public Parte Parte { get; set; }


        [XmlAttribute(AttributeName = "ClaveProdServ")]
        public string ClaveProdServ { get; set; }
        [XmlAttribute(AttributeName = "NoIdentificacion")]
        public string NoIdentificacion { get; set; }
        [XmlAttribute(AttributeName = "Cantidad")]
        public decimal Cantidad { get; set; }
        [XmlAttribute(AttributeName = "ClaveUnidad")]
        public string ClaveUnidad { get; set; }
        [XmlAttribute(AttributeName = "Unidad")]
        public string Unidad { get; set; }
        [XmlAttribute(AttributeName = "Descripcion")]
        public string Descripcion { get; set; }
        [XmlAttribute(AttributeName = "ValorUnitario")]
        public decimal ValorUnitario { get; set; }
        [XmlAttribute(AttributeName = "Importe")]
        public decimal Importe { get; set; }
        [XmlAttribute(AttributeName = "Descuento")]
        public decimal Descuento { get; set; }
        [XmlAttribute(AttributeName = "ObjetoImp")]
        public string ObjetoImp { get; set; }
    }
}