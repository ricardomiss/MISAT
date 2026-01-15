# Generar Solicitud Verificación
La función `GenerarSolicitudVerificacion` se utiliza para generar una solicitud XML para ser utilizado en el servicio de Descarga Masiva del SAT. Esta función recibe `SolicitudVerificacion` y devuelve una cadena XML que representa la solicitud.

```csharp
public static string GenerarSolicitudVerificacion(SolicitudVerificacion solicitud);
```

## Ejemplo de Uso
Este es un ejemplo de cómo utilizar la función `GenerarSolicitudVerificacion` para crear una solicitud de verificación de la solicitud de descarga emitida:
```csharp
using MiSAT;
using MiSAT.Models;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        SolicitudVerificacion solicitud = new SolicitudVerificacion
        (
            "d40d966e-40f7-48e0-a7f3-8075049c6011", 
            "GOHB910807H37", 
            new X509Certificate2("C:\\ruta\\del\\certificado.pfx", "C0ntr4s3ñ4")
        );
        string xml = DescargaMasiva.GenerarSolicitudVerificacion(solicitud);
        Console.WriteLine(xml);
    }
}
```
El resultado es una cadena XML que contiene la solicitud de verificacion en el formato requerido por el servicio de Descarga Masiva del SAT. Esta solicitud puede ser enviada al servicio para obtener los datos correspondientes según los parámetros especificados. Para más detalles sobre sus propiedades y atributos requeridos, consulta la sección de [Verificacion](/models/verificacion).