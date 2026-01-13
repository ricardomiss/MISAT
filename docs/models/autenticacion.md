# Autenticacion
Este Modelo representa los datos necesarios para autenticar a un contribuyente en la API del SAT, utilizado para la API [Generar Solicitud de Autenticación](/api/generar-solicitud-autenticacion).
## Creacion de la Instancia
Para crear una instancia de `Autenticacion`, se requiere proporcionar los siguientes parámetros:
- `fechaInicial`: Fecha y hora de inicio de la validez del token de autenticación.
- `fechaFinal`: Fecha y hora de fin de la validez del token de autenticación
- `certificado`: Certificado `X509Certificate2` del contribuyente.
```csharp
var autenticacion = new Autenticacion()
{
    FechaInicial = DateTime.UtcNow,
    FechaFinal = DateTime.UtcNow.AddMinutes(15),
    Certificado = new X509Certificate2("ruta/al/certificado.pfx", "contraseñaDelCertificado"),
};
```

## Modelo de la Clase
```csharp
public class Autenticacion 
{
    public DateTime FechaInicial { get; set; }
    public DateTime FechaFinal { get; set; }
    public X509Certificate2 Certificado { get; set; }
    public string UUID { get; private set; }
    public string DigestValue { get; private set; }
    public string SignatureValue { get; private set; }
    public string CertificateBase64 => Convert.ToBase64String(Certificado.RawData);
}
```