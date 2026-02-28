using Microsoft.AspNetCore.Mvc;
using Vare_Mvc.Models;

namespace Vare_Mvc.Controllers
{
    public class UserController : Controller
    {
        private const string SessionUserKey = "User";

        private readonly List<UserViewModel> _users = new()
        {
            new UserViewModel{ Username="peter", Password="1234"},
            new UserViewModel{ Username="maria", Password="1234"},
            new UserViewModel{ Username="admin", Password="admin"}
        };

        

        // GET: UserController1
        [HttpGet]
        public IActionResult Login()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionUserKey)))
            {
                return RedirectToAction("Index", "user");
            }
            return View();
        }


        // POST: UserController/Create
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user == null)
            {
                ViewBag.Error = "Forkert brugernavn eller kodeord";
                return View();
            }

            HttpContext.Session.SetString(SessionUserKey, username);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove(SessionUserKey);
            return RedirectToAction("Login");
        }


    }
}
