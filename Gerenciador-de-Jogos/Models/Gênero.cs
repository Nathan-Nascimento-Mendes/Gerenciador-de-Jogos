namespace GerenciadorJogos.Models
{
    public class Genero
    {
        public int Id { get; set; }
        public string? Nome { get; set; }

        public List<JogoGenero> JogoGeneros { get; set; } = new List<JogoGenero>();
    }
}
