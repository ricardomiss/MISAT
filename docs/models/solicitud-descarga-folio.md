# Solicitud Descarga Folio
Esta clase representa los datos a solicitar para descargar un CFDI por su Folio específico, utilizado para la API [Generar Solicitud de Descarga](/api/generar-solicitud-descarga/).

## Creacion de la Instancia
Para crear una instancia de `SolicitudDescargaFolio`, se requiere proporcionar los siguientes parámetros:
- `folio`: Es el UUID del CFDI que se desea descargar.
- `certificado`: Certificado `X509Certificate2` del contribuyente que realiza la solicitud.
- `rfcSolicitante`: RFC del contribuyente que realiza la solicitud. (opcional)

```csharp
var solicitud = new SolicitudDescargaFolio(
    folio: "B5R4N1T4-33LD-44KL-0ILY-V4L3D8E7C0E3",
    certificado: new X509Certificate2("ruta/al/certificado.pfx", "contraseñaDelCertificado"),
);
```

## Modelo de la Clase
```csharp
public class SolicitudDescargaFolio
{
    public string Folio { get; set; }
    
    public SolicitudDescargaFolio(string folio, X509Certificate2 certificado, string? rfcSolicitante = null)
    {
        Folio = folio;
        Certificado = certificado;
        if (!string.IsNullOrWhiteSpace(rfcSolicitante))
            RfcSolicitante = rfcSolicitante;
    }
}
```