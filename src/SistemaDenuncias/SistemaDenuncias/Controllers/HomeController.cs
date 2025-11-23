using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SistemaDenuncias.Models;
using Microsoft.AspNetCore.Authorization; 

namespace SistemaDenuncias.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
        [AllowAnonymous] 
        public IActionResult Index()
        {
            // 1. Verifica se o usuário já está autenticado
            if (User.Identity.IsAuthenticated)
            {
                // 2. Se for um Administrador, redireciona para a Dashboard de Admin
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("Dashboard", "Admin");
                }

                // 3. Se for um usário comum, redireciona para o painel de denúncias
                return RedirectToAction("Index", "Denuncia");
            }

            // 4. Se não estiver autenticado, redireciona para a página de login de usuário
            return RedirectToAction("Login", "Usuario");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}