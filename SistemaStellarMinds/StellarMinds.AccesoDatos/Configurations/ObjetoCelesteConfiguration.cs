using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StellarMinds.LogicaNegocio.Entidades;
using StellarMinds.LogicaNegocio.Enums;

namespace StellarMinds.AccesoDatos.Configurations
{
    public class ObjetoCelesteConfiguration : IEntityTypeConfiguration<ObjetoCeleste>
    {
        public void Configure(EntityTypeBuilder<ObjetoCeleste> builder)
        {
            builder.ToTable("ObjetosCelestes");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(o => o.Tipo)
                .IsRequired();

            builder.Property(o => o.MagnitudAparente)
                .HasColumnType("decimal(6,2)")
                .IsRequired();

            builder.HasIndex(o => o.Nombre)
                .IsUnique();

            builder.HasData(
                new { Id = 1, Nombre = "Luna", Tipo = TipoObjetoCeleste.Luna, MagnitudAparente = -12.74m },
                new { Id = 2, Nombre = "Júpiter", Tipo = TipoObjetoCeleste.Planeta, MagnitudAparente = -2.20m },
                new { Id = 3, Nombre = "Saturno", Tipo = TipoObjetoCeleste.Planeta, MagnitudAparente = 0.46m },
                new { Id = 4, Nombre = "Galaxia M42", Tipo = TipoObjetoCeleste.Nebulosa, MagnitudAparente = 4.00m },
                new { Id = 5, Nombre = "Polaris", Tipo = TipoObjetoCeleste.Estrella, MagnitudAparente = 1.98m });
        }
    }
}
