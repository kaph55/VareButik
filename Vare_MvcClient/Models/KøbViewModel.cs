namespace Vare_Mvc.Models
{
    public class KøbViewModel
    {
        public string Username { get; set; } = string.Empty;
        public List<KurvItemViewModel> Varer { get; set; } = new();
        public decimal TotalPris => Varer.Sum(v => v.Pris * v.Antal);
        public DateTime KøbsDato { get; set; } = DateTime.Now;
    }


    
}
