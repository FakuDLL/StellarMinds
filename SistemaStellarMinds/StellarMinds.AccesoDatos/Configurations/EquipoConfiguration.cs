using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.AccesoDatos.Configurations
{
    public class EquipoConfiguration : IEntityTypeConfiguration<Equipo>
    {
        public void Configure(EntityTypeBuilder<Equipo> builder)
        {
            builder.ToTable("Equipos");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Marca)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Modelo)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.CantidadDisponible)
                .IsRequired();

            builder.HasDiscriminator<string>("TipoEquipo")
                .HasValue<Telescopio>("Telescopio")
                .HasValue<Montura>("Montura")
                .HasValue<Camara>("Camara")
                .HasValue<Ocular>("Ocular");
        }
    }
}
