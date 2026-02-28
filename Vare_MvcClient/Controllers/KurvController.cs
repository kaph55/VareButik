using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using Vare_Mvc.Models;
using Vare_Mvc.Service;

namespace Vare_Mvc.Controllers
{
    public class KurvController : Controller
    {
        private readonly IKurvService _kurvService;
        private readonly IKøbService _købService;

        private readonly Kavita _api = new Kavita("https://localhost:7148", new HttpClient());

        public KurvController(IKurvService kurvService, IKøbService købService)
        {
            _kurvService = kurvService;
            _købService = købService;
        }

        // GET: kurv/index
        public IActionResult Index()
        {
            var username = HttpContext.Session.GetString("User");
            if (string.IsNullOrEmpty(username))
                return RedirectToAction("Login", "User");

            var kurv = _kurvService.GetKurv(username);
                return View(kurv);
        } 
      
        // GET: Kurv/Add
        public async Task<IActionResult> Add(int id)
        {
            var username = HttpContext.Session.GetString("User");
            if (string.IsNullOrEmpty(username))
                return RedirectToAction("Login", "User");

            //  Fetch vare data from API

            var vare = await _api.VaresGETAsync(id);
            if (vare == null)
                return RedirectToAction("Index", "Vare");


            // Add to kurv

            var item = new KurvItemViewModel
            {
                VareId = vare.Id,
                VareNavn = vare.Navn ?? "",
                Pris = (decimal)vare.Pris,
                Antal = 1,
                ImageData = vare.ImageData

            };

            _kurvService.AddToKurv(username, item);

            return RedirectToAction("Index", "Vare");
        }

        // GET: kurv/Buy
        public IActionResult Buy()
        {
            var username = HttpContext.Session.GetString("User");
            if (string.IsNullOrEmpty(username))
                return RedirectToAction("Login", "User");

            var varer = _kurvService.GetKurv(username);
            if (!varer.Any())
                return RedirectToAction("Index", "Vare");

            var køb = new KøbViewModel
            {
                Username = username,
                Varer = varer.ToList(),
                KøbsDato = DateTime.Now
            };



            _købService.AddKøb(køb);
            _kurvService.ClearKurv(username);

            return RedirectToAction("History", "Køb");
        }

        // GET: Kurv/Remove
        public IActionResult Remove(int id)
        {
            var username = HttpContext.Session.GetString("User");
            if (string.IsNullOrEmpty(username))
                return RedirectToAction("Login", "User");

           

            _kurvService.RemoveFromKurv(username, id);
            return RedirectToAction("Index");
        }

        
       

       
       
    }
}
