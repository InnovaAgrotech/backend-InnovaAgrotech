using InnatAPP.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(p => p.Mensagem)
            .HasMaxLength(500);

        builder.Property(p => p.CriadoEm)
            .IsRequired()
            .HasDefaultValue(DateTime.UtcNow);

        builder.Property(p => p.AtualizadoEm)
            .IsRequired()
            .HasDefaultValue(DateTime.UtcNow);

        builder.Property(p => p.Likes)
            .IsRequired()
            .HasDefaultValue(0);

        builder.Property(p => p.Dislikes)
            .IsRequired()
            .HasDefaultValue(0);

        builder.Property(p => p.Avaliacao)
            .HasPrecision(3, 2)
            .IsRequired();

        builder.HasOne(e => e.Avaliador)
            .WithMany(e => e.Reviews)
            .HasForeignKey(e => e.IdAvaliador)
            .IsRequired();

        builder.HasOne(e => e.Produto)
            .WithMany(e => e.Reviews)
            .HasForeignKey(e => e.IdProduto)
            .IsRequired();
    }
}
