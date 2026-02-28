using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using Vare_Mvc.Models;
using Vare_Mvc.Service;

namespace Vare_Mvc.Controllers
{
    public class KøbController : Controller
    {
        private readonly IKøbService _købService;

        public KøbController(IKøbService købService)
        {
            _købService = købService;
        }
        public IActionResult History()
        {
            var username = HttpContext.Session.GetString("User");
            if (string.IsNullOrEmpty(username))
                return RedirectToAction("Login", "User");

            var købListe = _købService.GetKøbByUser(username);
            return View(købListe);
        }

       
        
    }
}
