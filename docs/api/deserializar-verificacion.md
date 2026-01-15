# Deserializar Descarga
Se utiliza para convertir una cadena XML o un objeto `XmlDocument` que representa una respuesta de descarga en un objeto de tipo `VerificaSolicitudDescargaResponse`. Esta función es esencial para interpretar la respuesta del servicio de descargas masivas del SAT.
```csharp
public static VerificaSolicitudDescargaResponse DeserializarVerificacion(string xmlContent);
public static VerificaSolicitudDescargaResponse DeserializarVerificacion(XmlDocument xmlContent);
```
## Ejemplo de Uso
```csharp
using MiSAT;
using MiSAT.Models;

class Program
{
    static void Main(string[] args)
    {
        string xmlVerificacionResponse = "<s:Envelope>...</s:Envelope>"; // Ejemplo de respuesta XML
        VerificaSolicitudDescargaResponse xmlResponse = DescargaMasiva.DeserializarVerificacion(xmlVerificacionResponse);
        Console.WriteLine($"Codigo Respuesta: {xmlResponse.Body.SolicitaDescargaEmitidosResponse.Result.CodEstatus}");
    }
}
```
El resultado es un objeto `VerificaSolicitudDescargaResponse` que contiene la información deserializada de la respuesta XML. En el ejemplo se accede al código de estatus de la respuesta. Para más detalles sobre la estructura del objeto consulte la sección de [Modelos](/models/).