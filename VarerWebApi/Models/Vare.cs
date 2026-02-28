namespace VarerWebApi.Models
{
    public class Vare
    {
        public int Id { get; set; }
        public string? Navn { get; set; }                  
        public decimal Pris { get; set; }       
        public int Antal { get; set; }
        public byte[]? ImageData { get; set; } = null;
        


    }
}
