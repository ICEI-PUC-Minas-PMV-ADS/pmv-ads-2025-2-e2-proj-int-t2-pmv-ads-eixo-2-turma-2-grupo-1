using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SistemaDenuncias.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq; // Adicionado para o .Where e .Any

namespace SistemaDenuncias.Controllers
{
    [Authorize]
    public class DenunciaController : Controller
    {
        private readonly AppDbContext _context;

        public DenunciaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Denuncia/Index 
        // Exibe todas as denúncias do usuário logado
        public async Task<IActionResult> Index()
        {
            // Ajuste para parsing mais seguro, embora o FindFirstValue retorne string.
            if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            {
                return Unauthorized();
            }

            var denuncias = await _context.Denuncias
                                          .Where(d => d.UsuarioId == userId)
                                          .OrderByDescending(d => d.DataCriacao)
                                          .ToListAsync();
            return View(denuncias);
        }

        // GET: /Denuncia/Create 
        // Exibe o formulário para criar uma nova denúncia
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Denuncia/Create 
        // Processa o envio do formulário de criação de denúncia
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Denuncia denuncia)
        {
            // Removendo campos que não devem ser definidos pelo usuário ou que já são preenchidos automaticamente
            ModelState.Remove("Status");
            ModelState.Remove("Protocolo");
            ModelState.Remove("DataCriacao");
            ModelState.Remove("UsuarioId");
            ModelState.Remove("Usuario");

            if (ModelState.IsValid)
            {
                if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
                {
                    TempData["Erro"] = "Usuário não autenticado corretamente.";
                    return RedirectToAction(nameof(Index));
                }

                denuncia.UsuarioId = userId;
                denuncia.DataCriacao = DateTime.Now;
                denuncia.Status = StatusDenuncia.Aberta;
                denuncia.Protocolo = GerarProtocolo();

                _context.Add(denuncia);
                await _context.SaveChangesAsync();
                TempData["Sucesso"] = "Denúncia criada com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            return View(denuncia);
        }

        // GET: /Denuncia/Edit/{id} 
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId)) return Unauthorized();

            var denuncia = await _context.Denuncias
                                         .FirstOrDefaultAsync(d => d.Id == id && d.UsuarioId == userId);

            if (denuncia == null) return NotFound();

            // Somente permite edição se o status for Aberta ou Analise
            if (denuncia.Status == StatusDenuncia.Fechada)
            {
                TempData["Erro"] = "Não é possível editar uma denúncia com status 'Fechada'.";
                return RedirectToAction(nameof(Index));
            }

            return View(denuncia);
        }

        // POST: /Denuncia/Edit/{id} 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Denuncia denuncia)
        {
            if (id != denuncia.Id) return NotFound();

            // Removendo campos que não devem ser alterados pelo usuário na edição
            ModelState.Remove("Status");
            ModelState.Remove("Protocolo");
            ModelState.Remove("DataCriacao");
            ModelState.Remove("UsuarioId");
            ModelState.Remove("Usuario");

            if (ModelState.IsValid)
            {
                if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId)) return Unauthorized();

                try
                {
                    var denunciaExistente = await _context.Denuncias
                                                          .AsNoTracking()
                                                          .FirstOrDefaultAsync(d => d.Id == id && d.UsuarioId == userId);

                    if (denunciaExistente == null) return NotFound();

                    // Somente permite edição se o status for Aberta ou Analise
                    if (denunciaExistente.Status == StatusDenuncia.Fechada)
                    {
                        TempData["Erro"] = "Não é possível editar uma denúncia com status 'Fechada'.";
                        return RedirectToAction(nameof(Index));
                    }

                    // Manter os valores de Status, Protocolo, DataCriacao e UsuarioId
                    denuncia.Status = denunciaExistente.Status;
                    denuncia.Protocolo = denunciaExistente.Protocolo;
                    denuncia.DataCriacao = denunciaExistente.DataCriacao;
                    denuncia.UsuarioId = denunciaExistente.UsuarioId;

                    _context.Update(denuncia);
                    await _context.SaveChangesAsync();
                    TempData["Sucesso"] = "Denúncia atualizada com sucesso!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DenunciaExists(denuncia.Id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(denuncia);
        }

        // GET: /Denuncia/Details/{id} 
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId)) return Unauthorized();

            var denuncia = await _context.Denuncias
                                         .Include(d => d.Usuario)
                                         .FirstOrDefaultAsync(m => m.Id == id && m.UsuarioId == userId);

            if (denuncia == null) return NotFound();

            return View(denuncia);
        }

        // GET: /Denuncia/Delete/{id} 
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId)) return Unauthorized();

            var denuncia = await _context.Denuncias
                                         .FirstOrDefaultAsync(m => m.Id == id && m.UsuarioId == userId);

            if (denuncia == null) return NotFound();

            // Somente permite exclusão se o status for Aberta ou Analise
            if (denuncia.Status == StatusDenuncia.Fechada)
            {
                TempData["Erro"] = "Não é possível excluir uma denúncia com status 'Fechada'.";
                return RedirectToAction(nameof(Index));
            }

            return View(denuncia);
        }

        // POST: /Denuncia/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId)) return Unauthorized();

            var denuncia = await _context.Denuncias.FirstOrDefaultAsync(d => d.Id == id && d.UsuarioId == userId);

            if (denuncia == null) return NotFound();

            // Verificação de status novamente antes de excluir
            if (denuncia.Status == StatusDenuncia.Fechada)
            {
                TempData["Erro"] = "Não é possível excluir uma denúncia com status 'Fechada'.";
                return RedirectToAction(nameof(Index));
            }

            _context.Denuncias.Remove(denuncia);
            await _context.SaveChangesAsync();
            TempData["Sucesso"] = "Denúncia excluída com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        // GET: /Denuncia/LocalizacaoEmTempoReal
        // NOVO: Action para exibir a página de coleta de localização de emergência.
        [HttpGet]
        public IActionResult LocalizacaoEmTempoReal()
        {
            // Pega o nome do usuário logado para exibir na página de localização
            ViewBag.NomeUsuario = User.FindFirstValue(ClaimTypes.Name);
            return View();
        }

        private bool DenunciaExists(int id)
        {
            return _context.Denuncias.Any(e => e.Id == id);
        }

        private string GerarProtocolo()
        {
            // Gera um protocolo único de 8 caracteres
            return Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
        }
    }
}