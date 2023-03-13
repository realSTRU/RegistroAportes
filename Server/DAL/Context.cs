using RegistroAportes.Shared.Models;

namespace RegistroAportes.Server.DAL
{
    public class Context :DbContext
    {

        public DbSet<Persona> Personas { get; set; }

        public DbSet<Aportes> Aportes { get; set; }

        public DbSet<TipoAporte> TiposAportes { get; set; }

        public Context(DbContextOptions<Context> options) :base(options) { }
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>().HasData(
                
                new Persona{
                    PersonaId = 1,
                    Nombre ="Cesar",
                    Celular = "829-863-5107",
                    Telefono = "829-986-6597",
                    Fecha_Nacimiento = DateOnly.FromDateTime(DateTime.Now),
                    Cedula = "402-3362470-5",
                    Total_Aportado = 250.00

                }
            );
        }
        



    }
}
