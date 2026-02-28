using Vare_Mvc.Models;

namespace Vare_Mvc.Service
{
    public interface IKurvService
    {
        List<KurvItemViewModel> GetKurv(string username);
        void AddToKurv(string username, KurvItemViewModel item);
        
        void RemoveFromKurv(string username, int vareId);
        void ClearKurv(string username);
    }
}
