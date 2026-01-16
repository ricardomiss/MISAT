# Solicitud Descarga Paquetes
Esta clase representa los datos necesarios para solicitar la descarga de paquetes en el servicio de descargas masivas del SAT utilizando el método [Generar Solicitud Descarga Paquete](/api/generar-solicitud-descarga-paquete).

## Creacion de la Instancia
Para crear una instancia de `SolicitudDescargaPaquetes`, se deben proporcionar los siguientes parámetros:
- `idPaquete`: El identificador del paquete que se desea descargar.
- `rfcSolicitante`: El RFC del solicitante de la descarga.
- `certificado`: El certificado `X509Certificate2` del contribuyente.
```csharp
SolicitudDescargaPaquetes solicitud = new SolicitudDescargaPaquetes(
    idPaquete: "4e80345d-917f-40bb-a98f4a73939343c5_01", 
    rfcSolicitante: "AAO010101AAA", 
    certificado: new X509Certificate2("C:\\archivo.pfx", "C0ntr4s3ñ4")
);
```

## Modelo de la Clase
```csharp
public class SolicitudDescargaPaquetes
{
    public string IdPaquete { get; set; }
    public string RfcSolicitante { get; set; }
    public X509Certificate2 Certificado { get; protected set; }

    public SolicitudDescargaPaquetes(string idPaquete, string rfcSolicitante, X509Certificate2 certificado)
    {
        IdPaquete = idPaquete;
        RfcSolicitante = rfcSolicitante;
        Certificado = certificado;
    }
}
```