using MiSAT.Models;
using System.Xml;

namespace MiSAT.Strategies
{
    internal class SolicitudDescargaFolioStrategy : SolicitudDescargaStrategy
    {
        private SolicitudDescargaFolio _solicitudFolio;

        public SolicitudDescargaFolioStrategy(SolicitudDescarga solicitud) : base(solicitud)
        {
            this._solicitudFolio = solicitud as SolicitudDescargaFolio ?? throw new ArgumentException("Invalid solicitud type", nameof(solicitud));
        }

        public override solicitud GenerarSolicitud()
        {
            return new solicitud
            {
                RfcSolicitante = _solicitudFolio.RfcSolicitante,
                Folio = _solicitudFolio.Folio
            };
        }

        public override XmlElement GenerarSolicitudXML(solicitud sol)
        {
            return GenerarXML(new Envelope
            {
                Header = new Header(),
                Body = new Body
                {
                    SolicitaDescargaFolio = new SolicitaDescargaFolio
                    {
                        Solicitud = sol
                    }
                }
            });
        }
    }
}
