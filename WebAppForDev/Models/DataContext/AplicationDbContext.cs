using Microsoft.EntityFrameworkCore;

namespace WebAppForDev.Models.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<FuncionariosModel> Funcionarios { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

//mirgration  dotnet ef migrations add InitialCreate

    }
}
