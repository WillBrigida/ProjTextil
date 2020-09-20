using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PocIndustriaTextil.Core.Model;
using PocIndustriaTextil.Core.Modulos.Teste.Model;

namespace PocIndustriaTextil.Servidor.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Crianca> T_crianca { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
