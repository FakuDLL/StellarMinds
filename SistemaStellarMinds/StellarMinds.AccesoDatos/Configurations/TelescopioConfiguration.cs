using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.AccesoDatos.Configurations
{
    public class TelescopioConfiguration : IEntityTypeConfiguration<Telescopio>
    {
        public void Configure(EntityTypeBuilder<Telescopio> builder)
        {
            builder.Property(t => t.AperturaMm)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(t => t.RelacionFocal)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(t => t.DistanciaFocalMm)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(t => t.PesoKg)
                .HasColumnType("decimal(10,2)")
                .IsRequired();
        }
    }
}
