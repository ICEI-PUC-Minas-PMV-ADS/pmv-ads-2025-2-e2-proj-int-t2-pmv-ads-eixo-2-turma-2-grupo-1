using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SistemaDenuncias.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System;

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

        // GET: /Denuncia/Index (Tarefa implementada por 'Henrique Alves'
        // Exibe todas as denúncias do usuário logado
        public async Task<IActionResult> Index()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var denuncias = await _context.Denuncias
                                          .Where(d => d.UsuarioId == userId)
                                          .OrderByDescending(d => d.DataCriacao)
                                          .ToListAsync();
            return View(denuncias);
        }

        // GET: /Denuncia/Create (Tarefa implementada por 'Henrique Alves'
        // Exibe o formulário para criar uma nova denúncia
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Denuncia/Create (Tarefa implementada por 'Henrique Alves'
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
                int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                denuncia.UsuarioId = userId;
                denuncia.DataCriacao = DateTime.Now;
                denuncia.Status = StatusDenuncia.Aberta;
                denuncia.Protocolo = GerarProtocolo();

                _context.Add(denuncia);
                await _context.SaveChangesAsync();
                TempData["Sucesso"] = "Denúncia criada com sucesso!";
                return RedirectToAction(nameof(Index)); // Redireciona para Index
            }
            return View(denuncia);
        }

        // GET: /Denuncia/Edit/{id} (Tarefa implementada por 'Henrique Alves'

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var denuncia = await _context.Denuncias
                                         .FirstOrDefaultAsync(d => d.Id == id && d.UsuarioId == userId);

            if (denuncia == null)
            {
                return NotFound(); // Denúncia não encontrada ou não pertence ao usuário
            }

            // Somente permite edição se o status for Aberta ou Analise
            if (denuncia.Status == StatusDenuncia.Fechada)
            {
                TempData["Erro"] = "Não é possível editar uma denúncia com status 'Fechada'.";
                return RedirectToAction(nameof(Index)); // Redireciona para Index
            }

            return View(denuncia);
        }

        // POST: /Denuncia/Edit/{id} (Tarefa implementada por 'Henrique Alves'

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Denuncia denuncia)
        {
            if (id != denuncia.Id)
            {
                return NotFound();
            }

            // Removendo campos que não devem ser alterados pelo usuário na edição
            ModelState.Remove("Status");
            ModelState.Remove("Protocolo");
            ModelState.Remove("DataCriacao");
            ModelState.Remove("UsuarioId");
            ModelState.Remove("Usuario");

            if (ModelState.IsValid)
            {
                try
                {
                    int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                    var denunciaExistente = await _context.Denuncias
                                                          .AsNoTracking()
                                                          .FirstOrDefaultAsync(d => d.Id == id && d.UsuarioId == userId);

                    if (denunciaExistente == null)
                    {
                        return NotFound();
                    }

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
                    if (!DenunciaExists(denuncia.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index)); 
            }
            return View(denuncia);
        }

        // GET: /Denuncia/Details/{id} (Tarefa implementada por 'Henrique Alves'
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var denuncia = await _context.Denuncias
                                         .Include(d => d.Usuario)
                                         .FirstOrDefaultAsync(m => m.Id == id && m.UsuarioId == userId);

            if (denuncia == null)
            {
                return NotFound();
            }

            return View(denuncia);
        }

        // GET: /Denuncia/Delete/{id} (Tarefa implementada por 'Henrique Alves'
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var denuncia = await _context.Denuncias
                                         .FirstOrDefaultAsync(m => m.Id == id && m.UsuarioId == userId);

            if (denuncia == null)
            {
                return NotFound();
            }

            // Somente permite exclusão se o status for Aberta ou Analise
            if (denuncia.Status == StatusDenuncia.Fechada)
            {
                TempData["Erro"] = "Não é possível excluir uma denúncia com status 'Fechada'.";
                return RedirectToAction(nameof(Index)); 
            }

            return View(denuncia);
        }

        // POST: /Denuncia/Delete/{id} ((Tarefa implementada por 'Henrique Alves'
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var denuncia = await _context.Denuncias.FirstOrDefaultAsync(d => d.Id == id && d.UsuarioId == userId);

            if (denuncia == null)
            {
                return NotFound();
            }

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

        private bool DenunciaExists(int id)
        {
            return _context.Denuncias.Any(e => e.Id == id);
        }

        private string GerarProtocolo()
        {
            return Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
        }
    }
}