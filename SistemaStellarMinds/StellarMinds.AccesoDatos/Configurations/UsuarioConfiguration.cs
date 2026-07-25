using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StellarMinds.LogicaNegocio.Entidades;

namespace StellarMinds.AccesoDatos.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.NombreCompleto)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Direccion)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(u => u.Telefono)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(u => u.NombreUsuario)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(u => u.NombreUsuario)
                .IsUnique();

            builder.Property(u => u.PasswordHash)
                .IsRequired();

            builder.Property(u => u.Rol)
                .IsRequired();

            builder.OwnsOne(u => u.Email, email =>
            {
                email.Property(e => e.Valor)
                    .HasColumnName("Email")
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}