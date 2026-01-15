# Verifica Solicitud Descarga Result
Representa el resultado de una solicitud de descarga masiva realizada al servicio del SAT. Contiene información sobre el estado de la solicitud, incluyendo códigos de estatus, mensajes asociados y los identificadores de los paquetes generados.

## Propiedades
- `IdsPaquetes`: Lista de identificadores de los paquetes generados para la descarga.
- `CodEstatus`: Código de estatus de la petición de verificación.
- `Mensaje`: Mensaje descriptivo asociado al estado de la solicitud.
- `EstadoSolicitud`: Contiene el número correspondiente al estado de la solicitud de descarga.
- `CodigoEstadoSolicitud`: Contiene el código de estado de la solicitud de descarga
- `NumeroCFDIs`: Número total de CFDIs asociados a la solicitud.

## Modelo de Datos
```csharp
public class VerificaSolicitudResult
{
    public List<string> IdsPaquetes { get; set; }
    public int CodEstatus { get; set; }
    public string Mensaje { get; set; }
    public int EstadoSolicitud { get; set; }
    public int CodigoEstadoSolicitud { get; set; }
    public int NumeroCFDIs { get; set; }
}
```