using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "Signature")]
    public class Signature
    {
        [XmlElement(ElementName = "SignedInfo")]
        public SignedInfo SignedInfo { get; set; }
        [XmlElement(ElementName = "SignatureValue")]
        public string SignatureValue { get; set; }
        [XmlElement(ElementName = "KeyInfo")]
        public KeyInfo KeyInfo { get; set; }
    }
}