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
    // Classe DTO para receber os dados de localização do JavaScript
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

     
        #region Métodos CRUD antes de adicionar admin 'Por Henrique Alves'
        public async Task<IActionResult> Index()
        {
            if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId)) return Unauthorized();
            var denuncias = await _context.Denuncias.Where(d => d.UsuarioId == userId).OrderByDescending(d => d.DataCriacao).ToListAsync();
            return View(denuncias);
        }
        public IActionResult Create() { return View(); }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Denuncia denuncia)
        {
            ModelState.Remove("Status");
            ModelState.Remove("Protocolo");
            ModelState.Remove("DataCriacao");
            ModelState.Remove("UsuarioId");
            ModelState.Remove("Usuario");
            if (ModelState.IsValid)
            {
                if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId)) return RedirectToAction(nameof(Index));
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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId)) return Unauthorized();
            var denuncia = await _context.Denuncias.FirstOrDefaultAsync(d => d.Id == id && d.UsuarioId == userId);
            if (denuncia == null || denuncia.Status == StatusDenuncia.Fechada) return RedirectToAction(nameof(Index));
            return View(denuncia);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Denuncia denuncia)
        {
            if (id != denuncia.Id) return NotFound();
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
                    var denunciaExistente = await _context.Denuncias.AsNoTracking().FirstOrDefaultAsync(d => d.Id == id && d.UsuarioId == userId);
                    if (denunciaExistente == null || denunciaExistente.Status == StatusDenuncia.Fechada) return RedirectToAction(nameof(Index));
                    denuncia.Status = denunciaExistente.Status;
                    denuncia.Protocolo = denunciaExistente.Protocolo;
                    denuncia.DataCriacao = denunciaExistente.DataCriacao;
                    denuncia.UsuarioId = denunciaExistente.UsuarioId;
                    _context.Update(denuncia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) { if (!DenunciaExists(denuncia.Id)) return NotFound(); else throw; }
                return RedirectToAction(nameof(Index));
            }
            return View(denuncia);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId)) return Unauthorized();
            var denuncia = await _context.Denuncias.Include(d => d.Usuario).FirstOrDefaultAsync(m => m.Id == id && m.UsuarioId == userId);
            if (denuncia == null) return NotFound();
            return View(denuncia);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId)) return Unauthorized();
            var denuncia = await _context.Denuncias.FirstOrDefaultAsync(m => m.Id == id && m.UsuarioId == userId);
            if (denuncia == null || denuncia.Status == StatusDenuncia.Fechada) return RedirectToAction(nameof(Index));
            return View(denuncia);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId)) return Unauthorized();
            var denuncia = await _context.Denuncias.FirstOrDefaultAsync(d => d.Id == id && d.UsuarioId == userId);
            if (denuncia != null && denuncia.Status != StatusDenuncia.Fechada)
            {
                _context.Denuncias.Remove(denuncia);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        #endregion

        // GET: /Denuncia/LocalizacaoEmTempoReal
        [HttpGet]
        public IActionResult LocalizacaoEmTempoReal()   
        {
            ViewBag.NomeUsuario = User.FindFirstValue(ClaimTypes.Name);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AtivarModoPerigo([FromBody] LocationData location)
        {
            if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            {
                return Json(new { success = false, message = "Usuário não autenticado." });
            }

            var usuario = await _context.Usuarios.FindAsync(userId);
            if (usuario == null)
            {
                return Json(new { success = false, message = "Usuário não encontrado." });
            }

            usuario.EmPerigo = true;
            usuario.Latitude = location.Latitude;
            usuario.Longitude = location.Longitude;
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Modo perigo ativado." });
        }

   
        [HttpPost]
        public async Task<IActionResult> DesativarModoPerigo()
        {
            if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            {
                return Json(new { success = false, message = "Usuário não autenticado." });
            }

            var usuario = await _context.Usuarios.FindAsync(userId);
            if (usuario == null)
            {
                return Json(new { success = false, message = "Usuário não encontrado." });
            }

            usuario.EmPerigo = false;
            usuario.Latitude = null; // Limpa as coordenadas
            usuario.Longitude = null; // Limpa as coordenadas
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Modo perigo desativado." });
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