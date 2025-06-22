using InnatAPP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnatAPP.Infra.Data.EntitiesConfiguration
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Enderecos");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Numero)
                .HasMaxLength(10);

            builder.Property(e => e.Rua)
                .HasMaxLength(100)
                 .IsRequired();

            builder.Property(e => e.Bairro)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(e => e.Cidade)
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(e => e.Estado)
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(e => e.Complemento)
                .HasMaxLength(100);

            builder.Property(e => e.Cep)
                .HasMaxLength(8)
                .IsRequired();

            builder.HasOne(e => e.Usuario)
                .WithMany(e => e.Enderecos)
                .HasForeignKey(e => e.IdUsuario)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}