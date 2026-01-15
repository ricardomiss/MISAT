# Deserializar Descarga
Se utiliza para convertir una cadena XML o un objeto `XmlDocument` que representa una respuesta de descarga en un objeto de tipo `SolicitaDescargaResponse`. Esta función es esencial para interpretar la respuesta del servicio de descargas masivas del SAT.
```csharp
public static SolicitaDescargaResponse DeserializarDescarga(string xmlContent);
public static SolicitaDescargaResponse DeserializarDescarga(XmlDocument xmlContent);
```
## Ejemplo de Uso
```csharp
using MiSAT;
using MiSAT.Models;

class Program
{
    static void Main(string[] args)
    {
        string xmlEmitidoResponse = "<s:Envelope>...</s:Envelope>"; // Ejemplo de respuesta XML
        SolicitaDescargaResponse xmlResponse = DescargaMasiva.DeserializarDescarga(xmlEmitidoResponse);
        Console.WriteLine($"Codigo Respuesta: {xmlResponse.Body.SolicitaDescargaEmitidosResponse.Result.CodEstatus}");
    }
}
```
El resultado es un objeto `SolicitaDescargaResponse` que contiene la información deserializada de la respuesta XML. En el ejemplo se accede al código de estatus de la respuesta. Para más detalles sobre la estructura del objeto consulte la sección de [Modelos](/models/).