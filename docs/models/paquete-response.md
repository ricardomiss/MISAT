# Paquete Response
Representa el resultado de una solicitud de descarga de un paquete específico en el servicio de descargas masivas del SAT. Aqui ya obtenemos el paquete solicitado en `byte[]`. El paquete puede ser un archivo ZIP, esto puede cambiar dependiendo del [Web Service](https://www.sat.gob.mx/portal/public/tramites/factura-electronica).

## Propiedades
- `CodEstatus`: Código de estatus de la respuesta.
- `Mensaje`: Mensaje descriptivo asociado al estatus.
- `Paquete`: Contenido del paquete descargado en formato binario.

## Modelo de Datos
```csharp
public class PaqueteResponse
{
    public int CodEstatus { get; set; }
    public string Mensaje { get; set; }
    public byte[] Paquete { get; set; }
}
```