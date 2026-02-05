# Generar Solicitud de Consulta
Es un método para generar la solicitud de consulta en formato XML requerido por el servicio de consulta de CFDI del SAT. Este metodo recibe como parámetro un objeto de tipo `SolicitudConsultaCFDI` o `Comprobante` y devuelve un string que representa la solicitud de autenticación en formato XML.

```csharp
public static string GenerarSolicitudConsulta(SolicitudConsultaCFDI solicitud);
public static string GenerarSolicitudConsulta(Comprobante comprobante);
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
        SolicitudConsultaCFDI solicitud = new SolicitudConsultaCFDI
        {
            RFCEmisor = "AAA010101AAA",
            RFCReceptor = "XXX010101XXX",
            Total = "123.45",
            UUID = "1234-5678-1234-5678",
            Sello = "zbJYhO0wufy...4YlZuaCFRO2J4E"
        };
        string solicitudXml = CFDI.GenerarSolicitudConsulta(solicitud);
        Console.WriteLine(solicitudXml);
    }
}
```
El resultado es un string que contiene la solicitud de autenticación en formato XML, listo para ser enviado al servicio de consulta de CFDI del SAT. Para más detalles sobre los los parámetros y el formato del XML, consulta la sección de [SolicitudConsultaCFDI](/models/consulta-cfdi).
