namespace GerenciadorJogos.Models
{
    public class JogoPlataforma
    {
        public int JogoId { get; set; }
        public Jogo? Jogo { get; set; }

        public int PlataformaId { get; set; }
        public Plataforma? Plataforma { get; set; }

        public decimal Valor { get; set; }
    }
}
