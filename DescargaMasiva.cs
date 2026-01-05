using MiSAT.Models;
using System.Xml;
using System.Xml.Serialization;
using System.Text.RegularExpressions;

namespace MiSAT
{
    public static class DescargaMasiva
    {
        public static string GenerarSolicitudAutenticacion(Autenticacion request)
        {
            XmlDocument xml = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(typeof(Envelope));

            Timestamp timestamp = new Timestamp
            {
                Created = request.FechaInicial.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                Expires = request.FechaFinal.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")
            };
            request.GenerarDigestValue(GetNodeTimestamp(timestamp));
            
            SignedInfo signedInfo = new SignedInfo
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
            request.GenerarSignatureValue(GetNodeSignedInfo(signedInfo));

            Envelope envelope = new Envelope
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
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("u", WSNamespaces.u);
            namespaces.Add("s", WSNamespaces.s);
            namespaces.Add("o", WSNamespaces.o);

            using (XmlWriter writer = xml.CreateNavigator().AppendChild())
            {
                serializer.Serialize(writer, envelope, namespaces);
            }

            return ForzarAtributos(xml);
        }

        private static string GetNodeTimestamp(Timestamp timestamp)
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

        private static string GetNodeSignedInfo(SignedInfo signedInfo)
        {
            XmlDocument xml = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(typeof(SignedInfo));
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
