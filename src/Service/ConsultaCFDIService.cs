
using MiSAT.Models;
using MiSAT.Utilities;
using System.Xml;
using System.Xml.Serialization;

namespace MiSAT.Service
{
    internal class ConsultaCFDIService
    {
        public string GenerarSolicitudConsulta(SolicitudConsultaCFDI solicitud)
        {
            XmlNode cdata = GenerarCData(solicitud);
            Envelope envelope = new Envelope
            {
                Header = new Header(),
                Body = new Body
                {
                    Consulta = new Consulta
                    {
                        ExpresionImpresa = cdata
                    }
                }
            };

            XmlDocument xml = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(typeof(Envelope));
            XmlSerializerNamespaces ns = GenerateNamespaces();

            using (XmlWriter writer = xml.CreateNavigator().AppendChild())
            {
                serializer.Serialize(writer, envelope, GenerateNamespaces());
            }

            return xml.OuterXml;
        }

        public ConsultaResponse DeserializarConsultaCFDI(XmlDocument xmlContent)
        {
            return XmlGeneratorUtility.DeserializarEnvelope<ConsultaResponse>(xmlContent, envelope => envelope.Body.ConsultaResponse);
        }

        private XmlNode GenerarCData(SolicitudConsultaCFDI solicitud)
        {
            string content = $@"?re={solicitud.RFCEmisor}&rr={solicitud.RFCReceptor}&tt={solicitud.Total}&id={solicitud.UUID}";
            XmlDocument xml = new XmlDocument();
            XmlNode cdata = xml.CreateCDataSection(content);
            return cdata;
        }

        private XmlSerializerNamespaces GenerateNamespaces()
        {
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("soapenv", WSNamespaces.s);
            namespaces.Add("tem", WSNamespaces.tem);
            return namespaces;
        }
    }
}
