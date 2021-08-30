using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteFrame.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Vitrine> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Vitrine>()
                .Property(p => p.Nome)
                .HasMaxLength(50);

            modelBuilder.Entity<Vitrine>()
                .Property(p => p.Valor)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Vitrine>()
                .HasData(
                new Vitrine { Codigo = 1, Nome = "Maçã", Descricao = "Maçã", Imagem = null, Quantidade = 10, Valor = 2 },
                new Vitrine { Codigo = 2, Nome = "Banana", Descricao = "Banana", Imagem = null, Quantidade = 10, Valor = 4 },
                new Vitrine { Codigo = 3, Nome = "Manga", Descricao = "Manga", Imagem = null, Quantidade = 10, Valor = 3 },
                new Vitrine { Codigo = 4, Nome = "Morango", Descricao = "Morango", Imagem = null, Quantidade = 10, Valor = 6 }
                );

        }


    }
}
