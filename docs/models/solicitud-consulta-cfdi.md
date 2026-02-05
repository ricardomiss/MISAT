# Solicitud Consulta CFDI
Esta clase representa los datos necesarios para generar una solicitud de consulta en el servicio de Consulta de CFDI del SAT utilizando la función [Generar Solicitud Consulta](/api/generar-solicitud-consulta).

## Creacion de la Instancia
Para crear una instancia de `SolicitudConsultaCFDI`, se deben proporcionar los siguientes parámetros:
- `RFCEmisor`: El RFC del contribuyente quien emitió el CFDI.
- `RFCReceptor`: El RFC del contribuyente a quien se emitió el CFDI.
- `Total`: El total del importe del CFDI.
- `UUID`: El UUID del CFDI.
- `Sello`: El sello digital del CFDI.

```csharp
SolicitudConsultaCFDI solicitud = new SolicitudConsultaCFDI
{
    RFCEmisor = "XXX010101XXX",
    RFCReceptor = "BBB010101BBB",
    Total = "543.21",
    UUID = "1234-5678-1234-5678",
    Sello = "sxLKdHU80wufy...4YlZuaCFRO2J4E"
};
```

## Modelo de la Clase
```csharp
public class SolicitudConsultaCFDI
{
    public string RFCEmisor { get; set; }
    public string RFCReceptor { get; set; }
    public string Total { get; set; }
    public string UUID { get; set; }
    public string Sello { get; set; }
    
    // Propiedad calculada para obtener los últimos 8 caracteres del sello digital
    public string UltimosCaracteresSello 
        => Sello != null && Sello.Length >= 8 ? Sello[^8..] : string.Empty;
}
```