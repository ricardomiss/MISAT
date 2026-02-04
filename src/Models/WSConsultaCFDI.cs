namespace MiSAT.Models
{
    /// <summary>
    /// Representa la información para realciar una solicitud de consulta de un CFDI.
    /// </summary>
    public class SolicitudConsultaCFDI
    {
        /// <summary>
        /// RFC del emisor del CFDI
        /// </summary>
        public string RFCEmisor { get; set; }
        /// <summary>
        /// RFC del receptor del CFDI
        /// </summary>
        public string RFCReceptor { get; set; }
        /// <summary>
        /// Total del CFDI
        /// </summary>
        public string Total { get; set; }
        /// <summary>
        /// UUID del CFDI
        /// </summary>
        public string UUID { get; set; }
        /// <summary>
        /// Sello Digital del CFDI
        /// </summary>
        public string Sello { get; set; }
        /// <summary>
        /// Recupera los últimos 8 caracteres del sello digital del CFDI.
        /// </summary>
        public string UltimosCaracteresSello => Sello != null && Sello.Length >= 8 ? Sello[^8..] : string.Empty;
    }
}
