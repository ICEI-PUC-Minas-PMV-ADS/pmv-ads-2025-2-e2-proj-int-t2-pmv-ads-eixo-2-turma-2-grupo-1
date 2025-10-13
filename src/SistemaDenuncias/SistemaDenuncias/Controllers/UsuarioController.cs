using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SistemaDenuncias.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace SistemaDenuncias.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly AppDbContext _context;
        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Usuario/Cadastro ('Tarefa implementada por Henrique Alves')
        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }

        // POST: /Usuario/Cadastro ('Tarefa implementada por Henrique Alves')
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastro(Usuario usuario)
        {
            if (!ModelState.IsValid)
                return View(usuario);

            // Verifica se já existe email ou CPF cadastrado
            var exists = await _context.Usuarios
                .AnyAsync(u => u.Email == usuario.Email || u.Cpf == usuario.Cpf);

            if (exists)
            {
                ModelState.AddModelError(string.Empty, "Já existe um usuário com esse e-mail ou CPF.");
                return View(usuario);
            }

            // Criptografa senha
            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            // Faz login automático após cadastro
            await SignInUser(usuario);

            return RedirectToAction("BemVindo", "Usuario");
        }

        // GET: /Usuario/Login ('Tarefa implementada por Henrique Alves')
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Usuario/Login ('Tarefa implementada por Henrique Alves')
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string senha)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                ModelState.AddModelError(string.Empty, "Informe o e-mail e a senha.");
                return View();
            }

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
            if (usuario == null || !BCrypt.Net.BCrypt.Verify(senha, usuario.Senha))
            {
                ModelState.AddModelError(string.Empty, "E-mail ou senha inválidos.");
                return View();
            }

            await SignInUser(usuario);

            return RedirectToAction("BemVindo", "Usuario");
        }

        // POST: /Usuario/Logout ('Tarefa implementada por Henrique Alves')
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        // GET: /Usuario/BemVindo ('Tarefa implementada por Henrique Alves')
        [HttpGet]
        public IActionResult BemVindo()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login");

            ViewBag.NomeUsuario = User.Identity.Name;
            return View();
        }

        // Método auxiliar
        private async Task SignInUser(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Email, usuario.Email)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }
    }
}
