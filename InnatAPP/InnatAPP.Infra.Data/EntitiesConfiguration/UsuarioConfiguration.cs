using InnatAPP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnatAPP.Infra.Data.EntitiesConfiguration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasMaxLength(254)
                .IsRequired();

            builder.Property(u => u.SenhaHash)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(u => u.Foto)
                .HasMaxLength(250);

            builder.Property(u => u.Biografia)
                .HasMaxLength(500);

            builder.OwnsOne(u => u.TipoUsuario, tipo =>
            {
                tipo.Property(t => t.Valor)
                    .HasColumnName("TipoUsuario")
                    .IsRequired();

                tipo.WithOwner(); 
            });

            builder.HasIndex(u => u.Nome)
            .IsUnique();

            builder.HasIndex(u => u.Email)
            .IsUnique();
        }
    }
}