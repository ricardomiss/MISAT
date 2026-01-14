using MiSAT.Models;
using System.Xml;

namespace MiSAT.Interfaces
{
    internal interface ISolicitudDescargaStrategy
    {
        solicitud GenerarSolicitud();
        XmlElement GenerarSolicitudXML(solicitud sol);
    }
}
