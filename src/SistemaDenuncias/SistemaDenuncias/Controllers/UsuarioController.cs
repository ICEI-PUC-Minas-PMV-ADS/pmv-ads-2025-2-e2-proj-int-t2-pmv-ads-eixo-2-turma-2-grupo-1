using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SistemaDenuncias.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System; 


namespace SistemaDenuncias.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly AppDbContext _context;

    
        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }

        // POST: /Usuario/Cadastro - Processa o envio do formulário de cadastro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastro(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return View(usuario);
            }

            // Verifica se já existe um usuário com o mesmo e-mail ou CPF
            var exists = await _context.Usuarios
                .AnyAsync(u => u.Email == usuario.Email || u.Cpf == usuario.Cpf);

            if (exists)
            {
 
                ModelState.AddModelError(string.Empty, "Já existe um usuário com este e-mail ou CPF.");
                return View(usuario);
            }

            // Criptografa a senha do usuário antes de salvar no banco de dados
            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync(); 

      
            await SignInUser(usuario);


            TempData["Sucesso"] = $"Bem-vindo(a), {usuario.Nome}! Seu cadastro foi realizado com sucesso.";
            return RedirectToAction("Index", "Denuncia");
        }

        // GET: /Usuario/Login - Exibe o formulário de login
        [HttpGet]
        public IActionResult Login()
        {
         
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Denuncia");
            }
            return View();
        }

        // POST: /Usuario/Login - Processa o envio do formulário de login
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

           
            TempData["Sucesso"] = $"Login realizado com sucesso, {usuario.Nome}!";
            return RedirectToAction("Index", "Denuncia");
        }

        // POST: /Usuario/Logout - Realiza o logot do usuário
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            TempData["Info"] = "Você foi desconectado(a).";
            return RedirectToAction("Login");
        }

        // GET: /Usuario/BemVindo - Redireciona usuários autenticados para a lista de denúncias
    
        [HttpGet]
        public IActionResult BemVindo()
        {
            // Se o usuário não estiver autenticado, redireciona para a página de Login
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login");
            }

           
            return RedirectToAction("Index", "Denuncia");
        }

        // GET: /Usuario/AcessoNegado: Página exibida quando o acesso é negado
        [HttpGet]
        public IActionResult AcessoNegado()
        {
            return View();
        }

      
        private async Task SignInUser(Usuario usuario)
        {
         
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()), 
                new Claim(ClaimTypes.Name, usuario.Nome),                   
                new Claim(ClaimTypes.Email, usuario.Email)                  
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

           
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true, 
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8) 
                                                               
            };

          
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }
    }
}