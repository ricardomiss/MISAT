using MiSAT.Interfaces;
using MiSAT.Models;
using MiSAT.Strategies;
using MiSAT.Utilities;
using System.Xml;

namespace MiSAT.Service
{
    internal class DescargaService
    {
        public string GenerarSolicitudDescarga(SolicitudDescarga solicitud)
        {
            ISolicitudDescargaStrategy strategy = ObtenerStrategy(solicitud);
            solicitud.Validar();
            solicitud sol = strategy.GenerarSolicitud();
            XmlElement solicitudNode = sol.GetNodoSolicitud();
            XmlElement signature = XmlGeneratorUtility.GetNodoFirmado(solicitudNode, solicitud.Certificado);
            sol.Signature = signature;
            return strategy.GenerarSolicitudXML(sol).OuterXml;
        }

        private ISolicitudDescargaStrategy ObtenerStrategy(SolicitudDescarga solicitud)
        {
            return solicitud switch
            {
                SolicitudDescargaEmitidos emitidos => new SolicitudDescargaEmitidosStrategy(solicitud),
                SolicitudDescargaRecibidos recibidos => new SolicitudDescargaRecibidosStrategy(solicitud),
                SolicitudDescargaFolio folio => new SolicitudDescargaFolioStrategy(solicitud),
                _ => throw new NotImplementedException("Tipo de Solicitud no esperada")
            };
        }
    }
}
