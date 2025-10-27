using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SistemaDenuncias.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System; // Adicionado para DateTimeOffset e List<Claim>

// Certifique-se que o namespace do seu AppDbContext está aqui.
// Ex: using SistemaDenuncias.Data;
// Se o AppDbContext estiver no namespace SistemaDenuncias.Models, essa linha não é necessária.

namespace SistemaDenuncias.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly AppDbContext _context;

        // Construtor: Injeção de dependência do contexto do banco de dados
        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Usuario/Cadastro - Exibe o formulário de cadastro de novo usuário
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
            // Se o modelo não for válido (erros de validação de dados)
            if (!ModelState.IsValid)
            {
                return View(usuario);
            }

            // Verifica se já existe um usuário com o mesmo e-mail ou CPF
            var exists = await _context.Usuarios
                .AnyAsync(u => u.Email == usuario.Email || u.Cpf == usuario.Cpf);

            if (exists)
            {
                // Adiciona um erro ao ModelState se o e-mail ou CPF já existirem
                ModelState.AddModelError(string.Empty, "Já existe um usuário com este e-mail ou CPF.");
                return View(usuario);
            }

            // Criptografa a senha do usuário antes de salvar no banco de dados
            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync(); // Salva o novo usuário no banco de dados

            // Realiza o login automático do usuário recém-cadastrado
            await SignInUser(usuario);

            // Redireciona o usuário para a página de listagem de denúncias
            TempData["Sucesso"] = $"Bem-vindo(a), {usuario.Nome}! Seu cadastro foi realizado com sucesso.";
            return RedirectToAction("Index", "Denuncia");
        }

        // GET: /Usuario/Login - Exibe o formulário de login
        [HttpGet]
        public IActionResult Login()
        {
            // Se o usuário já estiver autenticado, redireciona para a lista de denúncias
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
            // Verifica se o e-mail e a senha foram fornecidos
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                ModelState.AddModelError(string.Empty, "Informe o e-mail e a senha.");
                return View();
            }

            // Busca o usuário pelo e-mail no banco de dados
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

            // Verifica se o usuário existe e se a senha fornecida corresponde à senha criptografada
            if (usuario == null || !BCrypt.Net.BCrypt.Verify(senha, usuario.Senha))
            {
                ModelState.AddModelError(string.Empty, "E-mail ou senha inválidos.");
                return View();
            }

            // Realiza o login do usuário
            await SignInUser(usuario);

            // Redireciona o usuário para a página de listagem de denúncias
            TempData["Sucesso"] = $"Login realizado com sucesso, {usuario.Nome}!";
            return RedirectToAction("Index", "Denuncia");
        }

        // POST: /Usuario/Logout - Realiza o logout do usuário
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            TempData["Info"] = "Você foi desconectado(a).";
            return RedirectToAction("Login");
        }

        // GET: /Usuario/BemVindo - Redireciona usuários autenticados para a lista de denúncias
        // Esta ação agora serve principalmente para redirecionamento.
        [HttpGet]
        public IActionResult BemVindo()
        {
            // Se o usuário não estiver autenticado, redireciona para a página de Login
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login");
            }

            // Se o usuário está autenticado, redireciona imediatamente para a lista de denúncias
            return RedirectToAction("Index", "Denuncia");
        }

        // GET: /Usuario/AcessoNegado - Opcional: Página exibida quando o acesso é negado
        [HttpGet]
        public IActionResult AcessoNegado()
        {
            return View();
        }

        // Método auxiliar para realizar o processo de login (autenticação) do usuário
        private async Task SignInUser(Usuario usuario)
        {
            // Cria uma lista de Claims (reivindicações) para o usuário
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()), 
                new Claim(ClaimTypes.Name, usuario.Nome),                   
                new Claim(ClaimTypes.Email, usuario.Email)                  
            };

            // Cria uma ClaimsIdentity para o esquema de autenticação por Cookie
            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // Define as propriedades de autenticação para o cookie
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true, // Define se o cookie deve persistir após o navegador ser fechado
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8) // Define o tempo de expiração do cookie (8 horas)
                                                               // Deve ser consistente com o ExpireTimeSpan em Program.cs
            };

            // Realiza o login, criando o cookie de autenticação no navegador do usuário
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties); // Passa as propriedades de autenticação
        }
    }
}