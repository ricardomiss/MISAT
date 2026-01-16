using MiSAT.Models;
using MiSAT.Utilities;
using System.Xml;

namespace MiSAT.Service
{
    internal class DescargaPaquetesService
    {
        public string GenerarSolicitudDescarga(SolicitudDescargaPaquetes solicitud)
        {
            peticionDescarga peticion = GenerarPeticionDescarga(solicitud);
            XmlElement peticionNode = peticion.GetNodo();
            XmlElement firma = XmlGeneratorUtility.GetNodoFirmado(peticionNode, solicitud.Certificado);
            peticion.Signature = firma;
            return GenerarSolicitudXML(peticion).OuterXml;
        }

        internal PaqueteResponse ObtenerPaquete(XmlDocument xmlContent)
        {
            PaqueteResponse response = XmlGeneratorUtility.DeserializarEnvelope(xmlContent, envelope => 
            {
                PaqueteResponse model = new PaqueteResponse();
                model.CodEstatus = envelope.Header.Respuesta.CodEstatus;
                model.Mensaje = envelope.Header.Respuesta.Mensaje;
                
                if(!string.IsNullOrEmpty(envelope.Body.RespuestaDescargaMasivaTercerosSalida.Paquete))
                    model.Paquete = Convert.FromBase64String(envelope.Body.RespuestaDescargaMasivaTercerosSalida.Paquete);

                return model;
            });

            return response;
        }

        private peticionDescarga GenerarPeticionDescarga(SolicitudDescargaPaquetes solicitud)
        {
            return new peticionDescarga
            {
                RfcSolicitante = solicitud.RfcSolicitante,
                IdPaquete = solicitud.IdPaquete,
            };
        }

        private XmlElement GenerarSolicitudXML(peticionDescarga peticion)
        {
            return new Envelope
            {
                Header = new Header(),
                Body = new Body
                {
                    PeticionDescargaMasivaTercerosEntrada = new PeticionDescargaMasivaTercerosEntrada
                    {
                        PeticionDescarga = peticion
                    }
                }
            }.GetEnvelope();
        }
    }
}
