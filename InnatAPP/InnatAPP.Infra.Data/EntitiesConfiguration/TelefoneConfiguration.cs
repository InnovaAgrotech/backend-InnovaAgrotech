using InnatAPP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnatAPP.Infra.Data.EntitiesConfiguration
{
    public class TelefoneConfiguration : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.ToTable("Telefones");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Ddd)
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(t => t.Numero)
                .HasMaxLength(9)
                .IsRequired();

            builder.HasOne(t => t.Usuario)
                .WithMany(t => t.Telefones)
                .HasForeignKey(t => t.IdUsuario)
                .IsRequired();
        }
    }
}