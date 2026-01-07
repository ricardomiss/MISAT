using System.Security.Cryptography.X509Certificates;

namespace MiSAT.Models
{
    /// <summary>
    /// Representa una solicitud para la descarga de documentos emitidos.
    /// </summary>
    public class SolicitudDescargaEmitidos : SolicitudDescarga
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
        /// RFCs receptores de los cuales se quiere consultar los CFDIs
        /// </summary>
        public string[]? RfcReceptor { get; set; }
        /// <summary>
        /// RFC del emisor del cual se quiere consultar los CFDIs
        /// </summary>
        public string RfcEmisor { get; set; }
        /// <summary>
        /// Tipo de solicitud para la descarga.
        /// </summary>
        public string TipoSolicitud { get; set; } = TiposSolicitud.CFDI;
        /// <summary>
        /// Tipo de comprobante a consultar.
        /// </summary>
        public string? TipoComprobante { get; set; }
        /// <summary>
        /// Estado del comprobante a consultar.
        /// </summary>
        public string EstadoComprobante { get; set; } = EstadosComprobante.Vigente;
        /// <summary>
        /// RFC del a cuenta a tercero del cual se quiere consultar los CFDIs
        /// </summary>
        public string RfcCuentaTerceros { get; set; }
        /// <summary>
        /// Complemento asociado a los CFDIs a descargar
        /// </summary>
        public string? Complemento { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SolicitudDescargaEmitidos"/> para solicitar la descarga de
        /// documentos emitidos dentro de un rango de fechas especificado para un RFC emisor dado, utilizando el certificado proporcionado.
        /// </summary>
        /// <remarks> El RFC emisor se utiliza tanto como emisor como solicitante en la solicitud de descarga. 
        /// Asegúrese de que el certificado corresponda al RFC especificado para una solicitud exitosa.</remarks>
        /// <param name="fechaInicial">La fecha de inicio del período para el cual se solicitan los documentos emitidos. Debe ser menor o igual a
        /// <paramref name="fechaFinal"/>.</param>
        /// <param name="fechaFinal">La fecha final del período para el cual se solicitan los documentos emitidos. Debe ser mayor o igual a
        /// <paramref name="fechaInicial"/>.</param>
        /// <param name="rfcEmisor">El RFC del emisor cuyos documentos se descargarán.</param>
        /// <param name="certificado">El certificado X.509 utilizado para autenticar la solicitud.</param>
        public SolicitudDescargaEmitidos(DateTime fechaInicial, DateTime fechaFinal, string rfcEmisor, X509Certificate2 certificado) : base()
        {
            FechaInicial = fechaInicial;
            FechaFinal = fechaFinal;
            RfcEmisor = rfcEmisor;
            RfcSolicitante = rfcEmisor;
            Certificado = certificado;
        }

        internal override bool Validar()
        {
            if (string.IsNullOrEmpty(RfcEmisor))
                throw new InvalidOperationException("El RFC del emisor no puede estar vacío.");

            return true;
        }
    }
}
