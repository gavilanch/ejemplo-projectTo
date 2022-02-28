using Microsoft.EntityFrameworkCore;
using ProjectDemoYoutubeESP.Entidades;

namespace ProjectDemoYoutubeESP
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(150);
            configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var persona = new Persona()
            {
                Id = 1,
                Nombre = "Felipe",
                Cedula = "123",
                EstaLogueado = true,
                FechaNacimiento = new DateTime(1901, 1, 1),
                Salario = 123.45m
            };

            var direcciones = new List<Direccion>() {
                new Direccion()
            {
                Id = 1,
                PersonaId = persona.Id,
                Calle = "Calle 123",
                CodigoPostal = "Codigo postal 123",
                Comentario = "Hay perro",
                Provincia = "Provincia 123",
                Telefono = "123-456",
                Pais = "Rep. Dominicana"
            },
                new Direccion()
            {
                Id = 2,
                PersonaId = persona.Id,
                Calle = "Calle 456",
                CodigoPostal = "Codigo postal 456",
                Comentario = "Hay dos perros",
                Provincia = "Provincia 456",
                Telefono = "456-789",
                Pais = "Rep. Dominicana"
            }
            };

            modelBuilder.Entity<Persona>().HasData(persona);
            modelBuilder.Entity<Direccion>().HasData(direcciones);
        }

        public DbSet<Persona> Personas { get; set; }

    }

}
