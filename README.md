# MISAT
 [Documentacion 📄](https://ricardomiss.github.io/MISAT/) | [Nuget 🧰](https://www.nuget.org/packages/MiSAT)
 
## Librería para uso de los servicios del SAT
MISAT es una librería en C# diseñada para facilitar la interacción con los servicios del Servicio de Administración Tributaria (SAT) de México. 
Esta librería proporciona funciones y métodos para realizar diversas operaciones relacionadas con la gestión fiscal.

### Instalación 📦
```bash
NuGet\Install-Package MiSAT
dotnet add package MiSAT
```
### Ejemplo Básico 🔧
En este ejemplo, se creara una solicitud de autenticación proporcionando la fecha inicial y final para la validez del token, así como el certificado `X509Certificate2` del contribuyente.
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

### Documentacion
Para más detalles sobre MiSAT, consulta la [Documentación](https://ricardomiss.github.io/MISAT/).

