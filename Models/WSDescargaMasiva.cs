using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MiSAT.Models
{
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
            UUID = $"uuid-{Guid.NewGuid().ToString()}-4";
        }

        internal void GenerarDigestValue(string node)
        {
            byte[] data = Encoding.UTF8.GetBytes(node);
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
