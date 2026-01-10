using MiSAT.Models;
using System.Xml;

namespace MiSAT.Interfaces
{
    internal interface ISolicitudDescargaStrategy
    {
        XmlElement GenerarNodoSignature(XmlElement solicitudNode);
        XmlElement GenerarNodoSolicitud(solicitud sol);
        solicitud GenerarSolicitud();
        XmlElement GenerarSolicitudXML(solicitud sol);
    }
}
