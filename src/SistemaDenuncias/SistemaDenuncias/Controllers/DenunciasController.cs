using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SistemaDenuncias.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;

namespace SistemaDenuncias.Controllers
{
    public class LocationData
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    [Authorize]
    public class DenunciaController : Controller
    {
        private readonly AppDbContext _context;

        public DenunciaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Denuncia/Index
        public async Task<IActionResult> Index()
        {
            if (!TryGetUserId(out int userId)) return Unauthorized();

            var denuncias = await _context.Denuncias
                .AsNoTracking()
                .Where(d => d.UsuarioId == userId)
                .OrderByDescending(d => d.DataCriacao)
                .ToListAsync();

            return View(denuncias);
        }

        // GET: /Denuncia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Denuncia/Create (CORRIGIDO E FUNCIONAL com ModelState.Remove)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Denuncia denuncia)
        {
            if (!TryGetUserId(out int userId)) return Unauthorized();

            // 1. Remove a validação dos campos que serão preenchidos pelo servidor.
            // Isso garante que o ModelState.IsValid foque apenas nos campos preenchidos pelo usuário.
            ModelState.Remove(nameof(Denuncia.Usuario)); // Propriedade de navegação
            ModelState.Remove(nameof(Denuncia.Protocolo));
            ModelState.Remove(nameof(Denuncia.DataCriacao));
            ModelState.Remove(nameof(Denuncia.Status));
            ModelState.Remove(nameof(Denuncia.UsuarioId));

            // 2. Verifica se os campos que o usuário preencheu são válidos.
            if (ModelState.IsValid)
            {
                // 3. Preenche os campos restantes com a lógica do servidor.
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
            if (!TryGetUserId(out int userId)) return Unauthorized();

            var denuncia = await _context.Denuncias
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.Id == id && d.UsuarioId == userId);

            if (denuncia == null || denuncia.Status == StatusDenuncia.Fechada)
            {
                TempData["Erro"] = "Esta denúncia não pode ser editada.";
                return RedirectToAction(nameof(Index));
            }
            return View(denuncia);
        }

        // POST: /Denuncia/Edit/{id} (Seguro e funcional)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Denuncia denunciaFormData)
        {
            if (id != denunciaFormData.Id) return NotFound();
            if (!TryGetUserId(out int userId)) return Unauthorized();

            // Remove a validação dos campos que não devem ser alterados pelo usuário.
            ModelState.Remove(nameof(Denuncia.Usuario));
            ModelState.Remove(nameof(Denuncia.Protocolo));
            ModelState.Remove(nameof(Denuncia.DataCriacao));
            ModelState.Remove(nameof(Denuncia.Status));
            ModelState.Remove(nameof(Denuncia.UsuarioId));

            if (ModelState.IsValid)
            {
                try
                {
                    var denunciaParaAtualizar = await _context.Denuncias.FirstOrDefaultAsync(d => d.Id == id && d.UsuarioId == userId);
                    if (denunciaParaAtualizar == null || denunciaParaAtualizar.Status == StatusDenuncia.Fechada)
                    {
                        TempData["Erro"] = "Esta denúncia não pode mais ser editada.";
                        return RedirectToAction(nameof(Index));
                    }

                   
                    denunciaParaAtualizar.TipoDenuncia = denunciaFormData.TipoDenuncia;
                    denunciaParaAtualizar.Descricao = denunciaFormData.Descricao;
                    denunciaParaAtualizar.Estado = denunciaFormData.Estado;
                    denunciaParaAtualizar.Cidade = denunciaFormData.Cidade;
                    denunciaParaAtualizar.Rua = denunciaFormData.Rua;
                    denunciaParaAtualizar.Bairro = denunciaFormData.Bairro;
                    denunciaParaAtualizar.Numero = denunciaFormData.Numero;
                    denunciaParaAtualizar.Complemento = denunciaFormData.Complemento;
                    denunciaParaAtualizar.Cep = denunciaFormData.Cep;
                    denunciaParaAtualizar.DenunciaAnonima = denunciaFormData.DenunciaAnonima;

                    await _context.SaveChangesAsync();
                    TempData["Sucesso"] = "Denúncia atualizada com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DenunciaExists(denunciaFormData.Id)) return NotFound();
                    else throw;
                }
            }
            
            return View(denunciaFormData);
        }

        // GET: /Denuncia/Details/{id}
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            if (!TryGetUserId(out int userId)) return Unauthorized();
            var denuncia = await _context.Denuncias.AsNoTracking().Include(d => d.Usuario).FirstOrDefaultAsync(m => m.Id == id && m.UsuarioId == userId);
            if (denuncia == null) return NotFound();
            return View(denuncia);
        }

        // GET: /Denuncia/Delete/{id}
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            if (!TryGetUserId(out int userId)) return Unauthorized();
            var denuncia = await _context.Denuncias.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id && m.UsuarioId == userId);
            if (denuncia == null || denuncia.Status == StatusDenuncia.Fechada)
            {
                TempData["Erro"] = "Esta denúncia não pode ser excluída.";
                return RedirectToAction(nameof(Index));
            }
            return View(denuncia);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!TryGetUserId(out int userId)) return Unauthorized();
            var denuncia = await _context.Denuncias.FirstOrDefaultAsync(d => d.Id == id && d.UsuarioId == userId);
            if (denuncia != null && denuncia.Status != StatusDenuncia.Fechada)
            {
                _context.Denuncias.Remove(denuncia);
                await _context.SaveChangesAsync();
                TempData["Sucesso"] = "Denúncia excluída com sucesso!";
            }
            else
            {
                TempData["Erro"] = "Não foi possível excluir a denúncia.";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult LocalizacaoEmTempoReal()
        {
            ViewBag.NomeUsuario = User.FindFirstValue(ClaimTypes.Name);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AtivarModoPerigo([FromBody] LocationData location)
        {
            if (!TryGetUserId(out int userId)) return Json(new { success = false, message = "Usuário não autenticado." });
            var usuario = await _context.Usuarios.FindAsync(userId);
            if (usuario == null) return Json(new { success = false, message = "Usuário não encontrado." });
            usuario.EmPerigo = true;
            usuario.Latitude = location.Latitude;
            usuario.Longitude = location.Longitude;
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Modo perigo ativado." });
        }

        [HttpPost]
        public async Task<IActionResult> DesativarModoPerigo()
        {
            if (!TryGetUserId(out int userId)) return Json(new { success = false, message = "Usuário não autenticado." });
            var usuario = await _context.Usuarios.FindAsync(userId);
            if (usuario == null) return Json(new { success = false, message = "Usuário não encontrado." });
            usuario.EmPerigo = false;
            usuario.Latitude = null;
            usuario.Longitude = null;
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Modo perigo desativado." });
        }

        #region Métodos Auxiliares
        private bool DenunciaExists(int id) => _context.Denuncias.Any(e => e.Id == id);
        private string GerarProtocolo() => Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
        private bool TryGetUserId(out int userId)
        {
            userId = 0;
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim, out userId))
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}