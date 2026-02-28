namespace Vare_Mvc.Models
{
    public class KurvItemViewModel
    {
        public int VareId { get; set; }
        public string VareNavn { get; set; } = string.Empty;
        public decimal Pris { get; set; }
        public int Antal { get; set; } = 1;
        public byte[]? ImageData { get; set; }
    }
}
