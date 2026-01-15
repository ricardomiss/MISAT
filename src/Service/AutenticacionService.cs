using MiSAT.Models;
using MiSAT.Utilities;
using System.Xml;
using System.Xml.Serialization;

namespace MiSAT.Service
{
    internal class AutenticacionService
    {
        public string GenerarSolicitudAutenticacion(Autenticacion request)
        {
            request.Validar();
            XmlDocument xml = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(typeof(Envelope));

            Timestamp timestamp = CreateTimestamp(request);
            request.GenerarDigestValue(timestamp.GetTimestamp());

            SignedInfo signedInfo = CreateSignedInfo(request);
            request.GenerarSignatureValue(signedInfo.GetNodoFirmado());

            Envelope envelope = CreateEnvelopeAuth(request, timestamp, signedInfo);

            XmlSerializerNamespaces ns = GenerateNamespaces();

            using (XmlWriter writer = xml.CreateNavigator().AppendChild())
            {
                serializer.Serialize(writer, envelope, ns);
            }

            return ForzarAtributos(xml);
        }

        public Envelope DeserializarEnvelope(XmlDocument xmlContent)
        {
            return XmlGeneratorUtility.DeserializarEnvelope<Envelope>(xmlContent, envelope => envelope);
        }

        private static Timestamp CreateTimestamp(Autenticacion request)
        {
            return new Timestamp
            {
                Created = request.FechaInicial.ToXmlStringUtc(),
                Expires = request.FechaFinal.ToXmlStringUtc()
            };
        }

        private static SignedInfo CreateSignedInfo(Autenticacion request)
        {
            return new SignedInfo
            {
                CanonicalizationMethod = new CanonicalizationMethod(),
                SignatureMethod = new SignatureMethod(),
                Reference = new Reference
                {
                    Transforms = new Transforms
                    {
                        Transform = new Transform()
                    },
                    DigestMethod = new DigestMethod(),
                    DigestValue = request.DigestValue
                }
            };
        }

        private static Envelope CreateEnvelopeAuth(Autenticacion request, Timestamp timestamp, SignedInfo signedInfo)
        {
            return new Envelope
            {
                Header = new Header
                {
                    Security = new Security
                    {
                        Timestamp = timestamp,
                        BinarySecurityToken = new BinarySecurityToken
                        {
                            Id = request.UUID,
                            Certificate = request.CertificateBase64
                        },
                        Signature = new Signature
                        {
                            SignedInfo = signedInfo,
                            SignatureValue = request.SignatureValue,
                            KeyInfo = new KeyInfo
                            {
                                SecurityTokenReference = new SecurityTokenReference
                                {
                                    Reference = new KeyReference
                                    {
                                        URI = $"#{request.UUID}"
                                    }
                                }
                            }
                        }
                    }
                },
                Body = new Body
                {
                    Autentica = new Autentica()
                }
            };
        }

        private static XmlSerializerNamespaces GenerateNamespaces()
        {
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("u", WSNamespaces.u);
            namespaces.Add("s", WSNamespaces.s);
            namespaces.Add("o", WSNamespaces.o);
            return namespaces;
        }

        private static string ForzarAtributos(XmlDocument xml)
        {
            var nsmgr = new XmlNamespaceManager(xml.NameTable);
            nsmgr.AddNamespace("s", WSNamespaces.s);
            nsmgr.AddNamespace("u", WSNamespaces.u);
            nsmgr.AddNamespace("o", WSNamespaces.o);
            var root = xml.DocumentElement;
            var securityNode = xml.SelectSingleNode("//s:Header/o:Security", nsmgr);
            var timestampNode = xml.SelectSingleNode("//s:Header/o:Security/u:Timestamp", nsmgr);

            if (root != null)
            {
                root.RemoveAllAttributes();
                var sAttr = xml.CreateAttribute("xmlns", "s", "http://www.w3.org/2000/xmlns/");
                var uAttr = xml.CreateAttribute("xmlns", "u", "http://www.w3.org/2000/xmlns/");
                sAttr.Value = WSNamespaces.s;
                root.Attributes.Append(sAttr);
                uAttr.Value = WSNamespaces.u;
                root.Attributes.Append(uAttr);
            }

            if (securityNode != null)
            {
                var attr = xml.CreateAttribute("xmlns", "o", "http://www.w3.org/2000/xmlns/");
                attr.Value = WSNamespaces.o;
                securityNode.Attributes.Append(attr);
            }

            if (timestampNode != null)
            {
                var idAttr = timestampNode.Attributes["Id"];
                if (idAttr != null)
                {
                    timestampNode.Attributes.Remove(idAttr);
                    var attr = xml.CreateAttribute("u", "Id", WSNamespaces.u);
                    attr.Value = idAttr.Value;
                    timestampNode.Attributes.Append(attr);
                }
            }
            return xml.OuterXml;
        }
    }
}
