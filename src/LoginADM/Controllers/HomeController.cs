using Microsoft.AspNetCore.Mvc;

namespace ProtecSysLoginMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
