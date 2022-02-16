using Microsoft.EntityFrameworkCore;
using Web.Site.GerenciadorCartao.Models;

namespace Web.Site.GerenciadorCartao.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Cartao> Cartoes { get; set; }
        public DbSet<Gasto> Gastos { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }
    }
}