# Solicitud Descarga Recibidos
Esta clase representa los datos a solicitar para descargar los CFDI recibidos por un contribuyente específico, utilizado para la API [Generar Solicitud de Descarga](/api/generar-solicitud-descarga).

## Creacion de la Instancia
Para crear una instancia de `SolicitudDescargaRecibidos`, se requiere proporcionar los siguientes parámetros:
- `fechaInicial`: Fecha inicial del rango de descarga.
- `fechaFinal`: Fecha final del rango de descarga.
- `rfcReceptor`: RFC del receptor cuyos CFDI se desean descargar.
- `certificado`: Certificado `X509Certificate2` del contribuyente.
- `estadoComprobante`: Estado del comprobante a descargar. (Default: Vigente).
- `tipoSolicitud`: Los datos a requerir descargar. (Default: CFDI).

```csharp
var solicitud = new SolicitudDescargaRecibidos(
    fechaInicial: new DateTime(2024, 1, 2),
    fechaFinal: new DateTime(2024, 1, 6),
    rfcReceptor: "AAA010101AAA",
    certificado: new X509Certificate2("ruta/al/certificado.pfx", "contraseñaDelCertificado"),
    estadoComprobante: EstadosComprobante.Todos,
    tipoSolicitud: TiposSolicitud.Metadata
);
```

## Modelo de la Clase
Aparte de los parametros del constructor, la clase `SolicitudDescargaRecibidos` tiene propiedades adicionales que pueden ser configuradas según las necesidades de la solicitud. Estas se definen conforme la documentacion oficial del SAT.
```csharp
public class SolicitudDescargaRecibidos
{
    public DateTime FechaInicial { get; set; }
    public DateTime FechaFinal { get; set; }
    public string RfcReceptor { get; set; }
    public string RfcEmisor { get; set; }
    public string TipoSolicitud { get; set; }
    public string? TipoComprobante { get; set; }
    public string EstadoComprobante { get; set; }
    public string RfcCuentaTerceros { get; set; }
    public string? Complemento { get; set; }

   public SolicitudDescargaRecibidos(
        DateTime fechaInicial, DateTime fechaFinal, string rfcReceptor, X509Certificate2 certificado, 
        string estadoComprobante = EstadosComprobante.Vigente, string tipoSolicitud = TiposSolicitud.CFDI)
    {
        FechaInicial = fechaInicial;
        FechaFinal = fechaFinal;
        RfcReceptor = rfcReceptor;
        RfcSolicitante = rfcReceptor;
        Certificado = certificado;
        EstadoComprobante = estadoComprobante;
        TipoSolicitud = tipoSolicitud;
    }
}
```