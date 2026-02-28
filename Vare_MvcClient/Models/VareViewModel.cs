namespace Vare_Mvc.Models
{
    public class VareViewModel
    {
        public int Id { get; set; }
        public string? Navn { get; set; }
        public double Pris { get; set; }
        public int Antal { get; set; }
        public byte[]? ImageData { get; set; } = null;
    }
}
