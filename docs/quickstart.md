# Inicio Rápido
Para comenzar a utilizar MiSAT, primero debes descargar e instalar la librería. Puedes hacerlo a través de NuGet Package Manager en Visual Studio o utilizando la consola de NuGet.
## Instalación
```bash
NuGet\Install-Package MiSAT
dotnet add package MiSAT
```

## Ejemplo Básico
Aquí tienes un ejemplo básico de cómo utilizar MiSAT para crear una solicitud de autenticación para el servicio de Descarga Masiva del SAT:
```csharp
using MiSAT;
using MiSAT.Models;

class Program
{
    static void Main(string[] args)
    {
        DateTime fecha = DateTime.UtcNow;
        Autenticacion auth = new Autenticacion
        {
            Certificado = new X509Certificate2("C:\\archivo.pfx", "contraseña"),
            FechaInicial = fecha,
            FechaFinal = fecha.AddMinutes(5),
        };

        string xml = DescargaMasiva.GenerarSolicitudAutenticacion(auth);
        Console.WriteLine($"Solicitud de Autenticación XML:\n{xml}");
    }
}
```
En este ejemplo, se crea una solicitud de autenticación proporcionando la fecha inicial y final para la validez del token, así como el certificado `X509Certificate2` del contribuyente. La solicitud se genera en formato XML y se imprime en la consola.
## Documentación Adicional
Para más detalles sobre las funcionalidades de MiSAT, consulta la [Documentación API](/api/).