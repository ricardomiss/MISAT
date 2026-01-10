using System.Security.Cryptography.X509Certificates;

namespace MiSAT.Models
{
    /// <summary>
    /// Representa una solicitud para la descarga de un CFDI.
    /// </summary>
    public class SolicitudDescargaFolio : SolicitudDescarga
    {
        public string Folio { get; set; }
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SolicitudDescargaFolio"/>.
        /// </summary>
        /// <param name="folio">El folio para la solicitud de descarga. No puede ser <see langword="null"/> o vacío.</param>
        /// <param name="rfcSolicitante">El RFC del solicitante. Puede ser <see langword="null"/> si no aplica.</param>
        /// <param name="certificado">El certificado X.509 utilizado para autenticar la solicitud.</param>
        public SolicitudDescargaFolio(string folio, X509Certificate2 certificado, string? rfcSolicitante = null)
        {
            Folio = folio;
            Certificado = certificado;
            if (!string.IsNullOrWhiteSpace(rfcSolicitante))
                RfcSolicitante = rfcSolicitante;
        }

        internal override bool Validar()
        {
            if (string.IsNullOrWhiteSpace(Folio))
            {
                throw new InvalidOperationException("El folio no puede estar vacío.");
            }
            return true;
        }
    }
}
