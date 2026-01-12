# Deserializar Autenticacion
La función `DeserializarAutenticacion` se utiliza para convertir una cadena XML o un objeto `XmlDocument` que representa una respuesta de autenticación en un objeto de tipo `Envelope`. Esta función es esencial para interpretar la respuesta del servicio de autenticación del SAT.
```csharp
public static Envelope DeserializarAutenticacion(string xmlContent);
public static Envelope DeserializarAutenticacion(XmlDocument xmlContent);
```

## Ejemplo de Uso
```csharp
string xmlResponse = "<s:Envelope>...</s:Envelope>"; // Respuesta XML del servicio de autenticación
Envelope autenticacionResponse = DescargaMasiva.DeserializarAutenticacion(xmlResponse);
Console.WriteLine($"Token: {autenticacionResponse.Body.AutenticaResponse.AutenticaResult}");

XmlDocument xmlDocResponse = new XmlDocument();
xmlDocResponse.LoadXml(xmlResponse);
Envelope autenticacionResponseFromDoc = DescargaMasiva.DeserializarAutenticacion(xmlDocResponse);
Console.WriteLine($"Token desde XmlDocument: {autenticacionResponseFromDoc.Body.AutenticaResponse.AutenticaResult}");
```
El resultado es un objeto `Envelope` que contiene la información de la respuesta de autenticación, incluyendo el token necesario para realizar descargas masivas. Para más detalles sobre el objeto `Envelope`, consulta la sección de [Modelos](/models/).