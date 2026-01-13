# Envelope
El modelo **Envelope** representa la estructura principal de un sobre digital. Este modelo se utiliza para generar solicitudes del [WebService de Descarga Masiva del SAT](https://www.sat.gob.mx/portal/public/tramites/factura-electronica) y deserializar las respuestas recibidas.

## Modelo de la Clase
```csharp
    public class Envelope
    {
        public Header Header { get; set; }
        public Body Body { get; set; }
    }
```