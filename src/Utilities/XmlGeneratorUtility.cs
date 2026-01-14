using MiSAT.Models;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;
using System.Xml.Serialization;

namespace MiSAT.Utilities
{
    internal static class XmlGeneratorUtility
    {
        internal static XmlElement GetNodoSolicitud(this solicitud sol)
        {
            var doc = new XmlDocument();
            doc.PreserveWhitespace = true;

            XmlSerializer serializer = new XmlSerializer(typeof(solicitud));

            var ns = new XmlSerializerNamespaces();
            ns.Add("des", WSNamespaces.dmt);

            using (XmlWriter writer = doc.CreateNavigator()!.AppendChild())
            {
                serializer.Serialize(writer, sol, ns);
            }
            return doc.DocumentElement!;
        }

        internal static XmlElement GetEnvelope(this Envelope envelope)
        {
            var doc = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(typeof(Envelope));

            var ns = new XmlSerializerNamespaces();
            ns.Add("soapenv", WSNamespaces.s);
            ns.Add("des", WSNamespaces.dmt2);
            ns.Add("xd", SignedXml.XmlDsigNamespaceUrl);

            using (XmlWriter writer = doc.CreateNavigator()!.AppendChild())
            {
                serializer.Serialize(writer, envelope, ns);
            }
            return doc.DocumentElement!;
        }

        internal static XmlElement GetNodoFirmado(XmlElement solicitudNode, X509Certificate2 certificado)
        {
            var doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.LoadXml(solicitudNode.OuterXml);

            SignedXml signedXml = new SignedXml(doc);
            signedXml.SigningKey = certificado.GetRSAPrivateKey();

            var reference = new System.Security.Cryptography.Xml.Reference();
            reference.Uri = "";
            reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
            reference.DigestMethod = SignedXml.XmlDsigSHA1Url;
            signedXml.SignedInfo!.SignatureMethod = SignedXml.XmlDsigRSASHA1Url;
            signedXml.SignedInfo.CanonicalizationMethod = SignedXml.XmlDsigC14NTransformUrl;
            signedXml.AddReference(reference);

            var keyInfo = new System.Security.Cryptography.Xml.KeyInfo();
            var x509Data = new KeyInfoX509Data(certificado);
            x509Data.AddIssuerSerial(certificado.Issuer, certificado.SerialNumber);
            keyInfo.AddClause(x509Data);
            signedXml.KeyInfo = keyInfo;

            signedXml.ComputeSignature();
            return signedXml.GetXml();
        }
    }
}
