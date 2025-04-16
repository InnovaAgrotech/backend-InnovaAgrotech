using InnatAPP.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InnatAPP.Infra.Data.EntitiesConfiguration
{
    class AvaliadorConfiguration : IEntityTypeConfiguration<Avaliador>
    {
        public void Configure(EntityTypeBuilder<Avaliador> builder)
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
