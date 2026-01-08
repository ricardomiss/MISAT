using MiSAT.Models;
using MiSAT.Utilities;
using System.Xml;

namespace MiSAT.Strategies
{
    internal class SolicitudDescargaRecibidosStrategy : SolicitudDescargaStrategy
    {
        private SolicitudDescargaRecibidos _solicitudRecibidos;

        public SolicitudDescargaRecibidosStrategy(SolicitudDescarga solicitud) : base(solicitud)
        {
            this._solicitudRecibidos = solicitud as SolicitudDescargaRecibidos ?? throw new ArgumentException("Invalid solicitud type", nameof(solicitud));
        }

        public override solicitud GenerarSolicitud()
        {
            var solicitud = new solicitud()
            {
                FechaInicial = _solicitudRecibidos.FechaInicial.ToXmlString(),
                FechaFinal = _solicitudRecibidos.FechaFinal.ToXmlString(),
                RfcReceptor = _solicitudRecibidos.RfcReceptor,
                RfcEmisor = _solicitudRecibidos.RfcEmisor,
                RfcSolicitante = _solicitudRecibidos.RfcSolicitante,
                TipoSolicitud = _solicitudRecibidos.TipoSolicitud,
                EstadoComprobante = _solicitudRecibidos.EstadoComprobante,
                Complemento = _solicitudRecibidos.Complemento,
                TipoComprobante = _solicitudRecibidos.TipoComprobante,
                RfcACuentaTerceros = _solicitudRecibidos.RfcCuentaTerceros
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
                    SolicitaDescargaRecibidos = new SolicitaDescargaRecibidos
                    {
                        Solicitud = sol
                    }
                }
            });
        }
    }
}
