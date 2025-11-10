using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorJogos.Models
{
    public class Jogo
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Adicione um título ao jogo.")]
        [StringLength(200, ErrorMessage ="O título não pode ter mais de 200 caracteres.")]
        public string? Titulo { get; set; }
        [Required(ErrorMessage ="O ano de lançamento é obrigatório.")]
        [Range(1952, int.MaxValue, ErrorMessage ="Insira um ano válido para jogos digitais.")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "A URL da capa é obrigatória.")]
        [Url(ErrorMessage = "A capa deve ter uma URL válida.")]
        public string Capa { get; set; }

        public List<JogoPlataforma>? JogoPlataformas { get; set; }
        public List<JogoGenero>? JogoGeneros { get; set; }
    }
}

