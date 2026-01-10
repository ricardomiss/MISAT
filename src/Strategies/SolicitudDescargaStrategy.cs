using MiSAT.Interfaces;
using MiSAT.Models;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;
using System.Xml.Serialization;

namespace MiSAT.Strategies
{
    internal abstract class SolicitudDescargaStrategy : ISolicitudDescargaStrategy
    {
        protected SolicitudDescarga _solicitud;

        protected SolicitudDescargaStrategy(SolicitudDescarga solicitud)
        {
            _solicitud = solicitud;
        }

        public XmlElement GenerarNodoSignature(XmlElement solicitudNode)
        {
            var doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.LoadXml(solicitudNode.OuterXml);

            SignedXml signedXml = new SignedXml(doc);
            signedXml.SigningKey = _solicitud.Certificado.GetRSAPrivateKey();

            var reference = new System.Security.Cryptography.Xml.Reference();
            reference.Uri = "";
            reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
            reference.DigestMethod = SignedXml.XmlDsigSHA1Url;
            signedXml.SignedInfo!.SignatureMethod = SignedXml.XmlDsigRSASHA1Url;
            signedXml.SignedInfo.CanonicalizationMethod = SignedXml.XmlDsigC14NTransformUrl;
            signedXml.AddReference(reference);

            var keyInfo = new System.Security.Cryptography.Xml.KeyInfo();
            var x509Data = new KeyInfoX509Data(_solicitud.Certificado);
            x509Data.AddIssuerSerial(_solicitud.Certificado.Issuer, _solicitud.Certificado.SerialNumber);
            keyInfo.AddClause(x509Data);
            signedXml.KeyInfo = keyInfo;

            signedXml.ComputeSignature();
            return signedXml.GetXml();
        }

        public XmlElement GenerarNodoSolicitud(solicitud sol)
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

        protected XmlElement GenerarXML(Envelope envelope)
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

        public abstract solicitud GenerarSolicitud();
        public abstract XmlElement GenerarSolicitudXML(solicitud sol);
    }
}
