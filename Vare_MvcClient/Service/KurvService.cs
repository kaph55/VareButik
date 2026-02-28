using Vare_Mvc.Models;

namespace Vare_Mvc.Service
{
    public class KurvService : IKurvService
    {
        private readonly Dictionary<string, List<KurvItemViewModel>> _kurvListe = new();

        public List<KurvItemViewModel> GetKurv(string username)
        {
            if (!_kurvListe.ContainsKey(username))
                _kurvListe[username] = new List<KurvItemViewModel>();

            return _kurvListe[username];
        }

        public void AddToKurv(string username, KurvItemViewModel item)
        {
            var kurv = GetKurv(username);
            var existing = kurv.FirstOrDefault(v => v.VareId == item.VareId);
            if (existing != null)
                existing.Antal += item.Antal;
            else
                kurv.Add(item);
        }

        public void RemoveFromKurv(string username, int vareId)
        {
            var kurv = GetKurv(username);
            var existing = kurv.FirstOrDefault(v => v.VareId == vareId);
            if (existing != null)
                kurv.Remove(existing);
        }


        public void ClearKurv(string username)
        {
            var kurv = GetKurv(username);
            kurv.Clear();
        }
    }
}
