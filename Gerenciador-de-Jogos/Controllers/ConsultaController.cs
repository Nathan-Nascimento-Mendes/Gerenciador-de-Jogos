// Controllers/ConsultaController.cs
#nullable enable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GerenciadorJogos.Data;

namespace GerenciadorJogos.Controllers
{
    public class ConsultaController : Controller
    {
        private readonly AppDbContext _context;

        public ConsultaController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // CONSULTA 1: Jogos e Plataformas (N:N via JogoPlataforma)
        public IActionResult JogosPlataformas()
        {
            var jpList = _context.JogoPlataformas
                .Include(jp => jp.Jogo)
                .Include(jp => jp.Plataforma)
                .ToList();

            var resultado = new List<IDictionary<string, object>>();

            foreach (var jp in jpList)
            {
                var dict = new Dictionary<string, object>();

                var jogoObj = jp.GetType().GetProperty("Jogo")?.GetValue(jp);
                var plataformaObj = jp.GetType().GetProperty("Plataforma")?.GetValue(jp);

                dict["Jogo"] = GetStringProperty(jogoObj, "Nome", "Titulo", "Title", "NomeJogo") ?? "(sem nome)";
                dict["Plataforma"] = GetStringProperty(plataformaObj, "Nome", "Title", "NomePlataforma") ?? "(sem plataforma)";

                var precoNullable = GetDecimalProperty(jogoObj, "Preco", "Valor", "Price");
                dict["Preco"] = precoNullable.HasValue ? precoNullable.Value.ToString("F2") : "";

                var anoNullable = GetIntProperty(jogoObj, "AnoLancamento", "Ano", "AnoDeLancamento", "Lancamento");
                dict["Ano"] = anoNullable.HasValue ? anoNullable.Value.ToString() : "";

                resultado.Add(dict);
            }

            ViewBag.Titulo = "Consulta 1 - Jogos e Plataformas";
            return View("Resultado", resultado);
        }

        // CONSULTA 2: Agrupamento por ano (quantidade e média de preço)
        public IActionResult JogosPorAno()
        {
            var jogos = _context.Jogos.ToList();

            var parcial = jogos
                .Select(j => new
                {
                    JogoObj = j,
                    Ano = GetIntProperty(j, "AnoLancamento", "Ano", "AnoDeLancamento", "Lancamento")
                })
                .Where(x => x.Ano.HasValue) // garante não-nulo antes de agrupar
                .ToList();

            var grupos = parcial
                .GroupBy(x => x.Ano!.Value) // seguro: filtramos HasValue
                .OrderBy(g => g.Key)
                .Select(g =>
                {
                    var listaJogos = g.Select(x => x.JogoObj).ToList();
                    var quantidade = listaJogos.Count;

                    // calcula média apenas com valores presentes
                    var precos = listaJogos
                        .Select(j => GetDecimalProperty(j, "Preco", "Valor", "Price"))
                        .Where(v => v.HasValue)
                        .Select(v => v!.Value)
                        .ToList();

                    decimal media = 0m;
                    if (precos.Any())
                        media = Math.Round(precos.Average(), 2);

                    var dict = new Dictionary<string, object>
                    {
                        ["Ano"] = g.Key,
                        ["Quantidade"] = quantidade,
                        ["MediaPreco"] = media
                    } as IDictionary<string, object>;

                    return dict;
                })
                .ToList();

            ViewBag.Titulo = "Consulta 2 - Jogos por Ano (Qtd e Média)";
            return View("Resultado", grupos);
        }

        // CONSULTA 3: Anos > 2010 com mais de 1 jogo (total de valores)
        public IActionResult AnosComMaisDeUmJogo()
        {
            var jogos = _context.Jogos.ToList();

            var parcial = jogos
                .Select(j => new
                {
                    JogoObj = j,
                    Ano = GetIntProperty(j, "AnoLancamento", "Ano", "AnoDeLancamento", "Lancamento")
                })
                .Where(x => x.Ano.HasValue && x.Ano.Value > 2010)
                .ToList();

            var consulta = parcial
                .GroupBy(x => x.Ano!.Value) // seguro: filtrado acima
                .Select(g =>
                {
                    var lista = g.Select(x => x.JogoObj).ToList();
                    var qtd = lista.Count;

                    var soma = lista
                        .Select(j => GetDecimalProperty(j, "Preco", "Valor", "Price"))
                        .Where(v => v.HasValue)
                        .Select(v => v!.Value)
                        .DefaultIfEmpty(0m)
                        .Sum();

                    return new Dictionary<string, object>
                    {
                        ["Ano"] = g.Key,
                        ["Quantidade"] = qtd,
                        ["TotalValor"] = Math.Round(soma, 2)
                    } as IDictionary<string, object>;
                })
                .Where(d => Convert.ToInt32(d["Quantidade"]) > 1)
                .OrderBy(d => Convert.ToInt32(d["Ano"]))
                .ToList();

            ViewBag.Titulo = "Consulta 3 - Anos (>2010) com mais de 1 jogo";
            return View("Resultado", consulta);
        }

        // Helpers reflexivos (seguros)
        private static string? GetStringProperty(object? obj, params string[] candidateNames)
        {
            if (obj == null) return null;
            foreach (var name in candidateNames)
            {
                var p = obj.GetType().GetProperty(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (p != null)
                {
                    var val = p.GetValue(obj);
                    if (val != null) return val.ToString();
                }
            }
            return null;
        }

        private static int? GetIntProperty(object? obj, params string[] candidateNames)
        {
            if (obj == null) return null;
            foreach (var name in candidateNames)
            {
                var p = obj.GetType().GetProperty(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (p == null) continue;
                var val = p.GetValue(obj);
                if (val == null) continue;

                if (val is int i) return i;
                if (val is long l && l >= int.MinValue && l <= int.MaxValue) return (int)l;
                if (val is short s) return (int)s;
                if (val is DateTime dt) return dt.Year;
                if (int.TryParse(val.ToString(), out var parsed)) return parsed;
            }
            return null;
        }

        private static decimal? GetDecimalProperty(object? obj, params string[] candidateNames)
        {
            if (obj == null) return null;
            foreach (var name in candidateNames)
            {
                var p = obj.GetType().GetProperty(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (p == null) continue;
                var val = p.GetValue(obj);
                if (val == null) continue;

                if (val is decimal d) return d;
                if (val is double db) return Convert.ToDecimal(db);
                if (val is float f) return Convert.ToDecimal(f);
                if (val is int iv) return Convert.ToDecimal(iv);
                if (decimal.TryParse(val.ToString(), out var parsed)) return parsed;
            }
            return null;
        }
    }
}
