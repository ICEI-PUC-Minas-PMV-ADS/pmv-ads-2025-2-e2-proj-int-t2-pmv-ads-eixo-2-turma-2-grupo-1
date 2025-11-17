using Microsoft.AspNetCore.Mvc;

namespace ProtecSysLoginMVC.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Index(string email, string senha)
        {
            // simulated credentials
            if (email?.Trim().ToLower() == "admin@protec.com" && senha == "1234")
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "E-mail ou senha inválidos.";
            ViewBag.Email = email;
            return View();
        }
    }
}
