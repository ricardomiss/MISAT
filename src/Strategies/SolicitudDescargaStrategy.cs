using MiSAT.Interfaces;
using MiSAT.Models;
using System.Security.Cryptography.Xml;
using System.Xml;
using System.Xml.Serialization;

namespace MiSAT.Strategies
{
    internal abstract class SolicitudDescargaStrategy : ISolicitudDescargaStrategy
    {
        protected SolicitudDescarga _solicitud;

        protected SolicitudDescargaStrategy(SolicitudDescarga solicitud)
        {
            _solicitud = solicitud;
        }

        protected XmlElement GenerarXML(Envelope envelope)
        {
            var doc = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(typeof(Envelope));

            var ns = new XmlSerializerNamespaces();
            ns.Add("soapenv", WSNamespaces.s);
            ns.Add("des", WSNamespaces.dmt2);
            ns.Add("xd", SignedXml.XmlDsigNamespaceUrl);

            using (XmlWriter writer = doc.CreateNavigator()!.AppendChild())
            {
                serializer.Serialize(writer, envelope, ns);
            }
            return doc.DocumentElement!;
        }

        public abstract solicitud GenerarSolicitud();
        public abstract XmlElement GenerarSolicitudXML(solicitud sol);
    }
}
