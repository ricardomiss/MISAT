using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MiSAT.Models
{

    internal static class WSNamespaces
    {
        internal const string u = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd";
        internal const string s = "http://schemas.xmlsoap.org/soap/envelope/";
        internal const string o = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd";
        internal const string dmt = "http://DescargaMasivaTerceros.gob.mx";
    }

    /// <summary>
    /// Tipo de Documentos a solicitar su descarga.
    /// </summary>
    public static class TiposSolicitud
    {
        /// <summary>
        /// Comprobante Fiscal Digital por Internet.
        /// </summary>
        public const string CFDI = "CFDI";
        /// <summary>
        /// Información básica de identificación de las facturas. 
        /// </summary>
        public const string Metadata = "Metadata";
    }

    /// <summary>
    /// Representa la información de autenticación que incluye los detalles del certificado, el período de validez 
    /// y los datos de la firma digital.
    /// </summary>
    public class Autenticacion
    {
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public X509Certificate2 Certificado { get; set; }
        public string UUID { get; private set; }
        public string DigestValue { get; private set; }
        public string SignatureValue { get; private set; }
        public string CertificateBase64 => Convert.ToBase64String(Certificado.RawData);
        public Autenticacion()
        {   
            UUID = $"uuid-{Guid.NewGuid().ToString()}-1";
        }

        internal void GenerarDigestValue(string node)
        {
            byte[] data = Encoding.Default.GetBytes(node);
            using (var sha1 = SHA1.Create())
            {
                DigestValue = Convert.ToBase64String(sha1.ComputeHash(data));
            }
        }

        internal void GenerarSignatureValue(string node)
        {
            byte[] data = Encoding.UTF8.GetBytes(node);
            using (var rsa = Certificado.GetRSAPrivateKey())
            {
                var signature = rsa!.SignData(data, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
                SignatureValue = Convert.ToBase64String(signature);
            }
        }


    }
}
