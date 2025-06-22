using InnatAPP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnatAPP.Infra.Data.EntitiesConfiguration
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Reviews");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Nota)
                .HasPrecision(3, 2)
                .IsRequired();

            builder.Property(r => r.Resenha)
                .HasMaxLength(500);

            builder.Property(r => r.CriadoEm)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(r => r.AtualizadoEm)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(r => r.Curtidas)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(r => r.Descurtidas)
                .IsRequired()
                .HasDefaultValue(0);

            builder.HasOne(r => r.Avaliador)
                .WithMany(r => r.Reviews)
                .HasForeignKey(r => r.IdAvaliador)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(r => r.Produto)
                .WithMany(r => r.Reviews)
                .HasForeignKey(r => r.IdProduto)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}