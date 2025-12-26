using MiSAT.Models;
using System.Xml;
using System.Xml.Serialization;

namespace MiSAT
{
    public static class CFDI
    {
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
    }
}
