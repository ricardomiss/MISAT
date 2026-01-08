using System.Security.Cryptography.X509Certificates;

namespace MiSAT.Models
{
    /// <summary>
    /// Representa una solicitud para la descarga de documentos recibidos.
    /// </summary>
    public class SolicitudDescargaRecibidos : SolicitudDescarga
    {
        /// <summary>
        /// Fecha inicial del rango de descarga.
        /// </summary>
        public DateTime FechaInicial { get; set; }
        /// <summary>
        /// Fecha final del rango de descarga.
        /// </summary>
        public DateTime FechaFinal { get; set; }
        /// <summary>
        /// RFC receptor el cual corresponde con el contribuyente del cual se requiere la información
        /// </summary>
        public string RfcReceptor { get; set; }
        /// <summary>
        /// RFC del emisor del cual se quiere consultar los CFDIs
        /// </summary>
        public string RfcEmisor { get; set; }
        /// <summary>
        /// Tipo de solicitud para la descarga.
        /// </summary>
        public string TipoSolicitud { get; set; }
        /// <summary>
        /// Tipo de comprobante a consultar.
        /// </summary>
        public string? TipoComprobante { get; set; }
        /// <summary>
        /// Estado del comprobante a consultar.
        /// </summary>
        public string EstadoComprobante { get; set; }
        /// <summary>
        /// RFC del a cuenta a tercero del cual se quiere consultar los CFDIs
        /// </summary>
        public string RfcCuentaTerceros { get; set; }
        /// <summary>
        /// Complemento asociado a los CFDIs a descargar
        /// </summary>
        public string? Complemento { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SolicitudDescargaRecibidos"/> para solicitar la descarga de
        /// documentos recibidos dentro de un rango de fechas especificado para un RFC receptor dado, utilizando el certificado proporcionado.
        /// </summary>
        /// <remarks> El RFC receptor se utiliza tanto como receptor como solicitante en la solicitud de descarga. 
        /// Asegúrese de que el certificado corresponda al RFC especificado para una solicitud exitosa.</remarks>
        /// <param name="fechaInicial">La fecha de inicio del período para el cual se solicitan los documentos recibidos. Debe ser menor o igual a
        /// <paramref name="fechaFinal"/>.</param>
        /// <param name="fechaFinal">La fecha final del período para el cual se solicitan los documentos recibidos. Debe ser mayor o igual a
        /// <paramref name="fechaInicial"/>.</param>
        /// <param name="rfcReceptor">El RFC del receptor cuyos documentos se descargarán.</param>
        /// <param name="certificado">El certificado X.509 utilizado para autenticar la solicitud.</param>
        /// <param name="estadoComprobante">El estado del comprobante a consultar.</param>
        /// <param name="tipoSolicitud">El tipo de datos a solicitar.</param>
        public SolicitudDescargaRecibidos(
            DateTime fechaInicial, DateTime fechaFinal, string rfcReceptor, X509Certificate2 certificado, 
            string estadoComprobante = EstadosComprobante.Vigente, string tipoSolicitud = TiposSolicitud.CFDI) : base() 
        {
            FechaInicial = fechaInicial;
            FechaFinal = fechaFinal;
            RfcReceptor = rfcReceptor;
            RfcSolicitante = rfcReceptor;
            Certificado = certificado;
            EstadoComprobante = estadoComprobante;
            TipoSolicitud = tipoSolicitud;
        }

        internal override bool Validar()
        {
            if (string.IsNullOrEmpty(RfcReceptor))
                throw new InvalidOperationException("El RFC del receptor no puede estar vacío.");
            return true;
        }
    }
}
