using MiSAT.Models;
using MiSAT.Utilities;
using System.Xml;

namespace MiSAT.Strategies
{
    internal class SolicitudDescargaEmitidosStrategy : SolicitudDescargaStrategy
    {
        private SolicitudDescargaEmitidos _solicitudEmitidos;

        public SolicitudDescargaEmitidosStrategy(SolicitudDescarga solicitud) : base(solicitud)
        {
            this._solicitudEmitidos = solicitud as SolicitudDescargaEmitidos ?? throw new ArgumentException("Invalid solicitud type", nameof(solicitud)); 
        }

        public override solicitud GenerarSolicitud()
        {
            List<RfcReceptores> receptores = _solicitudEmitidos.RfcReceptor?.Select(rfc => new RfcReceptores { RfcReceptor = rfc }).ToList() ?? new List<RfcReceptores>();

            var solicitud = new solicitud()
            {
                FechaInicial = _solicitudEmitidos.FechaInicial.ToXmlString(),
                FechaFinal = _solicitudEmitidos.FechaFinal.ToXmlString(),
                RfcReceptores = receptores,
                RfcEmisor = _solicitudEmitidos.RfcEmisor,
                RfcSolicitante = _solicitudEmitidos.RfcSolicitante,
                TipoSolicitud = _solicitudEmitidos.TipoSolicitud,
                TipoComprobante = _solicitudEmitidos.TipoComprobante,
                EstadoComprobante = _solicitudEmitidos.EstadoComprobante,
                RfcACuentaTerceros = _solicitudEmitidos.RfcCuentaTerceros,
                Complemento = _solicitudEmitidos.Complemento
            };
            return solicitud;
        }

        public override XmlElement GenerarSolicitudXML(solicitud sol)
        {
            return GenerarXML(new Envelope
            {
                Header = new Header(),
                Body = new Body
                {
                    SolicitaDescargaEmitidos = new SolicitaDescargaEmitidos
                    {
                        Solicitud = sol
                    }
                }
            });
        }
    }
}
