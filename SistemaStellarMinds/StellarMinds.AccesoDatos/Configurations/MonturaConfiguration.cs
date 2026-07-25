using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.AccesoDatos.Configurations
{
    public class MonturaConfiguration : IEntityTypeConfiguration<Montura>
    {
        public void Configure(EntityTypeBuilder<Montura> builder)
        {
            builder.Property(m => m.TipoMontura)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(m => m.CargaUtilKg)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(m => m.EsComputarizado)
                .IsRequired();
        }
    }
}
