using Vare_Mvc.Models;

namespace Vare_Mvc.Service
{
    public interface IKøbService
    {
        void AddKøb(KøbViewModel køb);
        List<KøbViewModel> GetKøbByUser(string username);
    }
}
