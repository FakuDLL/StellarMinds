using Microsoft.EntityFrameworkCore;
using StellarMinds.AccesoDatos.Configurations;
using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.AccesoDatos
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<AuditoriaPrestamo> AuditoriasPrestamo { get; set; }
        public DbSet<ObjetoCeleste> ObjetosCelestes { get; set; }
        public DbSet<Observacion> Observaciones { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new EquipoConfiguration());
            modelBuilder.ApplyConfiguration(new TelescopioConfiguration());
            modelBuilder.ApplyConfiguration(new MonturaConfiguration());
            modelBuilder.ApplyConfiguration(new CamaraConfiguration());
            modelBuilder.ApplyConfiguration(new OcularConfiguration());
            modelBuilder.ApplyConfiguration(new ObjetoCelesteConfiguration());
            modelBuilder.ApplyConfiguration(new ObservacionConfiguration());

            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.HasOne(p => p.Socio)
                    .WithMany()
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Telescopio)
                    .WithMany()
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Montura)
                    .WithMany()
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Camara)
                    .WithMany()
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Ocular)
                    .WithMany()
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AuditoriaPrestamo>(entity =>
            {
                entity.HasOne(a => a.Prestamo)
                    .WithMany(p => p.Auditorias)
                    .IsRequired();

                entity.HasOne(a => a.Coordinador)
                    .WithMany()
                    .IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
