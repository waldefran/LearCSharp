using Microsoft.EntityFrameworkCore;

namespace WebAppForDev.Models.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<FuncionariosModel> Funcionarios { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações adicionais do modelo, se necessário
        }
    }
}