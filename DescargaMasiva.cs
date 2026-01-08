using MiSAT.Interfaces;
using MiSAT.Models;
using MiSAT.Strategies;
using MiSAT.Utilities;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace MiSAT
{
    /// <summary>
    /// Provee métodos para las operaciones de descarga masiva del SAT.
    /// </summary>
    public static class DescargaMasiva
    {
        /// <summary>
        /// Genera la solicitud de autenticación en formato XML a partir de un objeto <see cref="Autenticacion"/>.
        /// </summary>
        /// <param name="request">Objeto de autenticación con los datos necesarios</param>
        /// <returns>Un <see cref="string"/> con la solicitud de autenticación en formato XML</returns>
        public static string GenerarSolicitudAutenticacion(Autenticacion request)
        {
            XmlDocument xml = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(typeof(Envelope));

            Timestamp timestamp = new Timestamp
            {
                Created = request.FechaInicial.ToXmlStringUtc(),
                Expires = request.FechaFinal.ToXmlStringUtc()
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

        /// <summary>
        /// Deserializa un documento XML en un objeto Envelope que representa la respuesta de autenticación.
        /// </summary>
        /// <param name="xmlContent">El documento XML que contiene la respuesta de autenticación.</param>
        /// <returns>Un objeto <see cref="Envelope"/> que representa la respuesta de autenticación deserializada.</returns>
        /// <exception cref="InvalidOperationException">Se lanza si el documento XML no tiene un elemento raíz o si no se puede deserializar la respuesta de autenticación.</exception>
        public static Envelope DeserializarAutenticacion(XmlDocument xmlContent)
        {
            var root = xmlContent.DocumentElement ?? throw new InvalidOperationException("El documento XML no tiene un elemento raíz.");
            XmlSerializer serializer = new XmlSerializer(typeof(Envelope));
            using var reader = new XmlNodeReader(xmlContent);
            if (serializer.Deserialize(reader) is not Envelope envelope)
                throw new InvalidOperationException("No se pudo deserializar la respuesta de autenticación.");
            return envelope;
        }

        /// <summary>
        /// Deserializa un documento XML en un objeto Envelope que representa la respuesta de autenticación.
        /// </summary>
        /// <param name="xmlContent">El documento XML que contiene la respuesta de autenticación.</param>
        /// <returns>Un objeto <see cref="Envelope"/> que representa la respuesta de autenticación deserializada.</returns>
        public static Envelope DeserializarAutenticacion(string xmlContent)
        {
            if (string.IsNullOrWhiteSpace(xmlContent))
                return new Envelope();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlContent);
            return DeserializarAutenticacion(xmlDoc);
        }

        /// <summary>
        /// Genera la solicitud de descarga en formato XML a partir de un objeto <see cref="SolicitudDescargaEmitidos"/>.
        /// </summary>
        /// <param name="solicitud">Objeto de solicitud con los datos necesarios</param>
        /// <returns>Un <see cref="string"/> con la solicitud de descarga de emitidos en formato XML</returns>
        public static string GenerarSolicitudDescarga(SolicitudDescargaEmitidos solicitud) 
            => SolicitudDescarga(solicitud);

        /// <summary>
        /// Genera la solicitud de descarga en formato XML a partir de un objeto <see cref="SolicitudDescargaRecibidos"/>.
        /// </summary>
        /// <param name="solicitud">Objeto de solicitud con los datos necesarios</param>
        /// <returns>Un <see cref="string"/> con la solicitud de descarga de recibidos en formato XML</returns>
        public static string GenerarSolicitudDescarga(SolicitudDescargaRecibidos solicitud) 
            => SolicitudDescarga(solicitud);
        
        /// <summary>
        /// Genera la solicitud de descarga en formato XML a partir de un objeto <see cref="SolicitudDescargaFolio"/>.
        /// </summary>
        /// <param name="solicitud">Objeto de solicitud con los datos necesarios</param>
        /// <returns>Un <see cref="string"/> con la solicitud de descarga de folio en formato XML</returns>
        public static string GenerarSolicitudDescarga(SolicitudDescargaFolio solicitud) 
            => SolicitudDescarga(solicitud);

        private static string SolicitudDescarga(SolicitudDescarga solicitud)
        {
            ISolicitudDescargaStrategy strategy = solicitud switch
            {
                SolicitudDescargaEmitidos emitidos => new SolicitudDescargaEmitidosStrategy(solicitud),
                SolicitudDescargaRecibidos recibidos => new SolicitudDescargaRecibidosStrategy(solicitud),
                SolicitudDescargaFolio folio => new SolicitudDescargaFolioStrategy(solicitud),
                _ => throw new NotImplementedException("Tipo de Solicitud no esperada")
            };

            solicitud.Validar();
            solicitud sol = strategy.GenerarSolicitud();
            XmlElement solicitudNode = strategy.GenerarNodoSolicitud(sol);
            XmlElement signature = strategy.GenerarNodoSignature(solicitudNode);
            sol.Signature = signature;
            return strategy.GenerarSolicitudXML(sol).OuterXml;
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
