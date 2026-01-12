# Solicitud Descarga Emitidos
Esta clase representa los datos a solicitar para descargar los CFDI emitidos por un contribuyente específico, utilizado para la API [Generar Solicitud de Descarga](/api/generar-solicitud-descarga/).

## Creacion de la Instancia
Para crear una instancia de `SolicitudDescargaEmitidos`, se requiere proporcionar los siguientes parámetros:
- `fechaInicial`: Fecha inicial del rango de descarga.
- `fechaFinal`: Fecha final del rango de descarga.
- `rfcEmisor`: RFC del emisor cuyos CFDI se desean descargar.
- `certificado`: Certificado `X509Certificate2` del contribuyente.
- `estadoComprobante`: Estado del comprobante a descargar. (Default: Vigente).
- `tipoSolicitud`: Los datos a requerir descargar. (Default: CFDI).

```csharp
var solicitud = new SolicitudDescargaEmitidos(
    fechaInicial: new DateTime(2023, 10, 3),
    fechaFinal: new DateTime(2023, 10, 7),
    rfcEmisor: "AAA010101AAA",
    certificado: new X509Certificate2("ruta/al/certificado.pfx", "contraseñaDelCertificado"),
    estadoComprobante: EstadosComprobante.Todos,
    tipoSolicitud: TiposSolicitud.Metadata
);
```

## Modelo de la Clase
Aparte de los parametros del constructor, la clase `SolicitudDescargaEmitidos` tiene propiedades adicionales que pueden ser configuradas según las necesidades de la solicitud. Estas se definen conforme la documentacion oficial del SAT.
```csharp
public class SolicitudDescargaEmitidos
{
    public DateTime FechaInicial { get; set; }
    public DateTime FechaFinal { get; set; }
    public string[]? RfcReceptor { get; set; }
    public string RfcEmisor { get; set; }
    public string TipoSolicitud { get; set; }
    public string? TipoComprobante { get; set; }
    public string EstadoComprobante { get; set; }
    public string RfcCuentaTerceros { get; set; }
    public string? Complemento { get; set; }
   public SolicitudDescargaEmitidos(DateTime fechaInicial, DateTime fechaFinal, string rfcEmisor, X509Certificate2 certificado,
        string estadoComprobante = EstadosComprobante.Vigente, string tipoSolicitud = TiposSolicitud.CFDI)
    {
        FechaInicial = fechaInicial;
        FechaFinal = fechaFinal;
        RfcEmisor = rfcEmisor;
        RfcSolicitante = rfcEmisor;
        Certificado = certificado;
        EstadoComprobante = estadoComprobante;
        TipoSolicitud = tipoSolicitud;
    }
}
```