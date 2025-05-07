using InnatAPP.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InnatAPP.Infra.Data.EntitiesConfiguration
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Email)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(p => p.Senha)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(p => p.Foto)
                .HasMaxLength(250);

            builder.Property(p => p.Bio)
                .HasMaxLength(500);
        }
    }
}