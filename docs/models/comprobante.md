# Comprobante
El modelo **Comprobante** representa el documento fiscal del SAT, se usa para deserializar los datos de un comprobante fiscal digital por internet (CFDI). El modelo incluye atributos y elementos que vienen en el XML del CFDI.

Para mas informacion de los atributos y elementos puedes consultarlo en el [anexo 20](http://omawww.sat.gob.mx/tramitesyservicios/Paginas/anexo_20.htm) (CFDI v4.0).

## Modelo de la Clase
```csharp
public class Comprobante
{
    // Elementos hijos
    public InformacionGlobal InformacionGlobal { get; set; }
    public CfdiRelacionados CfdiRelacionados { get; set; }
    public Emisor Emisor { get; set; }
    public Receptor Receptor { get; set; }
    public Conceptos Conceptos { get; set; }
    public Impuestos Impuestos { get; set; }
    public Complemento Complemento { get; set; }
    public Complemento Complemento { get; set; }

    // Atributos
    public string Version { get; set; }
    public string Serie { get; set; }
    public string Folio { get; set; }
    public string Fecha { get; set; }
    public string Sello { get; set; }
    public string FormaPago { get; set; }
    public string NoCertificado { get; set; }
    public string Certificado { get; set; }
    public string CondicionesDePago { get; set; }
    public string SubTotal { get; set; }
    public string Descuento { get; set; }
    public string Moneda { get; set; }
    public string TipoCambio { get; set; }
    public string Total { get; set; }
    public string TipoDeComprobante { get; set; }
    public string Exportacion { get; set; }
    public string MetodoPago { get; set; }
    public string LugarExpedicion { get; set; }
    public string Confirmacion { get; set; }
}
```