using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "Comprobante")]
    public class Comprobante
    {
        [XmlElement(ElementName = "InformacionGlobal")]
        public InformacionGlobal InformacionGlobal { get; set; }
        [XmlElement(ElementName = "CfdiRelacionados")]
        public CfdiRelacionados CfdiRelacionados { get; set; }
        [XmlElement(ElementName = "Emisor")]
        public Emisor Emisor { get; set; }
        [XmlElement(ElementName = "Receptor")]
        public Receptor Receptor { get; set; }
        [XmlElement(ElementName = "Conceptos")]
        public Conceptos Conceptos { get; set; }
        [XmlElement(ElementName = "Impuestos")]
        public Impuestos Impuestos { get; set; }
        [XmlElement(ElementName = "Complemento")]
        public Complemento Complemento { get; set; }

        [XmlAttribute(AttributeName = "Version")]
        public string Version { get; set; }
        [XmlAttribute(AttributeName = "Serie")]
        public string Serie { get; set; }
        [XmlAttribute(AttributeName = "Folio")]
        public string Folio { get; set; }
        [XmlAttribute(AttributeName = "Fecha")]
        public DateTime Fecha { get; set; }
        [XmlAttribute(AttributeName = "Sello")]
        public string Sello { get; set; }
        [XmlAttribute(AttributeName = "FormaPago")]
        public string FormaPago { get; set; }
        [XmlAttribute(AttributeName = "NoCertificado")]
        public string NoCertificado { get; set; }
        [XmlAttribute(AttributeName = "Certificado")]
        public string Certificado { get; set; }
        [XmlAttribute(AttributeName = "CondicionesDePago")]
        public string CondicionesDePago { get; set; }
        [XmlAttribute(AttributeName = "SubTotal")]
        public string SubTotal { get; set; }
        [XmlAttribute(AttributeName = "Descuento")]
        public string Descuento { get; set; }
        [XmlAttribute(AttributeName = "Moneda")]
        public string Moneda { get; set; }
        [XmlAttribute(AttributeName = "TipoCambio")]
        public string TipoCambio { get; set; }
        [XmlAttribute(AttributeName = "Total")]
        public string Total { get; set; }
        [XmlAttribute(AttributeName = "TipoDeComprobante")]
        public string TipoDeComprobante { get; set; }
        [XmlAttribute(AttributeName = "Exportacion")]
        public string Exportacion { get; set; }
        [XmlAttribute(AttributeName = "MetodoPago")]
        public string MetodoPago { get; set; }
        [XmlAttribute(AttributeName = "LugarExpedicion")]
        public string LugarExpedicion { get; set; }
        [XmlAttribute(AttributeName = "Confirmacion")]
        public string Confirmacion { get; set; }
    }
}
