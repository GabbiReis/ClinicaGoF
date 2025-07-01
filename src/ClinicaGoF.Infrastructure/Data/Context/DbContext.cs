using ClinicaGoF.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClinicaGoF.Infrastructure.Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Paciente> Pacientes => Set<Paciente>();
    public DbSet<Medico> Medicos => Set<Medico>();
    public DbSet<Consulta> Consultas => Set<Consulta>();
}
