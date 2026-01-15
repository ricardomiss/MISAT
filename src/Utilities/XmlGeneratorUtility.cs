using MiSAT.Models;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace MiSAT.Utilities
{
    internal static class XmlGeneratorUtility
    {
        private readonly static XmlSerializer EnvelopeSerializer = new (typeof(Envelope));

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

        internal static T DeserializarEnvelope<T>(XmlDocument xml, Func<Envelope, T> selector)
        {
            using var reader = new XmlNodeReader(xml);
            if (EnvelopeSerializer.Deserialize(reader) is not Envelope envelope)
                throw new InvalidOperationException("No se pudo deserializar el sobre SOAP.");
            return selector(envelope);
        }

        internal static XmlDocument GetXmlElement(this string xmlContent)
        {
            if(string.IsNullOrEmpty(xmlContent))
                throw new ArgumentException("El contenido XML no puede estar vacío.", nameof(xmlContent));

            var doc = new XmlDocument();
            doc.LoadXml(xmlContent);
            if (doc.DocumentElement == null)
                throw new InvalidOperationException("El contenido XML no tiene un elemento raíz");
            
            return doc;
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
 
        internal static string GetNodoFirmado(this Models.SignedInfo signedInfo)
        {
            XmlDocument xml = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(typeof(Models.SignedInfo));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, "http://www.w3.org/2000/09/xmldsig#");
            using (XmlWriter writer = xml.CreateNavigator().AppendChild())
            {
                serializer.Serialize(writer, signedInfo, namespaces);
            }
            var nsmgr = new XmlNamespaceManager(xml.NameTable);
            var attr = xml.CreateAttribute("xmlns", "http://www.w3.org/2000/xmlns/");
            attr.Value = "http://www.w3.org/2000/09/xmldsig#";
            xml.DocumentElement.Attributes.Append(attr);
            string raw = xml.OuterXml;
            string pattern = @"<([\w:\.\-]+)([^>]*)\s*/>";
            string replaced = Regex.Replace(raw, pattern, "<$1$2></$1>");
            return replaced.Replace(" >", ">");

        }

        internal static string GetTimestamp(this Timestamp timestamp)
        {
            XmlDocument xml = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(typeof(Timestamp));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("u", WSNamespaces.u);
            using (XmlWriter writer = xml.CreateNavigator().AppendChild())
            {
                serializer.Serialize(writer, timestamp, namespaces);
            }
            var nsmgr = new XmlNamespaceManager(xml.NameTable);
            nsmgr.AddNamespace("u", WSNamespaces.u);
            var timestampNode = xml.DocumentElement;
            if (timestampNode != null)
            {
                var idAttr = timestampNode.GetAttributeNode("Id");
                if (idAttr != null)
                {
                    timestampNode.RemoveAttributeNode(idAttr);
                    var attr = xml.CreateAttribute("u", "Id", WSNamespaces.u);
                    attr.Value = idAttr.Value;
                    timestampNode.Attributes.Append(attr);
                }
            }
            return xml.OuterXml;
        }
    }
}
