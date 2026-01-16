# Obtener Paquete
Se utiliza para convertir una cadena XML o un objeto `XmlDocument` que representa una respuesta de descarga en un objeto de tipo `PaqueteResponse`. Esta función es esencial para interpretar la respuesta del servicio de descargas masivas del SAT.
```csharp
public static PaqueteResponse ObtenerPaquete(string xmlContent);
public static PaqueteResponse ObtenerPaquete(XmlDocument xmlContent);
```
## Ejemplo de Uso
```csharp
using MiSAT;
using MiSAT.Models;

class Program
{
    static void Main(string[] args)
    {
        string paqueteXML = "<s:Envelope>...</s:Envelope>"; // Ejemplo de respuesta XML
        PaqueteResponse response = DescargaMasiva.ObtenerPaquete(paqueteXML);
        Console.WriteLine($"Codigo Respuesta: {response.CodEstatus}");
        if(response.Paquete.Length > 0))
        {
            // El data del paquete es un archivo zip, esto puede cambiar dependiendo de la documentación oficial
            string path = $"C:\\Descargas\\paquete_{DateTime.Now:yyyyMMddHHmmss}.zip";
            File.WriteAllBytes(path, response.Paquete);
            Console.WriteLine($"Paquete guardado en: {path}");
        }
    }
}
```
El resultado es un objeto `PaqueteResponse` que contiene la información deserializada de la respuesta XML. En el ejemplo se accede al código de estatus de la respuesta. Para más detalles sobre la estructura del objeto consulte la sección de [Modelos](/models/).