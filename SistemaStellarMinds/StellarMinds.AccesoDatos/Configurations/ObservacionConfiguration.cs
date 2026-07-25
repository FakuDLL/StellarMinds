using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.AccesoDatos.Configurations
{
    public class ObservacionConfiguration : IEntityTypeConfiguration<Observacion>
    {
        public void Configure(EntityTypeBuilder<Observacion> builder)
        {
            builder.ToTable("Observaciones");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Fecha)
                .IsRequired();

            builder.Property(o => o.PrestamoId)
                .IsRequired();

            builder.Property(o => o.ObjetoCelesteId)
                .IsRequired();

            builder.Property(o => o.IndicadorIA)
                .IsRequired();

            builder.Property(o => o.DetalleEvaluacion)
                .IsRequired()
                .HasMaxLength(300);

            builder.HasOne(o => o.Prestamo)
                .WithMany()
                .HasForeignKey(o => o.PrestamoId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.ObjetoCeleste)
                .WithMany()
                .HasForeignKey(o => o.ObjetoCelesteId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
