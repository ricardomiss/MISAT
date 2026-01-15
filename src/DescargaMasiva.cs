using MiSAT.Models;
using MiSAT.Service;
using MiSAT.Utilities;
using System.Xml;

namespace MiSAT
{
    /// <summary>
    /// Provee métodos para las operaciones de descarga masiva del SAT.
    /// </summary>
    public static class DescargaMasiva
    {
        private static readonly AutenticacionService _authService = new AutenticacionService();
        private static readonly DescargaService _descargaService = new DescargaService();
        private static readonly VerificacionService _verificacionService = new VerificacionService();

        #region Autenticación

        /// <summary>
        /// Genera la solicitud de autenticación en formato XML a partir de un objeto <see cref="Autenticacion"/>.
        /// </summary>
        /// <param name="request">Objeto de autenticación con los datos necesarios</param>
        /// <returns>Un <see cref="string"/> con la solicitud de autenticación en formato XML</returns>
        public static string GenerarSolicitudAutenticacion(Autenticacion request) => _authService.GenerarSolicitudAutenticacion(request);

        /// <summary>
        /// Deserializa un documento XML en un objeto Envelope que representa la respuesta de autenticación.
        /// </summary>
        /// <param name="xmlContent">El documento XML que contiene la respuesta de autenticación.</param>
        /// <returns>Un objeto <see cref="Envelope"/> que representa la respuesta de autenticación deserializada.</returns>
        /// <exception cref="InvalidOperationException">Se lanza si el documento XML no tiene un elemento raíz o si no se puede deserializar la respuesta de autenticación.</exception>
        public static Envelope DeserializarAutenticacion(XmlDocument xmlContent) => _authService.DeserializarEnvelope(xmlContent);

        /// <summary>
        /// Deserializa un documento XML en un objeto Envelope que representa la respuesta de autenticación.
        /// </summary>
        /// <param name="xmlContent">El documento XML que contiene la respuesta de autenticación.</param>
        /// <returns>Un objeto <see cref="Envelope"/> que representa la respuesta de autenticación deserializada.</returns>
        public static Envelope DeserializarAutenticacion(string xmlContent) => _authService.DeserializarEnvelope(xmlContent.GetXmlElement());

        #endregion

        #region Solicitud de Descarga

        /// <summary>
        /// Genera la solicitud de descarga en formato XML a partir de un objeto <see cref="SolicitudDescargaEmitidos"/>.
        /// </summary>
        /// <param name="solicitud">Objeto de solicitud con los datos necesarios</param>
        /// <returns>Un <see cref="string"/> con la solicitud de descarga de emitidos en formato XML</returns>
        public static string GenerarSolicitudDescarga(SolicitudDescargaEmitidos solicitud) 
            => _descargaService.GenerarSolicitudDescarga(solicitud);

        /// <summary>
        /// Genera la solicitud de descarga en formato XML a partir de un objeto <see cref="SolicitudDescargaRecibidos"/>.
        /// </summary>
        /// <param name="solicitud">Objeto de solicitud con los datos necesarios</param>
        /// <returns>Un <see cref="string"/> con la solicitud de descarga de recibidos en formato XML</returns>
        public static string GenerarSolicitudDescarga(SolicitudDescargaRecibidos solicitud) 
            => _descargaService.GenerarSolicitudDescarga(solicitud);
        
        /// <summary>
        /// Genera la solicitud de descarga en formato XML a partir de un objeto <see cref="SolicitudDescargaFolio"/>.
        /// </summary>
        /// <param name="solicitud">Objeto de solicitud con los datos necesarios</param>
        /// <returns>Un <see cref="string"/> con la solicitud de descarga de folio en formato XML</returns>
        public static string GenerarSolicitudDescarga(SolicitudDescargaFolio solicitud) 
            => _descargaService.GenerarSolicitudDescarga(solicitud);

        /// <summary>
        /// Deserializa un documento XML en un objeto Envelope que representa la respuesta de descarga.
        /// </summary>
        /// <param name="xmlContent">El documento XML que contiene la respuesta de descarga.</param>
        /// <returns>Un objeto <see cref="Envelope"/> que representa la respuesta de descarga deserializada.</returns>
        public static SolicitaDescargaResponse DeserializarDescarga(XmlDocument xmlContent) => _descargaService.DeserializarEnvelope(xmlContent);

        /// <summary>
        /// Deserializa un documento XML en un objeto Envelope que representa la respuesta de descarga.
        /// </summary>
        /// <param name="xmlContent">El documento XML que contiene la respuesta de descarga.</param>
        /// <returns>Un objeto <see cref="Envelope"/> que representa la respuesta de descarga deserializada.</returns>
        public static SolicitaDescargaResponse DeserializarDescarga(string xmlContent) => _descargaService.DeserializarEnvelope(xmlContent.GetXmlElement());

        #endregion

        #region Solicitud de Verificación

        /// <summary>
        /// Genera la solicitud de verificación en formato XML a partir de un objeto <see cref="SolicitudVerificacion"/>.
        /// </summary>
        /// <param name="solicitud">Objeto de solicitud con los datos necesarios</param>
        /// <returns>Un <see cref="string"/> con la solicitud de verificación en formato XML</returns>
        public static string GenerarSolicitudVerificacion(SolicitudVerificacion solicitud) => _verificacionService.GenerarSolicitudVerificacion(solicitud);

        /// <summary>
        /// Deserializa un documento XML en un objeto <see cref="Envelope"/> que representa la respuesta de verificación.
        /// </summary>
        /// <param name="xmlContent">El documento XML que contiene la respuesta de verificación.</param>
        /// <returns>Un objeto <see cref="VerificaSolicitudDescargaResponse"/> que representa la respuesta de verificación deserializada.</returns>
        public static VerificaSolicitudDescargaResponse DeserializarVerificacion(XmlDocument xmlContent) => _verificacionService.DeserializarEnvelope(xmlContent);

        /// <summary>
        /// Deserializa un documento XML en un objeto <see cref="Envelope"/> que representa la respuesta de verificación.
        /// </summary>
        /// <param name="xmlContent">El documento XML que contiene la respuesta de verificación.</param>
        /// <returns>Un objeto <see cref="VerificaSolicitudDescargaResponse"/> que representa la respuesta de verificación deserializada.</returns>
        public static VerificaSolicitudDescargaResponse DeserializarVerificacion(string xmlContent) => _verificacionService.DeserializarEnvelope(xmlContent.GetXmlElement());

        #endregion
    }
}
