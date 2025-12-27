using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "Transforms")]
    public class Transforms
    {
        [XmlElement(ElementName = "Transforms")]
        public Transform Transform { get; set; }
    }

    [XmlRoot(ElementName = "Transforms")]
    public class Transform
    {
        [XmlAttribute(AttributeName = "Algorithm")]
        public string Algorithm { get; set; } = "http://www.w3.org/2001/10/xml-exc-c14n#";
    }
}