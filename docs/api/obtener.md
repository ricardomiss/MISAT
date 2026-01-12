# Obtener
Es un metodo para deserializar XML que sea CFDI ya sea de un objeto ```XmlDocument``` o un string y devolver un objeto ```Comprobante```.
```csharp
public static Comprobante Obtener(string xmlString);
public static Comprobante Obtener(XmlDocument xmlDocument);
```

## Ejemplo de Uso
```csharp
using MiSAT;
using MiSAT.Models;

class Program
{
    static void Main(string[] args)
    {
        string xmlString = "<cfdi:Comprobante ...>...</cfdi:Comprobante>"; // XML del CFDI como string
        Comprobante comprobanteString = CFDI.Obtener(xmlString);
        Console.WriteLine($"Nombre del Emisor: {comprobanteString.Emisor.Nombre}");

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("ruta/al/cfdi.xml"); // Cargar XML del CFDI desde un archivo
        Comprobante comprobanteXmlDoc = CFDI.Obtener(xmlDoc);
        Console.WriteLine($"Total del Comprobante: {comprobanteXmlDoc.Total}");
    }
}
```
El resultado es un objeto `Comprobante` que representa el CFDI deserializado. Para más detalles sobre el objeto `Comprobante`, consulta la sección de [Modelos](/models/).