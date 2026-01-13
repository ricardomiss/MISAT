# Solicita Descarga Result
Representa el resultado de una solicitud de descarga masiva realizada al servicio del SAT. Contiene información sobre el estado de la solicitud, incluyendo códigos de estatus y mensajes asociados.

## Propiedades
- `CodEstatus`: Código numérico que indica el estado de la solicitud.
- `Mensaje`: Mensaje descriptivo asociado al estado de la solicitud.
- `IdSolicitud`: Identificador único de la solicitud de descarga.
- `RfcSolicitante`: RFC del solicitante que realizó la solicitud de descarga.
## Modelo de Datos
```csharp
public class SolicitaDescargaResult
{
    public int CodEstatus { get; set; }
    public string Mensaje { get; set; }
    public string IdSolicitud { get; set; }
    public string RfcSolicitante { get; set; }
}
```