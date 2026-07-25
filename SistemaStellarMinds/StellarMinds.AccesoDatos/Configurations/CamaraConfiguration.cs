using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.AccesoDatos.Configurations
{
    public class CamaraConfiguration : IEntityTypeConfiguration<Camara>
    {
        public void Configure(EntityTypeBuilder<Camara> builder)
        {
            builder.Property(c => c.TipoSensor)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Resolucion)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.TamanoPixelMicras)
                .HasColumnType("decimal(10,2)")
                .IsRequired();
        }
    }
}
