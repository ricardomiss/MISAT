# Solicitud Verificacion
Esta clase representa los datos necesarios para generar una solicitud de verificación en el servicio de Descarga Masiva del SAT utilizando la función [Generar Solicitud Verificación](/api/generar-solicitud-verificacion).

## Creacion de la Instancia
Para crear una instancia de `SolicitudVerificacion`, se deben proporcionar los siguientes parámetros:
- `idSolicitud`: El identificador único de la solicitud de descarga que se desea verificar.
- `rfcSolicitante`: El RFC del contribuyente que realizó la solicitud de descarga.
- `certificado`: El certificado `X509Certificate2` del contribuyente.

```csharp
SolicitudVerificacion solicitud = new SolicitudVerificacion(
    idSolicitud:"n40d966z-m1ss-48m0-a7p3-8dv4l3r14c22", 
    rfcSolicitante:"AAA010101AAA", 
    certificado:new X509Certificate2("ruta/al/certificado.pfx", "contraseñaDelCertificado")
);
```

## Modelo de la Clase
```csharp
public class SolicitudVerificacion
{
    public string IdSolicitud { get; set; }
    public string RfcSolicitante { get; set; }
    public X509Certificate2 Certificado { get; protected set; }

    public SolicitudVerificacion(string idSolicitud, string rfcSolicitante, X509Certificate2 certificado)
    {
        IdSolicitud = idSolicitud;
        RfcSolicitante = rfcSolicitante;
        Certificado = certificado;
    }
}
```