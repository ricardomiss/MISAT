# Consulta Result
Representa el resultado de una solicitud respuesta en el servicio de Consulta de CFDI del SAT. Aqui ya obtenemos el resultado de nuesta solicitud en un objeto en `ConsultaResult`.

## Propiedades
- `CodigoEstatus`: Código de estatus de la respuesta.
- `EsCancelable`: Informacion de la cancelabilidad del CFDI.
- `Estado`: Estado actual del CFDI consultado.
- `EstatusCancelacion`: Estatus de cancelación del CFDI, si aplica.
- `ValidacionEFOS`: Indica si el emisor del CFDI está en la lista de EFOS (Emisores de Facturas o Comprobantes Fiscales que Operan Sin Estar Autorizados).

## Modelo de Datos
```csharp
public class ConsultaResult
{
    public string CodigoEstatus { get; set; }
    public string EsCancelable { get; set; }
    public string Estado { get; set; }
    public string? EstatusCancelacion { get; set; }
    public string ValidacionEFOS { get; set; }
}
```