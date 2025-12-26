using System.Xml.Serialization;

namespace MiSAT.Models
{
    [XmlRoot(ElementName = "Complemento")]
    public class Complemento
    {
        [XmlElement(ElementName = "Nomina", Namespace = "http://www.sat.gob.mx/nomina12")]
        public Nomina Nomina { get; set; }
        [XmlElement(ElementName = "TimbreFiscalDigital", Namespace = "http://www.sat.gob.mx/TimbreFiscalDigital")]
        public TimbreFiscalDigital TimbreFiscalDigital { get; set; }
        [XmlElement(ElementName = "Addenda")]
        public Addenda Addenda { get; set; }
    }
}