using System.Collections.Generic;

namespace GerenciadorJogos.Models
{
    public class Plataforma
    {
        public int Id { get; set; }
        public string? Nome { get; set; }

        public List<JogoPlataforma> JogosPlataformas { get; set; } = new List<JogoPlataforma>();
    }
}
