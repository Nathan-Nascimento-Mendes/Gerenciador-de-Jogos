using GerenciadorJogos.Data.Seeds;
using GerenciadorJogos.Models;

using Microsoft.EntityFrameworkCore;

namespace GerenciadorJogos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Plataforma> Plataformas { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<JogoPlataforma> JogoPlataformas { get; set; }
        public DbSet<JogoGenero> JogoGeneros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<JogoPlataforma>()
                .HasKey(jp => new { jp.JogoId, jp.PlataformaId });

            modelBuilder.Entity<JogoGenero>()
                .HasKey(jg => new { jg.JogoId, jg.GeneroId });


            modelBuilder.Entity<JogoPlataforma>()
                .HasOne(jp => jp.Jogo)
                .WithMany(j => j.JogoPlataformas)
                .HasForeignKey(jp => jp.JogoId);

            modelBuilder.Entity<JogoPlataforma>()
                .HasOne(jp => jp.Plataforma)
                .WithMany()
                .HasForeignKey(jp => jp.PlataformaId);

            modelBuilder.Entity<JogoGenero>()
                .HasOne(jg => jg.Jogo)
                .WithMany(j => j.JogoGeneros)
                .HasForeignKey(jg => jg.JogoId);

            modelBuilder.Entity<JogoGenero>()
                .HasOne(jg => jg.Genero)
                .WithMany(g => g.JogoGeneros)
                .HasForeignKey(jg => jg.GeneroId);


            SeedData.Popular(modelBuilder);
        }
    }
}
