using GerenciadorJogos.Data;
using GerenciadorJogos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorJogos.Controllers
{
    public class JogosController : Controller
    {
        private readonly AppDbContext _context;

        public JogosController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var jogos = await _context.Jogos
                .Include(j => j.JogoPlataformas).ThenInclude(jp => jp.Plataforma)
                .Include(j => j.JogoGeneros).ThenInclude(jg => jg.Genero)
                .ToListAsync();
            return View(jogos);
        }

        public IActionResult Create()
        {
            ViewBag.Plataformas = _context.Plataformas.ToList();
            ViewBag.Generos = _context.Generos.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
    [Bind("Titulo,Ano,Capa")] Jogo jogo,
    List<int> plataformaIds,
    List<int> generoIds,
    Dictionary<int, string> valores)
        {
            // 🔹 Validações de modelo (Título, Ano, Capa)
            if (jogo.Ano > DateTime.Now.Year)
                ModelState.AddModelError("Ano", $"O ano não pode ser maior que {DateTime.Now.Year}.");

            if (string.IsNullOrWhiteSpace(jogo.Titulo))
                ModelState.AddModelError("Titulo", "O título é obrigatório.");

            if (string.IsNullOrWhiteSpace(jogo.Capa))
                ModelState.AddModelError("Capa", "A URL da capa é obrigatória.");

            // 🔹 Validação de plataformas
            if (plataformaIds == null || !plataformaIds.Any())
                ModelState.AddModelError("Plataformas", "Selecione pelo menos uma plataforma.");

            // 🔹 Validação de valores das plataformas
            if (plataformaIds != null)
            {
                foreach (var plataformaId in plataformaIds)
                {
                    if (!valores.TryGetValue(plataformaId, out string valorStr) ||
                        !decimal.TryParse(valorStr.Replace(",", "."), System.Globalization.NumberStyles.Any,
                            System.Globalization.CultureInfo.InvariantCulture, out decimal valor) ||
                        valor <= 0)
                    {
                        ModelState.AddModelError("Plataformas", "Insira um valor válido (> 0) para cada plataforma selecionada.");
                    }
                }
            }

            // 🔹 Validação de gêneros
            if (generoIds == null || !generoIds.Any())
                ModelState.AddModelError("Generos", "Selecione pelo menos um gênero.");

            // 🔹 Se algo falhou, retorna à view
            if (!ModelState.IsValid)
            {
                ViewBag.Plataformas = _context.Plataformas.ToList();
                ViewBag.Generos = _context.Generos.ToList();
                return View(jogo);
            }

            // 🔹 Salva o jogo
            _context.Add(jogo);
            await _context.SaveChangesAsync();

            // 🔹 Associa plataformas
            foreach (var plataformaId in plataformaIds)
            {
                var valorDecimal = decimal.Parse(valores[plataformaId].Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture);

                _context.JogoPlataformas.Add(new JogoPlataforma
                {
                    JogoId = jogo.Id,
                    PlataformaId = plataformaId,
                    Valor = valorDecimal
                });
            }

            // 🔹 Associa gêneros
            foreach (var generoId in generoIds)
            {
                _context.JogoGeneros.Add(new JogoGenero
                {
                    JogoId = jogo.Id,
                    GeneroId = generoId
                });
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var jogo = await _context.Jogos
                .Include(j => j.JogoPlataformas)
                .Include(j => j.JogoGeneros)
                .FirstOrDefaultAsync(j => j.Id == id);
            if (jogo == null) return NotFound();
            ViewBag.Plataformas = _context.Plataformas.ToList();
            ViewBag.Generos = _context.Generos.ToList();
            ViewBag.SelectedPlataformaIds = jogo.JogoPlataformas.Select(jp => jp.PlataformaId).ToList();
            ViewBag.SelectedGeneroIds = jogo.JogoGeneros.Select(jg => jg.GeneroId).ToList();
            return View(jogo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
    int id,
    [Bind("Id,Titulo,Ano,Capa")] Jogo jogo,
    List<int> plataformaIds,
    List<int> generoIds,
    Dictionary<int, string> valores)
        {
            if (id != jogo.Id) return NotFound();

            if (jogo.Ano > DateTime.Now.Year)
                ModelState.AddModelError("Ano", $"O ano não pode ser maior que {DateTime.Now.Year}.");

            if (string.IsNullOrWhiteSpace(jogo.Titulo))
                ModelState.AddModelError("Titulo", "O título é obrigatório.");

            if (string.IsNullOrWhiteSpace(jogo.Capa))
                ModelState.AddModelError("Capa", "A URL da capa é obrigatória.");

            if (plataformaIds == null || !plataformaIds.Any())
                ModelState.AddModelError("Plataformas", "Selecione pelo menos uma plataforma.");

            if (plataformaIds != null)
            {
                foreach (var plataformaId in plataformaIds)
                {
                    if (!valores.TryGetValue(plataformaId, out string valorStr) ||
                        !decimal.TryParse(valorStr.Replace(",", "."), System.Globalization.NumberStyles.Any,
                            System.Globalization.CultureInfo.InvariantCulture, out decimal valor) ||
                        valor <= 0)
                    {
                        ModelState.AddModelError("Plataformas", "Insira um valor válido (> 0) para cada plataforma selecionada.");
                    }
                }
            }

            if (generoIds == null || !generoIds.Any())
                ModelState.AddModelError("Generos", "Selecione pelo menos um gênero.");

            if (!ModelState.IsValid)
            {
                ViewBag.Plataformas = _context.Plataformas.ToList();
                ViewBag.Generos = _context.Generos.ToList();
                ViewBag.SelectedGeneroIds = generoIds ?? new List<int>();
                return View(jogo);
            }

            _context.Update(jogo);

            // 🔄 Atualiza associações
            var existingPlataformas = _context.JogoPlataformas.Where(jp => jp.JogoId == id).ToList();
            var existingGeneros = _context.JogoGeneros.Where(jg => jg.JogoId == id).ToList();
            _context.JogoPlataformas.RemoveRange(existingPlataformas);
            _context.JogoGeneros.RemoveRange(existingGeneros);

            foreach (var plataformaId in plataformaIds)
            {
                var valorDecimal = decimal.Parse(valores[plataformaId].Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture);

                _context.JogoPlataformas.Add(new JogoPlataforma
                {
                    JogoId = id,
                    PlataformaId = plataformaId,
                    Valor = valorDecimal
                });
            }

            foreach (var generoId in generoIds)
            {
                _context.JogoGeneros.Add(new JogoGenero
                {
                    JogoId = id,
                    GeneroId = generoId
                });
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var jogo = await _context.Jogos
                .Include(j => j.JogoPlataformas).ThenInclude(jp => jp.Plataforma)
                .Include(j => j.JogoGeneros).ThenInclude(jg => jg.Genero)
                .FirstOrDefaultAsync(j => j.Id == id);
            if (jogo == null) return NotFound();
            return View(jogo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)  // <-- REMOVA ActionName("Delete")
        {
            var jogo = await _context.Jogos
                .Include(j => j.JogoPlataformas)
                .Include(j => j.JogoGeneros)
                .FirstOrDefaultAsync(j => j.Id == id);

            if (jogo == null) return NotFound();

            _context.JogoPlataformas.RemoveRange(jogo.JogoPlataformas);
            _context.JogoGeneros.RemoveRange(jogo.JogoGeneros);
            _context.Jogos.Remove(jogo);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var jogo = await _context.Jogos
                .Include(j => j.JogoPlataformas).ThenInclude(jp => jp.Plataforma)
                .Include(j => j.JogoGeneros).ThenInclude(jg => jg.Genero)
                .FirstOrDefaultAsync(j => j.Id == id);
            if (jogo == null) return NotFound();
            return View(jogo);
        }
    }
}