# Generar Solicitud Descarga
La función `GenerarSolicitudDescarga` se utiliza para generar una solicitud XML para ser utilizado en el servicio de Descarga Masiva del SAT. Esta función acepta diferentes tipos de solicitudes, como `SolicitudDescargaEmitidos`, `SolicitudDescargaRecibidos` y `SolicitudDescargaFolio`, y devuelve una cadena XML que representa la solicitud solicitada.

```csharp
public static string GenerarSolicitudDescarga(SolicitudDescargaEmitidos solicitud);
public static string GenerarSolicitudDescarga(SolicitudDescargaRecibidos solicitud);
public static string GenerarSolicitudDescarga(SolicitudDescargaFolio solicitud);
```

## Ejemplo de Uso
Este es un ejemplo de cómo utilizar la función `GenerarSolicitudDescarga` para crear una solicitud de descarga de CFDIs emitidos:
```csharp
using MiSAT;
using MiSAT.Models;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        DateTime fechaInicial = new DateTime(2024, 10, 3);
        DateTime fechaFinal = new DateTime(2024, 10, 7);
        string rfcEmisor = "AAA010101AAA";
        X509Certificate2 certificado = new X509Certificate2("C:\\ruta\\del\\certificado.pfx", "C0ntr4s3ñ4");
        string estadoComprobante = EstadosComprobante.Vigente;
        string tipoSolicitud = TiposSolicitud.CFDI;
        

        SolicitudDescarga solicitud = new SolicitudDescargaEmitidos(
            fechaInicial, fechaFinal, rfcEmisor, certificado, 
            estadoComprobante, tipoSolicitud) 
            {
                TipoComprobante = TiposComprobante.Ingreso,
            };

        string solicitudXml = DescargaMasiva.GenerarSolicitudDescarga(solicitud);
        Console.WriteLine(solicitudXml);
    }
}
```
El resultado es una cadena XML que contiene la solicitud de descarga en el formato requerido por el servicio de Descarga Masiva del SAT. Esta solicitud puede ser enviada al servicio para obtener los datos correspondientes según los parámetros especificados. Para más detalles sobre los tipos de solicitudes, sus propiedades y atributos requeridos, consulta la sección de [Solicitud Descarga](/models/solicitud-descarga).