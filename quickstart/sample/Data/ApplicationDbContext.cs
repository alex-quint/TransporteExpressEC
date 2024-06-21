using Microsoft.EntityFrameworkCore;

namespace SampleMvcApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SampleMvcApp.ViewModels.Cliente> Cliente { get; set; } = default!;

        public DbSet<SampleMvcApp.ViewModels.Conductor> Conductor { get; set; }

        public DbSet<SampleMvcApp.ViewModels.Reserva> Reserva { get; set; }

        public DbSet<SampleMvcApp.ViewModels.Ruta> Ruta { get; set; }

        public DbSet<SampleMvcApp.ViewModels.Transporte> Transporte { get; set; }
        public DbSet<SampleMvcApp.ViewModels.Viaje> Viaje { get; set; }
    }
}
