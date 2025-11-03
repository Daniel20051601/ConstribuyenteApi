using ConstribuyenteApi.Contribuyente.Models;
using Microsoft.EntityFrameworkCore;

namespace ConstribuyenteApi.Contribuyente.Dal;

public class Contexto: DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
    }

    public DbSet<Contribuyentes> Contribuyentes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Contribuyentes>().HasData(
            new Contribuyentes { id = 1, cedula = "40233012394", nombre = "Johan", telefono = "8046559632", direccion = "Madre Vieja", email = "johanes384@gmail.com", fechaRegistro = "2025-01-16" },
            new Contribuyentes { id = 2, cedula = "40233345675", nombre = "Malvin", telefono = "8296559632", direccion = "Cotui", email = "mvillatapia384@gmail.com", fechaRegistro = "2025-01-16" }
            );
    }

}
