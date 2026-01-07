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
    /// Tipo de Comprobante a solicitar su descarga.
    /// </summary>
    public static class TiposComprobante
    {
        /// <summary>
        /// Ingreso
        /// </summary>
        public const string Ingreso = "I";
        /// <summary>
        /// Egreso
        /// </summary>
        public const string Egreso = "E";
        /// <summary>
        /// Traslado
        /// </summary>
        public const string Traslado = "T";
        /// <summary>
        /// Nómina
        /// </summary>
        public const string Nomina = "N";
        /// <summary>
        /// Pago
        /// </summary>
        public const string Pago = "P";
    }

    /// <summary>
    /// Los estados de los Comprobantes a solicitar su descarga.
    /// </summary>
    public static class EstadosComprobante
    {
        /// <summary>
        /// Comprobantes Vigentes
        /// </summary>
        public const string Vigente = "Vigente";
        /// <summary>
        /// Comprobantes Cancelados
        /// </summary>
        public const string Cancelado = "Cancelado";
        /// <summary>
        /// Todos los Comprobantes
        /// </summary>
        public const string Todos = "Todos";
    }

    /// <summary>
    /// Los complementos asociados a los Comprobantes.
    /// </summary>
    public static class Complementos
    {
        public const string AcreditamientoIEPS = "acreditamientoieps10";
        public const string Aerolineas = "aerolineas";
        public const string CertificadoDeDestruccion = "certificadodedestruccion";
        public const string RegistroFiscal = "cfdiregistrofiscal";
        public const string ComercioExterior = "comercioexterior10";
        public const string ComercioExterior11 = "comercioexterior11";
        public const string Comprobante = "comprobante";
        public const string ConsumoDeCombustibles = "consumodecombustibles";
        public const string ConsumoDeCombustibles11 = "consumodecombustibles11";
        public const string Detallista = "detallista";
        public const string Divisas = "divisas";
        public const string Donat11 = "donat11";
        public const string Ecc11 = "ecc11";
        public const string Ecc12 = "ecc12";
        public const string GastosHidrocarburos10 = "gastoshidrocarburos10";
        public const string Iedu = "iedu";
        public const string Implocal = "implocal";
        public const string INE = "ine11";
        public const string IngresosHidrocarburos = "ingresoshidrocarburos";
        public const string LeyendasFisc = "leyendasfisc";
        public const string Nomina11 = "nomina11";
        public const string Nomina12 = "nomina12";
        public const string NotariosPublicos = "notariospublicos";
        public const string ObrasArteAntiguedades = "obrasarteantiguedades";
        public const string PagoEnEspecie = "pagoenespecie";
        public const string Pagos = "Pagos10";
        public const string Pfic = "pfic";
        public const string RenovacionYSustitucionVehiculos = "renovacionysustitucionvehiculos";
        public const string ServicioParcialConstruccion = "servicioparcialconstruccion";
        public const string SPEI = "spei";
        public const string Terceros11 = "terceros11";
        public const string TuristaPasajeroExtranjero = "turistapasajeroextranjero";
        public const string ValesDeDespensa = "valesdedespensa";
        public const string VehiculoUsado = "vehiculousado";
        public const string VentaVehiculos11 = "ventavehiculos11";
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

    /// <summary>
    /// Representa una solicitud base para la solicitud de descarga de documentos, proporcionando información de certificado y
    /// solicitante requerida para la validación.
    /// </summary>
    public abstract class SolicitudDescarga
    {
        public string RfcSolicitante { get; set; }
        public X509Certificate2 Certificado { get; set; }
        public string DatosCertificado  { get; private set; }
        public string NumeroCertificado  { get; private set; }
        public string DigestValue { get; private set; }
        public string SignatureValue  { get; private set; }

        internal abstract bool Validar();
    }
}
