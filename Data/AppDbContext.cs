using Microsoft.EntityFrameworkCore;
using Itau_invest.Models;

namespace Itau_invest.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Ativo> Ativo { get; set; }
        public DbSet<Operacao> Operacoes { get; set; }
        public DbSet<Cotacao> Cotacao { get; set; }
        public DbSet<Posicao> Posicao { get; set; }
    }
}