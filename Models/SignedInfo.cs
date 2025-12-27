using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "SignedInfo")]
    public class SignedInfo
    {
        [XmlElement(ElementName = "CanonicalizationMethod")]
        public CanonicalizationMethod CanonicalizationMethod { get; set; }
        [XmlElement(ElementName = "SignatureMethod")]
        public SignatureMethod SignatureMethod { get; set; }
        [XmlElement(ElementName = "Reference")]
        public Reference Reference { get; set; }
    }

    [XmlRoot(ElementName = "CanonicalizationMethod")]
    public class CanonicalizationMethod
    {
        [XmlAttribute(AttributeName = "Algorithm")]
        public string Algorithm { get; set; } = "http://www.w3.org/2001/10/xml-exc-c14n#";
    }

    [XmlRoot(ElementName = "SignatureMethod")]
    public class SignatureMethod
    {
        [XmlAttribute(AttributeName = "Algorithm")]
        public string Algorithm { get; set; } = "http://www.w3.org/2000/09/xmldsig#rsa-sha1";
    }
}