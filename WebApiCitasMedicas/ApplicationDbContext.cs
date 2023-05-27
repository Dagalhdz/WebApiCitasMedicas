using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiCitasMedicas.Entities;

namespace WebApiCitasMedicas
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Citas> Citas { get; set; }
        public DbSet<Familiares> Familiares { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<HistorialPaciente> HistorialPacientes { get; set; }
        public DbSet<InformacionPaciente> InformacionPacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<MedicoPaciente> MedicosPacientes { get; set; }
        public DbSet<Parentesco> Parentescos { get; set; }


        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Medico>(d =>
            {
                d.ToTable("Medicos");
            });
            builder.Entity<Paciente>(d =>
            {
                d.ToTable("Pacientes");
            });

            builder.Entity<Familiares>()
                .HasOne(p => p.Paciente)
                .WithMany()
                .HasForeignKey(p => p.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Familiares>()
                .HasOne(p => p.Paciente)
                .WithMany()
                .HasForeignKey(p => p.FamiliarId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.Entity<Familiares>()
                .HasOne(p => p.Parentesco)
                .WithMany()
                .HasForeignKey(p => p.ParentescoId)
                .OnDelete(DeleteBehavior.Restrict);
        }


    }
}
