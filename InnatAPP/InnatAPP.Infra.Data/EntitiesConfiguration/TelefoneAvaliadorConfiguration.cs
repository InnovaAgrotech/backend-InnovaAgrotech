using InnatAPP.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InnatAPP.Infra.Data.EntitiesConfiguration
{
    public class TelefoneAvaliadorConfiguration : IEntityTypeConfiguration<TelefoneAvaliador>
    {
        public void Configure(EntityTypeBuilder<TelefoneAvaliador> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.Ddd)
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(p => p.Numero)
                .HasMaxLength(9)
                .IsRequired();

            builder.HasOne(e => e.Avaliador)
                .WithMany(e => e.TelefonesAvaliador)
                .HasForeignKey(e => e.IdAvaliador)
                .IsRequired();
        }
    }
}