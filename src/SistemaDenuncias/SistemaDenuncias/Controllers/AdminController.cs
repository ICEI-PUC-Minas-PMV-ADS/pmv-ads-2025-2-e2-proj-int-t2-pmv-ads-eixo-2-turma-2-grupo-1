using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDenuncias.Models;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace SistemaDenuncias.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Admin/Dashboard
        public async Task<IActionResult> Dashboard()
        {
            var viewModel = new DashboardViewModel
            {
                DenunciasAbertas = await _context.Denuncias.CountAsync(d => d.Status == StatusDenuncia.Aberta),
                DenunciasEmAnalise = await _context.Denuncias.CountAsync(d => d.Status == StatusDenuncia.Analise),
                DenunciasFechadas = await _context.Denuncias.CountAsync(d => d.Status == StatusDenuncia.Fechada),
                UsuariosEmPerigo = await _context.Usuarios.CountAsync(u => u.EmPerigo),
                NomeAdmin = User.Identity.Name ?? "Admin"
            };
            return View(viewModel);
        }

      
        // GET: /Admin/Index
        public async Task<IActionResult> Index()
        {
            var todasDenuncias = await _context.Denuncias
                .Include(d => d.Usuario) 
                .OrderByDescending(d => d.DataCriacao)
                .ToListAsync();

            return View(todasDenuncias);
        }

        // GET: /Admin/GerenciarDenuncia/
        public async Task<IActionResult> GerenciarDenuncia(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denuncia = await _context.Denuncias
                .Include(d => d.Usuario)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (denuncia == null)
            {
                return NotFound();
            }

            return View(denuncia);
        }

        // POST: /Admin/AtualizarStatus
        [HttpPost]
        public async Task<IActionResult> AtualizarStatus(int denunciaId, StatusDenuncia novoStatus)
        {
            var denuncia = await _context.Denuncias.FindAsync(denunciaId);
            if (denuncia == null)
            {
                return Json(new { success = false, message = "Denúncia não encontrada." });
            }

            denuncia.Status = novoStatus;
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Status atualizado com sucesso!" });
        }


        #region Métodos de Autenticação e SOS (Sem Alterações)
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin")) return RedirectToAction("Dashboard");
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string senha)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                ModelState.AddModelError(string.Empty, "Informe o e-mail e a senha.");
                return View();
            }
            var admin = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email && u.IsAdmin);
            if (admin == null || !BCrypt.Net.BCrypt.Verify(senha, admin.Senha))
            {
                ModelState.AddModelError(string.Empty, "E-mail, senha ou permissão inválidos.");
                return View();
            }
            await SignInAdmin(admin);
            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        private async Task SignInAdmin(Usuario admin)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString()),
                new Claim(ClaimTypes.Name, admin.Nome),
                new Claim(ClaimTypes.Email, admin.Email),
                new Claim(ClaimTypes.Role, "Admin")
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties { IsPersistent = true, ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8) };
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
        }

        [HttpGet]
        public async Task<IActionResult> UsuariosEmPerigoCount()
        {
            int count = await _context.Usuarios.CountAsync(u => u.EmPerigo);
            return Json(new { count });
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuariosEmPerigo()
        {
            var usuarios = await _context.Usuarios
                .Where(u => u.EmPerigo && u.Latitude.HasValue && u.Longitude.HasValue)
                .Select(u => new { u.Nome, u.Latitude, u.Longitude })
                .ToListAsync();
            return Json(usuarios);
        }
        #endregion
    }
}