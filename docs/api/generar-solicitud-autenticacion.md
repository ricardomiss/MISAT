# Generar Solicitud de Autenticación
Es un método para generar la solicitud de autenticación en formato XML requerido por el servicio de Descarga Masiva del SAT. Este metodo recibe como parámetro un objeto de tipo `Autenticacion` y devuelve un string que representa la solicitud de autenticación en formato XML.

```csharp
public static XmlDocument GenerarSolicitudAutenticacion(Autenticacion request);
```

## Ejemplo de Uso
```csharp
using MiSAT;
using MiSAT.Models;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        DateTime fecha = DateTime.UtcNow;
        Autenticacion authRequest = new Autenticacion
        {
            Certificado = new X509Certificate2("C:\\ruta\\del\\certificado.pfx", "C0ntr4s3ñ4"),
            FechaInicial = fecha,
            FechaFinal = fecha.AddMinutes(5),
        };
        string solicitudXml = DescargaMasiva.GenerarSolicitudAutenticacion(authRequest);
        Console.WriteLine(solicitudXml);
    }
}
```
El resultado es un string que contiene la solicitud de autenticación en formato XML, listo para ser enviado al servicio de Descarga Masiva del SAT segun las especificaciones de 
[Web Services Security v1.0 (WS-Security 2004)](https://www.oasis-open.org/standard/wssv1-0/).