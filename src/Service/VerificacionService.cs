using MiSAT.Models;
using MiSAT.Utilities;
using System.Xml;

namespace MiSAT.Service
{
    internal class VerificacionService
    {
        public string GenerarSolicitudVerificacion(SolicitudVerificacion solicitud)
        {

            solicitud sol = CreateSolicitud(solicitud);
            XmlElement node = sol.GetNodoSolicitud();
            XmlElement firma = XmlGeneratorUtility.GetNodoFirmado(node, solicitud.Certificado);
            sol.Signature = firma;
            XmlElement envelope = CreateEnvelope(sol);
            return envelope.OuterXml;
        }

        private solicitud CreateSolicitud(SolicitudVerificacion solicitud)
        {
            return new solicitud
            {
                IdSolicitud = solicitud.IdSolicitud,
                RfcSolicitante = solicitud.RfcSolicitante
            };
        }

        private XmlElement CreateEnvelope(solicitud sol)
        {
            return new Envelope
            {
                Header = new Header(),
                Body = new Body
                {
                    VerificaSolicitudDescarga = new VerificaSolicitudDescarga
                    {
                        Solicitud = sol
                    }
                }
            }.GetEnvelope();
        }
    }
}
