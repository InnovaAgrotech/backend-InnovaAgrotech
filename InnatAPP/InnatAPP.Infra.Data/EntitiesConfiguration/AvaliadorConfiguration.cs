using InnatAPP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnatAPP.Infra.Data.EntitiesConfiguration
{
    public class AvaliadorConfiguration : IEntityTypeConfiguration<Avaliador>
    {
        public void Configure(EntityTypeBuilder<Avaliador> builder)
        {
            builder.ToTable("Avaliadores");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.IdUsuario)
                .IsRequired();

            builder.HasIndex(a => a.IdUsuario)
                .IsUnique();

            builder.HasOne(a => a.Usuario)
                .WithOne()
                .HasForeignKey<Avaliador>(a => a.IdUsuario)
                .IsRequired();
        }
    }
}