# Generar Solicitud Descarga Paquete
La función `GenerarSolicitudDescarga` se utiliza para generar una solicitud XML para ser utilizado en el servicio de Descarga Masiva del SAT. Esta función recibe `SolicitudDescargaPaquetes` y devuelve una cadena XML que representa la solicitud.

```csharp
public static string GenerarSolicitudDescarga(SolicitudDescargaPaquetes solicitud);
```

## Ejemplo de Uso
Este es un ejemplo de cómo utilizar la función `GenerarSolicitudDescarga` para crear una solicitud de descarga de paquete:
```csharp
using MiSAT;
using MiSAT.Models;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        var solicitud = new SolicitudDescargaPaquetes(
            "4e80345d-917f-40bb-a98f4a73939343c5_01", 
            "AAA010101AAA", 
            new X509Certificate2("C:\\ruta\\del\\certificado.pfx", "C0ntr4s3ñ4")
        );

        var xml = DescargaMasiva.GenerarSolicitudDescarga(solicitud);
        Console.WriteLine(xml);
    }
}
```
El resultado es una cadena XML que contiene la solicitud de descarga de paquete en el formato requerido por el servicio de Descarga Masiva del SAT. Esta solicitud puede ser enviada al servicio para obtener los datos correspondientes según los parámetros especificados. Para más detalles sobre sus propiedades y atributos requeridos, consulta la sección de [Descarga Paquete](/models/descarga-paquete).