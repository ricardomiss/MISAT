using MiSAT.Models;
using MiSAT.Service;
using MiSAT.Utilities;
using System.Xml;
using System.Xml.Serialization;

namespace MiSAT
{
    /// <summary>
    /// Proporciona métodos para documentos CFDI del SAT.
    /// </summary>
    public static class CFDI
    {
        private static readonly ConsultaCFDIService _consultaCFDIService = new ConsultaCFDIService();

        /// <summary>
        /// Crea una instancia <see cref="Comprobante"/> apartir del contenido del XML.
        /// </summary>
        /// <param name="xml">Objeto XmlDocument que contiene el XML del CFDI</param>
        /// <returns> Un objeto <see cref="Comprobante"/> deserializado desde el XML proporcionado</returns>
        /// <exception cref="InvalidOperationException">Se lanza cuando el XML no tiene un elemento raíz, no contiene el espacio de nombres 'cfdi' o no se puede deserializar en un objeto Comprobante.</exception>
        public static Comprobante Obtener(XmlDocument xml)
        {
            var root = xml.DocumentElement ?? throw new InvalidOperationException("El documento XML no tiene un elemento raíz.");
            var xmlNamespace = root.GetAttribute("xmlns:cfdi");
            if (string.IsNullOrEmpty(xmlNamespace))
                throw new InvalidOperationException("El espacio de nombres 'cfdi' no se encontró en el XML.");

            XmlSerializer serializer = new XmlSerializer(typeof(Comprobante), xmlNamespace);
            using var reader = new XmlNodeReader(xml);
            if (serializer.Deserialize(reader) is not Comprobante cfdi)
                throw new InvalidOperationException("No se pudo deserializar el CFDI");
            return cfdi;
        }

        /// <summary>
        /// Crea una instancia <see cref="Comprobante"/> apartir del contenido del XML.
        /// </summary>
        /// <param name="xmlContent"> Un string que contiene la representación XML del <see cref="Comprobante"/>. Debe ser un documento XML bien formado.</param>
        /// <returns>Un objeto <see cref="Comprobante"/> deserializado desde el contenido XML proporcionado.</returns>
        public static Comprobante Obtener(string xmlContent)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlContent);
            return Obtener(xmlDoc);
        }

        /// <summary>
        /// Genera una solicitud de consulta CFDI en formato XML a partir de una instancia de <see cref="SolicitudConsultaCFDI"/>.
        /// </summary>
        /// <param name="solicitud">Un objeto <see cref="SolicitudConsultaCFDI"/> que contiene los datos para la consulta.</param>
        /// <returns>Un <see cref="string"/> que representa la solicitud de consulta en formato XML.</returns>

        public static string GenerarSolicitudConsulta(SolicitudConsultaCFDI solicitud)
        {
            return _consultaCFDIService.GenerarSolicitudConsulta(solicitud);
        }

        /// <summary>
        /// Genera una solicitud de consulta CFDI en formato XML a partir de una instancia de <see cref="Comprobante"/>.
        /// </summary>
        /// <param name="comprobante">Un objeto <see cref="Comprobante"/> donde contengan los datos para la consulta.</param>
        /// <returns>Un <see cref="string"/> que representa la solicitud de consulta en formato XML.</returns>
        public static string GenerarSolicitudConsulta(Comprobante comprobante)
        {
            return _consultaCFDIService.GenerarSolicitudConsulta(new SolicitudConsultaCFDI
            {
                RFCEmisor = comprobante.Emisor?.Rfc ?? string.Empty,
                RFCReceptor = comprobante.Receptor?.Rfc ?? string.Empty,
                Total = comprobante.Total,
                Sello = comprobante.Sello,
                UUID = comprobante.Complemento?.TimbreFiscalDigital?.UUID ?? string.Empty
            });
        }

        /// <summary>
        /// Deserializa el contenido XML de una respuesta de consulta CFDI en un objeto <see cref="ConsultaResponse"/>.
        /// </summary>
        /// <param name="xmlContent">Objeto XmlDocument que contiene la respuesta de consulta CFDI en formato XML.</param>
        /// <returns>Un objeto <see cref="ConsultaResponse"/> deserializado desde el contenido XML proporcionado.</returns>
        public static ConsultaResponse DeserializarConsulta(XmlDocument xmlContent) 
            => _consultaCFDIService.DeserializarConsultaCFDI(xmlContent);

        /// <summary>
        /// Deserializa el contenido XML de una respuesta de consulta CFDI en un objeto <see cref="ConsultaResponse"/>.
        /// </summary>
        /// <param name="xmlContent">Un string que contiene la respuesta de consulta CFDI en formato XML.</param>
        /// <returns>Un objeto <see cref="ConsultaResponse"/> deserializado desde el contenido XML proporcionado.</returns>
        public static ConsultaResponse DeserializarConsulta(string xmlContent) 
            => _consultaCFDIService.DeserializarConsultaCFDI(xmlContent.GetXmlElement());
    }
}
