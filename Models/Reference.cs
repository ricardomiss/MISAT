using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "Reference")]
    public class Reference
    {
        [XmlElement(ElementName = "Transforms")]
        public Transforms Transforms { get; set; }
        [XmlElement(ElementName = "DigestMethod")]
        public DigestMethod DigestMethod { get; set; } 
        [XmlElement(ElementName = "DigestValue")]
        public string DigestValue { get; set; }

        [XmlAttribute(AttributeName = "URI")]
        public string URI { get; set; } = "#_0";
    }

    [XmlRoot(ElementName = "DigestMethod")]
    public class DigestMethod
    {
        [XmlAttribute(AttributeName = "Algorithm")]
        public string Algorithm { get; set; } = "http://www.w3.org/2000/09/xmldsig#sha1";
    }
}