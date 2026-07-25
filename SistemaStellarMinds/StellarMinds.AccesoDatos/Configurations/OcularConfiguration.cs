using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.AccesoDatos.Configurations
{
    public class OcularConfiguration : IEntityTypeConfiguration<Ocular>
    {
        public void Configure(EntityTypeBuilder<Ocular> builder)
        {
            builder.Property(o => o.DiametroMm)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(o => o.AnguloVisionGrados)
                .HasColumnType("decimal(10,2)")
                .IsRequired();
        }
    }
}
