using Vare_Mvc.Models;

namespace Vare_Mvc.Service
{
    public class KøbService : IKøbService
    {
        private readonly List<KøbViewModel> _købListe = new();

        public void AddKøb(KøbViewModel køb)
        {
            _købListe.Add(køb);
        }

        public List<KøbViewModel> GetKøbByUser(string username)
        {
            return _købListe.Where(k => k.Username == username).ToList();
        }
    }
}
